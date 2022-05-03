using System.Collections.Generic;
using NUnit.Framework;
using ItIsNotOnlyMe.SistemaDePociones;
using ItIsNotOnlyMe.VectorDinamico;
using UnityEngine;
using UnityEngine.TestTools.Utils;

public class ContenedorTest
{
    private IIdentificador _vida, _temp, _vel;

    public ContenedorTest()
    {
        _vida = new IdentificadorPrueba();
        _temp = new IdentificadorPrueba();
        _vel = new IdentificadorPrueba();
    }

    private Vector CrearVector(float valorVida, float valorTemp, float valorVel)
    {
        Vector atributo = new Vector(new List<IComponente>
        {
            new Componente(_vida, valorVida), new Componente(_temp, valorTemp), new Componente(_vel, valorVel)
        });
        return atributo;
    }

    [Test]
    public void Test01UnContenedorSinIngredientesDaUnaPosionIgualAlEstadoInicial()
    {
        IContenedor contenedor = new Contenedor();
        ResultadoPrueba pocionEsperada = new ResultadoPrueba(Vector.Nulo());

        Pocion pocionResultado = contenedor.CrearPocion();

        FloatEqualityComparer comparador = new FloatEqualityComparer(10e-3f);
        Assert.That(pocionEsperada.Similitud(pocionResultado), Is.EqualTo(0f).Using(comparador));
        Assert.That(pocionEsperada.Multiplicidad(pocionResultado), Is.EqualTo(0f).Using(comparador));
    }

    [Test]
    public void Test02UnContenedorConUnIngredienteDaUnaPosicionIgualAlEstadoInicialMasElEstadoDelIngrediente()
    {
        
        float valorVida = 4f, valorTemp = 3f, valorVel = 5f;
        Vector atributo = CrearVector(valorVida, valorTemp, valorVel);
        IElemento ingrediente =  new Elemento(atributo);

        ResultadoPrueba pocionEsperada = new ResultadoPrueba(atributo);
        IContenedor contenedor = new Contenedor();
        contenedor.AgregarElemento(ingrediente);

        Pocion pocionResultado = contenedor.CrearPocion();

        FloatEqualityComparer comparador = new FloatEqualityComparer(10e-3f);
        Assert.That(pocionEsperada.Similitud(pocionResultado), Is.EqualTo(1f).Using(comparador));
        Assert.That(pocionEsperada.Multiplicidad(pocionResultado), Is.EqualTo(1f).Using(comparador));
    }

    [Test]
    public void Test03UnContenedorConDosIngredientesNoVinculadosEsComoSumarSusEstados()
    {
        float valorVida1 = 4f, valorTemp1 = 3f, valorVel1 = 5f;
        Vector atributo1 = CrearVector(valorVida1, valorTemp1, valorVel1);
        IElemento ingrediente1 = new Elemento(atributo1);

        float valorVida2 = 4f, valorTemp2 = 3f, valorVel2 = 5f;
        Vector atributo2 = CrearVector(valorVida2, valorTemp2, valorVel2);
        IElemento ingrediente2 = new Elemento(atributo2);

        IContenedor contenedor = new Contenedor();

        contenedor.AgregarElemento(ingrediente1);
        contenedor.AgregarElemento(ingrediente2);

        ResultadoPrueba pocionEsperada = new ResultadoPrueba(MathfVectores.Sumar(atributo1, atributo2));
        Pocion pocionResultado = contenedor.CrearPocion();

        FloatEqualityComparer comparador = new FloatEqualityComparer(10e-3f);
        Assert.That(pocionEsperada.Similitud(pocionResultado), Is.EqualTo(1f).Using(comparador));
        Assert.That(pocionEsperada.Multiplicidad(pocionResultado), Is.EqualTo(1f).Using(comparador));
    }

    [Test] 
    public void Test04UnContenedorConDosIngredientesVinculadosEsLaSumaDeSusEstadosModificados()
    {
        float multiplicador = 2f;
        ICambiar modificador = new CambiarMultiplicarPrueba(multiplicador, _vida);

        IRequisito requisito = new RequisitoValidoPrueba();

        List<ICondicionDeVinculo> condiciones = new List<ICondicionDeVinculo>
            { new CondicionDeVinculoPrueba(requisito, modificador) };

        float valorVida1 = 5f, valorTemp1 = 3f, valorVel1 = 4f;
        Vector atributo1 = CrearVector(valorVida1, valorTemp1, valorVel1);
        IElemento ingrediente1 = new Elemento(atributo1, condiciones);

        float valorVida2 = 4f, valorTemp2 = 3f, valorVel2 = 5f;
        Vector atributo2 = CrearVector(valorVida2, valorTemp2, valorVel2);
        IElemento ingrediente2 = new Elemento(atributo2);

        IContenedor contenedor = new Contenedor();

        contenedor.AgregarElemento(ingrediente1);
        contenedor.AgregarElemento(ingrediente2);

        Vector atributoEsperado = Vector.Nulo();
        ingrediente1.Agregar(ref atributoEsperado);
        ingrediente2.Agregar(ref atributoEsperado);

        ResultadoPrueba pocionEsperada = new ResultadoPrueba(atributoEsperado);
        Pocion pocionResultado = contenedor.CrearPocion();

        FloatEqualityComparer comparador = new FloatEqualityComparer(10e-3f);
        Assert.That(pocionEsperada.Similitud(pocionResultado), Is.EqualTo(1f).Using(comparador));
        Assert.That(pocionEsperada.Multiplicidad(pocionResultado), Is.EqualTo(1f).Using(comparador));
    }

    [Test]
    public void Test05UnContenedorModificaLosIngredientesQueSeAgregan()
    {
        float valorVida = 4f, valorTemp = 3f, valorVel = 5f;
        Vector atributo = CrearVector(valorVida, valorTemp, valorVel);
        IElemento ingrediente = new Elemento(atributo);

        float factoDeMultiplicacion = 4f;
        ICambiar modificador = new CambiarMultiplicarPrueba(factoDeMultiplicacion, _vida);

        List<ICambiar> modificadores = new List<ICambiar> { modificador };

        ResultadoPrueba pocionEsperada = new ResultadoPrueba(modificador.Modificar(atributo));
        IContenedor contenedor = new Contenedor(modificadores);
        contenedor.AgregarElemento(ingrediente);

        Pocion pocionResultado = contenedor.CrearPocion();

        FloatEqualityComparer comparador = new FloatEqualityComparer(10e-3f);
        Assert.That(pocionEsperada.Similitud(pocionResultado), Is.EqualTo(1f).Using(comparador));
        Assert.That(pocionEsperada.Multiplicidad(pocionResultado), Is.EqualTo(1f).Using(comparador));
    }
}
