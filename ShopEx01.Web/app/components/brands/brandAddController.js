(function (app) {
    app.controller('brandAddController', brandAddController);

    brandAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService'];

    function brandAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.brand = {
            CreatedDate: new Date(),
            Status: true,
        }
        $scope.GetSeoTitle = GetSeoTitle;
        function GetSeoTitle() {
            $scope.brand.Alias = commonService.getSeoTitle($scope.brand.Name);
        }

        $scope.AddBrand = AddBrand;

        function AddBrand() {
            apiService.post('api/brand/create', $scope.brand,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.');
                    $state.go('brands');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.');
                });
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

})(angular.module('shopex01.brands'));