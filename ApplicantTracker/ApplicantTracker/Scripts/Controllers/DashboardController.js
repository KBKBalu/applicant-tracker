(function (angular) {

    angular.module('sbAdminApp').controller('DashboardController',
       ['$scope', '$modal', 'DashboardService', function ($scope, $modal, DashboardService) {

           $scope.ActiveProfiles = 0;
           $scope.Customers = [2, 4, 5, 6, 2, 3, 4, 5];
           $scope.NewInterviews = 0;
           $scope.OfferReleases = 0;
           $scope.NewProfiles = 0;
           $scope.TotalEmployees = 0;
           $scope.MemberActivities = { TotalRecords: { count: 100, values: [1, 5, 7, 3, 5, 2], nodes: 6 }, NewRecords: { count: 100, values: [1, 5, 7, 3, 5, 2], nodes: 6 }, Members: [{ MemberName: 'Nithi', Assigned: 100, Processed: 100, InterviewSchudled: 0 }] }
           $scope.GetDashboardCount = function () {
               debugger;
               var value = null;
               DashboardService.GetDashboardCount(value)
                   .success(function (data) {
                       $scope.ActiveProfiles = data.ActiveProfiles;
                       $scope.NewInterviews = data.NewInterviews;
                       $scope.OfferReleases = data.OfferReleases;
                       $scope.NewProfiles = data.NewProfiles;
                       $scope.TotalEmployees = data.TotalEmployees;
                       var detail = { userId: '1', role: 'Manager', refreshType: 'today' };
                       DashboardService.RefreshDashboard(detail)
                       .success(function (data) {
                           $scope.MemberActivities.TotalRecords.count = data.TotalRecords;
                           $scope.MemberActivities.NewRecords.count = data.NewRecords;
                           $scope.MemberActivities.Members = data.WeeklyActivity;
                       }
          ).error(function (data) {
              $scope.IsLoading = false;
          });
                       $scope.IsLoading = false;
                   })

                   .error(function (data) {
                       $scope.IsLoading = false;
                   });
           };

           $scope.RefreshDashboard = function (value) {
               debugger;

               var data = { userId: '1', role: 'Manager', refreshType: value };

               DashboardService.RefreshDashboard(data)
                        .success(function (data) {
                            $scope.MemberActivities.TotalRecords.count = data.TotalRecords;
                            $scope.MemberActivities.NewRecords.count = data.NewRecords;
                            $scope.MemberActivities.Members = data.WeeklyActivity;
                        }
           ).error(function (data) {
               $scope.IsLoading = false;
           });


           };
       }]);
}(angular));
