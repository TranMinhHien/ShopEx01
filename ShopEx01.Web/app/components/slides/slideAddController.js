(function (app) {
    app.controller('slideAddController', slideAddController);

    slideAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService'];

    function slideAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.slide = {
            CreatedDate: new Date(),
            Status: true,
        }
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.slide.Alias = commonService.getSeoTitle($scope.slide.Name);
        }

        $scope.AddSlide = AddSlide;

        function AddSlide() {
            
            apiService.post('api/slide/create', $scope.slide,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.');
                    $state.go('slides');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.');
                });
        }
        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.product.Image = fileUrl;
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
    }

})(angular.module('shopex01.slides'));