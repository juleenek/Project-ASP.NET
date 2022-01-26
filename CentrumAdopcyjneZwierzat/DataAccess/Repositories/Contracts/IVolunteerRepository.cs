using CentrumAdopcyjneZwierzat.Models.AdoptionCenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentrumAdopcyjneZwierzat.DataAccess.Repositories.Contracts
{
    public interface IVolunteerRepository : IRepositoryBase<Volunteer>
    {
        Volunteer SaveVolunteer(Volunteer volunteer);
    }
}
