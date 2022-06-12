# Documentacion
---

Se tiene 5 interfases:
 * IAtomo
 * ICondicion
 * IModificador
 * IResultado
 * IVinculo
De los cuales solo IAtomo y IVinculo creo un implementacion concreta. Esto esta hecho para que este sistema pueda adaptarse al problema a solucionar.

### IResultado
---
La implementacion de IResultado es donde aparece las propiedades emergentes, ya que puede representar lo que uno quiera. La idea mas simple es que sea un valor, pero se puede pensar como un vector entonces cada componente representa un aspecto del atomo, y se van modificando y afectando entre si.

### ICondicion
---
La idea con ICondicion es que haya muchas implementaciones, que puedan determinar los vinculos entre los atomos.

### IModificador
---
La idea es que es la forma en la que los atomos se modifican entre si con los vinculos. Entonces, al igual que ICondicion, se deberia crear varias implementaciones para recrear las interacciones entre los atomos.