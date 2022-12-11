using BlazorApp1.Server.Modelos;
using BlazorApp1.Shared;

namespace BlazorApp1.Server.Servicios
{
    public class GestionUsuarios : IUsuarios
    {
        readonly EjempDbContext dbContext = new();

        public GestionUsuarios(EjempDbContext db)
        {
           dbContext = db;
        }

        public void ActualizarUsuario(Usuario u)
        {
            try
            {
                dbContext.Entry(u).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void BorrarUsuario(int id)
        {
            try
            {
                Usuario? u = dbContext.Usuario.Find(id);
                if (u != null)
                {
                    dbContext.Usuario.Remove(u);
                    dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public Usuario DatosUsuario(int id)
        {
            try
            {
                Usuario? u = dbContext.Usuario.Find(id);
                if(u != null)
                {
                    return u;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<Usuario> DatosUsuarios()
        {
            try
            {
                return dbContext.Usuario.ToList(); 
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void NuevoUsuario(Usuario u)
        {
            try
            {
                u.FechaAlta = DateTime.Now;
                dbContext.Usuario.Add(u);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
