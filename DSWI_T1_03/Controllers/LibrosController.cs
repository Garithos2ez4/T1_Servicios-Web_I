
using DSWI_T1_03.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DSWI_T1_03;

public class LibrosController : Controller
{
    private readonly ILibroService _libroService;
    private readonly IAutorService _autorService;

    public LibrosController(
        ILibroService libroService,
        IAutorService autorService)
    {
        _libroService = libroService;
        _autorService = autorService;
    }

    public async Task<IActionResult> Index()
    {
        var libros = await _libroService.ObtenerTodosAsync();

        var autores = await _autorService.ObtenerTodosAsync();

        ViewBag.Autores = autores.ToDictionary(
            a => a.AutorId,
            a => a.Nombre
        );

        return View(libros);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var autores = await _autorService.ObtenerTodosAsync();

        ViewBag.Autores = new SelectList(
            autores, "AutorId", "Nombre");

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Libro libro)
    {
        if (!ModelState.IsValid)
        {
            var autores = await _autorService.ObtenerTodosAsync();

            ViewBag.Autores = new SelectList(
                autores, "AutorId", "Nombre", libro.AutorId);

            return View(libro);
        }

        await _libroService.CrearAsync(libro);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var libro = await _libroService.ObtenerPorIdAsync(id);

        if (libro is null)
        {
            return NotFound();
        }

        var autores = await _autorService.ObtenerTodosAsync();

        ViewBag.Autores = new SelectList(
            autores, "AutorId", "Nombre", libro.AutorId);

        return View(libro);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Libro libro)
    {
        if (!ModelState.IsValid)
        {
            var autores = await _autorService.ObtenerTodosAsync();

            ViewBag.Autores = new SelectList(
                autores, "AutorId", "Nombre", libro.AutorId);

            return View(libro);
        }

        var libroExistente = await _libroService.ObtenerPorIdAsync(
            libro.LibroId);

        if (libroExistente is null)
        {
            return NotFound();
        }

        await _libroService.EditarAsync(libro);

        return RedirectToAction(nameof(Index));
    }
}
