'use strict';

var data = require('../data');


module.exports = {
    getStatistics: function(req, res, next){
        var statistics = {};

        data.users.getCount(function(err, users){
            if(err){
                res.status(400).json({message: "Failed to get users count"});
            }
            else{
                statistics.users = users;

                data.files.getCount(function(err, files){
                    if(err){
                        res.statis(400).json({message: "Failed to get files count"});

                    }
                    else {
                        statistics.files = files;

                        res.json(statistics);
                    }
                });
            }
        });
    }
};