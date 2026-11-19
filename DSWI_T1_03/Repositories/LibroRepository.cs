using DSWI_T1_03.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DSWI_T1_03;

public class LibroRepository : ILibroRepository
{
    private readonly LibreriaDbContext _context;

    public LibroRepository(LibreriaDbContext context)
    {
        _context = context;
    }

    public async Task<List<Libro>> ObtenerTodosAsync()
    {
        return await _context.Libros
            .FromSqlRaw("EXEC sp_ListarLibros")
            .ToListAsync();
    }

    public async Task<Libro?> ObtenerPorIdAsync(int id)
    {
        var libros = await ObtenerTodosAsync();
        return libros.FirstOrDefault(libro => libro.LibroId == id);
    }

    public async Task CrearAsync(Libro libro)
    {
        var parametros = new[]
        {
            new SqlParameter("@Titulo", (object?)libro.Titulo ?? DBNull.Value),
            new SqlParameter("@Genero", (object?)libro.Genero ?? DBNull.Value),
            new SqlParameter("@AñoPublicacion", (object?)libro.AñoPublicacion ?? DBNull.Value),
            new SqlParameter("@ISBN", (object?)libro.Isbn ?? DBNull.Value),
            new SqlParameter("@AutorID", (object?)libro.AutorId ?? DBNull.Value)
        };

        await _context.Database.ExecuteSqlRawAsync(
            "EXEC sp_InsertarLibro @Titulo, @Genero, @AñoPublicacion, @ISBN, @AutorID",
            parametros);
    }

    public async Task EditarAsync(Libro libro)
    {
        var parametros = new[]
        {
            new SqlParameter("@LibroID", libro.LibroId),
            new SqlParameter("@Titulo", (object?)libro.Titulo ?? DBNull.Value),
            new SqlParameter("@Genero", (object?)libro.Genero ?? DBNull.Value),
            new SqlParameter("@AñoPublicacion", (object?)libro.AñoPublicacion ?? DBNull.Value),
            new SqlParameter("@ISBN", (object?)libro.Isbn ?? DBNull.Value),
            new SqlParameter("@AutorID", (object?)libro.AutorId ?? DBNull.Value)
        };

        await _context.Database.ExecuteSqlRawAsync(
            "EXEC sp_EditarLibro @LibroID, @Titulo, @Genero, @AñoPublicacion, @ISBN, @AutorID",
            parametros);
    }
}
