appRoot.service('DataService', function ($http, $resource) {

    this.GetAllData = function (callback) {

        var dataController = $resource('/api/data/GetAllData', {}, {
            query: {
                method: 'GET'
                , isArray: true
            }
        });

        dataController.query(function (data) {
            callback(data);
        });

    };

    this.getFilteredData = function (order, callback) {
        var fController = $resource("/api/data/GetFilteredData", {}, {
            create: {
                method: 'POST'
                , isArray: true
            }
        });

        fController.create(order, function (data) {
            callback(data);
        }, function (response) {
            callback(response);
        });

    };

    this.addOrder = function (order, callback) {
        var saveController = $resource("/api/data/AddOrder", {}, {
            create: {
                method: 'POST'
            }
        });

        saveController.create(order, function (data) {
            callback(data);
        }, function (response) {
            callback(response);
        });

    };

    this.updateOrder = function (order, callback) {
        var saveController = $resource("/api/data/UpdateOrder", {}, {
            create: {
                method: 'POST'
            }
        });

        saveController.create(order, function (data) {
            callback(data);
        }, function (response) {
            callback(response);
        });

    };

    this.deleteOrder = function (id, callback) {
        var deleteController = $resource("/api/data/DeleteOrder/:id", { id: '@id' }, {
            create: {
                method: 'POST'
            }
        });

        deleteController.create({ id: id }, function (data) {
            callback(data);
        }, function (response) {
            callback(response);
        });

    };




});