/**
 * Created by Stefan on 13.6.2014 г..
 */

window.onload = function () {
    document.getElementById('delete-checked-button').addEventListener('click', deleteChecked);
    document.getElementById('delete-all-button').addEventListener('click', deleteAll);
    document.getElementById('hide-checked-button').addEventListener('click', hideChecked);
    document.getElementById('show-checked-button').addEventListener('click', showChecked);
};

function showChecked() {
    var div = document.getElementById("list").children;

    for (var i = 0; i < div.length; i++) {
        if (div[i].firstElementChild instanceof HTMLInputElement) {
            if (div[i].firstElementChild.checked) {
                div[i].className = "hyde";
//                console.log(div[i].tagName);
                div[i].firstElementChild.checked = false;
            }
        }
    }

    for (var i = 0; i < div.length; i++) {
        if (div[i].className === "hyde") {
            div[i].style.display = "";
            div[i].className = "";
        }
    }
}

function hideChecked() {
    var div = document.getElementById("list").children;

    for (var i = 0; i < div.length; i++) {
        if (div[i].firstElementChild instanceof HTMLInputElement) {
            if (div[i].firstElementChild.checked) {
                div[i].className = "hyde";
//                console.log(div[i].tagName);
            }
        }
    }

    for (var i = 0; i < div.length; i++) {
        if (div[i].className === "hyde") {
            div[i].style.display = "none";

        }
    }
}

function deleteChecked() {
    var div = document.getElementById("list").children;

    for (var i = 0; i < div.length; i++) {
        if (div[i].firstElementChild instanceof HTMLInputElement) {
            if (div[i].firstElementChild.checked) {
                div[i].className = "forDeleting";
            }
        }
    }

    for (var i = 0; i < div.length; i++) {
        if (div[i].className === "forDeleting") {

            div[i].parentNode.removeChild(div[i]);

        }
    }
}

function deleteAll() {
    var div = document.getElementById("list");
    while (div.firstChild) {
        div.removeChild(div.firstChild);
    }
}

function addItem(event) {
    var div = document.getElementById("list");
    var input = document.getElementById("input");
    var inputValue = input.value;

    input.style.border = "";
    input.placeholder = "Enter TO DO Item";
    input.placeholder = "Enter TO DO Item";



    if (inputValue !== "") {
        div.innerHTML += "<div><input type='checkbox' id='checkbox-1'/><label for='add if you want to work'>" +
            inputValue + "</label></div>";
    }
    else {
        input.style.border = "1px solid red";
        input.placeholder = "Please fill out this field";
    }

    input.value = "";
}
