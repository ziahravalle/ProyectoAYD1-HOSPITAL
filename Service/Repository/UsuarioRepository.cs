using ProyectoAYD1_HOSPITAL.Models;
using ProyectoAYD1_HOSPITAL.Service.Interface;

namespace ProyectoAYD1_HOSPITAL.Service.Repository
{
    public class UsuarioRepository : IUsuario
    {
        private bdAYD bdAyd = new bdAYD();
        public IEnumerable<TbUsuario> GetAllUsuarios()
        {
            return bdAyd.TbUsuarios;
        }

        //añadir
        public void Add(TbUsuario usuario)
        {
            try
            {
                bdAyd.TbUsuarios.Add(usuario);
                bdAyd.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message, "existe, no puede crear contraseña");
            }
        }

        //eliminar
        public void Delete(int id)
        {
            var obj = (from tbusuario in bdAyd.TbUsuarios
                       where tbusuario.UsuarioId == id
                       select tbusuario).Single();
            bdAyd.TbUsuarios.Remove(obj);//delete from <tabla> where <campo>=id
            bdAyd.SaveChanges();
        }

        //return obj= UsuarioId == id
        public TbUsuario GetUsuario(int id)
        {
            var obj = (from tbusuario in bdAyd.TbUsuarios
                       where tbusuario.UsuarioId == id
                       select tbusuario).Single();
            return obj;
        }

        public void Update(TbUsuario usuarioModificado)
        {
            var objAModificado = (from tbusuario in bdAyd.TbUsuarios
                                  where tbusuario.UsuarioId == usuarioModificado.UsuarioId
                                  select tbusuario).FirstOrDefault();
            if (objAModificado != null)
            {
                objAModificado.PacienteId = usuarioModificado.PacienteId;
                objAModificado.Password = usuarioModificado.Password;

                bdAyd.SaveChanges();
            }
        }

        public TbUsuario Validar(TbUsuario usuario)
        {
            var obj = (from tbusuario in bdAyd.TbUsuarios
                       where tbusuario.PacienteId == usuario.PacienteId &&
                                tbusuario.Password == usuario.Password
                       select tbusuario).FirstOrDefault();
            return obj;
        }
    }


}
