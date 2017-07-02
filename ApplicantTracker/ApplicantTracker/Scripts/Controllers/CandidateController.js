(function (angular) {


    angular.module('sbAdminApp').controller('CandidateController',
       ['$scope', '$modal', '$log', '$timeout', 'CandidateService', function ($scope, $modal, $log, $timeout, CandidateService) {



           $scope.searchInputViewModel = {};

           $scope.searchInputViewModel.IsRecent = false;
           $scope.searchInputViewModel.IsEmailAddress = false;
           $scope.searchInputViewModel.IsPhoneAddress = false;
           $scope.searchInputViewModel.IsKeyword = false;
           $scope.searchInputViewModel.Keyword = '';
           $scope.searchInputViewModel.Status = '';
           $scope.searchInputViewModel.Company = '';
           $scope.searchInputViewModel.Role = '';

           $scope.Message = '';

           $scope.ConfirmationMessage = "Candidate Created Successfully. Do you want to create Profile for this candidate?"
           $scope.ErrorMessage = "Error occured while process your request. Please try again later...";
           $scope.SuccessMessage = "Candidate Information Updated Successfully";
           $scope.ProfileSuccessMessage = "Profile Created Successfully."
           $scope.ProfileUpdateMessage = "Profile Updated Successfully."
           $scope.IsError = false;
           $scope.IsConfirmed = false;

           $scope.ConfirmationUrl = '/Templates/Common/Confirmation.html';
           $scope.ErrorUrl = '/Templates/Common/Error.html';
           $scope.SuccessUrl = '/Templates/Common/Success.html'
           $scope.ProfileSuccessUrl = '/Templates/Common/ProfileSuccess.html'
           $scope.ProfileUpdateUrl = '/Templates/Common/ProfileUpdate.html'
           $scope.condition = '';
           $scope.Statuses = [];

           //$scope.selectedSalaryInThousands = {};
           //  $scope.selectedSalaryInLacs = {};
           $scope.selectedExperienceInYears = {};
           $scope.selectedExperienceInMonths = {};

           $scope.Size = 0;
           $scope.Candidate = {};
           $scope.Candidate.CandidateId = '';
           $scope.Candidate.FirstName = '';
           $scope.Candidate.MiddleName = '';
           $scope.Candidate.LastName = '';
           $scope.Candidate.MobileNumber = '';
           $scope.Candidate.AlternateNumber = '';
           $scope.Candidate.Email = '';
           $scope.Candidate.SecondaryEmail = '';
           $scope.Candidate.DateOfBirth = '';
           $scope.Candidate.CurrentEmployer = '';
           $scope.Candidate.CurrentDesignation = '';
           $scope.Candidate.CurrentCTC = '';
           $scope.Candidate.CurrentLocation = '';
           $scope.Candidate.HomeTown = '';
           $scope.Candidate.Source = '';
           $scope.Candidate.Status = '';
           $scope.Candidate.SkillSet = '';
           $scope.Candidate.Experience = '';
           $scope.Candidate.Qualification = '';
           $scope.Candidate.NoticePeriod = '';
           $scope.Candidate.SalaryInLacs = '';
           $scope.Candidate.SalaryInThousands = '';

           $scope.Candidates = [];

           $scope.IsExpanded = false;
           $scope.IsInfoExpanded = true;
           $scope.IsStatusExpanded = false;

           $scope.IsRoleExpanded = false;
           $scope.IsCompanyExpanded = false;
           $scope.IsCreatedByExpanded = false;
           $scope.IsExperienceExpanded == false;
           $scope.IsLocationExpanded = false;
           $scope.IsSalaryExpanded = false;
           $scope.Keyword = "";

           $scope.SearchItems = {};
           //   $scope.SearchItems.Days = [];

           $scope.IsMoreStatus = false;
           $scope.IsMoreIndustry = false;
           $scope.IsMoreCompany = false;
           $scope.IsMoreExperience = false;
           $scope.IsMoreCreatedBy = false;
           $scope.IsMoreSalary = false;
           $scope.IsMoreLocation = false;

           $scope.LastDays = [];


           $scope.firstNameError = false;
           $scope.lastNameError = false;
           $scope.dobError = false
           $scope.mobileNumberError = false
           $scope.emailError = false;

           $scope.SalaryInLacs = [];
           $scope.SalaryInThousands = [];
           $scope.ExperienceInYears = [];
           $scope.ExperienceInMonths = [];

           var defaultDay = {
               "name": "Select",
               "id": -1
           };



           // for(var i=30;i<)

           var defaultLac = {
               "name": "Select Lacs",
               "id": -1
           };

           var defaultThousand = {
               "name": "Select Thousand",
               "id": -1
           };

           var defaultYear = {
               "name": "Select Year",
               "id": -1
           };

           var defaultMonth = {
               "name": "Select Month",
               "id": -1
           };
           //$scope.selectedSalaryInLacs = defaultLac;
           //$scope.selectedSalaryInThousands = defaultThousand;
           $scope.selectedExperienceInYears = defaultYear;
           $scope.selectedExperienceInMonths = defaultMonth;
           $scope.ExperienceInYears.push(defaultYear);
           $scope.ExperienceInMonths.push(defaultMonth);

           $scope.SalaryInLacs.push(defaultLac);
           $scope.SalaryInThousands.push(defaultThousand);

           for (var i = 0; i <= 50; i++) {
               var salary = {
                   "name": i,
                   "id": i
               };

               $scope.SalaryInLacs.push(salary);
           }

           for (var i = 0; i <= 95;) {
               var salary = {
                   "name": i,
                   "id": i
               };

               $scope.SalaryInThousands.push(salary);
               i = i + 5;
           }

           for (var i = 0; i <= 30; i++) {
               var item = {
                   "name": i,
                   "id": i
               };

               $scope.ExperienceInYears.push(item);
           }

           for (var i = 0; i <= 11; i++) {
               var item = {
                   "name": i,
                   "id": i
               };

               $scope.ExperienceInMonths.push(item);
           }
           for (var i = 0; i < $scope.SalaryInLacs.length; i++) {
               if ($scope.SalaryInLacs[i].id == -1) {
                   $scope.Candidate.selectedSalaryInLacs = $scope.SalaryInLacs[i];
                   break;
               }
           }

           for (var i = 0; i < $scope.SalaryInThousands.length; i++) {
               if ($scope.SalaryInThousands[i].id == -1) {
                   $scope.Candidate.selectedSalaryInThousands = $scope.SalaryInThousands[i];
                   break;
               }
           }

           for (var i = 0; i < $scope.ExperienceInYears.length; i++) {
               if ($scope.ExperienceInYears[i].id == -1) {
                   $scope.Candidate.selectedExperienceInYears = $scope.ExperienceInYears[i];
                   break;
               }
           }


           for (var i = 0; i < $scope.ExperienceInMonths.length; i++) {
               if ($scope.ExperienceInMonths[i].id == -1) {
                   $scope.Candidate.selectedExperienceInMonths = $scope.ExperienceInMonths[i];
                   break;
               }
           }


           $scope.Industries = [];

           var defaultIndustry = {
               "Code": -1,
               Name: "SELECT INDUSTRY",
           };
           $scope.Industries.push(defaultIndustry);


           $scope.LoadSearchItems = function () {
               debugger;
               CandidateService.GetSearchableItems(null).success(function (data) {
                   debugger;

                   //  $scope.SearchItems.Statuses = 
                   $scope.SearchItems = data;

                   for (var i = 0; i < data.Statuses.length; i++) {
                       $scope.Statuses.push(data.Statuses[i]);
                   }

                   for (var i = 0; i < data.Industry.length; i++) {
                       $scope.Industries.push(data.Industry[i]);
                   }

                   for (var i = 0; i < $scope.Industries.length; i++) {
                       if ($scope.Industries[i].Code == -1) {
                           $scope.Candidate.selectedIndustry = $scope.Industries[i];
                       }
                   }

                   $scope.IsMoreStatus = $scope.Statuses.length > 3;

                   $scope.IsMoreLocation = $scope.SearchItems.Locations.length > 3

                   $scope.IsMoreSalary = $scope.SearchItems.Salaries.length > 3
                   $scope.IsMoreCreatedBy = $scope.SearchItems.CreatedBy.length > 3
                   $scope.IsMoreExperience = $scope.SearchItems.Experiences.length > 3

                   $scope.IsMoreCompany = $scope.SearchItems.Companies.length > 3
                   $scope.IsMoreIndustry = $scope.SearchItems.Industry.length > 3


                   $scope.SearchItems.Days.push(defaultDay);

                   for (var i = 0; i < $scope.SearchItems.Days.length; i++) {
                       if ($scope.SearchItems.Days[i].Code == -1)
                           $scope.SearchItems.selectedDay = $scope.SearchItems.Days[i];
                   }
                   // $scope.Statuses = data.Statuses;
                   debugger;
               }).error(function (data) {

               });
           }




           $scope.ToggleDays = function () {
               $scope.IsDaysExpanded = !$scope.IsDaysExpanded;
           };
           $scope.ToggleStatus = function () {
               $scope.IsStatusExpanded = !$scope.IsStatusExpanded;
           };
           $scope.ToggleRole = function () {
               $scope.IsRoleExpanded = !$scope.IsRoleExpanded;
           };
           $scope.ToggleCompany = function () {
               $scope.IsCompanyExpanded = !$scope.IsCompanyExpanded;
           };
           $scope.ToggleIndustry = function () {
               $scope.IsIndustryExpanded = !$scope.IsIndustryExpanded;
           };
           $scope.ToggleCreatedBy = function () {
               $scope.IsCreatedByExpanded = !$scope.IsCreatedByExpanded;
           };
           $scope.ToggleExperience = function () {
               $scope.IsExperienceExpanded = !$scope.IsExperienceExpanded;
           };

           $scope.ToggleLocation = function () {
               $scope.IsLocationExpanded = !$scope.IsLocationExpanded;
           };

           $scope.ToggleSalary = function () {
               $scope.IsSalaryExpanded = !$scope.IsSalaryExpanded;
           };


           $scope.ShowMoreStatus = function () {
               var modalInstance = $modal.open({
                   size: '1000px',
                   animation: false,
                   backdrop: 'static',
                   templateUrl: '/Templates/Candidate/More.html',
                   controller: 'moreModalCtrl',
                   scope: $scope,
                   windowClass: 'large-Modal',
                   resolve: {
                       candidate: function () {
                           return $scope.candidate;
                       }
                   }
               });
               modalInstance.result.then(function (response) {
                   debugger;
                   $scope.currentCandidate = response;
               }, function () {
                   // $log.info('Modal dismissed at: ' + new Date());
               });
           };


           $scope.ShowMoreRoles = function () {
               var modalInstance = $modal.open({
                   size: '1000px',
                   animation: false,
                   backdrop: 'static',
                   templateUrl: '/Templates/Candidate/MoreRoles.html',
                   controller: 'moreModalCtrl',
                   scope: $scope,
                   windowClass: 'large-Modal',
                   resolve: {
                       candidate: function () {
                           return $scope.candidate;
                       }
                   }
               });
               modalInstance.result.then(function (response) {
                   debugger;
                   $scope.currentCandidate = response;
               }, function () {
                   $log.info('Modal dismissed at: ' + new Date());
               });
           };

           $scope.ShowMoreCreatedBy = function () {
               var modalInstance = $modal.open({
                   size: '1000px',
                   animation: false,
                   backdrop: 'static',
                   templateUrl: '/Templates/Candidate/MoreCreatedBy.html',
                   controller: 'moreModalCtrl',
                   scope: $scope,
                   windowClass: 'large-Modal',
                   resolve: {
                       candidate: function () {
                           return $scope.candidate;
                       }
                   }
               });
               modalInstance.result.then(function (response) {
                   debugger;
                   $scope.currentCandidate = response;
               }, function () {
                   $log.info('Modal dismissed at: ' + new Date());
               });
           };


           $scope.ShowMoreExperience = function () {
               var modalInstance = $modal.open({
                   size: '1000px',
                   animation: false,
                   backdrop: 'static',
                   templateUrl: '/Templates/Candidate/MoreExperience.html',
                   controller: 'moreModalCtrl',
                   scope: $scope,
                   windowClass: 'large-Modal',
                   resolve: {
                       candidate: function () {
                           return $scope.candidate;
                       }
                   }
               });
               modalInstance.result.then(function (response) {
                   debugger;
                   $scope.currentCandidate = response;
               }, function () {
                   $log.info('Modal dismissed at: ' + new Date());
               });
           };

           $scope.ShowMoreCompany = function () {
               var modalInstance = $modal.open({
                   size: '1000px',
                   animation: false,
                   backdrop: 'static',
                   templateUrl: '/Templates/Candidate/MoreCompany.html',
                   controller: 'moreModalCtrl',
                   scope: $scope,
                   windowClass: 'large-Modal',
                   resolve: {
                       candidate: function () {
                           return $scope.candidate;
                       }
                   }
               });
               modalInstance.result.then(function (response) {
                   debugger;
                   $scope.currentCandidate = response;
               }, function () {
                   $log.info('Modal dismissed at: ' + new Date());
               });
           };

           $scope.ShowMoreIndustry = function () {
               var modalInstance = $modal.open({
                   size: '1000px',
                   animation: false,
                   backdrop: 'static',
                   templateUrl: '/Templates/Candidate/MoreIndustry.html',
                   controller: 'moreModalCtrl',
                   scope: $scope,
                   windowClass: 'large-Modal',
                   resolve: {
                       candidate: function () {
                           return $scope.candidate;
                       }
                   }
               });
               modalInstance.result.then(function (response) {
                   debugger;
                   $scope.currentCandidate = response;
               }, function () {
                   $log.info('Modal dismissed at: ' + new Date());
               });
           };

           $scope.ShowMoreLocation = function () {
               var modalInstance = $modal.open({
                   size: '1000px',
                   animation: false,
                   backdrop: 'static',
                   templateUrl: '/Templates/Candidate/MoreLocation.html',
                   controller: 'moreModalCtrl',
                   scope: $scope,
                   windowClass: 'large-Modal',
                   resolve: {
                       candidate: function () {
                           return $scope.candidate;
                       }
                   }
               });
               modalInstance.result.then(function (response) {
                   debugger;
                   $scope.currentCandidate = response;
               }, function () {
                   $log.info('Modal dismissed at: ' + new Date());
               });
           };

           $scope.ShowMoreSalary = function () {
               var modalInstance = $modal.open({
                   size: '1000px',
                   animation: false,
                   backdrop: 'static',
                   templateUrl: '/Templates/Candidate/MoreSalary.html',
                   controller: 'moreModalCtrl',
                   scope: $scope,
                   windowClass: 'large-Modal',
                   resolve: {
                       candidate: function () {
                           return $scope.candidate;
                       }
                   }
               });
               modalInstance.result.then(function (response) {
                   debugger;
                   $scope.currentCandidate = response;
               }, function () {
                   $log.info('Modal dismissed at: ' + new Date());
               });
           };



           //for (var i = 0; i < 10; i++) {
           //    var item = {
           //        CandidateId: i,
           //        FirstName: "FirstName" + i,
           //        LastName: "LastName" + i,
           //        MobileNumber: "000000000" + i,
           //        Status: "Interview Scheduled",

           //    };
           //    $scope.Candidates.push(item);

           //}

           $scope.recordsFound = false;

           $scope.showAlert = function (url) {
               debugger;

               //var url = '/Templates/Common/' + $scope.FileName;
               debugger;
               var modalInstance = $modal.open({
                   animation: false,
                   backdrop: 'static',
                   templateUrl: url,
                   controller: 'AlterModalController',
                   keyboard: false,
                   scope: $scope,
                   windowclass: 'centre-Modal',
                   resolve: {
                       param1: null
                   }
               });
               modalInstance.result.then(function (response) {


               }, function () {
               });
           };

           $scope.SearchCandidate = function () {
               debugger;
               $scope.IsLoading = true;
               var selectedStatuses = GetSelectedStatus();
               // var selectedRoles = GetSelectedRoles();
               var selectedCompanies = GetSelectedCompanies();
               var selectedExperience = GetSelectedExperiences();
               var selectedCreatedBy = GetSelectedCreatedBy();
               var selectedSalary = GetSelectedSalary();
               var selectedLocations = GetSelectedLocations();
               var selectedIndustry = GetSelectedIndustry();

               var searchInputViewModel =
                   {
                       Keyword: $scope.Keyword,
                       Status: selectedStatuses,
                       //   Role: selectedRoles,
                       Company: selectedCompanies,
                       Experience: selectedExperience,
                       CreatedBy: selectedCreatedBy,
                       Salary: selectedSalary,
                       Location: selectedLocations,
                       Industry: selectedIndustry,
                       Days: $scope.SearchItems.selectedDay.Code
                       //30//Need to change


                   };

               CandidateService.SearchCandidate(searchInputViewModel).success(function (data) {
                   debugger;
                   $scope.Candidates = [];
                   for (var i = 0; i < data.length; i++) {
                       var candidate = {
                           CandidateId: data[i].CandidateId,
                           FirstName: data[i].FirstName,
                           MiddleName: data[i].MiddleName,
                           LastName: data[i].LastName,
                           MobileNumber: data[i].MobileNumber,
                           AlternateNumber: data[i].AlternateNumber,
                           Email: data[i].Email,
                           SecondaryEmail: data[i].SecondaryEmail,
                           DateOfBirth: data[i].DateOfBirth,
                           CurrentEmployer: data[i].CurrentEmployer,
                           CurrentDesignation: data[i].CurrentDesignation,
                           CurrentCTC: data[i].CurrentDesignation,
                           CurrentLocation: data[i].CurrentLocation,
                           HomeTown: data[i].HomeTown,
                           Source: data[i].Source,
                           Industry: data[i].Industry,
                           NoticePeriod: data[i].NoticePeriod,
                           CandidateStatus: data[i].CandidateStatus,
                           AssignTo: data[i].AssignTo,
                           SkillSet: data[i].SkillSet,
                           SalaryInLacs: data[i].SalaryInLacs,
                           SalaryInThousands: data[i].SalaryInThousands,
                           ExperienceInYears: data[i].ExperienceInYears,
                           ExperienceInMonths: data[i].ExperienceInMonths,
                           IsEdit: data[i].IsEdit
                       };
                       $scope.Candidates.push(candidate);
                   }

                   $scope.IsLoading = false;
               }).error(function (data) {
                   $scope.IsLoading = false;
               });

           };
           //export to excel start
           $scope.buildSearchRequest = function () {
               buildSearchRequest();
           };

           $scope.downloadSearchReport1 = function () {
               alert("Work in progress! Coming Soon");
           };

           $scope.downloadSearchReport = function () {
               debugger;
               //var searchMessage = buildSearchRequest();
               var searchMessage = null;
               $scope.isLoading = true;
               $scope.isError = false;
               
               //$scope.pagination.totalItems = 0;

               var iframe,
                   form,
                   input,
                   timer,
                   lastModified,
                   doc,
                   updatedIframe,
                   updatedDoc;

               iframe = document.createElement("iframe");
               form = document.createElement("form");
               input = document.createElement("input");

               iframe.style.display = 'none';
               iframe.setAttribute('id', 'export-frame-id');
               iframe.setAttribute('src', 'about:blank');
               iframe.setAttribute('name', 'export-frame');

               //var location = $location.absUrl().split('#')[0].replace(/\/$/, '');

               form.setAttribute('action', CandidateService.downloadSearchReport());
               form.setAttribute('target', 'export-frame');
               form.setAttribute('method', 'post');

               input.setAttribute('name', 'data');
               input.setAttribute('value', JSON.stringify(searchMessage));

               //if ($scope.searchMode == 'id') {
               //    input.setAttribute('name', 'id');
               //    input.setAttribute('value', $scope.searchFilter.searchText);
               //}

               document.body.appendChild(iframe);
               iframe.appendChild(form);
               form.appendChild(input);

               doc = iframe.contentDocument || iframe.contentWindow.document;
               lastModified = doc.lastModified;

               form.submit();

               // NOTE: Unfortunately chrome doesn't fire load event of iframe in case of file response. SO this is a possible workaround.
               timer = setInterval(function () {
                   updatedIframe = document.getElementById('export-frame-id');
                   updatedDoc = updatedIframe.contentDocument || updatedIframe.contentWindow.document;

                   if (updatedDoc.lastModified !== lastModified) {
                       $scope.isLoading = false;

                       // for cross browser support
                       updatedIframe.parentNode.removeChild(updatedIframe);
                       clearInterval(timer);

                       $scope.$apply();

                       return;
                   }
               }, 1000);
           };


           function buildSearchRequest() {

               var selectedStatuses = GetSelectedStatus();               
               var selectedCompanies = GetSelectedCompanies();
               var selectedExperience = GetSelectedExperiences();
               var selectedCreatedBy = GetSelectedCreatedBy();
               var selectedSalary = GetSelectedSalary();
               var selectedLocations = GetSelectedLocations();
               var selectedIndustry = GetSelectedIndustry();

               var searchInputViewModel =
                   {
                       Keyword: $scope.Keyword || "",
                       Status: selectedStatuses,
                       //   Role: selectedRoles,
                       Company:uiSelectToArray(selectedCompanies),
                       Experience:uiSelectToArray(selectedExperience),
                       CreatedBy:uiSelectToArray(selectedCreatedBy),
                       Salary:uiSelectToArray(selectedSalary),
                       Location:uiSelectToArray(selectedLocations),
                       Industry:uiSelectToArray(selectedIndustry),
                       Days: $scope.SearchItems.selectedDay.Code
                       //30//Need to change


                   };              

               return searchInputViewModel;
           }

           function uiSelectToArray(json) {

               if (isEmpty(json)) {
                   return null;
               };

               var array = [];

               angular.forEach(json, function (val, i) {
                   array.push(val.ID);
               });

               function isEmpty(obj) {
                   for (var i in obj) {
                       return false;
                   }

                   return true;
               }

               return array.length > 0 ? array : null;
           };

           //export to excel end


           $scope.open = function (size) {

               var modalInstance = $modal.open({
                   size: '1000px',
                   animation: false,
                   backdrop: 'static',
                   templateUrl: '/Templates/Candidate/Create.html',
                   controller: 'createModalCtrl',
                   scope: $scope,
                   windowClass: 'large-Modal',
                   resolve: {
                       candidate: function () {
                           return $scope.candidate;
                       }
                   }
               });
               modalInstance.result.then(function (response) {
                   debugger;
                   $scope.currentCandidate = response;
               }, function () {
                   $log.info('Modal dismissed at: ' + new Date());
               });
           };


           $scope.view = function (candidate, size) {

               $scope.SelectedCandidate = candidate;
               $scope.Candidate.Profiles = [];

               debugger;
               var modalInstance = $modal.open({
                   //  size: size,
                   animation: false,
                   backdrop: 'static',
                   templateUrl: '/Templates/Candidate/View.html',
                   controller: 'viewModalCtrl',
                   scope: $scope,
                   windowClass: 'large-Modal',
                   resolve: {
                       candidate: function () {
                           return $scope.candidate;
                       }
                   }
               });
               modalInstance.result.then(function (response) {
                   debugger;
                   $scope.currentCandidate = response;
               }, function () {
                   $log.info('Modal dismissed at: ' + new Date());
               });
           };

           $scope.Edit = function (candidate, size) {



               // Candidate.selectedStatus =
               $scope.UpdateCandidate = {};
               $scope.UpdateCandidate = candidate;


               var result = SetDefaults();
               //for (var i = 0; i < $scope.SearchItems.Statuses.length; i++) {
               //    if ($scope.SelectedCandidate.CandidateStatus == $scope.SearchItems.Statuses[i].Name) {
               //        $scope.Candidate.selectedStatus = $scope.SearchItems.Statuses[i];
               //        break;
               //    }
               //}


               //for (var i = 0; i < $scope.SalaryInLacs.length; i++) {
               //    if ($scope.SalaryInLacs[i].id == $scope.SelectedCandidate.SalaryInLacs) {
               //        $scope.SelectedCandidate.selectedSalaryInLacs = $scope.SalaryInLacs[i];
               //        break;
               //    }
               //}

               //for (var i = 0; i < $scope.SalaryInThousands.length; i++) {
               //    if ($scope.SalaryInThousands[i].id == $scope.SelectedCandidate.SalaryInThousands) {
               //        $scope.SelectedCandidate.selectedSalaryInThousands = $scope.SalaryInThousands[i];
               //        break;
               //    }
               //}

               //for (var i = 0; i < $scope.ExperienceInYears.length; i++) {
               //    if ($scope.ExperienceInYears[i].id == $scope.SelectedCandidate.ExperienceInYears) {
               //        $scope.SelectedCandidate.selectedExperienceInYears = $scope.ExperienceInYears[i];
               //        break;
               //    }
               //}


               //for (var i = 0; i < $scope.ExperienceInMonths.length; i++) {
               //    if ($scope.ExperienceInMonths[i].id == $scope.SelectedCandidate.ExperienceInMonths) {
               //        $scope.SelectedCandidate.selectedExperienceInMonths = $scope.ExperienceInMonths[i];
               //        break;
               //    }
               //}



               debugger;
               var modalInstance = $modal.open({
                   //  size: size,
                   animation: false,
                   backdrop: 'static',
                   templateUrl: '/Templates/Candidate/Edit.html',
                   controller: 'editModalCtrl',
                   scope: $scope,
                   windowClass: 'large-Modal',
                   resolve: {
                       candidate: function () {
                           return $scope.candidate;
                       }
                   }
               });
               modalInstance.result.then(function (response) {
                   debugger;
                   $scope.currentCandidate = response;
               }, function () {
                   $log.info('Modal dismissed at: ' + new Date());
               });
           };

           $scope.OpenProfile = function (size) {
               //Need to add code for Profile create
               debugger;
               var modalInstance = $modal.open({
                   size: '800px',
                   //size: size,
                   animation: false,
                   backdrop: 'static',
                   templateUrl: '/Templates/Profile/Create.html',
                   controller: 'ProfileController',
                   keyboard: false,
                   scope: $scope,
                   windowClass: 'large-Modal',
                   resolve: {
                       param1: null
                   }
               });
               modalInstance.result.then(function (response) {


               }, function () {
                   $log.info('Modal dismissed at: ' + new Date());
               });
           };

           $scope.ViewProfile = function (profile) {
               debugger;

               $scope.SelectedProfile = {};
               $scope.SelectedProfile = profile;

               debugger;
               var modalInstance = $modal.open({
                   size: '800px',
                   //size: size,
                   animation: false,
                   backdrop: 'static',
                   templateUrl: '/Templates/Profile/ViewProfile.html',
                   controller: 'ProfileController',
                   keyboard: false,
                   scope: $scope,
                   windowClass: 'large-Modal',
                   resolve: {
                       param1: null
                   }
               });
               modalInstance.result.then(function (response) {


               }, function () {
                   $log.info('Modal dismissed at: ' + new Date());
               });

               //$scope.Profile = Profile.GetProfileById(ProfileId);
           }

           //$scope.ProfileView = function (ProfileId, CandidateId) {

           //};

           $scope.EditProfile = function (profile) {

               $scope.UpdateProfileInfo = {};
               $scope.UpdateProfileInfo = profile;
               var modalInstance = $modal.open({
                   size: '800px',
                   //size: size,
                   animation: false,
                   backdrop: 'static',
                   templateUrl: '/Templates/Profile/Edit.html',
                   controller: 'ProfileController',
                   keyboard: false,
                   scope: $scope,
                   windowClass: 'large-Modal',
                   resolve: {
                       param1: null
                   }
               });
               modalInstance.result.then(function (response) {


               }, function () {
                   $log.info('Modal dismissed at: ' + new Date());
               });

           };

           function SetDefaults() {
               debugger;

               for (var i = 0; i < $scope.SearchItems.Industry.length; i++) {
                   if ($scope.SearchItems.Industry[i].Code == $scope.UpdateCandidate.Industry) {
                       $scope.UpdateCandidate.selectedIndustry = $scope.SearchItems.Industry[i];
                   }

               }
               for (var i = 0; i < $scope.SearchItems.CreatedBy.length; i++) {
                   if ($scope.UpdateCandidate.AssignTo == $scope.SearchItems.CreatedBy[i].Name) {
                       $scope.UpdateCandidate.SelectedAssignTo = $scope.SearchItems.CreatedBy[i];
                       break;
                   }

               }

               for (var i = 0; i < $scope.SearchItems.Statuses.length; i++) {
                   if ($scope.UpdateCandidate.CandidateStatus == $scope.SearchItems.Statuses[i].Name) {
                       $scope.UpdateCandidate.selectedStatus = $scope.SearchItems.Statuses[i];
                       break;
                   }
               }


               for (var i = 0; i < $scope.SalaryInLacs.length; i++) {
                   if ($scope.SalaryInLacs[i].id == $scope.UpdateCandidate.SalaryInLacs) {
                       $scope.UpdateCandidate.selectedSalaryInLacs = $scope.SalaryInLacs[i];
                       break;
                   }
               }

               for (var i = 0; i < $scope.SalaryInThousands.length; i++) {
                   if ($scope.SalaryInThousands[i].id == $scope.UpdateCandidate.SalaryInThousands) {
                       $scope.UpdateCandidate.selectedSalaryInThousands = $scope.SalaryInThousands[i];
                       break;
                   }
               }

               for (var i = 0; i < $scope.ExperienceInYears.length; i++) {
                   if ($scope.ExperienceInYears[i].id == $scope.UpdateCandidate.ExperienceInYears) {
                       $scope.UpdateCandidate.selectedExperienceInYears = $scope.ExperienceInYears[i];
                       break;
                   }
               }


               for (var i = 0; i < $scope.ExperienceInMonths.length; i++) {
                   if ($scope.ExperienceInMonths[i].id == $scope.UpdateCandidate.ExperienceInMonths) {
                       $scope.UpdateCandidate.selectedExperienceInMonths = $scope.ExperienceInMonths[i];
                       break;
                   }
               }

               return true;
           }

           function GetSelectedIndustry() {

               var selectedItems = [];
               for (var i = 0; i < $scope.SearchItems.Industry.length; i++) {
                   if ($scope.SearchItems.Industry[i].IsSelected) {
                       selectedItems.push($scope.SearchItems.Industry[i].Code);
                   }

               }
               return selectedItems;
           };

           function GetSelectedStatus() {

               var selectedItems = [];
               for (var i = 0; i < $scope.SearchItems.Statuses.length; i++) {
                   if ($scope.SearchItems.Statuses[i].IsSelected) {
                       selectedItems.push($scope.SearchItems.Statuses[i].Code);
                   }

               }
               return selectedItems;
           };

           function GetSelectedRoles() {

               var roles = [];
               for (var i = 0; i < $scope.SearchItems.Roles.length; i++) {
                   if ($scope.SearchItems.Roles[i].IsSelected) {
                       roles.push($scope.SearchItems.Roles[i].Code);
                   }

               }
               return roles;
           };

           function GetSelectedLocations() {

               var locations = [];
               for (var i = 0; i < $scope.SearchItems.Locations.length; i++) {
                   if ($scope.SearchItems.Locations[i].IsSelected) {
                       locations.push($scope.SearchItems.Locations[i].Name);
                   }

               }
               return locations;
           };

           function GetSelectedSalary() {

               var list = [];
               for (var i = 0; i < $scope.SearchItems.Salaries.length; i++) {
                   if ($scope.SearchItems.Salaries[i].IsSelected) {
                       list.push($scope.SearchItems.Salaries[i].Code);
                   }

               }
               return list;
           };

           function GetSelectedCompanies() {

               var list = [];
               for (var i = 0; i < $scope.SearchItems.Companies.length ; i++) {
                   if ($scope.SearchItems.Companies[i].IsSelected) {
                       list.push($scope.SearchItems.Companies[i].Code);
                   }

               }
               return list;
           };


           function GetSelectedExperiences() {

               var list = [];
               for (var i = 0; i < $scope.SearchItems.Experiences.length ; i++) {
                   if ($scope.SearchItems.Experiences[i].IsSelected) {
                       list.push($scope.SearchItems.Experiences[i].Code);
                   }

               }
               return list;
           };

           function GetSelectedCreatedBy() {

               var list = [];
               for (var i = 0; i < $scope.SearchItems.CreatedBy.length ; i++) {
                   if ($scope.SearchItems.CreatedBy[i].IsSelected) {
                       list.push($scope.SearchItems.CreatedBy[i].Code);
                   }

               }
               return list;
           };



           $scope.showItems = function (item) {
               return item.Show || item.IsSelected;
           };
       }]);


    angular.module('sbAdminApp').controller('createModalCtrl',
       ['$scope', '$modalInstance', 'CandidateService', '$modal', function ($scope, $modalInstance, CandidateService, $modal) {



           $scope.Create = function () {
               debugger;


               $scope.IsError = false;
               //var firstNameError = false;

               //if (typeof $scope.Candidate.FirstName == 'undefined' || $scope.Candidate.FirstName == null || $scope.Candidate.FirstName == '') {
               //    firstNameError = true;
               //    //  $scope.ErrorMessage = "FirstName Mandatory";
               //}

               //var lastNameError = false;
               //if (typeof $scope.Candidate.LastName == 'undefined' || $scope.Candidate.LastName == null || $scope.Candidate.LastName == '') {
               //    lastNameError = true;
               //    //  $scope.ErrorMessage = "LastName Mandatory";
               //}

               //var dobError = false;
               //if (typeof $scope.Candidate.DateOfBirth == 'undefined' || $scope.Candidate.DateOfBirth == null || $scope.Candidate.DateOfBirth == '') {
               //    dobError = true;
               //    //$scope.ErrorMessage = "Date Of Birth Mandatory";
               //}

               //var mobileNumberError = false;

               //if (typeof $scope.Candidate.MobileNumber == 'undefined' || $scope.Candidate.MobileNumber == null || $scope.Candidate.MobileNumber == '') {
               //    mobileNumberError = true;
               //    // $scope.ErrorMessage = "Mobile Number Mandatory";
               //}

               //var emailError = false;

               //if (typeof $scope.Candidate.Email == 'undefined' || $scope.Candidate.Email == null || $scope.Candidate.Email == '') {
               //    emailError = true;
               //    //  $scope.ErrorMessage = "Email Address Mandatory";
               //}


               //if (firstNameError || lastNameError || dobError || mobileNumberError || emailError) {
               //    $scope.IsError = true;
               //    $scope.ErrorMessage = "Enter Mandatory Fields";
               //    return;
               //}

               //  debugger;
               $scope.Candidate.SalaryInLacs = $scope.Candidate.selectedSalaryInLacs.id;
               $scope.Candidate.ExperienceInYears = $scope.Candidate.selectedExperienceInYears.id;
               $scope.Candidate.SalaryInThousands = $scope.Candidate.selectedSalaryInThousands.id;
               $scope.Candidate.ExperienceInMonths = $scope.Candidate.selectedExperienceInMonths.id;
               $scope.Candidate.Industry = $scope.Candidate.selectedIndustry.Code;
               var model = $scope.Candidate;
               CandidateService.CreateCandidate(model).success(function (data) {
                   //$scope.CandidateCreationMessage = "Candidate Created Successfully. Do you want to create Profile for this candidate?";
                   //$scope.IsError = false;
                   //$scope.IsConfirmed = true;

                   // $scope.condition = 'Confirmation';
                   //  $scope.FileName = 'Confirmation.html';
                   $scope.showAlert($scope.ConfirmationUrl);
               }).error(function (data) {
                   //$scope.CandidateCreationMessage = "Candidate Created Failed";
                   // $scope.condition = 'Error';
                   $scope.showAlert($scope.ErrorUrl);
               });;

           };


           //$scope.showAlert = function (size) {
           //    debugger;
           //    var modalInstance = $modal.open({
           //        animation: false,
           //        backdrop: 'static',
           //        templateUrl: '/Templates/Common/AlertPopUp.html',
           //        controller: 'AlterModalController',
           //        keyboard: false,
           //        scope: $scope,
           //        windowclass: 'centre-Modal',
           //        resolve: {
           //            param1: null
           //        }
           //    });
           //    modalInstance.result.then(function (response) {


           //    }, function () {
           //    });
           //};


           $scope.ok = function () {
               $modalInstance.close();
           };

           $scope.cancel = function () {
               $modalInstance.dismiss('cancel');
           };
       }]);



    angular.module('sbAdminApp').controller('viewModalCtrl',
      ['$scope', '$modalInstance', 'CandidateService', '$timeout', function ($scope, $modalInstance, CandidateService, $timeout) {

          $scope.ToggleProfile = function () {

              debugger;
              $scope.SelectedCandidate.Profiles = [];
              $scope.IsExpanded = !$scope.IsExpanded;
              if ($scope.IsExpanded) {
                  $scope.IsLoading = false;


                  var model = {
                      Id: $scope.SelectedCandidate.CandidateId
                  };
                  //var
                  var id = $scope.SelectedCandidate.CandidateId;
                  CandidateService.GetCandidateProfiles(model).success(function (data) {
                      $scope.SelectedCandidate.Profiles = data;
                      $scope.IsLoading = false;
                  }).error(function (data) {
                      $scope.IsLoading = false;
                  });
              }


          };


          $scope.ToggleCandidateInfo = function () {
              $scope.IsInfoExpanded = !$scope.IsInfoExpanded;

          };

          $scope.ok = function () {
              $modalInstance.close();
          };

          $scope.close = function () {
              $modalInstance.dismiss('cancel');
          };
      }]);

    angular.module('sbAdminApp').controller('editModalCtrl',
      ['$scope', '$modalInstance', 'CandidateService', function ($scope, $modalInstance, CandidateService) {


          $scope.ok = function () {
              $modalInstance.close();
          };

          $scope.cancel = function () {
              $modalInstance.dismiss('cancel');
          };


          $scope.Update = function () {
              debugger;
              $scope.UpdateCandidate.SalaryInLacs = $scope.UpdateCandidate.selectedSalaryInLacs.id;
              $scope.UpdateCandidate.ExperienceInYears = $scope.UpdateCandidate.selectedExperienceInYears.id;
              $scope.UpdateCandidate.SalaryInThousands = $scope.UpdateCandidate.selectedSalaryInThousands.id;
              $scope.UpdateCandidate.ExperienceInMonths = $scope.UpdateCandidate.selectedExperienceInMonths.id;
              $scope.UpdateCandidate.Industry = $scope.UpdateCandidate.selectedIndustry.Code;
              $scope.UpdateCandidate.AssignTo = $scope.UpdateCandidate.SelectedAssignTo.Code;
              $scope.UpdateCandidate.CandidateStatus = $scope.UpdateCandidate.selectedStatus.Code;
              var model = $scope.UpdateCandidate;
              CandidateService.UpdateCandidate(model).success(function (data) {
                  //$scope.condition = 'Confirmation';
                  // $scope.FileName = 'Confirmation.html';
                  $scope.showAlert($scope.SuccessUrl);
                  // $scope.showAlert('sm');
              }).error(function (data) {
                  debugger;
                  // $scope.condition = 'Error';
                  $scope.showAlert($scope.ErrorUrl);
              });

          };
      }]);

    angular.module('sbAdminApp').controller('moreModalCtrl',
     ['$scope', '$modalInstance', 'CandidateService', function ($scope, $modalInstance, CandidateService) {


         $scope.close = function () {
             $modalInstance.close();
         };

         $scope.cancel = function () {
             $modalInstance.dismiss('cancel');
         };
     }]);


    angular.module('sbAdminApp').controller('AlterModalController',
    ['$scope', '$modalInstance', '$modalStack', 'param1', function ($scope, $modalInstance, $modalStack, param1) {


        $scope.CloseAll = function (isClose) {
            $modalStack.dismissAll('cancel');
            if (isClose == 'No')
                // $modalStack.dismissAll('cancel');
                $scope.OpenProfile('lg');
        };

        //$scope.Close = function () {
        //    $modalStack.dismissAll('cancel');
        //};
        $scope.ok = function () {
            $modalStack.dismissAll('cancel');
        };
    }]);




}(angular));
