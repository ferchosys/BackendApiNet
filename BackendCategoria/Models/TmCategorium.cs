using System;
using System.Collections.Generic;

namespace BackendCategoria.Models;

public partial class TmCategorium
{
    public int CatId { get; set; }

    public string? CatMon { get; set; }

    public string? CatObs { get; set; }

    public DateTime? CatFec { get; set; }

    public string? CatTipo { get; set; }
}
