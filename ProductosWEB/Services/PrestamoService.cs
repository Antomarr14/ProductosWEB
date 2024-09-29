using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ProductosWEB.Models;

namespace ProductosWEB.Services
{
    public class PrestamoService
    {
        private readonly HttpClient _httpClient;

        public PrestamoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Prestamo>> GetAllPrestamosAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Prestamo>>("api/Prestamo");
        }

        public async Task<Prestamo> GetPrestamoByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Prestamo>($"api/Prestamo/{id}");
        }

        public async Task<Prestamo> CreatePrestamoAsync(Prestamo prestamo)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Prestamo", prestamo);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Prestamo>();
            }
            throw new Exception("Error al crear el préstamo.");
        }

        public async Task UpdatePrestamoAsync(Prestamo prestamo)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Prestamo/{prestamo.Id}", prestamo);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error al actualizar el préstamo.");
            }
        }

        public async Task<bool> MarkPrestamoAsReturnedAsync(int id)
        {
            var prestamo = await GetPrestamoByIdAsync(id);
            if (prestamo == null || prestamo.estado == "Devuelto")
            {
                return false;
            }

            prestamo.estado = "Devuelto";
            prestamo.fecha_devolucion = DateTime.UtcNow;

            var response = await _httpClient.PutAsJsonAsync($"api/Prestamo/{prestamo.Id}/mark-returned", prestamo);
            return response.IsSuccessStatusCode;
        }
    }
}