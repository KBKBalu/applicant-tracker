(function (angular) {
    angular.module('sbAdminApp').service('userService',
        ['$q', 'baseApiService', function ($q, baseApiService) {

            function deleteUser(id) {
                return baseApiService.sendDeleteQuery(id);
            }

            function get(id) {
                return baseApiService.sendGetQuery(id);
            }

            function search(data) {
                return baseApiService.sendPostQuery(data);
            }


            function disableUser(user) {
                debugger;                                      
                return baseApiService.sendPostQuery("UpdateUserAsync", user);
            }


            function submitUser(user) {

                debugger;
                return baseApiService.sendPostQuery("CreateUserAsync", user);

               // return baseApiService.sendPostQuery(user);
            }

            function updateUser(user) {
                debugger;
                return baseApiService.sendPostQuery('UpdateUserAsync', user);               
            }
            function getAllUsers() {
                debugger;
                return baseApiService.sendGetQuery('GetAllUsersAsync');
            }
            function getUserById(user) {
                debugger;
                return baseApiService.sendPostQuery('GetUserByIdAsync', user);
            }

            function getAllStatus() {
                debugger;
                return baseApiService.sendGetQuery('GetAllStatusAsync');
            }
            function getAllRoles() {
                debugger;
                return baseApiService.sendGetQuery('GetAllRolesAsync');
            }

            function createStatus(data) {
                debugger;
                return baseApiService.sendPostQuery('CreateStatusAsync',data);
            }

            function createRole(data) {
                debugger;
                return baseApiService.sendPostQuery('CreateRoleAsync', data);
            }

            function UpdateStatus(data) {
                debugger;
                return baseApiService.sendPostQuery('UpdateStatusAsync', data);
            }
            function UpdateRole(data) {
                debugger;
                return baseApiService.sendPostQuery('UpdateRoleAsync', data);
            }

            function disableStatus(data) {
                debugger;
                return baseApiService.sendPostQuery("UpdateStatusAsync", data);
            }

            function disableRole(data) {
                debugger;
                return baseApiService.sendPostQuery("UpdateRoleAsync", data);
            }

            function getAllCompanys() {
                debugger;
                return baseApiService.sendGetQuery('GetAllCompanysAsync');
            }
          
            function createCompany(data) {
                debugger;
                return baseApiService.sendPostQuery('CreateCompanyAsync', data);
            }
            function UpdateCompany(data) {
                debugger;
                return baseApiService.sendPostQuery('UpdateCompanyAsync', data);
            }

            function disableCompany(company) {
                debugger;
                return baseApiService.sendPostQuery("UpdateCompanyAsync", company);
            }

            function userroles() {
                debugger;
                return baseApiService.sendGetQuery("GetUserRolesAsync");
            }

            function createUserRole(userrole) {
                debugger;
                return baseApiService.sendPostQuery("CreateUserRoleAsync", userrole);
            }

            function getUserRoleById(userrole) {
                debugger;
                return baseApiService.sendPostQuery("GetUserRoleByIdAsync", userrole);
            }
            
            function updateUserRole(userrole) {
                debugger;
                return baseApiService.sendPostQuery("UpdateUserRoleAsync", userrole);
            }          
            
            return {
                deleteUser: deleteUser,
                get: get,
                disableUser:disableUser,
                search: search,
                submitUser: submitUser,
                updateUser: updateUser,
                getAllUsers: getAllUsers,
                getAllStatus: getAllStatus,
                getAllRoles: getAllRoles,
                createStatus: createStatus,
                createRole: createRole,
                UpdateStatus: UpdateStatus,
                UpdateRole: UpdateRole,
                UpdateRole: UpdateRole,
                disableRole:disableRole,
                disableStatus:disableStatus,
                getAllCompanys: getAllCompanys,
                createCompany: createCompany,
                UpdateCompany: UpdateCompany,
                disableCompany: disableCompany,
                getUserById: getUserById,
                createUserRole: createUserRole,
                getUserRoleById: getUserRoleById,
                updateUserRole: updateUserRole

            };
        }]);
})
(angular);