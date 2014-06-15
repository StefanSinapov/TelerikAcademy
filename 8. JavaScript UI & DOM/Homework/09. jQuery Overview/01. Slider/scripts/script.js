var slides = [
        {
            title: "JavaScript DOM & UI",
            imgSrc: 'http://media.letscodejavascript.com/video/lessons_learned/ll10.jpg',
            content: '<ul><li>Practical exam – 45%</li>'+
                    '<li>Exam evaluation – 10%</li>' +
                    '<li>7-8 exam peer reviews</li>' +
                    '<li>Homework – 10%</li>' +
                    '<li>Homework evaluation – 5%</li>' +
                    '<li>3 peer reviews per homework</li>' +
                    '<li>Teamwork – 20%</li>' +
                    '<li>Attendance in class – 10%</li>' +
                    '<li>Forum - 5%</li></ul>',
            footer: 'homework due date: 05.06.2014'

        },
        {
            title: "Document Object Model",
            imgSrc: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSitUJvw4QUimUuTUKISNIw66RmzjW9FByLTJ5Pdptr3MrI1JBVceRZeCM',
            content: 'The Document Object Model (DOM) is a cross-platform and language-independent convention for representing and interacting with objects in HTML, XHTML and XML documents.[1] Objects in the DOM tree may be addressed and manipulated by using methods on the objects. The public interface of a DOM is specified in its application programming interface (API). The history of the Document Object Model is intertwined with the history of the "browser wars" of the late 1990s between Netscape Navigator and Microsoft Internet Explorer, as well as with that of JavaScript and JScript, the first scripting languages to be widely implemented in the layout engines of web browsers.',
            footer: 'homework due date: 05.06.2014'
        },
        {
            title: "jQuery",
            imgSrc: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSitUJvw4QUimUuTUKISNIw66RmzjW9FByLTJ5Pdptr3MrI1JBVceRZeCM',
            content: 'jQuery is a fast, small, and feature-rich JavaScript library. It makes things like HTML document traversal and manipulation, event handling, animation, and Ajax much simpler with an easy-to-use API that works across a multitude of browsers. With a combination of versatility and extensibility, jQuery has changed the way that millions of people write JavaScript.' ,
            footer: 'homework due date: 15.06.2014'
        }
    ],
    containerWidth = 500,
    containerHeight = 500;

function createSlides(slides)
{
    var $container = createSlideContainer();
    appendSlides($container, slides);
    addControls($container);


    return $container;
}

function moveNextSlide(){
    var $current = $('.current');
    if($current.next().length){
        $current.removeClass('current').next().addClass('current');
    }
}

function movePreviousSlide(){
    var $current = $('.current');
    if($current.prev().length){
        $current.removeClass('current').prev().addClass('current');
    }
}

function addControls($container){
    var $nextButton = $('<button/>')
            .attr('id', 'next-button')
            .addClass('button')
            .html('next')
            .on('click', moveNextSlide),
        $previousButton = $('<button/>')
            .attr('id', 'previous-button')
            .addClass('button')
            .html('previous')
            .on('click', movePreviousSlide);

    $container.append($nextButton, $previousButton);
}

function appendSlides($container, slides){
    var $slides = $('<div/>');
    for (var i = 0; i < slides.length; i++) {
        var $slide = $('<div />');
        if(i===0){
            $slide.addClass('current');
        }
        $slide.addClass(slides[i].id || 'slide');

        if(slides[i].title){
            var title = $('<h1/>')
                .addClass('slide-title')
                .html(slides[i].title);
            $slide.append(title);
        }
        if(slides[i].imgSrc){
            var img = $('<img/>');
            img.addClass('slide-image');
            img.attr('src',slides[i].imgSrc);
            $slide.append(img);
        }
        if(slides[i].content) {
            var content = $('<div/>');
            content.addClass('slide-content');
            content.html(slides[i].content);
            $slide.append(content);
        }
        if(slides[i].footer) {
            var footer = $('<h3/>')
                .addClass('slide-footer')
                .html(slides[i].footer);
            $slide.append(footer);
        }

        $slides.append($slide.clone());
    }
    $container.append($slides)
}

function createSlideContainer()
{
    var $container = $('<div />');
    $container.attr('id', 'slider-container');
    return $container;
}

window.onload = function() {
    var $slidesContainer = createSlides(slides);

//    $slidesContainer.appendTo('#wrapper');
    $('#wrapper').append($slidesContainer);
    setInterval(moveNextSlide, 10000);
};