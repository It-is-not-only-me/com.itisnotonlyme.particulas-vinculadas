using UnityEngine;
using ItIsNotOnlyMe.ParticulasVinculadas;

public class ResultadoPrueba : IResultado
{
    public Vector3 Valor;

    public ResultadoPrueba(Vector3 valor)
    {
        Valor = valor;
    }
}
