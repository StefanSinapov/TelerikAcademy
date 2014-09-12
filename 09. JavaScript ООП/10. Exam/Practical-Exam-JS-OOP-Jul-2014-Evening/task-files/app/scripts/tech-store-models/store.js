define(['tech-store-models/item'], function (Item) {

    'use strict';
    var Store = (function () {

        function Store(name) {
            var nameIsString = (typeof name === 'string' || name instanceof String),
                nameLengthIsValid = (name.length >= 6 && name.length <= 30 );
            if (!nameIsString && !nameLengthIsValid) {
                throw new TypeError('Store name must be string with length between 6 and 30 characters');
            }
            this.name = name;
            this._items = [];
        }

        Store.prototype.addItem = function (item) {
            if (item instanceof Item) {
                this._items.push(item);
            }
            return this;
        };

        Store.prototype.getAll = function () {
            var copiedItems = this._items.concat();
            sortItemsByName(copiedItems);
            return copiedItems;
        };

        Store.prototype.getSmartPhones = function () {
            var filtered = filterItemsTypeBy(this._items, 'smart-phone');
            sortItemsByName(filtered);
            return filtered;
        };

        Store.prototype.getMobiles = function () {
            var filtered = filterItemsTypeBy(this._items, 'smart-phone', 'tablet');
            sortItemsByName(filtered);
            return filtered;
        };

        Store.prototype.getComputers = function () {
            var filtered = filterItemsTypeBy(this._items, 'pc', 'notebook');
            sortItemsByName(filtered);
            return filtered;
        };

        Store.prototype.filterItemsByType = function (filterType) {
            var filtered = filterItemsTypeBy(this._items, filterType);
            sortItemsByName(filtered);
            return filtered;
        };

        Store.prototype.filterItemsByPrice = function (options) {
            if (options === undefined) {
                options = {};
            }
            var minValue = options.min || 0;
            var maxValue = options.max || Number.POSITIVE_INFINITY;
            var filtered = this._items.filter(function (item) {
                return (item.price >= minValue && item.price <= maxValue);
            });
            filtered.sort(function (first, second) {
                return first.price - second.price;
            });

            return filtered;
        };

        Store.prototype.countItemsByType = function () {
            var result = {};
            this._items.forEach(function (item) {
                if (result.hasOwnProperty(item.type)) {
                    result[item.type] += 1;
                }
                else {
                    result[item.type] = 1;
                }
            });

            return result;
        };

        Store.prototype.filterItemsByName = function (partOfName) {
            var filtered = this._items.filter(function (item) {
                return (item.name.toLowerCase().indexOf(partOfName.toLowerCase()) !== -1);
            });

            sortItemsByName(filtered);

            return filtered;
        };


        function filterItemsTypeBy(items, firstCondition, secondCondition) {
            if (secondCondition === undefined) {
                secondCondition = firstCondition;
            }
            var filtered = items.filter(function (item) {
                return (item.type === firstCondition || item.type === secondCondition);
            });

            return filtered
        }

        function sortItemsByName(array) {
            array.sort(function (first, second) {
                if (first.name > second.name) {
                    return 1;
                }
                if (first.name < second.name) {
                    return -1;
                }
                return 0;
            });
        }

        return Store;

    }());

    return Store;
})
;