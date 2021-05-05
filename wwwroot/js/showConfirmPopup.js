﻿// Get the modal
var modal = document.getElementById("myModal");

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];

// When the user clicks on <span> (x), close the modal
span.onclick = async function () {
  modal.style.display = "none";
  await fetch("/SelectItem/CloseModal");


}

// When the user clicks anywhere outside of the modal, close it
window.onclick = async function (event) {
  if (event.target == modal) {
    modal.style.display = "none";
    await fetch("/SelectItem/CloseModal");
  }
}