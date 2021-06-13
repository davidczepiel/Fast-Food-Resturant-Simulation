# IAVFinal-Czepiel
# Curso 2020 / 2021 - Universidad Complutense de Madrid
# Facultad de Informática - Videojuegos

Proyecto final de la asignatura de Inteligencia Articicial para Videojuegos 

Autor: David Czepiel


# Trabajo Final
<a href="https://drive.google.com/file/d/1flir1s0gZp28OH_fsL3MxWGsSqCp5Uwx/view?usp=sharing" target="_blank">Build del proyecto</a>

<a href="https://drive.google.com/file/d/1zzbcrSOFX1oWClB_fgw5CMvfTMb1YiYa/view" target="_blank">Video Presentación</a>

![Restaurante](./Resources/Mapa.jpg?raw=true)

# Introducción
-----------------------------

El proyecto trata de un prototipo que pretende simulador un restaurante de comida rápida. Este prototipo está implementado en Unity 
haciendo uso de la herramienta de Behavior Designer. La cual es utilizada para desarrollar el comportamiento de los diversos agentes de la escena.
En este proyecto vamos a encontrar tres tipos de agentes. Los clientes, los cuales vendrán al local a realizar una visita ordinaria, en la que pedirán su
orden, la comerán, recogerán, opcionalmente irán al servicio y por último se irán del local.
Luego tenemos a los cajeros, los cuales serán los encargados de atender a los clientes y de realizar pedidos sencillos, como las bebidas o los helados. Aquellos 
pedidos que reciban de los clientes se dejarán en una serie de mesas donde se pueden ver todos los pedidos en los que se están trabajando y cómo se van incluyendo los 
diferentes items en estos.
Aparte, estos serán los encargados de reparar los váteres los cuales acabarán atascandose tras determinados usos y de vaciar las papeleras las cuales   
se llenarán tras determinados usos y dejarán de ser utilizables.
Por último encontramos a los cocineros, los cuales serán los encargados de realizar los pedidos más elaborados que los clientes pidan, como las hamburguesas
o las patatas fritas.

Es posible ver este proyecto en ejecución en el siguiente [vídeo](https://drive.google.com/file/d/1t60b6t9Tly3rDMyMseNAqdmOyPgfNV2R/view?usp=sharing)


# EXPLICACIÓN DE LOS AGENTES INTELIGENTES
Clientes
---------------------

![Cliente](./Resources/Cliente.JPG?raw=true)

Estos agentes presentan el siguiente árbol de comportamiento:

![ArbolCliente](./Resources/ArbolCliente.JPG?raw=true)

La ejecución de este árbol provoca que los clientes realicen los siguientes pasos:

- El cliente entra al local y lo primero que hace es ponerse en la cola del mostrador, en caso de que no haya nadie esperará en el mostrador hasta ser atendido
- Una vez ha sido atendido se hará a un lado a esperar a que su pedido esté listo
- Una vez su pedido esté listo, se lo llevará y se irá al comedor a sentarse en una silla y comerse su pedido. En caso de que no haya ningún hueco hará cola a la entrada del comedor hasta que se libere algún asiento.
- Una vez haya terminado de comer su menú, se irá a la zona de las papeleras a tirar sus restos, en caso de que no haya ninguna papelera libre o que estén todas llenas hará cola frente a estas hasta que alguna papelera se quede libre o sea vaciada por los cajeros
- En caso de que en su pedido hubiera incluido bebida, se irá al servicio, igual que en las papeleras hará cola mientras no haya servicio libre o estén todos atascados
- Por último saldrá del local y su comportamiento habrá terminado

Se puede observar el ciclo de ejecución completo de un cliente en el siguiente [video](https://drive.google.com/file/d/1FqBi00TZsP_2sUTdR4leUXKIftHZa0ie/view?usp=sharing)
En este [video](https://drive.google.com/file/d/17LH1zlIXlTrJxSFQ-CFZ3elDmiHjEMCr/view?usp=sharing) podemos observar cómo los clientes hacen cola para realizar sus pedidos.
Y en este [video](https://drive.google.com/file/d/1EhDpYpI4LNsqusduK9-v2XuSBouqtRwI/view?usp=sharing) podemos observar cómo los clientes forman colas en las papeleras y en los baños

Cajeros
---------------------------------

![Cajero](./Resources/Cajero.JPG?raw=true)

Estos agentes presentan el siguiente árbol de comportamiento:

![ArbolCajero](./Resources/ArbolCajero.JPG?raw=true)


La ejecución de este árbol provoca que los cajeros realicen los siguientes pasos:

- Cuando venga algún cliente y se ponga en el mostrador el cajero vendrá a atenderle para tomar su orden
- Cuando los cocineros hayan terminado de hacer los elementos del menú solicitado que necestiten ser elaborados en la cocina el cajero tomará el pedido para completarlo con bebidas y/o helado en caso de que el pedido lo requiera
- Cuando haya algún pedido que haya sido completado, el cajero irá a por él y se lo dará al cliente que lo haya solicitado
- En caso de que no tenga ningún cliente al que atender y haya algún elemento que arreglar, como una papelera o un váter, irá hacia este a repararlo
- Si no ocurre nada de lo anterior, ni hay clientes ni pedidos ni nadad que reparar, se irá a la despensa a descansar


Esta clase de agente priorizará las tareas que puede realizar y lo hará con el siguiente orden de prioridad
- Completar menús y entregar aquellos que hayan sido completados.
- Atender nuevos clientes que se encuentren en el mostrados y no hayan sido atendidos todavía.
- Vaciar aquellas papeleras que se hayan llenado
- Reparar aquellos váteres que hayan sido atascados
- Irse a la despensa a descansar

Se puede observar el ciclo de ejecución de un cajero en el siguiente [video](https://drive.google.com/file/d/1FdsQPcoiiWfAKZvplZDoHKG2f-4jM0bJ/view?usp=sharing)
En este [video](https://drive.google.com/file/d/1gqgiUKZFCJT62RnO5ciTV3BR8jDuw5B9/view?usp=sharing) podemos observar cómo los cajeros vacían las papeleras.
Y en este [video](https://drive.google.com/file/d/1mNLxwnKjuZ2PuQEbYva-GraqcUA_ZEHc/view?usp=sharing) podemos observar cómo los cajeros reparan los váteres.


Cocineros
---------------------------------

![Cocinero](./Resources/Cocinero.JPG?raw=true)

Estos agentes presentan el siguiente árbol de comportamiento:

![ArbolCocinero](./Resources/ArbolCocinero.JPG?raw=true)

La ejecución de este árbol provoca que los cocineros realicen los siguientes pasos:

- Cuando entre en la cocina algún pedido nuevo, irá a por él para ver si tiene algún elemento que solo se pueda hacer en la cocina, si no lo tiene lo deja en las mesas para que los cajeros lo completen. En caso de que sí tenga algo que necesita cocinarse en la cocina, tomará nota y se pondrá a prepararlo
- En caso de que no haya ningún menu nuevo que entre en la cocina mirará si hay alguno que ya se esté haciendo en esta, y si tiene elementos en los que pueda ayudar lo anotará y se pondrá a cocinar
- Cada vez que termine de cocinar algo se irá a la mesa donde se encuentra el menú y añadirá dicho elemento, en caso de que dicho menú no necesite de más elementos que se cocinen en la cocina avisará a los cajeros para que lo completen o lo entreguen
- Si no tiene ningún pedido que empezar, ni ninguno en el que ayuda, se irá a la despensa a descansar


Esta clase de agente priorizará las tareas que puede realizar y lo hará con el siguiente orden de prioridad
- Ir a ver posibles menús nuevos para ver si necesitan que algo se prepare en la cocina o ni siquiera necesitan pasar por esta
- Empezar a cocinar alguno de los menús nuevos que hayan entrado a la cocina
- Ayudar en algún pedido que ya se esté preparando dentro de la cocina
- Irse a la despensa a descansar

Se puede observar el ciclo de ejecución de un cocinero en el siguiente [video](https://drive.google.com/file/d/1Xym8_v2Tv4gjr24OqV_l2quVvIEONnx5/view?usp=sharing)

# CONTROLES

La interfaz que se le va a ofrecer al jugador va a ser la que se muestra en la siguiente imágen

![Interfaz](./Resources/Interfaz.JPG?raw=true)

En ella se muestra en la parte superior derecha una imagen con una serie de teclas, estas representan los controles utilizados para controlar la cámara.
La cual se puede mover haciendo uso de las teclas WASD, y además, podemos controlar su altura con las teclas Q y E, para poder ver con más o menos detalle a los agentes.

Por otro lado encontramos el resto de elementos de la interfaz, los cuales son todos botones, aquellos que se encuentran en la parte inferior están relacionados con los clientes, los cuatro que representan items del menú, sirven para configurar el menú de los nuevos clientes que vayamos a instanciar, para completar
estos botones, tenemos el botón de la derecha del todo "Mandar" el cual nos sirve para crear un nuevo cliente que vaya a pedir un menú que conste de los items que se muestren
en dicho botón. Por ejemplo, en la imagen mostrada, pulsar dicho botón provocaría la aparición de un cliente cuyo menú constara de todos los elementos posibles del local.
Dichos clientes aparecerán en la calle.

Por otro lado, encontramos en la parte superior izquierda dos botones más, los cuales sirven para hacer spawn de trabajadores, tenemos uno destinado a los cocineros 
y otro a los cajeros. Dichos nuevos trabajadores aparecerán en la cocina.


# FEEDCAK VISUAL

En este proyecto se ofrecen tres tipos de feedback visual, el primero es el que se muestra en la siguiente imágen.

![FeedBackUsosRestantes](./Resources/Usosrestantes.JPG?raw=true)

El cual representa los usos que les quedan a determinados elementos del escenario para que se gasten y tenga que venir un cajero a repararlos.
El siguiente tipo de feedback visual que se ofrece lo podemos observar en las siguientes imágenes.

![ClienteIntencion](./Resources/ClientesSimulandoPedidaDeOrdenes.JPG?raw=true)
![CajeroIntencion](./Resources/CajerosEscogiendoItemCompletar.JPG?raw=true)
![CocineroIntencion](./Resources/CocinerosEscogiendoPedidoQueHacer.JPG?raw=true)

Como podemos ver, este feedback visual consiste en una serie de imágenes que se muestran encima de los agentes con el objetivo de indicar su objetivo actual.
Por ejemplo, en la imágen de los cocineros podemos distinguir un cocinero cocinando hamburguesa y otro patatas.
O en la imágen de los clientes podemos distinguir aquellos clientes que están esperando de aquellos que están pidiendo y de aquel que se lleva su pedido

El último tipo de feedback visual que se ofrece el de los elementos de los pedidos añadiendose a estos mientras los trabajadores los van haciendo. 
Esto lo podemos observar en la siguiente imágen.

![ImagenPedidos](./Resources/PedidosFormandose.JPG?raw=true)

Estos mismos elementos van desapareciendo a medida que van siendo comidos, lo cual podemos observar en el siguiente [video](https://drive.google.com/file/d/1VE0UO2E7Op9auYlh5btnFyfTZD427NyQ/view?usp=sharing)


# LOS MENÚS

![ImagenMenu](./Resources/Menu.JPG?raw=true)

Los menús que se tratan en este proyecto constan como máximo, de cuatro elementos diferentes: hamburguesas,patatas,bebida y helado.
Estos menús son solicitados por los clientes, los cuales ya tienen configurado lo que van a solicitar desde que son instanciados.
Una vez que el cliente es atendido el menú es situado en las mesas de la cocina, donde se van acumulando los son solicitados y donde 
se pueden ve cómo sus elementos se van añadiendo.
El ciclo de ejecución de un menú dentro de la cocina sigue el siguiente curso:

- Primero el menú entra en la cocina cuando el cliente es atendido
- Un cocinero viene a ver el menú, si no tiene nada que se haga en la cocina, avisa de ello y se lo da a los cajeros para que lo completen
- Cuando un menú no necesita más elementos de la cocina pasa a ser controlado por los cajeros, los cuales irán añadiendo elementos hasta que esté completo
- Cuando el menú esté completo un cajero lo tomará y se lo dará al cliente que lo solicitó

La coperación de los trabajadores para hacer los menús se divide en, los cocineros y los cajeros. El funcionamiento de esto se basa en que el menú tiene una serie de elementos
que hay que hacer, cada trabajador analizará el menú, y verá si le falta algún elemento, nadie lo está haciendo, y dicho trabajador es capaz de hacerlo, en cuyo caso
lo apunta, para que ningún otro trabajador se ponga con ello y se pone a preparar dicho elemento.

La parte de los menús que puede ser realizada por los cajeros (bebidas y helados) no puede empezar a hacerse hasta que todos los elementos del menú que tengan
que ser preparados en la cocina estén ya listos en dicho menú. Esto supone que para que los cajeros se ponga a completar un menú con bebidas y helados, dicho menú tiene 
que haber recibido el visto bueno de un cocinero indicando que dicho menú ya no necesitara nada de la cocina.


ASSETS Y REFERENCIAS
================================
* [Assets restaurante](https://assetstore.unity.com/packages/3d/props/interior/restaurant-interior-full-pack-153273)
* AI for Games 3rd Edition (2019) - Ian Millington
	





