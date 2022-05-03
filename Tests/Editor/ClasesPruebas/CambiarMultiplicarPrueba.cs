using ItIsNotOnlyMe.SistemaDePociones;
using ItIsNotOnlyMe.VectorDinamico;

public class CambiarMultiplicarPrueba : ICambiar
{
    private float _valorMultiplicar;
    private IIdentificador _identificador;

    public CambiarMultiplicarPrueba(float valorMultiplicar, IIdentificador identificador)
    {
        _valorMultiplicar = valorMultiplicar;
        _identificador = identificador;
    }

    public void Cambiar(ICambiante cambiante)
    {
        cambiante.AgregarModificador(this);
    }

    public Vector Modificar(Vector atributos)
    {
        return MathfVectores.Multiplicar(atributos, _valorMultiplicar, _identificador);
    }
}
