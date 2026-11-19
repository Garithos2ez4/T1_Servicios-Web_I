using DSWI_T1_03.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DSWI_T1_03;

public class AutorRepository : IAutorRepository
{
    private readonly LibreriaDbContext _context;

    public AutorRepository(LibreriaDbContext context)
    {
        _context = context;
    }

    public async Task<List<Autore>> ObtenerTodosAsync()
    {
        return await _context.Autores
            .FromSqlRaw("EXEC sp_ListarAutores")
            .ToListAsync();
    }

    public async Task<Autore?> ObtenerPorIdAsync(int id)
    {
        var autores = await ObtenerTodosAsync();
        return autores.FirstOrDefault(autor => autor.AutorId == id);
    }

    public async Task CrearAsync(Autore autor)
    {
        var parametros = new[]
        {
            new SqlParameter("@Nombre", (object?)autor.Nombre ?? DBNull.Value),
            new SqlParameter("@Nacionalidad", (object?)autor.Nacionalidad ?? DBNull.Value)
        };

        await _context.Database.ExecuteSqlRawAsync(
            "EXEC sp_InsertarAutor @Nombre, @Nacionalidad",
            parametros);
    }

    public async Task EditarAsync(Autore autor)
    {
        var parametros = new[]
        {
            new SqlParameter("@AutorID", autor.AutorId),
            new SqlParameter("@Nombre", (object?)autor.Nombre ?? DBNull.Value),
            new SqlParameter("@Nacionalidad", (object?)autor.Nacionalidad ?? DBNull.Value)
        };

        await _context.Database.ExecuteSqlRawAsync(
            "EXEC sp_EditarAutor @AutorID, @Nombre, @Nacionalidad",
            parametros);
    }
}
