using ApplicantTracker.Data.AppTrackEntities;
using ApplicantTracker.Data.Interfaces;
using ApplicantTracker.InfraStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicantTracker.Data
{
    public class UserRepository : Repository<user>, IUserRepository
    {
    }
}
