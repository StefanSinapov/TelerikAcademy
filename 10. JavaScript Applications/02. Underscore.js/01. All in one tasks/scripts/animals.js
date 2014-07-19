define(['chance'], function (Chance) {
    'use strict';
    var animals = [],
        chance = new Chance(),
        allowedLegCount = [2, 4, 6, 8, 100],
        allowedSpecies = ['Mammals', 'Reptiles', 'Birds', 'Insects', 'Aquatic Animals'];

    for (var i = 0; i < 20; i++) {
        animals.push({
            name: chance.first(),
            legsCount: allowedLegCount[chance.integer({min: 0, max: allowedLegCount.length - 1})],
            specie: allowedSpecies[chance.integer({min: 0, max: allowedSpecies.length - 1})]
        });
    }

    return animals;
});