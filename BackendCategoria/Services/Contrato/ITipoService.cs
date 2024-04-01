using BackendCategoria.Models;

namespace BackendCategoria.Services.Contrato
{
    public interface ITipoService
    {

        Task<List<TmTipo>> GetList();
    }
}
