using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ProductosWEB.Models;

namespace ProductosWEB.Services
{
    public class ArticuloService
    {
        private readonly HttpClient _httpClient;

        public ArticuloService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Obtener todos los artículos
        public async Task<List<Articulo>> GetArticulosAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Articulo>>("api/Articulo");
        }

        // Obtener un artículo por ID
        public async Task<Articulo> GetArticuloById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Articulo>($"api/Articulo/{id}");
        }

        // Crear un nuevo artículo
        public async Task<Articulo> CreateArticulo(Articulo articulo)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Articulo", articulo);
            return await response.Content.ReadFromJsonAsync<Articulo>();
        }

        // Actualizar un artículo existente
        public async Task UpdateArticulo(Articulo articulo)
        {
            await _httpClient.PutAsJsonAsync($"api/Articulo/{articulo.Id}", articulo);
        }

        // Eliminar un artículo por ID
        public async Task DeleteArticulo(int id)
        {
            await _httpClient.DeleteAsync($"api/Articulo/{id}");
        }
    }
}