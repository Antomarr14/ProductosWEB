using System;
using ProductosWEB.Models;

namespace ProductosWEB.Services;

public class UsuarioRolService
{
    private readonly HttpClient _httpClient;

    public UsuarioRolService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<UsuarioRol>> GetUsuarioRolAsync(){
        return await _httpClient.GetFromJsonAsync<List<UsuarioRol>>("api/UsuarioRol");
    }

    public async Task<UsuarioRol> GetUsuarioRolById(int id){
        return await _httpClient.GetFromJsonAsync<UsuarioRol>($"api/UsuarioRol/{id}");
    }

    public async Task<UsuarioRol> CreateUsuarioRol(UsuarioRol usuarioRol){
        var response = await _httpClient.PatchAsJsonAsync("api/UsuarioRol", usuarioRol);
        return await response.Content.ReadFromJsonAsync<UsuarioRol>();
    }

    public async Task UpdateUsuarioRol(UsuarioRol usuarioRol){
        await _httpClient.PutAsJsonAsync($"api/UsuarioRol/{usuarioRol.Id}", usuarioRol);
    }

    public async Task DeleteUsuarioRol(int id){
        await _httpClient.DeleteAsync($"api/UsuarioRol/{id}");
    }
}
