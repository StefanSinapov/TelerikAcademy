module.exports = function (grunt) {
    grunt.initConfig({
        connect: {
            options: {
                port: 9578,
                livereload: 35729,
                hostname: 'localhost'
            },
            livereload: {
                options: {
                    open: true,
                    base: ['dev']
                }
            }
        },
        watch: {
            coffee: {
                files: ['dev/scripts/*.coffee'],
                task: ['coffee'],
                options: {
                    livereload: true
                }
            },
            js: {
                files: ['dev/scripts/*.js'],
                tasks: ['jshint'],
                options: {
                    livereload: true
                }
            },
            styles: {
                files: ['dev/styles/*.styl'],
                tasks: ['stylus'],
                options: {
                    livereload: true
                }
            },
            jade: {
              files: ['dev/jade/*.jade'],
                tasks: ['jade'],
                options: {
                    livereload: true
                }
            },
            html: {
                files: ['dev/*.html'],
                options: {
                    livereload: true
                }
            },
            livereload: {
                options: {
                    livereload: '<%= connect.options.livereload %>'
                },
                files: [
                    'dev/*.html',
                    'dev/jade/*.jade',

                    'dev/styles/*.css',
                    'dev/styles/*.styl'
                ]
            }
        },
        stylus: {
            compile: {
                options: {
                    compress: false
                },
                files: {
                    'dev/styles/styles.css': 'dev/styles/styles.styl'
                }
            }
        },
        jade: {
            compile: {
                options: {
                    pretty: true
                },
                files: {
                    'dev/index.html': 'dev/jade/index.jade'
                }
            }
        },
        coffee: {
            compile: {
                files: {
                    'dev/scripts/scripts.js': 'dev/scripts/scripts.coffee'
                }
            }
        },
        copy: {
            main: {
                cwd: 'app/imgs',
                src: '**/*',
                dest: 'dev/imgs',
                expand: true
            }
        }
    });

    grunt.loadNpmTasks('grunt-contrib-stylus');
    grunt.loadNpmTasks('grunt-contrib-jade');
    grunt.loadNpmTasks('grunt-contrib-coffee');
    grunt.loadNpmTasks('grunt-contrib-copy');
    grunt.loadNpmTasks('grunt-contrib-connect');
    grunt.loadNpmTasks('grunt-contrib-watch');

    grunt.registerTask('serve', ['stylus', 'jade', 'coffee', 'copy', 'connect', 'watch']);
};