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


// --------- Sidebar Toggler --------- //
const sidebar = document.querySelector(".sidebar");
const sidebarToggler = document.querySelector(".sidebar-toggler");
const togglerArrow = document.querySelector(".toggler-arrow");
let togglerActive = JSON.parse(localStorage.getItem("togglerActive")) || false;

updateSidebar();

sidebarToggler.addEventListener("click", () => {
    togglerActive = !togglerActive;
    localStorage.setItem("togglerActive", JSON.stringify(togglerActive));
    updateSidebar();
});

function updateSidebar() {
    if (togglerActive) {
        togglerArrow.classList.add("turn-round");
        sidebar.classList.remove("long-sidebar");
        sidebar.classList.add("short-sidebar")
    } else {
        togglerArrow.classList.remove("turn-round");
        sidebar.classList.remove("short-sidebar");
        sidebar.classList.add("long-sidebar");
    }
}
// --------- Sidebar Toggler --------- //
