define(function () {
    'use strict';
    var Item = (function () {
        function Item(type, name, price) {

            _setType.call(this, type);
            _setName.call(this, name);
            _setPrice.call(this, price);
        }

        function _setType(type) {
            if (type === 'accessory' || type === 'smart-phone' || type === 'notebook' ||
                type === 'pc' || type === 'tablet') {
                this.type = type;
            }
            else {
                throw new TypeError('Item time is invalid');
            }
        }

        function _setName(name) {
            if (name.length < 6 || name.length > 40) {
                throw new TypeError('Item name must be string between 6 and 40-characters-long ');
            }
            this.name = name;
        }

        function _setPrice(price) {
            if(!isNumber(price)){
                throw new TypeError('Item price must be a decimal floating-point number')
            }
            this.price = price;
        }

        function isNumber(o) {
            return !isNaN(o - 0) && o !== null && o !== "" && o !== false;
        }

        isNumber(''); // false

        return Item;
    }());

    return Item;
});