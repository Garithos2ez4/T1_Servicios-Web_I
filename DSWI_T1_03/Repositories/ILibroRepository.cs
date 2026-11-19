using DSWI_T1_03.Models;

namespace DSWI_T1_03;

public interface ILibroRepository
{
    Task<List<Libro>> ObtenerTodosAsync();
    Task<Libro?> ObtenerPorIdAsync(int id);
    Task CrearAsync(Libro libro);
    Task EditarAsync(Libro libro);
}
