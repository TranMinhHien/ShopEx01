/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('shopex01.slides', ['shopex01.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('slides', {
            url: "/slides",
            templateUrl: "/app/components/slides/slideListView.html",
            parent: 'base',
            controller: "slideListController"
        })
            .state('add_slide', {
                url: "/add_slide",
                parent: 'base',
                templateUrl: "/app/components/slides/slideAddView.html",
                controller: "slideAddController"
            })
            .state('edit_slide', {
                url: "/edit_slide/:id",
                templateUrl: "/app/components/slides/slideEditView.html",
                controller: "slideEditController",
                parent: 'base',
            });
    }
})();