using WebApiCodeFirst.Data;
using WebApiCodeFirst.Models;
using WebApiCodeFirst.Repositorios.IRepositorios;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApiCodeFirst.Repositorios
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        //Declarar un objeto  de conexion a la base de datos
        private readonly ApplicationDbContext _db;

        //Constructor que recibe el contexto de la base de datos
        public CategoriaRepositorio(ApplicationDbContext db)
        {
            _db = db;
        }

        public ICollection<Categoria> GetCategorias()
        {
            return _db.categoria.OrderBy(c => c.Nombre).ToList();
        }

        public Categoria? GetCategoria(int idCategoria)
        {
            return _db.categoria.FirstOrDefault(c => c.Id == idCategoria);
        }

        public bool CrearCategoria(Categoria categoria)
        {
            categoria.FechaCreacion = DateTime.Now;
            _db.categoria.Add(categoria);
            return Guardar();
        }

        public bool ActualizarCategoria(Categoria categoria)
        {
            categoria.FechaCreacion = DateTime.Now;
            //Arreglar problema del PUT
            var categoriaExistente = _db.categoria.Find(categoria.Id);
            if (categoriaExistente != null)
            {
                _db.Entry(categoriaExistente).CurrentValues.SetValues(categoria);
            }
            else
            {
                _db.categoria.Update(categoria);
            }

            return Guardar();
        }

        public bool EliminarCategoria(Categoria categoria)
        {
            _db.categoria.Remove(categoria);
            return Guardar();
        }

        public bool ExisteCategoria(int idCategoria)
        {
            return _db.categoria.Any(c => c.Id == idCategoria);
        }

        public bool ExisteCategoria(string nombreCategoria)
        {
            bool exiteCateoria = _db.categoria.Any(c => c.Nombre.ToLower().Trim() == nombreCategoria.ToLower().Trim());
            return exiteCateoria;
        }

        public bool Guardar()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }
    }
}