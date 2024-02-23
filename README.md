Dejo las siguientes anotaciones con el fin de dar un contexto y no con buscar una excusa...

La aplicación no cumple con ciertos requisitos **(por lo cual desde ya pido disculpas)** como integrar Apache Kafka o Dockerizar la aplicación.

La realidad es que tuve solo dos días para hacer el challenge, de los cuales solo pude trabajar de noche debido a mis ocupaciones. 

Tenía una gran curva de aprendizaje por delante ya que nunca había utilizado **Docker** por la mala costumbre de siempre tener un DevOps en mi equipo. Por otro lado tampoco había utilizado **Apache Kafka**, ya que trabajé distintas arquitecturas pero no asi una de Microservicios. No obstante soy un apasionado por la tecnología por lo cual le intente durante horas buscar la solución a los incontables problemas que surgían, por eso luego llegué a tener el container corriendo, junto con los servicios de Elasticsearch y Kibana levantados desde el docker-compose.
El problema más grande fue cuando quise añadir los servicios de Apache Kafka y Zookeeper al container. Comenzaron problemas de compatibilidad y errores del sistema operativo, al borde de colapsarme el disco sólido y recibir un pantallazo azul, luego de esto el disco sólido estaba con 0 bytes disponibles (siendo este disco donde se encuentra el SO) ya que el proceso del WSL (Windows Subsystem for Linux) estaba colapsando todo el sistema. **Ahora entiendo porque dicen que hay que usar Docker en Linux y no en Windows**.

No quiero seguirme extendiendo mucho más en los problemas sucedidos, ya que como dije al comienzo, no busco excusas.

En cuanto a la parte de **Testing** apreciaría algunas observaciones ya que es mi primera vez realizando unit testing. Busque las mejores prácticas utilizando Moq, FluentAssertions y xunit. Debido al poco tiempo solo realicé algunas pruebas de uno de los servicios.

Aprender a integrar y utilizar **Elasticsearch y Kibana** también fue un gran y prospero desafío, ya que no conocía en absoluto dichas herramientas y me parecieron muy buenas.

En cuanto a la arquitectura utilizada arme una adaptación de Clean Architecture de Jason Taylor, digo adaptación ya que esta arquitectura es acompañada por el principio de **DDD** debido a que está pensada para aplicaciones robustas y en este caso no era necesario.

Desde ya muchas gracias, estoy abierto a cualquier tipo de observación, ha sido un gran desafio!
