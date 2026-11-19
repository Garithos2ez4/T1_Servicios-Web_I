using DSWI_T1_03.Models;
using Microsoft.AspNetCore.Mvc;

namespace DSWI_T1_03;

public class AutoresController : Controller
{
    private readonly IAutorService _autorService;

    public AutoresController(IAutorService autorService)
    {
        _autorService = autorService;
    }

    public async Task<IActionResult> Index()
    {
        var autores = await _autorService.ObtenerTodosAsync();
        return View(autores);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Autore autor)
    {
        if (!ModelState.IsValid)
        {
            return View(autor);
        }

        await _autorService.CrearAsync(autor);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var autor = await _autorService.ObtenerPorIdAsync(id);
        if (autor is null)
        {
            return NotFound();
        }

        return View(autor);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Autore autor)
    {
        if (!ModelState.IsValid)
        {
            return View(autor);
        }

        var autorExistente = await _autorService.ObtenerPorIdAsync(autor.AutorId);
        if (autorExistente is null)
        {
            return NotFound();
        }

        await _autorService.EditarAsync(autor);
        return RedirectToAction(nameof(Index));
    }
}
