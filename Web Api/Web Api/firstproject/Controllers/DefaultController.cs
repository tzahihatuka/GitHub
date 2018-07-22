﻿using firstproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace firstproject.Controllers
{
    public class DefaultController : ApiController
    {
        // GET: api/Default
        public IEnumerable<Person> Get()
        {
            return new Person[] {
                new Person{ Id=2, Name="Water" ,
                            FoodTaste =Taste.Bitterness,
                            IsVeg =true,
                            Price =7,
                            Description = "drink 10 cups every day"}
            };
        }

        // GET: api/Default/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Default
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Default/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
        }
    }
}
