define(function() {
  'use strict';
  var Container;
  Container = (function() {
      function Container() {
            this._sections = [];
      }

      Container.prototype = {
            add: function(item){
                this._sections.push(item);
                return this;
            },
            getData: function(){
                var i, section, dataSections = [], len;

                for (i = 0, len = this._sections.length; i < len ; i++) {
                    section = this._sections[i];
                    dataSections.push(section);
                }

                return dataSections;
            }
      };
      return Container;
  }());
  return Container;
});