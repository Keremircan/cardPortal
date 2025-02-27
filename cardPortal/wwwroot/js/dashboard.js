
fetch('/Home/GetPersonnelCount')
    .then(response => response.json())
    .then(data => {
        console.log("Personnel Count:", data.count);
    })
    .catch(error => console.error('Error:', error));