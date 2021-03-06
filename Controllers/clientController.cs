﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Breeze.WebApi;
using Breeze.WebApi.EF;
using _2.models;
using Newtonsoft.Json.Linq;


namespace _2.Controllers
{
    [BreezeController]
    public class ClientController : ApiController
    {
        //give the controller the dbcontext
        readonly EFContextProvider<MyDatabaseContext> contextProvider = new EFContextProvider<MyDatabaseContext>();

        //get call for metadata
        [HttpGet]
        public string Metadata()
        {
            return contextProvider.Metadata();
        }
        //call for data from dummys table
        [HttpGet]
        public IQueryable<client> clients()
        {
            return contextProvider.Context.clients;
        }

        //save changes to dummys table
        [HttpPost]
        public SaveResult SaveChanges(JObject saveBundle)
        {
            return contextProvider.SaveChanges(saveBundle);
        }
    }
}