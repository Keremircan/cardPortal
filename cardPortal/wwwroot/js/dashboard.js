

var perCircle = document.getElementById("perCircle");
var comCircle = document.getElementById("comCircle");
var admCircle = document.getElementById("admCircle");

var personnelText = document.getElementById("personnelText");
var companyText = document.getElementById("companyText");
var adminText = document.getElementById("adminText");

var defaultPersonnelText = personnelText.innerText;
var defaultCompanyText = companyText.innerText;
var defaultAdminText = adminText.innerText;

var personnelCount = personnelText.getAttribute("data-count");
var companyCount = companyText.getAttribute("data-count");
var adminCount = adminText.getAttribute("data-count");


perCircle.addEventListener("mouseover", function () {
    perCircle.style.transform = "rotateX(360deg)";
    personnelText.innerText = personnelCount;
});
perCircle.addEventListener("mouseout", function () {
    perCircle.style.transform = "rotateX(0deg)";
    personnelText.innerText = defaultPersonnelText;
});

comCircle.addEventListener("mouseover", function () {
    comCircle.style.transform = "rotateX(360deg)";
    companyText.innerText = companyCount;
});
comCircle.addEventListener("mouseout", function () {
    comCircle.style.transform = "rotateX(0deg)";
    companyText.innerText = defaultCompanyText;
});

admCircle.addEventListener("mouseover", function () {
    admCircle.style.transform = "rotateX(360deg)";
    adminText.innerText = adminCount;
});
admCircle.addEventListener("mouseout", function () {
    admCircle.style.transform = "rotateX(0deg)";
    adminText.innerText = defaultAdminText;
});