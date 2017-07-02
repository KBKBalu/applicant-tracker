using ApplicantTracker.Data.AppTrackEntities;
using ApplicantTracker.InfraStructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicantTracker.Data.Interfaces
{
    public interface IRoleRepository : IRepository<role>
    {
    }
}
