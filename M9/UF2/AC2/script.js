function changeAudio(audioFile, audioDetails) {
    var audioPlayer = document.getElementById('audioPlayer');
    var audioSource = document.getElementById('audioSource');
    audioSource.src = audioFile;
    audioPlayer.load(); // Cargar el nuevo archivo de audio

    // Esperar a que los metadatos se hayan cargado antes de actualizar la duración
    audioPlayer.onloadedmetadata = function() {
        // Obtener la duración en segundos y convertirla en formato minutos:segundos
        var duration = audioPlayer.duration;
        var minutes = Math.floor(duration / 60);
        var seconds = Math.floor(duration % 60);
        var durationFormatted = minutes + ":" + (seconds < 10 ? "0" + seconds : seconds);

        // Actualizar la información del archivo de audio
        var details = document.getElementById('audioDetails');
        details.innerHTML = `
            <p><strong>Detalles del archivo:</strong></p>
            <ul>
                <li>Formato: ${audioDetails}</li>
                <li>Duración: ${durationFormatted}</li>
            </ul>
        `;
    };
}
