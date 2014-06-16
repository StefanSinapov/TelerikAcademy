(function($){
    $.fn.dropdown = function(){
        var $this = $(this);
        $this.hide();
        var $listContainer = $('<div/>').addClass("dropdown-list-container");
        appendList($listContainer);

        function appendList($listContainer){
            var $ul = $('<ul/>')
                .addClass('dropdown-list-options')
                .css('list-style-type','none');
            var $options = $this.find('option');
            for(var i = 0; i < $options.length; i+=1){
                var text = $($options[i]).text();
                var value = $($options[i]).val();
                var $li = $('<li/>').addClass('dropdown-list-option');
                $li.attr('data-value',value);
                $li.text(text);
                $li.css('width', '100px').css('border', '1px solid black');
                $ul.append($li);
            }
            $listContainer.append($ul);
        }

        $listContainer.on('click', 'li.dropdown-list-option', function(){
//           $this.find(.attr('selected','selected');
            var selectedValue = $(this).attr('data-value');
            var selector = 'option[value = \"' + selectedValue + '\"]';
            var selectedOption = $this.find(selector);

            if(selectedOption.attr('selected')){
                selectedOption.removeAttr('selected', 'selected');

                $(this).css('background-color', '');
                $('#selected-item').text('Unselected: ' + selectedOption.html()).fadeOut(1000);
            }
            else {
                selectedOption.attr('selected','selected');
                $(this).css('background-color', 'red');
                $('#selected-item').text('Selected: ' + selectedOption.html()).fadeIn();
            }
        });
        var $arrow = $('<img />')
            .attr('src' ,'images/dropdown-arrow.png')
            .attr('id','#dropdown-arrow' )
            .css('width', '50px')
            .css('height', '50px');
        $this.before($arrow);
        $this.after($listContainer);
        $listContainer.hide();

        $arrow.on('click', function(){
            $listContainer.slideToggle();
        })
    }
}(jQuery));
