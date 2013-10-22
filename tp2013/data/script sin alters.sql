CREATE TABLE Afiliados ( 
	nroAfiliado numeric(18) NOT NULL,
	planMedico numeric(18),
	activoAfiliado char(10),
	estadoCivil nchar(10),
	cantHijos int,
	userId numeric(18),
	tipoAfiliado int,       --------<----------SOLUCION AL 01,02,03     
)
;

CREATE TABLE Agendas ( 
	medico numeric(18),
	dia date,
	horaIngreso time(7),
	horaEgreso time(7)
)
;

CREATE TABLE Bonos ( 
	numeroBono numeric(18)  NOT NULL,
	fechaImp datetime,
	afiliadoCompro nvarchar(255),
	tipoBono nchar(10),
	planMedico numeric(18)
)
;

CREATE TABLE Cambios_Afiliado ( 
	afiliado numeric(18),
	fecha date,
	motivo char(10)
)
;

CREATE TABLE Consulta ( 
	turno numeric(18),
	bono numeric(18),
	sintomas varchar(255),
	enfermedad varchar(255)
)
;

CREATE TABLE Detalles_Persona ( 
	dni numeric(18),
	tipo varchar(255),
	telefono numeric(18),
	direccion varchar(255),
	sexo char(10),
	mail varchar(255),
	apellido varchar(255),
	nombre varchar(255),
	userId numeric(18) NOT NULL,
	fechaNac date
)
;

CREATE TABLE Dias_Laborales ( 
	fecha date NOT NULL
)
;

CREATE TABLE Especialidades ( 
	codigoEspecialidad numeric(18) NOT NULL,
	descripcionEsp varchar(255),
	tipoEsp numeric(18)
)
;

CREATE TABLE Estados_turno ( 
	idEstado numeric(18) NOT NULL,
	descTurno nchar(10),
	motivoCancel nchar(10)
)
;

CREATE TABLE Funcionalidades ( 
	idFunc numeric(10) IDENTITY (1,1) NOT NULL,
	descripcion nchar(255)
)
;

CREATE TABLE Medicamentos ( 
	idMedic numeric(18) identity (1000,1),
	descrip nchar(255)
)
;

CREATE TABLE Medicos ( 
	matricula numeric(18),
	userId numeric(18) NOT NULL,
	activoMedico char(10)
)
;

CREATE TABLE Medicos_Esp ( 
	medico numeric(18),
	especialidad numeric(18)
)
;

CREATE TABLE Perfil ( 
	idPerfil numeric(10) identity(1,1) NOT NULL,
	detallesPerf nchar(255)
)
;

CREATE TABLE Perfil_Func ( 
	perfil numeric(10,2),
	funcion numeric(10,2)
)
;

CREATE TABLE Planes_Medicos ( 
	codigo numeric(18) NOT NULL,
	descripcionPM varchar(255),
	precioConsulta numeric(18),
	precioFarmacia numeric(18)
)
;

CREATE TABLE Receta ( 
	bonoConsulta nchar(10),
	bonoFarmacia nchar(10)
)
;

CREATE TABLE Recetas_Medicamen ( 
	receta nchar(10),
	medicamento numeric(18)
)
;

CREATE TABLE Roles ( 
	idRol numeric(10)  NOT NULL,
	descripRol nchar(10),
	activoRol bit,
	perfil numeric(10,2)
)
;

CREATE TABLE Roles_Func ( 
	rol numeric(10,2),
	funcionalidad numeric(10,2) NOT NULL
)
;

CREATE TABLE Tipo_Doc ( 
	idTipo varchar(255) NOT NULL,
	descripcion varchar(255)
)
;

CREATE TABLE Tipos_Especialidad ( 
	codigoEsp numeric(18) NOT NULL,
	descripcionEsp varchar(255)
)
;

CREATE TABLE Turnos ( 
	numero numeric(18) NOT NULL,
	medico numeric(18),
	afiliado numeric(18),
	fechaHora datetime,
	estado numeric(18) identity (1,1) ,
	fechaHoraLlegada datetime
)
;

CREATE TABLE Usuarios ( 
	idUser numeric(18) identity(1000,1)  NOT NULL,
	username numeric(10,2),
	password nvarchar(255) NOT NULL,
	intentos int,
	activo bit
)
;

CREATE TABLE Usuarios_Roles ( 
	usuario numeric(18) NOT NULL,
	rol numeric(10) identity (100,1)NOT NULL
)
;






-------MIGRACIONES------------------------------------------------------
PRINT 'INICIO DE MIGRACION DE DATOS'


INSERT INTO Funcionalidades (Descripcion) VALUES ('DarDeAltaPaciente');
INSERT INTO Funcionalidades (Descripcion) VALUES ('ModificarDatos');
INSERT INTO Funcionalidades (Descripcion) VALUES ('EliminarUsuarios');
INSERT INTO Funcionalidades (Descripcion) VALUES ('Recetar');
INSERT INTO Funcionalidades (Descripcion) VALUES ('habilitarRol');
INSERT INTO Funcionalidades (Descripcion) VALUES ('inhabilitarRol');
INSERT INTO Funcionalidades (Descripcion) VALUES ('venderBonosFarmacia');
INSERT INTO Funcionalidades (Descripcion) VALUES ('comprarBonosFarmacia');
INSERT INTO Funcionalidades (Descripcion) VALUES ('venderBonosConsulta');
INSERT INTO Funcionalidades (Descripcion) VALUES ('comprarBonosConsulta');
INSERT INTO Funcionalidades (Descripcion) VALUES ('RegistrarUsuarios');
INSERT INTO Funcionalidades (Descripcion) VALUES ('CancelarTurno');
INSERT INTO Funcionalidades (Descripcion) VALUES ('RegistrarTurno');
INSERT INTO Funcionalidades (Descripcion) VALUES ('SolicitarTurno');

INSERT INTO Perfil (detallesPerf) VALUES ('Afiliado'); ---- correspode al 1 de perfil
INSERT INTO Perfil (detallesPerf) VALUES ('Medico'); ---corresponde al 2 de perfil

INSERT INTO Perfil (detallesPerf) VALUES ('Administrativo')

INSERT INTO Perfil (detallesPerf) VALUES ('administrador')







--- ESTE ES DIRECTO YA QUE ES RELACION DE 3A15
INSERT INTO Perfil_Func (perfil , funcion)
values (1 ,4)
INSERT INTO Perfil_Func (perfil , funcion)
values (1 ,8)
INSERT INTO Perfil_Func (perfil , funcion)
values (1 ,10)
INSERT INTO Perfil_Func (perfil , funcion)
values (1 ,12)
INSERT INTO Perfil_Func (perfil , funcion)
values (1 ,14)

INSERT INTO Perfil_Func (perfil , funcion)
values (2,1)
INSERT INTO Perfil_Func (perfil , funcion)
values (2,12)

INSERT INTO Perfil_Func (perfil , funcion)
values (3,2)
INSERT INTO Perfil_Func (perfil , funcion)
values (3,3)
INSERT INTO Perfil_Func (perfil , funcion)
values (3,5)
INSERT INTO Perfil_Func (perfil , funcion)
values (3,6)
INSERT INTO Perfil_Func (perfil , funcion)
values (3,7)
INSERT INTO Perfil_Func (perfil , funcion)
values (3,9)
INSERT INTO Perfil_Func (perfil , funcion)
values (3,11)
INSERT INTO Perfil_Func (perfil , funcion)
values (3,13)

---SI VA EL DIOS DESPUES LO AGREGO











-- Ingresando los clientes.
PRINT 'Ingresando los Afiliados...'
GO



INSERT INTO Usuarios (activo,Intentos,username,Password)
SELECT DISTINCT 1,0,LTRIM(RTRIM(CAST(Paciente_Dni AS NVARCHAR(255)))),'bed9ae713b440eed894573977256ed12a992b93804975fa09aff32dd1572b658' 
FROM gd_esquema.Maestra 
where Paciente_Dni is not null

INSERT INTO Detalles_Persona(dni,tipo,telefono,direccion,sexo,mail,apellido,nombre,userId,fechaNac) 
SELECT distinct m.Paciente_Dni,NULL,m.Paciente_Telefono,m.Paciente_Direccion,NULL, m.Paciente_Mail,m.Paciente_Apellido,m.Paciente_Nombre, u.idUser, m.Paciente_Fecha_Nac 
FROM gd_esquema.Maestra m INNER JOIN Usuarios u ON CAST(m.Paciente_Dni AS NVARCHAR(255))=u.username 


INSERT INTO Afiliados(nroAfiliado,planMedico,activoAfiliado, estadoCivil,cantHijos,userId)
SELECT DISTINCT (ABS(CAST(NEWID() as binary(6)) % 100000) + 1700)*100, m.Plan_Med_Codigo,1, NULL,NULL, u.idUser  FROM Usuarios u  -----faltaria aignarle el 01 02 03
INNER JOIN gd_esquema.Maestra m ON u.username = CAST(m.Paciente_Dni AS NVARCHAR(255))
GO


--Ingresando los Medicos
PRINT 'Ingresando los Medicos...'
GO


INSERT INTO Usuarios (activo,intentos,username,password)
SELECT DISTINCT 1,0, LTRIM(RTRIM(CAST(Medico_Dni AS NVARCHAR(255)))),'bed9ae713b440eed894573977256ed12a992b93804975fa09aff32dd1572b658' 
FROM gd_esquema.Maestra  
Where Medico_Dni is not null

INSERT INTO Detalles_Persona(dni,tipo,telefono,direccion,sexo,mail,apellido,nombre,userid,fechaNac) 
SELECT distinct m.Medico_Dni,NULL,m.Medico_Telefono,m.Medico_Direccion,NULL,m.Medico_Mail,m.Medico_Apellido,m.Medico_Nombre, u.idUser,m.Medico_Fecha_Nac FROM gd_esquema.Maestra m 
 INNER JOIN Usuarios u ON CAST(m.Medico_Dni AS NVARCHAR(255))=u.username 



INSERT INTO Medicos (matricula, userId , activoMedico)
SELECT DISTINCT (ABS(CAST(NEWID() as binary(6)) % 100000) + 1700), u.idUser, 1 
FROM gd_esquema.Maestra m
INNER JOIN Usuarios u ON u.username= CAST(m.Medico_Dni AS NVARCHAR(255))


----ingresando Agendas




---Dias_Laborales
PRINT'ingresando agenda'
GO
INSERT into Dias_Laborales(fecha)
select distinct CONVERT(CHAR(10), m.Turno_Fecha,112)
from gd_esquema.Maestra m 
where m.Turno_Fecha is not null



--Ingresando los bonos ---ver
PRINT 'Ingresando los Bonos '
GO
INSERT INTO Bonos(numeroBono,fechaImp,afiliadoCompro,tipoBono,planMedico)
SELECT distinct m.Bono_Consulta_Numero , m.Bono_Consulta_Fecha_Impresion,a.idUser ,'consulta', m.Plan_Med_Codigo  
  FROM gd_esquema.Maestra m
  inner join Usuarios a on CAST(m.Paciente_Dni AS NVARCHAR(255))= a.username
  WHERE m.Turno_Fecha is NULL AND m.Bono_Consulta_Numero is not null  
GO

INSERT INTO Bonos(numeroBono,fechaImp,afiliadoCompro,tipoBono,planMedico)
SELECT distinct m.Bono_Farmacia_Numero , m.Bono_Farmacia_Fecha_Impresion, a.idUser,'farmacia', m.Plan_Med_Codigo  
  FROM gd_esquema.Maestra m
  inner join Usuarios a on CAST(m.Paciente_Dni AS NVARCHAR(255))= a.username
  WHERE m.Turno_Fecha is NULL AND m.Bono_Farmacia_Numero is not null   
GO

---hasta aca 56 segundos


--Ingresando Turnos
PRINT 'Ingresando los turnos...'
GO
INSERT INTO Turnos (numero,medico,afiliado,fechaHora,fechaHoraLlegada)
SELECT distinct m.Turno_Numero , x.idUser , u.idUser, m.Turno_Fecha,null -- ver como descontar 15 minutos
FROM gd_esquema.Maestra m
inner join Usuarios u ON u.username=CAST(m.Paciente_Dni AS NVARCHAR(255))
inner join Usuarios x on x.username =CAST(m.Medico_Dni AS NVARCHAR(255))
where m.Turno_Fecha is not null
order by 1



INSERT INTO Consulta(turno,bono,sintomas,enfermedad)
SELECT  distinct m.Turno_Numero , m.Bono_Consulta_Numero,m.Consulta_Sintomas,m.Consulta_Enfermedades
FROM gd_esquema.Maestra m 
INNER JOIN Turnos t ON t.numero = m.Turno_Numero
INNER JOIN Bonos b ON m.Bono_Consulta_Numero = b.numeroBono   
GO  



--Ingresando Planes
PRINT 'Ingresando los Planes...'
GO
INSERT INTO Planes_Medicos (codigo,descripcionPM,precioConsulta,precioFarmacia)
SELECT distinct m.Plan_Med_Codigo, m.Plan_Med_Descripcion, m.Plan_Med_Precio_Bono_Consulta , m.Plan_Med_Precio_Bono_Farmacia
FROM gd_esquema.Maestra m
GO


--Ingresando Medicos Esp

PRINT 'Ingresando TipoESP...'
GO
INSERT INTO Tipos_Especialidad (codigoEsp , descripcionEsp)
SELECT distinct m.Tipo_Especialidad_Codigo , m.Tipo_Especialidad_Descripcion
FROM gd_esquema.Maestra m
WHERE m.Tipo_Especialidad_Codigo is not null
GO

PRINT 'Ingresando especialidades...'
GO
INSERT INTO Especialidades(codigoEspecialidad , descripcionEsp , tipoEsp)
SELECT distinct m.Especialidad_Codigo , m.Especialidad_Descripcion, m.Tipo_Especialidad_Codigo
FROM gd_esquema.Maestra m
WHERE m.Tipo_Especialidad_Codigo is not null 
GO

PRINT 'Ingresando Medicos_Esp...'
GO
INSERT INTO Medicos_Esp(medico , especialidad)
SELECT distinct a.matricula , m.Especialidad_Codigo
FROM gd_esquema.Maestra m
inner join Usuarios u on u.username = CAST(m.Medico_Dni AS NVARCHAR(255))
inner join Medicos a on u.idUser = a.userId
GO



--Ingresando Recetas
PRINT 'Ingresando los Recetas...'
GO
INSERT INTO Receta (bonoConsulta, bonoFarmacia)
SELECT  m.Bono_Farmacia_Numero , m.Bono_Consulta_Numero
from gd_esquema.Maestra m
Where ( m.Bono_Farmacia_Numero is not null AND m.Bono_Consulta_Numero is not null )
GO

--INGRESANDO MEDICAMENTOS
print'INGREANDO MEDICAMENTOS'
GO
INSERT INTO Medicamentos (descrip)
select distinct m.Bono_Farmacia_Medicamento
from gd_esquema.Maestra m 
GO

--Ingresando Recetas_medicamen
PRINT 'Ingresando los  Recetas_medicamen...'
GO
INSERT INTO  Recetas_medicamen (receta , medicamento)
SELECT  m.Bono_Farmacia_Numero , me.idMedic
from gd_esquema.Maestra m
inner join Medicamentos me on me.descrip = m.Bono_Farmacia_Medicamento 
GO

-----MIGRANDO ROLES



INSERT INTO Usuarios_Roles(usuario) 
Select u.username      
from Usuarios u

---migrar roles de medico
INSERT INTO Roles(idRol , descripRol , activoRol, perfil ) 
select distinct u.rol , 'medico' , 1 ,2
from Usuarios_Roles u
inner join gd_esquema.Maestra m on u.usuario = CAST(m.Medico_Dni AS NVARCHAR(255))     
---migrar roles de afiliado
INSERT INTO Roles(idRol , descripRol , activoRol, perfil ) 
select distinct u.rol , 'Afiliado' , 1 , 1
from Usuarios_Roles u
inner join gd_esquema.Maestra m on u.usuario = CAST(m.Paciente_Dni AS NVARCHAR(255))

-- ROLES FUNC 
INSERT INTO Roles_Func (rol, funcionalidad)
select distinct idRol ,4
from Roles
where descripRol = 'Afiliado'

INSERT INTO Roles_Func (rol, funcionalidad)
select distinct idRol ,8
from Roles
where descripRol = 'Afiliado'

INSERT INTO Roles_Func (rol, funcionalidad)
select distinct idRol ,10
from Roles
where descripRol = 'Afiliado'

INSERT INTO Roles_Func (rol, funcionalidad)
select distinct idRol ,12
from Roles
where descripRol = 'Afiliado'

INSERT INTO Roles_Func (rol, funcionalidad)
select distinct idRol ,14
from Roles
where descripRol = 'Afiliado'

INSERT INTO Roles_Func (rol, funcionalidad)
select distinct idRol ,1
from Roles
where descripRol = 'medico'

INSERT INTO Roles_Func (rol, funcionalidad)
select distinct idRol ,12
from Roles
where descripRol = 'medico'


PRINT 'Proceso finalizado con éxito!'
GO