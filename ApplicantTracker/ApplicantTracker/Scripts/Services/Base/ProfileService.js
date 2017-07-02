(function (angular) {

    angular.module('sbAdminApp').service('ProfileService',
        ['$http', '$q', '$location', 'baseApiService', function ($http, $q, $location, baseApiService) {


            function CreateCandidate(data) {
                debugger;
                baseApiService.sendPostQuery("CreateCandidate", data);
            }


            function GetCandidateProfiles(data) {
                debugger;
                baseApiService.sendPostQuery("CandidateProfiles", data);
            }

            function SearchProfiles(data) {
                debugger;
                return baseApiService.sendPostQuery("SearchProfiles", data);
            }

            function FetchIndustries(data) {
                debugger;
                return baseApiService.sendGetQuery("FetchIndustries", data);
            }

            function FetchCompanies(data) {
                debugger;

                return baseApiService.sendGetQuery("FetchCompanies", data);
            }

            function GetProfileById(data) {
                debugger;
                baseApiService.sendGetQuery("GetProfileById", data);
            }

            function CreateProfile(data) {
                debugger;
                return baseApiService.sendPostQuery("CreateProfile", data);
            }

            function SearchCandidate(data) {
                debugger;
                baseApiService.sendGetQuery("SearchCandidate", data);
            }

            function loadTemplate(data) {
                debugger;
                baseApiService.sendGetQuery("SearchCandidate", data);
            }

            function UpdateProfile(data) {
                debugger;
                return baseApiService.sendPostQuery("UpdateProfile", data);
            }


            return {
                CreateCandidate: CreateCandidate,
                SearchCandidate: SearchCandidate,
                GetCandidateProfiles: GetCandidateProfiles,
                SearchProfiles: SearchProfiles,
                CreateProfile: CreateProfile,
                GetProfileById: GetProfileById,
                FetchIndustries: FetchIndustries,
                FetchCompanies: FetchCompanies,
                UpdateProfile: UpdateProfile


            };
        }]);
})
(angular);