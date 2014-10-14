$(document).ready(function() {
    $('#add-file').on('click', function() {
        var inputs = $('#upload-form > input[type="file"]').length;

        var label = $('<label />');
        label.attr('for', 'file' + inputs);
        label.text('File');

        var inputFile = $('<input />');
        inputFile.attr('type', 'file');
        inputFile.attr('name', 'file_' + inputs);
        inputFile.attr('id', 'file' + inputs);

        var inputPrivate = $('<input />');
        inputPrivate.attr('type', 'checkbox');
        inputPrivate.attr('name', 'file_' + inputs + 'private');

        var br = $('<br />');

        $('#upload-form').prepend(br).prepend(br).prepend(inputPrivate).prepend(inputFile).prepend(label);
    })
});