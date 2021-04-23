# GetaGamesTest
 
Este código es basado en el paquete dentro del repositorio : https://github.com/JuanDevGeta/GetaGamesDevTest.




La prueba cuenta con 3 escenas : Menú, Game y GameOver.


En menú se encuentra un botón para jugar y un texto de bienvenida.


Scripts
CmraControler : Es el encargado de hacer que la cámara siga al kart con rotación y posición. 
Data: Estructura de datos que se usa para almacenar las estadísticas en el json
Endtext : Script que dice si ganaste o perdiste una partida 
GameManager: Singelton donde se guarda el numero de carreras completadas por corrida 
Kartmanager: Script encargado del movimiento y funcionalidad del kart durante el juego 
LoadManager: Script que carga la siguiente escena de manera asíncrona 
Save: Script donde guarda y carga los datos del juego en un json
Timer Script encargado del temporizador


Timer
El juego originalmente tiene un timer de 60 segundos por sección 
Este ultimo se modifica en el script de timer 


Movimiento 
W adelante
S Atrás
A izquierda
D derecha 


Power Up
Cubos morados Agregan 10 segundo al reloj
Plano amarillo duplica la aceleración por un corto tiempo
Plano azul Salto




Obstaculos 
Plano negro derrape


Font :https://www.dafont.com/es/mario-kart-ds.font


Particulas: https://www.kenney.nl/assets/particle-pack
