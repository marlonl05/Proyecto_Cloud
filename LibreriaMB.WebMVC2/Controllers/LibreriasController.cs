using LibreriaMB.Modelos;
using LibreriaMB.UAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LibreriaMB.WebMVC2.Controllers
{
    public class LibreriasController : Controller
    {
        private Crud<Modelos.Libreria> libreria = new Crud<Modelos.Libreria>();
        private string Url = "https://localhost:7187/api/Librerias";
       
        // GET: LibreriasController
        public ActionResult Index()
        {
            var datos = libreria.Select(Url);
            return View(datos); ;
        }

        // GET: LibreriasController/Details/5
        public ActionResult Details(int id)
        {
            var datos = libreria.Select_ById(Url, id.ToString());
            return View(datos);
        }

        // GET: LibreriasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LibreriasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Modelos.Libreria datos)
        {
            try
            {
                libreria.Insert(Url, datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }

        // GET: LibreriasController/Edit/5
        public ActionResult Edit(int id)
        {
            var datos = libreria.Select_ById(Url, id.ToString());
            return View(datos);
        }

        // POST: LibreriasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Modelos.Libreria datos)
        {
            try
            {
                libreria.Update(Url, id.ToString(), datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }

        // GET: LibreriasController/Delete/5
        public ActionResult Delete(int id)
        {
            var datos = libreria.Select_ById(Url, id.ToString());
            return View(datos);
        }

        // POST: LibreriasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Modelos.Libreria datos)
        {
            try
            {
                libreria.Delete(Url, id.ToString());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }
    }
}
