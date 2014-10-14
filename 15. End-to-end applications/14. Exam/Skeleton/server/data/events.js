'use strict';

var Event = require('mongoose').model('Event');
var DEFAULT_PAGE_SIZE = 10;

module.exports = {
    create: function (event, callback) {
        Event.create(event, callback);
    },
    getCount: function (callback) {
        Event.count({}, callback);
    },
    getQuery: function (filters, callback) {
        var today = new Date();
        var page = Math.max(filters.page, 1);
        var orderBy = filters.orderBy || 'date';
        var activeOnly = filters.activeOnly || false;
        var creator = filters.creator || undefined;
        var joinedBy = filters.joinedBy || joinedBy;
        var isPast = filters.isPast || false;

        var query = Event.find()
            .sort(orderBy)
            .skip(DEFAULT_PAGE_SIZE * (page - 1))
            .limit(DEFAULT_PAGE_SIZE);

        if (activeOnly) {
            query.where('date').gte(today);
        }

        if (isPast) {
            query.where('date').lt(today);
        }

        if (creator) {
            query.where({creator: creator});
        }
        if (joinedBy) {
            query.where({'participants': joinedBy});
        }

        query.exec(callback);
    },
    getById: function (id, callback) {
        Event
            .findOne({ _id: id })
            .populate('creator', 'username phoneNumber')
            .populate('participants', '_id')
            .exec(callback);
    },
    save: function (event, callback) {
        event.save(callback);
    }
};