El TP anterior, y el del año pasado estuvieron basados en Visual C# 2008 y SQL Server 2008.

Buscando en internet, un pibe hizo una maquina virtual con XP y los dos programas instalados y funcionando, mas el Tortoise SVN.

SVN y Tortoise

SVN sirve para el versionado. Se crea un proyecto en google code, o algun otro servidor de repositorio, y con el Tortoise se hace un checkout del proyecto. Se va a ir updeteando manualmente para tener la ultima version, y si se hacen cambios se hace un comit. Este comit requiere un user y pass de google code, y se saca de la pagina. Link abajo.

Yo voy a ir agregando permisos al repositorio segun los mails que me den, y voy a ir haciendo varios comits con versiones de prueba y con comentarios, y cualquier cosa me preguntan.

https://code.google.com/hosting/settings

Un repositorio que hice de prueba yo y al cual voy a subir cosas hasta que nos den el enunciado:

https://code.google.com/p/pruebaversionado1/source/checkout

Un tutorial de como crear un SVN y manejarlo con el Tortoise (No lo creen, es al dope)

http://uialberto.wordpress.com/2011/05/19/integrar-tortoisesvn-con-repositorio-de-google-code/


Para bajar la VM con las aplicaciones, vamos a

https://mega.co.nz/#F!AF0E0L7C!ZzKyl0Ft0PYajHCkZ1z_0Q

Y lo bajamos de ahi. La VM es la que pesa mas, unos 10 gigas. La otra no tiene nada instaldo, pero si los instaladores.

Para ver SQL:
Hay mil tutoriales, mas lo que da la clase, y lo que hay que aprender por ahora es la basica de las funciones, eso es el SELECT; INSERT; DELETE; UPDATE. El resto se hacen con clicks en el SQL Server por ahora, hasta que lo veamos en clase.

Un tutorial copado:

http://sqlzoo.net/wiki/SELECT_basics

Bastante bueno, interactivo pero en ingles.


Una vez que bajamos la VM:

Instalamos algun programa para levantar el disco virtual, creando una maquina virtual.

Podemos usar el VirtualBox, VirtualPC, VMWare, etc. Yo uso el VirtualBox.

La maquina tiene que tener 512 Gb ram para que ande bien bien, y 10g en disco.

La encendemos, y todo deberia andar, igual que Sistemas Operativos.

NO INSTALAR NINGUN UPDATE, el TP pide que se use el .NET Framework 3.5, y es el que esta instalado

Para empezar,

Visual C#:

Abrir la aplicacion Visual Studio 2008 y seguir estos pasos

http://www.functionx.com/vcsharp/gdi/printing.htm

Es un tutorial basico que dice paso a paso para boludos como hacer un form chico que calcula y guarda en archivos. Esto sirve para entender como maneja los formularios, y tener una idea del visual, no hace falta que completen todo, pero si por lo menos hasta guardar y levantar un archivo.

HAGANLO!


Ahora ya deberian saber un poco de C#, como se maneja el Visual, y como crear un proyecto y una aplicacion.

Vamos a conectar el Visual con SQL 2008.

Abrimos el SQL Server 2008

Creas una Base de datos de prueba,  y sacar el path del archivo, lo copias.

Despues vas a inicio, programas, sql server y hay una aplicacion para configurarlo, ahi tenes que habilitar el TCP.


Para linkear al visual, tenes que sacar el string de conexion, vas a nuevo origen de  datos, base de datos.

pones nueva conexion, y te aparecen varias opciones

Origen de datos es el del medio, archivo de sql server

La base de datos la buscas dentro de tu pc, donde la creaste (por default c:/archivos de programa... el path que copiaste al principio)
user sa, pass gestiondedatos

en avanzadas, camibias de sql express a sql 2008, y pones user instance en false.

Antes de poner aceptar, reinicia el servicio de sql, si no te tira un error raro. despues dale aceptar

Algo asi te deberia quedar:

Data Source=.\SQLSERVER2008;AttachDbFilename="C:\Archivos de programa\Microsoft SQL
Server\MSSQL10\_50.SQLSERVER2008\MSSQL\DATA\basePrueba.mdf";Persist Security Info=True;User ID=sa;Password=gestiondedatos;Connect Timeout=30;User Instance=False

Este es el string que va a usar la clase de conexion. Hay varios tutoriales andando por ahi, especialmente en youtube.

No estoy 100% seguro de que la conexion se haga asi, porque teoricamente me conecto a un server en red, y en el string le estoy pasando el path de un archivo.

Lo vemos despues.


# Details #

Add your content here.  Format your content with:
  * Text in **bold** or _italic_
  * Headings, paragraphs, and lists
  * Automatic links to other wiki pages