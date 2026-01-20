namespace APIRest.Model
{
    public class Usuarios
    {
        public string Id { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string EMail { get; set; } = string.Empty;
        public int Edad { get; set; }
    }
}
