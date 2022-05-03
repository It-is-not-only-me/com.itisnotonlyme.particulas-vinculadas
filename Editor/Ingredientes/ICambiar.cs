using ItIsNotOnlyMe.VectorDinamico;

namespace ItIsNotOnlyMe.SistemaDePociones
{
    public interface ICambiar 
    {
        public void Cambiar(ICambiante cambiante);

        public Vector Modificar(Vector atributos);
    }   
}