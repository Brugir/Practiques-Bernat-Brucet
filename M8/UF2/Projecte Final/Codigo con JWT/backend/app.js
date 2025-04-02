// app.js
const express = require('express')
const cors = require('cors')
const routes = require('./routes/routes.js')
const authRoutes = require('./routes/auth'); // Importar las rutas de autenticación

// Instanciación del servidor
const app = express()

// Configurar middleware
app.use(cors());          // para evitar CORS
app.use(express.json());  // para parsear contenido JSON

// Configurar las rutas
app.use('/', routes);        // Enrutamiento de las peticiones de libros
app.use('/auth', authRoutes); // Enrutamiento de las peticiones de autenticación

// Arranque del servidor
app.listen(5000, () => {
    console.log('server is listening on port 5000')
})
