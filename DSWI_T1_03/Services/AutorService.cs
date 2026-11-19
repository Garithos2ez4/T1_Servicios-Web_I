using DSWI_T1_03.Models;

namespace DSWI_T1_03;

public class AutorService : IAutorService
{
    private readonly IAutorRepository _autorRepository;

    public AutorService(IAutorRepository autorRepository)
    {
        _autorRepository = autorRepository;
    }

    public Task<List<Autore>> ObtenerTodosAsync()
    {
        return _autorRepository.ObtenerTodosAsync();
    }

    public Task<Autore?> ObtenerPorIdAsync(int id)
    {
        return _autorRepository.ObtenerPorIdAsync(id);
    }

    public Task CrearAsync(Autore autor)
    {
        return _autorRepository.CrearAsync(autor);
    }

    public Task EditarAsync(Autore autor)
    {
        return _autorRepository.EditarAsync(autor);
    }
}
