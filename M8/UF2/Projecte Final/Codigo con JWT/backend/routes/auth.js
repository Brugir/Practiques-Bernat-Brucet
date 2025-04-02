// routes/auth.js
const express = require('express');
const router = express.Router();
const authController = require('../controllers/auth');

// Ruta de login para autenticar usuarios y generar un JWT
router.post('/login', authController.login);

module.exports = router;
