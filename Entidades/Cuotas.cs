using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cuotas
    {
        [Key]
        public int Id { get; set; }
        public int NCuota { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Interes { get; set; }
        public decimal Capital { get; set; }
        public decimal Bce { get; set; }

        [ForeignKey("IdPrestamo")]
        public virtual Prestamos Prestamo { get; set; }

        public Cuotas()
        {
            Id = 0;
            NCuota = 0;
            Fecha = DateTime.Now;
            Interes = 0;
            Capital = 0;
            Bce = 0;

        }

        public Cuotas(int id, int nCuota, DateTime fecha, decimal interes, decimal capital, decimal bce)
        {
            this.Id = id;
            this.NCuota = nCuota;
            this.Fecha = fecha;
            this.Interes = interes;
            this.Capital = capital;
            this.Bce = bce;

        }
    }
}
