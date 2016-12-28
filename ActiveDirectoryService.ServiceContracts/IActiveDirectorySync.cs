using System;
using System.Threading.Tasks;

namespace ActiveDirectoryService.ServiceContracts
{
    public interface IActiveDirectorySync
    {
        Task<bool> SynchronizeUsersAsync(string groupName, DateTime timeFrom);
    }
}
