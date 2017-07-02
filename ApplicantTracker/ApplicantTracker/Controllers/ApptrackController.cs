using ApplicantTracker.InfraStructure;
using ApplicantTracker.InfraStructure.Interfaces;
using ApplicantTracker.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using ApplicantTracker.Extensions;
using ApplicantTracker.Data.AppTrackEntities;
using ApplicantTracker.Helpers;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Net.Http.Headers;
using OfficeOpenXml;

namespace ApplicantTracker.Controllers
{

    public class ApptrackController : BaseController
    {


        private readonly IBusinessLayer _businessLayer;

        public ApptrackController()
        {
            _businessLayer = new BusinessLayer();
        }

        public ApptrackController(IBusinessLayer businessLayer)
        {
            _businessLayer = businessLayer;
        }

        [HttpGet]
        [Route("api/Apptrack/testnormal")]
        public IEnumerable<Data.AppTrackEntities.candidate> GetAllCandidates()
        {


            return _businessLayer.GetAllCandidates();
        }

        [HttpGet]
        [Route("api/Apptrack/GetAllCandidatesAsync")]
        public IEnumerable<Data.AppTrackEntities.candidate> GetAllCandidatesAsync()
        {
            //******Web API with EF CRUD operations testing start***********
            Data.AppTrackEntities.user employee = new Data.AppTrackEntities.user()
            {
                FirstName = "Shekar async",
                LastName = "Gadamoni",
                UserId = 1243,
                Password = "test123",
                Mobile = "9703471377",
                MaritalStatus = "M",
                IsActive = true,
                Gender = "M",
                Email = "test@gmail.com",
                Details = "tst",
                DOB = null,
                Address = "Hyderabad"

            };
            //test create
            _businessLayer.AddEmployeeAsync(employee);
            //test update
            _businessLayer.UpdateEmploeeAsync(employee);
            //test get
            //test remove
            //_businessLayer.RemoveEmployeeAsync(employee);
            //test get
            var a = _businessLayer.GetAllEmployeesAsync();
            //******Web API with EF CRUD operations testing end***********


            return _businessLayer.GetAllCandidates();
        }

        // GET: api/Apptrack/5
        [HttpGet]
        [Route("api/Apptrack/Candidate")]
        public Data.AppTrackEntities.candidate Get(string mail)
        {
            return _businessLayer.GetCandidateByMail(mail);
        }

        [HttpGet]
        [Route("api/Apptrack/CandidateById")]
        public CandidateViewModel GetCandidate(int id)
        {
            var candidate = _businessLayer.GetCandidateById(id);
            return new CandidateViewModel(candidate);

        }

        [HttpPost]
        [Route("api/Apptrack/CandidateProfiles")]
        public List<ProfileViewModel> GetCandidateProfiles(ProfileSearchViewModel model)
        {


            var profiles = _businessLayer.GetAllProfileInfoByCandidateId(model.Id);


            List<ProfileViewModel> list = new List<ProfileViewModel>();


            foreach (var profile in profiles)
            {
                var companyName = _businessLayer.GetAllCompany().Where(x => x.CompanyId == profile.CompanyId).Select(y => y.Name).FirstOrDefault();
                list.Add(new ProfileViewModel
                {
                    AppliedPositionFor = profile.AppliedPositionFor,
                    CandidateId = profile.CandidateId,
                    CompanyContact = profile.CompanyContact,
                    CompanyDetails = profile.CompanyDetails,
                    CompanyName = companyName,
                    CompanyId = profile.CompanyId,
                    CurrentStatus = profile.CurrentStatus,
                    DateOfInterview = profile.DateOfInterview.HasValue ? profile.DateOfInterview.Value.ToShortDateString() : null,
                    HRCopy = profile.HRCopy,
                    IndustryId = profile.IndustryId,
                    Interviewer = profile.Interviewer,
                    InterviewerContact = profile.InterviewerMobile,
                    ProfileId = profile.ProfileId,
                    RecruiterContact = profile.ContactOfRecruiter,
                    RecruiterName = profile.NameOfRecruiter,
                    ReferenceType = profile.ReferenceType,
                    TeamLeadName = profile.TeamLeadName

                });

            }

            return list;


            //List <ProfileViewModel> profiles = new List<ProfileViewModel>();
            //for (int i = 0; i < 100; i++)
            //{
            //    profiles.Add(new ProfileViewModel
            //    {
            //        CandidateId = 1,
            //        ProfileId = i + 1,
            //        CurrentStatus = "InProgress"

            //    });
            //}
            //return profiles;

        }

        [HttpGet]
        [Route("api/Apptrack/SearchableItems")]
        public SearchItemViewModel GetSearchableItems()
        {
            return GetItems();


        }

        private SearchItemViewModel GetItems()
        {
            SearchItemViewModel model = new SearchItemViewModel();

            model.Companies.AddRange(GetCompanyList());
            model.CreatedBy.AddRange(GetCreatedByList());
            model.Experiences.AddRange(GetExperienceList());
            model.Locations.AddRange(GetLocationList());
            //  model.Roles.AddRange(GetRoleList());
            model.Salaries.AddRange(GetSalaryList());
            model.Statuses.AddRange(GetStatusList());
            model.Days.AddRange(GetDaysList());
            model.Industry.AddRange(GetIndustryList());
            return model;

        }

        private IEnumerable<ItemViewModel> GetIndustryList()
        {
            var industries = _businessLayer.GetAllIndustry();

            var list = (from industry in industries
                        select new ItemViewModel
                        {
                            Code = industry.IndustryId,
                            Name = industry.Name,
                        }).ToList();

            if (list != null)
            {
            for (int i = 0; i < 3; i++)
            {
                list[i].Show = true;
            }
            }
            else
            {
                list = new List<ItemViewModel>();
            }
            return list;
        }

        private IEnumerable<ItemViewModel> GetDaysList()
        {
            List<ItemViewModel> list = new List<ItemViewModel>();
            list.Add(new ItemViewModel
            {
                Code = -1,
                Name = "SELECT",
            });
            list.Add(new ItemViewModel
            {
                Code = 30,
                Name = "Last 30 Days",
            });
            list.Add(new ItemViewModel
            {
                Code = 60,
                Name = "Last 60 Days",
            });

            list.Add(new ItemViewModel
            {
                Code = 90,
                Name = "Last 90 Days"
            });

            list.Add(new ItemViewModel
            {
                Code = 180,
                Name = "Last 6 Months"
            });

            list.Add(new ItemViewModel
            {
                Code = 365,
                Name = "Last 1 Year"
            });


            return list;
        }

        private IEnumerable<ItemViewModel> GetStatusList()
        {
            var statuses = _businessLayer.GetAllCandStatusAsync();

            var list = (from status in statuses.Result
                        select new ItemViewModel
                        {
                            Code = status.CanStatusId,
                            Name = status.Name,
                        }).ToList();

            if (list != null)
            {
            for (int i = 0; i < 3; i++)
            {
                list[i].Show = true;
            }
            }

            else
            {
                list = new List<ItemViewModel>();
            }
            return list;
        }

        private IEnumerable<ItemViewModel> GetSalaryList()
        {
            List<ItemViewModel> list = new List<ItemViewModel>();
            list.Add(new ItemViewModel
            {
                Code = 1,
                Name = "0-1 Lakhs",
                Show = true
            });
            list.Add(new ItemViewModel
            {
                Code = 2,
                Name = "1-3 Lakhs",
                Show = true
            });

            list.Add(new ItemViewModel
            {
                Code = 3,
                Name = "3-5 Lakhs"
            });

            list.Add(new ItemViewModel
            {
                Code = 4,
                Name = "5-8 Lakhs"
            });

            list.Add(new ItemViewModel
            {
                Code = 5,
                Name = "8-10 Lakhs"
            });

            list.Add(new ItemViewModel
            {
                Code = 5,
                Name = "10+ Lakhs"
            });

            return list;
        }

        //private IEnumerable<ItemViewModel> GetRoleList()
        //{
        //    List<ItemViewModel> list = new List<ItemViewModel>();
        //    list.Add(new ItemViewModel
        //    {
        //        Code = 1,
        //        Name = "Programmer",
        //        Show = true
        //    });
        //    list.Add(new ItemViewModel
        //    {
        //        Code = 2,
        //        Name = "SE",
        //        Show = true
        //    });

        //    list.Add(new ItemViewModel
        //    {
        //        Code = 3,
        //        Name = "ITA"
        //    });

        //    list.Add(new ItemViewModel
        //    {
        //        Code = 4,
        //        Name = "Manager"
        //    });

        //    list.Add(new ItemViewModel
        //    {
        //        Code = 5,
        //        Name = "SM"
        //    });

        //    return list;
        //}

        private IEnumerable<ItemViewModel> GetLocationList()//Doubt
        {
            var locations = _businessLayer.GetLocationList();

            var list = (from location in locations
                        select new ItemViewModel
                        {
                            //Code = location,
                            Name = location,
                        }).ToList();



            if (list != null)
            {
            var count = list.Count;
            for (int i = 0; i < 3; i++)
            {
                if (count > i)
                    list[i].Show = true;
            }
            }
            else
            {
                list = new List<ItemViewModel>();
            }


            return list;
            //List<ItemViewModel> list = new List<ItemViewModel>();
            //list.Add(new ItemViewModel
            //{
            //    Code = 1,
            //    Name = "Hyderabad",
            //    Show = true
            //});
            //list.Add(new ItemViewModel
            //{
            //    Code = 2,
            //    Name = "Amaravati",
            //    Show = true
            //});

            //list.Add(new ItemViewModel
            //{
            //    Code = 3,
            //    Name = "Tenali"
            //});

            //list.Add(new ItemViewModel
            //{
            //    Code = 4,
            //    Name = "Guntur"
            //});

            //list.Add(new ItemViewModel
            //{
            //    Code = 5,
            //    Name = "Vizag"
            //});

            //return list;
        }

        private IEnumerable<ItemViewModel> GetExperienceList()
        {
            List<ItemViewModel> list = new List<ItemViewModel>();
            list.Add(new ItemViewModel
            {
                Code = 1,
                Name = "0-2 Years",
                Show = true
            });
            list.Add(new ItemViewModel
            {
                Code = 2,
                Name = "2-5 Years",
                Show = true
            });

            list.Add(new ItemViewModel
            {
                Code = 3,
                Name = "5-8 Years"
            });

            list.Add(new ItemViewModel
            {
                Code = 4,
                Name = "8-10 Years"
            });

            list.Add(new ItemViewModel
            {
                Code = 5,
                Name = "10+ Years"
            });

            return list;
        }

        private IEnumerable<ItemViewModel> GetCreatedByList()
        {

            var employees = _businessLayer.GetAllEmployees();

            var list = (from employee in employees
                        select new ItemViewModel
                        {
                            Code = employee.UserId,
                            Name = string.Format("{0} {1} {2}", employee.FirstName, employee.MiddleName, employee.LastName)
                        }).ToList();

            if (list != null)
            {
            for (int i = 0; i < 3; i++)
            {
                list[i].Show = true;
            }
            }
            else
            {
                list = new List<ItemViewModel>();
            }
            
            return list;

        }

        private IEnumerable<ItemViewModel> GetCompanyList()
        {
            var companyList = _businessLayer.GetAllCompany();

            var list = (from company in companyList
                        select new ItemViewModel
                        {
                            Code = company.CompanyId,
                            Name = company.Name,
                        }).ToList();

            if (list != null)
            {
            for (int i = 0; i < 3; i++)
            {
                list[i].Show = true;
            }
            }
            else
            {
                list = new List<ItemViewModel>();
            }

            return list;
        }

        [HttpPost]
        [Route("api/Apptrack/SearchCandidate")]
        public IList<CandidateViewModel> SearchCandidate(SearchInputViewModel searchInputViewModel)
        {


            var candidates = _businessLayer.GetAllCandidates();

           
            var experienceList = new List<string>();

            Experience experience = new Experience();
            foreach (var exp in searchInputViewModel.Experience)
            {
                experienceList.Add(experience.GetExperienceById(exp));
            }

            var salaryList = new List<string>();

            Salary salary = new Salary();
            foreach (var item in searchInputViewModel.Salary)
            {
                salaryList.Add(salary.GetSalaryById(item));
            }

            var data = RequestContext.Principal.Identity.Name;
            var keyword = searchInputViewModel.Keyword;
            var status = searchInputViewModel.Status.ToString(',');
            var company = searchInputViewModel.Company.ToString(',');
            var createdBy = searchInputViewModel.CreatedBy.ToString(',');
            var industry = searchInputViewModel.Industry.ToString(',');
            var experince = experienceList.ToString(',');
            var location = searchInputViewModel.Location.ToString(',');
            var sal = salaryList.ToString(',');
            var days = searchInputViewModel.Days > 0 ? Convert.ToString(searchInputViewModel.Days) : null;
            int startRecord=0;
            int pageLimit=10;
            int totalRecord=0;

            var result = _businessLayer.SearchApplicant(keyword, status, company, experince, createdBy, sal, location, industry, days, startRecord, pageLimit,out totalRecord);

            return ConvertCandidateToModel(candidates);
            //foreach(var res in result)
            //{
            //    res.
            //}


            // return ConvertCandidateToModel(result.Result);
        }

        private IList<CandidateViewModel> ConvertCandidateToModel(IList<candidate> candidates)
        {
            List<CandidateViewModel> list = new List<CandidateViewModel>();
            foreach (var candidate in candidates)
            {

                var result = _businessLayer.GetAllEmployeesAsync().Result;
                var user = result.Where(x => x.UserId == candidate.AssignedTo).FirstOrDefault();


                var statusName = _businessLayer.GetAllCandStatusAsync().Result.Where(x => x.CanStatusId == candidate.CanStatusId).First().Name;

                var userName = RequestContext.Principal.Identity.Name;
                var loggedInUser = result.Where(x => x.Email == userName).FirstOrDefault();



                list.Add(new CandidateViewModel
                {
                    AlternateNumber = candidate.AlternateNumber,
                    AssignTo = string.Format("{0} {1} {2}", user.FirstName, user.MiddleName, user.LastName),
                    CandidateId = candidate.CandidateId,
                    CandidateStatus = statusName,
                    CurrentDesignation = candidate.CurrentDesignation,
                    ExperienceInMonths = candidate.ExperienceMonths.Value,
                    ExperienceInYears = candidate.ExperienceYears.Value,
                    CreatedBy = candidate.CreatedBy,
                    CurrentEmployer = candidate.CurrentEmployer,
                    CurrentLocation = candidate.CurrentLocation,
                    DateOfBirth = candidate.DOB.Value,
                    Email = candidate.PrimaryEmail,
                    FirstName = candidate.FirstName,
                    LastName = candidate.LastName,
                    HomeTown = candidate.HomeTown,
                    MiddleName = candidate.MiddleName,
                    MobileNumber = candidate.MobileNumber,
                    NoticePeriod = candidate.NoticePeriod,
                    //  Qualification=candidate.e
                    SalaryInLacs = candidate.SalaryInLacks.Value,
                    SalaryInThousands = candidate.SalaryInThousands,
                    SecondaryEmail = candidate.SecondaryEmail,
                    SkillSet = candidate.Skills,
                    Source = candidate.Source,
                    Industry = candidate.IndustryId,

                    IsEdit = (user.UserId == loggedInUser.UserId)



                });
            }

            return list;
        }

        [HttpPost]
        [Route("api/Apptrack/CreateCandidate")]
        public bool Create([FromBody]CandidateViewModel model)
        {

          //  return true;

            var userName = RequestContext.Principal.Identity.Name;
            var user = _businessLayer.GetAllEmployeesAsync().Result.Where(x => x.Email == userName).FirstOrDefault();

            var statusId = _businessLayer.GetAllCandStatusAsync().Result.Where(x => x.Name.ToUpper() == "CREATED").First().CanStatusId;
            Data.AppTrackEntities.candidate candidate = new Data.AppTrackEntities.candidate
            {
                CreateDate = DateTime.Now,
                CurrentDesignation = model.CurrentDesignation,
                CurrentLocation = model.CurrentLocation,
                DOB = model.DateOfBirth,
                PrimaryEmail = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
                MobileNumber = model.MobileNumber,
                HomeTown = model.HomeTown,
                Source = model.Source,
                SecondaryEmail = model.SecondaryEmail,
                AlternateNumber = model.AlternateNumber,
                CanStatusId = statusId,
                CreatedBy = user.UserId,
                AssignedTo = user.UserId,
                CurrentEmployer = model.CurrentEmployer,
                ExperienceMonths = model.ExperienceInMonths,
                ExperienceYears = model.ExperienceInYears,
                IndustryId = model.Industry,
                ModifiedBy = user.UserId,
                Skills = model.SkillSet,
                SalaryInLacks = model.SalaryInLacs,
                SalaryInThousands = model.SalaryInThousands,
                NoticePeriod = model.NoticePeriod,
                ModifiedDate = DateTime.Now
            };
            try
            {
                _businessLayer.AddCandidate(candidate);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("api/Apptrack/UpdateProfile")]
        public bool UpdateProfile([FromBody]ProfileViewModel model)
        {

            //  return true;

            var userName = RequestContext.Principal.Identity.Name;
            var user = _businessLayer.GetAllEmployeesAsync().Result.Where(x => x.Email == userName).FirstOrDefault();

            //var statusId = _businessLayer.GetAllCandStatusAsync().Result.Where(x => x.Name.ToUpper() == "CREATED").First().CanStatusId;
            Data.AppTrackEntities.profileinfo profile = new Data.AppTrackEntities.profileinfo
            {
                ProfileId = model.ProfileId,
                //CreateDate = DateTime.Now,
                AppliedPositionFor = model.AppliedPositionFor,
                CompanyId = model.CompanyId,
                IndustryId = model.IndustryId.Value,
                CandidateId = model.CandidateId,
                CompanyContact = model.CompanyContact,
                CompanyDetails = model.CompanyDetails,
                ContactOfRecruiter = model.RecruiterContact,
                CreatedBy = user.UserId,
                CurrentStatus = model.CurrentStatus,
                DateOfInterview = !string.IsNullOrEmpty(model.DateOfInterview) ?
               Convert.ToDateTime(model.DateOfInterview) : default(DateTime?),
                HRCopy = model.HRCopy,
                Interviewer = model.Interviewer,
                InterviewerMobile = model.InterviewerContact,
                NameOfRecruiter = model.RecruiterName,
                ReferenceType = model.ReferenceType,
                TeamLeadName = model.TeamLeadName,
                ModifiedBy = user.UserId,
                ModifiedDate = DateTime.Now,

            };
            try
            {
                _businessLayer.UpdateProfile(profile);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }


        [HttpPost]
        [Route("api/Apptrack/UpdateCandidate")]
        public bool Update([FromBody]CandidateViewModel model)
        {
            var userName = RequestContext.Principal.Identity.Name;
            var result = _businessLayer.GetAllEmployeesAsync().Result;
            var user = result.Where(x => Convert.ToString(x.UserId) == model.AssignTo).FirstOrDefault();
            var loggedInUser = result.Where(x => x.Email == userName).FirstOrDefault();

            var statusId = _businessLayer.GetAllCandStatusAsync().Result.Where(x => Convert.ToString(x.CanStatusId) == model.CandidateStatus).First().CanStatusId;
            Data.AppTrackEntities.candidate candidate = new Data.AppTrackEntities.candidate
            {

                CurrentDesignation = model.CurrentDesignation,
                CurrentLocation = model.CurrentLocation,
                DOB = model.DateOfBirth,
                PrimaryEmail = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
                MobileNumber = model.MobileNumber,
                HomeTown = model.HomeTown,
                Source = model.Source,
                SecondaryEmail = model.SecondaryEmail,
                AlternateNumber = model.AlternateNumber,
                CanStatusId = statusId,
                ModifiedDate = DateTime.Now,
                CandidateId = model.CandidateId,
                //CreatedBy = user.UserId,
                AssignedTo = user.UserId,
                CurrentEmployer = model.CurrentEmployer,
                ExperienceMonths = model.ExperienceInMonths > 0 ? model.ExperienceInMonths : default(int?),
                ExperienceYears = model.ExperienceInYears > 0 ? model.ExperienceInYears : default(int?),
                IndustryId = model.Industry > 0 ? model.Industry : -1,//Possible of Exception
                ModifiedBy = user.UserId,
                Skills = model.SkillSet,
                SalaryInLacks = model.SalaryInLacs > 0 ? model.SalaryInLacs : default(int?),
                SalaryInThousands = model.SalaryInThousands > 0 ? model.SalaryInThousands : -1,
                NoticePeriod = model.NoticePeriod,
            };
            try
            {
                _businessLayer.UpdateCandidate(candidate);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        // GET: api/Apptrack/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Apptrack
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Apptrack/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Apptrack/5
        public void Delete(int id)
        {
        }

        [HttpGet]
        [Route("api/search/downloadSearchReport")]
        public async Task<HttpResponseMessage> DownloadSearchReport()
        {
            SearchInputViewModel model;
            HttpResponseMessage result = null;

            var reportFileData = await CreateSearchReport();
            //var reportFileData = await 
            //     _businessLayer.CreateSearchReport(JsonConvert.DeserializeObject<SearchInputViewModel>(model)));
            //if (reportFileData == null)
            //{
            //    return Request.CreateResponse(HttpStatusCode.Gone);
            //}

            result = Request.CreateResponse(HttpStatusCode.OK);
            result.Content = new StreamContent(new MemoryStream(reportFileData));
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            result.Content.Headers.ContentDisposition.FileName = "Profile_Report_" + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".xlsx";

            return result;
        }


        public async Task<byte[]> CreateSearchReport()
        {
            // Retrieve the maximum number of records
            // message.SearchPolicyRequestHeader.StartRecord = 1;
            //message.SearchPolicyRequestHeader.ResultPageSize = int.MaxValue;

            var searchResults = await _businessLayer.GetAllEmployeesAsync();
            byte[] output = null;

            if (searchResults == null) return null;

            //var reportCollection = _policyReportMapper.Map(searchResults.SearchPolicyResponseList);

            return CreateReportInternal(searchResults);
        }

        private byte[] CreateReportInternal(IList<user> reportCollection)
        {
            //foreach (var policyReportItem in reportCollection)
            //{
            //    if (policyReportItem.ChangeDesc != null)
            //    {
            //        policyReportItem.ChangeDesc = CleanUpHtml(policyReportItem.ChangeDesc);
            //    }
            //    if (policyReportItem.ChangeReason != null)
            //    {
            //        policyReportItem.ChangeReason = CleanUpHtml(policyReportItem.ChangeReason);
            //    }
            //}
            using (var pck = new ExcelPackage())
            {
                // Create the worksheet
                using (var ws = pck.Workbook.Worksheets.Add("Report"))
                {
                    // Load the datatable into the sheet, starting from cell A1. Print the column names on row 1
                    ws.Cells["A1"].LoadFromCollection(reportCollection, true);

                    return pck.GetAsByteArray();
                }
            }
        }

        //private string CleanUpHtml(string input)
        //{
        //    return _cleanRegex.Replace(
        //        _brRegex.Replace(_liRegex.Replace(input, "\r\n• "), "\r\n"), string.Empty);
        //}
    }
}
