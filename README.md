# E404-HitFactor
E404 Technical Unity Test

### **LOOK MOM, NO SINGLETONS**

Bueno, acá les comparto un MVP del technical unity test que me enviaron por mail. A continuación comentaré algunas aclaraciones en cuanto al desarrollo del proyecto y a algunos aspectos que quedaron pendientes:

Mi foco estuvo en el desarrollo de un * *sistema modular, óptimo, reutilizable y designer friendly* *, para lo cual decidí implementar un diseño de arquitectura de eventos y variables utilizando Scriptable Objects, inspirado en los modelos utilizados por **Schellgames** que pueden encontrar en el siguiente link:

[Game Architecture with Scriptable Objects](https://schellgames.com/blog/game-architecture-with-scriptable-objects?fbclid=IwAR05O0Ayv6R8bkn8HVKKYHAmQN6CO5gf7R6cX2fjJbaLbw_9oUiat4HZJ1g)

Sumado a esto, implemente el diseño * *State Pattern* * para el manejo de los distintos estados de los distintos componentes del videojuego. 

## **TO DO**

- [ ] Revisar aspectos performáticos del sistema (saber el target device del producto en cuestión sería vital).
Ejemplos: 
Metódos para manejar variables dependientes del tiempo --> * *Coroutines vs timer += Time.deltaTime* *
Método de manejo de probabilidades de spawneo de cada objeto --> * *Dictionary vs Object* *

- [ ] Aesthetics (UIs, Tutorial, SFX, etc...)

- [ ] Implementar State Pattern para el display de las distintas UIs. El diseño actual no es para nada modular. 

- [ ] El método de spawneo en pantalla de los objetos. De momento emplea una pseudo-grilla, pero sería ideal implementar una grilla real y desarrollar la implementación de una Queue para la situación ocasional donde no haya espacio en dicha grilla para spawnear el/los siguiente/s objetos.
   
