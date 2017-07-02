using ApplicantTracker.Data.AppTrackEntities;
using ApplicantTracker.InfraStructure;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicantTracker.Data.Interfaces
{
    public class SearchApplicantRepository : Repository<SearchApplicant_Result>, ISearchApplicantRepository
    {


        public IList<SearchApplicant_Result> SearchApplicant(string searchText, string status, string company, string experience, string createdBy, string salary, string location, string industry, string days, int? startRecord, int? pageLimit, out int totalRecord)
        {
            List<SearchApplicant_Result> searchResultList;
            //ObjectResult<SearchApplicant_Result> candidateResults = null;
            dynamic candidateResults;
            try
            {
                ObjectParameter Output = new ObjectParameter("TotalRecord", typeof(Int32));

                using (var context = new apptrackEntities())
                {
                    

                    candidateResults = context.SearchApplicant(searchText, status, company, experience, createdBy, salary, location, industry, days, startRecord, pageLimit, Output).ToList();
                    searchResultList = ConvertToSearchResultList(candidateResults);
                    totalRecord = Output.Value == DBNull.Value ? 0 : Convert.ToInt32(Output.Value);
                    
                }
                return searchResultList;

            }
            catch (Exception ex)
            {

                throw;
            }
        }


        private List<SearchApplicant_Result> ConvertToSearchResultList(ObjectResult<SearchApplicant_Result> candidateResults)
        {
            List<SearchApplicant_Result> searchResultList = new List<SearchApplicant_Result>();
            foreach (var candidateResult in candidateResults)
            {

                searchResultList.Add(new SearchApplicant_Result
                {
                    FirstName = candidateResult.FirstName,
                    LastName = candidateResult.LastName,
                    MiddleName = candidateResult.MiddleName,
                    MobileNumber = candidateResult.MobileNumber,
                    AlternateNumber = candidateResult.AlternateNumber,
                    DOB = candidateResult.DOB,
                    PrimaryEmail = candidateResult.PrimaryEmail,
                    SecondaryEmail = candidateResult.SecondaryEmail,
                    CanStatusId = candidateResult.CanStatusId,
                    CurrentEmployer = candidateResult.CurrentEmployer,
                    CurrentDesignation = candidateResult.CurrentDesignation,
                    SalaryInLacks = candidateResult.SalaryInLacks,
                    SalaryInThousands = candidateResult.SalaryInThousands,
                    ExperienceYears = candidateResult.ExperienceYears,
                    ExperienceMonths = candidateResult.ExperienceMonths,
                    Skills = candidateResult.Skills,
                    IndustryId = candidateResult.IndustryId,
                    NoticePeriod = candidateResult.NoticePeriod,
                    AssignedTo = candidateResult.AssignedTo,
                    Resume = candidateResult.Resume,
                    CurrentLocation = candidateResult.CurrentLocation,
                    HomeTown = candidateResult.HomeTown,
                    Source = candidateResult.Source,
                    Qualification = candidateResult.Qualification,
                    Age = candidateResult.Age,
                    DateofSpoken = candidateResult.DateofSpoken,
                    PreferredLocation = candidateResult.PreferredLocation,
                    CreateDate = candidateResult.CreateDate,
                    CreatedBy = candidateResult.CreatedBy,
                    ModifiedDate = candidateResult.ModifiedDate,
                    ModifiedBy = candidateResult.ModifiedBy

                });

            }
            return searchResultList;
        }


        public async Task<IList<SearchApplicant_Result>> SearchApplicantAsync(string searchText, string status, string company, string experience, string createdBy, string salary, string location, string industry, string days, int? startRecord, int? pageLimit, int totalRecord)
        {
            dynamic result = null;
            try
            {
                ObjectParameter Output = new ObjectParameter("TotalRecord", typeof(Int32));

                using (var context = new apptrackEntities())
                {
                    await Task.Run(() =>
                    {


                        result = context.SearchApplicant(searchText, status, company, experience, createdBy, salary, location, industry, days, startRecord, pageLimit, Output).ToList();
                    });

                    totalRecord = Output.Value == DBNull.Value ? 0 : Convert.ToInt32(Output.Value);
                }
                return result;

            }
            catch (Exception ex)
            {

                throw;
            }
        }


    }
}
