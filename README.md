# La Defensa de Trost

<p align="center">
  <img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen1.png" alt="JuveR" width="300px">
</p>

<p align="center">
  UNIVERSIDAD REY JUAN CARLOS
</p>  
<p align="center">
 ESCUELA TÉCNICA SUPERIOR EN INGENIERÍA INFORMÁTICA
</p>  
<p align="center">
  GRADO EN DISEÑO Y DESARROLLO DE VIDEOJUEGOS
</p>  
<p align="center">
  Juegos para web y redes sociales
</p>  

&nbsp;

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen2.png" alt="JuveR" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen3.png" alt="JuveR" width="300px">
</p>

&nbsp;

**Integrantes**
- Roberto Alegre Marcos
- Iván Pérez Ciruelos
- David Pozo Sánchez
- Juan Higuero López
- Pablo Burgaleta de la Peña

&nbsp;

# Contenido
* 1.**Sinopsis**
* 2.**Mecánicas**
  * 2.1. Dentro de partida
  * 2.2. Efectos del juego
  * 2.3. Cartas
  * 2.4. Controles
  * 2.5. Cámara
  * 2.6. Partida
* 3.**Diagrama de flujo**
* 4.**Mundos** 
  * 4.1. Winterfall
  * 4.2. Farafra
  * 4.3. Atlantis
  * 4.4. Valhalla
  * 4.5. Selva Mágica
  * 4.6. Trost sumido en el Infierno
* 5.**Torres principales** 
  * 5.1. Winterfall
  * 5.2. Farafra
  * 5.3. Atlantis
  * 5.4. Valhalla
  * 5.5. Selva mágica
  * 5.6. Trost sumido en el infierno
* 6.**Héroes** 
  * 6.1. Winterfall
  * 6.2. Farafra
  * 6.3. Atlantis
  * 6.4. Valhalla
  * 6.5. Selva mágica
  * 6.6. Trost sumido en el infierno
* 7.**Torretas**
  * 7.1. General
  * 7.2. Winterfall
  * 7.3. Farafra
  * 7.4. Atlantis
  * 7.5. Valhalla
  * 7.6. Selva mágica
  * 7.7. Trost sumido en el infierno
* 8.**Enemigos** 
  * 8.1. Winterfall
  * 8.2. Farafra
  * 8.3. Atlantis
  * 8.4. Valhalla
  * 8.5. Selva mágica
  * 8.6. Trost sumido en el infierno
  * 8.6. Enemigo final del juego
* 9.**Arte 2D** 
  * 9.1. HUD
  * 9.2. Pantallas
    * 9.2.1. Pantalla tutorial
  * 9.3. Iconos
* 10.**Historia**
* 11.**Sonido/Música** 
  * 11.1. Música
    * 11.1.1. In-game
    * 11.1.2. Menús
  * 11.2. Efectos de sonido
* 12.**Monetización** 
  * 12.1. Caja de herramientas
  * 12.2. Bussines model canvas
* 13.**Propósito, público objetivo y plataformas** 
  * 13.1. Propósito
  * 13.2. Público objetivo
  * 13.3. Plataformas
* 14.**Hitos**
  * 14.1. Hito 1 - Versión Alpha
  * 14.2. Hito 2 - Versión Beta
  * 14.3. Hito 3 - Versión Gold Master
  * 14.4. Hito 4 - Publicación

&nbsp;

# 1.**Sinopsis**
La defensa de Trost es un videojuego que combina el Tower defense con el Roguelike en el que se tiene que defender diferentes mundos para recuperar las 6 partes de un tesoro que ha sumido al mundo en la oscuridad. Cada fragmento del tesoro está en un mundo completamente diferente, y cada mundo tiene torretas, enemigos y mecánicas diferentes. El mapa se genera de forma aleatoria y procedural por lo que cada partida es completamente diferente.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen0.png" alt="JuveR" width="700px">
</p>  

&nbsp;

# 2.**Mecánicas**
  ## 2.1. Dentro de partida 
Cada mapa tiene una torre principal, especificadas en el apartado 5, con una habilidad especial la cual se puede usar cada cierto número de rondas dependiendo de la zona en la que se halle el jugador. En cada mapa hay casillas especiales que otorgan efectos únicos tanto a las torretas como a los enemigos. En cada mundo encontramos 3 torretas nuevas y 6 nuevos enemigos, divididos en 3 pequeños, 2 medianos y un jefe final, estos se especifican en el apartado 8.

Existen dos modalidades de juego el modo campaña y el modo infinito. 

En el modo campaña jugaras en el mundo específico seleccionado teniendo acceso únicamente a la torre principal, torretas y enemigos propios de esta zona y a cuatro torretas más comunes a todos los mundos. En este modo de juego la partida está formada por un número de rondas limitadas, un total de 30 rondas. 

En el modo infinito tienes la opción de elegir 6 torretas independientemente del mundo al que pertenezcan, los enemigos en este modo también pueden ser de cualquier mundo y no existe un número de rondas, sino que la partida acaba cuando la torre principal es destruida.

Durante la partida cada cierto número rondas, aparecen unas cartas, de las posibles opciones que salen se tiene que elegir una de cada tipo, una mejora para torretas y una mejora para los enemigos. El número de cartas de entre las cuales se puede elegir está determinado por el número que se obtenga al lanzar el dado.

El mapa se genera de forma procedural y completamente aleatoria en cada partida, pero siempre hay un camino que permite llegar a los enemigos al objetivo. 

Las principales variables que influyen en la generación del mapa son las probabilidades de que los caminos sean rectos o no, de que se curven, de que se corten, de generar casillas especiales, de generar obstáculos y de conectar caminos.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen4.png" alt="JuveR" width="300px">
</p>  
<p align="center">
<i>Ilustración 1. Dados</i>
</p>
  
  ## 2.2. Efectos del juego
Dentro del juego se pueden encontrar diferentes efectos, los cuales pueden ser aplicados por las torres, las casillas especiales de los diferentes mundos o los hechizos de cada mundo. Estos efectos son:

-	Efecto de hielo: aplicado principalmente en el mundo de Winterfall, provoca que los enemigos reduzcan su velocidad de movimiento, pudiendo llegar a estar congelados si este efecto llega al 100%.
-	Efecto de quemado: aplicado principalmente en el mundo de Farafra, provoca que los enemigos pierdan vida de forma progresiva, al llegar al 100% aplica mucho daño y se reinicia el efecto.
-	Efecto de agua: aplicado principalmente en el mundo de Atlantis, acumula un porcentaje de humedad en los enemigos, al llegar al 100% de humedad se aplica el efecto de agua, generando un torbellino de agua que levanta a los enemigos durante 1 segundo, quedando inmovilizados mientras tanto.
-	Efecto de ascensión: aplicado principalmente en el mundo de Valhalla, este efecto sólo es contemplado para ser aplicado en las torretas de este mundo al ser colocadas en las casillas del mapa que aplican este efecto. Las consecuencias de que una torreta posea este efecto es un aumento de sus estadísticas.
-	Efecto de sangrado: aplicado principalmente en el mundo de la Selva Mágica, este efecto provoca un sangrado en los enemigos que hace que pierdan vida de forma progresiva.
-	Efecto de transformación: aplicado principalmente en el mundo de Trost sumido en el infierno, acumula un porcentaje de locura en los enemigos, al llegar al 100% aplica el efecto de locura que hace que el enemigo muera, pero resucite convertido en un esqueleto de gran poder.

  ## 2.3. Cartas
Las cartas aparecen cada cierto número de rondas. Existen dos tipos de cartas, cartas de torretas y cartas de enemigos. Las cartas de torretas son mejoras para estas y las cartas de enemigos son mejoras para los enemigos.  Además, existen 3 tipos de rangos de cartas, cartas de rango 1, 2 y 3.  Cuanto mayor es el rango de la carta mayor es la desventaja o ventaja que aplica. 

Las cartas de torretas son mejoras referentes a las características de las torretas (vida, rango, velocidad de ataque y efectos). Las cartas de los enemigos son mejoras a estos en términos de características (vida, rango, velocidad) o disminuciones del oro que ganamos al matarlos.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen78.png" alt="JuveR" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen79.png" alt="JuveR" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen80.png" alt="JuveR" width="300px">
</p>  
<p align="center">
<i>Ilustración 2. Diseño de cartas</i>
</p>
  
  ## 2.4. Controles
Los controles se basan en el uso del teclado y del ratón:

Colocación de torretas: clicar sobre la torreta a colocar y clicar sobre la casilla donde se quiere colocar.

Mejora de torretas: clicar sobre la torreta y pulsar en el botón de mejora

Lanzamiento de hechizos/habilidades especiales de cada zona: clicar sobre el terreno de juego donde quieras lanzarlo

Venta de torretas: clicar sobre la torreta y pulsar sobre el botón vender

Mover cámara: uso de las teclas A, W, S, D para mover la cámara o hacer uso del ratón con el botón derecho. Para rotar la cámara se utilizan las teclas Q y E. Con la rueda del ratón podemos hacer zoom.

En la versión de móvil existen diferencias respecto a la versión web, ya que en el móvil no se puede usar el teclado, para solventar estas acciones se añaden botones que realizan estas acciones. Las acciones adaptadas son zoom y girar cámara.

  ## 2.5. Cámara
El juego posee una cámara ortográfica enfocando al videojuego con una vista isométrica que permite observar todo el terreno de juego.

Para el control de la cámara disponemos de herramientas por teclado (teclas W-A-S-D) o de desplazamiento mediante el ratón.

Para acercar o alejar el punto de vista del jugador se puede emplear la rueda del ratón.

Para rotar la cámara y poder así ver el escenario desde otros puntos de vista se utilizan las teclas Q y E.

  ## 2.6. Partida
Al comenzar una partida, se genera una parte de mapa del mundo con su respectiva torre principal, para comenzar a jugar será necesario accionar el bloque que aumenta el tamaño del mapa.

Al aumentar el tamaño del mapa aparecerá el primer enemigo del que habrá que defenderse y se habilitará la posibilidad de empezar a colocar torretas y héroes dependiendo del dinero disponible, o lanzar hechizos especiales si se considera oportuno. 

Cada ronda termina al acabar con todos los enemigos que hayan aparecido en dicha ronda, pasando a un modo de planificación en el que se dispone de todo el tiempo que se precise para preparar la estrategia de la siguiente ronda. 

Para comenzar las siguientes rondas se podrá hacer ampliando el mapa pulsando los botones de ampliación o pulsando el botón de “Empezar ronda” dependiendo del número de ronda en el que se encuentre.

Dependiendo del nivel de ronda actual aparecen una cantidad de enemigos determinando, aumentando de forma progresiva con el aumento de rondas, teniendo que planificar en cada ronda cual es la mejor estrategia en la compra y colocación de torretas. 

&nbsp;

# 3.**Diagrama de flujo** 
A continuación, se presenta el diagrama de flujo y una breve explicación del contenido que se encuentra en cada pantalla.
<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen76.png" alt="JuveR" width="500px">
</p>  
<p align="center">
<i>Ilustración 1. Dados</i>
</p>

Menú principal: En esta pantalla se muestra el menú principal y clicando sobre los distintos elementos podemos navegar a nuevas pantallas.

Menú de opciones: En esta pantalla se puede modificar diferentes opciones del videojuego. 

Contacto: A través de esta pantalla podemos acceder a las diferentes redes sociales de Team Salchichill.

Selección de nivel: En esta pantalla se elige el mundo que se quiere desarrollar la partida. Existe un botón para cada uno de los mundos y un botón extra que permite acceder en el modo infinito.

Selección de torretas: Esta pantalla se muestra si hemos seleccionado el modo de juego infinito, en ella se debe elegir un mundo en el que jugar, un hechizo, un héroe y 6 torretas. Una vez seleccionadas podemos entrar al modo de juego infinito.

Pantalla de juego: Esta pantalla es donde se desarrolla la partida si hemos seleccionado un mundo en el menú de selección de nivel.

Pantalla de juego Infinito: Esta pantalla es donde se desarrolla el modo de juego infinito.

GameOver: Pantalla de fin del juego, esta aparece cuando perdemos la partida, es decir el jugador ha sido derrotado.

Pausa: En esta pantalla se muestran diferentes opciones modificar en el juego, como por ejemplo los sonidos. Además, desde esta pantalla tenemos acceso al tutorial, a través del cual podemos consultar las diferentes características de los mundos. También nos permite reiniciar la partida y navegar al menú principal. 

&nbsp;

# 4.**Mundos** 
Existen 6 mundos diferentes. En cada mundo hay un terreno diferente, y cada mundo tienes unas características únicas, diferentes enemigos, torretas, hechizos o reglas. 

  ## 4.1. Winterfall
En este mundo existen casillas especiales que si están en el mapa y pones una torreta encima hace que este aplique más efecto de congelamiento con sus disparos a los enemigos.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen82.png" alt="JuveR" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen83.png" alt="JuveR" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen84.png" alt="JuveR" width="300px">
</p>  
<p align="center">
<i>Ilustración 4. Casillas normales terreno – Casilla especial terreno</i>
</p>

En el caso de que estas casillas se encuentren en el camino y los enemigos pasen por encima estos se ralentizaran.

El efecto de congelación hace que los enemigos vayan más lentos hasta un máximo de la mitad de su velocidad original.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen85.png" alt="JuveR" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen86.png" alt="JuveR" width="300px">
</p>  
<p align="center">
<i>Ilustración 5. Casilla normal camino – Casilla especial camino</i>
</p>

  ## 4.2. Farafra
Las casillas especiales de Farafra si se encuentran en el mapa y colocas una torreta encima suya hace que apliquen más efecto de quemado sobre el enemigo.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen87.png" alt="JuveR" width="300px">
</p>  
<p align="center">
<i>Ilustración 6. Casilla normal terreno – Casilla especial terreno</i>
</p>

En el caso de que se encuentren en el camino a estos se le aplicaran más efecto de quemado.

El efecto de quemado hace que los enemigos pierdan vida poco a poco y cuando llegan al 100% de quemado el enemigo recibe daño extra y su quemado baja al 0%.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen88.png" alt="JuveR" width="300px">
</p>  
<p align="center">
<i>Ilustración 7.Casilla normal camino – Casilla especial camino</i>
</p>

Por otro lado, hay casillas quemadas, que lo que hace es que, si colocas una torre sobre ella esta va a disparar más rápido, pero se va a sobrecalentar y va a hacer que esté unos segundos sin poder disparar hasta que se enfríe.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen89.png" alt="JuveR" width="300px">
</p>  
<p align="center">
<i>Ilustración 7.Casilla normal camino – Casilla especial camino</i>
</p>

Por último, en este mundo hay zonas que tienen una tormenta de arena que dura varios turnos. Mientras esté activa dicha tormenta no podrás construir en esa zona.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen90.png" alt="JuveR" width="300px">
</p>  
<p align="center">
<i>Ilustración 7.Casilla normal camino – Casilla especial camino</i>
</p>

  ## 4.3. Atlantis
En el mundo de Atlantis las casillas del camino son corrientes de agua, cada varias rondas cambia la dirección de la corriente. Esta corriente mueve a los enemigos en esa dirección, haciendo que vayan más rápido o más lento dependiendo de la dirección. Esto se refleja a través del color de la perla de la torre principal. Si es de color rojo los enemigos tienen más velocidad de lo normal, si es de color verde tienen menos velocidad y si es amarillo tienen su velocidad normal.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen91.png" alt="JuveR" width="300px">
</p>  
<p align="center">
<i>Ilustración 10. Color perlas Atlantis</i>
</p>

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen92.png" alt="JuveR" width="300px">
</p>  
<p align="center">
<i>Ilustración 11. Casilla especial camino</i>
</p>

Por otro lado, en las casillas del mapa encontramos casillas sin efecto y casillas con efecto en las que si colocas una torre esta aplica efecto de agua.

El efecto de agua al llegar al 100% hace que una ola lo levante y no pueda hacer nada durante 1 segundo.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen93.png" alt="JuveR" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen94.png" alt="JuveR" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen95.png" alt="JuveR" width="300px">
</p>  
<p align="center">
<i>Ilustración 12. Casillas normales terreno – Casilla especial terreno</i>
</p>

  ## 4.4. Valhalla
En el Valhalla existen casillas que si están en el mapa y pones una torre encima esta es ascendida, es decir, esa torre tiene todas las estadísticas subidas. Estas casillas aparecen raramente.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen96.png" alt="JuveR" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen97.png" alt="JuveR" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen98.png" alt="JuveR" width="300px">
</p>  
<p align="center">
<i>Ilustración 13. Casillas normales terreno – Casilla especial terreno</i>
</p>

En el caso de que se encuentren el camino, los enemigos que pasen por encima son ascendidos, es decir, todas sus estadísticas se aumentan.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen99.png" alt="JuveR" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen100.png" alt="JuveR" width="300px">
</p>  
<p align="center">
<i>Ilustración 14. Casilla normal camino – Casilla especial camino</i>
</p>

  ## 4.5. Selva Mágica
En el mapa aparecen unas casillas especiales que, si pones una torreta encima, esta obtiene un escudo (vida extra) y velocidad de ataque.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen101.png" alt="JuveR" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen102.png" alt="JuveR" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen103.png" alt="JuveR" width="300px">
</p>  
<p align="center">
<i>Ilustración 15. Casillas normales terreno – Casilla especial terreno</i>
</p>

En la Selva Mágica hay casillas en el camino en las que hay espinas, que hace que los enemigos que pasen por encima sufran sangrado. 

El efecto de sangrado reduce la vida del enemigo mientras se está aplicando.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen104.png" alt="JuveR" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen105.png" alt="JuveR" width="300px">
</p>  
<p align="center">
<i>Ilustración 16. Casilla normal camino – Casilla especial camino</i>
</p>

  ## 4.6. Trost sumido en el Infierno
En Trost sumido en el infierno las casillas especiales del mapa reducen afecto de locura, las torretas que se sitúan sobre estas casillas aplican este efecto.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen106.png" alt="JuveR" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen107.png" alt="JuveR" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen108.png" alt="JuveR" width="300px">
</p>  
<p align="center">
<i>Ilustración 17. Casillas normales terreno – Casilla especial terreno</i>
</p>

En el camino hay casillas de sacrificio, estás hacen que los enemigos que pasen por encima se le aplique un porcentaje de locura. 

El efecto de locura hace que si llega al 100% el enemigo muera, pero invoque un enemigo muy fuerte, además, si un enemigo muere encima de estas casillas, se convertirá en un enemigo muy fuerte sin necesidad de haber llegado al 100% de locura.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen109.png" alt="JuveR" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen110.png" alt="JuveR" width="300px">
</p>  
<p align="center">
<i>Ilustración 18. Casilla normal camino – Casilla especial camino</i>
</p>

&nbsp;

# 5.**Torres principales** 
Cada mundo tiene una torre principal que lo caracteriza, así como un hechizo propio. A continuación, se explican las diferentes torres principales y hechizos.

  ## 5.1. Winterfall
La torre principal de WinterFall es un castillo helado donde se encuentra el primer fragmento del corazón de Trost. En el castillo existen brujos de hielo capaces de invocar hechizos de hielo, que congelan a los enemigos.
-	Poder Torre principal: Hechizo de hielo, al lanzarlo se crea un aura de hielo que congela a los enemigos afectados.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen5.png" alt="JuveR" width="300px">
</p>  
<p align="center">
<i>Ilustración 19. Torre principal WinterFall</i>
</p>

  ## 5.2. Farafra
Farafra es un templo situado en el gran Desierto de Trost, en este templo se encuentra el segundo fragmento del corazón de Trost. Farafra es una gran pirámide con la habilidad de corromper a quien osa atacarla.
-	Poder Torre principal: Hechizo de locura, al lanzarlo se crea un aura de veneno que provoca que los enemigos se peguen entre ellos.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen6.jpg" alt="JuveR" width="300px">
</p>  
<p align="center">
<i>Ilustración 20. Torre principal Farafra</i>
</p>

  ## 5.3. Atlantis
El castillo de Maribel es la torre principal de Atlantis, en él se encuentra la orquesta real del reino que es capaz de invocar grandes olas cuando su reino se ve amenazado, por lo que son los protectores del tercer fragmento del corazón de Trost.
-	Poder Torre principal: Hechizo Ola, al lanzarlo se invoca una fila de torbellinos de agua gigantes en la dirección seleccionada que levanta a todos los enemigos con los que se encuentre.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen7.png" alt="JuveR" width="300px">
</p>  
<p align="center">
<i>Ilustración 21. Torre principal Atlantis</i>
</p>

  ## 5.4. Valhalla
El Valhalla es el hogar de los dioses de Trost, en su edificio principal vienen los dioses más fuertes de Trost cuya misión es defender el cuarto fragmento del corazón de Trost, capaces de invocar una gran lanza para atacar a sus enemigos empleando sus diferentes habilidades.
-	Poder Torre principal: Hechizo Lanza de Odín, cae una gran lanza en el camino provocando mucho daño a los enemigos que estén en él.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen8.jpg" alt="JuveR" width="300px">
</p>  
<p align="center">
<i>Ilustración 22. Torre principal Valhalla</i>
</p>

  ## 5.5. Selva mágica
La torre principal de la selva mágica es el gran árbol de Trost, este árbol alberga en su interior el quinto fragmento del corazón de Trost. Gracias a ser el árbol más longevo de la selva posee la capacidad curar y proteger a sus habitantes. 
-	Poder Torre principal: Crecimiento salvaje, al lanzarlo se crea un aura en el que las torres afectadas obtienen un escudo que les multiplica su velocidad de ataque mientras este escudo este activo o se rompa.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen9.jpg" alt="JuveR" width="300px">
</p>  
<p align="center">
<i>Ilustración 23. Torre principal Selva Mágica</i>
</p>

  ## 5.6. Trost sumido en el infierno
La torre principal del infierno es la sede central del gobierno de Trost, donde se encuentra el ultimo fragmento del corazón de Trost. Esta sede es el lugar donde el protagonista es teletransportado al inicio de la historia y donde ve Trost destruida. En ella se encuentran grandes aliados de Trost capaces de invocar ataques de fuego. 
-	Poder Torre principal: Hechizo Bola de fuego, de la torre principal sale una bola de fuego gigante hacia delante y hace daño todos los enemigos que impacta.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen10.jpg" alt="JuveR" width="300px">
</p>  
<p align="center">
<i>Ilustración 24. Torre principal Trost sumido en el Infierno</i>
</p>

&nbsp;  

# 6.**Héroes** 
  ## 6.1. Winterfall
Rey Fannar: El rey Fannar es el último descendiente de la corona de WinterFall, se caracteriza por llevar siempre consigo su bastón de hielo que le permite lanzar bolas de hielo a los enemigos, haciendo daño en área y congelándolos. Además, posee un ataque especial defensivo que le permite crear muros de hielo en el camino para impedir que los enemigos puedan avanzar.

Ataque normal: lanza-bolas de hielo a los enemigos, haciendo daño en área y congelándolos 

Activa: crear muros de hielo en el camino para impedir que los enemigos puedan avanzar, estos muros de hielo los invoca cada 30 segundos y duran hasta que se derritan, tras 20 segundos o sean destruidos.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen111.png" alt="JuveR" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen70.png" alt="JuveR" width="300px">
</p>  
<p align="center">
<i>Ilustración 25. Rey Fannar</i>
</p>

  ## 6.2. Farafra
Rey Axiryus: El rey Axiryus, está basado en el dios Ra de la mitología egipcia, como es un rey muy mayor no tiene casi fuerzas para mantenerse en pie por lo que está siempre sentado en su trono. Para atacar a los enemigos emplea su cetro el cual genera un rayo continuo que daña a los enemigos en el área que golpea quemando a estos. Además, cuenta con la habilidad de invocar dos obeliscos a su alrededor que curan a las torretas aliadas cercanas, esta habilidad la realiza cada mucho tiempo ya que para invocarlos necesita levantarse de su trono. 

Ataque normal: Emplea su centro generando un rayo continuo que daña a los enemigos en el área donde golpea aplicando quemaduras sobre estos.

Activa: Invoca dos obeliscos a su alrededor que curan a las torretas aliadas cercanas. 

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen112.png" alt="JuveR" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen71.jpg" alt="JuveR" width="300px">
</p>  
<p align="center">
<i>Ilustración 26. Rey Axiryus</i>
</p>

  ## 6.3. Atlantis
Reina Maribel: Maribel es la reina de Atlantis, como buena reina de su país no le gusta ver a sus habitantes en guerra por lo que emplea su canto para motivarlos y así acabar con la guerra lo antes posible. Maribel posee pésimas habilidades de canto por lo que los enemigos al escucharlas se ven dañados, pero en cambio los habitantes de Atlantis como idolatran a su reina se ven motivados. Maribel es un fan de cantar el himno de su nación por lo que cuando lo canta sus aliados se extra motivan provocando que aumenten sus ganas de defender su mundo.

Ataque normal: utiliza su canto para dañar a los enemigos, su daño es en área ya que todos los enemigos que se acercan a ella sufren su canto.

Activa: Canta el himno de su población provocando que las torretas aliadas cercanas aumenten su velocidad de ataque.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen113.png" alt="JuveR" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen72.png" alt="JuveR" width="300px">
</p>  
<p align="center">
<i>Ilustración 27. Reina Maribel</i>
</p>

  ## 6.4. Valhalla
Rey Lothbrock: El rey LothBrock es el mejor dios de Trost, por lo que reina en el Valhalla. LothBrock es un fanático de las tormentas de rayos por lo que motivado por su afición logró fabricar un martillo capaz de invocar rayos. LothBrock emplea este martillo para atacar a los enemigos, lanzándoles rayos que rebotan entre los enemigos, a su vez posee una gran habilidad para invocar tormentas de rayos que dañan al enemigo cuanto más cerca este de ellas.

Ataque normal: lanza rayos que rebotan en los enemigos.

Activa: Invocación de tormenta que crea un ataque en un área que hace más daño cuanto más cerca del centro estés.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen114.png" alt="JuveR" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen73.png" alt="JuveR" width="300px">
</p>  
<p align="center">
<i>Ilustración 28. Rey Lothbrock</i>
</p>

  ## 6.5. Selva mágica
Reina Tatinia: La Reina Tatinia es una reina que sobrepone la belleza y salud de ella y de su reino por encima de todo, debido a su delicadeza sus ataques no son muy potentes en uno contra uno, por lo que prioriza golpear al máximo número de enemigos. La belleza debe resaltar, ante todo, así que esta reina buscará curar a todos sus aliados para que estén en perfecto estado. Como ella siempre dice, antes muerta que sencilla.

Ataque normal: ataque en área que golpea a los enemigos. 

Activa: Cura a todas las torres aliadas dentro de su rango de acción y aumenta su velocidad de ataque y daño 1.25 durante 10 segundos.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen115.png" alt="JuveR" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen74.png" alt="JuveR" width="300px">
</p>  
<p align="center">
<i>Ilustración 29. Reina Tatinia</i>
</p>

  ## 6.6. Trost sumido en el infierno
Rey Bubuyog: El rey Bubuyog se destaca, como cualquier mosca, por ser sucio y su modo juego no iba a ser menos, su táctica consiste atacar de lejos mediante un báculo y en crear moscas que ataquen a los enemigos, provocándoles picazones y la rabia, volviéndoles más agresivos y perdiendo el control, haciendo que se peguen entre ellos, después de hacer que se maten entre ellos, las moscas harán un buen uso de su cadáver.

Ataque normal: ataque en área que golpea a los enemigos. 

Activa: Invoca moscas que atacan a los enemigos aplicando efecto de locura.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen116.png" alt="JuveR" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen75.png" alt="JuveR" width="300px">
</p>  
<p align="center">
<i>Ilustración 30. Rey Bubuyog</i>
</p>

&nbsp;  

# 7.**Torretas**
Cada torreta tiene una características y estadísticas únicas, dichas estadísticas son las siguientes:

-	Vida: Cantidad de vida que tiene antes de morir.
-	Rango: Alcance que tiene para poder atacar.
-	Velocidad de ataque: Cantidad de veces que ataca por segundo.
-	Daño: Cantidad de vida que quita a los enemigos en cada disparo.
-	Efecto de hielo: Cantidad de efecto de hielo que aplica.
-	Efecto de quemado: Cantidad de efecto de quemado que aplica.
-	Efecto de agua: Cantidad de efecto de agua que aplica.
-	Efecto de sangrado: Cantidad de efecto de sangrado que aplica.
-	Efecto de ascensión: La torreta mejoró sus estadísticas 
-	Efecto de transformación: Cantidad de efecto de transformación que aplica.

  ## 7.1. General
**Mina**

Unidad inicial que genera dinero y recursos de forma periódica durante las rondas de enemigos

   *	Vida: 500
   *	Rango: No se puede aplicar
   *	Velocidad de sacar oro: 0.2
   *	Oro que genera: 10
   *	Efecto de hielo: No se puede aplicar
   *	Efecto de quemado: No se puede aplicar
   *	Efecto de agua: No se puede aplicar
   *	Efecto de ascensión: 
   *	Efecto de sangrado: No se puede aplicar
   *	Efecto de transformación: No se puede aplicar
   *	Lugar de colocación: Mapa
   *	Coste: 750 monedas
   *	Tipo de target: No se puede aplicar
   *	Estadística especial: Velocidad de sacar oro

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen117.png" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen11.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 31. Mina</i>
</p>

**Cañón**

Torre básica que dispara bolas de cañón y atacan a varios enemigos con gran poder de ataque.

   * Vida: 750
   * Rango: 5
   * Velocidad de ataque: 0.5
   * Daño: 200
   * Efecto de hielo: 0%
   * Efecto de quemado: 0%
   * Efecto de agua: 0%
   * Efecto de ascensión: False
   * Efecto de sangrado: 0%
   * Efecto de transformación: 0%
   * Lugar de colocación: Mapa
   * Coste: 500 monedas
   * Tipo de target: En área
   * Estadística especial: Aumento de daño

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen118.png" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen12.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 32. Cañón</i>
</p>

**Barricada**

Una torre inicial que tiene como función parar a los enemigos para que no avancen, pero no causa daño.

   *	Vida: 2000
   *	Vida: 7000
   *	Rango: No se puede aplicar
   *	Velocidad de ataque: No se puede aplicar
   *	Daño: No se puede aplicar
   *	Efecto de hielo: 0%
   *	Efecto de quemado: 0%
   *	Efecto de agua: 0%
   *	Efecto de ascensión: False
   *	Efecto de sangrado: 0%
   *	Efecto de transformación: 0%
   *	Lugar de colocación: Camino
   *	Coste: 500 monedas
   *	Tipo de target:  Ninguno
   *	Estadística especial:  Recibe más vida

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen119.png" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen13.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 33. Barricada</i>
</p>

**Torre de arqueras**

Una torre básica que ataca a varios enemigos a la vez con gran velocidad.

  *	Vida: 700
  *	Rango: 10
  *	Velocidad de ataque: 1.5
  *	Daño: 75
  *	Efecto de hielo: 0%
  *	Efecto de quemado: 0%
  *	Efecto de agua: 0%
  *	Efecto de ascensión: False
  *	Efecto de sangrado: 0%
  *	Efecto de transformación: 0%
  *	Lugar de colocación: Mapa
  *	Coste: 200 monedas
  *	Tipo de target: Objetivo único
  *	Estadística especial: Velocidad de disparo

 
<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen120.png" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen14.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 34. Torre de arqueras</i>
</p>

  ## 7.2. Winterfall
**Snow Man**

Muñeco de nieve que dispara bolas de nieve que congelan a los enemigos

  * Vida: 500
  *	Rango: 15
  *	Velocidad de ataque: 2.5
  *	Daño: 80
  *	Efecto de hielo: 1%
  *	Efecto de quemado: 0%
  *	Efecto de agua: 0%
  *	Efecto de ascensión: False
  *	Efecto de sangrado: 0%
  *	Efecto de transformación: 0%
  *	Lugar de colocación: Mapa
  *	Coste: 200 monedas
  *	Tipo de target: Objetivo único
  *	Estadística especial: Aplicar más efecto de hielo

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen121.png" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen15.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 35. Snow Man</i>
</p>

**Spray Nieve**

Cañón de nieve con alto nivel de congelación y velocidad de ataque

  *	Vida: 700
  *	Rango: 10
  *	Velocidad de ataque: No se puede aplicar
  *	Daño: 250
  *	Efecto de hielo: 1%
  *	Efecto de quemado: 0%
  *	Efecto de agua: 0%
  *	Efecto de ascensión: False
  *	Efecto de sangrado: 0%
  *	Efecto de transformación: 0%
  *	Lugar de colocación: Mapa
  *	Coste: 250 monedas

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen122.png" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen16.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 36. Spray nieve</i>
</p>

**Snow Keeper**

Guardián de nieve que para a los enemigos y les ataca con su lanza helada

  *	Vida: 4000
  *	Rango: 5
  *	Velocidad de ataque: 1
  *	Daño: 25
  *	Efecto de hielo: 1%
  *	Efecto de quemado: 0%
  *	Efecto de agua: 0%
  *	Efecto de ascensión: False
  *	Efecto de sangrado: 0%
  *	Efecto de transformación: 0%
  *	Lugar de colocación: Mapa
  *	Coste: 550 monedas
  *	Tipo de target: Objetivo único
  *	Estadística especial: Aumento de daño


<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen123.png" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen17.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 37. Snow Keeper</i>
</p>

  ## 7.3. Farafra
**PeRigie**

Monumento egipcio que ataca con un ataque elemental discontinuo

  *	Vida: 400
  *	Rango: 15
  *	Velocidad de ataque: 2
  *	Daño: 120
  *	Efecto de hielo: 0%
  *	Efecto de quemado: 3%
  *	Efecto de agua: 0%
  *	Efecto de ascensión: False
  *	Efecto de sangrado: 0%
  *	Efecto de transformación: 0%
  *	Lugar de colocación: Mapa
  *	Coste: 300 monedas
  *	Tipo de target: Objetivo único
  *	Estadística especial: Aumento velocidad de ataque

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen124.png" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen18.jpg" width="300px">
</p>  
<p align="center">
<i>Ilustración 38. PeRigie</i>
</p>

**Syrius Purple**

Monumento egipcio en honor al dios Anubis que ataca dando un bastonazo en el suelo

  *	Vida: 900
  *	Rango: 4
  *	Velocidad de ataque: 0.5
  *	Daño: 175
  *	Efecto de hielo: 0%
  *	Efecto de quemado: 1%
  *	Efecto de agua: 0%
  *	Efecto de ascensión: False
  *	Efecto de sangrado: 0%
  *	Efecto de transformación: 0%
  *	Lugar de colocación: Mapa
  *	Coste: 500 monedas
  *	Tipo de target: Ataque en área
  *	Estadística especial: Aumento de daño

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen125.png" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen19.jpg" width="300px">
</p>  
<p align="center">
<i>Ilustración 16. Syrius Purple</i>
</p>

**Test-Lah**

Torre del mundo del desierto que ataca con rayos elementales continuado a los enemigos

  *	Vida: 500
  *	Rango: 9
  *	Velocidad de ataque: 150
  *	Daño: 4
  *	Efecto de hielo: 0%
  *	Efecto de quemado: 1%
  *	Efecto de agua: 0%
  *	Efecto de ascensión: False
  *	Efecto de sangrado: 0%
  *	Efecto de transformación: 0%
  *	Lugar de colocación: Mapa
  *	Coste: 200 monedas
  *	Tipo de target: Objetivo único
  *	Estadística especial: Aumento de rango

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen126.png" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen20.jpg" width="300px">
</p>  
<p align="center">
<i>Ilustración 39. Test-Lah</i>
</p>

  ## 7.4. Atlantis
**Suw Balony**

Tirachinas gigante de globos de agua que ataca en área

  *	Vida: 700
  *	Rango: 10
  *	Velocidad de ataque: 0.6
  *	Daño: 170
  *	Efecto de hielo: 0%
  *	Efecto de quemado: 0%
  *	Efecto de agua: 5%
  *	Efecto de ascensión: False
  *	Efecto de sangrado: 0%
  *	Efecto de transformación: 0%
  *	Lugar de colocación: Mapa
  *	Coste: 500 monedas
  *	Tipo de target: Ataque en área
  *	Estadística especial: Aumento de daño
   
<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen127.png" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen21.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 40. Suw Balony</i>
</p>

**Tuex**

Ballesta que lanza arpones a los enemigos

o	Vida: 500
o	Rango: 12
o	Velocidad de ataque: 0.75
o	Daño: 200
o	Efecto de hielo: 0%
o	Efecto de quemado: 0%
o	Efecto de agua: 2%
o	Efecto de ascensión: False
o	Efecto de sangrado: 0%
o	Efecto de transformación: 0%
o	Lugar de colocación: Mapa
o	Coste: 350 monedas
o	Tipo de target: Objetivo único
o	Estadística especial: Aumento de velocidad de ataque

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen128.png" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen22.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 41. Tuex</i>
</p>

**Pium**

Cañón de agua que ataca a un único objetivo

  *	Vida: 500
  *	Rango: 20
  *	Velocidad de ataque: 3
  *	Daño: 45
  *	Efecto de hielo: 0%
  *	Efecto de quemado: 0%
  *	Efecto de agua: 1%
  *	Efecto de ascensión: False
  *	Efecto de sangrado: 0%
  *	Efecto de transformación: 0%
  *	Lugar de colocación: Mapa
  *	Coste: 250 monedas
  *	Tipo de target: Objetivo único
  *	Estadística especial: Aumento de rango

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen129.png" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen23.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 42. Pium</i>
</p>

  ## 7.5. Valhalla
**Altar de Odín**

Torre que lanza ataques en áreas circulares

  *	Vida: 550
  *	Rango: 7
  *	Velocidad de ataque: 0.5
  *	Daño: 200
  *	Efecto de hielo: 0%
  *	Efecto de quemado: 0%
  *	Efecto de agua: 0%
  *	Efecto de ascensión: False
  *	Efecto de sangrado: 0%
  *	Efecto de transformación: 0%
  *	Lugar de colocación: Mapa
  *	Coste: 350 monedas
  *	Tipo de target: Ataque en área
  *	Estadística especial: Aumento velocidad de ataque

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen130.png" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen24.jpg" width="300px">
</p>  
<p align="center">
<i>Ilustración 43. Altar de Odín</i>
</p>

**Kyria**

Torre de soporte que cura a los aliados y ataca a los enemigos.

  *	Vida: 700
  *	Rango: 15
  *	Velocidad de ataque: 1
  *	Daño y curación: 75
  *	Efecto de hielo: 0%
  *	Efecto de quemado: 0%
  *	Efecto de agua: 0%
  *	Efecto de ascensión: False
  *	Efecto de sangrado: 0%
  *	Efecto de transformación: 0%
  *	Lugar de colocación: Mapa
  *	Coste: 200 monedas
  *	Tipo de target: Ataque en área
  *	Estadística especial: Aumenta velocidad de ataque

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen131.png" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen25.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 44. Kyria</i>
</p>

**Beowulf**

Torre especial que invoca grupos de aliados para atacar a los enemigos.

  *	Vida: 300
  *	Rango: No se puede aplicar
  *	Velocidad de ataque: 0.25
  *	Daño: No se puede aplicar
  *	Efecto de hielo: 0%
  *	Efecto de quemado: 0%
  *	Efecto de agua: 0%
  *	Efecto de ascensión: False
  *	Efecto de sangrado: 0%
  *	Efecto de transformación: 0%
  *	Lugar de colocación: Mapa
  *	Coste: 500 monedas
  *	Tipo de target: No se puede aplicar
  *	Estadística especial: Aumento de daño

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen132.png" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen26.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 45. Salón de Beowulf</i>
</p>

  ## 7.6. Selva mágica
**ThornGun**

Torre planta que lanza espinas a los enemigos.

*	Vida: 500
*	Rango: 10
*	Velocidad de ataque: 4
*	Daño: 50
*	Efecto de hielo: 0%
*	Efecto de quemado: 0%
*	Efecto de agua: 0%
*	Efecto de ascensión: False
*	Efecto de sangrado: 1%
*	Efecto de transformación: 0%
*	Lugar de colocación: Mapa
*	Coste: 150 monedas
*	Tipo de target: Objetivo único
*	Estadística especial: Aumento efecto de sangrado

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen133.png" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen27.jpg" width="300px">
</p>  
<p align="center">
<i>Ilustración 46. ThornGun</i>
</p>

**Antium**

Torre de protección que ataca y se defiende e de los enemigos.

  *	Vida: 3500
  *	Rango: 5
  *	Velocidad de ataque: 0.5
  *	Daño: 8
  *	Efecto de hielo: 0%
  *	Efecto de quemado: 0%
  *	Efecto de agua: 0%
  *	Efecto de ascensión: False
  *	Efecto de sangrado: 1%
  *	Efecto de transformación: 0%
  *	Lugar de colocación: Camino
  *	Coste: 550 monedas
  *	Tipo de target: Objetivo único
  *	Estadística especial: Aumento de vida

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen134.png" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen28.jpg" width="300px">
</p>  
<p align="center">
<i>Ilustración 47. Antium</i>
</p>

**Viva Porub**

Torre soporte que cura a las torres aliadas en área

  *	Vida: 500
  *	Rango: 15
  *	Velocidad de ataque: 0.2
  *	Daño (cuanto cura): 100
  *	Efecto de hielo: 0%
  *	Efecto de quemado: 0%
  *	Efecto de agua: 0%
  *	Efecto de ascensión: False
  *	Efecto de sangrado: 0%
  *	Efecto de transformación: 0%
  *	Lugar de colocación: Mapa
  *	Coste: 350 monedas
  *	Tipo de target: Daño en área
  *	Estadística especial: Aumento velocidad de ataque

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen135.png" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen29.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 48. Viva Porub</i>
</p>

  ## 7.7. Trost sumido en el infierno
**Charmando**

Torre de fuego que lanza bolas ígneas que explotan en área.

  *	Vida: 500
  *	Rango: 10
  *	Velocidad de ataque: 0.5
  *	Daño: 75
  *	Efecto de hielo: 0%
  *	Efecto de quemado: 0%
  *	Efecto de agua: 0%
  *	Efecto de ascensión: False
  *	Efecto de sangrado: 0%
  *	Efecto de transformación: 1%
  *	Lugar de colocación: Mapa
  *	Coste: 400 monedas
  *	Tipo de target: Ataque en área
  *	Estadística especial: Aumento de daño

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen136.png" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen30.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 49. Charmando</i>
</p>

**Eklypsion**

Torre especial que genera oro y recurso extra por los enemigos que mueran en su área.

  *	Vida: 1500
  *	Rango: 10
  *	Velocidad de ataque: No se puede aplicar
  *	Daño: No se puede aplicar
  *	Efecto de hielo: No se puede aplicar
  *	Efecto de quemado: No se puede aplicar
  *	Efecto de agua: No se puede aplicar
  *	Efecto de ascensión: False
  *	Efecto de sangrado: No se puede aplicar
  *	Efecto de transformación: No se puede aplicar
  *	Lugar de colocación: Mapa
  *	Coste: 200 monedas
  *	Tipo de target: No se puede aplicar
  *	Estadística especial: Aumenta la velocidad de ataque

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen137.png" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen31.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 50. Eklypsion</i>
</p>

**Hihell**

Torre especial que invoca demonios aleatorios entre 3, que atacan a los enemigos de forma diferente según el demonio invocado.

  *	Vida: 500
  *	Rango: No se puede aplicar
  *	Velocidad de ataque: 0.5
  *	Daño: No se puede aplicar
  *	Efecto de hielo: No se puede aplicar
  *	Efecto de quemado: No se puede aplicar
  *	Efecto de agua: No se puede aplicar
  *	Efecto de ascensión: False
  *	Efecto de sangrado: No se puede aplicar
  *	Efecto de transformación: No se puede aplicar
  *	Lugar de colocación: Mapa
  *	Coste: 300 monedas
  *	Tipo de target: No se puede aplicar
  *	Estadística especial: Aumento velocidad de ataque

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen138.png" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen32.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 51. Hihell</i>
</p>

&nbsp;

# 8.**Enemigos**
Existen tres tipos diferentes de enemigos, enemigos finales, medianos y pequeños
-	Enemigo Final: Caracterizados por tener un tamaño mucho mayor al resto de enemigos y contar con habilidades únicas, además, son capaces de atacar a cualquier tipo de estructura, ya sean torretas situadas en el camino, en el exterior o a los héroes. Este tipo de enemigos tienen una vida muy superior al resto de enemigos. En cada zona solo existe un único enemigo final.

-	Enemigos medianos: Estos enemigos tienen un tamaño mayor que los enemigos pequeños pero menor que el enemigo final, se caracterizan por poder atacar a las torretas situadas en el camino y las torretas situadas en el exterior. Estos no pueden atacar al héroe. Estos enemigos tienen gran cantidad de vida y daño. En cada zona existen 2 tipos de enemigos medianos.

-	Enemigos pequeños: Estos enemigos tienen un tamaño pequeño, mucho menor al resto de enemigos, debido a que son el peor enemigo dentro del juego por sus estadísticas, no poseen la habilidad de atacar a las torretas situadas en el exterior a excepción de algunos, es decir por cada zona existe un enemigo pequeño que puede atacar desde lejos a las torretas situadas en el exterior. Estos enemigos tienen poca vida y poco daño. En cada zona existen 3 tipos de enemigos pequeños.

  ## 8.1. Winterfall
**Enemigo Final**

o	Hahandra: Hahandra es una bruja de hielo, cuya habilidad es invocar nuevos enemigos pequeños mientras se encuentra con vida y puede a tacar a cualquier tipo de torre y al héroe.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen33.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 52. Hahandra</i>
</p>

**Enemigos Medianos**

o	Mamut: Mamut gigante que camina protegiendo al resto de enemigos y embistiendo a las torres cercanas.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen34.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 53. Mamut</i>
</p>

o	Yety: Gigante de hielo que camina despacio y ataca a las torres con sus enormes brazos.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen35.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 54. Yeti</i>
</p>

**Enemigos pequeños**

o	Chup: Es un cuenco de cristal con cubitos de hielo, capaz de disparar a las torretas situadas en los extremos del camino.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen36.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 55. Chup</i>
</p>

o	Go BlinBlin: Es un goblin de hielo con un cuchillo en la mano.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen37.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 56. Go Blinblin</i>
</p>

o	Frederick: Es un pingüino aparentemente mono, pero que no te engañe, es peligroso y ataca a todo lo que tiene por delante.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen38.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 57. Frederick</i>
</p>

  ## 8.2. Farafra
**Enemigo Final**

o	Baraka Irwin: Basado en el dios Sobek de la mitología egipcia. Este jefe final posee la habilidad de curarse cada cierto tiempo, así como una gran hacha que le permite golpear el suelo haciendo daño a las torretas de su alrededor.  

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen39.jpg" width="300px">
</p>  
<p align="center">
<i>Ilustración 58. Baraka Irwin</i>
</p>

**Enemigos Medianos**

o	Escorpy: Escorpión que ataca a unidades y torres con su aguijón.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen40.jpg" width="300px">
</p>  
<p align="center">
<i>Ilustración 59. Escorpy</i>
</p>

o	Oba: soldado egipcio de arena que se puede proteger gracias a su escudo y atacar con su espada.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen41.jpg" width="300px">
</p>  
<p align="center">
<i>Ilustración 60. Oba</i>
</p>

**Enemigos pequeños**

o	DirtyPaper: momia que ataca a las torres con las manos

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen42.jpg" width="300px">
</p>  
<p align="center">
<i>Ilustración 61. DirtyPaper</i>
</p>

o	Mokri: soldado egipcio que lleva una poderosa espada para atacar.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen43.jpg" width="300px">
</p>  
<p align="center">
<i>Ilustración 62. Mokri</i>
</p>

o	LizSand: pequeño lagarto de arena que escupe su veneno a las torretas situadas en los extremos del terreno. 

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen44.jpg" width="300px">
</p>  
<p align="center">
<i>Ilustración 63. LizSand</i>
</p>

  ## 8.3. Atlantis
**Enemigo Final**

o	Boze Vode: Basado en Poseidón de la mitología griega. Este jefe final posee la habilidad de atacar con su gran lanza e infligir enormes cantidades de daño a todo lo que golpee. Debido a la envidia que tiene a Maribel, Boze ha mejorado sus habilidades de canto que provoca que sus aliados sean más rápidos.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen45.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 64. Boze Vode</i>
</p>

**Enemigos Medianos**

o	Salo: morsa marina con una minigun en la espalda que ataca a las torres desde la distancia.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen46.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 65. Salo</i>
</p>

o	Morski: sirenas montadas en caballos de mar que guían al resto de enemigos hasta su destino.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen47.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 66. Morski</i>
</p>

**Enemigos pequeños**

o	Konj: Es un sireno 

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen48.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 67. Konj</i>
</p>

o	Axu: Es un ajolote capaz de disparar a las torretas del exterior, y utilizando el veneno que escupe por su boca.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen49.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 68. Axu</i>
</p>

o	Ginrelk: cangrejo con una pinza gigante desproporcionada a su tamaño.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen50.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 69. Ginrelk</i>
</p>

  ## 8.4. Valhalla
**Enemigo Final**

o	Firulais: basado en Fenrir de la mitología nórdica. Firulais es capaz de invocar a nuevos aliados y utilizar sus grandes mandíbulas para atacar a las torretas y héroes.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen51.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 70. Firulais</i>
</p>

o	Eyra: es una valkyria caída capaz de volar, de manera que puede sobrepasar solo el resto de los enemigos. 

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen52.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 71. Eyra</i>
</p>

o	Aren: es un gigante azul lento pero una gran capacidad de destrucción.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen53.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 72. Aren</i>
</p>

**Enemigos pequeños**

o	Borj: es un no muerto vikingo  

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen54.jpg" width="300px">
</p>  
<p align="center">
<i>Ilustración 73. Borj</i>
</p>

o	Alf: Es un elfo oscuro, capaz de disparar a las torretas exteriores con su arco oscuro 

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen55.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 74. Alf</i>
</p>

o	Berquist: vikingo tradicional

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen56.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 75. Berquist</i>
</p>

  ## 8.5. Selva mágica
**Enemigo Final**

o	Svinja: Es el rey de los animales de la Selva Mágica, basado en un ogro gigante. Snivia es capaz de golpear con sus grandes puños y reganarse vida cada cierto tiempo empelando el cuerpo de sus aliados caídos.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen57.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 76. Svinja</i>
</p>

**Enemigos Medianos**

o	VodaRider: son Goblins capaces de montar vodas, especies de lobos únicos de la selva mágica, caracterizados por su alta velocidad.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen58.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 77. VodaRider</i>
</p>

o	Nakaka: son orcos gigantes lentos pero fuertes que atacan a las torretas empleando poderosos golpes con sus puños.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen59.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 78. Nakaka</i>
</p>

**Enemigos pequeños**

o	Magic Go Blin: Es un goblin con una maza en su mano que tira a las torretas enemigas para debilitarlas.  

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen60.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 79. Magic Go Blin</i>
</p>

o	Warfy: goblins pequeños con el único objetivo de correr hasta las torres y explotar contra ellas.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen61.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 80. Warfy</i>
</p>

o	Voda: especies de lobos únicos de la selva mágica, caracterizados por su alta velocidad.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen62.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 81. Voda</i>
</p>

  ## 8.6. Trost sumido en el infierno
**Enemigo Final**

o	Pyerno: Basado en satanás, lucifer y referencias en general de los reyes del inframundo, su arma es un tridente de fuego con el que hace daño a las torretas y posee la habilidad de resucitar a los muertos (invoca a enemigos pequeños) 

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen63.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 82. Pyerno</i>
</p>

**Enemigos Medianos**

o	Keryon: Es un golem de fuego con la capacidad de erupcionar para atacar a las torres.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen64.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 83. Keryon</i>
</p>

o	Toby: basado en Cerbero, poderoso perro de tres cabezas que habita en el infierno 

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen65.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 84. Toby</i>
</p>

**Enemigos pequeños**

o	Sunog: Es un pequeño diablo con alas, lo que le permite volar sobrepasando a sus aliados. Moviendo sus alas a gran velocidad puede crear corrientes de calor que dañan a las torretas

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen66.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 85. Sunog</i>
</p>

o	Toby do fogo: Es un perro en llamas que busca apagar el fuego de su cuerpo por lo que corre a gran velocidad para lograr su objetivo..

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen67.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 86. Toby do fogo</i>
</p>

o	Fire Blin: es un pequeño espíritu de fuego que corre hasta las torres para prenderlas fuego.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen68.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 87. Fire Blin</i>
</p>

 ## 8.7. Enemigo final del juego
Mago Oscuro: El enemigo final del juego es un mago oscuro que posee la habilidad de viajar por el tiempo y que posee 5 de los fragmentos del corazón de Trost. Su tamaño es mucho mayor al de los enemigos finales, así como sus estadísticas. Este enemigo final cuenta con la capacidad de invocar a enemigos finales de otros territorios, además de 3 habilidades especificas más:  

-Invoca esqueletos que se centran en atacar las torres de fuera del camino

-Lanza una bola mágica a una torre en su rango y la inutiliza durante 15 segundos

-Lanza un rayo de energía a un área haciendo daño a todas las unidades

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen69.png" width="300px">
</p>  
<p align="center">
<i>Ilustración 88. Mago Oscuro</i>
</p>

&nbsp;  

# 9.**Arte 2D** 
El arte 2D está conformado por el HUD, que es visible en todas las pantallas, las pantallas que no sean de partida, e iconos que nos aportan información extra dentro de una partida.

  ## 9.1. HUD
El HUD durante la partida está formado por una barra inferior que contiene todas las torretas disponibles, su precio e icono. En la parte superior una barra que especifica el número de ronda y los enemigos que quedan en dicha ronda. Cuando hacemos click en alguna torreta ya colocada en el terreno aparecerá un menú en la parte derecha de la pantalla que muestra la información de dicha torreta, sus estadísticas, nivel de mejora y costa de mejora. 

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen139.png" width="700px">
</p>  
<p align="center">
<i>Ilustración 89. HUD del juego</i>
</p>

 ## 9.2. Pantallas
El arte 2D de las pantallas está presente en la pantalla principal/inicio, que nos encontramos nada más entrar al juego, conformada por un fondo diseñado en 2D, acompañado de su respectivo HUD, la pantalla de opciones, en la que podemos ver un fondo igual al del menú principal, pero con un fondo/tono más grisáceo, todo esto acompañado de su respectivo HUD, pantalla post-partida, pantalla créditos y pantalla wiki.

**9.2.1.Pantalla tutorial**

Se han generado un conjunto de pantallas a modo de tutorial para que los jugadores puedan consultarlas en cualquier momento durante la partida para resolver sus dudas.

Estas pantallas de dividen en pantallas de información general e información concreta de cada mundo.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen140.png" width="700px">
</p>  
<p align="center">
<i>Ilustración 90. Tutorial general 1</i>
</p>

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen141.png" width="700px">
</p>  
<p align="center">
<i>Ilustración 91. Tutorial general 2</i>
</p>

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen142.png" width="700px">
</p>  
<p align="center">
<i>Ilustración 92. Tutorial mundo específico</i>
</p>

 ## 9.3. Iconos
Todas las torretas del juego contarán con un icono único que aparecerá en la barra de compra de torretas en la parte de abajo del HUD, y en el menú de información de las torretas cuando se les hace click encima.

**Iconos de estadísticas de torretas**

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen143.png" width="500px">
</p>  
<p align="center">
<i>Ilustración 93. Iconos de estadísticas de torretas</i>
</p>

**Iconos de efectos**

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen144.png" width="500px">
</p>  
<p align="center">
<i>Ilustración 94. Iconos de efectos</i>
</p>

**Barra de información en las rondas**

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen145.png" width="500px">
</p>  
<p align="center">
<i>Ilustración 95. Barra de información en las rondas</i>
</p>

**Botones**

Ejemplo de algunos botones

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen146.png" width="500px">
</p>  
<p align="center">
<i>Ilustración 96. Ejemplo algunos botones</i>
</p>

&nbsp;  

# 10.**Historia**
Trost, el planeta donde se desarrolla la historia basa su estabilidad en el corazón de Trost, una gema divida en 6 fragmentos repartidos por diferentes territorios del planeta, a lo largo de los tiempos 5 de estos han sido robados por el Mago Oscuro, un viajero del tiempo que busca reunir los 6 fragmentos para conquistar Trost. Tras finalizar el quinto ataque a Trost y robar el quinto fragmento el Mago Oscuro planea ir por el sexto y último fragmento. 

Paralelamente a este último suceso el protagonista de nuestra historia se encuentra jugando en su habitación al mejor videojuego estrategia, ya que se encuentra el en top 1 de todos los juegos de estrategia del mundo y no quiere que nadie le arrebate el puesto. Mientras está jugando recibe un extraño mensaje donde le invitan a jugar a un nuevo videojuego de estrategia que promete ser el mejor, el jugador acepta. En ese momento es teletransportado 100 años en el futuro encontrándose con Trost destruido, y con un extraño anciano, el cual explica al protagonista que el Mago Oscuro está atacando Trost para obtener el sexto y último fragmento del corazón de Trost que le permitirá conquistar el planeta. A parte de esto también le explica que él ha sido elegido para defender Trost debido a sus habilidades de estrategia, por lo que el anciano dota al protagonista del poder de viajar en el tiempo, para que viaje a los momentos exactos donde el Mago Oscuro robo los fragmentos para impedir que este los posea y una vez defendidos le pide que los reúna todos y se enfrente al Mago Oscuro para devolver la paz a Trost.

Explicado esto nuestro protagonista decide embarcarse en la misión que el anciano le encomienda, viajando hacia el pasado a los momentos y lugares exactos para defender los fragmentos. Los territorios a los que debe viajar son: WinterFall antiguo imperio de hielo, la pirámide de Farafra en el gran Desierto de Trost, Atlantis situado bajo las profundidades del océano, la Selva Mágica y el Valhalla, lugar donde los dioses de Trost residen. 

Defendidos los diferentes territorios nuestro protagonista tendrá en su poder los 5 fragmentos necesarios para enfrentarse con el Mago Oscuro, de manera que se vuelve a reunir con el anciano en el futuro, comenzando así su último y definitivo combate, en el que deberá poner a prueba todos los conocimientos y habilidades adquiridas durante su viaje. 

Tras una batalla frenética el Mago Oscuro es derrotado y nuestro protagonista obtiene el 6 fragmento del corazón de Trost, haciendo que este se convierta en uno solo provocando que nuestro protagonista caiga en la maldición del corazón de Trost, convirtiéndole en el Mago Oscuro provocando que quiera conquistar Trost, dando lugar a que la historia se repita.

&nbsp;

# 11.**Sonido/Música** 
La música y los efectos de sonidos no son de creación propia, por lo que se ha buscado sonido y música libre de derechos.

  ## 11.1. Música

El juego contara con tres pistas de música diferentes, la música del menú principal y la música ingame, esta última cuenta con dos pistas de audio que se alternan entre ellas

**11.1.1. In-game**

La música ingame se divide en 2, por un lado, está la música que suena durante la ronda, la cual es más frenética y movida, mientras que por el otro lado está la música entre rondas la cual es más calmada.

**11.1.2. Menús**

En los menús se escucha una música de fondo de motivación, para poner al jugador en contexto.  

  ## 11.2. Efectos de sonido
El juego contiene diferentes efectos de sonido en función de las acciones que ocurren en este. Cada torreta dependiendo del tipo de ataque que realiza tendrá un efecto de sonido diferente, además al golpear a los enemigos este impacto también tendrá su efecto de sonido. Los hechizos de los héroes tienen cada uno un sonido característico acorde a lo que produce si hechizo. Los botones al ser clicados también tienen un efecto se sonido que ayuda a fomentar la retroalimentación que recibe el jugador respecto del juego. También existen sonidos para cuando las torretas se mejoran o son destruidas. La pérdida de vida de la torre principal también se complementa con un efecto de sonido.

&nbsp;
    
# 12.**Monetización** 
En ordenador, el juego tendrá 2 versiones:

-	Una demo gratuita con 2 de los 6 niveles con todo lo que incluye aparte del modo infinito limitado por el contenido que ofrece la demo. Es decir, dos mundos con sus correspondientes niveles del modo campaña, torretas, enemigos y héroes. Además, también tendrán acceso al modo ilimitado, pero de forma limitada, es decir con un límite de rondas (que será mayor a las rondas que hay en los niveles del modo campaña)
-	La otra versión sería una versión de pago, que costaría 6.99€, la cual incluye todo el contenido que puede ofrecer el juego, actualmente tiene 6 mundos distintos con sus correspondientes torretas, enemigos y héroes, además de poder tener acceso a héroes o torretas adicionales que no corresponden a ningún mundo. Estos usuarios tendrán acceso al modo ilimitado sin ningún tipo de restricción del número de rondas.
-	Hay dos monedas dentro del juego:

o	Monedas normales que se consiguen jugando.

o	Monedas premium que se consiguen poco a poco jugando, mediante un login diario o mediante su compra.

En la versión de móvil, también habrá las mismas versiones, pero con ligeros cambios:

-	Demo: Tendrá anuncios después de x partidas o x tiempo y solo contendrá los dos primeros mundos, al igual que un límite en el modo infinito. 
-	Pago: igual que las versiones de pc, contendría el resto de los mundos y además se eliminarían los anuncios, pero su precio bajaría a 3,99€, un precio más accesible para los usuarios de móvil.

 ## 12.1. Caja de herramientas
La siguiente imagen muestra la caja de herramientas de la empresa TeamSalchichill. TeamSalchichill tiene 6 relaciones clave para poder llevar a cabo su modelo de negocio. 

Para poder llevar a cabo nuestro producto establecemos relaciones con Unity donde ellos nos proporcionan su motor de videojuegos a cambio del precio por su uso, Discord que nos proporciona una herramienta para comunicarnos entre los miembros y VoxelEdit y VoxEdit que nos proporcionan las herramientas necesarias para modelar y animar los diferentes elementos que forman el videojuego.

Finalmente tenemos dos últimas relaciones que nos sirven para vender y promocionar nuestro producto. Una de ellas es mantener relaciones con influencers para que promocionen nuestro videojuego dándonos así viabilidad y exposición a cambio de dinero y nuestro producto. Finalmente, la relación que nos permite vender el videojuego la establecemos con Itch.io le proporcionamos nuestro producto para que ellos lo vendan a los consumidores a cambio de su precio.  Con esta relación obtenemos visibilidad, exposición y dinero a cambio de poco dinero que damos a Itchi.io por alojar nuestro videojuego en su web.

<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen76.png" alt="JuveR" width="700px">
</p>  
<p align="center">
<i>Ilustración 97. Caja de herramientas</i>
</p>

 ## 12.2. Bussines model canvas
 
<p align="center">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen77.png" alt="JuveR" width="700px">
</p>  
<p align="center">
<i>Ilustración 98. Business model canvas</i>
</p>
 
&nbsp;

# 13.**Propósito, público objetivo y plataformas** 
  ## 13.1. Propósito
El propósito general es el diseño y desarrollo de un videojuego acorde a todo el trabajo realizado anteriormente y que se realizará a posterior para cumplir con unas expectativas marcadas.

  ## 13.2. Público objetivo
El público objetivo del videojuego se trata de jóvenes de entre 12 - 18 años, que quieran divertirse y pasar el tiempo con partidas rápidas y diferentes. Los usuarios que juegan a nuestro juego serán jugadores interesados en los juegos de estrategia, pero no necesariamente amantes de los videojuegos sino usuarios que busquen matar el tiempo con un videojuego dinámico y diferente en cada partida.

  ## 13.3. Plataformas
El videojuego será lanzado inicialmente para Pc, en las plataformas de itch.io y Steam, pero está planeado que también exista una versión compatible para dispositivos móviles, publicada en la Play Store y la Apple Store.

&nbsp;  

# 14.**Hitos**
  ## 14.1. Hito 1 - Versión Alpha
Fecha: 30/10/2022

Contenido: Una versión jugable

  ## 14.2. Hito 2 - Versión Beta
Fecha: 20/11/2022

Contenido: El juego terminado sin pulir

  ## 14.3. Hito 3 - Versión Gold Master
Fecha: 11/12/2022

Contenido: El juego terminado y pulido

  ## 14.4. Hito 4 - Publicación
Fecha: 12/12/2022

Contenido: publicación del videojuego

