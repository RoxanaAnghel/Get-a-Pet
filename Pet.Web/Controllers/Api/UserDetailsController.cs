﻿using Microsoft.AspNet.Identity;
using Pet.Database;
using Pet.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pet.Web.Controllers.Api
{
    [RoutePrefix("api/userdetails")]
    public class UserDetailsController : ApiController
    {
        private static UnitOfWorkFactory unitOfWorkFactory;
        private static IUserDetailsService userDetailsService;


        public UserDetailsController()
        {
            unitOfWorkFactory = new UnitOfWorkFactory(new Config());
            userDetailsService = new UserDetailsService(unitOfWorkFactory);
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetUserId()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Ok(User.Identity.GetUserId());
            }
            return Ok(0);
        }
    }
}
