(function (angular) {

    angular.module('sbAdminApp').controller('ProfileController', ['$scope', '$modalInstance', '$log', 'ProfileService', function ($scope, $modalInstance, $log, ProfileService) {

        debugger;
        $scope.Profile = {};
        $scope.Profile.ProfileId = '';
        $scope.Profile.CandidateId = '';
        $scope.Profile.CompanyName = '';
        $scope.Profile.CompanyDetails = '';
        $scope.Profile.DateOfInterview = '';
        $scope.Profile.CurrentStatus = '';
        $scope.Profile.HRCopy = '';
        $scope.Profile.AppliedPositionFor = '';
        $scope.Profile.Interviewer = '';
        $scope.Profile.InterviewerContact = '';
        $scope.Profile.CompanyContact = '';
        $scope.Profile.ReferenceType = '';
        $scope.Profile.RecruiterName = '';
        $scope.Profile.RecruiterContact = '';
        $scope.Profile.TeamLeadName = '';
        $scope.Profile.CreateDate = '';
        $scope.Profile.CreatedBy = '';
        $scope.Profile.ModifiedDate = '';
        $scope.Profile.ModifiedBy = '';

        $scope.Profile.Candidate = $scope.$parent.SelectedCandidate;
        //$scope.Profile.Candidate.CandidateId = '';
        //$scope.Profile.Candidate.FirstName = '';
        //$scope.Profile.Candidate.MiddleName = '';
        //$scope.Profile.Candidate.LastName = '';
        //$scope.Profile.Candidate.MobileNumber = '';
        //$scope.Profile.Candidate.AlternateNumber = '';
        //$scope.Profile.Candidate.Email = '';
        //$scope.Profile.Candidate.SecondaryEmail = '';
        //$scope.Profile.Candidate.DateOfBirth = '';
        //$scope.Profile.Candidate.CurrentEmployer = '';
        //$scope.Profile.Candidate.CurrentDesignation = '';
        //$scope.Profile.Candidate.CurrentCTC = '';
        //$scope.Profile.Candidate.CurrentLocation = '';
        //$scope.Profile.Candidate.HomeTown = '';
        //$scope.Profile.Candidate.Source = '';
        //$scope.Profile.Candidate.Status = '';
        $scope.Profiles = [];

        $scope.IsExpanded = false;
        $scope.IsInfoExpanded = true;
        $scope.Profile.CompanyId = '';
        $scope.Profile.IndustryId = '';
        $scope.Profile.SelectedCompany = {};
        $scope.Profile.SelectedIndustry = {};

        //$scope.Initialize();

        //Initialize = function () {
        //    //Load Industries and Companies
        //    $scope.Industries = ProfileService.FetchIndustries();

        //    $scope.Comapnies = ProfileService.FetchCompanies();
        //};

        $scope.LoadDropdownItems = function () {
            debugger;

            $scope.Profile.Candidate = $scope.$parent.SelectedCandidate;
            ProfileService.FetchCompanies(null).success(function (data) {
                debugger;
                //  $scope.SearchItems.Statuses = 
                $scope.Companies = data;
                $scope.Profile.SelectedCompany = $scope.Companies[0];

                //for (var i = 0; i < data.Statuses.length; i++) {
                //    $scope.Statuses.push(data.Statuses[i]);
                //}

                // $scope.Statuses = data.Statuses;
                debugger;
            }).error(function (data) {

            });



            ProfileService.FetchIndustries(null).success(function (data) {
                debugger;
                //  $scope.SearchItems.Statuses = 
                $scope.Industries = data;
                $scope.Profile.SelectedIndustry = $scope.Industries[0];
                //for (var i = 0; i < data.Statuses.length; i++) {
                //    $scope.Statuses.push(data.Statuses[i]);
                //}

                // $scope.Statuses = data.Statuses;
                debugger;
            }).error(function (data) {

            });

            return true;
        }

        $scope.LoadEdit = function () {
            $scope.Profile = $scope.UpdateProfileInfo;
            var data = $scope.LoadDropdownItems();

            //for(var i=0;i<$scope.Industries.length;i++)
            //{
            //    if($scope.Industries[i].IndustryId==$scope.Profile.IndustryId)
            //    {
            //        $scope.Profile.SelectedIndustry = $scope.Industries[i];
            //        break;
            //    }

            //}

            //for (var i = 0; i < $scope.Companies.length; i++) {
            //    if ($scope.Companies[i].IndustryId == $scope.Profile.CompanyId) {
            //        $scope.Profile.SelectedCompany = $scope.Companies[i];
            //        break;
            //    }

            //}


        };

        $scope.SearchProfile = function () {
            debugger;
            //ProfileService.SearchProfile(model);
            $scope.Profiles = ProfileService.SearchProfiles('pavan228@gmail.com');
        }

        $scope.SaveProfile = function (size) {
            debugger;
            $scope.Profile.CompanyId = $scope.Profile.SelectedCompany.CompanyId;
            $scope.Profile.IndustryId = $scope.Profile.SelectedIndustry.IndustryId;
            $scope.Profile.CandidateId = $scope.Profile.Candidate.CandidateId;
            var model = $scope.Profile;

            ProfileService.CreateProfile(model).success(function (data) {
                //$scope.condition = 'Confirmation';
                // $scope.FileName = 'Confirmation.html';
                $scope.SuccessMessage = "Profile Created Successfully";
                $scope.showAlert($scope.ProfileSuccessUrl);
                // $scope.showAlert('sm');
            }).error(function (data) {
                // $scope.condition = 'Error';
                // $scope.ErrorMessage = "Profile Creation Failed. Please try again later...";
                $scope.showAlert($scope.ErrorUrl);
            });
        };

        $scope.UpdateProfile = function (size) {
            debugger;
            // $scope.Profile.CompanyId = $scope.Profile.SelectedCompany.CompanyId;
            //   $scope.Profile.IndustryId = $scope.Profile.SelectedIndustry.IndustryId;
            //  $scope.Profile.CandidateId = $scope.Profile.Candidate.CandidateId;
            var model = $scope.Profile;

            var model = {
                AppliedPositionFor: $scope.Profile.AppliedPositionFor,
                CandidateId: $scope.Profile.CandidateId,
                CompanyContact: $scope.Profile.CompanyContact,
                CompanyDetails: $scope.Profile.CompanyDetails,
                CompanyId: $scope.Profile.CompanyId,
                CurrentStatus: $scope.Profile.CurrentStatus,
                DateOfInterview: $scope.DateOfInterview,
                HRCopy: $scope.Profile.HRCopy,
                IndustryId: $scope.Profile.IndustryId,
                Interviewer: $scope.Profile.Interviewer,
                InterviewerContact: $scope.Profile.InterviewerContact,
                ProfileId: $scope.Profile.ProfileId,
                RecruiterContact: $scope.Profile.RecruiterContact,
                RecruiterName: $scope.Profile.RecruiterName,
                ReferenceType: $scope.Profile.ReferenceType,
                TeamLeadName: $scope.Profile.TeamLeadName
            }

            ProfileService.UpdateProfile(model).success(function (data) {
                //$scope.condition = 'Confirmation';
                // $scope.FileName = 'Confirmation.html';
                // $scope.SuccessMessage = "Profile Created Successfully";
                $scope.showAlert($scope.ProfileUpdateUrl);
                // $scope.showAlert('sm');
            }).error(function (data) {
                debugger;
                // $scope.condition = 'Error';
                // $scope.ErrorMessage = "Profile Creation Failed. Please try again later...";
                $scope.showAlert($scope.ErrorUrl);
            });
        };

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };
    }]);

    angular.module('sbAdminApp').controller('createModalCtrl', ['$scope', '$modalInstance', 'ProfileService', function ($scope, $modalInstance, ProfileService) {
        $scope.SaveProfile = function () {
            debugger;
            var model = $scope.Profile;
            ProfileService.CreateProfile(model);
        };

        $scope.ok = function () {
            $modalInstance.close();
        };

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };
    }]);
}(angular));