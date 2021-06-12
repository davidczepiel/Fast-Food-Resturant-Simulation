# IAVFinal-Czepiel
# Curso 2020 / 2021 - Universidad Complutense de Madrid
# Facultad de Informática - Videojuegos

Proyecto final de la asignatura de Inteligencia Articicial para Videojuegos 

Autor:David Czepiel


# Trabajo Final
<a href="https://drive.google.com/file/d/1ILV0cGxd4ZwSc96NijXEZe5AN-QSOZHc/view" target="_blank">Video Demo 1</a>

<a href="https://drive.google.com/file/d/1zzbcrSOFX1oWClB_fgw5CMvfTMb1YiYa/view" target="_blank">Video Demo 2</a>

Restaurante:
![Restaurante](./Resources/Mapa.jpg?raw=true)

# Introducción
-----------------------------

El proyecto trata de un prototipo de un simulador de un restaurante de comida rápida. Este prototipo está implementado en Unity 
haciendo uso de la herramienta de Behavior Designer. La cual es utilizada para desarrollar el comportamiento de los diversos agentes de la escena.
En este proyecto vamos a encontrar tres tipos de agentes. Los clientes, los cuales vendrán al local a realizar una visita ordinaria, en la que pedirán su
orden, la comerán, recogerán, opcionalmente irán al servicio y por último se irán del local.
Luego tenemos a los cajeros, los cuales serán los encargados de atender a los clientes y de realizar pedidos sencillos, como las bebidas o los helados.
Aparte, estos serán los encargados de reparar los váteres los cuales acabarán atascandose y de vaciar las papeleras las cuales también tienen 
usos limitados.
Por último encontramos a los cocineros, los cuales serán los encargados de realizar los pedidos más elaborados que los clientes pidan, como las hamburguesas
o las patatas fritas.
Por último, en este proyecto se va a ofrecer una interfaz donde se mostrarán los controles para navegar por la escena y una serie de botones que sirven 
para añadir más agentes a la escena y poder personalizar los menús de aquellos clientes que vayamos añadiendo.


# EXPLICACIÓN DE LOS COMPORTAMIENTOS INTELIGENTES
Clientes
---------------------

Cliente:
![Cliente](./Resources/Cliente.JPG?raw=true)

Estos agentes presentan el siguiente arbol de comportamiento:

ArbolCliente:
![ArbolCliente](./Resources/ArbolCliente.JPG?raw=true)

La ejecución de este árbol provoca que los clientes realicen los siguientes pasos:
- El cliente entra al local y lo primero que hace es ponerse en la cola del mostrador, en caso de que no haya nadie y le toque esperará en el mostrador hasta ser atendido
- Una vez ha sido atendido se hará a un lado a esperar a que su pedido esté listo
- Una vez su pedido esté listo, se lo llevará y se irá al comedor a sentarse en una silla y comerse su pedido. En caso de que no haya ningún hueco hará cola a la entrada del comedor hasta que se libere algún asiento.
- Una vez haya terminado de comer su menú, se irá a la zona de las papeleras a tirar sus restos, en caso de que no haya ninguna papelera libre o que estén todas llenas hará cola frente a estas hasta que alguna papelera se quede libre o sea vaciada por los cajeros
- En caso de que en su pedido hubiera incluido bebida, se irá al servicio, igual que en las papeleras hará cola mientras no haya servicio libre o estén todos atascados
- Por último saldrá del local y su comportamiento habrá terminado

Cajeros
---------------------------------

Cajero:
![Cajero](./Resources/Cajero.JPG?raw=true)

Estos agentes presentan el siguiente arbol de comportamiento:

ArbolCajero:
![ArbolCajero](./Resources/ArbolCajero.JPG?raw=true)


La ejecución de este árbol provoca que los clientes realicen los siguientes pasos:

- Si no tienen ningún cliente al que atender y no hay ningún pedido que hacer ni ninguno en el que puedan ayudar a completar, ni tenga nada que reparar, se irán a la despensa a descansar
- Cuando venga algún cliente y se ponga en el mostrador el cajero vendrá a atenderle para tomar su orden
- Cuando los cocineros hayan terminado de hacer los elementos del menú solicitado que necestietn ser elaborados en la cocina el cajero tomará el pedido para completarlo con bebidas y/o helado en caso de que el pedido lo requiera
- Cuando haya algún pedido que haya sido completado el cajero irá a por el y se lo dará al cliente que lo haya solicitado
- En caso de que no tenga ningún cliente al que atender y haya algún elemento que arreglar, como una papelera o un váter, irá hacia este a repararlo

Esta clase de agente priorizará las tareas que puede realizar y lo hará con el siguiente orden de prioridad
- Completar y entregar menús que hayan sido completados.
- Atender nuevos clientes que se encuentren en el mostrados y no hayan sido atendidos.
- Vaciar aquellas papeleras que se hayan llenado
- Reparar aquellos váteres que hayan sido atascados
- Irse a la despensa a descansar


Cocineros
---------------------------------

Cocinero:
![Cocinero](./Resources/Cocinero.JPG?raw=true)

Estos agentes presentan el siguiente arbol de comportamiento:

ArbolCocinero:
![ArbolCocinero](./Resources/ArbolCocinero.JPG?raw=true)

La ejecución de este árbol provoca que los clientes realicen los siguientes pasos:

- Si no tiene ningún pedido con elementos que necesiten ser elaborados en la cocina ni puede ayudar a completar algún otro pedido, se irá a la despensa a descansar
- Cuando entre en la cocina algún pedido nuevo irá a por él para ver si tiene algún elemento que solo se pueda hacer en la cocina, si no lo tiene lo deja en las mesas para que los cajeros lo completen. En caso de que si tenga algo que necesita cocinarse en la cocina, tomará nota y se pondrá a prepararlo
- En caso de que no haya ningún menu nuevo que entre en la cocina mirará si hay alguno que ya se esté haciendo en esta y si puede ayudar a hacer algo de este lo anotará y se pondrá a cocinar
- Cada vez que termine de cocinar algo se irá a la mesa donde se encuentra el menú y añadirá dicho elemento, en caso de que dicho menú no necesite de más elementos que se cocinen en la cocina avisará a los cajeros para que lo completen o lo entreguen

Esta clase de agente priorizará las tareas que puede realizar y lo hará con el siguiente orden de prioridad
- Ir a ver posibles menús nuevos para ver si necesitan que algo se prepare en la cocina o ni siquiera necesitan pasar por esta
- Empezar a cocinar alguno de los menús nuevos que hayan entrado a la cocina
- Ayudar en algún pedido que ya se esté preparando dentro de la cocina
- Irse a la despensa a descansar

ASSETS Y REFERENCIAS
================================
* [Assets perro](https://assetstore.unity.com/packages/3d/characters/animals/5-animated-voxel-animals-145754)
* [Assets ratas](https://assetstore.unity.com/packages/3d/characters/creatures/meshtint-free-burrow-cute-series-184837)
* AI for Games 3rd Edition (2019) - Ian Millington
	
La solucion ha sido basada en el codigo proporcionado por Federico Peinado referente a comportamientos de movimiento
combinados mendiante pesos.





