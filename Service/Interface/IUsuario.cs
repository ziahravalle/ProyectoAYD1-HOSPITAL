using ProyectoAYD1_HOSPITAL.Models;

namespace ProyectoAYD1_HOSPITAL.Service.Interface
{
    public interface IUsuario
    {
        void Add(TbUsuario usuario);
        void Delete(int id); 
        void Update(TbUsuario usuarioModificado);
        IEnumerable<TbUsuario> GetAllUsuarios();
        TbUsuario GetUsuario(int id);
        TbUsuario Validar(TbUsuario usuario);

    }
}
