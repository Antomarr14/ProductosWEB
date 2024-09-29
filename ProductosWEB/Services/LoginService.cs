using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ProductosWEB.Models;

namespace ProductosWEB.Services
{
    public class LoginService
    {
        private readonly HttpClient _httpClient;

        public LoginService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Obtener todos los inicios de sesión
        public async Task<List<Login>> GetLoginsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Login>>("api/Login");
        }

        // Obtener un inicio de sesión por ID
        public async Task<Login> GetLoginById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Login>($"api/Login/{id}");
        }

        // Crear un nuevo inicio de sesión
        public async Task<Login> CreateLogin(Login login)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Login", login);
            return await response.Content.ReadFromJsonAsync<Login>();
        }

        // Actualizar un inicio de sesión existente
        public async Task UpdateLogin(Login login)
        {
            await _httpClient.PutAsJsonAsync($"api/Login/{login.Id}", login);
        }

        // Eliminar un inicio de sesión por ID
        public async Task DeleteLogin(int id)
        {
            await _httpClient.DeleteAsync($"api/Login/{id}");
        }
    }
}