using APIRest.Model;
using System.Net.Http.Json;

namespace APIRest.Services
{
    public class APIServices
    {
        private readonly HttpClient _cliente = new HttpClient();
        private const string UrlApi = "https://696fa39da06046ce61876ae7.mockapi.io/DAM/API/Usuarios";

        public async Task<List<Usuarios>> GetTodosAsync()
        {
            try
            {
                var lista = await _cliente.GetFromJsonAsync<List<Usuarios>>(UrlApi);
                return lista ?? new List<Usuarios>();
            }
            catch
            {
                return new List<Usuarios>();
            }
        }

        public async Task<Usuarios?> GetPorIdAsync(string id)
        {
            try
            {
                return await _cliente.GetFromJsonAsync<Usuarios>($"{UrlApi}/{id}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> CrearAsync(Usuarios nuevo)
        {
            try
            {
                var respuesta = await _cliente.PostAsJsonAsync(UrlApi, nuevo);
                return respuesta.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> ActualizarAsync(Usuarios actualizado)
        {
            try
            {
                var respuesta = await _cliente.PutAsJsonAsync($"{UrlApi}/{actualizado.Id}", actualizado);
                return respuesta.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> EliminarAsync(string id)
        {
            try
            {
                var respuesta = await _cliente.DeleteAsync($"{UrlApi}/{id}");
                return respuesta.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}
