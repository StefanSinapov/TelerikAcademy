///<reference path='Interfaces.ts'/>
var Utilities;
(function (Utilities) {
    var List = (function () {
        function List() {
            this._collection = [];
        }
        List.prototype.add = function (item) {
            this._collection.push(item);
        };

        List.prototype.remove = function (item) {
            var index = this._collection.indexOf(item);
            if (index > -1) {
                this._collection.splice(index, 1);
            }
        };

        Object.defineProperty(List.prototype, "count", {
            get: function () {
                return this._collection.length;
            },
            enumerable: true,
            configurable: true
        });
        return List;
    })();
    Utilities.List = List;
})(Utilities || (Utilities = {}));
//# sourceMappingURL=Utilities.js.map
