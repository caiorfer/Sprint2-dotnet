using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace SistemaRecomendacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly List<Usuario> _usuarios;

        public UsuariosController()
        {
            _usuarios = new List<Usuario>
            {
                new Usuario { Id = 1, Nome = "Usuário 1" },
                new Usuario { Id = 2, Nome = "Usuário 2" },
                new Usuario { Id = 3, Nome = "Usuário 3" }
            };
        }

        // GET: api/Usuarios
        [HttpGet]
        public IActionResult GetUsuarios()
        {
            return Ok(new { usuarios = _usuarios });
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public IActionResult GetUsuario(int id)
        {
            var usuario = _usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        // POST: api/Usuarios
        [HttpPost]
        public IActionResult CreateUsuario([FromBody] Usuario novoUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            novoUsuario.Id = _usuarios.Max(u => u.Id) + 1;
            _usuarios.Add(novoUsuario);
            return CreatedAtAction(nameof(GetUsuario), new { id = novoUsuario.Id }, novoUsuario);
        }

        // PUT: api/Usuarios/5
        [HttpPut("{id}")]
        public IActionResult UpdateUsuario(int id, [FromBody] Usuario usuarioAtualizado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuario = _usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            usuario.Nome = usuarioAtualizado.Nome;
            return Ok(us)
        }
    }
}