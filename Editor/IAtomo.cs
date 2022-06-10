using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe.SistemaDePosiones
{
    public interface IAtomo
    {
        public void AgregarCondicion(ICondicion condicion);

        public bool PermiteCrearVinculo(IAtomo atomo);

        public void EstablecerVinculo(IVinculo vinculo);

        public void RomperVinculo(IVinculo vinculo);
    }

    public interface IVinculo
    {
        public bool EsEstable();

        public void RomperVinculo(); // puede ser que no sea necesario
    }

    public interface ICondicion
    {
        public bool EsValido(IAtomo atomo);
    }

    public interface IModificador
    {
        public IResultado Modificar(IResultado anterior);
    }

    public interface IResultado
    {

    }
}