"use strict"

// --------- Sidebar Active State --------- //
const routeLocation = window.location.href.split("/")[3];
const sidebarLinks = document.querySelectorAll(".sidebar-navlink");

sidebarLinks.forEach((sidebarLink) => {
    sidebarLink.addEventListener("click", () => {
        localStorage.setItem("routeLocation", sidebarLink.dataset.name);
    })
})

let chosenLocation = null;

if (chosenLocation === null) {
    localStorage.setItem("routeLocation", routeLocation);
    chosenLocation = localStorage.getItem("routeLocation");
} else {
    chosenLocation = localStorage.getItem("routeLocation");
}

if (chosenLocation === routeLocation) {
    const chosenElement = document.querySelector(`[data-name="${chosenLocation}"]`)
    chosenElement.classList.add("active-navlink");
}
// --------- Sidebar Active State --------- //