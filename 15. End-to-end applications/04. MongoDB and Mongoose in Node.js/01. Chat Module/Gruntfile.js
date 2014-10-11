module.exports = function (grunt) {
    'use strict';
    require('load-grunt-tasks')(grunt);
    grunt.initConfig({
        watch: {
            options: {
                livereload: true
            },
            express: {
                files: [ '*.js', 'server/**/*.js' ],
                tasks: [ 'express:development' ],
                options: {
                    spawn: false // Without this option specified express won't be reloaded
                }
            }
        },
        express: {
            options: {
                port: 3000,
                node_env: 'development'
            },
            development: {
                options: {
                    script: 'server.js',
                    node_env: 'development'
                }
            },
			production: {
				option: {
					script: 'server.js',
					node_env: 'production'
				}
			}
        }
    });

    grunt.registerTask('server', function (arg) {
        if (arg && arg === 'production') {
            grunt.task.run([
                'express:production',
                'watch'
            ]);
        }
        else {
            grunt.task.run([
                'express:development',
                'watch'
            ]);
        }
    });
    grunt.registerTask('default', [ 'server' ]);
    grunt.registerTask('dist', [ 'server:production' ]);
};