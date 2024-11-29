// Datos simulados de la base de datos
let inventory = [
    { name: "Manzana[Dato de BD]", price: 3000, stock: 50, initialStock: 50 },
    { name: "Carne de Res[Dato de BD]", price: 15000, stock: 20, initialStock: 20 },
    { name: "Huevos[Dato de BD]", price: 2000, stock: 100, initialStock: 100 },
    { name: "Leche[Dato de BD]", price: 5000, stock: 40, initialStock: 40 },
    { name: "Tomate[Dato de BD]", price: 1500, stock: 70, initialStock: 70 }
];

// Función para renderizar la tabla
function renderInventory() {
    const table = document.getElementById('inventoryTable');
    table.innerHTML = '';

    inventory.forEach((product, index) => {
        const progress = (product.stock / product.initialStock) * 100;
        table.innerHTML += `
            <tr>
                <td>${product.name}</td>
                <td>$${product.price}</td>
                <td>${product.stock}</td>
                <td>
                    <div class="progress-bar">
                        <div class="progress" style="width: ${progress}%;"></div>
                    </div>
                </td>
                <td>
                    <div class="action-buttons">
                        <button onclick="updateStock(${index}, 1)">+</button>
                        <button onclick="updateStock(${index}, -1)">-</button>
                        <button onclick="editPrice(${index})">Cambiar Precio</button>
                        <button class="delete" onclick="deleteProduct(${index})">Eliminar</button>
                    </div>
                </td>
            </tr>
        `;
    });
}

// Funciones para actualizar, editar y agregar productos (sin cambios en este fragmento)
function updateStock(index, change) {
    inventory[index].stock += change;
    if (inventory[index].stock < 0) {
        inventory[index].stock = 0;
    }
    renderInventory();
}

function editPrice(index) {
    const newPrice = prompt("Ingrese el nuevo precio:");
    if (newPrice && !isNaN(newPrice) && newPrice > 0) {
        inventory[index].price = parseInt(newPrice);
        renderInventory();
    } else {
        alert("Precio inválido.");
    }
}

function deleteProduct(index) {
    inventory.splice(index, 1);
    renderInventory();
}

function addProduct() {
    const name = document.getElementById('newProductName').value.trim();
    const price = parseInt(document.getElementById('newProductPrice').value);
    const stock = parseInt(document.getElementById('newProductStock').value);

    if (name && price > 0 && stock > 0) {
        inventory.push({ name, price, stock, initialStock: stock });
        document.getElementById('newProductName').value = '';
        document.getElementById('newProductPrice').value = '';
        document.getElementById('newProductStock').value = '';
        renderInventory();
    } else {
        alert("Por favor, Complete todos los campos correctamente.");
    }
}

// Render inicial
renderInventory();