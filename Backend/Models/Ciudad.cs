﻿using System.Text.Json.Serialization;

namespace CorabastosAPI.Models;

public class Ciudad
{
    public Guid CiudadId { get; set; }
    public string CiudadNombre { get; set; }
    
    public virtual ICollection<Usuario> Usuarios { get; set; }
}