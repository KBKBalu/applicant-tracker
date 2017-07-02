using ApplicantTracker.InfraStructure;
using ApplicantTracker.InfraStructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace ApplicantTracker.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly IBusinessLayer _businessLayer;

        public EmployeeController()
        {
            _businessLayer = new BusinessLayer();
        }

        public EmployeeController(IBusinessLayer businessLayer)
        {
            _businessLayer = businessLayer;
        }

        [HttpGet]
        [Route("api/Apptrack/GetAllUsersAsync")]
        public async Task<IList<Data.AppTrackEntities.user>> GetAllEmployeesAsync()
        {
            return await _businessLayer.GetAllEmployeesAsync();

        }
                
        [HttpGet]
        [Route("api/Apptrack/GetUserRolesAsync")]
        public async Task<IList<Data.AppTrackEntities.userrole>> GetUserRolesAsync()
        {
            return await _businessLayer.GetAllUserRolesAsync();

        }

        [HttpPost]
        [Route("api/Apptrack/GetUserByIdAsync")]
        public async Task<Data.AppTrackEntities.user> GetEmployeeByIdAsync(Data.AppTrackEntities.user user)
        {
            int id = user.UserId;
            return await _businessLayer.GetEmployeeByIdAsync(id);

        }
        
        [HttpPost]
        [Route("api/Apptrack/GetUserRoleByIdAsync")]
        public async Task<Data.AppTrackEntities.userrole> GetUserRoleByIdAsync(Data.AppTrackEntities.userrole userrole)
        {
            int id = userrole.UserId;
            return await _businessLayer.GetUserRoleByIdAsync(id);

        }

        [HttpPost]
        [Route("api/Apptrack/UpdateUserAsync")]
        public async Task UpdateEmploeeAsync(Data.AppTrackEntities.user employee)
        {
            await _businessLayer.UpdateEmploeeAsync(employee);
        }

        [HttpPost]
        [Route("api/Apptrack/UpdateUserRoleAsync")]
        public async Task UpdateUserRoleAsync(Data.AppTrackEntities.userrole userrole)
        {
            await _businessLayer.UpdateUserRoleAsync(userrole);
        }

        [HttpPost]
        [Route("api/Apptrack/submitUserAsync")]
        public async Task submitUserAsync(Data.AppTrackEntities.user employee)
        {
            await _businessLayer.AddEmployeeAsync(employee);
           

        }

        [HttpPost]
        [Route("api/Apptrack/disableUserAsync")]
        public async Task disableUserAsync(int userId)
        {
            //await _businessLayer.AddEmployeeAsync(userId);
        }

        //sample thiru check this method for return entity 
        [HttpPost]
        [Route("api/Apptrack/CreateUserAsync")]
        public async Task<Data.AppTrackEntities.user> AddEmployeeAsync(Data.AppTrackEntities.user employee)
        {
            //await _businessLayer.AddEmployeeAsync(employee);
            Data.AppTrackEntities.user user;
            Data.AppTrackEntities.userrole userrole;
           return await _businessLayer.AddSingleEmployeeAsync(employee);
            //userrole=new Data.AppTrackEntities.userrole{UserId=user.UserId,RoleId=1};
            //await _businessLayer.AddEmployeeRoleAsync(userrole);
        }

        [HttpPost]
        [Route("api/Apptrack/CreateUserRoleAsync")]
        public async Task AddEmployeeRoleAsync(Data.AppTrackEntities.userrole userrole)
        {                                 
            await _businessLayer.AddEmployeeRoleAsync(userrole);
        }

        [HttpPost]
        [Route("api/Apptrack/RemoveUserAsync")]
        public async Task RemoveEmployeeAsync(Data.AppTrackEntities.user employee)
        {
            await _businessLayer.RemoveEmployeeAsync(employee);
        }

        [HttpGet]
        [Route("api/Apptrack/GetAllUsers")]
        public IEnumerable<Data.AppTrackEntities.user> GetAllUsers()
        {
            //******Web API with EF CRUD operations testing start***********
            Data.AppTrackEntities.user employee = new Data.AppTrackEntities.user()
            {
                FirstName = "Shekar  async",
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
            Data.AppTrackEntities.user employee1 = new Data.AppTrackEntities.user()
            {
                FirstName = "Shekar  async",
                UserId = 22,
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
            //Data.AppTrackEntities.role roleManager = new Data.AppTrackEntities.role()
            //{
            //    Name="Manager",
            //    RoleId=1,
            //    Description="test" 
            //};
            //Data.AppTrackEntities.role roleAssociate = new Data.AppTrackEntities.role()
            //{
            //    Name = "Associate",
            //    RoleId = 4,
            //    Description = "test"
            //};
            //Data.AppTrackEntities.role rolAdmin = new Data.AppTrackEntities.role()
            //{
            //    Name = "Admin",
            //    RoleId = 2,
            //    Description = "test"
            //};
            //Data.AppTrackEntities.role roleTL = new Data.AppTrackEntities.role()
            //{
            //    Name = "TeamLeader",
            //    RoleId = 3,
            //    Description = "test"
            //};

            //test create
            _businessLayer.AddEmployeeAsync(employee, employee1);
            //test update
            _businessLayer.UpdateEmploeeAsync(employee);
            //test get
            //test remove
            //_businessLayer.RemoveEmployeeAsync(employee);
            //test get
            var a = _businessLayer.GetAllEmployeesAsync();
            //******Web API with EF CRUD operations testing end***********


            return _businessLayer.GetAllEmployees();
        }
    }
}
