function CarasoulAutoplay(duration) {
    const myCarouselElement = document.querySelector('#carouselExampleIndicators')

    const carousel = new bootstrap.Carousel(myCarouselElement, {
        interval: duration,
        touch: false
    })


    console.log(myCarouselElement);
    console.log(duration);
}

function updateResize() {
    var heidht = window.innerHeight;
    var width = window.innerWidth;
    console.log(heidht);
    console.log(width);

    return {
        width: heidht,
        height: width
    };
}

function GetResize() {

    window.addEventListener("resize", updateResize);
}

window.BlazorWindowSize = {
    getWindowSize: function () {
        return {
            width: window.innerWidth,
            height: window.innerHeight
        };
    }
};

