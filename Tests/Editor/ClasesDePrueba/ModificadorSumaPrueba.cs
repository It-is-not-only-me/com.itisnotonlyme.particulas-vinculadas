using ItIsNotOnlyMe.SistemaDePosiones;
using UnityEngine;

public class ModificadorSumaPrueba : IModificador
{
    private float _suma;

    public ModificadorSumaPrueba(float suma)
    {
        _suma = suma;
    }

    public IResultado Modificar(IResultado anterior)
    {
        ResultadoPrueba resultado = anterior as ResultadoPrueba;
        Vector3 vectorResultado = resultado.Valor + Vector3.one * _suma;
        return new ResultadoPrueba(vectorResultado);
    }
}
