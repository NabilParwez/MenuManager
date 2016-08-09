namespace MenuManager.Controllers {

    export class HomeController {
        public menuItems;
    }

    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }

    export class MenuEditController {
        public categories;

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) {
            this.$http.get('/api/menuItem/categories')
                .then((response) => {
                    this.categories = response.data;
                });
        }

        public submit(menuItem) {
            this.$http.post('/api/menuItem', menuItem)
                .then((response) => {
                    this.$state.go('menu');
                })
                .catch((reason) => {
                    alert("Please fill out all fields.");
                });
        }
    }

    export class MenuController {
        public menuItems;

        constructor(private $uibModal: angular.ui.bootstrap.IModalService, private $http: ng.IHttpService) {
            $http.get('/api/menuItem').then((results) => {
                this.menuItems = {};
                for (let mi of <any>results.data) {
                    this.menuItems[mi.categoryName] = this.menuItems[mi.categoryName] || [];
                    this.menuItems[mi.categoryName].push(mi);
                }
            });
        }

        public showModal(menuItem) {
            this.$uibModal.open({
                templateUrl: '/ngApp/views/menuItemsModal.html',
                controller: 'MenuItemModalsController',
                controllerAs: 'modal',
                resolve: {
                    menuItem: () => menuItem
                },
                size: 'md'
            });
        }
    }

    angular.module('MenuManager').controller('MenuController', MenuItemModalsController);

    export class MenuItemModalsController {
        constructor(private menuItem, private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance) {}

        public ok() {
            this.$uibModalInstance.close();
        }
    }

    angular.module('MenuManager').controller('MenuItemModalsController', MenuItemModalsController);

    export class MenuItemController {

        constructor(private $http: ng.IHttpService) { }

        
    }

    export class AboutController {
        public message = 'About us!';
    }

    export class LocationController {
        public location;
    }
    export class ContactUsController {
        public contactUs;
    }
}

