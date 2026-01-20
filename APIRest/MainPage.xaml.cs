using APIRest.Model;
using APIRest.Services;

namespace APIRest;

public partial class MainPage : ContentPage
{
    private readonly APIServices _api = new APIServices();

    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnConsultarTodos(object sender, EventArgs e)
    {
        Cargando.IsRunning = true;
        Cargando.IsVisible = true;

        var lista = await _api.GetTodosAsync();

        Cargando.IsRunning = false;
        Cargando.IsVisible = false;

        ListaUsuarios.ItemsSource = lista;
    }

    private async void OnBuscarPorId(object sender, EventArgs e)
    {
        string id = BuscarIdEntry.Text;
        var usuario = await _api.GetPorIdAsync(id);

        if (usuario != null)
        {
            ListaUsuarios.ItemsSource = new List<Usuarios> { usuario };
        }
        else
        {
            await DisplayAlert("Error", "Usuario no encontrado", "Cerrar");
        }
    }

    private async void OnCrear(object sender, EventArgs e)
    {
        Usuarios nuevo = new Usuarios();
        nuevo.Nombre = CrearNombreEntry.Text;
        nuevo.Apellidos = CrearApellidosEntry.Text;
        nuevo.EMail = CrearEmailEntry.Text;
        nuevo.Edad = Convert.ToInt32(CrearEdadEntry.Text);

        bool ok = await _api.CrearAsync(nuevo);

        if (ok)
        {
            await DisplayAlert("OK", "Usuario creado", "Cerrar");
            OnConsultarTodos(sender, e);
        }
        else
        {
            await DisplayAlert("Error", "No se pudo crear", "Cerrar");
        }
    }

    private async void OnActualizar(object sender, EventArgs e)
    {
        Usuarios actualizado = new Usuarios();
        actualizado.Id = ActualizarIdEntry.Text;
        actualizado.Nombre = ActualizarNombreEntry.Text;
        actualizado.Apellidos = ActualizarApellidosEntry.Text;
        actualizado.EMail = ActualizarEmailEntry.Text;
        actualizado.Edad = Convert.ToInt32(ActualizarEdadEntry.Text);

        bool ok = await _api.ActualizarAsync(actualizado);

        if (ok)
        {
            await DisplayAlert("OK", "Usuario actualizado", "Cerrar");
            OnConsultarTodos(sender, e);
        }
        else
        {
            await DisplayAlert("Error", "No se pudo actualizar", "Cerrar");
        }
    }

    private async void OnEliminar(object sender, EventArgs e)
    {
        string id = EliminarIdEntry.Text;

        bool ok = await _api.EliminarAsync(id);

        if (ok)
        {
            await DisplayAlert("OK", "Usuario eliminado", "Cerrar");
            OnConsultarTodos(sender, e);
        }
        else
        {
            await DisplayAlert("Error", "No se pudo eliminar", "Cerrar");
        }
    }
}
