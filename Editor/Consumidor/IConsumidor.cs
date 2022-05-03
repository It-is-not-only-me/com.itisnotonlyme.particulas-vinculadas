using System.Collections;
using UnityEngine;

namespace ItIsNotOnlyMe.SistemaDePociones
{
    public interface IConsumidor : IDemandado
    {
        public void Consumir(Pocion pocion);

        public bool EnCondicionesParaSeguir();

        public bool Evaluacion();
    }
}
