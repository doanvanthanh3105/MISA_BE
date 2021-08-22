using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.Interfaces;
using MISA.CukCuk.Web.Api;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Api
{
    
    public class PositionController : BaseEntityController<Position>
    {
        IBaseService<Position> _baseService;

        public PositionController(IBaseService<Position> baseService) : base(baseService)
        {
            _baseService = baseService;
        }

    }
}
