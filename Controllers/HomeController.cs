using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DesafioSistemasInfo.Data;
using DesafioSistemasInfo.Models;

namespace DesafioSistemasInfo.Controllers
{
    public class HomeController : Controller
    {
        private readonly UsuarioContext _context;

        public HomeController(UsuarioContext context)
        {
            _context = context;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LoginAsync(string apelido, string senha)
        {
            
            if (apelido == null || senha == null)
            {

                return View("Error");
            }
            
            Usuario usuario =  _context.Usuario
                .First(m => m.apelido == apelido);
            if (usuario == null)
            {
                return View("Error");
            } else
            {
                if (usuario.senha == senha)
                {
                    HttpContext.Session.SetInt32("Userid", usuario.id);

                    return RedirectToAction("Index", "Usuarios");
                   
                }
                return (View("Error"));
            }
        }
        public ActionResult Error()
        {
            return View();
        }

    }
}
