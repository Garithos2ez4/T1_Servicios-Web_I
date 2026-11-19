using DSWI_T1_03.Models;

namespace DSWI_T1_03;

public interface IAutorRepository
{
    Task<List<Autore>> ObtenerTodosAsync();
    Task<Autore?> ObtenerPorIdAsync(int id);
    Task CrearAsync(Autore autor);
    Task EditarAsync(Autore autor);
}
