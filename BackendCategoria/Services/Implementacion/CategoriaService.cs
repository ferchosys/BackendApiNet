using Microsoft.EntityFrameworkCore;
using BackendCategoria.Models;
using BackendCategoria.Services.Contrato;

namespace BackendCategoria.Services.Implementacion
{
    public class CategoriaService: ICategoriaService
    {

        private Dbtest2Context _dbtest2Context;

        public CategoriaService(Dbtest2Context dbtest2Context)
        {
            _dbtest2Context = dbtest2Context;
        }

        public async Task<List<TmCategorium>> GetList()
        {
            try
            {
                List<TmCategorium> listaCategoria = new List<TmCategorium>();
                listaCategoria = await _dbtest2Context.TmCategoria.ToListAsync();
                return listaCategoria;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<TmCategorium> Get(int id)
        {
            try
            {
                TmCategorium? categoria = new TmCategorium();
                categoria = await _dbtest2Context.TmCategoria.Where(e=> e.CatId == id).FirstOrDefaultAsync();

                return categoria;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<TmCategorium> Add(TmCategorium modelo)
        {
            try
            {
                _dbtest2Context.Add(modelo);
                await _dbtest2Context.SaveChangesAsync();

                return modelo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> Update(TmCategorium modelo)
        {
            try
            {
                _dbtest2Context.Update(modelo);
                await _dbtest2Context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> Delete(TmCategorium modelo)
        {
            try
            {
                _dbtest2Context.TmCategoria.Remove(modelo);
                await _dbtest2Context.SaveChangesAsync(); 
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

       

       

        
    }
}
