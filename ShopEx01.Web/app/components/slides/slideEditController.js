(function (app) {
    app.controller('slideEditController', slideEditController);

    slideEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService'];

    function slideEditController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
        $scope.slide = {
            CreatedDate: new Date(),
            Status: true
        }

        $scope.UpdateSlide = UpdateSlide;
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.slide.Alias = commonService.getSeoTitle($scope.slide.Name);
        }

        function loadSlideDetail() {
            apiService.get('api/slide/getbyid/' + $stateParams.id, null, function (result) {
                $scope.slide = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function UpdateSlide() {
            apiService.put('api/slide/update', $scope.slide,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được cập nhật.');
                    $state.go('slides');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.');
                });
        }
        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.slide.Image = fileUrl;
                })
            }
            finder.popup();
        }

        //function loadParentCategory() {
        //    apiService.get('api/productcategory/getallparents', null, function (result) {
        //        $scope.parentCategories = result.data;
        //    }, function () {
        //        console.log('Cannot get list parent');
        //    });
        //}

        //loadParentCategory();
        loadSlideDetail();
    }

})(angular.module('shopex01.slides'));