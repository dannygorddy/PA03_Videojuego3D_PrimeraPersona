# La Búsqueda - Proyecto Final

Curso: Desarrollo de Videojuegos
Grupo: D

## Integrantes

1. Danny Gorddy Huaman Chavez
2. Susan Katherine Torres Calderon
3. Francisco James Leon Trujillo

## Descripción

La Búsqueda es un videojuego 3D en primera persona desarrollado en Unity. El jugador debe explorar dos niveles, Bosque y Desierto, encontrar 5 reliquias en cada uno y evitar ser capturado por un guardián con inteligencia artificial.

El guardián utiliza NavMesh para patrullar mediante Waypoints y perseguir al jugador cuando entra en su rango de detección. Si el jugador logra alejarse, el enemigo vuelve a su patrulla.

El juego cuenta con menú principal, opciones de audio y sensibilidad, sistema de pausa, Game Over, música, efectos de sonido, partículas, pantalla de objetivos y una escena final de victoria.

## Flujo del juego

MainMenu → Bosque → Desierto → WinScene

## Mecánicas principales

- Exploración en primera persona
- Recolección de reliquias
- Contador de objetos
- IA de patrulla y persecución
- Sistema de Game Over
- Pausa y opciones
- Música y efectos de sonido
- Efectos visuales
- Dos niveles jugables

## Optimización

Se redujo el uso de sombras en algunos elementos decorativos y montañas para disminuir cálculos innecesarios de renderizado.

## Estado del proyecto

Proyecto finalizado y probado mediante Build para Windows.