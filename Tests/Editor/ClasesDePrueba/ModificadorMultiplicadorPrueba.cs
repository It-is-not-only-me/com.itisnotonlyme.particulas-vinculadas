using ItIsNotOnlyMe.ParticulasVinculadas;
using UnityEngine;

public class ModificadorMultiplicadorPrueba : IModificador
{
    private float _multiplicador;

    public ModificadorMultiplicadorPrueba(float multiplicador)
    {
        _multiplicador = multiplicador;
    }

    public IResultado Modificar(IResultado anterior)
    {
        ResultadoPrueba resultado = anterior as ResultadoPrueba;
        Vector3 vectorResultado = resultado.Valor * _multiplicador;
        return new ResultadoPrueba(vectorResultado);
    }
}
