var states={
	commonStates:[
		{
			name:"common.dashbord",
			config:{
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
        	}
		},
		{
			name:"common.resetpassword",
			config:{
	            url: '/account/resetpassword?userid&code',
	            templateUrl: '/Templates/account/resetpassword.tpl.html'.mapPath(),
	            permissionCode: PermissionNameConstrant.Open,
	            controller: 'resetPasswordController'
	        }
		},
		{
			name:"common.nopermission",
			config:{
	            url: '/nopermission/:denyPage',
	            templateUrl: '/Templates/common/nopermission.tpl.html'.mapPath(),
	            controller: "NoPermissionController",
	            permissionCode: 'Open'
	        }
		}
	],
	offerStates:[
		{
			name:"offer.overview",
			config:{
	            url: '/offer/overview/my',
	            templateUrl: '/Templates/realEstateObject/overview.tpl.html'.mapPath(),
	            controller: "OfferOverviewController",
	            permissionCode: PermissionNameConstrant.ViewAllRealEstateObjects,
	            resolve: {
	                tabName: function () {
	                    return "myObjects";
	                }
	            }
	        }
		},
		{
			name:"offer.overview.allOffers",
			config:{
	            url: '/offer/overview/all',
	            templateUrl: '/Templates/realEstateObject/overview.tpl.html'.mapPath(),
	            controller: "OfferOverviewController",
	            permissionCode: PermissionNameConstrant.ViewAllRealEstateObjects,
	            resolve: {
	                tabName: function () {
	                    return "allObjects";
	                }
	            }
	        }
		},
		{
			name:"offer.overview.myOffers",
			config:{
	            url: '/offer/overview/my',
	            templateUrl: '/Templates/realEstateObject/overview.tpl.html'.mapPath(),
	            controller: "OfferOverviewController",
	            permissionCode: PermissionNameConstrant.ViewAllRealEstateObjects,
	            resolve: {
	                tabName: function () {
	                    return "myObjects";
	                }
	            }
	        }
		},
		{
			name:"offer.overview.linkedOwnOffers",
			config:{
	            url: '/offer/overview/linked-own-offers',
	            templateUrl: '/Templates/realEstateObject/overview.tpl.html'.mapPath(),
	            controller: "OfferOverviewController",
	            permissionCode: PermissionNameConstrant.ViewAllRealEstateObjects,
	            resolve: {
	                tabName: function () {
	                    return "linkedOwnOffers";
	                }
	            }
	        }
		},
		{
			name:"offer.overview.acceptedLinkedOffers",
			config:{
	            url: '/offer/overview/accepted-linked-offer',
	            templateUrl: '/Templates/realEstateObject/overview.tpl.html'.mapPath(),
	            controller: "OfferOverviewController",
	            permissionCode: PermissionNameConstrant.ViewAllRealEstateObjects,
	            resolve: {
	                tabName: function () {
	                    return "acceptedLinkedOffers";
	                }
	            }
	        }
		},
		{
			name:"offer.overview.linkedOfferRequests",
			config:{
	            url: '/offer/overview/linked-offer-requests',
	            templateUrl: '/Templates/realEstateObject/overview.tpl.html'.mapPath(),
	            controller: "OfferOverviewController",
	            permissionCode: PermissionNameConstrant.ViewAllRealEstateObjects,
	            resolve: {
	                tabName: function () {
	                    return "linkedOfferRequests";
	                }
	            }
	        }
		},
		{
			name:"offer.overview.rejectedLinkedOffers",
			config:{
	            url: '/offer/overview/rejected-linked-offer',
	            templateUrl: '/Templates/realEstateObject/overview.tpl.html'.mapPath(),
	            controller: "OfferOverviewController",
	            permissionCode: PermissionNameConstrant.ViewAllRealEstateObjects,
	            resolve: {
	                tabName: function () {
	                    return "rejectedLinkedOffer";
	                }
	            }
	        }
		},
		{
			name:"offer.overview.draftOffers",
			config:{
	            url: '/offer/overview/draft',
	            templateUrl: '/Templates/realEstateObject/overview.tpl.html'.mapPath(),
	            controller: "OfferOverviewController",
	            permissionCode: PermissionNameConstrant.ViewAllRealEstateObjects,
	            resolve: {
	                tabName: function () {
	                    return "draftObjects";
	                }
	            }
	        }
		},
		{
			name:"offer.overview.archivedOffers",
			config:{
	            url: '/offer/overview/archived',
	            templateUrl: '/Templates/realEstateObject/overview.tpl.html'.mapPath(),
	            controller: "OfferOverviewController",
	            permissionCode: PermissionNameConstrant.ViewAllRealEstateObjects,
	            resolve: {
	                tabName: function () {
	                    return "archivedObjects";
	                }
	            }
	        }
		},
		{
			name:"offer.overview.fromSearch",
			config:{
		        url: '/offer/overview/:keyword',
		        templateUrl: '/Templates/realEstateObject/overview.tpl.html'.mapPath(),
		        controller: "OfferOverviewController",
		        permissionCode: PermissionNameConstrant.ViewAllRealEstateObjects
		    }
		},		
		{
			name:"offer.statistics",
			config:{
	            url: '/offer/statistics/:friendlyId',
	            templateUrl: '/Templates/realEstateObject/analytics.tpl.html'.mapPath(),
	            controller: 'OfferAnalyticsController',
	            permissionCode: PermissionNameConstrant.EditRealEstateObject,
	            resolve: {
	                readOnly: function () {
	                    return false;
	                }
	            }
	        }
		},
		{
			name:"offer.detail",
			config:{
	            url: '/offer/detail/:id',
	            templateUrl: '/Templates/realEstateObject/detail/detail.tpl.html'.mapPath(),
	            controller: 'OfferDetailController',
	            permissionCode: PermissionNameConstrant.EditRealEstateObject,
	            resolve: {
	                readOnly: function () {
	                    return false;
	                }
	            }
	        }
		},
		{
			name:"offer.detail.withkeyword",
			config:{
	            url: '/offer/detail/{id:string}/{keyword:string}',
	            templateUrl: '/Templates/realEstateObject/detail/detail.tpl.html'.mapPath(),
	            controller: 'OfferDetailController',
	            permissionCode: PermissionNameConstrant.EditRealEstateObject,
	            resolve: {
	                readOnly: function () {
	                    return false;
	                }
	            }
	        }
		},
		{
			name:"offer.detail.view",
			config:{
	            url: '/offer/view/:id',
	            templateUrl: '/Templates/realEstateObject/view.tpl.html'.mapPath(),
	            controller: 'OfferViewController',
	            permissionCode: PermissionNameConstrant.LinkedOfferViewInvite,
	            resolve: {
	                readOnly: function () {
	                    return true;
	                }
	            }
	        }
		},
		{
			name:"offer.add",
			config:{
	            url: '/offer/add{step:.*}',
	            templateUrl: '/Templates/realEstateObject/add.tpl.html'.mapPath(),
	            permissionCode: PermissionNameConstrant.CreateRealEstateObject,
	            controller: 'AddOfferController'
	        }
		}
	],
	userRoleStates:[
		{
			name:"user.overview",
			config:{
	            url: '/user/overview',
	            templateUrl: '/Templates/user/overview.tpl.html'.mapPath(),
	            permissionCode: PermissionNameConstrant.ViewAllUsers,
	            controller: 'UserOverviewController',
	            resolve: {
	                userType: function () {
	                    return ['Customer'];
	                }
	            }
	        }
		},
		{
			name:"staff.overview",
			config:{
	            url: '/staff/overview',
	            templateUrl: '/Templates/staff/overview.tpl.html'.mapPath(),
	            permissionCode: PermissionNameConstrant.ViewAllUsers,
	            controller: 'UserOverviewController',
	            resolve: {
	                userType: function () {
	                    return ['BrokerManager'];
	                }
	            }
	        }
		},
		{
			name:"user.detail",
			config:{
	            url: '/user/detail/:id',
	            templateUrl: '/Templates/user/detail.tpl.html'.mapPath(),
	            permissionCode: PermissionNameConstrant.EditUser,
	            controller: 'UserDetailController'
	        }
		},
		{
			name:"user.add",
			config: {
	            url: '/user/add',
	            templateUrl: '/Templates/user/add.tpl.html'.mapPath(),
	            permissionCode: PermissionNameConstrant.CreateUser,
	            controller: 'UserAddController'
	        }
		},
		{
			name:"role.overview",
			config:{
	            url: '/role/overview',
	            templateUrl: '/Templates/role/overview.tpl.html'.mapPath(),
	            permissionCode: PermissionNameConstrant.ViewAllRoles,
	            controller: 'RoleOverviewController'
	        }
		},
		{
			name:"role.detail",
			config:{
	            url: '/role/detail/:id',
	            templateUrl: '/Templates/role/detail.tpl.html'.mapPath(),
	            permissionCode: PermissionNameConstrant.EditRole,
	            controller: 'RoleDetailController'
	        }
		},
		{
			name:"role.add",
			config:{
	            url: '/role/add',
	            templateUrl: '/Templates/role/add.tpl.html'.mapPath(),
	            permissionCode: PermissionNameConstrant.CreateRole,
	            controller: 'RoleAddController'
	        }
		}
	],
	transactionStates:[
		{
			name:"transaction.overview.all",
			config:{
	            url: '/transaction/overview/all',
	            templateUrl: '/Templates/transaction/overview.tpl.html'.mapPath(),
	            permissionCode: PermissionNameConstrant.ViewAllTransactions,
	            controller: 'TransactionOverviewController',
	            resolve: {
	                tabName: function () {
	                    return "all";
	                }
	            }
	        }
		},
		{
			name:"transaction.overview.my",
			config:{
	            url: '/transaction/overview/my',
	            templateUrl: '/Templates/transaction/overview.tpl.html'.mapPath(),
	            permissionCode: PermissionNameConstrant.ViewAllTransactions,
	            controller: 'TransactionOverviewController',
	            resolve: {
	                tabName: function () {
	                    return "my";
	                }
	            }
	        }
		},
		{
			name:"transaction.detail",
			config:{
	            url: '/transaction/detail/:id',
	            templateUrl: '/Templates/transaction/detail.tpl.html'.mapPath(),
	            permissionCode: PermissionNameConstrant.EditTransaction,
	            controller: 'TransactionDetailController'
	        }
		},
		{
			name:"transaction.preiew",
			config:{
	            url: '/transaction/preview/:id',
	            templateUrl: '/Templates/transaction/preview.tpl.html'.mapPath(),
	            permissionCode: PermissionNameConstrant.EditTransaction,
	            controller: 'TransactionPreviewController'
	        }
		},
		{
			name:"transaction.add",
			config: {
	            url: '/transaction/add',
	            templateUrl: '/Templates/transaction/add.tpl.html'.mapPath(),
	            permissionCode: PermissionNameConstrant.CreateTransaction,
	            controller: 'TransactionAddController'
	        }
		},
		{
			name:"transaction.add.fromObject",
			config:{
	            url: '/transaction/add/{objectId:string}/{type:string}',
	            templateUrl: '/Templates/transaction/add.tpl.html'.mapPath(),
	            permissionCode: PermissionNameConstrant.CreateTransaction,
	            controller: 'TransactionAddController'
	        }
		}
	],
	leadStates:[
		{
			name:"lead.overview",
			config:{
	            url: '/dataCollectiveLead/overview',
	            templateUrl: '/Templates/dataCollectiveLead/overview.tpl.html'.mapPath(),
	            permissionCode: PermissionNameConstrant.ViewAllDataCollectiveLeads,
	            data: {
	                tab: 0,
	            },
	            controller: 'DataCollectiveLeadOverviewController'
	        }
		},
		{
			name:"lead.overview.all",
			config:{
	            url: '/dataCollectiveLead/overview/allleads',
	            templateUrl: '/Templates/dataCollectiveLead/overview.tpl.html'.mapPath(),
	            permissionCode: PermissionNameConstrant.ViewAllDataCollectiveLeads,
	            data: {
	                tab: 1,
	            },
	            controller: 'DataCollectiveLeadOverviewController'
	        }
		},
		{
			name:"lead.detail",
			config: {
	            url: '/dataCollectiveLead/detail/:id/:utcStartDate/:utcEndDate',
	            templateUrl: '/Templates/dataCollectiveLead/detail.tpl.html'.mapPath(),
	            permissionCode: PermissionNameConstrant.ViewDataCollectiveLead,
	            controller: 'DataCollectiveLeadDetailController'
	        }
		}
	],
	financialtransactionStates:[
		{
			name:"financialtransaction.overview",
			config: {
	            url: '/financialtransaction/overview',
	            templateUrl: '/templates/financialtransaction/overview.tpl.html'.mapPath(),
	            permissionCode: PermissionNameConstrant.ViewAllFinancialTransactions,
	            controller: 'financialTransactionOverviewController'
	        }
		},
		{
			name:"financialtransaction.overview.subscription",
			config:{
	            url: "/financialtransaction/subscription/:walletId",
	            templateUrl: '/templates/financialtransaction/overview.subscription.tpl.html'.mapPath(),
	            permissionCode: PermissionNameConstrant.ViewAllFinancialTransactions,
	            controller: 'financialTransactionSubscriptionController'
	        }
		},
		{
			name:"financialtransaction.detail",
			config:{
	            url: '/financialtransaction/detail/:transactionType/:fromDate/:toDate/:walletId',
	            templateUrl: '/templates/financialtransaction/detail.tpl.html'.mapPath(),
	            permissionCode: PermissionNameConstrant.ViewFinancialTransaction,
	            controller: 'financialTransactionDetailController'
	        }
		}
	],
	dataMigrationStates:[
		{
			name:"dataMigration.overview",
			config:{
	            url: '/data-migration/overview',
	            templateUrl: '/Templates/dataMigration/overview.tpl.html'.mapPath(),
	            permissionCode: PermissionNameConstrant.ViewAllDataMigrations,
	            controller: 'DataMigrationOverviewController'
	        }
		},
		{
			name:"dataMigration.add",
			config:{
	            url: '/data-migration/add',
	            templateUrl: '/Templates/dataMigration/add.tpl.html'.mapPath(),
	            permissionCode: PermissionNameConstrant.CreateDataMigration,
	            controller: 'DataMigrationAddController'
	        }
		}
	],
	settingStates:[
		{
			name:"setting.basic",
			config:{
	            url: '/basic-setting/edit',
	            templateUrl: '/Templates/setting/basicSetting.tpl.html'.mapPath(),
	            permissionCode: PermissionNameConstrant.EditSearchEngineSetting,
	            controller: 'EditSearchEngineSettingController'
	        }
		},
		{
			name:"setting.leadreport",
			config:{
	            url: '/leadreport-setting/edit',
	            templateUrl: '/Templates/setting/leadReportSetting.tpl.html'.mapPath(),
	            permissionCode: PermissionNameConstrant.EditMyLeadReportSetting,
	            controller: 'LeadReportSettingController'
	        }
		},
		{
			name:"setting.leadreport.user",
			config: {
	            url: '/leadreport-setting/edit/:userId/:userEmail',
	            templateUrl: '/Templates/setting/leadReportSetting.tpl.html'.mapPath(),
	            permissionCode: PermissionNameConstrant.UserEditLeadReportSetting,
	            controller: 'LeadReportSettingController'
	        }
		},
		{
			name:"setting.startpage",
			config:{
	            url: '/startpage-setting/edit',
	            templateUrl: '/Templates/setting/startpageSetting.tpl.html'.mapPath(),
	            permissionCode: PermissionNameConstrant.EditSearchEngineSetting,
	            controller: 'EditStartPageSettingController'
	        }
		}
	]
}