var students = [
    {
        firstName: 'Peter',
        lastName: 'Ivanov',
        grade: '3'
    },
    {
        firstName: 'Milena',
        lastName: 'Grigorova',
        grade: '6'
    },
    {
        firstName: 'Gergana',
        lastName: 'Borisova',
        grade: '12'
    },
    {
        firstName: 'Boyko',
        lastName: 'Petrov',
        grade: '7'
    }
];

window.onload = function() {
    $('#generate-button').first().on('click', function() {
        generateTable(students);
    })
};

function generateTable(students){
    var $table = $('<table/>');
    $table.attr('border', "1px solid black");
    $table.css('border-collapse','collapse');
    var $tHead = generateTHead(students[0]);
    var $tBody = $('<tbody/>');

    for (var i = 0; i < students.length; i+=1) {
        var $row = generateRow(students[i]);
        $tBody.append($row);
    }

    $table.append($tHead);
    $table.append($tBody);
    $('#wrapper').append($table);
}

function generateTHead()
{
    var $thead = $('<thead/>');
    var $row = $('<tr/>');
    $row.append($('<th/>').append('First name'));
    $row.append($('<th/>').append('Last name'));
    $row.append($('<th/>').append('Grade'));
    $thead.append($row);
    return $thead;
}

function generateRow(student){
    var $row = $('<tr/>');
    $row.append($('<td/>').append(student.firstName));
    $row.append($('<td/>').append(student.lastName));
    $row.append($('<td/>').append(student.grade));
    return $row;
}