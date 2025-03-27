using Microsoft.AspNetCore.Mvc;
using ProyectoAYD1_HOSPITAL.Models;
using ProyectoAYD1_HOSPITAL.Service.Interface;

namespace ProyectoAYD1_HOSPITAL.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuario objUsuario;

        public UsuarioController(IUsuario UsuarioObj)
        {
            objUsuario = UsuarioObj;
        }

        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Validar(TbUsuario usuario)
        {
            var obj = objUsuario.Validar(usuario); // Busca el usuario en la base de datos 

            if (obj == null)
            {
                // Si el usuario no se encuentra en la base de datos index
                return View("Login");
            }
            else
            {
                return View("Index");
            }
        }

        /*---MANTENIMIENTOS-----------------------------------------------------------------*/
        //LISTAR

        public IActionResult Listar()
        {
            return View(objUsuario.GetAllUsuarios());
        }

        //GRABAR
        public IActionResult Agregar()
        {
            return View();
        }

        public IActionResult Grabar(TbUsuario usuario)
        {

            objUsuario.Add(usuario);
            return RedirectToAction("Listar");
        }

        //EDIT

        //[Route("admin/Edit/{cod}")]
        public IActionResult Edit(int cod)
        {
            return View(objUsuario.GetUsuario(cod));
        }
        public IActionResult EditDetails(TbUsuario usuario)
        {
            objUsuario.Update(usuario);
            return RedirectToAction("Listar");
        }

        //DELETE

        //[Route("admin/Delete/{cod}")]
        public IActionResult Delete(int cod)
        {
            objUsuario.Delete(cod);
            return RedirectToAction("Listar");
        }
    }
}
