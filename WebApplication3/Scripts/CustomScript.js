﻿function w3_open() {
    document.getElementById("main").style.marginLeft = "25%";
    document.getElementById("mySidebar").style.width = "25%";
    document.getElementById("mySidebar").style.display = "block";
    document.getElementById("openNav").style.display = 'none';
}
function w3_close() {
    document.getElementById("main").style.marginLeft = "0%";
    document.getElementById("mySidebar").style.display = "none";
    document.getElementById("openNav").style.display = "inline-block";
} 

// This function allows the result to fade away
setTimeout(function myTimer() {
    var fadeTarget = document.getElementById("viewbagResult");
    var fadeEffect = setInterval(function () {
        if (!fadeTarget.style.opacity) {
            fadeTarget.style.opacity = 1;
        }
        if (fadeTarget.style.opacity > 0) {
            fadeTarget.style.opacity -= 0.1;
        } else {
            clearInterval(fadeEffect);
        }
    }, 200);
}, 1000)

// This function displays and hides search and delete boxes
function toggleBoxes(ID) {
    // Hide the viewbag result
    document.getElementById('display').style.display = "none";

    // Check if the element is already hidden
    if (document.getElementById(ID).style.display == "none") {
        // Make it visible
        document.getElementById(ID).style.display = "block";
    } else {
        // Make it hidden
        document.getElementById(ID).style.display = "none";
    }
}