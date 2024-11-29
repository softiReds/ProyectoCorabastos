const API_BASE_URL = "https://corabastosapi.azurewebsites.net/api";
const API_BASE_URL_LOCAL = "https://localhost:7124/api";

// Arreglo global para manejar los productos en el carrito
let carrito = [];
let carritosDisponibles = [];
let carritoSeleccionado = null; // Guardará el carrito actualmente seleccionado

// Función para obtener carritos desde la API
async function obtenerCarritos() {
    console.log("Obteniendo de: " + `${API_BASE_URL}/carritocompras`);
    try {
        const response = await fetch(`${API_BASE_URL}/carritocompras`, {
            method: 'GET',
            headers: { 'Content-Type': 'application/json' },
        });

        if (!response.ok) {
            throw new Error(`Error al obtener carritos: ${response.statusText}`);
        }

        return await response.json();
    } catch (error) {
        console.error('Error al conectar con la API para obtener carritos:', error);
        return [];
    }
}

// Función para listar y seleccionar un carrito
async function mostrarCarritos() {
    carritosDisponibles = await obtenerCarritos();
    const carritoContainer = document.getElementById('carritoSelector');
    
    if (!carritoContainer) {
        console.error('No se encontró el contenedor de selección de carritos.');
        return;
    }

    // Limpiar contenido actual
    carritoContainer.innerHTML = '';

    // Mostrar los carritos disponibles
    carritosDisponibles.forEach(carrito => {
        const carritoHTML = `
            <div class="carrito-card">
                <h3>${carrito.cliente.usuarioNombre} ${carrito.cliente.usuarioApellido}</h3>
                <p>ID del carrito: ${carrito.carritoComprasId}</p>
                <button onclick="seleccionarCarrito('${carrito.carritoComprasId}', '${carrito.clienteId}')">Seleccionar</button>
            </div>
        `;
        carritoContainer.innerHTML += carritoHTML;
    });
}

// Función para seleccionar un carrito
function seleccionarCarrito(carritoId, clienteId) {
    carritoSeleccionado = {
        carritoComprasId: carritoId,
        clienteId: clienteId,
    };

    alert(`Carrito de ${carritoSeleccionado.clienteId} seleccionado con éxito.`);
}

// Función para obtener productos desde la API
async function obtenerProductos() {
    try {
        const response = await fetch(`${API_BASE_URL}/producto`, {
            method: 'GET',
            headers: { 'Content-Type': 'application/json' },
        });

        if (!response.ok) {
            throw new Error(`Error al obtener productos: ${response.statusText}`);
        }

        return await response.json();
    } catch (error) {
        console.error('Error al conectar con la API para obtener productos:', error);
        return [];
    }
}

// Función para mostrar los productos
async function mostrarProductos() {
    const productos = await obtenerProductos();

    const contenedorFrutas = document.getElementById('frutas');
    if (!contenedorFrutas) {
        console.error('No se encontró el contenedor de frutas.');
        return;
    }

    // Limpiar contenido actual
    contenedorFrutas.innerHTML = '';

    // Insertar productos dinámicamente
    productos.forEach(producto => {
        const productoHTML = `
            <div class="product-card">
                <img src="https://via.placeholder.com/150" alt="${producto.productoNombre}">
                <h3>${producto.productoNombre}</h3>
                <p>$${producto.productoPrecio.toLocaleString('es-CO')}</p>
                <button onclick="addToCart('${producto.productoNombre}', ${producto.productoPrecio}, '${producto.productoId}')">Agregar</button>
            </div>
        `;
        contenedorFrutas.innerHTML += productoHTML;
    });
}

// Función para agregar un producto al carrito
async function addToCart(nombre, precio, productoId) {
    await obtenerCarrito(); 
    if (!carritoSeleccionado) {
        alert('Por favor, selecciona un carrito antes de agregar productos.');
        return;
    }

    const confirmacion = confirm(`¿Deseas agregar "${nombre}" al carrito por $${precio.toLocaleString('es-CO')}?`);

    const total = parseInt(document.getElementById('cartTotal').textContent.replace(/\D/g, ''));

    console.log("Total: " + total);

    if (confirmacion) {
        const carritoComprasRequest = {
            CarritoCompras: {
                CarritoComprasId: carritoSeleccionado.carritoComprasId,
                ClienteId: carritoSeleccionado.clienteId,
                CarritoComprasTotal: total // El backend calculará el total
            },
            CarritoComprasProducto: {
                CarritoComprasId: carritoSeleccionado.carritoComprasId,
                ProductoId: productoId,
                Cantidad: 1
            }
        };

        const resultado = await enviarProductoACarrito(carritoComprasRequest);

        if (resultado.success) {
            await obtenerCarrito(); // Actualizar el carrito desde la API
            alert("Producto agregado al carrito con éxito.");
        } else {
            alert("No se pudo agregar el producto al carrito. Intenta nuevamente.");
        }
    }
}

// Función para enviar un PUT al backend para agregar un producto al carrito
async function enviarProductoACarrito(payload) {
    try {
        const response = await fetch(`${API_BASE_URL}/carritocompras/true`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(payload),
        });

        if (!response.ok) {
            throw new Error(`Error al agregar producto: ${response.statusText}`);
        }

        return { success: true };
    } catch (error) {
        console.error("Error al enviar producto al carrito:", error);
        return { success: false, error };
    }
}

// Función para mostrar y ocultar el carrito, obteniendo los datos desde la API
async function toggleCart() {
    const cartModal = document.getElementById('cartModal');
    if (!cartModal) {
        console.error('No se encontró el modal del carrito.');
        return;
    }

    if (!cartModal.classList.contains('active')) {
        // Obtener los elementos del carrito antes de abrir el modal
        await obtenerCarrito();
    }

    cartModal.classList.toggle('active');
}

// Función para obtener y actualizar el carrito visualmente
async function obtenerCarrito() {
    if (!carritoSeleccionado) {
        alert('Por favor, selecciona un carrito primero.');
        return;
    }

    try {
        const response = await fetch(`${API_BASE_URL}/carritocompras/${carritoSeleccionado.carritoComprasId}`, {
            method: 'GET',
            headers: { 'Content-Type': 'application/json' },
        });

        if (!response.ok) {
            throw new Error(`Error al obtener el carrito: ${response.statusText}`);
        }

        const carrito = await response.json();
        actualizarCarritoDesdeAPI(carrito);
    } catch (error) {
        console.error('Error al conectar con la API para obtener el carrito:', error);
    }
}

// Función para eliminar un producto del carrito
async function eliminarDelCarrito(productoId) {
    await obtenerCarrito();
    if (!carritoSeleccionado) {
        alert('Por favor, selecciona un carrito primero.');
        return;
    }

    const confirmacion = confirm('¿Estás seguro de que deseas eliminar este producto del carrito?');
    if (!confirmacion) return;

    const total = parseInt(document.getElementById('cartTotal').textContent.replace(/\D/g, ''));

    console.log("Total: " + total);

    const carritoComprasRequest = {
        CarritoCompras: {
            CarritoComprasId: carritoSeleccionado.carritoComprasId,
            ClienteId: carritoSeleccionado.clienteId,
            CarritoComprasTotal: total // Este total se ajustará en el backend
        },
        CarritoComprasProducto: {
            CarritoComprasId: carritoSeleccionado.carritoComprasId,
            ProductoId: productoId,
            Cantidad: 1 // Se resta una unidad
        }
    };

    try {
        const response = await fetch(`${API_BASE_URL}/carritocompras/false`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(carritoComprasRequest),
        });

        if (!response.ok) {
            throw new Error(`Error al eliminar producto del carrito: ${response.statusText}`);
        }

        await obtenerCarrito(); // Actualizar el carrito después de eliminar el producto
        alert('Producto eliminado del carrito con éxito.');
    } catch (error) {
        console.error('Error al conectar con la API para eliminar el producto:', error);
    }
}

// Mostrar productos y carritos disponibles al cargar la página
document.addEventListener('DOMContentLoaded', () => {
    mostrarCarritos();
    mostrarProductos();
});

// Función para actualizar el carrito visualmente con datos de la API
function actualizarCarritoDesdeAPI(carrito) {
    const cartItems = document.getElementById('cartItems');
    const cartTotal = document.getElementById('cartTotal');

    if (!cartItems || !cartTotal) {
        console.error('Elementos del carrito no encontrados en el DOM.');
        return;
    }

    // Limpiar contenido actual
    cartItems.innerHTML = '';

    let total = 0;

    // Verificar si hay productos en el carrito
    if (!carrito.carritoComprasProductos || carrito.carritoComprasProductos.length === 0) {
        cartItems.innerHTML = '<p>El carrito está vacío.</p>';
        cartTotal.textContent = '0';
        return;
    }

    // Renderizar cada producto del carrito
    carrito.carritoComprasProductos.forEach(item => {
        const producto = item.producto || {}; // Manejar si producto es null o undefined
        const nombre = producto.productoNombre || 'Producto desconocido';
        const precio = producto.productoPrecio || 0;
        const cantidad = item.cantidad || 1;

        // Sumar al total
        total += precio * cantidad;

        // Renderizar producto
        const productoHTML = `
            <div>
                ${nombre} - $${precio.toLocaleString('es-CO')} x ${cantidad}
                <button onclick="eliminarDelCarrito('${producto.productoId}')">Eliminar</button>
            </div>
        `;
        cartItems.innerHTML += productoHTML;
    });

    // Actualizar total del carrito
    cartTotal.textContent = total.toLocaleString('es-CO');
}

// Función para cerrar el carrito
function closeCart() {
    const cartModal = document.getElementById('cartModal');
    if (!cartModal) {
        console.error('No se encontró el modal del carrito.');
        return;
    }
    cartModal.classList.remove('active');
}
