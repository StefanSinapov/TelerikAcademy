/* global app */

'use strict';

app.factory('TodosResource', function ($resource) {

    return $resource('/api/todos/:id', { id: '@_id' }, {
        update: {
            method: 'PUT' // this method issues a PUT request
        }
    });
});