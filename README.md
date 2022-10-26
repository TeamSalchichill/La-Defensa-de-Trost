# La Defensa de Trost

**Team Salchichill**

<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen1.png" alt="JuveR" width="300px">

UNIVERSIDAD REY JUAN CARLOS

ESCUELA TÉCNICA SUPERIOR EN INGENIERÍA INFORMÁTICA

GRADO EN DISEÑO Y DESARROLLO DE VIDEOJUEGOS

Juegos para web y redes sociales

&nbsp;

<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen2.png" alt="JuveR" width="300px">
<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen3.png" alt="JuveR" width="300px">

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
  * 2.1. Fuera de partida 
  * 2.2. Dentro de partida
  * 2.3. Controles
  * 2.4. Cámara
* 3.**Terreno** 
  * 3.1. Winterfall
  * 3.2. Farafra
  * 3.3. Atlantis
  * 3.4. Valhalla
  * 3.5. Fantasía
  * 3.6. Infierno
* 4.**Torres principales** 
  * 4.1. Winterfall
  * 4.2. Farafra
  * 4.3. Atlantis
  * 4.4. Valhalla
  * 4.5. Selva mágica
  * 4.6. Trost sumido en el infierno
* 5.**Torretas**
  * 5.1. General
  * 5.2. Winterfall
  * 5.3. Farafra
  * 5.4. Atlantis
  * 5.5. Valhalla
  * 5.6. Selva mágica
  * 5.7. Trost sumido en el infierno
* 6.**Enemigos** 
  * 6.1. Winterfall
  * 6.2. Farafra
  * 6.3. Atlantis
  * 6.4. Valhalla
  * 6.5. Selva mágica
  * 6.6. Trost sumido en el infierno
* 7.**Héroes** 
  * 7.1. Winterfall
  * 7.2. Farafra
  * 7.3. Atlantis
  * 7.4. Valhalla
  * 7.5. Selva mágica
  * 7.6. Trost sumido en el infierno
* 8.**Arte 2D** 
  * 8.1. HUD
  * 8.2. Pantallas
    * 8.2.1. Mapa de pantallas
  * 8.3. Iconos
* 9.**Historia**
* 10.**Sonido/Música** 
  * 10.1. Música
    * 10.1.1. In-game
    * 10.1.2. Menús
  * 10.2. Sonidos
    * 10.2.1. In-game
    * 10.2.2. Menús
* 11.**Monetización** 
  * 11.1. Caja de herramientas
  * 11.2. Bussines model canvas
* 12.**Propósito, público objetivo y plataformas** 
  * 12.1. Propósito
  * 12.2. Público objetivo
  * 12.3. Plataformas
* 13.**Hitos**
  * 13.1. Hito 1 - Versión Alpha
  * 13.2. Hito 2 - Versión Beta
  * 13.3. Hito 3 - Versión Gold Master
  * 13.4. Hito 4 - Publicación


&nbsp;

# 1.**Sinopsis**
La defensa de Trost es un videojuego que combina el Tower defense con el Roguelike en el que se tiene que defender diferentes zonas para recuperar las 6 partes de un tesoro que ha sumido al mundo en la oscuridad. Cada fragmento del tesoro está en una zona completamente diferente, y cada zona tiene torretas, enemigos y mecánicas diferentes. El mapa se genera de forma aleatoria y procedural por lo que cada partida es completamente diferente.

&nbsp;

# 2.**Mecánicas**
  ## 2.1. Fuera de partida 
Cuando se está fuera de partida se puede acceder a la tienda destinada para el modo infinito en la cual se pueden comprar héroes, torres, cartas y habilidades de torre principal que se pueden usar en partida. Para poder comprar cualquier de estas cosas tienes que haberte pasado el nivel al que pertenecen, para si desbloquearlas.
  ## 2.2. Dentro de partida
Cada mapa tiene una torre principal con una habilidad especial la cual se puede usar cada cierto número de rondas dependiendo de la zona en la que se halle el jugador. La torre principal cada 5 rondas sube de nivel y mejora su habilidad. En cada mapa hay casillas especiales que otorgan efectos únicos tanto a las torretas como a los enemigos. En cada zona encontramos 3 torretas nuevas y 6 nuevos enemigos, divididos en 3 pequeños, 2 mediano y un jefe final.
Existen dos modalidades de juego el modo campaña y el modo infinito. En el modo campaña jugaras en la zona específica seleccionada teniendo acceso únicamente a la torre principal, torretas y enemigos propios de esta zona. En este modo de juego la partida está formada por un numero de rondas limitadas. En el modo infinito tienes la opción de elegir 6 torretas independientemente de la zona a la que pertenezcan, los enemigos en este modo también pueden ser de cualquier zona y no existe un numero de rondas, sino que la partida acaba cuando la torre principal es destruida.
Durante la partida cada cierta ronda te aparece unos dados que los tienes que tirar y en función del número que te salga aparecen más o menos cartas, de entre las cartas que te salen tienes que elegir una. Hay que tirar 2 dados, del primero que tiras te salen cartas que me mejorar las torres y el segundo a los enemigos.
El mapa se genera procedural y completamente aleatoria en cada partida, pero siempre hay un objetivo hacia el objetivo.
Las principales variables que influyen en la generación del mapa son las probabilidades de que los caminos sean rectos o no, de que se curven, de que se corten, de generar casillas especiales, de generar obstáculos y de conectar caminos.

<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen4.png" alt="JuveR" width="300px">

  ## 2.3. Controles
Los controles se basan en el uso del teclado y del ratón:
-	Colocación de torretas: clicar sobre la torreta a colocar y arrástrala a la casilla donde se quiere colocar.
-	Mejora de torretas: clicar sobre la torreta y pulsar en el botón de mejora
-	Lanzamiento de hechizos/habilidades especiales de cada zona: clicar sobre el terreno de juego donde quieras lanzarlo
-	Venta de torretas: clicar sobre la torreta y pulsar sobre el botón vender
-	Mover cámara: uso de las teclas A, W, S, D para mover la cámara. 

  ## 2.4. Cámara
El juego posee una cámara ortográfica enfocando al videojuego con una vista isométrica que permite observar todo el terreno de juego.
Para el control de la cámara disponemos de herramientas por teclado (teclas W-A-S-D) o de desplazamiento mediante el ratón.
Para acercar o alejar el punto de vista del jugador se puede emplear la rueda del ratón.

&nbsp;

# 3.**Terreno** 
En cada nivel hay un terreno diferente, y cada terreno tienes unas características únicas.
  ## 3.1. Winterfall
En este terreno existen casillas especiales que si están en el terreno y pones una torreta encima hace que este aplique más efecto de congelamiento con sus disparos a los enemigos.
En el caso de que estas casillas se encuentren en el camino y los enemigos pasen por encima estos se ralentizaran.
El efecto de congelación hace que los enemigos vayan más lentos hasta un máximo de la mitad de su velocidad original.

  ## 3.2. Farafra
Las casillas especiales de Farafra si se encuentran en el terreno y colocas una torreta encima suya hace que apliquen más efecto de quemado sobre el enemigo.
En el caso de que se encuentren en el camino a estos se le aplicaran más efecto de quemado.
El efecto de quemado hace que los enemigos pierdan vida poco a poco y cuando llegan al 100% de quemado el enemigo recibe daño extra y su quemado baja al 0%.
Por otro lado, hay casillas quemadas, que lo que hace es que, si colocas una torre sobre ella esta va a disparar más rápido, pero se va a sobrecalentar y va a hacer que esté unos segundos sin poder disparar hasta que se enfríe.
Por último, en este mapa hay zonas que tienen una tormenta de arena que dura varios turnos. Mientras esté activa dicha tormenta no podrás construir en esa zona.

  ## 3.3. Atlantis
En el mapa de Atlantis las casillas del camino son corrientes de agua que cada varias rondas cambia la dirección de la corriente. Esta corriente mueve a los enemigos en esa dirección, haciendo que vayan más rápido o más lento dependiendo de la dirección.
Por otro lado, hay casillas en el terreno que si colocas una torre esta aplica humedad.
La humedad al llegar al 100% hace que una ola lo levante y no pueda hacer nada durante 1 segundo.

  ## 3.4. Valhalla
En el Valhalla existen unas casillas muy raras que hacen que si están en el terreno y pones una torre encima esta es ascendida, es decir, esa torre tiene todas las estadísticas subidas.
En el caso de que se encuentren el camino, los enemigos que pasen por encima son ascendidos, es decir, todas sus estadísticas son subidas.

  ## 3.5. Fantasía
En el bosque de fantasía hay casillas en el camino en las que hay espinas, que hace que los enemigos que pasen por encima sufran sangrado.
En el terreno también aparecen unas casillas especiales que si pones una torreta encima esta obtiene un escudo (vida extra) y velocidad de ataque.

  ## 3.6. Infierno
En el infierno hay casillas de sacrificio, que si se encuentran en el camino hace que los enemigos que pasen por encima se le aplique un porcentaje de locura. En el caso de que se encuentren en el terreno las torres que se encuentren encima hace que sus disparos quiten efecto de locura.
El efecto de locura hace que si llega al 100% el enemigo muera, pero invoque un enemigo muy fuerte.
Aparte de estas casillas también están las casillas de la zona del desierto.
  
&nbsp;

# 4.**Torres principales** 
  ## 4.1. Winterfall
La torre principal de WinterFall es un castillo helado donde se encuentra el primer fragmento del corazón de Trost. En el castillo existen brujos de hielo capaces de invocar hechizos de hielo, que congelan a los enemigos.
-	Poder Torre principal: Hechizo de hielo (sobre una zona se congelan los enemigos)

<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen5.png" alt="JuveR" width="300px">

  ## 4.2. Farafra
Farafra es un templo situado en el gran Desierto de Trost, en este templo se encuentra el segundo fragmento del corazón de Trost. Farafra es una gran pirámide con la habilidad de corromper a quien osa atacarla.
-	Poder Torre principal: Hechizo que hace que los enemigos se peguen entre ellos

<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen6.jpg" alt="JuveR" width="300px">

  ## 4.3. Atlantis
El castillo de Maribel es la torre principal de Atlantis, en él se encuentra la orquesta real del reino que es capaz de invocar grandes olas cuando su reino se ve amenazado, por lo que son los protectores del tercer fragmento del corazón de Trost.
-	Poder Torre principal: Una ola que levanta a todos los enemigos y no les puedes golpear

<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen7.png" alt="JuveR" width="300px">

  ## 4.4. Valhalla
El Valhalla es el hogar de los dioses de Trost, en su edificio principal vienen los dioses más fuertes de Trost cuya misión es defender el cuarto fragmento del corazón de Trost, capaces de invocar una gran lanza para atacar a sus enemigos empleando sus diferentes habilidades.
-	Poder Torre principal: Cae una gran lanza el camino que llegue a la torre principal provocando mucho daño a los enemigos que estén en él.

<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen8.jpg" alt="JuveR" width="300px">

  ## 4.5. Selva mágica
La torre principal de la selva mágica es el gran árbol de Trost, este árbol alberga en su interior el quinto fragmento del corazón de Trost. Gracias a ser el árbol más longevo de la selva posee la capacidad curar y proteger a sus habitantes. 
-	Poder Torre principal: Cae un hechizo “Crecimiento salvaje” y las torres afectadas obtienen un escudo que les multiplica su velocidad de ataque mientras este escudo este activo o se rompa.

<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen9.jpg" alt="JuveR" width="300px">

  ## 4.6. Trost sumido en el infierno
La torre principal del infierno es la sede central del gobierno de Trost, donde se encuentra el ultimo fragmento del corazón de Trost. Esta sede es el lugar donde el protagonista es teletransportado al inicio de la historia y donde ve Trost destruida. En ella se encuentran grandes aliados de Trost capaces de invocar ataques de fuego. 
-	Poder Torre principal: De la torre principal sale una bola de fuego gigante hacia delante y hace daño.

<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen10.jpg" alt="JuveR" width="300px">

&nbsp;  
# 5.**Torretas**
  ## 5.1. General
  ## 5.2. Winterfall
  ## 5.3. Farafra
  ## 5.4. Atlantis
  ## 5.5. Valhalla
  ## 5.6. Selva mágica
  ## 5.7. Trost sumido en el infierno
&nbsp;  
# 6.**Enemigos** 
  ## 6.1. Winterfall
  ## 6.2. Farafra
  ## 6.3. Atlantis
  ## 6.4. Valhalla
  ## 6.5. Selva mágica
  ## 6.6. Trost sumido en el infierno
&nbsp;  
# 7.**Héroes** 
  ## 7.1. Winterfall
Rey Fannar: El rey Fannar es el último descendiente de la corona de WinterFall, se caracteriza por llevar siempre consigo su bastón de hielo que le permite lanzar bolas de hielo a los enemigos, haciendo daño en área y congelándolos. Además, posee un ataque especial defensivo que le permite crear muros de hielo en el camino para impedir que los enemigos puedan avanzar.

Ataque normal: lanza-bolas de hielo a los enemigos, haciendo daño en área y congelándolos 

Activa: crear muros de hielo en el camino para impedir que los enemigos puedan avanzar, estos muros de hielo los invoca cada 30 segundos y duran hasta que se derritan, tras 20 segundos o sean destruidos.

<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen70.png" alt="JuveR" width="300px">

  ## 7.2. Farafra
Rey Axiryus: El rey Axiryus, está basado en el dios Ra de la mitología griega, como es un rey muy mayor no tiene casi fuerzas para mantenerse en pie por lo que está siempre sentado en su trono. Para atacar a los enemigos emplea su cetro el cual genera un rayo continuo que daña a los enemigos en el área que golpea quemando a estos. Además, cuenta con la habilidad de invocar dos obeliscos a su alrededor que curan a las torretas aliadas cercanas, esta habilidad la realiza cada mucho tiempo ya que para invocarlos necesita levantarse de su trono. 

Ataque normal: Emplea su centro generando un rayo continuo que daña a los enemigos en el área donde golpea aplicando quemaduras sobre estos.

Activa: Invoca dos obeliscos a su alrededor que curan a las torretas aliadas cercanas.

<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen71.jpg" alt="JuveR" width="300px">

  ## 7.3. Atlantis
Reina Maribel: Maribel es la reina de Atlantis, como buena reina de su país no le gusta ver a sus habitantes en guerra por lo que emplea su canto para motivarlos y así acabar con la guerra lo antes posible. Maribel posee pésimas habilidades de canto por lo que los enemigos al escucharlas se ven dañados, pero en cambio los habitantes de Atlantis como idolatran a su reina se ven motivados. Maribel es un fan de cantar el himno de su nación por lo que cuando lo canta sus aliados se extra motivan provocando que aumenten sus ganas de defender su país.

Ataque normal: utiliza su canto para dañar a los enemigos, su daño es en área ya que todos los enemigos que se acercan a ella sufren su canto.

Activa: Canta el himno de su población provocando que las torretas aliadas cercanas aumenten su velocidad de ataque.

<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen72.png" alt="JuveR" width="300px">

  ## 7.4. Valhalla
Rey Lothbrock: El rey LothBrock es el mejor dios de Trost, por lo que reina en el Valhalla. LothBrock es un fanático de las tormentas de rayos por lo que motivado por su afición logró fabricar un martillo capaz de invocar rayos. LothBrock emplea este martillo para atacar a los enemigos, lanzándoles rayos que rebotan entre los enemigos, a su vez posee una gran habilidad para invocar tormentas de rayos que dañan al enemigo cuanto más cerca este de ellas.

Ataque normal: lanza rayos que rebotan en los enemigos

Activa: Invocación de tormenta que crea un ataque en un área que hace más daño cuanto más cerca del centro estés

<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen73.png" alt="JuveR" width="300px">

  ## 7.5. Selva mágica
Reina Tatinia: La Reina Tatinia es una reina que sobrepone la belleza y salud de ella y de su reino por encima de todo, debido a su delicadeza sus ataques no son muy potentes en uno contra uno, por lo que prioriza golpear al máximo número de enemigos. La belleza debe resaltar ante todo, así que esta reina buscará curar a todos sus aliados para que estén en perfecto estado. Como ella siempre dice, antes muerta que sencilla.

Ataque AOE

Activa: Cura a todas las torres aliadas (rango global) y aumenta su velocidad de ataque y daño 1.25 durante 10 segundos.

<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen74.png" alt="JuveR" width="300px">

  ## 7.6. Trost sumido en el infierno
Rey Bubuyog: El rey Bubuyog se destaca, como cualquier mosca, por ser sucio y su modo juego no iba a ser menos, su táctica consiste atacar de lejos mediante un báculo y en crear moscas que ataquen a los enemigos, provocándoles picazones y la rabia, volviéndoles más agresivos y perdiendo el control, haciendo que se peguen entre ellos, después de hacer que se maten entre ellos, las moscas harán un buen uso de su cadáver.

<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen75.png" alt="JuveR" width="300px">

&nbsp;  

# 8.**Arte 2D** 
El arte 2D está conformado por el HUD, que es visible en todas las pantallas, las pantallas que no sean de partida, e iconos que nos aportan información extra dentro de una partida.

  ## 8.1. HUD
El HUD durante la partida está formado por una barra inferior que contiene todas las torretas disponibles, su precio e icono. En la parte superior una barra que especifica el número de ronda y los enemigos que quedan en dicha ronda. Cuando hacemos click en alguna torreta aparecerá un menú en la parte derecha de la pantalla que muestra la información de dicha torreta, sus estadísticas, nivel de mejora y costa de mejora. 
 
 ## 8.2. Pantallas
El arte 2D de las pantallas está presente en la pantalla principal/inicio, que nos encontramos nada más entrar al juego, conformada por un fondo diseñado en 2D, acompañado de su respectivo HUD, la pantalla de opciones, en la que podemos ver un fondo igual al del menú principal, pero con un fondo/tono más grisáceo, todo esto acompañado de su respectivo HUD, pantalla post-partida, pantalla créditos y pantalla wiki

**8.2.1.Mapa de pantallas**

El mapa se divide en una pantalla de menú principal desde la cual se puede acceder a opciones y empezar partida. SI se selecciona está última, aparecerá un menú interactivo (las opciones serían edificios y estructuras que se pueden seleccionar) donde se podrá acceder tanto al modo historia como al modo infinito, y a la tienda.
 
 ## 8.3. Iconos
Todas las torretas del juego contarán con un icono único que aparecerá en la barra de compra de torretas en la parte de abajo del HUD, y en el menú de información de las torretas cuando se les hace click encima.

&nbsp;  

# 9.**Historia**
Trost, el planeta donde se desarrolla la historia basa su estabilidad en el corazón de Trost, una gema divida en 6 fragmentos repartidos por diferentes territorios del planeta, a lo largo de los tiempos 5 de estos han sido robados por el Mago Oscuro, un viajero del tiempo que busca reunir los 6 fragmentos para conquistar Trost. Tras finalizar el quinto ataque a Trost y robar el quinto fragmento el Mago Oscuro planea ir por el sexto y último fragmento. 

Paralelamente a este último suceso el protagonista de nuestra historia se encuentra jugando en su habitación al mejor videojuego estrategia, ya que se encuentra el en top 1 de todos los juegos de estrategia del mundo y no quiere que nadie le arrebate el puesto. Mientras está jugando recibe un extraño mensaje donde le invitan a jugar a un nuevo videojuego de estrategia que promete ser el mejor, el jugador acepta. En ese momento es teletransportado 100 años en el futuro encontrándose con Trost destruido, y con un extraño anciano, el cual explica al protagonista que el Mago Oscuro está atacando Trost para obtener el sexto y último fragmento del corazón de Trost que le permitirá conquistar el planeta. A parte de esto también le explica que él ha sido elegido para defender Trost debido a sus habilidades de estrategia, por lo que el anciano dota al protagonista del poder de viajar en el tiempo, para que viaje a los momentos exactos donde el Mago Oscuro robo los fragmentos para impedir que este los posea y una vez defendidos le pide que los reúna todos y se enfrente al Mago Oscuro para devolver la paz a Trost.

Explicado esto nuestro protagonista decide embarcarse en la misión que el anciano le encomienda, viajando hacia el pasado a los momentos y lugares exactos para defender los fragmentos. Los territorios a los que debe viajar son: WinterFall antiguo imperio de hielo, la pirámide de Farafra en el gran Desierto de Trost, Atlantis situado bajo las profundidades del océano, la Selva Mágica y el Valhalla, lugar donde los dioses de Trost residen. 

Defendidos los diferentes territorios nuestro protagonista tendrá en su poder los 5 fragmentos necesarios para enfrentarse con el Mago Oscuro, de manera que se vuelve a reunir con el anciano en el futuro, comenzando así su último y definitivo combate, en el que deberá poner a prueba todos los conocimientos y habilidades adquiridas durante su viaje. 

Tras una batalla frenética el Mago Oscuro es derrotado y nuestro protagonista obtiene el 6 fragmento del corazón de Trost, haciendo que este se convierta en uno solo provocando que nuestro protagonista caiga en la maldición del corazón de Trost, convirtiéndole en el Mago Oscuro provocando que quiera conquistar Trost, dando lugar a que la historia se repita.

&nbsp;

# 10.**Sonido/Música** 
Dependiendo del momento del juego sonará una música u otra, pero toda está relacionada entre sí.

  ## 10.1. Música
**10.1.1. In-game**

La música ingame se divide en 2, por un lado, está la que suena durante la ronda, la cual será más frenética y movida, mientras que por el otro lado está la música entre ronda y ronda la cual es más calmada.

**10.1.2. Menús**

En los menús se escuchará una música tranquila diferente a la que suena entre ronda y ronda.

  ## 10.2. Sonidos
El juego estará lleno de sonidos para dar retroalimentación al jugador.

**10.2.1. In-game**

Cualquier tipo de disparo, muerte, ataque o interacción irá acompañado de un sonido para que el jugador sepa que está pasando en la partida sin necesidad de verlo.
    
**10.2.2. Menús**

Durante la navegación por los menús habrá sonidos en la interacción con los botones.
    
# 11.**Monetización** 
En ordenador, el juego tendrá 2 versiones:

-	Una demo gratuita con 2 de los 6 niveles con todo lo que incluye aparte del modo infinito limitado por el contenido que ofrece la demo. Es decir, dos mundos con sus correspondientes niveles del modo campaña, torretas, enemigos y héroes. Además, también tendrán acceso al modo ilimitado, pero de forma limitada, es decir con un límite de rondas (que será mayor a las rondas que hay en los niveles del modo campaña)
-	La otra versión sería una versión de pago, que costaría 6.99€, la cual incluye todo el contenido que puede ofrecer el juego, actualmente tiene 6 mundos distintos con sus correspondientes torretas, enemigos y héroes, además de poder tener acceso a héroes o torretas adicionales que no corresponden a ningún mundo. Estos usuarios tendrán acceso al modo ilimitado sin ningún tipo de restricción del número de rondas.
-	Hay dos monedas dentro del juego:

o	monedas normales que se consiguen jugando.

o	Monedas premium que se consiguen poco a poco jugando, mediante un login diario o mediante su compra.

En la versión de móvil, también habrá las mismas versiones, pero con ligeros cambios:

-	Demo: Tendrá anuncios después de x partidas o x tiempo y solo contendrá los dos primeros mundos, al igual que un límite en el modo infinito. 
-	Pago: igual que las versiones de pc, contendría el resto de los mundos y además se eliminarían los anuncios, pero su precio bajaría a 3,99€, un precio más accesible para los usuarios de móvil.

 ## 11.1. Caja de herramientas
La siguiente imagen muestra la caja de herramientas de la empresa TeamSalchichill. TeamSalchichill tiene 6 relaciones clave para poder llevar a cabo su modelo de negocio. 

Para poder llevar a cabo nuestro producto establecemos relaciones con Unity donde ellos nos proporcionan su motor de videojuegos a cambio del precio por su uso, Discord que nos proporciona una herramienta para comunicarnos entre los miembros y VoxelEdit y VoxEdit que nos proporcionan las herramientas necesarias para modelar y animar los diferentes elementos que forman el videojuego.

Finalmente tenemos dos últimas relaciones que nos sirven para vender y promocionar nuestro producto. Una de ellas es mantener relaciones con influencers para que promocionen nuestro videojuego dándonos así viabilidad y exposición a cambio de dinero y nuestro producto. Finalmente, la relación que nos permite vender el videojuego la establecemos con Itch.io le proporcionamos nuestro producto para que ellos lo vendan a los consumidores a cambio de su precio.  Con esta relación obtenemos visibilidad, exposición y dinero a cambio de poco dinero que damos a Itchi.io por alojar nuestro videojuego en su web.

<img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen76.png" alt="JuveR" width="700px">

 ## 11.2. Bussines model canvas
 
 <img src="https://github.com/TeamSalchichill/La-Defensa-de-Trost/blob/main/ImagenesGDD/Imagen77.png" alt="JuveR" width="700px">
 
&nbsp;

# 12.**Propósito, público objetivo y plataformas** 
  ## 12.1. Propósito
El propósito general es el diseño y desarrollo de un videojuego acorde a todo el trabajo realizado anteriormente y que se realizará a posterior para cumplir con unas expectativas marcadas.

  ## 12.2. Público objetivo
El público objetivo del videojuego se trata de jóvenes de entre 12 - 18 años, que quieran divertirse y pasar el tiempo con partidas rápidas y diferentes. Los usuarios que juegan a nuestro juego serán jugadores interesados en los juegos de estrategia, pero no necesariamente amantes de los videojuegos sino usuarios que busquen matar el tiempo con un videojuego dinámico y diferente en cada partida.

  ## 12.3. Plataformas
El videojuego será lanzado inicialmente para Pc, en las plataformas de itch.io y Steam, pero está planeado que también exista una versión compatible para dispositivos móviles, publicada en la Play Store y la Apple Store.

&nbsp;  

# 13.**Hitos**
  ## 13.1. Hito 1 - Versión Alpha
Fecha: 30/10/2022

Contenido: Una versión jugable

  ## 13.2. Hito 2 - Versión Beta
Fecha: 20/11/2022

Contenido: El juego terminado sin pulir

  ## 13.3. Hito 3 - Versión Gold Master
Fecha: 11/12/2022

Contenido: El juego terminado y pulido

  ## 13.4. Hito 4 - Publicación
Fecha: 12/12/2022

Contenido: publicación del videojuego

