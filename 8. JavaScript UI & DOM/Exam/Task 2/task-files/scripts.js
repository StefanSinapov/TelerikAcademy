$.fn.gallery = function (width) {
    var galleryWidth = width || 4;
    var $this = $(this);
    var $fatherNode = $this;
    $this.addClass('gallery');
    $this.find('.image-container:nth-child('+ galleryWidth + 'n)').next().addClass('clearfix');

    var $selected = $this.find('.selected');
    $selected.hide();

    $this.find('.image-container').on('click', clickImageContainer);

    $selected.find('.current-image').on('click', function(){
        var $this = $(this);
        $selected.hide();
        $fatherNode.find('.gallery-list').removeClass('blurred');
        $fatherNode.find('.image-container').on('click', clickImageContainer);
    });

    $selected.find('.previous-image').on('click', function(){
        var $this = $(this);
        var dataInfo = $this.find('#previous-image').attr('data-info');
        $selected.find('#current-image').click();
        $fatherNode.find('.image-container img[data-info=\"'+dataInfo+'\"]').click();
    });

    $selected.find('.next-image').on('click', function(){
        var $this = $(this);
        var dataInfo = $this.find('#next-image').attr('data-info');
        $selected.find('#current-image').click();
        $fatherNode.find('.image-container img[data-info=\"'+dataInfo+'\"]').click();
    });



    function clickImageContainer(){
        var $this = $(this),
            dataInfo = $this.find('img').attr('data-info'),
            prevDataInfo,
            nextDataInfo;

        if($this.prev().length){
            prevDataInfo = $this.prev().find('img').attr('data-info');
        }
        else{
            prevDataInfo = $this.parent()
                .find('.image-container:last-child')
                .find('img')
                .attr('data-info');
        }
        if($this.next().length){
            nextDataInfo = $this.next().find('img').attr('data-info');
        }
        else{
            nextDataInfo = $this.parent()
                .find('.image-container:first-child')
                .find('img')
                .attr('data-info');
        }
        $selected.find('#previous-image').attr('src','images/' + prevDataInfo + '.jpg').attr('data-info',prevDataInfo);
        $selected.find('#current-image').attr('src','images/' + dataInfo + '.jpg').attr('data-info',dataInfo);
        $selected.find('#next-image').attr('src','images/' + nextDataInfo + '.jpg').attr('data-info',nextDataInfo);

        //TODO: what is disabled-background for?
//        $fatherNode.find('.gallery-list').addClass('disabled-background');
        $fatherNode.find('.gallery-list').addClass('blurred');
        $fatherNode.find('.image-container').attr('onclick','').unbind('click');
        $selected.show();
    }

    return $this;
};

















//    $this.find('.next-image').on('click', function() {
//        var $newCurrent = $fatherNode.find('.next-image');
//
//        $fatherNode.find('.previous-image').removeClass('previous-image').removeClass('selected');
//        $fatherNode.find('.current-image').removeClass('current-image').addClass('previous-image');
//        $newCurrent.removeClass('next-image').addClass('current-image');
//        if($newCurrent.next().length){
//            $newCurrent.next().addClass('next-image');
//        }
//    });