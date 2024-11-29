document.addEventListener('DOMContentLoaded', () => {
    const botonCategorias = document.getElementById('botonCategorias');
    if (botonCategorias) {
        botonCategorias.addEventListener('click', () => {
            window.location.href = '/html/categorias.html';
        });
    }
}); 

// Arreglo para almacenar productos del carrito
let cart = [];

// Función para cambiar de categoría
function showCategory(category) {
    // Ocultar todas las categorías
    document.querySelectorAll('.product-list').forEach(cat => cat.classList.remove('active'));
    // Mostrar la categoría seleccionada
    document.getElementById(category).classList.add('active');
    
    // Cambiar el estado del botón activo
    document.querySelectorAll('.categories-nav button').forEach(button => button.classList.remove('active'));
    document.querySelector(`button[onclick="showCategory('${category}')"]`).classList.add('active');
}

// Función para agregar productos al carrito
function addToCart(productName, price) {
    // Agregar el producto al carrito
    cart.push({ productName, price });
    updateCart(); // Actualizar la vista del carrito
}

// Función para actualizar el carrito visualmente
function updateCart() {
    const cartItemsContainer = document.getElementById('cartItems');
    const cartTotalElement = document.getElementById('cartTotal');
    let total = 0;

    cartItemsContainer.innerHTML = ''; // Limpiar el carrito

    // Mostrar los productos del carrito
    cart.forEach((item, index) => {
        total += item.price;
        const cartItem = document.createElement('div');
        cartItem.classList.add('cart-item');
        cartItem.innerHTML = `
            <span>${item.productName}</span>
            <span>$${item.price}</span>
            <button onclick="removeFromCart(${index})">Eliminar</button>
        `;
        cartItemsContainer.appendChild(cartItem);
    });

    // Actualizar el total
    cartTotalElement.textContent = total;
}

// Función para eliminar productos del carrito
function removeFromCart(index) {
    // Eliminar el producto del carrito
    cart.splice(index, 1);
    updateCart(); // Actualizar la vista del carrito
}

// Función para mostrar y ocultar el carrito
function toggleCart() {
    document.getElementById('cartModal').classList.toggle('active');
}


// Función para cerrar el carrito
function closeCart() {
    document.getElementById('cartModal').classList.remove('active');
}

