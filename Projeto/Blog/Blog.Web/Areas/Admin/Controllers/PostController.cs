using Blog.Core.Data;
using Blog.Core.Domain;
using Blog.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{
    public class PostController : Controller
    {

        private const string _ImagesPath = "~/Images/post";
        EfDbContext db = new EfDbContext();
        // GET: Admin/Post

        public ActionResult Index()
        {
            @ViewBag.Title = "Post";
            return View(db.Artigos.OrderBy(a=>a.descricao));
        }
        public JsonResult GetPost()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var json = db.Artigos;
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Novo()
        {
            ViewBag.Title = "Post";
            ViewBag.Categorias = new SelectList(db.Categorias, "id_categoria", "descricao");
            return View();
        }
        [HttpPost]
            [ValidateInput(false)]
        public ActionResult Novo(PostViewModel post)
        {
            if(post != null)
            {
               
                if (post.ImageUpload != null)
                {
                    // Delete exiting file
                    //System.IO.File.Delete(Path.Combine(Server.MapPath(_ImagesPath), carousel.CarouselImage));
                    // Save new file
                    string fileName = Guid.NewGuid() + Path.GetFileName(post.ImageUpload.FileName);
                    string path = Path.Combine(Server.MapPath(_ImagesPath), fileName);
                    post.ImageUpload.SaveAs(path);
                    post.imagem = fileName;
                    
                }
                Artigos artigo = null;
                if (post.id_post == 0)
                {
                    artigo = new Artigos()
                    {
                        id_artigo = post.id_post,
                        ativo = post.ativo,
                        conteudo = post.conteudo,
                        data_alteracao = DateTime.Now,
                        data_criacao = DateTime.Now,
                        descricao = post.descricao == null ? "" : post.descricao,
                        titulo = post.titulo == null ? "" : post.titulo,
                        meta_title = post.meta_title == null ? "" : post.meta_title,
                        meta_description = post.meta_description == null ? "" : post.meta_description,
                        id_categoria = post.id_categoria,
                        imagem = post.imagem
                        
                    };
                    db.Artigos.Add(artigo);
                    
                }
                else
                {
                    artigo = db.Artigos.Find(post.id_post);
                    artigo.id_artigo = post.id_post;
                    artigo.ativo = post.ativo;
                    artigo.conteudo = post.conteudo;
                    artigo.data_alteracao = DateTime.Now;
                    artigo.data_criacao = DateTime.Now;
                    artigo.descricao = post.descricao == null ? "" : post.descricao;
                    artigo.titulo = post.titulo == null ? "" : post.titulo;
                    artigo.meta_title = post.meta_title == null ? "" : post.meta_title;
                    artigo.meta_description = post.meta_description == null ? "" : post.meta_description;
                    artigo.id_categoria = post.id_categoria;
                    artigo.imagem = post.imagem;
                }
                Usuarios user = db.Usuarios.FirstOrDefault(u => u.email == User.Identity.Name);
                artigo.id_usuario = user.id_usuario;
                db.SaveChanges();


                @ViewBag.Title = "Post";
                return RedirectToAction("Index");
            }

            

            return View();
        }
        public ActionResult Editar(int id)
        {
            if(id > 0)
            {
                PostViewModel post = (from p in db.Artigos
                           where p.id_artigo == id
                           select new PostViewModel()
                           {
                               ativo = p.ativo.Value,
                               conteudo = p.conteudo,
                               descricao = p.descricao,
                               id_categoria = p.id_categoria.Value,
                               id_post = p.id_artigo,
                               imagem = p.imagem,
                               meta_description = p.meta_description,
                               meta_title = p.meta_title,
                               titulo = p.titulo
                           }).First();
                ViewBag.Categorias = new SelectList(db.Categorias, "id_categoria", "descricao");
                return View("Novo", post);
            }
            @ViewBag.Title = "Post";
            return View();
        }
    }
}