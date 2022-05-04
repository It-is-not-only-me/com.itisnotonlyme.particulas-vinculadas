using ItIsNotOnlyMe.VectorDinamico;

public class IdentificadorPrueba : IIdentificador
{
    private static int _contador = 0;

    public int ID => _id;
    private int _id;

    public IdentificadorPrueba()
    {
        _id = _contador;
        _contador++;
    }

    public bool EsIgual(IIdentificador identificador)
    {
        return ID == ((IdentificadorPrueba)identificador).ID;
    }
}
