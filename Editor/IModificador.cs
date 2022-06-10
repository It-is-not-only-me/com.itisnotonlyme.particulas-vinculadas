namespace ItIsNotOnlyMe.SistemaDePosiones
{
    public interface IModificador
    {
        public IResultado Modificar(IResultado anterior);
    }
}