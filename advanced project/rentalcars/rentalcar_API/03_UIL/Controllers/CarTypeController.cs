﻿using _01_BOL;
using _02_BLL;
using _03_UIL.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace _03_UIL.Controllers
{
    

    public class CarTypeController : ApiController
    {
        // GET: api/CarType

       

        public IHttpActionResult Get(string id)
        {
            List<BOLCarType> value = RentTypeOfCars.GetCarsTypeFrom_db(id);
            return Ok(value);
        }
        [Route("api/GetsearchType")]
        [HttpGet]
        public IHttpActionResult GetsearchType(string name,string model,string gear)
        {
           BOLCarType value = RentTypeOfCars.GetCarsTypeFrom_db(name, model, gear);
            return Ok(value);
        }

        [Route("api/TypeName")]
        [HttpGet]
        public IHttpActionResult TypeName()
        {
            List<string> value = RentTypeOfCars.GetTypeNames();
            return Ok(value);
        }
        [Route("api/TypeName")]
        [HttpGet]
        public IHttpActionResult getModels(string id)
        {
            List<string> value = RentTypeOfCars.GetTypeModel(id);
            return Ok(value);
        }
        [Route("api/GetGear")]
        [HttpGet]
        public IHttpActionResult getgear()
        {
            List<string> value = RentTypeOfCars.GetTypeGear();
            return Ok(value);
        }
        [Route("api/GetYear")]
        [HttpGet]
        public IHttpActionResult getYear()
        {
            List<DateTime> value = RentTypeOfCars.GetTypeYear();
            return Ok(value);
        }

        [Route("api/DistinctName")]
        [HttpGet]
        public IHttpActionResult DistinctName()
        {
            List<BOLCarType> value = RentTypeOfCars.GetDistinctName();
            return Ok(value);
        }

        // POST: api/CarType
        [AuthenticationFilter]
        [Authorize(Roles = "admin,worker")]
        public IHttpActionResult Post([FromBody]BOLCarType newCarType)
        {
            RentTypeOfCars.AddCarTypeTo_db(newCarType);
            return Ok();
        }

        // PUT: api/CarType/5
        [AuthenticationFilter]
        [Authorize(Roles = "admin")]
        public IHttpActionResult Put([FromBody] List<BOLCarType>  CarType)
        {
            RentTypeOfCars.UpDataCarTypeTo_db(CarType[0], CarType[1]);
            return Ok();
        }

        // DELETE: api/CarType/5
        [AuthenticationFilter]
        [Authorize(Roles = "admin")]
        public IHttpActionResult Delete(BOLCarType carType)
        {
            RentTypeOfCars.deleteFrom_db(carType);
            return Ok();
        }
    }
}
