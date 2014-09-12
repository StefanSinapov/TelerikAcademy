define(function () {
    'use strict';
    var Section;
    Section = (function () {
        function Section(title) {
            this.title = title;
            this._items = [];
        }

        Section.prototype.add = function (item) {
            this._items.push(item);
        };

        Section.prototype.getData = function () {
            var itemsCopy = this._items.map(function (item) {
                return item.getData();
            });

            return {
                title: this.title,
                items: itemsCopy
            }
        };

        return Section;
    }());

    return Section;
});