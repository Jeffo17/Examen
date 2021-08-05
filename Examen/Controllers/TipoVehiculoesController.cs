using Datos.Datos;
using Datos.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Controllers
{
    public class TipoVehiculoesController : Controller
    {
        
        private readonly EjercicioEvaluacionContext _context;
        
        public TipoVehiculoesController (EjercicioEvaluacionContext context)
        {
            _context = context;
        }

        public void Combox()
        {
            ViewData["CodigoVehiculo"] = new SelectList(_context.Vehiculos.Select(x => new ViewModelsTiposVehiculos
            {
                Codigo = x.Codigo,
                Nombres = $"{Descripcion}"

            })where(a=> a.Estado== 1).ToList(), "Codigo);

        // GET: TipoVehiculoesController
        public ActionResult Index()
        {
            List<TipoVehiculo> ltsTVehiculo = _context.TipoVehiculos.ToList();
            return View(ltsTVehiculo);

        }

        // GET: VehiculoesController/Details/5
        public ActionResult Details(int id)
        {
            TipoVehiculo Tvehiculo = _context.TipoVehiculos.Where(a => a.Codigo == id).FirstOrDefault();
            return View(Tvehiculo);
        }

        // GET: VehiculoesController/Create
        public ActionResult Create()
        {
                Combox();
            return View();
        }

        // POST: VehiculoesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoVehiculo Tvehiculo)
        {
            try
            {
                Tvehiculo.Estado = 1;
                _context.Add(Tvehiculo);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(Tvehiculo);
            }
        }

        // GET: VehiculoesController/Edit/5
        public ActionResult Edit(int id)
        {
                Combox();
            TipoVehiculo Tvehiculo = _context.TipoVehiculos.Where(a => a.Codigo == id).FirstOrDefault();
            return View(Tvehiculo);
        }

        // POST: VehiculoesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TipoVehiculo Tvehiculo)
        {
            if (id != Tvehiculo.Codigo)
            {
                return RedirectToAction("Index");
            }

            try
            {
                _context.Update(Tvehiculo);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                    Combox();
                return View();
            }
        }

        // GET: VehiculoesController/Delete/5
        public ActionResult Desactivar(int id)
        {
            TipoVehiculo Tvehiculo = _context.TipoVehiculos.Where(a => a.Codigo == id).FirstOrDefault();
            Tvehiculo.Estado = 0;
            _context.Update(Tvehiculo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: VehiculoesController/Delete/5
        public ActionResult Activar(int id)
        {
            TipoVehiculo Tvehiculo = _context.TipoVehiculos.Where(a => a.Codigo == id).FirstOrDefault();
            Tvehiculo.Estado = 1;
            _context.Update(Tvehiculo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
    }
}

