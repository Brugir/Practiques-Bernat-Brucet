const express = require('express');
const router = express.Router();
const jwtAuth = require('../middlewares/jwtAuth'); // Importar el middleware de JWT
const booksController = require('../controllers/books'); // Importar los controladores

// Rutas públicas (por ejemplo, obtener todos los libros no requiere autenticación)
router.get('/api/books', booksController.getBooks);

// Rutas protegidas (requieren autenticación JWT)
router.post('/api/books', jwtAuth, booksController.createBook);   // Crear libro
router.put('/api/books', jwtAuth, booksController.updateBook);     // Modificar libro
router.delete('/api/books', jwtAuth, booksController.deleteBook);  // Eliminar libro

module.exports = router;
