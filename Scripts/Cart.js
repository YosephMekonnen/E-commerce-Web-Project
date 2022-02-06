const CartDropDown = document.getElementById('cart');
const dropContainer = document.getElementById('drop-container');
const close = document.getElementById('close');

CartDropDown.addEventListener('click',()=>{

    dropContainer.style.display = "block";

})
close.addEventListener('click', () => {

    dropContainer.style.display = "none";

});