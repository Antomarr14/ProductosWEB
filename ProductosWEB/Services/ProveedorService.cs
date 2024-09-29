using System;
using ProductosWEB.Models;

namespace ProductosWEB.Services;

public class ProveedorService
{
    private readonly HttpClient _httpClient;

    public ProveedorService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Proveedor>> GetProveedoresAsync(){
        return await _httpClient.GetFromJsonAsync<List<Proveedor>>("api/Proveedor");
    }

    public async Task<Proveedor> GetProveedorById(int id){
        return await _httpClient.GetFromJsonAsync<Proveedor>($"api/Proveedor/{id}");
    }

    public async Task<Proveedor> CreateProveedor(Proveedor proveedor){
        var response = await _httpClient.PatchAsJsonAsync("api/Proveedor", proveedor);
        return await response.Content.ReadFromJsonAsync<Proveedor>();
    }

    public async Task UpdateProveedor(Proveedor proveedor){
        await _httpClient.PutAsJsonAsync($"api/Proveedor/{proveedor.Id}", proveedor);
    }

    public async Task DeleteProveedor(int id){
        await _httpClient.DeleteAsync($"api/Proveedor/{id}");
    }
}
