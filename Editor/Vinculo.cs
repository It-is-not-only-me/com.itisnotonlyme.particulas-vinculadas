using System.Collections.Generic;

namespace ItIsNotOnlyMe.ParticulasVinculadas
{
    public class Vinculo : IVinculo
    {
        private List<IModificador> _modificadores;
        private List<IAtomo> _atomos;

        public Vinculo(IAtomo atomoPrincipal, IAtomo atomoSecundario, List<IModificador> modificadores = null)
        {
            _modificadores = (modificadores == null) ? new List<IModificador>() : modificadores;
            _atomos = new List<IAtomo> { atomoPrincipal, atomoSecundario };
        }

        public bool EsEstable()
        {
            return _atomos.TrueForAll(atomo => EsEstableParaAtomo(atomo));
        }

        private bool EsEstableParaAtomo(IAtomo atomo)
        {
            bool esEstable = true;
            atomo.RomperVinculo(this);

            foreach (IAtomo atomoVinculado in _atomos)
                if (atomo != atomoVinculado && !atomo.PermiteCrearVinculo(atomoVinculado))
                    esEstable = false;

            atomo.EstablecerVinculo(this);
            return esEstable;
        }

        public IResultado ModificarEstado(IResultado resultado)
        {
            _modificadores.ForEach(modificador => resultado = modificador.Modificar(resultado));
            return resultado;
        }
    }
}