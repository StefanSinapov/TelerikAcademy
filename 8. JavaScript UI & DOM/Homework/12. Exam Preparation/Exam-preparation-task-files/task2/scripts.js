$.fn.tabs = function () {
    var $this = $(this),
        $parentNode = $this;
    $this.addClass("tabs-container");

    $this.find('.tab-item-content').hide();
    $this.find('.tab-item-title')
        .on('click', function(ev){
            var $this = $(this);
            $parentNode.find('.current').removeClass('current');
            $parentNode.find('.tab-item-content').hide();
            $this.parent()
                .addClass('current')
                .find('.tab-item-content')
                .show();
            //.css('display', '');
        });

    $this.find('.current .tab-item-title').click();


    /*$this.on('mouseover', function() {
        //zoom in element
    });
    $this.on('mouseout', function() {
        //zoom out element
    });*/

    return $this;
};