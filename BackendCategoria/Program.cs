using BackendCategoria.Models;
using Microsoft.EntityFrameworkCore;
using BackendCategoria.Services.Contrato;
using BackendCategoria.Services.Implementacion;
using AutoMapper;
using BackendCategoria.DTOs;
using BackendCategoria.Utilidades;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Dbtest2Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"));
});

builder.Services.AddScoped<ITipoService, TipoService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddCors(options =>
{

    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



#region PETICIONES API REST

app.MapGet("/tipo/lista", async(
    ITipoService _tipoService,
    IMapper _mapper
    ) =>
{
    var listaTipo = await _tipoService.GetList();
    var listaTipoDTO = _mapper.Map<List<TmTipoDTO>>(listaTipo);

    if (listaTipoDTO.Count > 0)
    {
        return Results.Ok(listaTipoDTO);
    }
    else
    { 
        return Results.NotFound();
    }
});

app.MapGet("/categoria/lista", async (
    ICategoriaService _categoriaService,
    IMapper _mapper
    ) =>
{
    var listaCategoria = await _categoriaService.GetList();
    var listaCategoriaDTO = _mapper.Map<List<TmCategoriumDTO>>(listaCategoria);

    if (listaCategoriaDTO.Count > 0)
    {
        return Results.Ok(listaCategoriaDTO);
    }
    else
    {
        return Results.NotFound();
    }
});


app.MapPost("/categoria/guardar", async (
    TmCategoriumDTO modelo,
      ICategoriaService _categoriaService,
      IMapper _mapper
    ) => { 
        var _categoria = _mapper.Map<TmCategorium>(modelo);
        var _categoriaCreado = await _categoriaService.Add(_categoria);

        if (_categoriaCreado.CatId != 0)
        {
            return Results.Ok(_mapper.Map<TmCategoriumDTO>(_categoriaCreado));
        }
        else 
        { 
            return Results.StatusCode(StatusCodes.Status500InternalServerError); 
        }
});
app.MapPut("/categoria/actualizar/{id}", async (

    int id,
    TmCategoriumDTO modelo,
      ICategoriaService _categoriaService,
      IMapper _mapper
    ) => {

        var _encontrado = await _categoriaService.Get(id);

        if(_encontrado is null) 
        {
            return Results.NotFound();
        }

        var _categoria = _mapper.Map<TmCategorium>(modelo);

        _encontrado.CatMon = _categoria.CatMon;
        _encontrado.CatObs = _categoria.CatObs;
        _encontrado.CatFec = _categoria.CatFec;
        _encontrado.CatTipo = _categoria.CatTipo;

        var respuesta = await _categoriaService.Update(_encontrado);

        if (respuesta)
        {
            return Results.Ok(_mapper.Map<TmCategoriumDTO>(_encontrado));
        }
        else {
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
        }

    });


app.MapDelete("/categoria/eliminar/{id}", async (
    int id,
     ICategoriaService _categoriaService
    ) =>{

        var _encontrado = await _categoriaService.Get(id);

        if (_encontrado is null)
        {
            return Results.NotFound();
        }

        var respuesta = await _categoriaService.Delete(_encontrado);

        if (respuesta)
        {
            return Results.Ok();
        }
        else
        {
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
        }

    });


#endregion

app.UseCors("NuevaPolitica");
app.Run();

