using System;
using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AplicadaIIprimerParcial.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Guardar()
        {
            RepositorioBase<CuentasBancarias> repositorio = new RepositorioBase<CuentasBancarias>();
            CuentasBancarias cuentab = new CuentasBancarias();
            bool paso = false;

            cuentab.CuentaId = 7;
            cuentab.Fecha = DateTime.Now;
            cuentab.Nombre = "Maria";
            cuentab.Balance = 200;

            paso = repositorio.Guardar(cuentab);
            Assert.AreEqual(true, paso);
        }
        [TestMethod]
        public void Modificar()
        {
            RepositorioBase<CuentasBancarias> repositorio = new RepositorioBase<CuentasBancarias>();
            CuentasBancarias cuentab = new CuentasBancarias();
            bool paso = false;

            cuentab.CuentaId = 7;
            cuentab.Fecha = DateTime.Now;
            cuentab.Nombre = "Jose";
            cuentab.Balance = 300;

            paso = repositorio.Modificar(cuentab);
            Assert.AreEqual(true, paso);
        }
    }
}
