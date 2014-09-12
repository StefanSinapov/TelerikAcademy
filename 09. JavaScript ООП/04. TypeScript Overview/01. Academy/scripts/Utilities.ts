///<reference path='Interfaces.ts'/>

module Utilities {
    export class List<T> implements Interfaces.IList{
        private _collection: T[];

        constructor(){
            this._collection = [];
        }

        add(item: T) {
            this._collection.push(item);
        }

        remove(item: T) {
            var index = this._collection.indexOf(item);
            if(index > -1)
            {
                this._collection.splice(index, 1);
            }
        }

        get count(): number {
            return this._collection.length;
        }
    }
}