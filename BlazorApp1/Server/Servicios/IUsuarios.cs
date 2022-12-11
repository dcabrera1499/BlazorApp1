using BlazorApp1.Shared;

namespace BlazorApp1.Server.Servicios
{
    public interface IUsuarios
    {
        public List<Usuario> DatosUsuarios(); //traer info de usuarios en db

        public void NuevoUsuario(Usuario u); //crear un nuevo usuario 

        public void ActualizarUsuario(Usuario u); //actualizar un usuario

        public Usuario DatosUsuario(int id); //traer info de un usuario

        public void BorrarUsuario(int id); //eliminar a un usuario 

        //esta clase es la que se encarga de interconectar con la db

    }
}
