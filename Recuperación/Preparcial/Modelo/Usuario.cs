namespace Preparcial.Modelo
{
    public class Usuario
    {
        public int IdUsuario { get; set; } // el id debe ser entero

        public string NombreUsuario { get; set; }

        public string Contrasena { get; set; }

        public bool Admin { get; set; }

        public Usuario(int idUsuario, string nombreUsuario, string contrasenia, bool admin)
        {
            IdUsuario = idUsuario;
            NombreUsuario = nombreUsuario;
            Contrasena = contrasenia;
            Admin = admin;
        }
    }
}
