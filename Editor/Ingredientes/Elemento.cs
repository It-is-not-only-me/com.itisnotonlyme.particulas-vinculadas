using System.Collections.Generic;
using ItIsNotOnlyMe.VectorDinamico;

namespace ItIsNotOnlyMe.SistemaDePociones
{
    public class Elemento : IElemento
    {
        private List<IVinculo> _vinculos;

        private List<ICondicionDeVinculo> _condiciones;
        private List<ICambiar> _modificadores;

        private Vector _atributosBase;

        public Elemento(Vector atributosBase,
                           List<ICondicionDeVinculo> condiciones = null)
        {
            _vinculos = new List<IVinculo>();

            _condiciones = (condiciones == null) ? new List<ICondicionDeVinculo>() : condiciones;
            _modificadores = new List<ICambiar>();

            _atributosBase = atributosBase;
        }

        public void Agregar(ref Vector atributos)
        {
            Estabilidad();
            Vector modificado = AtributoBaseModificado();
            atributos.Sumar(modificado);
        }

        private Vector AtributoBaseModificado()
        {
            Vector nuevo = _atributosBase;
            _modificadores.ForEach(modificador => nuevo = modificador.Modificar(nuevo));
            return nuevo;
        }

        public void CrearVinculo(IVinculo vinculo)
        {
            _vinculos.Add(vinculo);
        }

        public void RomperVinculo(IVinculo vinculo)
        {
            _vinculos.Remove(vinculo);
        }

        public float ObtenerValor(IIdentificador identificador)
        {
            Vector atributos = AtributoBaseModificado();
            return atributos.ProductoInterno(new Vector(new Componente(identificador, 1)));
        }

        public void AgregarModificador(ICambiar modificador)
        {
            _modificadores.Add(modificador);
        }

        public void SacarModificador(ICambiar modificador)
        {
            _modificadores.Remove(modificador);
        }

        public bool HayVinculo(IElemento elemento)
        {
            return _vinculos.Exists(vinculo => vinculo.HayVinculo(elemento));
        }

        public ICondicionDeVinculo EncontrarCondicion(IElemento elemento)
        {
            return _condiciones.Find(condicion => condicion.Evaluar(this, elemento));
        }

        public bool PermiteVinculoCon(IVinculado vinculado)
        {
            return _condiciones.Exists(condicion => condicion.Evaluar(this, vinculado));
        }

        public void Estabilidad()
        {
            List<IVinculo> vinculosNoEstables = _vinculos.FindAll(vinculo => !vinculo.Estable());
            vinculosNoEstables.ForEach(vinculo => vinculo.RomperVinculo());
        }

        public bool Unirse(IElemento elemento)
        {
            if (HayVinculo(elemento) || elemento.HayVinculo(this))
                return false;

            Estabilidad();
            elemento.Estabilidad();

            IVinculo vinculo;
            ICondicionDeVinculo condicion;

            if (PermiteVinculoCon(elemento))
            {
                condicion = EncontrarCondicion(elemento);
                vinculo = (IVinculo)new Vinculo(this, elemento, condicion);
            }
            else if (elemento.PermiteVinculoCon(this))
            {
                condicion = elemento.EncontrarCondicion(this);
                vinculo = (IVinculo)new Vinculo(elemento, this, condicion);
            }
            else
            {
                return false;
            }

            CrearVinculo(vinculo);
            elemento.CrearVinculo(vinculo);

            return true;
        }
    }
}