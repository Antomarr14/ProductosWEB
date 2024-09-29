using System;
using ProductosWEB.Models;

namespace ProductosWEB.Services;

public class UsuarioServices
{
    private readonly HttpClient _httpClient;

    public UsuarioServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Usuario>> GetUsuariosAsync(){
        return await _httpClient.GetFromJsonAsync<List<Usuario>>("api/Usuario");
    }

    public async Task<Usuario> GetUsuarioById(int id){
        return await _httpClient.GetFromJsonAsync<Usuario>($"api/Usuario/{id}");
    }

    public async Task<Usuario> CreateUsuario(Usuario usuario){
        var response = await _httpClient.PatchAsJsonAsync("api/Usuario", usuario);
        return await response.Content.ReadFromJsonAsync<Usuario>();
    }

    public async Task UpdateUsuario(Usuario usuario){
        await _httpClient.PutAsJsonAsync($"api/Usuario/{usuario.Id}", usuario);
    }

    public async Task DeleteUsuario(int id){
        await _httpClient.DeleteAsync($"api/Usuario/{id}");
    }

}
