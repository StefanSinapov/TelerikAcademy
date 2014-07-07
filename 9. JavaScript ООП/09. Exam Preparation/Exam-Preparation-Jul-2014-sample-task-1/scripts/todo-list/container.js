define(function () {
    'use strict';
    var Container;
    Container = (function () {
        function Container() {
            this._sections = [];
        }

        Container.prototype.add = function (section) {
            this._sections.push(section);
        };

        Container.prototype.getData = function () {
            return this._sections.map(function (item) {
                return item.getData();
            })
        };

        return Container;
    }());
    return Container;
});