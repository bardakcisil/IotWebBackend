using IotWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IotWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorDataController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public SensorDataController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult Get()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("IotAppCon"));

            var dbList = dbClient.GetDatabase("IotDB").GetCollection<SensorData>("SensorData").AsQueryable();

            return new JsonResult(dbList);

         }
        /*[HttpPost]
        public JsonResult Post(SensorData sensordata)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("IotAppCon"));

            int LastSensorDataId = dbClient.GetDatabase("IotDB").GetCollection<SensorData>("SensorData").AsQueryable().Count();
            sensordata._Id= LastSensorDataId + 1;

            dbClient.GetDatabase("IotDB").GetCollection<SensorData>("SensorData").InsertOne(sensordata);

            return new JsonResult("Added Successfully");

        }*/
    }
}
