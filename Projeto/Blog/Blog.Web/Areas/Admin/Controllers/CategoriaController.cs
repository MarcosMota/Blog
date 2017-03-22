using AutoMapper;
using Blog.Core.Data.Repositorio;
using Blog.Core.Domain;
using Blog.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{
    public class CategoriaController : Controller
    {
        private CategoriaRepositorio repositorio;
        public CategoriaController(CategoriaRepositorio _repositorio)
        {
            repositorio = _repositorio;
        }
        // GET: Admin/Categoria
        public ActionResult Index()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Categorias, CategoriaViewModel>();
               
            });
            var t = Mapper.Map<List<Categorias>, List<CategoriaViewModel>>(repositorio.GetAll());
            

            return View(t);
        }
      
        public ActionResult Novo()
        {
            ViewBag.Title = "Categorias";
            return View();
        }
        public ActionResult Novo(Categorias categoria)
        {
            if (ModelState.IsValid)
            {


                if (categoria != null)
                {                
                    if (categoria.id_categoria == 0)
                    {
                        repositorio.Insert(categoria);                }
                    else
                    {
                        repositorio.Update(categoria);
                    }
                    ViewBag.Title = "Categoria";
                    return RedirectToAction("Index");
                }

            }

            return View(categoria);
        }
        public ActionResult Editar(int id)
        {
            if (id > 0)
            {
                Categorias categoria = repositorio.GetById(id);
                
                return View("Novo", categoria);
            }
            ViewBag.Title = "Categoria";
            return View();
        }
    }
}