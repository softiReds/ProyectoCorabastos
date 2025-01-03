﻿using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CorabastosAPI.Models;

public class Ciudad
{
    public Guid CiudadId { get; set; }
    public string CiudadNombre { get; set; }

    [JsonIgnore] [ValidateNever] public virtual ICollection<Usuario> Usuarios { get; set; }
}