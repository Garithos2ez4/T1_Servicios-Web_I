using DSWI_T1_03.Models;

namespace DSWI_T1_03;

public class LibroService : ILibroService
{
    private readonly ILibroRepository _libroRepository;

    public LibroService(ILibroRepository libroRepository)
    {
        _libroRepository = libroRepository;
    }

    public Task<List<Libro>> ObtenerTodosAsync()
    {
        return _libroRepository.ObtenerTodosAsync();
    }

    public Task<Libro?> ObtenerPorIdAsync(int id)
    {
        return _libroRepository.ObtenerPorIdAsync(id);
    }

    public Task CrearAsync(Libro libro)
    {
        return _libroRepository.CrearAsync(libro);
    }

    public Task EditarAsync(Libro libro)
    {
        return _libroRepository.EditarAsync(libro);
    }
}
