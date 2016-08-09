namespace MenuManager {

    angular.module('MenuManager', ['ui.router', 'ngResource', 'ui.bootstrap']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/home.html',
                controller: MenuManager.Controllers.HomeController,
                controllerAs: 'controller'
            })
            
            .state('menu', {
                url: '/menu',
                templateUrl: '/ngApp/views/menu.html',
                controller: MenuManager.Controllers.MenuController,
                controllerAs: 'controller'
            })
            .state('login', {
                url: '/login',
                templateUrl: '/ngApp/views/login.html',
                controller: MenuManager.Controllers.LoginController,
                controllerAs: 'controller'
            })
            .state('menuEdit', {
                url: '/edit',
                templateUrl: '/ngApp/views/menuEdit.html',
                controller: MenuManager.Controllers.MenuEditController,
                controllerAs: 'controller'
            })
            .state('register', {
                url: '/register',
                templateUrl: '/ngApp/views/register.html',
                controller: MenuManager.Controllers.RegisterController,
                controllerAs: 'controller'
            })
            .state('externalRegister', {
                url: '/externalRegister',
                templateUrl: '/ngApp/views/externalRegister.html',
                controller: MenuManager.Controllers.ExternalRegisterController,
                controllerAs: 'controller'
            }) 
            .state('about', {
                url: '/about',
                templateUrl: '/ngApp/views/about.html',
                controller: MenuManager.Controllers.AboutController,
                controllerAs: 'controller'
            })
            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/views/notFound.html'
            })
            .state('location', {
                url: '/location',
                templateUrl: '/ngApp/views/location.html',
                controller: MenuManager.Controllers.LoginController,
                controllerAs: 'controller'
            })
            .state('contactUs', {
                url: '/contactUs',
                templateUrl: '/ngApp/views/contactus.html',
                controller: MenuManager.Controllers.LoginController,
                controllerAs: 'controller'
            });

        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
    });

    
    angular.module('MenuManager').factory('authInterceptor', (
        $q: ng.IQService,
        $window: ng.IWindowService,
        $location: ng.ILocationService
    ) =>
        ({
            request: function (config) {
                config.headers = config.headers || {};
                config.headers['X-Requested-With'] = 'XMLHttpRequest';
                return config;
            },
            responseError: function (rejection) {
                if (rejection.status === 401 || rejection.status === 403) {
                    $location.path('/login');
                }
                return $q.reject(rejection);
            }
        })
    );

    angular.module('MenuManager').config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });

    

}
