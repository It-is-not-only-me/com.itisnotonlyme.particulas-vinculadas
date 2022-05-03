using System.Collections.Generic;
using ItIsNotOnlyMe.VectorDinamico;

namespace ItIsNotOnlyMe.SistemaDePociones
{
    public class Consumidor : IConsumidor
    {
        private Vector _estadoInicial;
        private List<Pocion> _pociones;
        private List<IRequisito> _requisitosSobrevivir, _requisitosSatisfaccion;

        public Consumidor(Vector estadoInicial,
                          List<IRequisito> requisitosSobrevivir = null,
                          List<IRequisito> requisitosSatisfaccion = null)
        {
            _estadoInicial = estadoInicial;

            if (requisitosSobrevivir == null)
                requisitosSobrevivir = new List<IRequisito>();
            _requisitosSobrevivir = requisitosSobrevivir;

            if (requisitosSatisfaccion == null)
                requisitosSatisfaccion = new List<IRequisito>();
            _requisitosSatisfaccion = requisitosSatisfaccion;

            _pociones = new List<Pocion>();
        }

        public void Consumir(Pocion pocion)
        {
            _pociones.Add(pocion);
        }

        public bool EnCondicionesParaSeguir()
        {
            return _requisitosSobrevivir.TrueForAll(requisito => requisito.Evaluar(this));
        }

        public bool Evaluacion()
        {
            return _requisitosSatisfaccion.TrueForAll(requisito => requisito.Evaluar(this));
        }

        public float ObtenerValor(IIdentificador identificador)
        {
            EstadoModificado(out Vector estado);
            return estado.ProductoInterno(new Vector(new Componente(identificador, 1)));
        }

        private void EstadoModificado(out Vector resultado)
        {
            resultado = Vector.Nulo();
            resultado.Sumar(_estadoInicial);
            foreach (Pocion pocion in _pociones)
                pocion.Agregar(ref resultado);
        }
    }
}
