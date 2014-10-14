$(document).ready(function() {

    var pager = $('#currentPage');
    var currentPage = pager.val();
    $('#prevPageBtn').on('click', function() {
        if(currentPage>=2)
        {
            currentPage--;
            pager.val(currentPage);
        }
    });
    $('#nextPageBtn').on('click', function() {
        currentPage++;
        pager.val(currentPage);
    });

});