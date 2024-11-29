document.getElementById('botonUsuario').addEventListener('click', () => {
    window.location.href = '/html/loginUser.html';});

function toggleDarkMode() {
// Alternar la clase dark-mode en el body y el contenedor de login
    document.body.classList.toggle('dark-mode');
    document.querySelector('.login-container').classList.toggle('dark-mode');
}