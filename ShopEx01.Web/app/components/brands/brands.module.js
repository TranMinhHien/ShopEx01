/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('shopex01.brands', ['shopex01.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('brands', {
            url: "/brands",
            templateUrl: "/app/components/brands/brandListView.html",
            parent: 'base',
            controller: "brandListController"
        })
            .state('add_brand', {
                url: "/add_brand",
                parent: 'base',
                templateUrl: "/app/components/brands/brandAddView.html",
                controller: "brandAddController"
            })
            .state('edit_brand', {
                url: "/edit_brand/:id",
                templateUrl: "/app/components/brands/brandEditView.html",
                controller: "brandEditController",
                parent: 'base',
            });
    }
})();