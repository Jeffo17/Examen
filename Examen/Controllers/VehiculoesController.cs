using Datos.Datos;
using Datos.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Controllers
{
    public class VehiculoesController : Controller
    {
        private readonly EjercicioEvaluacionContext _context;

        public VehiculoesController(EjercicioEvaluacionContext context)
        {
            _context = context;
        }

        // GET: VehiculoesController
        public ActionResult Index()
        {
            List<Vehiculo> ltsVehiculo = _context.Vehiculos.ToList();
            return View(ltsVehiculo);
           
        }

        // GET: VehiculoesController/Details/5
        public ActionResult Details(int id)
        {
            Vehiculo vehiculo = _context.Vehiculos.Where(a => a.Codigo == id).FirstOrDefault();
            return View(vehiculo);
        }

        // GET: VehiculoesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehiculoesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vehiculo vehiculo)
        {
            try
            {
                vehiculo.Estado = 1;
                _context.Add(vehiculo);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(vehiculo);
            }
        }

        // GET: VehiculoesController/Edit/5
        public ActionResult Edit(int id)
        {
            Vehiculo vehiculo = _context.Vehiculos.Where(a => a.Codigo == id).FirstOrDefault();
            return View();
        }

        // POST: VehiculoesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Vehiculo vehiculo)
        {
            if(id != vehiculo.Codigo)
            {
                return RedirectToAction("Index");
            }
          
            try
            {
                _context.Update(vehiculo);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: VehiculoesController/Delete/5
        public ActionResult Desactivar(int id)
        {
            Vehiculo vehiculo = _context.Vehiculos.Where(a => a.Codigo == id).FirstOrDefault();
            vehiculo.Estado = 0;
            _context.Update(vehiculo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: VehiculoesController/Delete/5
        public ActionResult Activar(int id)
        {
            Vehiculo vehiculo = _context.Vehiculos.Where(a => a.Codigo == id).FirstOrDefault();
            vehiculo.Estado = 1;
            _context.Update(vehiculo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
    
}
