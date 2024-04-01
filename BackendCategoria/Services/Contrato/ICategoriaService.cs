using BackendCategoria.Models;


namespace BackendCategoria.Services.Contrato
{
    public interface ICategoriaService
    {
        Task<List<TmCategorium>> GetList();

        Task<TmCategorium> Get(int id);

        Task<TmCategorium> Add(TmCategorium modelo);

        Task<bool> Update(TmCategorium modelo);

        Task<bool> Delete(TmCategorium modelo);
    }
}
