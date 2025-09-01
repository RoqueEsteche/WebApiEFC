using System;
using System.Collections.Generic;

namespace WebApiDatabaseFirst.Models;

public partial class Alumno
{
    public long Id { get; set; }

    public string NroDocumento { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;
}
