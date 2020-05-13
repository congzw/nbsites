using System;
using Microsoft.AspNetCore.Mvc;

namespace NbSites.Areas.Web.PRM.Apis
{
    [ApiController]
    [Route("Api/PRM/Test")]
    public class _TestApi : ControllerBase
    {
        [HttpGet("GetDate")]
        public DateTime GetDate()
        {
            return DateTime.Now;
        }
    }
}
