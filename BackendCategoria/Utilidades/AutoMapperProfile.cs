using AutoMapper;
using BackendCategoria.DTOs;
using BackendCategoria.Models;
using System.Globalization;

namespace BackendCategoria.Utilidades
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            #region Tipo
                CreateMap<TmTipo,TmTipoDTO>().ReverseMap();
            #endregion

            #region Categoria
            CreateMap<TmCategorium, TmCategoriumDTO>().ReverseMap();
           
            #endregion
        }
    }
}
