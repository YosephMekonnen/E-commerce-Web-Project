
const menu = document.getElementById("ham");
const collapse = document.getElementById("collapse");

function openNav() {
    document.getElementById("mySidenav").style.width = "250px";
}

/* Set the width of the side navigation to 0 */
function closeNav() {
    document.getElementById("mySidenav").style.width = "0";
}
var slideIndex = 1;
showSlides(slideIndex);

// Next/previous controls
function plusSlides(n) {
    showSlides((slideIndex += n));
}

// Thumbnail image controls
function currentSlide(n) {
    showSlides((slideIndex = n));
}

function showSlides(n) {
    var i;
    var slides = document.getElementsByClassName("mySlides");
    var dots = document.getElementsByClassName("dot");
    if (n > slides.length) {
        slideIndex = 1;
    }
    if (n < 1) {
        slideIndex = slides.length;
    }
    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    for (i = 0; i < dots.length; i++) {
        dots[i].className = dots[i].className.replace(" active", "");
    }
    slides[slideIndex - 1].style.display = "block";
    dots[slideIndex - 1].className += " active";
}
  /*var slideIndex = 0;
  howSlides();

 function showSlides() {
   var i;
   var slides = document.getElementsByClassName("mySlides");
   for (i = 0; i < slides.length; i++) {
     slides[i].style.display = "none";
   }
   slideIndex++;
   if (slideIndex > slides.length) {
     slideIndex = 1;
   }
   slides[slideIndex - 1].style.display = "block";
   setTimeout(showSlides, 3000); // Change image every 8 seconds 
 }*/
/*var cardDrop = document.getElementById('card-dropdown');
var activeDropdown;

/*
cardDrop.addEventListener('click', function () {
    var node;
    for (var i = 0; i < this.childNodes.length - 1; i++)
        node = this.childNodes[i];
    if (node.className === 'dropdown-select') {
        node.classList.add('visible');
        activeDropdown = node;
    };
})

    (function () {

        $("#cart").on("click", function () {
            $(".shopping-cart").fadeToggle("fast");
        });

    })();*/