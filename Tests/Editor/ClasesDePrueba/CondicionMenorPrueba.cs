using ItIsNotOnlyMe.ParticulasVinculadas;

public class CondicionMenorPrueba : ICondicion
{
    private float _valorMaximo;

    public CondicionMenorPrueba(float valorMaximo)
    {
        _valorMaximo = valorMaximo;
    }

    public bool EsValido(IAtomo atomo)
    {
        ResultadoPrueba resultado = atomo.ResultadoFinal() as ResultadoPrueba;
        bool esValido = true;
        for (int i = 0; i < 3; i++)
            esValido &= resultado.Valor[i] < _valorMaximo;
        return esValido;
    }
}
