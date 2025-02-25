
//console.log("menuSidebar.js yüklendi!");
//var toggle = document.querySelector(".toggle");
//var menuIcon = document.querySelector(".menu");
//var closeIcon = document.querySelector(".close");

//menuIcon.addEventListener("click", function () {
//    toggle.style.display = "block";

//    console.log("Menü butonuna tıklandı!");

//});

//closeIcon.addEventListener("click", function () {
//    toggle.style.display = "none";

//    console.log("Menü butonuna tıklandı!");

//});

//const sidebarLinks = document.querySelectorAll(".sidebar a");
//var themeBtn = document.querySelector(".mode");

//document.addEventListener("DOMContentLoaded", () => {


//    sidebarLinks.forEach((link) => {
//        link.addEventListener("click", () => {
//            document.querySelector(".sidebar .activee")?.classList.remove("activee");
//            link.classList.add("activee");
//        });
//    });




//    themeBtn.addEventListener("click", function () {
//        document.body.classList.toggle("dark-theme-variables");

//        themeBtn.querySelector('span:nth-child(1)').classList.toggle("activee");
//        themeBtn.querySelector('span:nth-child(2)').classList.toggle("activee");
//    });
//});

console.log("menuSidebar.js yüklendi!");

document.addEventListener("DOMContentLoaded", () => {
    const toggle = document.querySelector(".toggle");
    const menuIcon = document.querySelector(".menu");
    const closeIcon = document.querySelector(".close");

    const sidebarLinks = document.querySelectorAll(".sidebar a:not(.logout)");

    const themeBtn = document.querySelector(".mode");
    const lightModeIcon = themeBtn.querySelector("span:nth-child(1)");
    const darkModeIcon = themeBtn.querySelector("span:nth-child(2)");
   
    // Menü Aç/Kapa Butonları
    if (menuIcon && closeIcon && toggle) {
        menuIcon.addEventListener("click", function () {
            toggle.style.display = "block";
            console.log("Menü açıldı!");
        });

        closeIcon.addEventListener("click", function () {
            toggle.style.display = "none";
            console.log("Menü kapatıldı!");
        });
    }

    // Aktif sidebar buton
    let currentPath = window.location.pathname;
    sidebarLinks.forEach((link) => {
        if (link.getAttribute("href") === currentPath) {
            link.classList.add("activee");
        }
    });

    // Tema Butonu
    const currentTheme = localStorage.getItem("theme");

    // Eğer önceki tema 'dark' ise koyu temaya geç
    if (currentTheme === "dark") {
        document.body.classList.add("dark-theme-variables");
        lightModeIcon.classList.remove("activee");
        darkModeIcon.classList.add("activee");
    } else {
        // Varsayılan olarak açık tema (light mode)
        document.body.classList.remove("dark-theme-variables");
        lightModeIcon.classList.add("activee");
        darkModeIcon.classList.remove("activee");
    }

    // Tema butonuna tıklandığında tema değiştir
    themeBtn.addEventListener("click", () => {
        // Eğer karanlık temadaysak, ışık temasına geç
        if (document.body.classList.contains("dark-theme-variables")) {
            document.body.classList.remove("dark-theme-variables");
            localStorage.setItem("theme", "light"); // Temayı light olarak kaydet
            lightModeIcon.classList.add("activee");
            darkModeIcon.classList.remove("activee");
        } else {
            // Eğer açık temadaysak, karanlık temaya geç
            document.body.classList.add("dark-theme-variables");
            localStorage.setItem("theme", "dark"); // Temayı dark olarak kaydet
            lightModeIcon.classList.remove("activee");
            darkModeIcon.classList.add("activee");
        }
    });

});






//const activePage = localStorage.getItem("activePage");
//if (!activePage) {
//    const homeLink = document.querySelector('.sidebar a[href="/Home"]');
//    if (homeLink) {
//        homeLink.classList.add("activee");
//    }
//} else {
//    sidebarLinks.forEach((link) => {
//        if (link.href === activePage) {
//            link.classList.add("activee");
//        }
//    });
//}
//// Sidebar'da Tıklanan Linki Aktif Yap
//sidebarLinks.forEach((link) => {
//    link.addEventListener("click", () => {
//        sidebarLinks.forEach((li) => {
//            li.classList.remove('activee');
//        });
//        link.classList.add("activee");
//        localStorage.setItem("activePage", link.href);
//    });
//});