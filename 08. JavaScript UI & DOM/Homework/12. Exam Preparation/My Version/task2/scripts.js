$.fn.tabs = function () {
    var $this = $(this);
    $this.addClass('tabs-container');

    var $items = $this.find('.tab-item');
    $items.find(".tab-item-content").hide();


    if($this.find('.current').length){
        $this.find('.current').find('.tab-item-content').show();
    }
    else{
        $items.first().addClass('current').find('.tab-item-content').show() ;
    }

    $items.on('click', '.tab-item-title', function(){
        var $clickedItem = $($(this).parent());
        $this.find('.current').removeClass('current');
        $items.find(".tab-item-content").hide();
        $clickedItem.addClass('current')
            .find('.tab-item-content').show();
    });
    return $this;
};