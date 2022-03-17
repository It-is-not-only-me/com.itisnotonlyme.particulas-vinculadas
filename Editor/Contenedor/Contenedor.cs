using System.Collections.Generic;
using ItIsNotOnlyMe.VectorDinamico;

namespace ItIsNotOnlyMe.PotionSystem
{
    public class Contenedor : IContenedor
    {
        private List<IElemento> _elementos;
        private List<ICambiar> _modificadores;

        public Contenedor(List<ICambiar> modificadores = null)
        {
            _elementos = new List<IElemento>();

            if (modificadores == null)
                modificadores = new List<ICambiar>();
            _modificadores = modificadores;
        }

        public void AgregarElemento(IElemento elemento)
        {
            _modificadores.ForEach(modificador => elemento.AgregarModificador(modificador));
            _elementos.Add(elemento);
        }

        public void AgregarPocion(Pocion pocion)
        {
            foreach (IElemento elemento in pocion)
                AgregarElemento(elemento);
        }

        public void Mezclar(IElemento elemento1, IElemento elemento2)
        {
            if (_elementos.Contains(elemento1) && _elementos.Contains(elemento2))
                elemento1.Unirse(elemento2);
        }

        public Pocion CrearPocion()
        {
            if (Vacio())
                return new Pocion();

            Pocion pocion = new Pocion(_elementos);
            _elementos.Clear();
            return pocion;
        }

        private bool Vacio()
        {
            return _elementos.Count == 0;
        }
    }
}
