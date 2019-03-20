﻿using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Contexto : DbContext
    {
        public DbSet<CuentasBancarias> cuentasBancarias { get; set; }
        public DbSet<Depositos> depositos { get; set; }
        public DbSet<Prestamos> prestamos { get; set; }
        public DbSet<Cuotas> cuotas { get; set; }

        public Contexto() : base("ConStr")
        {

        }
    }
}
