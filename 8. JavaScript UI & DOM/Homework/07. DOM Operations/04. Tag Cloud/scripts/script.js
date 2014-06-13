window.onload = function(){
    var tags = ["http", "cms", "ASP.NET MVC", "js", "javascript", ".net", ".net", "web", "html", "xaml", "ASP.NET", "css", "wordpress", "js", "http", "asp.net", "asp.net MVC", "ASP.NET MVC", "wp", "cms", "html", "wp", "javascript", "http", ".NET Framework", ".net", "Java", "java", "java"];

    var minFontSize = 18;
    var maxFontSize = 42;
    generateTagCloud(tags, minFontSize, maxFontSize);
};

function generateTagCloud(tags, minFontSize, maxFontSize) {
    var tagDictionary = extractTags(tags);
    var tagContainer = createContainer();
    appendTagCloudContainer(tagContainer);
    pushTagsInContainer(tagContainer, tagDictionary, minFontSize, maxFontSize);
}

function extractTags(collection) {
    var tagDictionary = [];

    for (var i = 0; i < collection.length; i++) {
        var currentTag = collection[i].toLowerCase();

        tagDictionary[currentTag] = tagDictionary[currentTag] || 0;
        tagDictionary[currentTag]++;
    }

    return tagDictionary;
}

function appendTagCloudContainer(tagContainer) {

    document.getElementById('wrapper').appendChild(tagContainer);
}

function createContainer() {
    var div = document.createElement('div');
    div.id = 'tag-cloud-container';
    return div;
}

function pushTagsInContainer(tagContainer, tags, minFontSize, maxFontSize) {
    var minOccurs = Array.min(tags);
    var maxOccurs = Array.max(tags);
    var length = maxOccurs - minOccurs;
    var step = (maxFontSize - minFontSize) / length;
    var div = document.createElement('div');

    for (var tagName in tags) {
        div.style.position = 'absolute';
        div.style.top = getRandomInt(0, 150) + 'px';
        div.style.left = getRandomInt(0, 300) + 'px';
        div.style.color = getRandomColor();
        div.style.fontSize = ((tags[tagName] - 1) * step + minFontSize) + 'px';
        div.innerHTML = tagName;

        tagContainer.appendChild(div.cloneNode(true));
    }
}

function getRandomColor(){
//    return (Math.random()*0xFFFFFF<0).toString(16);
    return '#' + Math.random().toString(16).substr(-6);
}

function getRandomInt(min, max) {
    min = parseInt(min);
    max = parseInt(max);

    if (!isNumber(min)) {
        return 0;
    }

    if (!isNumber(max)) {
        max = min;
        min = 0;
    }

    if (min > max) {
        return 0;
    }

    return Math.floor(Math.random() * (max - min + 1)) + min;
}

function isNumber(n) {
    return !isNaN(parseFloat(n)) && isFinite(n);
}

Array.min = function(collection) {
    return Math.min.apply(null, Object.keys(collection).map(function(e) {
        return collection[e];
    }));
};

Array.max = function(collection) {
    return Math.max.apply(null, Object.keys(collection).map(function(e) {
        return collection[e];
    }));
};