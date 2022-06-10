using System.Collections.Generic;

namespace ItIsNotOnlyMe.SistemaDePosiones
{
    public class Vinculo : IVinculo
    {
        private List<IModificador> _modificadores;
        private IAtomo _atomoPrincipal, _atomoSecundario;

        public Vinculo(IAtomo atomoPrincipa, IAtomo atomoSecundario, List<IModificador> modificadores = null)
        {
            _modificadores = (modificadores == null) ? new List<IModificador>() : modificadores;
            _atomoPrincipal = atomoPrincipa;
            _atomoSecundario = atomoSecundario;
        }

        public bool EsEstable()
        {
            return EsEstableParaAtomo(_atomoPrincipal) && EsEstableParaAtomo(_atomoSecundario);
        }

        private bool EsEstableParaAtomo(IAtomo atomo)
        {
            _atomoPrincipal.RomperVinculo(this);
            if (_atomoPrincipal.PermiteCrearVinculo(_atomoSecundario))
            {
                _atomoPrincipal.EstablecerVinculo(this);
                return false;
            }
            return true;
        }

        public IResultado ModificarEstado(IResultado resultado)
        {
            _modificadores.ForEach(modificador => resultado = modificador.Modificar(resultado));
            return resultado;
        }
    }
}