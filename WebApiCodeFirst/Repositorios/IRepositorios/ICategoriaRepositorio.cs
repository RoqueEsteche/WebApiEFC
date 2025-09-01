using WebApiCodeFirst.Models;

namespace WebApiCodeFirst.Repositorios.IRepositorios
{
    public interface ICategoriaRepositorio
    {
        ICollection<Categoria> GetCategorias(); //Lista de categorias

        Categoria? GetCategoria(int idCategoria); //Obtener una categoria por id

        bool ExisteCategoria(int idCategoria); //Verifica si existe una categoria por identificador

        bool ExisteCategoria(string nombreCategoria); //Verifica si existe una categoria por nombre

        bool CrearCategoria(Categoria categoria); //Crear una categoria

        bool ActualizarCategoria(Categoria categoria); //Actualizar una categoria

        bool EliminarCategoria(Categoria categoria); //Eliminar una categoria

        bool Guardar(); //Guardar cambios en la base de datos
    }
}