using ActiveDirectoryService.ServiceContracts;
using System;
using System.Threading.Tasks;

namespace ActiveDirectoryService.ServiceImplementation
{
    public class ActiveDirectorySync : IActiveDirectorySync
    {
        public Task<bool> SynchronizeUsersAsync(string groupName, DateTime timeFrom)
        {
            //todo
            return Task.FromResult(false);
        }
    }
}
