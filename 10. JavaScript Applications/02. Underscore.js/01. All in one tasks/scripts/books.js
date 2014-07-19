define(['chance'], function (Chance) {
    'use strict';
    var books = [],
        chance = new Chance(),
        titlesList = ['Harry Potter', 'Game of Thrones', 'The Stand', 'It', 'The Shining', 'Pet Sematary',
            'The Stand', 'Dr. Sleep', 'Hamlet', 'Macbeth', 'Romeo and Juliet', 'Othello',
            'And Then There Were None', 'Murder on the Orient Express'],
        authorsList = ['George R. R. Martin', 'J. K. Rowling', 'Steven King', 'William Shakespeare', 'Agatha Christie'];

    for (var i = 0; i < titlesList.length; i++) {
        books.push({
            title: titlesList[i],
            author: authorsList[chance.integer({min: 0, max: authorsList.length - 1})]
        });
    }
    return books;
});