using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItIsNotOnlyMe.VectorDinamico;

namespace ItIsNotOnlyMe.PotionSystem
{
    public class Pocion : IResultado, IEnumerable
    {
        private List<IElemento> _elementos;

        public Pocion(List<IElemento> elementos)
        {
            _elementos = new List<IElemento>();
            if (elementos == null)
                elementos = new List<IElemento>();
            elementos.ForEach(elemento => _elementos.Add(elemento));
        }

        public Pocion()
            : this(new List<IElemento>())
        {
        }

        public IEnumerator GetEnumerator()
        {
            foreach (IElemento elemento in _elementos)
                yield return elemento;
        }

        public void Agregar(ref Vector atributos)
        {
            foreach (IElemento elemento in _elementos)
                elemento.Agregar(ref atributos);
        }

        public float Distancia(IResultado resultado)
        {
            return resultado.Distancia(EstadoActual());
        }

        public float Distancia(Vector atributos)
        {
            return MathfVectores.Distancia(EstadoActual(), atributos);
        }

        public float Similitud(IResultado resultado)
        {
            return resultado.Similitud(EstadoActual());
        }

        public float Similitud(Vector atributos)
        {
            return MathfVectores.Similitud(EstadoActual(), atributos);
        }

        public float Multiplicidad(IResultado resultado)
        {
            return resultado.Multiplicidad(EstadoActual());
        }

        public float Multiplicidad(Vector atributos)
        {
            return MathfVectores.Multiplicdad(EstadoActual(), atributos);
        }

        private Vector EstadoActual()
        {
            Vector vector = Vector.Nulo();
            Agregar(ref vector);
            return vector;

        }
    }
}
