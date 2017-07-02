using ApplicantTracker.Data.AppTrackEntities;
using ApplicantTracker.InfraStructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicantTracker.Data.Interfaces
{
    public interface ISearchApplicantRepository : IRepository<SearchApplicant_Result>
    {
        Task<IList<SearchApplicant_Result>> SearchApplicantAsync(string searchText, string status, string company, string experience, string createdBy, string salary, string location, string industry, string days, int? startRecord, int? pageLimit, int totalRecord);
        IList<SearchApplicant_Result> SearchApplicant(string searchText, string status, string company, string experience, string createdBy, string salary, string location, string industry, string days, int? startRecord, int? pageLimit,out int totalRecord);
    
    }
    
}
