using ApplicantTracker.Data;
using ApplicantTracker.Data.AppTrackEntities;
using ApplicantTracker.Data.Interfaces;
using ApplicantTracker.InfraStructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicantTracker.InfraStructure
{
    public class BusinessLayer : IBusinessLayer
    {
        private readonly ICandidateRepository _candRepository;
        private readonly IProfileInfoRepository _profileRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IIndustryRepository _industryRepository;
        private readonly ICandidateStatusRepository _candStatusRepository;
        private readonly ISearchApplicantRepository _searchApplicantRepository;
        private readonly IUserRoleRepository _userRoleRepository;

        public BusinessLayer()
        {
            _candRepository = new CandidateRepository();
            _profileRepository = new ProfileInfoRepository();
            _userRepository = new UserRepository();
            _roleRepository = new RoleRepository();

            _candStatusRepository = new CandidateStatusRepository();
            _searchApplicantRepository = new SearchApplicantRepository();
            _companyRepository = new CompanyRepository();
            _industryRepository = new IndustryRepository();
            _userRoleRepository = new UserRoleRepository();
        }

        public BusinessLayer(ICandidateRepository candRepository,
                             IProfileInfoRepository profileRepository,
                             IUserRepository userRepository,
                             IRoleRepository roleRepository,
                             ICandidateStatusRepository candStatusRepository,
                             ICompanyRepository companyRepository,
                             IIndustryRepository industryRepository,
                             IUserRoleRepository userRoleRepository)
        {
            _candRepository = candRepository;
            _profileRepository = profileRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _candStatusRepository = candStatusRepository;
            _companyRepository = companyRepository;
            _industryRepository = industryRepository;
            _userRoleRepository = userRoleRepository;
        }


        public Task<IList<Data.AppTrackEntities.candidate>> GetAllCandidatesAsync()
        {
            return _candRepository.GetAllAsync();
        }

        public IList<Data.AppTrackEntities.candidate> GetAllCandidates()
        {
            return _candRepository.GetAll();
        }

        public Task<Data.AppTrackEntities.candidate> GetCandidateByMailAsync(string candidateEmail)
        {
            return _candRepository.GetSingleAsync(c => c.PrimaryEmail.Equals(candidateEmail),
                c => c.profileinfoes);//Include related profiles
        }

        public Data.AppTrackEntities.candidate GetCandidateByMail(string candidateEmail)
        {
            return _candRepository.GetSingle(c => c.PrimaryEmail.Equals(candidateEmail),
                c => c.profileinfoes);//Include related profiles
        }

        public Task AddCandidateAsync(params Data.AppTrackEntities.candidate[] candidates)
        {
            //TO DO: Validation and error handling
            return _candRepository.AddAsync(candidates);
        }

        public Task UpdateCandidateAsync(params Data.AppTrackEntities.candidate[] candidates)
        {
            //TO DO: Validation and error handling
            return _candRepository.UpdateAsync(candidates);
        }

        public Task RemoveCandidateAsync(params Data.AppTrackEntities.candidate[] candidates)
        {
            //TO DO: Validation and error handling
            return _candRepository.RemoveAsync(candidates);
        }

        public Data.AppTrackEntities.candidate GetCandidateById(int id)
        {
            return _candRepository.GetSingle(c => c.CandidateId == id);
        }

        public void AddCandidate(params Data.AppTrackEntities.candidate[] candidates)
        {
            //TO DO: Validation and error handling
            _candRepository.Add(candidates);
        }

        public void UpdateCandidate(params Data.AppTrackEntities.candidate[] candidates)
        {
            //TO DO: Validation and error handling
            _candRepository.Update(candidates);
        }

        public void RemoveCandidate(params Data.AppTrackEntities.candidate[] candidates)
        {
            //TO DO: Validation and error handling
            _candRepository.Remove(candidates);
        }

        public Task<Data.AppTrackEntities.candidate> GetCandidateByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        #region Profile

        #region Asyn operations
        public Task<IList<Data.AppTrackEntities.profileinfo>> GetProfilesByCandidateEmailAsync(string candidateEmail)
        {
            throw new NotImplementedException();
        }

        public Task<Data.AppTrackEntities.profileinfo> GetProfilesByIdAsync(string profileId)
        {
            return _profileRepository.GetSingleAsync(prof => prof.ProfileId == Convert.ToInt32(profileId));
        }

        public Task AddProfileAsync(Data.AppTrackEntities.profileinfo profile)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProfileAsync(Data.AppTrackEntities.profileinfo profile)
        {
            throw new NotImplementedException();
        }

        public Task RemoveProfileAsync(Data.AppTrackEntities.profileinfo profile)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region synchronous methods
        public IList<Data.AppTrackEntities.profileinfo> GetProfilesByCandidateEmail(string candidateEmail)
        {
            return _profileRepository.GetList(p => p.candidate.PrimaryEmail.Equals(candidateEmail));
        }

        public void AddProfile(Data.AppTrackEntities.profileinfo profile)
        {
            //TO DO: Validation and error handling
            _profileRepository.Add(profile);
        }

        public void UpdateProfile(Data.AppTrackEntities.profileinfo profile)
        {
            _profileRepository.Update(profile);
        }

        public void RemoveProfile(Data.AppTrackEntities.profileinfo profile)
        {
            _profileRepository.Remove(profile);
        }
        #endregion
        #endregion

        public bool IsUserExists(string email, string password)
        {
            var isExists = _userRepository.GetList(e => e.Email.Equals(email) &&
                                                     e.Password.Equals(password) &&
                                                     e.IsActive == true);
            return isExists.Any();

        }

        public IList<Data.AppTrackEntities.user> GetAllEmployees()
        {
            return _userRepository.GetAll();
        }

        public Task<IList<Data.AppTrackEntities.user>> GetAllEmployeesAsync()
        {
            return _userRepository.GetAllAsync();

        }

        public Task<IList<Data.AppTrackEntities.userrole>> GetUserRolesAsync()
        {
            return _userRoleRepository.GetAllAsync();
        }

        public void AddEmployee(params Data.AppTrackEntities.user[] employee)
        {
            _userRepository.Add(employee);
        }

        public void UpdateEmploee(Data.AppTrackEntities.user employee)
        {
            _userRepository.Update(employee);
        }

        public void RemoveEmployee(Data.AppTrackEntities.user employee)
        {
            _userRepository.Remove(employee);
        }

        public virtual Task AddEmployeeAsync(params Data.AppTrackEntities.user[] employee)
        {
            return _userRepository.AddAsync(employee);
        }

        public Task<user> AddSingleEmployeeAsync(user employee)
        {
            return _userRepository.AddSingleAsync(employee);
        }
        public virtual Task UpdateEmploeeAsync(Data.AppTrackEntities.user employee)
        {
            return _userRepository.UpdateAsync(employee);
        }

        public virtual Task UpdateUserRoleAsync(Data.AppTrackEntities.userrole userrole)
        {
            return _userRoleRepository.UpdateAsync(userrole);
        }

        public virtual Task UpdateCompanyAsync(Data.AppTrackEntities.company company)
        {
            return _companyRepository.UpdateAsync(company);
        }
        public virtual Task UpdateIndustryAsync(Data.AppTrackEntities.industry industry)
        {
            return _industryRepository.UpdateAsync(industry);
        }


        public virtual Task RemoveEmployeeAsync(Data.AppTrackEntities.user employee)
        {
            return _userRepository.RemoveAsync(employee);
        }


        public Task<userrole> AddEmployeeRoleAsync(userrole userRole)
        {
            return _userRoleRepository.AddSingleAsync(userRole);
        }


        public Task<IList<userrole>> GetAllUserRolesAsync()
        {
            return _userRoleRepository.GetAllAsync();
        }

        public Task<IList<Data.AppTrackEntities.role>> GetAllRolesAsync()
        {
            return _roleRepository.GetAllAsync();
        }

        public Task<IList<Data.AppTrackEntities.company>> GetAllCompanysAsync()
        {
            return _companyRepository.GetAllAsync();
        }

        public Task<IList<Data.AppTrackEntities.industry>> GetAllIndustryAsync()
        {
            return _industryRepository.GetAllAsync();
        }

        public Task<Data.AppTrackEntities.role> GetRoleByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddRoleAsync(Data.AppTrackEntities.role role)
        {
            return _roleRepository.AddAsync(role);
        }

        public Task UpdateRoleAsync(Data.AppTrackEntities.role role)
        {
            return _roleRepository.UpdateAsync(role);
        }

        public Task RemoveRoleAsync(Data.AppTrackEntities.role role)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Data.AppTrackEntities.candidatestatu>> GetAllCandStatusAsync()
        {
            return _candStatusRepository.GetAllAsync();
            //throw new NotImplementedException();
        }

        public Task<Data.AppTrackEntities.candidatestatu> GetCandStatusByIdAsync(int id)
        {
            // return _candStatusRepository.GetAllAsync().Result.Where(x => x.CanStatusId == id).FirstOrDefault();

            throw new NotImplementedException();
        }

        public Task AddCompanyAsync(Data.AppTrackEntities.company company)
        {
            return _companyRepository.AddAsync(company);
        }

        public Task AddIndustryAsync(Data.AppTrackEntities.industry industry)
        {
            return _industryRepository.AddAsync(industry);
        }

        public Task AddCandStatusAsync(Data.AppTrackEntities.candidatestatu status)
        {
            return _candStatusRepository.AddAsync(status);
        }

        public Task UpdateCandStatusAsync(Data.AppTrackEntities.candidatestatu status)
        {
            return _candStatusRepository.UpdateAsync(status);
        }

        public Task RemoveCandStatusAsync(Data.AppTrackEntities.candidatestatu status)
        {
            throw new NotImplementedException();
        }


        public virtual async Task<IList<SearchApplicant_Result>> SearchApplicantAsync(string searchText, string status, string company, string experience, string createdBy, string salary, string location, string industry, string days, int? startRecord, int? pageLimit, int totalRecord)
        {
            return await _searchApplicantRepository.SearchApplicantAsync(searchText, status, company, experience, createdBy, salary, location, industry, days, startRecord, pageLimit, totalRecord);
        }

        public virtual IList<SearchApplicant_Result> SearchApplicant(string searchText, string status, string company, string experience, string createdBy, string salary, string location, string industry, string days, int? startRecord, int? pageLimit, out int totalRecord)
        {
            
            return _searchApplicantRepository.SearchApplicant(searchText, status, company, experience, createdBy, salary, location, industry, days, startRecord, pageLimit, out totalRecord);


        }

        public IList<Data.AppTrackEntities.company> GetAllCompany()
        {
            return _companyRepository.GetAll();
        }

        public IList<Data.AppTrackEntities.industry> GetAllIndustry()
        {
            return _industryRepository.GetAll();
        }

        public IList<string> GetLocationList()//Performance Issue
        {
            List<string> locations = new List<string>();
            locations.AddRange(_candRepository.GetAll().Select(x => x.CurrentLocation.ToUpper()).Distinct().ToList());

            //   locations.AddRange(_profileRepository.GetAll().Select(x=>x.))

            return locations;
        }

        public Task RemoveCompanyAsync(company company)
        {
            throw new NotImplementedException();
        }

        public Task RemoveIndustryAsync(industry industry)
        {
            throw new NotImplementedException();
        }


        public Task<user> GetEmployeeByIdAsync(int userId)
        {
            var result = _userRepository.GetSingleAsync(u => u.UserId.Equals(userId));//Include related roles
            return result;
        }

        public Task<userrole> GetUserRoleByIdAsync(int userId)
        {
            var result = _userRoleRepository.GetSingleAsync(u => u.UserId.Equals(userId));//Include related roles

            return result;
        }

        public List<candidate> GetCandidateReport(int userId, string refreshType)
        {
            var result1 = _candRepository.GetAllAsync();
            var result = result1.Result.Where(user => user.AssignedTo.Equals(userId) || user.CreatedBy.Equals(userId) || user.ModifiedBy.Equals(userId));

            var filterRefreshType = new List<candidate>();
            if (refreshType == "week")
            {
                DateTime startOfWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek));
                filterRefreshType = result.Where(user => user.CreateDate >= startOfWeek || user.ModifiedDate <= startOfWeek).ToList();
            }
            if (refreshType == "today")
            {
                filterRefreshType = result.Where(user => user.CreateDate >= DateTime.Today.AddDays(-1) || user.ModifiedDate <= DateTime.Today.AddDays(1)).ToList();
            }
            if (refreshType == "month")
            {
                DateTime startOfMonth = DateTime.Today.AddDays(-1 * (int)(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)));
                filterRefreshType = result.Where(user => user.CreateDate >= startOfMonth || user.ModifiedDate <= startOfMonth).ToList();
            }

            return filterRefreshType;
        }




        public IList<userrole> GetUserRoles()
        {
            throw new NotImplementedException();
        }

        public void AddEmployee(params userrole[] userrole)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmploee(userrole userrole)
        {
            throw new NotImplementedException();
        }

        public void RemoveEmployee(userrole userrole)
        {
            throw new NotImplementedException();
        }

        public List<profileinfo> GetAllProfileInfoByCandidateId(int id)
        {
            return _profileRepository.GetAll().Where(x => x.CandidateId == id).ToList();
        }


    }
}