USE [GD2C2013]
GO
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = 'SHARPS')
DROP SCHEMA [SHARPS]
GO
/****** Object:  Schema [GRUPO_N]    Script Date: 11/12/2012 20:20:08 ******/
CREATE SCHEMA [SHARPS] AUTHORIZATION [gd]
GO


CREATE TABLE Afiliados ( 
	nroAfiliado int NOT NULL,
	planMedico int,
	activoAfiliado char(10),
	estadoCivil nchar(10),
	cantHijos int,
	userId int,
	tipoAfiliado int,       --------<----------SOLUCION AL 01,02,03     
CONSTRAINT [PK_Afiliados] PRIMARY KEY CLUSTERED 
(
	[nroAfiliado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE Agendas ( 
	medico int,
	dia datetime,
	idEntrada int, 
	idTurno int,
CONSTRAINT [PK_Agendas] PRIMARY KEY CLUSTERED 
(
	[idTurno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE Bonos ( 
	numeroBono int  NOT NULL,
	fechaImp datetime,
	afiliadoCompro nvarchar(255),
	tipoBono nchar(10),
	planMedico int,
CONSTRAINT [PK_Bonos] PRIMARY KEY CLUSTERED 
(
	[numeroBono] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE Cambios_Afiliado ( 
	afiliado int,
	fecha date,
	motivo char(10)
)
;

CREATE TABLE Consulta ( 
	turno int,
	bono int,
	sintomas varchar(255),
	enfermedad varchar(255),
	nroConsulta int identity(1,1),
CONSTRAINT [PK_Consulta] PRIMARY KEY CLUSTERED 
(
	[nroConsulta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE Detalles_Persona ( 
	dni int,
	tipo varchar(255),
	telefono int,
	direccion varchar(255),
	sexo char(10),
	mail varchar(255),
	apellido varchar(255),
	nombre varchar(255),
	userId int NOT NULL,
	fechaNac date
)
;

CREATE TABLE Dias_Laborales ( 
	fecha date NOT NULL
)
;

CREATE TABLE Especialidades ( 
	codigoEspecialidad int NOT NULL,
	descripcionEsp varchar(255),
	tipoEsp int,
CONSTRAINT [PK_Especialidades] PRIMARY KEY CLUSTERED 
(
	[codigoEspecialidad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE Estados_turno ( 
	idEstado int NOT NULL,
	descTurno nchar(10),
	motivoCancel nchar(10),
CONSTRAINT [PK_Estados_turno] PRIMARY KEY CLUSTERED 
(
	[idEstado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE Funcionalidades ( 
	idFunc numeric(10) IDENTITY (1,1) NOT NULL,
	descripcion nchar(255),
CONSTRAINT [PK_Funcionalidades] PRIMARY KEY CLUSTERED 
(
	[idFunc] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE Medicamentos ( 
	idMedic int identity (1000,1),
	descrip nchar(255),
CONSTRAINT [PK_Medicamentos] PRIMARY KEY CLUSTERED 
(
	[idMedic] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE Medicos ( 
	matricula int,
	userId int NOT NULL,
	activoMedico char(10),
CONSTRAINT [PK_Medicos] PRIMARY KEY CLUSTERED 
(
	[matricula] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE Medicos_Esp ( 
	medico int,
	especialidad int
)
;

CREATE TABLE Perfil ( 
	idPerfil numeric(10) identity(1,1) NOT NULL,
	detallesPerf nchar(255),
CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED 
(
	[idPerfil] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE Perfil_Func ( 
	perfil numeric(10,2) ,
	funcion numeric(10,2)
)
;

CREATE TABLE Planes_Medicos ( 
	codigo int NOT NULL,
	descripcionPM varchar(255),
	precioConsulta int,
	precioFarmacia int,
CONSTRAINT [PK_Planes_Medicos] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE Receta ( 
	bonoConsulta nchar(10),
	bonoFarmacia nchar(10),
	idReceta int identity(1,1),
CONSTRAINT [PK_Receta] PRIMARY KEY CLUSTERED 
(
	[idReceta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE Recetas_Medicamen ( 
	receta nchar(10),
	medicamento int
CONSTRAINT [PK_Recetas_Medicamen] PRIMARY KEY CLUSTERED 
(
	[receta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE Roles ( 
	idRol numeric(10) identity(1,1) NOT NULL,
	descripRol nchar(10),
	activoRol bit,
	perfil numeric(10,2),
CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[idRol] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE Roles_Func ( 
	rol numeric(10,2),
	funcionalidad numeric(10,2) NOT NULL
)
;



CREATE TABLE Tipos_Especialidad ( 
	codigoEsp int NOT NULL,
	descripcionEsp varchar(255),
CONSTRAINT [PK_Tipos_Especialidad] PRIMARY KEY CLUSTERED 
(
	[codigoEsp ] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE Turnos ( 
	numero int NOT NULL,
	medico int,
	afiliado int,
	fechaHora datetime,
	estado int  ,
	fechaHoraLlegada datetime,
	idAgenda int identity(1,1),
CONSTRAINT [PK_Turnos] PRIMARY KEY CLUSTERED 
(
	[numero] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE Usuarios ( 
	idUser int identity(1000,1)  NOT NULL,
	username nvarchar(255),
	password nvarchar(255) NOT NULL,
	intentos int,
	activo bit,
CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[idUser] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE Usuarios_Roles ( 
	usuario int NOT NULL,
	rol numeric(10) NOT NULL
)
;






-------MIGRACIONES------------------------------------------------------
PRINT 'INICIO DE MIGRACION DE DATOS'


INSERT INTO Funcionalidades (Descripcion) VALUES ('AdministrarAfiliados'); ---1
INSERT INTO Funcionalidades (Descripcion) VALUES ('AbmEspecialidadesMedicas');---2
INSERT INTO Funcionalidades (Descripcion) VALUES ('AbmPlanes');---3
INSERT INTO Funcionalidades (Descripcion) VALUES ('AdministrarProfesionales');----4
INSERT INTO Funcionalidades (Descripcion) VALUES ('AdministrarRoles');----5
INSERT INTO Funcionalidades (Descripcion) VALUES ('CancelarAtencion');----6
INSERT INTO Funcionalidades (Descripcion) VALUES ('CompraBono');----7
INSERT INTO Funcionalidades (Descripcion) VALUES ('GenerarReceta');----8
INSERT INTO Funcionalidades (Descripcion) VALUES ('ListarEstadisticas');----9
INSERT INTO Funcionalidades (Descripcion) VALUES ('PedirTurno');-----10
INSERT INTO Funcionalidades (Descripcion) VALUES ('RegistrarAgenda');----11
INSERT INTO Funcionalidades (Descripcion) VALUES ('RegistroLlegada');----12
INSERT INTO Funcionalidades (Descripcion) VALUES ('RegistroResultadoAtencion');----13
INSERT INTO Funcionalidades (Descripcion) VALUES ('RegistroUsuario');----14

INSERT INTO Perfil (detallesPerf) VALUES ('Afiliado'); ---- correspode al 1 de perfil
INSERT INTO Perfil (detallesPerf) VALUES ('Medico'); ---corresponde al 2 de perfil

INSERT INTO Perfil (detallesPerf) VALUES ('Administrativo')

INSERT INTO Perfil (detallesPerf) VALUES ('administrador')







--- ESTE ES DIRECTO YA QUE ES RELACION DE 3A15   ---Modificar
INSERT INTO Perfil_Func (perfil , funcion)
values (1 ,6)
INSERT INTO Perfil_Func (perfil , funcion)
values (1 ,7)
INSERT INTO Perfil_Func (perfil , funcion)
values (1 ,10)
INSERT INTO Perfil_Func (perfil , funcion)
values (3 ,9 )
INSERT INTO Perfil_Func (perfil , funcion)
values (2 ,13)

INSERT INTO Perfil_Func (perfil , funcion)
values (2,6)
INSERT INTO Perfil_Func (perfil , funcion)
values (2,8)

INSERT INTO Perfil_Func (perfil , funcion)
values (3,1)
INSERT INTO Perfil_Func (perfil , funcion)
values (3,2)
INSERT INTO Perfil_Func (perfil , funcion)
values (3,3)
INSERT INTO Perfil_Func (perfil , funcion)
values (3,4)
INSERT INTO Perfil_Func (perfil , funcion)
values (3,5)
INSERT INTO Perfil_Func (perfil , funcion)
values (3,12)
INSERT INTO Perfil_Func (perfil , funcion)
values (3,14)
INSERT INTO Perfil_Func (perfil , funcion)
values (2,11)

---SI VA EL DIOS DESPUES LO AGREGO











-- Ingresando los clientes.
PRINT 'Ingresando los Afiliados...'
GO



INSERT INTO Usuarios (activo,Intentos,username,Password)
SELECT DISTINCT 1,0,LTRIM(RTRIM(CAST(Paciente_Dni AS NVARCHAR(255)))),'E6-B8-70-50-BF-CB-81-43-FC-B8-DB-01-70-A4-DC-9E-D0-0D-90-4D-DD-3E-2A-4A-D1-B1-E8-DC-0F-DC-9B-E7' 
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
SELECT DISTINCT 1,0, LTRIM(RTRIM(CAST(Medico_Dni AS NVARCHAR(255)))),'E6-B8-70-50-BF-CB-81-43-FC-B8-DB-01-70-A4-DC-9E-D0-0D-90-4D-DD-3E-2A-4A-D1-B1-E8-DC-0F-DC-9B-E7' 
FROM gd_esquema.Maestra m 
inner join Usuarios u on  LTRIM(RTRIM(CAST(m.Medico_dni AS NVARCHAR(255)))) <> u.username ---Para que no repita
Where Medico_Dni is not null

INSERT INTO Detalles_Persona(dni,tipo,telefono,direccion,sexo,mail,apellido,nombre,userid,fechaNac) 
SELECT distinct m.Medico_Dni,NULL,m.Medico_Telefono,m.Medico_Direccion,NULL,m.Medico_Mail,m.Medico_Apellido,m.Medico_Nombre, u.idUser,m.Medico_Fecha_Nac FROM gd_esquema.Maestra m 
 INNER JOIN Usuarios u ON CAST(m.Medico_Dni AS NVARCHAR(255))=u.username 
 inner join Detalles_Persona dp on dp.dni < > m.Medico_Dni ------AUN NO PROBADO



INSERT INTO Medicos (matricula, userId , activoMedico)
SELECT DISTINCT (ABS(CAST(NEWID() as binary(6)) % 100000) + 1700), u.idUser, 1 
FROM gd_esquema.Maestra m
INNER JOIN Usuarios u ON u.username= CAST(m.Medico_Dni AS NVARCHAR(255))











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

---Ingresando Agenda

INSERT INTO Agendas(idTurno , medico , dia , idEntrada)
select t.idAgenda , t.medico , t.fechaHora , null
from Turnos t


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



INSERT INTO Usuarios_Roles(usuario , rol) --- Lo hago 2 veces ya que uno puede ser para paciente y otro medico pero ambos tienen el mismo usuario(dni)  y se le aignan 2 roles
Select distinct CAST(m.Medico_Dni AS NVARCHAR(255))  , 2    
from gd_esquema.Maestra m
where m.Medico_Dni is not null

INSERT INTO Usuarios_Roles(usuario , rol) 
Select distinct CAST( m.Paciente_Dni AS NVARCHAR(255)),1      
from gd_esquema.Maestra m
where m.Paciente_Dni is not null

---migrar roles de afiliado
INSERT INTO Roles( descripRol , activoRol, perfil ) 
select distinct 'Afiliado' , 1 , 1
from Usuarios_Roles u
inner join gd_esquema.Maestra m on u.usuario = CAST(m.Paciente_Dni AS NVARCHAR(255))
---migrar roles de medico
INSERT INTO Roles( descripRol , activoRol, perfil ) 
select distinct  'medico' , 1 ,2
from Usuarios_Roles u
inner join gd_esquema.Maestra m on u.usuario = CAST(m.Medico_Dni AS NVARCHAR(255))     


-- ROLES FUNC 
INSERT INTO Roles_Func (rol, funcionalidad)
select distinct idRol ,6
from Roles
where descripRol = 'Afiliado'

INSERT INTO Roles_Func (rol, funcionalidad)
select distinct idRol ,7
from Roles
where descripRol = 'Afiliado'

INSERT INTO Roles_Func (rol, funcionalidad)
select distinct idRol ,10
from Roles
where descripRol = 'Afiliado'

INSERT INTO Roles_Func (rol, funcionalidad)
select distinct idRol ,11
from Roles
where descripRol = 'medico'


INSERT INTO Roles_Func (rol, funcionalidad)
select distinct idRol ,6
from Roles
where descripRol = 'medico'

INSERT INTO Roles_Func (rol, funcionalidad)
select distinct idRol ,8
from Roles
where descripRol = 'medico'

INSERT INTO Roles_Func (rol, funcionalidad)
select distinct idRol ,13
from Roles
where descripRol = 'medico'

PRINT 'Proceso finalizado con éxito!'
GO