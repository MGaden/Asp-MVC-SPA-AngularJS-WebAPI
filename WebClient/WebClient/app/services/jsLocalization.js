appRoot.service('jsLocalization', function ($resource) {
    this.getResourceValues = function (fileName, resDic, callback) {
        var GetString = $resource('/api/shared/getResourceStrings?resName=' + fileName, {},
         {
             'query': { method: 'Post' }
         });
        GetString.query(resDic, function (data) {
            callback(data);
        }, function (response) {

        })
    };
});