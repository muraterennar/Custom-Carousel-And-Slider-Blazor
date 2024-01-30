function CarasoulAutoplay(duration) {
    const myCarouselElement = document.querySelector('#carouselExampleIndicators')

    const carousel = new bootstrap.Carousel(myCarouselElement, {
        interval: duration,
        touch: false
    })


    console.log(myCarouselElement);
    console.log(duration);
}

function clickButton() {
    const btn = document.querySelector('#btn');

    console.log(btn);
}