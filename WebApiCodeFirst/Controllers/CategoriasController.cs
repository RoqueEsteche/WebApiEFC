using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiCodeFirst.Mappers;
using WebApiCodeFirst.Models;
using WebApiCodeFirst.Models.DTO;
using WebApiCodeFirst.Repositorios.IRepositorios;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        private readonly IMapper _mapper;

        public CategoriasController(ICategoriaRepositorio categoriaRepositorio, IMapper mapper)
        {
            _categoriaRepositorio = categoriaRepositorio;
            _mapper = mapper;
        }

        // GET: api/<CategoriasController>
        [HttpGet]
        public IActionResult GetCategorias()
        {
            var categorias = _categoriaRepositorio.GetCategorias();
            List<CategoriaDTO> listaCategorias = new List<CategoriaDTO>();

            foreach (var item in categorias)
            {
                listaCategorias.Add(_mapper.Map<CategoriaDTO>(item));
            }

            return Ok(listaCategorias);
        }

        // GET api/<CategoriasController>/5
        [HttpGet("{categoriaId}", Name = "GetCategoria")]
        public IActionResult GetCategoria(int categoriaId)
        {
            var itemCategoria = _categoriaRepositorio.GetCategoria(categoriaId);

            if (itemCategoria == null)
            {
                return NotFound();
            }

            var categoriaDTO = _mapper.Map<CategoriaDTO>(itemCategoria);

            return Ok(categoriaDTO);
        }

        // POST api/<CategoriasController>
        [HttpPost]
        public IActionResult CrearCategoria([FromBody] CrearCategoriaDTO crearCategoriaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (crearCategoriaDTO == null)
            {
                return BadRequest(ModelState);
            }

            if (_categoriaRepositorio.ExisteCategoria(crearCategoriaDTO.Nombre))
            {
                ModelState.AddModelError("", "La categoría ya existe");
                return StatusCode(404, ModelState);
            }

            var categoria = _mapper.Map<Categoria>(crearCategoriaDTO);

            if (!_categoriaRepositorio.CrearCategoria(categoria))
            {
                ModelState.AddModelError("", $"Algo salio mal guardando el registro{categoria.Nombre}");
                return StatusCode(404, ModelState);
            }

            return CreatedAtRoute("GetCategoria", new { categoriaId = categoria.Id }, categoria);
        }

        // PUT api/<CategoriasController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CrearCategoriaDTO actualizarCategoriaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (actualizarCategoriaDTO == null)
            {
                return BadRequest(ModelState);
            }

            if (!_categoriaRepositorio.ExisteCategoria(id))
            {
                return NotFound();
            }

            // Verifica si el nombre ya existe en otra categoría
            var existeNombre = _categoriaRepositorio.GetCategorias()
                .Any(c => c.Nombre.ToLower().Trim() == actualizarCategoriaDTO.Nombre.ToLower().Trim() && c.Id != id);
            if (existeNombre)
            {
                ModelState.AddModelError("", "La categoría ya existe");
                return StatusCode(404, ModelState);
            }

            var categoria = _categoriaRepositorio.GetCategoria(id);
            if (categoria == null)
            {
                return NotFound();
            }

            categoria.Nombre = actualizarCategoriaDTO.Nombre;

            if (!_categoriaRepositorio.ActualizarCategoria(categoria))
            {
                ModelState.AddModelError("", $"Algo salio mal actualizando el registro {categoria.Nombre}");
                return StatusCode(404, ModelState);
            }

            return NoContent();
        }

        // DELETE api/<CategoriasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_categoriaRepositorio.ExisteCategoria(id))
            {
                return NotFound();
            }

            var categoria = _categoriaRepositorio.GetCategoria(id);
            if (categoria == null)
            {
                return NotFound();
            }

            if (!_categoriaRepositorio.EliminarCategoria(categoria))
            {
                ModelState.AddModelError("", $"Algo salio mal eliminando el registro {categoria.Nombre}");
                return StatusCode(404, ModelState);
            }

            return NoContent();
        }
    }
}