document.getElementById("menu").addEventListener("click", function () {
    var sidebar = document.getElementById("sidebar");
    var menuIcon = document.getElementById("menu");

    if (sidebar.style.display === "none" || sidebar.style.display === "") {
        sidebar.style.display = "block"; // Sidebar'ı aç
        menuIcon.style.display = "none"; // Menü ikonunu gizle
    } else {
        sidebar.style.display = "none"; // Sidebar'ı kapat
        menuIcon.style.display = "block"; // Menü ikonunu geri getir
    }

});