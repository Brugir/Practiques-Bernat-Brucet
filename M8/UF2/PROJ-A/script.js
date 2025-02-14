document.addEventListener('DOMContentLoaded', function () {
    const ccaaSelect = document.getElementById('ccaa');
    const provinciaSelect = document.getElementById('provincia');
    const poblacionSelect = document.getElementById('poblacion');
    const imageContainer = document.getElementById('image-container');
    const submit = document.getElementById('submit');

    // Obtener comunidades autónomas
    async function getComunidadesAutonomas() {
        const response = await fetch('https://raw.githubusercontent.com/frontid/ComunidadesProvinciasPoblaciones/refs/heads/master/ccaa.json');
        const data = await response.json();
        data.forEach(comunidad => {
            let options = document.createElement('option');
            options.value = comunidad.code;
            options.textContent = comunidad.label;
            ccaaSelect.appendChild(options);
        });
    }

    getComunidadesAutonomas();

    // Obtener provincias
    async function getProvincias() {
        const response = await fetch('https://raw.githubusercontent.com/frontid/ComunidadesProvinciasPoblaciones/refs/heads/master/provincias.json');
        const data = await response.json();
        provinciaSelect.innerHTML = "";
        let options = document.createElement('option');
        options.text = "Selecciona una Provincia";
        provinciaSelect.appendChild(options);
        data.forEach(provincia => {
            if (provincia.parent_code == ccaaSelect.value) {
                let options = document.createElement('option');
                options.value = provincia.code;
                options.textContent = provincia.label;
                provinciaSelect.appendChild(options);
            }
        });
    }

    ccaaSelect.addEventListener('change', function () {
        getProvincias();
    });

    // Obtener poblaciones
    async function getPoblaciones() {
        const response = await fetch('https://raw.githubusercontent.com/frontid/ComunidadesProvinciasPoblaciones/refs/heads/master/poblaciones.json');
        const data = await response.json();
        poblacionSelect.innerHTML = "";
        let options = document.createElement('option');
        options.text = "Selecciona una Población";
        poblacionSelect.appendChild(options);
        data.forEach(poblacion => {
            if (poblacion.parent_code == provinciaSelect.value) {
                let options = document.createElement('option');
                options.value = poblacion.code;
                options.textContent = poblacion.label;
                poblacionSelect.appendChild(options);
            }
        });
    }

    provinciaSelect.addEventListener('change', function () {
        getPoblaciones();
    });

    // Función para obtener imágenes de Wikimedia
    submit.addEventListener('click', function (event) {
        event.preventDefault();
        const poblacion = poblacionSelect.options[poblacionSelect.selectedIndex].text;
        
        if (poblacion) {
            const imageUrl = `https://commons.wikimedia.org/w/api.php?action=query&format=json&origin=*&generator=images&titles=${encodeURIComponent(poblacion)}&gimlimit=10&prop=imageinfo&iiprop=url`;

            // Llamada a la API de Wikimedia
            fetch(imageUrl)
                .then(response => response.json())
                .then(data => {
                    console.log("Imágenes de Wikimedia:", data);
                    
                    imageContainer.innerHTML = ''; // Limpiar imágenes previas
                    if (data.query && data.query.pages) {
                        Object.values(data.query.pages).forEach(page => {
                            if (page.imageinfo && page.imageinfo[0] && page.imageinfo[0].url) {
                                const imgUrl = page.imageinfo[0].url;
                                const imgBox = document.createElement('div');
                                imgBox.className = 'image-box';
                                const img = document.createElement('img');
                                img.src = imgUrl;
                                imgBox.appendChild(img);
                                imageContainer.appendChild(imgBox);
                            }
                        });
                    } else {
                        imageContainer.innerHTML = '<p>No se encontraron imágenes para esta población.</p>';
                    }
                })
                .catch(error => {
                    console.error('Error cargando imágenes:', error);
                    imageContainer.innerHTML = '<p>Ocurrió un error al cargar las imágenes.</p>';
                });
        } else {
            alert('Por favor, selecciona una población.');
        }
    });
});
