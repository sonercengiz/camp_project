function startTime() {
    let today = new Date();
    document.getElementsByClassName('clock')[0].innerHTML = today.getHours() + ":" + checkTime(today.getMinutes()) + ":" + checkTime(today.getSeconds()) + " - " + checkTime(today.getDate()) + "/" + checkTime(today.getMonth() + 1) + "/" + today.getFullYear()%1000;
    setTimeout(startTime, 1000);
}

function checkTime(i) {
    if (i < 10) { i = "0" + i };  // add zero in front of numbers < 10
    return i;
}

function navigateToHomePage() {
    window.location.href = "/";
}

function NavigateToCity() {
    let il = document.getElementById("iller").value;
    window.location.href = "/campground/index?il=" + il;
}