using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.Enum;
using MISA.ApplicationCore.Interfaces;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infrastructure
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {

        #region DECLARE
        IConfiguration _configuration;
        string _connectionString;
        protected IDbConnection _dbConnection;
        string _tableName;
        #endregion

        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("MISAAMISLocalConnect");
            _dbConnection = new MySqlConnection(_connectionString);
            _tableName = typeof(TEntity).Name;
        }

        public int Add(TEntity entity)
        {
            var param = MappingDbType(entity);
            var rowAffect = _dbConnection.Execute($"Proc_Insert{_tableName}", param, commandType: CommandType.StoredProcedure);
            return rowAffect;
        }

        public int Delete(Guid entityId)
        {
            var parameter = new DynamicParameters();
            parameter.Add($"@{_tableName}Id", entityId);
            var sqlCommand = $"DELETE FROM {_tableName} WHERE {_tableName}Id = @{_tableName}Id";
            var rowAffect = _dbConnection.Execute(sqlCommand, param: parameter, commandType: CommandType.Text);
            return rowAffect;
        }

        public int Update(TEntity entity)
        {
            var param = MappingDbType(entity);
            var rowAffect = _dbConnection.Execute($"Proc_Update{_tableName}", param, commandType: CommandType.StoredProcedure);
            return rowAffect;
        }

        public IEnumerable<TEntity> GetAll()
        {
            // khởi tạo command text
            var entities = _dbConnection.Query<TEntity>($"Proc_Get{_tableName}s", commandType: CommandType.StoredProcedure);

            // trả về dữ liệu
            return entities;
        }

        TEntity IBaseRepository<TEntity>.GetByCode(string entityCode)
        {
            var parameter = new DynamicParameters();
            parameter.Add($"@{_tableName}Code", entityCode);
            var sqlCommand = $"SELECT * FROM {_tableName} t WHERE t.{_tableName}Code = @{_tableName}Code";
            var entity = _dbConnection.QueryFirstOrDefault<TEntity>(sql: sqlCommand, param: parameter, commandType: CommandType.Text);
            return entity;
        }

        TEntity IBaseRepository<TEntity>.GetById(Guid entityId)
        {
            var parameter = new DynamicParameters();
            parameter.Add($"@{_tableName}Id", entityId);
            var sqlCommand = $"SELECT * FROM {_tableName}  WHERE {_tableName}Id = @{_tableName}Id";
            var entity = _dbConnection.QueryFirstOrDefault<TEntity>(sql: sqlCommand, param: parameter, commandType: CommandType.Text);
            return entity;
        }


        protected DynamicParameters MappingDbType(TEntity entity)
        {
            var properties = entity.GetType().GetProperties();
            var parameters = new DynamicParameters();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                var propertyType = property.PropertyType;
                if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                {
                    parameters.Add($"@{propertyName}", propertyValue, DbType.String);
                }
                else
                {
                    parameters.Add($"@{propertyName}", propertyValue);
                }
            }

            return parameters;
        }

        public TEntity GetEntityByProperty(TEntity entity, PropertyInfo property)
        {
            var propertyName = property.Name;
            var propertyValue = property.GetValue(entity);
            var id = entity.GetType().GetProperty($"{_tableName}Id").GetValue(entity);
            
            var parameter = new DynamicParameters();

            parameter.Add(propertyName, propertyValue);
            parameter.Add($"{_tableName}Id", id);
            var sqlCommand = string.Empty;
            if (entity.EntityStatus == EntityStatus.Add)
            {
                sqlCommand = $"SELECT * FROM {_tableName} WHERE {propertyName} = @{propertyName}";
            }
            else if (entity.EntityStatus == EntityStatus.Update)
            {
                sqlCommand = $"SELECT * FROM {_tableName} WHERE {propertyName} = @{propertyName} AND {_tableName}Id <> @{_tableName}Id";
            }
            else
                return null;

            var res = _dbConnection.QueryFirstOrDefault<TEntity>(sql: sqlCommand, param: parameter, commandType: CommandType.Text);

            return res;
        }
    }
}
