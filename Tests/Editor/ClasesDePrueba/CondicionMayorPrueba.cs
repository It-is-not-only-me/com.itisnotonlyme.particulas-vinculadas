using ItIsNotOnlyMe.SistemaDePosiones;

public class CondicionMayorPrueba : ICondicion
{
    private float _valorMinimo;

    public CondicionMayorPrueba(float valorMinimo)
    {
        _valorMinimo = valorMinimo;
    }

    public bool EsValido(IAtomo atomo)
    {
        ResultadoPrueba resultado = atomo.ResultadoFinal() as ResultadoPrueba;
        bool esValido = true;
        for (int i = 0; i < 3; i++)
            esValido &= resultado.Valor[i] > _valorMinimo;
        return esValido;
    }
}
