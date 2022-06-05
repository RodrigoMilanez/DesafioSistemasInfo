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
            
            if (apelido == null)
            {
                return View("Login");
            }
            //var usuario =  _context.Usuario.First(a => a.apelido == apelido);
            
            Usuario usuario =  _context.Usuario
                .First(m => m.apelido == apelido);
            if (usuario == null)
            {
                return View("Login");
            } else
            {
                if (usuario.senha == senha)
                {
                    return RedirectToAction("Index", "Usuarios");
                }
                return (View("Login"));
            }
        }

    }
}
