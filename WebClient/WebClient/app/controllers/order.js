appRoot.controller('OrderController', function ($scope, DataService, jsLocalization) {

    $scope.orders = [];
    $scope.order = {};
    $scope.fOrder = {};
    $scope.isEditing = false;

    //load resources
    $scope.resourcesValues = [];

    //load resources
    var resDic = {}
    resDic.resArray = [];
    resDic.resArray.push('home');
    resDic.resArray.push('addOrder');
    resDic.resArray.push('confirmDelete');
    resDic.resArray.push('delete');
    resDic.resArray.push('edit');
    resDic.resArray.push('filterList');
    resDic.resArray.push('filterOrderList');
    resDic.resArray.push('name');
    resDic.resArray.push('orderList');
    resDic.resArray.push('price');
    resDic.resArray.push('save');

    jsLocalization.getResourceValues('Main.Resource', resDic, function (resourcedata) {
        $scope.resourcesValues = resourcedata;
    });
    //-----------------------

    $scope.refreshGrid = function () {
        DataService.GetAllData(function (data) {
            $scope.orders = data;
        });
    };
    
    $scope.refreshGrid();

    $scope.saveOrder = function () {
        if ($scope.isEditing)
        {
            DataService.updateOrder($scope.order, function (result) {
                if (result.Sucess != undefined && result.Sucess) {
                    $scope.order = {};
                    frmsaveOrder.orderName.$dirty = false;
                    $scope.isEditing = false;
                    $scope.refreshGrid();
                }
                else {

                }
               
            });
            
        }
        else
        {
            DataService.addOrder($scope.order, function (result) {
                if (result.Sucess != undefined && result.Sucess) {
                    $scope.order = {};
                    frmsaveOrder.orderName.$dirty = false;
                    $scope.refreshGrid();
                }
                else {

                }
                
            });
        }
        
    };

    $scope.updatePrice = function (order) {
        if (/^\$?(?!0.00)(([0-9]{1,3},([0-9]{3},)*)[0-9]{3}|[0-9]{1,3})(\.[0-9]{2})?$/.test(order.Price))
        {
            DataService.updateOrder(order, function (result) {
                if (result.Sucess != undefined && result.Sucess) {
                    $scope.order = {};
                    $scope.isEditing = false;
                    $scope.refreshGrid();
                }
                else {

                }

            });
        }
    };

    
    $scope.filterOrder = function () {
        if ($scope.fOrder.Name != undefined || $scope.fOrder.Price != undefined)
        {
            DataService.getFilteredData($scope.fOrder, function (data) {
                $scope.orders = data;
            });
        }
        else
        {
            $scope.refreshGrid();
        }
             
        $scope.fOrder = {};
    };

    $scope.delete = function (id) {
        DataService.deleteOrder(id, function (result) {
            if (result.Sucess != undefined && result.Sucess)
            {
                $scope.refreshGrid();
            }
            else
            {

            }
            
        });
    };

    $scope.edit = function (order) {
        $scope.order = order;
        $scope.isEditing = true;
    };

});