// controllers/auth.js
const bcrypt = require('bcrypt');
const jwt = require('jsonwebtoken');
const db = require('../db'); // Aquí asumo que tienes acceso a tu base de datos

const login = async (req, res) => {
    const { username, password } = req.body;

    try {
        // Buscar al usuario en la base de datos
        const [rows] = await db.execute('SELECT id, username, password FROM users WHERE username = ?', [username]);

        if (rows.length === 0) {
            return res.status(404).json({ error: 'Usuario no encontrado' });
        }

        const user = rows[0];

        // Comparar la contraseña proporcionada con la almacenada en la base de datos
        const isMatch = await bcrypt.compare(password, user.password);

        if (!isMatch) {
            return res.status(401).json({ error: 'Contraseña incorrecta' });
        }

        // Generar el JWT con el username como payload
        const token = jwt.sign({ username: user.username }, process.env.JWT_SECRET, { expiresIn: '1h' });

        // Devolver el token al cliente
        res.json({ token });
    } catch (error) {
        console.error('Error en el login:', error);
        res.status(500).json({ error: 'Error en el servidor' });
    }
};

module.exports = {
    login
};
