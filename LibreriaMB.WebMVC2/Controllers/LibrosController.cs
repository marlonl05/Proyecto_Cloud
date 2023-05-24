using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibreriaMB.UAPI;
using LibreriaMB.Modelos;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LibreriaMB.WebMVC2.Controllers
{
    public class LibrosController : Controller
    {

        private string Url = "https://localhost:7187/api/Libros";
        private Crud<Libro> Crud { get; set; }

        public LibrosController()
        {
            Crud = new Crud<Libro>();
        }

        // GET: LibroController1
        public ActionResult Index()
        {
            var datos = Crud.Select(Url);
            return View(datos);
        }

        // GET: LibroController1/Details/5
        public ActionResult Details(int id)
        {
            var datos = Crud.Select_ById(Url, id.ToString());
            return View(datos);
        }

        // GET: LibroController1/Create
        public ActionResult Create()
        {
            // obtenemos la lista de provincias para que sea usada en la Vista en un ComboBox
            var listaLibreria = new Crud<Libreria>()
                .Select(Url.Replace("Libros", "Librerias"))
                .Select(p => new SelectListItem     // transformamos del tipo Libreria -> SelectListItem
                {
                    Value = p.LibreriaId.ToString(),       // codigo de libreria
                    Text = p.Nombre                // nombre de librerira
                })
                .ToList();

            ViewBag.ListaLibreria = listaLibreria;  // pasamos la lista de libreria a la vista

            return View();
        }

        // POST: LibroController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Libro datos)
        {
            try
            {
                Crud.Insert(Url, datos);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View(datos);
            }
        }

        // GET: LibroController1/Edit/5
        public ActionResult Edit(int id)
        {
            // obtenemos la lista de provincias para que sea usada en la Vista en un ComboBox
            var listaLibreria = new Crud<Libreria>()
                .Select(Url.Replace("Libro", "Libreria"))
                .Select(p => new SelectListItem     // transformamos del tipo Privincia -> SelectListItem
                {
                    Value = p.LibreriaId.ToString(),       // codigo de provincia
                    Text = p.Nombre                // nombre de provincia
                })
                .ToList();

            ViewBag.ListaLibreria = listaLibreria;  // pasamos la lista de Provincias a la vista

            var datos = Crud.Select_ById(Url, id.ToString());
            return View(datos);
        }

        // POST: LibroController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Libro datos)
        {
            try
            {
                Crud.Update(Url, id.ToString(), datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }

        // GET: LibroController1/Delete/5
        public ActionResult Delete(int id)
        {
            var datos = Crud.Select_ById(Url, id.ToString());
            return View(datos);
        }

        // POST: LibroController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Libro datos)
        {
            try
            {
                Crud.Delete(Url, id.ToString());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }
    }
}