using CentrumAdopcyjneZwierzat.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentrumAdopcyjneZwierzat.DataAccess.Repositories.Contracts
{
    public interface IUsersListRepository : IRepositoryBase<ApplicationUser>
    {
        Task<IList<ApplicationUser>> List();
        void AddVolunteerAsUser(string firstId, string secondId);
        ApplicationUser SaveUser(ApplicationUser user);

    }
}
