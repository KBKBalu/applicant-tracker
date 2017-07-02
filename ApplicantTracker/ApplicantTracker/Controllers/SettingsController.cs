using ApplicantTracker.InfraStructure;
using ApplicantTracker.InfraStructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace ApplicantTracker.Controllers
{
    public class SettingsController : BaseController
    {
        private readonly IBusinessLayer _businessLayer;

        public SettingsController()
        {
            _businessLayer = new BusinessLayer();
        }

        public SettingsController(IBusinessLayer businessLayer)
        {
            _businessLayer = businessLayer;
        }

        [HttpGet]
        [Route("api/Apptrack/GetAllRolesAsync")]
        public async Task<IList<Data.AppTrackEntities.role>> GetAllRolesAsync()
        {
            return await _businessLayer.GetAllRolesAsync();
        }

        [HttpGet]
        [Route("api/Apptrack/GetAllCompanysAsync")]
        public async Task<IList<Data.AppTrackEntities.company>> GetAllCompanysAsync()
        {
            return await _businessLayer.GetAllCompanysAsync();
        }

        [HttpGet]
        [Route("api/Apptrack/GetAllIndustryAsync")]
        public async Task<IList<Data.AppTrackEntities.industry>> GetAllIndustryAsync()
        {
            return await _businessLayer.GetAllIndustryAsync();
        }

        [HttpPost]
        [Route("api/Apptrack/UpdateRoleAsync")]
        public async Task UpdateRoleAsync(Data.AppTrackEntities.role role)
        {
            await _businessLayer.UpdateRoleAsync(role);
        }

        [HttpPost]
        [Route("api/Apptrack/UpdateCompanyAsync")]
        public async Task UpdateCompanyAsync(Data.AppTrackEntities.company company)
        {
            await _businessLayer.UpdateCompanyAsync(company);
        }

        [HttpPost]
        [Route("api/Apptrack/UpdateIndustryAsync")]
        public async Task UpdateIndustryAsync(Data.AppTrackEntities.industry industry)
        {
            await _businessLayer.UpdateIndustryAsync(industry);
        }

        [HttpPost]
        [Route("api/Apptrack/CreateRoleAsync")]
        public async Task CreateRoleAsync(Data.AppTrackEntities.role role)
        {
            await _businessLayer.AddRoleAsync(role);
        }
        [HttpPost]
        [Route("api/Apptrack/CreateCompanyAsync")]
        public async Task CreateCompanyAsync(Data.AppTrackEntities.company company)
        {
            await _businessLayer.AddCompanyAsync(company);
        }

        [HttpPost]
        [Route("api/Apptrack/CreateIndustryAsync")]
        public async Task CreateIndustryAsync(Data.AppTrackEntities.industry industry)
        {
            await _businessLayer.AddIndustryAsync(industry);
        }

        [HttpGet]
        [Route("api/Apptrack/GetAllStatusAsync")]
        public async Task<IList<Data.AppTrackEntities.candidatestatu>> GetAllStatusAsync()
        {
            return await _businessLayer.GetAllCandStatusAsync();
        }

        [HttpPost]
        [Route("api/Apptrack/UpdateStatusAsync")]
        public async Task UpdateStatusAsync(Data.AppTrackEntities.candidatestatu status)
        {
            await _businessLayer.UpdateCandStatusAsync(status);
        }

        [HttpPost]
        [Route("api/Apptrack/CreateStatusAsync")]
        public async Task CreateStatusAsync(Data.AppTrackEntities.candidatestatu status)
        {
            await _businessLayer.AddCandStatusAsync(status);
        }
        [HttpPost]
        [Route("api/Apptrack/RemoveStatusAsync")]
        public async Task RemoveStatusAsync(Data.AppTrackEntities.candidatestatu status)
        {
            await _businessLayer.RemoveCandStatusAsync(status);
        }

    }
}
