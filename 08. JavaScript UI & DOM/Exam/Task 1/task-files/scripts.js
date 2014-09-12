function createImagesPreviewer(selector, items) {
    var galleryContainer = document.querySelector(selector);
    var displayContainer = document.createElement('div');
    var displayTitle = document.createElement('strong');
    var displayImage = document.createElement('img');
    var listContainer = displayContainer.cloneNode();
    var fragment = document.createDocumentFragment();

    var filterBox = document.createElement('input');
    var filterBoxLabel = document.createElement('label');


    displayTitle.textContent = items[0].title;
    displayImage.src = items[0].url;


    applyDisplayContainerContentStyles(displayTitle, displayImage);
    applyDisplayContainerStyles(displayContainer);
    applyFilterBoxStyles(filterBox, filterBoxLabel);
    applyListContainerStyles(listContainer);

    displayContainer.appendChild(displayTitle);
    displayContainer.appendChild(displayImage);

    filterBox.addEventListener('keyup', function(){
        var value = this.value;
        var allImages = listContainer.childNodes;
        for(var i = 2; i < allImages.length; i+=1) {
            if (allImages[i].textContent.contains(value)) {
//                console.log("images: " + i + " stay")
                allImages[i].style.display = '';
            }
            else{
                allImages[i].style.display = 'none';
            }
        }
    });

    listContainer.appendChild(filterBoxLabel);
    listContainer.appendChild(filterBox);
    appendImagesToList(listContainer, displayContainer, items);


    fragment.appendChild(displayContainer);
    fragment.appendChild(listContainer);
    galleryContainer.appendChild(fragment);
}

String.prototype.contains = function(it) {
    return (this.toLowerCase()).indexOf(it) != -1;
};

function appendImagesToList(listContainer, displayContainer, items){
    var image = document.createElement('img'),
        imageContainer = document.createElement('div'),
        titleContainer = document.createElement('strong'),
        fragment = document.createDocumentFragment(),
        i;

    imageContainer.className += ' image-container';
    imageContainer.style.margin = '2px 10px';

    titleContainer.style.display = 'block';
    titleContainer.style.textAlign = 'center';

    image.style.width = '150px';
    image.style.paddingLeft = '5px';
    image.style.borderRadius = '15px';


    for (i = 0; i < items.length; i+=1) {
        titleContainer.textContent = items[i].title;
        image.src = items[i].url;
        imageContainer.appendChild(titleContainer);
        imageContainer.appendChild(image);


        fragment.appendChild(imageContainer.cloneNode(true));
    }
    //cloneNode doesn't clone the event listener :(
    var imgContainers = fragment.childNodes;
    for(i = 0; i < imgContainers.length; i+=1){

        imgContainers[i].addEventListener( 'click' , function(){
            clickImageFromList(displayContainer, this);
            var previouslyClicked = this.parentNode.querySelector('.image-container[clicked="clicked"]');
            if(previouslyClicked)
            {
                previouslyClicked.setAttribute('clicked', '');
                previouslyClicked.style.backgroundColor = 'white';
            }
            this.setAttribute('clicked','clicked');
            this.style.backgroundColor = 'gray';
        });

        imgContainers[i].addEventListener( 'mouseover' , function(){
            if(this.getAttribute('clicked')!== 'clicked') {
                this.style.backgroundColor = 'lightgray';
            }
        });

        imgContainers[i].addEventListener( 'mouseout' , function(){
            if(this.getAttribute('clicked')!== 'clicked'){
                this.style.backgroundColor = 'white';
            }

        });
    }


    listContainer.appendChild(fragment);
}

function clickImageFromList(displayContainer, imageContainer){

    var title = imageContainer.childNodes[0].textContent;
    var imageSrc = imageContainer.childNodes[1].getAttribute("src");

    displayContainer.childNodes[0].textContent = title;
    displayContainer.childNodes[1].setAttribute('src', imageSrc);

}

function applyFilterBoxStyles(filterBox, filterBoxLabel)
{
    filterBox.setAttribute("type", "text");
    filterBox.setAttribute("id", "filter-input");
    filterBox.style.display = 'block';
    filterBox.style.marginLeft = '10px';
    filterBox.style.width = '160px';
    filterBoxLabel.setAttribute('for', 'filter-input');
    filterBoxLabel.textContent = 'Filter';
    filterBoxLabel.style.display = 'block';
    filterBoxLabel.style.textAlign = 'center';
}
function applyDisplayContainerStyles(displayContainer)
{
    displayContainer.setAttribute('id', 'display-container');
    displayContainer.style.width = '400px';
    displayContainer.style.height = '450px';
    displayContainer.style.position = 'absolute';
    displayContainer.style.top = '10px';
    displayContainer.style.left = '30px';
    displayContainer.style.display = 'inline-block';
}
function applyDisplayContainerContentStyles(displayTitle, displayImage){
    displayTitle.style.display = 'block';
    displayTitle.style.textAlign = 'center';
    displayTitle.style.fontSize = '30px';
    displayTitle.style.marginTop = '15px';
    displayImage.style.width = '350px';
    displayImage.style.borderRadius = '15px';
    displayImage.style.display = 'block';
    displayImage.style.marginLeft = 'auto';
    displayImage.style.marginRight = 'auto';
    displayImage.style.marginTop = '5px';
    displayImage.setAttribute('id', 'display-image');
}

function applyListContainerStyles(listContainer){
    listContainer.style.width = '200px';
    listContainer.style.height = '400px';
    listContainer.style.position = 'absolute';
    listContainer.style.top = '10px';
    listContainer.style.left = '440px';
    listContainer.style.display = 'inline-block';
    listContainer.style.overflow = 'auto';
    listContainer.className += ' list-container';
}