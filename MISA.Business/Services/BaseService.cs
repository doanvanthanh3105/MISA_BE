using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {

        public IBaseRepository<TEntity> _baseRepository;
        ServiceResult _serviceResult;
        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
            _serviceResult = new ServiceResult();
        }

        public virtual ServiceResult Add(TEntity entity)
        {
            entity.EntityStatus = Enum.EntityStatus.Add;
            var isValid = Validate(entity);

            if (isValid)
            {

                _serviceResult.Data = _baseRepository.Add(entity);
                _serviceResult.MISACode = Enum.MISACode.IsValid;
                return _serviceResult;
            }

            else
            {
                return _serviceResult;
            }

        }

        public virtual ServiceResult Delete(Guid entityId)
        {
            ServiceResult serviceResult = new ServiceResult();
            serviceResult.Data = _baseRepository.Delete(entityId);
            return serviceResult;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public TEntity GetByCode(string entityCode)
        {
            return _baseRepository.GetByCode(entityCode);
        }



        public TEntity GetById(Guid entityId)
        {
            return _baseRepository.GetById(entityId);
        }

        public virtual ServiceResult Update(TEntity entity)
        {
            entity.EntityStatus = Enum.EntityStatus.Update;
            var isValid = Validate(entity);

            if (isValid)
            {
                _serviceResult.Data = _baseRepository.Update(entity);
                _serviceResult.MISACode = Enum.MISACode.IsValid;
                return _serviceResult;
            }

            else
            {
                return _serviceResult;
            }
        }

        public bool Validate(TEntity entity)
        {

            var properties = entity.GetType().GetProperties();

            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(entity);
                var displayNameArray = property.GetCustomAttributes(typeof(DisplayNameAttribute), true);
                var displayName = string.Empty;
                if(displayNameArray.Length > 0)
                {
                    displayName = (displayNameArray[0] as DisplayNameAttribute).DisplayName;
                }

                if (property.IsDefined(typeof(Required), false))
                {

                    if (propertyValue == null)
                    {
                        _serviceResult.Data = string.Format(Properties.Resources.NullOrEmptyValidation, displayName);
                        _serviceResult.MISACode = Enum.MISACode.NotValid;
                        _serviceResult.Msg = Properties.Resources.ValidationError;
                        return false;
                    }
                }
                if (property.IsDefined(typeof(CheckDuplicate), false))
                {
                    var propertyName = property.Name;

                    var duplicateEntity = _baseRepository.GetEntityByProperty(entity, property);

                    if (duplicateEntity != null)

                    {
                        _serviceResult.Data = string.Format(Properties.Resources.DuplicateValidation, displayName);
                        _serviceResult.MISACode = Enum.MISACode.NotValid;
                        _serviceResult.Msg = Properties.Resources.ValidationError;
                        return false;
                    }
                }

                if (property.IsDefined(typeof(Maxlength), false))
                {
                    
                    var attributeMaxlength = property.GetCustomAttributes(typeof(Maxlength), true)[0];

                    var length = (attributeMaxlength as Maxlength).Value;
                    var msg = (attributeMaxlength as Maxlength).ErrorMsg;
                    if(propertyValue.ToString().Trim().Length > length)
                    {
                        _serviceResult.Data = string.Format(Properties.Resources.MaxLengthValidation, displayName, length);
                        _serviceResult.MISACode = Enum.MISACode.NotValid;
                        _serviceResult.Msg = Properties.Resources.ValidationError;
                        return false;
                    }
                }

            }

            return true;
        }

        public virtual bool validateCustom(TEntity entity)
        {
            return true;
        }

        
    }
}
