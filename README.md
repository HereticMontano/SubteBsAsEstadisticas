# Subte Bs As Estadisticas

## Problema
No tener datos de acceso publico, sobre el tiempo de funcionamiento (normal, suspendido, demorado, etc) 
de las lineas de subte de la ciudad de Buenos Aires. 

## Solución 
La solucion consta de dos grandes partes.
### Consola
Una aplicación de consola que cada 5 minutos se ejecuta, llama a una WebApi que le retorna los estados de las lineas en un json, 
procesa esos datos y los guarda en una base. 

### Web
Una aplicación web con la que se va a permitir al usuario consumir esas estadísticas en formas de distintos tipos de gráficos. 
También contiene la WebApi que hace uso la consola para obtener los estados, para obtener los estado se hace scraping de la pagina de Metrovias.com.ar.

