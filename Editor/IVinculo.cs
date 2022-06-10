namespace ItIsNotOnlyMe.SistemaDePosiones
{
    public interface IVinculo
    {
        public bool EsEstable();

        public IResultado ModificarEstado(IResultado resultado);
    }
}