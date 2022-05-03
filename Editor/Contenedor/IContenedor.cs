namespace ItIsNotOnlyMe.SistemaDePociones
{
    public interface IContenedor
    {
        public void AgregarElemento(IElemento elemento);

        public void AgregarPocion(Pocion pocion);

        public void Mezclar(IElemento elemento1, IElemento elemento2);

        public Pocion CrearPocion();
    }
}
