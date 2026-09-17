using System;
using System.Collections.Generic;
using System.Text;
using DeliveryApp.Models;

namespace DeliveryApp.Services;

public class MockDeliveryService
{
    // Método para obtener las categorías principales
    public List<Categoria> ObtenerCategorias()
    {
        return new List<Categoria>
        {
            new Categoria { Id = 1, Nombre = "Todos", Icono = "🍽️", EsSeleccionada = true },
            new Categoria { Id = 2, Nombre = "Hamburguesas", Icono = "🍔" },
            new Categoria { Id = 3, Nombre = "Pizzas", Icono = "🍕" },
            new Categoria { Id = 4, Nombre = "Bebidas", Icono = "🥤" },
            new Categoria { Id = 5, Nombre = "Postres", Icono = "🍦" }
        };
    }

    // Método para obtener el catálogo de platillos del restaurante
    public List<Plato> ObtenerPlatos()
    {
        return new List<Plato>
        {
            new Plato
            {
                Id = 101,
                Nombre = "Super Burger Doble Carne",
                Descripcion = "Doble carne artesanal de res 150g, queso cheddar fundido, tocineta crocante y salsa especial de la casa.",
                Precio = 24900m,
                ImagenUrl = "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?w=500",
                Categoria = "Hamburguesas",
                Calificacion = 4.9,
                TiempoPreparacionMinutos = 18
            },
            new Plato
            {
                Id = 102,
                Nombre = "Pizza Pepperoni Suprema",
                Descripcion = "Masa madre crujiente, abundante queso mozzarella importado y doble porción de pepperoni premium.",
                Precio = 32000m,
                ImagenUrl = "https://images.unsplash.com/photo-1628840042765-356cda07504e?w=500",
                Categoria = "Pizzas",
                Calificacion = 4.8,
                TiempoPreparacionMinutos = 25
            },
            new Plato
            {
                Id = 103,
                Nombre = "Milkshake Chocolate Artesanal",
                Descripcion = "Malteada cremosa de helado de chocolate belga, crema batida y chispas de chocolate oscuro.",
                Precio = 12500m,
                ImagenUrl = "https://images.unsplash.com/photo-1572490122747-3968b75cc699?w=500",
                Categoria = "Bebidas",
                Calificacion = 4.7,
                TiempoPreparacionMinutos = 10
            },
            new Plato
            {
                Id = 104,
                Nombre = "Waffle Supremo con Frutos Rojos",
                Descripcion = "Waffle dorado recién horneado acompañado de fresas frescas, arándanos, helado de vainilla y miel.",
                Precio = 16800m,
                ImagenUrl = "https://images.unsplash.com/photo-1562376552-0d160a2f238d?w=500",
                Categoria = "Postres",
                Calificacion = 4.9,
                TiempoPreparacionMinutos = 15
            }
        };
    }
}