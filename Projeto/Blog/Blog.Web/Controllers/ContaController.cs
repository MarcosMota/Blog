using Blog.Core.Data;
using Blog.Web.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Blog.Web.Controllers
{
    public class ContaController : Controller
    {
        
        // GET: Conta
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel login, string returnUrl)
        {

            if (ModelState.IsValid)
            {
                using (EfDbContext db = new EfDbContext())
                {
                    var vLogin = db.Usuarios.Where(p => p.email.Equals(login.Email)).FirstOrDefault();
                    /*Verificar se a variavel vLogin está vazia. Isso pode ocorrer caso o usuário não existe. 
              Caso não exista ele vai cair na condição else.*/
                    if (vLogin != null)
                    {
                        /*Código abaixo verifica se a senha digitada no site é igual a senha que está sendo retornada 
     do banco. Caso não cai direto no else*/
                        if (Equals(vLogin.senha, login.Senha))
                        {
                            FormsAuthentication.SetAuthCookie(vLogin.email.ToString(), login.Lembrar);
                            if (Url.IsLocalUrl(returnUrl)
                            && returnUrl.Length > 1
                            && returnUrl.StartsWith("/")
                            && !returnUrl.StartsWith("//")
                            && returnUrl.StartsWith("/\\"))
                            {
                                return Redirect(returnUrl);
                            }

                            Session["id_usuario"] = vLogin.id_usuario;
                            Session["Usuario"] = vLogin.nome;
                            return RedirectToAction("Index", "Home");
                        }
                        /*Else responsável da validação da senha*/
                        else
                        {
                            /*Escreve na tela a mensagem de erro informada*/
                            ModelState.AddModelError("", "Senha informada Inválida!!!");
                            /*Retorna a tela de login*/
                            return View(new LoginViewModel());
                        }
                    }
                    else
                    {
                        /*Escreve na tela a mensagem de erro informada*/
                        ModelState.AddModelError("", "Usuario informado Inválida!!!");
                        /*Retorna a tela de login*/
                        return View(new LoginViewModel());
                    }
                    /*Else responsável por verificar se o usuário está ativo*/

                }
                /*Else responsável por verificar se o usuário existe*/

            }
            return View(new LoginViewModel());
        }

        public ActionResult Sair()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("/Home/Index");
        }

        public ActionResult Registrar()
        {
            return View();
        }
       

    }
}