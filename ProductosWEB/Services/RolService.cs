using System;
using ProductosWEB.Models;

namespace ProductosWEB.Services;

public class RolService
{
    private readonly HttpClient _httpClient;
    public RolService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Rol>> GetRolesAsync(){
        return await _httpClient.GetFromJsonAsync<List<Rol>>("api/Rol");
    }

    public async Task<Rol> GetRolById(int id){
        return await _httpClient.GetFromJsonAsync<Rol>($"api/Rol/{id}");
    }

    public async Task<Rol> CreateRol(Rol rol){
        var response = await _httpClient.PatchAsJsonAsync("api/Rol", rol);
        return await response.Content.ReadFromJsonAsync<Rol>();
    }

    public async Task UpdateRol(Rol rol){
        await _httpClient.PutAsJsonAsync($"api/Rol/{rol.Id}", rol);
    }

    public async Task DeleteRol(int id){
        await _httpClient.DeleteAsync($"api/Rol/{id}");
    }
}
