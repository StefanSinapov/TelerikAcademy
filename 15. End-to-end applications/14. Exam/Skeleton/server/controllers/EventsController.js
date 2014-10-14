'use strict';

var events = require('../data/events');
var initiatives = [undefined, 'Software Academy', 'Algo Academy', 'School Academy', 'Kids Academy'];
var seasons = [undefined, 'Started 2010', 'Started 2011', 'Started 2012', 'Started 2013'];
var categories = ['Lecture', 'Seminar', 'Workshop', 'Team building', 'Free time', 'Sport', 'Exam', 'Graduation'];
var CONTROLLER_NAME = 'events';

module.exports = {
    getCreate: function (req, res, next) {
        if (!req.user.phoneNumber) {
            req.session.error = 'Users without phone number cant create event, please add your phone number!';
            res.redirect('/profile');
        }
        else {
            res.render(CONTROLLER_NAME + '/create', { initiatives: initiatives, seasons: seasons, categories: categories });
        }
    },
    postCreate: function (req, res, next) {
        var newEventData = {
            date: req.body.date,
            title: req.body.title,
            description: req.body.description,
            location: req.body.location,
            category: req.body.category,
            type: {},
            creator: req.user._id,
            comments: []
        };

        if (req.body.isPublic) {
            newEventData.type.isPublic = true;
        }
        else {
            newEventData.type.isPublic = false;
            if (req.body.initiative) {
                newEventData.type.initiative = req.body.initiative;
            }
            if (req.body.season) {
                newEventData.type.season = req.body.season;
            }
        }


        //console.log(newEventData);
        //res.redirect('/events/create');

        events.create(newEventData, function (err, event) {
            if (err) {
                req.session.error = 'Event failed to create, please try again';
                res.redirect('/events/create');
            }
            else {
                req.session.success = 'Event created successfully';
                res.redirect('/');
            }
        });
    },

    getActive: function (req, res, next) {
        var filters = {
            page: 1,
            activeOnly: true
        };

        if (req.query.page) {
            filters.page = req.query.page;
            //filters.page++;
        }


        events.getQuery(filters, function (err, events) {
            if (err) {
                req.session.error = 'Cant load active events, please check you connection';
                res.redirect('/');
            }
            else {
                res.render(CONTROLLER_NAME + '/active', {events: events, filters: filters});
            }
        });
    },
    getPast: function (req, res, next) {
        var filters = {
            page: 1,
            isPast: true
        };

        if (req.query.page) {
            filters.page = req.query.page;
        }


        events.getQuery(filters, function (err, events) {
            if (err) {
                req.session.error = 'Cant load active events, please check you connection';
                res.redirect('/');
            }
            else {
                res.render(CONTROLLER_NAME + '/past', {events: events, filters: filters});
            }
        });
    },
    getEventById: function (req, res, next) {
        var id = req.params.id;

        events.getById(id, function (err, event) {
            if (err) {
                req.session.error = 'Cant find such event';
                res.redirect('/');
            }
            res.render(CONTROLLER_NAME + '/event-details', {event: event});
        });

    },
    postEventById: function (req, res, next) {
        var id = req.params.id;
        var newComment = {
            username: req.user.username,
            content: req.body.comment
        };
        events.getById(id, function (err, event) {
            if (err) {
                req.session.error = 'Cant find this event';
                res.redirect('/');
            }
            else{
                event.comments.push(newComment);

                events.save(event, function (err, responce) {
                    if (err) {
                        req.session.error = 'Failed saving the comment';
                        res.redirect('/');
                    }
                    else{
                        req.session.success = 'Successfully comment on event';
                        res.redirect('/events/' + event._id);
                    }
                });
            }
        });
    },
    joinEvent: function(req, res, next){
        var id = req.params.id;

        events.getById(id, function (err, event) {
            if (err) {
                req.session.error = 'Cant find this event';
                res.redirect('/');
            }
            else{
                event.participants.push(req.user._id);

                events.save(event, function (err, responce) {
                    if (err) {
                        req.session.error = 'Failed saving the event';
                        res.redirect('/');
                    }
                    else{
                        req.session.success = 'Successfully joined event';
                        res.redirect('/events/' + event._id);
                    }
                });
            }
        });
    }
};