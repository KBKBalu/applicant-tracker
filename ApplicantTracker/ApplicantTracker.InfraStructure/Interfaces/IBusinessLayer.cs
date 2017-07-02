using ApplicantTracker.Data.AppTrackEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicantTracker.InfraStructure.Interfaces
{
    public interface IBusinessLayer
    {
        #region Async Crud operations

        Task<IList<user>> GetAllEmployeesAsync();
        Task<user> GetEmployeeByIdAsync(int userId);
        Task AddEmployeeAsync(params user[] employee);
        Task UpdateEmploeeAsync(user employee);
        Task RemoveEmployeeAsync(user employee);
        Task<user> AddSingleEmployeeAsync(user employee);
        bool IsUserExists(string email, string password);

        
        Task<IList<userrole>> GetAllUserRolesAsync();

        Task<userrole> GetUserRoleByIdAsync(int userId);
        Task<userrole> AddEmployeeRoleAsync(userrole userRole);
        Task UpdateUserRoleAsync(userrole userrole);
        //Task RemoveEmployeeAsync(user employee);
        //bool IsUserExists(string email, string password);



        Task<IList<candidate>> GetAllCandidatesAsync();
        Task<candidate> GetCandidateByMailAsync(string candidateEmail);
        Task AddCandidateAsync(params candidate[] candidates);
        Task UpdateCandidateAsync(params candidate[] candidates);
        Task RemoveCandidateAsync(params candidate[] candidates);

        Task<IList<profileinfo>> GetProfilesByCandidateEmailAsync(string candidateEmail);
        Task<candidate> GetCandidateByIdAsync(int id);
        Task AddProfileAsync(profileinfo profile);
        Task UpdateProfileAsync(profileinfo profile);
        Task RemoveProfileAsync(profileinfo profile);

        Task<IList<role>> GetAllRolesAsync();
        Task<role> GetRoleByIdAsync(int id);
        Task AddRoleAsync(role role);
        Task UpdateRoleAsync(role role);
        Task RemoveRoleAsync(role role);

        Task<IList<company>> GetAllCompanysAsync();
        //Task<company> GetCompanyByIdAsync(int id);
        Task AddCompanyAsync(company company);
        Task UpdateCompanyAsync(company company);
        Task RemoveCompanyAsync(company company);

        Task<IList<industry>> GetAllIndustryAsync();
        //Task<industry> GetIndustryByIdAsync(int id);
        Task AddIndustryAsync(industry industry);
        Task UpdateIndustryAsync(industry industry);
        Task RemoveIndustryAsync(industry industry);

        Task<profileinfo> GetProfilesByIdAsync(string profileId);

        Task<IList<candidatestatu>> GetAllCandStatusAsync();
        Task<candidatestatu> GetCandStatusByIdAsync(int id);
        Task AddCandStatusAsync(candidatestatu status);
        Task UpdateCandStatusAsync(candidatestatu status);
        Task RemoveCandStatusAsync(candidatestatu status);

        Task<IList<SearchApplicant_Result>> SearchApplicantAsync(string searchText, string status, string company, string experience, string createdBy, string salary, string location, string industry, string days, int? startRecord, int? pageLimit, int totalRecord);
        IList<SearchApplicant_Result> SearchApplicant(string searchText, string status, string company, string experience, string createdBy, string salary, string location, string industry, string days, int? startRecord, int? pageLimit, out int totalRecord);
        #endregion


        #region Non Async Crud operations

        IList<candidate> GetAllCandidates();
        candidate GetCandidateByMail(string candidateEmail);
        void AddCandidate(params candidate[] candidates);
        void UpdateCandidate(params candidate[] candidates);
        void RemoveCandidate(params candidate[] candidates);

        IList<profileinfo> GetProfilesByCandidateEmail(string candidateEmail);
        candidate GetCandidateById(int id);
        void AddProfile(profileinfo profile);
        void UpdateProfile(profileinfo profile);
        void RemoveProfile(profileinfo profile);



        IList<user> GetAllEmployees();
        void AddEmployee(params user[] employee);
        void UpdateEmploee(user employee);
        void RemoveEmployee(user employee);
     
        #endregion

        IList<company> GetAllCompany();
        IList<industry> GetAllIndustry();

        IList<string> GetLocationList();

        List<candidate> GetCandidateReport(int userId, string refreshType);

        List<profileinfo> GetAllProfileInfoByCandidateId(int id);


    }
}
