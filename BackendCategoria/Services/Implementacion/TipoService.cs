using Microsoft.EntityFrameworkCore;
using BackendCategoria.Models;
using BackendCategoria.Services.Contrato;

namespace BackendCategoria.Services.Implementacion
{
    
    public class TipoService: ITipoService
    {
        private Dbtest2Context _dbtest2Context;

        public TipoService(Dbtest2Context dbtest2Context)
        {
            _dbtest2Context = dbtest2Context;
        }

        public async Task<List<TmTipo>> GetList()
        {
            try
            {
                List<TmTipo> lista = new List<TmTipo>();
                lista = await _dbtest2Context.TmTipos.ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
