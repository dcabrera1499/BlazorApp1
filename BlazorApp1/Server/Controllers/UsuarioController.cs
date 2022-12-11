using BlazorApp1.Server.Servicios;
using BlazorApp1.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarios iUsuario;

        public UsuarioController(IUsuarios iUser)
        {
           iUsuario = iUser;
        }

        [HttpGet]

        public async Task<List<Usuario>> ListaUsuarios()
        {
            return await Task.FromResult(iUsuario.DatosUsuarios());
        }

        [HttpPost]

        public void Post(Usuario usuario)
        {
            iUsuario.NuevoUsuario(usuario);
        }

        [HttpGet("{id}")]

        public IActionResult GetUsuario(int id)
        {

            Usuario u = iUsuario.DatosUsuario(id);

            if(u != null)
            {
                return Ok(u);
            }
            return NotFound();


        }

        [HttpPut]

        public void Modificar(Usuario usuario)
        {
            iUsuario.ActualizarUsuario(usuario);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            iUsuario.BorrarUsuario(id);
            return Ok();
        }

    }
}
