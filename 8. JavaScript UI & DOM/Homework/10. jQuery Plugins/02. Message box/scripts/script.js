(function($){
    $.fn.messageBox = function(){
        $this = this;
        $this.hide();
        $this.css('width','100px')
            .css('height', '50px')
            .css('border', '1px solid black');
        $this.success = function (message){
            $this.text(message)
                .css('background-color', 'yellowgreen')
                .css('text-align', 'center')
                .css('margin',' auto auto');
            showMessage();
        };
        $this.error = function (message) {
            $this.text(message)
                .css('background-color', 'red')
                .css('text-align', 'center')
                .css('margin',' auto auto');
            showMessage();
        };

        function showMessage(){
            $this.fadeIn(1500, "linear");
            setTimeout(function() {
                $this.fadeOut(1500, 'linear')
            }, 3000);
        }

        return $this;
    }
}(jQuery));

