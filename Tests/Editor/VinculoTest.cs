using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using ItIsNotOnlyMe.ParticulasVinculadas;

public class VinculoTest
{
    IResultado _resultadoNulo = new ResultadoPrueba(Vector3.zero);
    IResultado _resultadoPositivo = new ResultadoPrueba(Vector3.one);
    IResultado _resultadoNegativo = new ResultadoPrueba(-Vector3.one);

    [Test]
    public void Test01VinculoEntreDosParticulassinCondicionesEsEstable()
    {
        IAtomo atomo = new Atomo(_resultadoNulo);
        IAtomo atomoVinculante = new Atomo(_resultadoNulo);

        IVinculo vinculo = new Vinculo(atomo, atomoVinculante);

        Assert.IsTrue(vinculo.EsEstable());
    }

    [Test]
    public void Test02VinculoEntreDosParticulasEsEstable()
    {
        ICondicion condicion = new CondicionMenorPrueba(0);

        IAtomo atomoVinculante = new Atomo(_resultadoNegativo);
        IAtomo atomoDePrueba = new Atomo(_resultadoNulo, new List<ICondicion> { condicion });

        IVinculo vinculoDePrueba = new Vinculo(atomoVinculante, atomoDePrueba);

        Assert.IsTrue(vinculoDePrueba.EsEstable());
    }

    [Test]
    public void Test03VinculoEntreDosParticulasSeVuelveInestableAlCrearOtroVinculo()
    {
        ICondicion condicion = new CondicionMenorPrueba(0);

        IAtomo atomoVinculante = new Atomo(_resultadoNegativo);
        IAtomo atomoPerturbador = new Atomo(_resultadoNulo);
        IAtomo atomoDePrueba = new Atomo(_resultadoNulo, new List<ICondicion> { condicion });

        IVinculo vinculoDePrueba = new Vinculo(atomoVinculante, atomoDePrueba);

        float factorDeSuma = 2;
        IModificador modificador = new ModificadorSumaPrueba(factorDeSuma);
        IVinculo vinculoModificador = new Vinculo(atomoVinculante, atomoPerturbador, new List<IModificador> { modificador });

        Assert.IsTrue(vinculoDePrueba.EsEstable());

        atomoVinculante.EstablecerVinculo(vinculoModificador);

        Assert.IsFalse(vinculoDePrueba.EsEstable());
    }
}
