window.onload = () => {
    // Si ya hay un JWT almacenado, cargamos los libros protegidos
    if (localStorage.getItem('jwt')) {
        showBookTable();
    }

    // Añadimos el listener para el login
    document.querySelector('#login-form').addEventListener('submit', login);

    // Añadimos al botón de submit del formulario un listener para enlazarlo a la función createBook
    document.querySelector('#createButton').addEventListener('click', createBook);

    document.querySelector('#downloadButton').addEventListener('click', downloadVideo);
}

async function login(event) {
    event.preventDefault(); // Evitar la recarga de página

    const username = document.querySelector('#username').value;
    const password = document.querySelector('#password').value;

    // Realizar la petición POST para obtener el JWT
    const response = await fetch('http://localhost:5000/login', {  // Cambia la URL al endpoint correcto de tu backend
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ username, password })
    });

    const data = await response.json();

    if (data.token) {
        // Si el login es exitoso, almacenamos el token en el localStorage
        localStorage.setItem('jwt', data.token);
        document.querySelector('#login-message').textContent = '¡Login exitoso!';
        showBookTable(); // Mostrar la tabla de libros
    } else {
        // Si hay un error en el login, mostramos el mensaje
        document.querySelector('#login-message').textContent = `Error: ${data.error || 'Credenciales incorrectas'}`;
    }
}

function showBookTable() {
    // Mostrar la tabla de libros y el formulario de añadir libro
    document.querySelector('#login-form-container').style.display = 'none';
    document.querySelector('#book-table-container').style.display = 'table';
    document.querySelector('#book-form').style.display = 'block';
    document.querySelector('#downloadButton').style.display = 'inline-block';

    fetchBooks();
}

async function fetchBooks() {
    let apiUrl = "http://localhost:5000/api/books";
    const token = localStorage.getItem('jwt');

    // Asegurarnos de que el token esté presente en las cabeceras de la solicitud
    let res = await fetch(apiUrl, {
        headers: {
            'Authorization': `Bearer ${token}`
        }
    });
    
    let books = await res.json();
    eraseTable();
    updateTable(books);
}

function eraseTable() {
    let filas = Array.from(document.querySelectorAll('tbody tr'));
    for (let fila of filas) {
        fila.remove();
    }
}

function updateTable(books) {
    let table = document.getElementById("book-table");

    for (let book of books) {
        let row = document.createElement('tr');
        table.append(row);
        let celdaId = document.createElement('td');
        celdaId.innerHTML = book.id;
        row.append(celdaId);
        let celdaTitulo = document.createElement('td');
        celdaTitulo.innerHTML = book.title;
        celdaTitulo.contentEditable = true;
        row.append(celdaTitulo);
        let celdaAutor = document.createElement('td');
        celdaAutor.innerHTML = book.author;
        celdaAutor.contentEditable = true;
        row.append(celdaAutor);
        let celdaAno = document.createElement('td');
        celdaAno.innerHTML = book.year;
        celdaAno.contentEditable = true;
        row.append(celdaAno);
        let celdaAcciones = document.createElement('td');
        row.append(celdaAcciones);
        let buttonEdit = document.createElement('button');
        buttonEdit.innerHTML = "Modificar";
        buttonEdit.addEventListener('click', editBook);
        celdaAcciones.append(buttonEdit);
        let buttonDelete = document.createElement('button');
        buttonDelete.innerHTML = "Eliminar";
        buttonDelete.addEventListener('click', deleteBook);
        celdaAcciones.append(buttonDelete);
    }
}

async function deleteBook(event) {
    let celdas = event.target.parentElement.parentElement.children;
    let id = celdas[0].innerHTML;

    let apiUrl = "http://localhost:5000/api/books";
    let deletedBook = {
        "id": id
    }

    const token = localStorage.getItem('jwt');

    let response = await fetch(apiUrl, {
        method: "DELETE",
        headers: {
            "Content-Type": "application/json",
            "Authorization": `Bearer ${token}`
        },
        body: JSON.stringify(deletedBook)
    });

    let json = await response.json();
    console.log(json);
    fetchBooks();
}

async function editBook(event) {
    let celdas = event.target.parentElement.parentElement.children;
    let id = celdas[0].innerHTML;
    let titulo = celdas[1].innerHTML;
    let autor = celdas[2].innerHTML;
    let ano = celdas[3].innerHTML;

    let apiUrl = "http://localhost:5000/api/books"
    let modifiedBook = {
        "id": id,
        "title": titulo,
        "author": autor,
        "year": ano
    }

    const token = localStorage.getItem('jwt');

    let response = await fetch(apiUrl, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
            "Authorization": `Bearer ${token}`
        },
        body: JSON.stringify(modifiedBook)
    });

    let json = await response.json();
    console.log(json);
    fetchBooks();
}

async function createBook(event) {
    event.preventDefault(); 
    let titulo = document.querySelector("#book-title").value.trim();
    let autor = document.querySelector("#book-author").value.trim();
    let ano = document.querySelector("#book-year").value.trim();

    if (!titulo || !autor || !ano) {
        alert("Por favor, completa todos los campos.");
        return;
    }

    if (isNaN(ano) || ano < 0) {
        alert("El año debe ser un número válido.");
        return;
    }

    let apiUrl = "http://localhost:5000/api/books";
    let newBook = { title: titulo, author: autor, year: parseInt(ano) };
    const token = localStorage.getItem('jwt');

    try {
        let response = await fetch(apiUrl, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${token}`
            },
            body: JSON.stringify(newBook)
        });

        let json = await response.json();
        fetchBooks();
        document.querySelector("#book-title").value = "";
        document.querySelector("#book-author").value = "";
        document.querySelector("#book-year").value = "";
    } catch (error) {
        console.error("Error al crear el libro:", error.message);
        alert("Hubo un problema al crear el libro.");
    }
}

function downloadVideo() {
    console.log('Downloading video...');
    let xhr = new XMLHttpRequest();

    xhr.open('GET', './vid.mp4');
    xhr.responseType = 'blob';
    xhr.send();

    xhr.onload = function () {
        if (xhr.status != 200) {
            console.log(`Error ${xhr.status}: ${xhr.statusText}`);
        } else {
            console.log(`Done downloading video!`);
            const blob = new Blob([xhr.response], { type: 'video/mp4' });
            const url = URL.createObjectURL(blob);

            const a = document.createElement('a');
            a.href = url;
            a.download = 'downloaded_video.mp4';
            document.body.appendChild(a);
            a.click();
            document.body.removeChild(a);
        }
    };

    xhr.onprogress = function (event) {
        if (event.lengthComputable) {
            console.log(`Received ${event.loaded} of ${event.total} bytes`);
        } else {
            console.log(`Received ${event.loaded} bytes`);
        }
    };

    xhr.onerror = function () {
        console.log("Request failed");
    };
}
