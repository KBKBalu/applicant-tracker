(function (angular) {

    angular.module('sbAdminApp').service('CandidateService',
        ['$http', '$q', '$location', 'baseApiService', function ($http, $q, $location, baseApiService) {


            function CreateCandidate(data) {
                debugger;
                return baseApiService.sendPostQuery("CreateCandidate", data);
            }


            function GetCandidateProfiles(data) {
                debugger;
                return baseApiService.sendPostQuery("CandidateProfiles", data);
            }



            function GetCandidateById(data) {
                debugger;
                baseApiService.sendGetQuery("CandidateById", data);
            }

            function SearchCandidate(data) {
                debugger;
                return baseApiService.sendPostQuery("SearchCandidate", data);
            }

            function loadTemplate(data) {
                debugger;
                baseApiService.sendGetQuery("SearchCandidate", data);
            }

            function GetSearchableItems(data) {

                return baseApiService.sendGetQuery("SearchableItems", data);
            }

            function UpdateCandidate(data) {
                debugger;
                return baseApiService.sendPostQuery("UpdateCandidate", data);
            }

            function downloadSearchReport(data) {
                return baseApiService.sendPostQuery("downloadSearchReport", data);
            }

            return {
                CreateCandidate: CreateCandidate,
                GetCandidateById: GetCandidateById,
                SearchCandidate: SearchCandidate,
                GetCandidateProfiles: GetCandidateProfiles,
                GetSearchableItems: GetSearchableItems,
                UpdateCandidate: UpdateCandidate,
                downloadSearchReport: downloadSearchReport



            };
        }]);
})
(angular);