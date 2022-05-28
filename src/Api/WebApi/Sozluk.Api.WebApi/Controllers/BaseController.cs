﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sozluk.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public Guid? UserId => Guid.NewGuid(); // new(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value); test

    }
}