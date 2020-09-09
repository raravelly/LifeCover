using System;
using System.Collections.Generic;
using LifeCover.Services;
using Microsoft.AspNetCore.Mvc;

namespace LifeCover.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccupationsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<string>> GetOccupations()
        {
            return Ok(Enum.GetNames(typeof(Occupation)));
        }
    }
}