using DSWI_T1_03.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DSWI_T1_03.Controllers
{
    public class Pregunta1Controller : Controller
    {
        // ==================== EJERCICIO 1: UTILIDADES ====================
        [HttpGet]
        public IActionResult Utilidades()
        {
            return View(new UtilidadViewModel());
        }

        [HttpPost]
        public IActionResult Utilidades(UtilidadViewModel model)
        {
            decimal porcentaje;

            if (model.AniosTrabajando < 1)
                porcentaje = 0.05m;
            else if (model.AniosTrabajando < 2)
                porcentaje = 0.07m;
            else if (model.AniosTrabajando < 5)
                porcentaje = 0.10m;
            else if (model.AniosTrabajando < 10)
                porcentaje = 0.15m;
            else
                porcentaje = 0.20m;

            model.PorcentajeAplicado = porcentaje * 100;
            model.MontoUtilidad = model.Salario * porcentaje;
            model.Calculado = true;

            return View(model);
        }

        // ==================== EJERCICIO 2: NOTAS Y BECA ====================
        [HttpGet]
        public IActionResult Beca()
        {
            return View(new BecaViewModel());
        }

        [HttpPost]
        public IActionResult Beca(BecaViewModel model)
        {
            model.Promedio = Math.Round((model.Nota1 + model.Nota2 + model.Nota3) / 3.0, 2);

            if (model.Asistencia < 70)
            {
                model.Categoria = "Reprobado (Asistencia menor al 70%)";
                model.PorcentajeBeca = 0;
            }
            else if (model.Promedio >= 18)
            {
                model.Categoria = "Excelente";
                model.PorcentajeBeca = 50;
            }
            else if (model.Promedio >= 14)
            {
                model.Categoria = "Bueno";
                model.PorcentajeBeca = 25;
            }
            else if (model.Promedio >= 11)
            {
                model.Categoria = "Regular";
                model.PorcentajeBeca = 0;
            }
            else
            {
                model.Categoria = "Reprobado (Debe repetir el curso)";
                model.PorcentajeBeca = 0;
            }

            model.Calculado = true;
            return View(model);
        }
    }
}