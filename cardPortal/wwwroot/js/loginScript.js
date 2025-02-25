
document.getElementById("eye-btn").addEventListener("click", function () {
	var passwordInput = document.getElementById("passwordInput");
	var icon = this.querySelector("span");

	if (passwordInput.type === "password") {
		passwordInput.type = "text";
		icon.textContent = "visibility";
	} else {
		passwordInput.type = "password";
		icon.textContent = "visibility_off";
	}
});