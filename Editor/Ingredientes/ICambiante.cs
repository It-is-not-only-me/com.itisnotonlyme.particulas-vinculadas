namespace ItIsNotOnlyMe.SistemaDePociones
{
    public interface ICambiante
    {
        public void AgregarModificador(ICambiar modificador);

        public void SacarModificador(ICambiar modificador);
    }
}