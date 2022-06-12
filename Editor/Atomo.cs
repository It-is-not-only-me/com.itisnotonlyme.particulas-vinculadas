using System.Collections.Generic;

namespace ItIsNotOnlyMe.ParticulasVinculadas
{
    public class Atomo : IAtomo
    {
        private List<ICondicion> _condiciones;
        private List<IVinculo> _vinculos;
        private IResultado _estadoInicial;

        public Atomo(IResultado estadoInicial, List<ICondicion> condiciones = null)
        {
            _condiciones = (condiciones == null) ? new List<ICondicion>() : condiciones;
            _estadoInicial = estadoInicial;
            _vinculos = new List<IVinculo>();
        }

        public void EstablecerVinculo(IVinculo vinculo)
        {
            _vinculos.Add(vinculo);
        }

        public void RomperVinculo(IVinculo vinculo)
        {
            _vinculos.Remove(vinculo);
        }

        public bool PermiteCrearVinculo(IAtomo atomo)
        {
            bool sePermiteVincular = true;
            _condiciones.ForEach(condicion => sePermiteVincular &= condicion.EsValido(atomo));
            return sePermiteVincular;
        }

        public IResultado ResultadoFinal()
        {
            IResultado resultado = _estadoInicial;
            _vinculos.ForEach(vinculo => resultado = vinculo.ModificarEstado(resultado));
            return resultado;
        }
    }
}