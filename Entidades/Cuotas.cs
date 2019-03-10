using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Cuotas
    {
        [Key]
        public int NCuota { get; set; }
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Interes { get; set; }
        public decimal Capital { get; set; }
        public decimal Bce { get; set; }
        public decimal Monto { get; set; }

        [ForeignKey("Id")]
        public virtual Prestamos Prestamo { get; set; }

        public Cuotas()
        {
            NCuota = 0;
            Id = 0;
            Fecha = DateTime.Now;
            Interes = 0;
            Capital = 0;
            Bce = 0;
            Monto = 0;

        }

        public Cuotas( int nCuota, int id, DateTime fecha, decimal interes, decimal capital, decimal bce,decimal monto)
        {

            this.NCuota = nCuota;
            this.Id = id;
            this.Fecha = fecha;
            this.Interes = interes;
            this.Capital = capital;
            this.Bce = bce;
            this.Monto = monto;

        }
    }
}
