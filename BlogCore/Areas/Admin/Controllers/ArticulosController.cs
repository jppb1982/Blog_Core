using BlogCore.AccesoDatos.Data.Repository.IRepository;
using BlogCore.Modelos;
using BlogCore.Modelos.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BlogCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticulosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        public ArticulosController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            ArticuloViewModel articuloVM = new ArticuloViewModel()
            {
                Articulo = new Articulo(),
                ListaCategorias = _contenedorTrabajo.Categoria.GetListaCategorias()
            };
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(Articulo articulo)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //Lógica para guardar en BD
        //        _contenedorTrabajo.Articulo.Add(articulo);
        //        _contenedorTrabajo.Save();
        //        return RedirectToAction(nameof(Index));

        //    }
        //    return View(articulo);
        //}


        #region Llamadas a las API
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Articulo.GetAll(includeProperties: "Categoria") });
        }
        #endregion

    }
}
