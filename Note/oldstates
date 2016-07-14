
/* Setup Rounting For All Pages */
angular.module("realNextServiceWebApp").config(['$stateProvider', '$urlRouterProvider', '$locationProvider', 'PermissionNameConstrant',
function ($stateProvider, $urlRouterProvider, $locationProvider, PermissionNameConstrant) {
    $urlRouterProvider.otherwise("");

    $stateProvider
        .state('resetpassword', {
            url: '/account/resetpassword?userid&code',
            templateUrl: '/Templates/account/resetpassword.tpl.html'.mapPath(),
            permissionCode: PermissionNameConstrant.Open,
            controller: 'resetPasswordController'
        })
        .state('dashboard', {
            url: "",
            templateUrl: "/Templates/home/dashboard.tpl.html".mapPath(),
            data: { pageTitle: 'Admin Dashboard Template' },
            permissionCode: PermissionNameConstrant.Open,
            controller: "DashboardController",
            resolve: {
                deps: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load({
                        name: 'realNextServiceWebApp',
                        insertBefore: '#ng_load_plugins_before', // load the above css files before a LINK element with this ID. Dynamic CSS files must be loaded between core and theme css files
                        files: [
                            '/assets/global/plugins/morris/morris.css'.mapPath(),
                            '/assets/global/plugins/morris/morris.min.js'.mapPath(),
                            '/assets/global/plugins/morris/raphael-min.js'.mapPath(),
                            '/assets/global/plugins/jquery.sparkline.min.js'.mapPath(),
                            '/assets/pages/scripts/dashboard.min.js'.mapPath(),
                            '/scripts/modules/home/controllers/DashboardController.js'.mapPath(),
                        ]
                    });
                }]
            }
        })
        //------------------------------ Object tabs --------------------------------------
        .state('myOfferOverview', {
            url: '/offer/overview/my',
            templateUrl: '/Templates/realEstateObject/overview.tpl.html'.mapPath(),
            controller: "OfferOverviewController",
            permissionCode: PermissionNameConstrant.ViewAllRealEstateObjects,
            resolve: {
                tabName: function () {
                    return "myObjects";
                }
            }
        })
        .state('allOfferOverview', {
            url: '/offer/overview/all',
            templateUrl: '/Templates/realEstateObject/overview.tpl.html'.mapPath(),
            controller: "OfferOverviewController",
            permissionCode: PermissionNameConstrant.ViewAllRealEstateObjects,
            resolve: {
                tabName: function () {
                    return "allObjects";
                }
            }
        })
        .state('linkedOwnOfferOverview', {
            url: '/offer/overview/linked-own-offers',
            templateUrl: '/Templates/realEstateObject/overview.tpl.html'.mapPath(),
            controller: "OfferOverviewController",
            permissionCode: PermissionNameConstrant.ViewAllRealEstateObjects,
            resolve: {
                tabName: function () {
                    return "linkedOwnOffers";
                }
            }
        })
        .state('acceptedLinkedOfferOverview', {
            url: '/offer/overview/accepted-linked-offer',
            templateUrl: '/Templates/realEstateObject/overview.tpl.html'.mapPath(),
            controller: "OfferOverviewController",
            permissionCode: PermissionNameConstrant.ViewAllRealEstateObjects,
            resolve: {
                tabName: function () {
                    return "acceptedLinkedOffers";
                }
            }
        })
        .state('linkedOfferRequestsOverview', {
            url: '/offer/overview/linked-offer-requests',
            templateUrl: '/Templates/realEstateObject/overview.tpl.html'.mapPath(),
            controller: "OfferOverviewController",
            permissionCode: PermissionNameConstrant.ViewAllRealEstateObjects,
            resolve: {
                tabName: function () {
                    return "linkedOfferRequests";
                }
            }
        })
        .state('rejectedLinkedOfferOverview', {
            url: '/offer/overview/rejected-linked-offer',
            templateUrl: '/Templates/realEstateObject/overview.tpl.html'.mapPath(),
            controller: "OfferOverviewController",
            permissionCode: PermissionNameConstrant.ViewAllRealEstateObjects,
            resolve: {
                tabName: function () {
                    return "rejectedLinkedOffer";
                }
            }
        })
        .state('draftOfferOverview', {
            url: '/offer/overview/draft',
            templateUrl: '/Templates/realEstateObject/overview.tpl.html'.mapPath(),
            controller: "OfferOverviewController",
            permissionCode: PermissionNameConstrant.ViewAllRealEstateObjects,
            resolve: {
                tabName: function () {
                    return "draftObjects";
                }
            }
        })
        .state('archivedOfferOverview', {
            url: '/offer/overview/archived',
            templateUrl: '/Templates/realEstateObject/overview.tpl.html'.mapPath(),
            controller: "OfferOverviewController",
            permissionCode: PermissionNameConstrant.ViewAllRealEstateObjects,
            resolve: {
                tabName: function () {
                    return "archivedObjects";
                }
            }
        })
        .state('offeroverviewFromSearch', {
            url: '/offer/overview/:keyword',
            templateUrl: '/Templates/realEstateObject/overview.tpl.html'.mapPath(),
            controller: "OfferOverviewController",
            permissionCode: PermissionNameConstrant.ViewAllRealEstateObjects
        })
        // --------------------------- Object tabs end ---------------------------------------------
        .state('offerdetail', {
            url: '/offer/detail/:id',
            templateUrl: '/Templates/realEstateObject/detail/detail.tpl.html'.mapPath(),
            controller: 'OfferDetailController',
            permissionCode: PermissionNameConstrant.EditRealEstateObject,
            resolve: {
                readOnly: function () {
                    return false;
                }
            }
        })
        .state('offerStatistics', {
            url: '/offer/statistics/:friendlyId',
            templateUrl: '/Templates/realEstateObject/analytics.tpl.html'.mapPath(),
            controller: 'OfferAnalyticsController',
            permissionCode: PermissionNameConstrant.EditRealEstateObject,
            resolve: {
                readOnly: function () {
                    return false;
                }
            }
        })
        .state('offerdetailWithKeyword', {
            url: '/offer/detail/{id:string}/{keyword:string}',
            templateUrl: '/Templates/realEstateObject/detail/detail.tpl.html'.mapPath(),
            controller: 'OfferDetailController',
            permissionCode: PermissionNameConstrant.EditRealEstateObject,
            resolve: {
                readOnly: function () {
                    return false;
                }
            }
        })
        .state('offerview', {
            url: '/offer/view/:id',
            templateUrl: '/Templates/realEstateObject/view.tpl.html'.mapPath(),
            controller: 'OfferViewController',
            permissionCode: PermissionNameConstrant.LinkedOfferViewInvite,
            resolve: {
                readOnly: function () {
                    return true;
                }
            }
        })
        .state('addoffer', {
            url: '/offer/add{step:.*}',
            templateUrl: '/Templates/realEstateObject/add.tpl.html'.mapPath(),
            permissionCode: PermissionNameConstrant.CreateRealEstateObject,
            controller: 'AddOfferController'
        })
        .state('userOverview', {
            url: '/user/overview',
            templateUrl: '/Templates/user/overview.tpl.html'.mapPath(),
            permissionCode: PermissionNameConstrant.ViewAllUsers,
            controller: 'UserOverviewController',
            resolve: {
                userType: function () {
                    return ['Customer'];
                }
            }
        })
        .state('staffOverview', {
            url: '/staff/overview',
            templateUrl: '/Templates/staff/overview.tpl.html'.mapPath(),
            permissionCode: PermissionNameConstrant.ViewAllUsers,
            controller: 'UserOverviewController',
            resolve: {
                userType: function () {
                    return ['BrokerManager'];
                }
            }
        })
        .state('userDetail', {
            url: '/user/detail/:id',
            templateUrl: '/Templates/user/detail.tpl.html'.mapPath(),
            permissionCode: PermissionNameConstrant.EditUser,
            controller: 'UserDetailController'
        })
        .state('userAdd', {
            url: '/user/add',
            templateUrl: '/Templates/user/add.tpl.html'.mapPath(),
            permissionCode: PermissionNameConstrant.CreateUser,
            controller: 'UserAddController'
        })
        //#region   RN276  Role CURD Pages  Begin
        .state('roleOverview', {
            url: '/role/overview',
            templateUrl: '/Templates/role/overview.tpl.html'.mapPath(),
            permissionCode: PermissionNameConstrant.ViewAllRoles,
            controller: 'RoleOverviewController'
        })
        .state('roleDetail', {
            url: '/role/detail/:id',
            templateUrl: '/Templates/role/detail.tpl.html'.mapPath(),
            permissionCode: PermissionNameConstrant.EditRole,
            controller: 'RoleDetailController'
        })
        .state('roleAdd', {
            url: '/role/add',
            templateUrl: '/Templates/role/add.tpl.html'.mapPath(),
            permissionCode: PermissionNameConstrant.CreateRole,
            controller: 'RoleAddController'
        })
        //#endregion  Role CURD Pages  End
        .state('myTransactionOverview', {
            url: '/transaction/overview/my',
            templateUrl: '/Templates/transaction/overview.tpl.html'.mapPath(),
            permissionCode: PermissionNameConstrant.ViewAllTransactions,
            controller: 'TransactionOverviewController',
            resolve: {
                tabName: function () {
                    return "my";
                }
            }
        })
        .state('allTransactionOverview', {
            url: '/transaction/overview/all',
            templateUrl: '/Templates/transaction/overview.tpl.html'.mapPath(),
            permissionCode: PermissionNameConstrant.ViewAllTransactions,
            controller: 'TransactionOverviewController',
            resolve: {
                tabName: function () {
                    return "all";
                }
            }
        })
        .state('transactionDetail', {
            url: '/transaction/detail/:id',
            templateUrl: '/Templates/transaction/detail.tpl.html'.mapPath(),
            permissionCode: PermissionNameConstrant.EditTransaction,
            controller: 'TransactionDetailController'
        })
        .state('transactionPreiew', {
            url: '/transaction/preview/:id',
            templateUrl: '/Templates/transaction/preview.tpl.html'.mapPath(),
            permissionCode: PermissionNameConstrant.EditTransaction,
            controller: 'TransactionPreviewController'
        })
        .state('transactionAdd', {
            url: '/transaction/add',
            templateUrl: '/Templates/transaction/add.tpl.html'.mapPath(),
            permissionCode: PermissionNameConstrant.CreateTransaction,
            controller: 'TransactionAddController'
        })
        .state('transactionAddFromObject', {
            url: '/transaction/add/{objectId:string}/{type:string}',
            templateUrl: '/Templates/transaction/add.tpl.html'.mapPath(),
            permissionCode: PermissionNameConstrant.CreateTransaction,
            controller: 'TransactionAddController'
        })
        .state('dataCollectiveLeadOverview', {
            url: '/dataCollectiveLead/overview',
            templateUrl: '/Templates/dataCollectiveLead/overview.tpl.html'.mapPath(),
            permissionCode: PermissionNameConstrant.ViewAllDataCollectiveLeads,
            data: {
                tab: 0,
            },
            controller: 'DataCollectiveLeadOverviewController'
        })
        .state('dataCollectiveLeadOverviewAllLeads', {
            url: '/dataCollectiveLead/overview/allleads',
            templateUrl: '/Templates/dataCollectiveLead/overview.tpl.html'.mapPath(),
            permissionCode: PermissionNameConstrant.ViewAllDataCollectiveLeads,
            data: {
                tab: 1,
            },
            controller: 'DataCollectiveLeadOverviewController'
        })
        .state('dataCollectiveLeadDetail', {
            url: '/dataCollectiveLead/detail/:id/:utcStartDate/:utcEndDate',
            templateUrl: '/Templates/dataCollectiveLead/detail.tpl.html'.mapPath(),
            permissionCode: PermissionNameConstrant.ViewDataCollectiveLead,
            controller: 'DataCollectiveLeadDetailController'
        })
        .state('nopermission', {
            url: '/nopermission/:denyPage',
            templateUrl: '/Templates/common/nopermission.tpl.html'.mapPath(),
            controller: "NoPermissionController",
            permissionCode: 'Open'
        })
        .state('testui', {
            url: '/offer/testui',
            templateUrl: '/Templates/realEstateObject/testui.tpl.html'.mapPath(),
            controller: 'TestUIController',
            resolve: {
                deps: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load({
                        name: 'realNextServiceWebApp',
                        //insertBefore: '#ng_load_plugins_before', // load the above css files before a LINK element with this ID. Dynamic CSS files must be loaded between core and theme css files
                        files: [
                            '/scripts/modules/realEstateObject/realEstateObject.js'.mapPath(),
                            '/scripts/modules/realEstateObject/resources/realEstateObjectResource.js'.mapPath(),
                            '/scripts/modules/realEstateObject/controllers/TestUIController.js'.mapPath()
                        ]
                    });
                }]
            }
        })
        // AngularJS plugins
        .state('fileupload', {
            url: "/file_upload.html",
            templateUrl: "views/file_upload.html",
            data: { pageTitle: 'AngularJS File Upload' },
            controller: "GeneralPageController",
            resolve: {
                deps: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load([{
                        name: 'angularFileUpload',
                        files: [
                            '/assets/global/plugins/angularjs/plugins/angular-file-upload/angular-file-upload.min.js',
                        ]
                    }, {
                        name: 'realNextServiceWebApp',
                        files: [
                            'js/controllers/GeneralPageController.js'
                        ]
                    }]);
                }]
            }
        })

        // UI Select
        .state('uiselect', {
            url: "/ui_select.html",
            templateUrl: "views/ui_select.html",
            data: { pageTitle: 'AngularJS Ui Select' },
            controller: "UISelectController",
            resolve: {
                deps: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load([{
                        name: 'ui.select',
                        insertBefore: '#ng_load_plugins_before', // load the above css files before '#ng_load_plugins_before'
                        files: [
                            '../assets/global/plugins/angularjs/plugins/ui-select/select.min.css',
                            '../assets/global/plugins/angularjs/plugins/ui-select/select.min.js'
                        ]
                    }, {
                        name: 'realNextServiceWebApp',
                        files: [
                            'js/controllers/UISelectController.js'
                        ]
                    }]);
                }]
            }
        })

        // UI Bootstrap
        .state('uibootstrap', {
            url: "/ui_bootstrap.html",
            templateUrl: "views/ui_bootstrap.html",
            data: { pageTitle: 'AngularJS UI Bootstrap' },
            controller: "GeneralPageController",
            resolve: {
                deps: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load([{
                        name: 'realNextServiceWebApp',
                        files: [
                            'js/controllers/GeneralPageController.js'
                        ]
                    }]);
                }]
            }
        })

        // Tree View
        .state('tree', {
            url: "/tree",
            templateUrl: "views/tree.html",
            data: { pageTitle: 'jQuery Tree View' },
            controller: "GeneralPageController",
            resolve: {
                deps: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load([{
                        name: 'realNextServiceWebApp',
                        insertBefore: '#ng_load_plugins_before', // load the above css files before '#ng_load_plugins_before'
                        files: [
                            '../assets/global/plugins/jstree/dist/themes/default/style.min.css',

                            '../assets/global/plugins/jstree/dist/jstree.min.js',
                            '../assets/pages/scripts/ui-tree.min.js',
                            'js/controllers/GeneralPageController.js'
                        ]
                    }]);
                }]
            }
        })

        // Form Tools
        .state('formtools', {
            url: "/form-tools",
            templateUrl: "views/form_tools.html",
            data: { pageTitle: 'Form Tools' },
            controller: "GeneralPageController",
            resolve: {
                deps: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load([{
                        name: 'realNextServiceWebApp',
                        insertBefore: '#ng_load_plugins_before', // load the above css files before '#ng_load_plugins_before'
                        files: [
                            '../assets/global/plugins/bootstrap-fileinput/bootstrap-fileinput.css',
                            '../assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css',
                            '../assets/global/plugins/bootstrap-markdown/css/bootstrap-markdown.min.css',
                            '../assets/global/plugins/typeahead/typeahead.css',

                            '../assets/global/plugins/fuelux/js/spinner.min.js',
                            '../assets/global/plugins/bootstrap-fileinput/bootstrap-fileinput.js',
                            '../assets/global/plugins/jquery-inputmask/jquery.inputmask.bundle.min.js',
                            '../assets/global/plugins/jquery.input-ip-address-control-1.0.min.js',
                            '../assets/global/plugins/bootstrap-pwstrength/pwstrength-bootstrap.min.js',
                            '../assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js',
                            '../assets/global/plugins/bootstrap-maxlength/bootstrap-maxlength.min.js',
                            '../assets/global/plugins/bootstrap-touchspin/bootstrap.touchspin.js',
                            '../assets/global/plugins/typeahead/handlebars.min.js',
                            '../assets/global/plugins/typeahead/typeahead.bundle.min.js',
                            '../assets/pages/scripts/components-form-tools-2.min.js',

                            'js/controllers/GeneralPageController.js'
                        ]
                    }]);
                }]
            }
        })

        // Date & Time Pickers
        .state('pickers', {
            url: "/pickers",
            templateUrl: "views/pickers.html",
            data: { pageTitle: 'Date & Time Pickers' },
            controller: "GeneralPageController",
            resolve: {
                deps: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load([{
                        name: 'realNextServiceWebApp',
                        insertBefore: '#ng_load_plugins_before', // load the above css files before '#ng_load_plugins_before'
                        files: [
                            '../assets/global/plugins/clockface/css/clockface.css',
                            '../assets/global/plugins/bootstrap-datepicker/css/bootstrap-datepicker3.min.css',
                            '../assets/global/plugins/bootstrap-timepicker/css/bootstrap-timepicker.min.css',
                            '../assets/global/plugins/bootstrap-colorpicker/css/colorpicker.css',
                            '../assets/global/plugins/bootstrap-daterangepicker/daterangepicker-bs3.css',
                            '../assets/global/plugins/bootstrap-datetimepicker/css/bootstrap-datetimepicker.min.css',

                            '../assets/global/plugins/bootstrap-datepicker/js/bootstrap-datepicker.min.js',
                            '../assets/global/plugins/bootstrap-timepicker/js/bootstrap-timepicker.min.js',
                            '../assets/global/plugins/clockface/js/clockface.js',
                            '../assets/global/plugins/moment.min.js',
                            '../assets/global/plugins/bootstrap-daterangepicker/daterangepicker.js',
                            '../assets/global/plugins/bootstrap-colorpicker/js/bootstrap-colorpicker.js',
                            '../assets/global/plugins/bootstrap-datetimepicker/js/bootstrap-datetimepicker.min.js',

                            '../assets/pages/scripts/components-date-time-pickers.min.js',

                            'js/controllers/GeneralPageController.js'
                        ]
                    }]);
                }]
            }
        })

        // Custom Dropdowns
        .state('dropdowns', {
            url: "/dropdowns",
            templateUrl: "views/dropdowns.html",
            data: { pageTitle: 'Custom Dropdowns' },
            controller: "GeneralPageController",
            resolve: {
                deps: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load([{
                        name: 'realNextServiceWebApp',
                        insertBefore: '#ng_load_plugins_before', // load the above css files before '#ng_load_plugins_before'
                        files: [
                            '../assets/global/plugins/bootstrap-select/css/bootstrap-select.min.css',
                            '../assets/global/plugins/select2/css/select2.min.css',
                            '../assets/global/plugins/select2/css/select2-bootstrap.min.css',

                            '../assets/global/plugins/bootstrap-select/js/bootstrap-select.min.js',
                            '../assets/global/plugins/select2/js/select2.full.min.js',

                            '../assets/pages/scripts/components-bootstrap-select.min.js',
                            '../assets/pages/scripts/components-select2.min.js',

                            'js/controllers/GeneralPageController.js'
                        ]
                    }]);
                }]
            }
        })

        // Advanced Datatables
        .state('datatablesAdvanced', {
            url: "/datatables/managed.html",
            templateUrl: "views/datatables/managed.html",
            data: { pageTitle: 'Advanced Datatables' },
            controller: "GeneralPageController",
            resolve: {
                deps: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load({
                        name: 'realNextServiceWebApp',
                        insertBefore: '#ng_load_plugins_before', // load the above css files before '#ng_load_plugins_before'
                        files: [
                            '../assets/global/plugins/datatables/datatables.min.css',
                            '../assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.css',

                            '../assets/global/plugins/datatables/datatables.all.min.js',

                            '../assets/pages/scripts/table-datatables-managed.min.js',

                            'js/controllers/GeneralPageController.js'
                        ]
                    });
                }]
            }
        })

        // Ajax Datetables
        .state('datatablesAjax', {
            url: "/datatables/ajax.html",
            templateUrl: "views/datatables/ajax.html",
            data: { pageTitle: 'Ajax Datatables' },
            controller: "GeneralPageController",
            resolve: {
                deps: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load({
                        name: 'realNextServiceWebApp',
                        insertBefore: '#ng_load_plugins_before', // load the above css files before '#ng_load_plugins_before'
                        files: [
                            '../assets/global/plugins/datatables/datatables.min.css',
                            '../assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.css',
                            '../assets/global/plugins/bootstrap-datepicker/css/bootstrap-datepicker3.min.css',

                            '../assets/global/plugins/datatables/datatables.all.min.js',
                            '../assets/global/plugins/bootstrap-datepicker/js/bootstrap-datepicker.min.js',
                            '../assets/global/scripts/datatable.js',

                            'js/scripts/table-ajax.js',
                            'js/controllers/GeneralPageController.js'
                        ]
                    });
                }]
            }
        })

        // User Profile
        .state("profile", {
            url: "/profile",
            templateUrl: "views/profile/main.html",
            data: { pageTitle: 'User Profile' },
            controller: "UserProfileController",
            resolve: {
                deps: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load({
                        name: 'realNextServiceWebApp',
                        insertBefore: '#ng_load_plugins_before', // load the above css files before '#ng_load_plugins_before'
                        files: [
                            '../assets/global/plugins/bootstrap-fileinput/bootstrap-fileinput.css',
                            '../assets/pages/css/profile.css',

                            '../assets/global/plugins/jquery.sparkline.min.js',
                            '../assets/global/plugins/bootstrap-fileinput/bootstrap-fileinput.js',

                            '../assets/pages/scripts/profile.min.js',

                            'js/controllers/UserProfileController.js'
                        ]
                    });
                }]
            }
        })

        // User Profile Dashboard
        .state("profile.dashboard", {
            url: "/dashboard",
            templateUrl: "views/profile/dashboard.html",
            data: { pageTitle: 'User Profile' }
        })

        // User Profile Account
        .state("profile.account", {
            url: "/account",
            templateUrl: "views/profile/account.html",
            data: { pageTitle: 'User Account' }
        })

        // User Profile Help
        .state("profile.help", {
            url: "/help",
            templateUrl: "views/profile/help.html",
            data: { pageTitle: 'User Help' }
        })

        // Todo
        .state('todo', {
            url: "/todo",
            templateUrl: "views/todo.html",
            data: { pageTitle: 'Todo' },
            controller: "TodoController",
            resolve: {
                deps: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load({
                        name: 'realNextServiceWebApp',
                        insertBefore: '#ng_load_plugins_before', // load the above css files before '#ng_load_plugins_before'
                        files: [
                            '../assets/global/plugins/bootstrap-datepicker/css/bootstrap-datepicker3.min.css',
                            '../assets/apps/css/todo-2.css',
                            '../assets/global/plugins/select2/css/select2.min.css',
                            '../assets/global/plugins/select2/css/select2-bootstrap.min.css',

                            '../assets/global/plugins/select2/js/select2.full.min.js',

                            '../assets/global/plugins/bootstrap-datepicker/js/bootstrap-datepicker.min.js',

                            '../assets/apps/scripts/todo-2.min.js',

                            'js/controllers/TodoController.js'
                        ]
                    });
                }]
            }
        })
        .state('financialtransactions', {
            url: '/financialtransaction/overview',
            templateUrl: '/templates/financialtransaction/overview.tpl.html'.mapPath(),
            permissionCode: PermissionNameConstrant.ViewAllFinancialTransactions,
            controller: 'financialTransactionOverviewController'
        })
        .state('financialtransactions_subscription', {
            url: "/financialtransaction/subscription/:walletId",
            templateUrl: '/templates/financialtransaction/overview.subscription.tpl.html'.mapPath(),
            permissionCode: PermissionNameConstrant.ViewAllFinancialTransactions,
            controller: 'financialTransactionSubscriptionController'
        })
        .state('financialtransactionsDetail', {
            url: '/financialtransaction/detail/:transactionType/:fromDate/:toDate/:walletId',
            templateUrl: '/templates/financialtransaction/detail.tpl.html'.mapPath(),
            permissionCode: PermissionNameConstrant.ViewFinancialTransaction,
            controller: 'financialTransactionDetailController'
        })

        // Data Migration
        .state('data-migration-overview', {
            url: '/data-migration/overview',
            templateUrl: '/Templates/dataMigration/overview.tpl.html'.mapPath(),
            permissionCode: PermissionNameConstrant.ViewAllDataMigrations,
            controller: 'DataMigrationOverviewController'
        })
        .state('data-migration-add', {
            url: '/data-migration/add',
            templateUrl: '/Templates/dataMigration/add.tpl.html'.mapPath(),
            permissionCode: PermissionNameConstrant.CreateDataMigration,
            controller: 'DataMigrationAddController'
        })
        // Settings
        .state('edit-basic-setting', {
            url: '/basic-setting/edit',
            templateUrl: '/Templates/setting/basicSetting.tpl.html'.mapPath(),
            permissionCode: PermissionNameConstrant.EditSearchEngineSetting,
            controller: 'EditSearchEngineSettingController'
        })
        .state('edit-leadreport-setting', {
            url: '/leadreport-setting/edit',
            templateUrl: '/Templates/setting/leadReportSetting.tpl.html'.mapPath(),
            permissionCode: PermissionNameConstrant.EditMyLeadReportSetting,
            controller: 'LeadReportSettingController'
        })
        .state('edit-leadreport-setting-user', {
            url: '/leadreport-setting/edit/:userId/:userEmail',
            templateUrl: '/Templates/setting/leadReportSetting.tpl.html'.mapPath(),
            permissionCode: PermissionNameConstrant.UserEditLeadReportSetting,
            controller: 'LeadReportSettingController'
        })
        .state('edit-startpage-setting', {
            url: '/startpage-setting/edit',
            templateUrl: '/Templates/setting/startpageSetting.tpl.html'.mapPath(),
            permissionCode: PermissionNameConstrant.EditSearchEngineSetting,
            controller: 'EditStartPageSettingController'
        });
}]);