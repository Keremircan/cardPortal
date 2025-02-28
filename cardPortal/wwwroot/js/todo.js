function deleteTodo(checkbox) {
    if (checkbox.checked) {
        let todoId = checkbox.value;
        let response = await fetch(`/Home/Delete/${todoId}`, {
            method: "DELETE"
        });

        if (response.ok) {
            checkbox.parentElement.remove(); // Task'i listeden kaldır
        } else {
            alert("Delete operation failed!");
            checkbox.checked = false; // Başarısız olursa tekrar eski hale getir
        }
    }
}