var Calculator = (function () {

    var privateMember = 5;

    return {
        publicMember: function () {
            return privateMember;
        },
        change: function (newNumber) {
            privateMember = newNumber;
        }
    }
})