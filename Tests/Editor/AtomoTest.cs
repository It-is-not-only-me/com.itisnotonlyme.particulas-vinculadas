using System.Collections;
using System.Collections.Generic;
using ItIsNotOnlyMe.ParticulasVinculadas;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class AtomoTest
{
    IResultado _resultadoNulo = new ResultadoPrueba(Vector3.zero);
    IResultado _resultadoPositivo = new ResultadoPrueba(Vector3.one);
    IResultado _resultadoNegativo = new ResultadoPrueba(-Vector3.one);

    [Test]
    public void Test01AtomoSinVinculosYUnEstadoInternoNuloSuResultadoFinalTambienEsNulo()
    {
        IAtomo atomo = new Atomo(_resultadoNulo);

        ResultadoPrueba resultado = atomo.ResultadoFinal() as ResultadoPrueba;

        Assert.AreEqual(Vector3.zero, resultado.Valor);
    }

    [Test]
    public void Test02AtomoSinVinculosPuedeTenerVinculoConUnAtomoAlNoTenerCondicionesPuedeCrearVinculo()
    {
        IAtomo atomo = new Atomo(_resultadoNulo), atomoVinculante = new Atomo(_resultadoNulo);

        Assert.IsTrue(atomo.PermiteCrearVinculo(atomoVinculante));
    }

    [Test]
    public void Test03AtomoSinVinculosConUnaCondicionDeMayorParaUnAtomoConUnEstadoInternoNegativoNoPuedeCrearVinculo()
    {
        ICondicion condicion = new CondicionMayorPrueba(0);
        IAtomo atomo = new Atomo(_resultadoNulo, new List<ICondicion> { condicion });
        IAtomo atomoVinculante = new Atomo(_resultadoNegativo);

        Assert.IsFalse(atomo.PermiteCrearVinculo(atomoVinculante));
    }

    [Test]
    public void Test04AtomoSinVinculosConUnaCondicionDeMenorParaUnAtomoConUnEstadoInternoNegativoSePuedeCrearVinculo()
    {
        ICondicion condicion = new CondicionMenorPrueba(0);
        IAtomo atomo = new Atomo(_resultadoNulo, new List<ICondicion> { condicion });
        IAtomo atomoVinculante = new Atomo(_resultadoNegativo);

        Assert.IsTrue(atomo.PermiteCrearVinculo(atomoVinculante));
    }

    [Test]
    public void Test05AtomoConVinculoSuResultadoFinalEsElEstadoInternoSiElOtroAtomoNoTieneModificadores()
    {
        IAtomo atomo = new Atomo(_resultadoNulo);
        IAtomo atomoVinculante = new Atomo(_resultadoNulo);

        IVinculo vinculo = new Vinculo(atomo, atomoVinculante);

        atomo.EstablecerVinculo(vinculo);

        ResultadoPrueba resultado = atomo.ResultadoFinal() as ResultadoPrueba;

        Assert.AreEqual(Vector3.zero, resultado.Valor);
    }

    [Test]
    public void Test06AtomoConVinculoSuResultadoFinalEsLaSumaDeLosEstadosInternosConElOtroAtomoTeniendoUnModificadorDeSuma()
    {
        IAtomo atomo = new Atomo(_resultadoNulo);
        IAtomo atomoVinculante = new Atomo(_resultadoNulo);

        float factorDeSuma = 2;
        IModificador modificador = new ModificadorSumaPrueba(factorDeSuma);
        IVinculo vinculo = new Vinculo(atomo, atomoVinculante, new List<IModificador> { modificador });

        atomo.EstablecerVinculo(vinculo);

        ResultadoPrueba resultado = atomo.ResultadoFinal() as ResultadoPrueba;

        Assert.AreEqual(Vector3.one * factorDeSuma, resultado.Valor);
    }

    [Test]
    public void Test07AtomoSinVinculoPermiteUnirsePeroAlCrearVinculoYaNoPermiteUnirse()
    {
        ICondicion condicion = new CondicionMenorPrueba(0);

        IAtomo atomoVinculante = new Atomo(_resultadoNegativo);
        IAtomo atomoPerturbador = new Atomo(_resultadoNulo);
        IAtomo atomoDePrueba = new Atomo(_resultadoNulo, new List<ICondicion> { condicion });

        float factorDeSuma = 2;
        IModificador modificador = new ModificadorSumaPrueba(factorDeSuma);
        IVinculo vinculo = new Vinculo(atomoVinculante, atomoPerturbador, new List<IModificador> { modificador });

        Assert.IsTrue(atomoDePrueba.PermiteCrearVinculo(atomoVinculante));

        atomoVinculante.EstablecerVinculo(vinculo);

        Assert.IsFalse(atomoDePrueba.PermiteCrearVinculo(atomoVinculante));
    }
}
