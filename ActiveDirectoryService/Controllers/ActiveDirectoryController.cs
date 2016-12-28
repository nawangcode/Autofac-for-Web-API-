using ActiveDirectoryService.ServiceContracts;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace ActiveDirectoryService.Controllers
{
    public class ActiveDirectoryController : ApiController
    {
        readonly IActiveDirectorySync adService;

        public ActiveDirectoryController(IActiveDirectorySync service)
        {
            adService = service;
        }

        [Route("api/ActiveDirectory/{groupName}/{timeFrom}")]
        public async Task<IHttpActionResult> Get(string groupName, DateTime timeFrom)
        {
            if (groupName == null || timeFrom == null)
            {
                return BadRequest();
            }
            return Ok(await adService.SynchronizeUsersAsync(groupName, timeFrom));
            //return await Task.FromResult<bool>(true);
        }
    }
}