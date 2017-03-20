using Blog.Core.Data;
using Blog.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Controllers
{
    public class BlogController : Controller
    {
        public int ProdutosPorPagina = 12;
        EfDbContext db = new EfDbContext();

        // GET: Blog
        public ActionResult Index()
        {
            
            return View(db.Artigos.Where(p=>p.ativo.Value));
        }
        public ActionResult Post(int id = 0)
        {
            var post = db.Artigos.FirstOrDefault(a => a.id_artigo == id);
            return View(post);
        }
        public ActionResult Categoria(int id)
        {
            var artigos = db.Artigos
                .Where(a => a.id_categoria == id)
                .OrderBy(a => a.data_criacao);
            return View("Index",artigos);
        }
        public ActionResult Tag(int id)
        {
            //var artigos = from tag in db.Tags
            //                           where tag.Artigos_Tags
            //                           .Any(c => c.Tags.id_tag == id)
            //                           select tag;
            var artigos = from tag in db.Tags
                           join artigo_tag in db.Artigos_Tags on tag.id_tag equals artigo_tag.id_tag
                           join artigo in db.Artigos on artigo_tag.id_artigo equals artigo.id_artigo
                           where tag.id_tag == id
                           select new Artigos
                           {
                               titulo = artigo.titulo,
                               descricao = artigo.descricao,
                               ativo = artigo.ativo.Value,
                               conteudo = artigo.conteudo,
                               meta_title = artigo.meta_title,
                               meta_description = artigo.meta_description,
                               data_alteracao = artigo.data_alteracao,
                               id_artigo = artigo.id_artigo,
                               data_criacao = artigo.data_criacao,
                               id_categoria = artigo.id_categoria,
                               id_usuario = artigo.id_usuario,
                               imagem = artigo.imagem,
                           };
                          

            return View("Index", artigos);
        }
        #region PartialView
        public PartialViewResult PostRecentes()
        {
            var posts = db.Artigos
                .OrderBy(p => p.data_criacao)
                .Take(5).Where(p=>p.ativo.Value);

            return PartialView(posts);
        }

        #endregion
    }
}