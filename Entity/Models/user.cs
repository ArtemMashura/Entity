﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity.Models;

[Keyless]
public partial class user
{
    public int? id { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string name { get; set; }
}