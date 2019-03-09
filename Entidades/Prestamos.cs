using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Prestamos
    {
        [Key]
        public int PrestamoId { get; set; }
        public DateTime Fecha { get; set; }
        public int IdCuenta { get; set; }
        public decimal Capital { get; set; }
        public decimal InteresAnual { get; set; }
        public int TiempoMeses { get; set; }

        public virtual List<Cuotas>  Detalle { get; set; }

        public Prestamos()
        {
            PrestamoId = 0;
            Fecha = DateTime.Now;
            IdCuenta = 0;
            Capital = 0;
            InteresAnual = 0;
            TiempoMeses = 0;
            this.Detalle = new List<Cuotas>();

        }

        public void AgregarDetalle(int id, int nCuota, DateTime fecha, decimal interes, decimal capital, decimal bce)
        {
            this.Detalle.Add(new Cuotas(id, nCuota, fecha, interes, capital, bce));
        }

    }
}
