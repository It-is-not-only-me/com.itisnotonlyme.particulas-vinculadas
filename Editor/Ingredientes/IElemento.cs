using ItIsNotOnlyMe.VectorDinamico;

namespace ItIsNotOnlyMe.PotionSystem
{
    public interface IElemento : IDemandado, ICambiante, IVinculado
    {
        public void Agregar(ref Vector vector);

        public void Estabilidad();

        public bool HayVinculo(IElemento elemento);

        public ICondicionDeVinculo EncontrarCondicion(IElemento elemento);

        public bool Unirse(IElemento elemento);
    }
}