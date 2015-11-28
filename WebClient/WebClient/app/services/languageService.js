appRoot.service('languageService', function ($http, $resource) {

    this.GetLanguages = function (callback) {

        var langController = $resource('/api/language/GetLanguages', {}, {
            query: {
                method: 'GET'
                , isArray: true
            }
        });

        langController.query(function (data) {
            callback(data);
        });

    };

    this.GetPreSelectedLanguage = function (callback) {

        var plangController = $resource('/api/language/GetSelectedCulture', {}, {
            query: {
                method: 'GET'
            }
        });

        plangController.query(function (data) {
            callback(data);
        });

    };

    this.changeLang = function (culture , callback) {

        var clangController = $resource('/api/language/SetCulture/:cultureName', { cultureName: '@cultureName' },
          {
              'change': { method: 'Get' }
          });

        clangController.change({ cultureName: culture },function (data) {
            callback(data);
        });

    };


});