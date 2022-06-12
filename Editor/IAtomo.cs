using System.Collections;
using UnityEngine;

namespace ItIsNotOnlyMe.ParticulasVinculadas
{
    public interface IAtomo
    {
        public bool PermiteCrearVinculo(IAtomo atomo);

        public void EstablecerVinculo(IVinculo vinculo);

        public void RomperVinculo(IVinculo vinculo);

        public IResultado ResultadoFinal();
    }
}