define(function() {
  'use strict';
  var Section;
  Section = (function() {
        function Section(title) {
	        this._title = title;
            this._items = [];
        }

      Section.prototype = {
          add: function(item){
              this._items.push(item);
              return this;
          },
          getData: function(){
              var item, items, i, len;

              items = [];
              for(i = 0, len=this._items.length; i<len; i+=1){
                  item = this._items[i];
                  items.push(item);
              }

              return {
                  title: this._title,
                  items: items
              }
          }
      };

	    return Section;
  }());
  return Section;
});