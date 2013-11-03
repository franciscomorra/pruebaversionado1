USE [GD2C2013]
/*
GO
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = 'SHARPS')
DROP SCHEMA [SHARPS]
GO
CREATE SCHEMA [SHARPS] AUTHORIZATION [gd]
GO
*/

CREATE TABLE Afiliados ( 
	GrupoFamiliar [int] NOT NULL,
	PlanMedico [int],
	Activo [bit],
	EstadoCivil [int],
	CantHijos [int],
	UsuarioID [int],
	TipoAfiliado [int],    
CONSTRAINT [PK_Afiliados] PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE Agendas ( 
	AgendaID  [int] IDENTITY (1,1) NOT NULL,
	Profesional [int],
	Horario datetime,
CONSTRAINT [PK_Agendas] PRIMARY KEY CLUSTERED 
(
	Profesional,Horario ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE Bonos ( 
	NumeroDeBono [int]  NOT NULL,
	Fecha_Impresion datetime,
	Afiliado_Compro nvarchar(MAX),
	Tipo_Bono [int],
	PlanMedico [int],
CONSTRAINT [PK_Bonos] PRIMARY KEY CLUSTERED 
(
	NumeroDeBono,Tipo_Bono ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE Cambios_Afiliado ( 
	Afiliado [int],
	Fecha datetime,
	Motivo_Cambio char(10)
)
;

CREATE TABLE Consultas ( --Revisar, Numero_Consulta es la cantidad de veces que el paciente se atendio
	Turno [int],
	Bono [int],
	Sintomas nvarchar(MAX),
	Enfermedad nvarchar(MAX),
	Numero_Consulta [int]
CONSTRAINT [PK_Consulta] PRIMARY KEY CLUSTERED 
(
	Turno,Bono ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE Detalles_Persona ( 
	UsuarioID [int] NOT NULL,
	DNI [int],
	TipoDNI nvarchar(5),
	Telefono [numeric](18, 0),
	Direccion nvarchar(MAX),
	Sexo nvarchar(10),
	Mail nvarchar(50),
	Apellido nvarchar(50),
	Nombre nvarchar(50),
	FechaNac datetime
)
;
/*
CREATE TABLE Feriados ( 
	Fecha datetime NOT NULL
)
;
*/
CREATE TABLE Especialidades ( 
	Codigo [int] NOT NULL,
	Descripcion nvarchar(MAX),
	Tipo [int],
CONSTRAINT [PK_Especialidades] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;
CREATE TABLE Estados_Civiles ( 
	Codigo [int] IDENTITY(1,1) NOT NULL,
	Descripcion nvarchar(MAX),
CONSTRAINT [PK_Estados_Civiles] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;
CREATE TABLE Estados_Turno ( 
	Estado [int] IDENTITY(1,1) NOT NULL,
	Descripcion nvarchar(50),
	MotivoCancelacion nvarchar(50),
CONSTRAINT [PK_Estados_Turno] PRIMARY KEY CLUSTERED 
(
	[Estado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE Funcionalidades ( 
	Codigo [int] IDENTITY (1,1) NOT NULL,
	Descripcion nvarchar(MAX),
CONSTRAINT [PK_Funcionalidades] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE Medicamentos ( 
	Codigo [int] IDENTITY (1,1),
	Descripcion nvarchar(MAX),
CONSTRAINT [PK_Medicamentos] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE Profesionales ( 
	Matricula [int],
	UsuarioID [int] NOT NULL,
	Activo char(10),
CONSTRAINT [PK_Profesionales] PRIMARY KEY CLUSTERED 
(
	[Matricula] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE Profesionales_Especialidades ( 
	Profesional [int],
	Especialidad [int]
)
;

CREATE TABLE Perfiles ( 
	PerfilID [int] identity(1,1) NOT NULL,
	Descripcion nvarchar(MAX),

CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED 
(
	[PerfilID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE Perfiles_Funcionalidades ( 
	Perfil [int] ,
	Funcionalidad [int]
)
;

CREATE TABLE Planes_Medicos ( 
	Codigo [int] NOT NULL,
	Descripcion nvarchar(MAX),
	Precio_Bono_Consulta [int],
	Precio_Bono_Farmacia [int],
CONSTRAINT [PK_Planes_Medicos] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE Recetas ( 
	BonoConsulta nvarchar(50),
	BonoFarmacia nvarchar(50),
	RecetaID [int] identity(1,1),
CONSTRAINT [PK_Recetas] PRIMARY KEY CLUSTERED 
(
	[RecetaID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE Recetas_Medicamentos ( 
	Receta nvarchar(50),
	Medicamento [int]
CONSTRAINT [PK_Recetas_Medicamen] PRIMARY KEY CLUSTERED 
(
	[Receta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE Roles ( 
	RolID [int] identity(1,1) NOT NULL,
	Descripcion nvarchar(50),
	Activo bit,
	Perfil [int],
CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RolID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE Roles_Funcionalidades ( 
	Rol [int],
	Funcionalidad [int] NOT NULL
)
;

CREATE TABLE Tipos_Bonos ( 
	Codigo [int] identity(1,1) NOT NULL,
	Descripcion nvarchar(MAX),
CONSTRAINT [PK_Tipos_Bonos] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE Tipos_Especialidades ( 
	Codigo [int] NOT NULL,
	Descripcion nvarchar(MAX),
CONSTRAINT [PK_Tipos_Especialidad] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE Turnos ( 
	Numero [int] NOT NULL,
	Afiliado [int],
	Estado [int]  ,
	FechaHoraLlegada datetime,
	Agenda datetime,--Tiene que ser [int],
	Profesional [int] --No tiene que ir!
CONSTRAINT [PK_Turnos] PRIMARY KEY CLUSTERED 
(
	[Numero] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE Usuarios ( 
	UsuarioID [int] identity(1,1)  NOT NULL,
	Username nvarchar(MAX),
	Password nvarchar(MAX) NOT NULL,
	Intentos [int],
	Activo bit,
CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE Usuarios_Roles ( 
	Usuario [int] NOT NULL,
	Rol [int] NOT NULL
)
;






-------MIGRACIONES------------------------------------------------------
PRINT 'INICIO DE MIGRACION DE DATOS'

PRINT 'Creando Funcionalidades'
INSERT INTO Funcionalidades (Descripcion) VALUES ('AdministrarAfiliados'); --Listado de Afiliados
INSERT INTO Funcionalidades (Descripcion) VALUES ('AbmEspecialidadesMedicas'); --No se requiere
INSERT INTO Funcionalidades (Descripcion) VALUES ('AbmPlanes'); --No se requiere
INSERT INTO Funcionalidades (Descripcion) VALUES ('AdministrarProfesionales'); --Listado de Profesionales
INSERT INTO Funcionalidades (Descripcion) VALUES ('AdministrarRoles'); --Listado de Roles
INSERT INTO Funcionalidades (Descripcion) VALUES ('AdministrarTurnos'); --Listado de Turnos de Afiliado
INSERT INTO Funcionalidades (Descripcion) VALUES ('CancelarDia'); --Cancelar dia para Profesional
INSERT INTO Funcionalidades (Descripcion) VALUES ('ComprarBonos'); --Comprar Bonos para Afiliado
INSERT INTO Funcionalidades (Descripcion) VALUES ('GenerarRecetas'); --Generar una Receta
INSERT INTO Funcionalidades (Descripcion) VALUES ('ListarEstadisticas'); --Listados Estadisticos
INSERT INTO Funcionalidades (Descripcion) VALUES ('RegistrarAgenda'); --Registrar Agenda de Profesional
INSERT INTO Funcionalidades (Descripcion) VALUES ('RegistroLlegada'); --Registrar llegada de Afiliado
INSERT INTO Funcionalidades (Descripcion) VALUES ('RegistroResultadoAtencion'); --Registrar Resultados
INSERT INTO Funcionalidades (Descripcion) VALUES ('RegistroUsuario'); --No se requiere


PRINT 'Creando Perfiles'
INSERT INTO Perfiles (Descripcion) VALUES ('Afiliado');
INSERT INTO Perfiles (Descripcion) VALUES ('Profesional');
INSERT INTO Perfiles (Descripcion) VALUES ('Administrativo')
INSERT INTO Perfiles (Descripcion) VALUES ('Administrador')

PRINT 'Asignando Funcionalidades a los Perfiles'
INSERT INTO Perfiles_Funcionalidades (Perfil , Funcionalidad)
SELECT p.perfilID, f.Codigo FROM Perfiles p, Funcionalidades f
WHERE p.Descripcion = 'Administrador'

INSERT INTO Perfiles_Funcionalidades (Perfil , Funcionalidad)
SELECT p.perfilID, f.Codigo FROM Perfiles p, Funcionalidades f
WHERE p.Descripcion = 'Afiliado' AND f.Descripcion = 'AdministrarTurnos'

INSERT INTO Perfiles_Funcionalidades (Perfil , Funcionalidad)
SELECT p.perfilID, f.Codigo FROM Perfiles p, Funcionalidades f
WHERE p.Descripcion = 'Afiliado' AND f.Descripcion = 'ComprarBonos'

INSERT INTO Perfiles_Funcionalidades (Perfil , Funcionalidad)
SELECT p.perfilID, f.Codigo FROM Perfiles p, Funcionalidades f
WHERE p.Descripcion = 'Administrativo' AND f.Descripcion = 'ListarEstadisticas'

INSERT INTO Perfiles_Funcionalidades (Perfil , Funcionalidad)
SELECT p.perfilID, f.Codigo FROM Perfiles p, Funcionalidades f
WHERE p.Descripcion = 'Administrativo' AND f.Descripcion = 'AdministrarAfiliados'

INSERT INTO Perfiles_Funcionalidades (Perfil , Funcionalidad)
SELECT p.perfilID, f.Codigo FROM Perfiles p, Funcionalidades f
WHERE p.Descripcion = 'Administrativo' AND f.Descripcion = 'AbmEspecialidadesMedicas'

INSERT INTO Perfiles_Funcionalidades (Perfil , Funcionalidad)
SELECT p.perfilID, f.Codigo FROM Perfiles p, Funcionalidades f
WHERE p.Descripcion = 'Administrativo' AND f.Descripcion = 'AbmPlanes'

INSERT INTO Perfiles_Funcionalidades (Perfil , Funcionalidad)
SELECT p.perfilID, f.Codigo FROM Perfiles p, Funcionalidades f
WHERE p.Descripcion = 'Administrativo' AND f.Descripcion = 'AdministrarProfesionales'

INSERT INTO Perfiles_Funcionalidades (Perfil , Funcionalidad)
SELECT p.perfilID, f.Codigo FROM Perfiles p, Funcionalidades f
WHERE p.Descripcion = 'Administrativo' AND f.Descripcion = 'AdministrarRoles'

INSERT INTO Perfiles_Funcionalidades (Perfil , Funcionalidad)
SELECT p.perfilID, f.Codigo FROM Perfiles p, Funcionalidades f
WHERE p.Descripcion = 'Administrativo' AND f.Descripcion = 'RegistroLlegada'

INSERT INTO Perfiles_Funcionalidades (Perfil , Funcionalidad)
SELECT p.perfilID, f.Codigo FROM Perfiles p, Funcionalidades f
WHERE p.Descripcion = 'Administrativo' AND f.Descripcion = 'RegistroUsuario'

INSERT INTO Perfiles_Funcionalidades (Perfil , Funcionalidad)
SELECT p.perfilID, f.Codigo FROM Perfiles p, Funcionalidades f
WHERE p.Descripcion = 'Profesional' AND f.Descripcion = 'CancelarDia'


INSERT INTO Perfiles_Funcionalidades (Perfil , Funcionalidad)
SELECT p.perfilID, f.Codigo FROM Perfiles p, Funcionalidades f
WHERE p.Descripcion = 'Profesional' AND f.Descripcion = 'GenerarRecetas'

INSERT INTO Perfiles_Funcionalidades (Perfil , Funcionalidad)
SELECT p.perfilID, f.Codigo FROM Perfiles p, Funcionalidades f
WHERE p.Descripcion = 'Profesional' AND f.Descripcion = 'RegistrarAgenda'


INSERT INTO Perfiles_Funcionalidades (Perfil , Funcionalidad)
SELECT p.perfilID, f.Codigo FROM Perfiles p, Funcionalidades f
WHERE p.Descripcion = 'Profesional' AND f.Descripcion = 'RegistroResultadoAtencion'

PRINT 'Agregando Roles' --Los roles por defecto tienen los mismos nombres que sus perfiles
INSERT INTO Roles (Descripcion,Perfil) 
SELECT p.Descripcion, p.PerfilID FROM Perfiles p

-- ROLES FUNC 
PRINT 'Asignando Funcionalidades a los Roles' --Los roles tienen todas las funcionalidades del perfil
INSERT INTO Roles_Funcionalidades (Rol, Funcionalidad)
SELECT PF.Perfil AS ROL, PF.Funcionalidad AS FUNCIONALIDAD FROM Perfiles_Funcionalidades PF


PRINT 'Generando Usuario Administrador...'
INSERT INTO Usuarios (Activo,Intentos,Username,Password)
values (1,0,'Administrador','E6-B8-70-50-BF-CB-81-43-FC-B8-DB-01-70-A4-DC-9E-D0-0D-90-4D-DD-3E-2A-4A-D1-B1-E8-DC-0F-DC-9B-E7')


PRINT 'Ingresando Estados Civiles...'
INSERT INTO Estados_Civiles(Descripcion) VALUES ('Soltero'); 
INSERT INTO Estados_Civiles (Descripcion) VALUES ('Casado');
INSERT INTO Estados_Civiles (Descripcion) VALUES ('Viudo');
INSERT INTO Estados_Civiles (Descripcion) VALUES ('En Pareja');

PRINT 'Ingresando los Usuarios de Afiliados...'
INSERT INTO Usuarios (Activo,Intentos,Username,Password)
SELECT DISTINCT 1,0,LTRIM(RTRIM(CAST(Paciente_DNI AS Nvarchar(MAX)))),'E6-B8-70-50-BF-CB-81-43-FC-B8-DB-01-70-A4-DC-9E-D0-0D-90-4D-DD-3E-2A-4A-D1-B1-E8-DC-0F-DC-9B-E7' 
FROM gd_esquema.Maestra 
WHERE Paciente_DNI is not null


PRINT 'Ingresando los Detalles Personales de Afiliados...'
INSERT INTO Detalles_Persona(DNI,TipoDNI,Telefono,Direccion,Sexo,Mail,Apellido,Nombre,UsuarioID,FechaNac) 
SELECT distinct m.Paciente_DNI,'DNI',m.Paciente_Telefono,m.Paciente_Direccion,NULL, m.Paciente_Mail,m.Paciente_Apellido,m.Paciente_Nombre, u.UsuarioID, m.Paciente_Fecha_Nac 
FROM gd_esquema.Maestra m INNER JOIN Usuarios u ON CAST(m.Paciente_DNI AS Nvarchar(MAX))=u.Username 

PRINT 'Ingresando las Entidades de Afiliados...'

INSERT INTO Afiliados(GrupoFamiliar,PlanMedico,Activo, EstadoCivil,CantHijos,UsuarioID)
SELECT DISTINCT (RANK() OVER (ORDER BY m.Paciente_DNI DESC)* 100), m.Plan_Med_Codigo,1, NULL,NULL, u.UsuarioID  FROM Usuarios u  -----faltaria aignarle el 01 02 03
INNER JOIN gd_esquema.Maestra m ON u.Username = CAST(m.Paciente_DNI AS Nvarchar(MAX))
GO

PRINT 'Ingresando los Usuarios de Profesionales...'
INSERT INTO Usuarios (Activo,Intentos,Username,Password)
SELECT DISTINCT 1,0, LTRIM(RTRIM(CAST(m.Medico_DNI AS Nvarchar(MAX)))),'E6-B8-70-50-BF-CB-81-43-FC-B8-DB-01-70-A4-DC-9E-D0-0D-90-4D-DD-3E-2A-4A-D1-B1-E8-DC-0F-DC-9B-E7' 
FROM gd_esquema.Maestra m 
WHERE Medico_DNI is not null

PRINT 'Ingresando los Detalles Personales de Profesionales...'
INSERT INTO Detalles_Persona(DNI,TipoDNI,Telefono,Direccion,Sexo,Mail,Apellido,Nombre,UsuarioID,FechaNac) 
SELECT distinct m.Medico_DNI,NULL,m.Medico_Telefono,m.Medico_Direccion,NULL,m.Medico_Mail,m.Medico_Apellido,m.Medico_Nombre, u.UsuarioID,m.Medico_Fecha_Nac FROM gd_esquema.Maestra m 
 INNER JOIN Usuarios u ON CAST(m.Medico_DNI AS Nvarchar(MAX))=u.Username 
 --inner join Detalles_Persona dp on dp.DNI < > m.Medico_DNI ------AUN NO PROBADO


PRINT 'Ingresando las Entidades de Profesionales...'

INSERT INTO Profesionales (Matricula, UsuarioID , Activo)
SELECT DISTINCT (RANK() OVER (ORDER BY m.Medico_DNI DESC)+ 723), u.UsuarioID, 1 
FROM gd_esquema.Maestra m
INNER JOIN Usuarios u ON u.Username= CAST(m.Medico_DNI AS Nvarchar(MAX))





--Ingresando los Bonos
PRINT 'Ingresando los Tipos de Bonos'
INSERT INTO Tipos_Bonos (Descripcion) VALUES ('Consulta'); ---- correspode al 1 de Tipos
INSERT INTO Tipos_Bonos (Descripcion) VALUES ('Farmacia'); ---corresponde al 2 de Tipos

PRINT 'Ingresando los Bonos Consulta'
GO
INSERT INTO Bonos(NumeroDeBono,Fecha_Impresion,Afiliado_Compro,Tipo_Bono,PlanMedico)
SELECT distinct m.Bono_Consulta_Numero , m.Bono_Consulta_Fecha_Impresion,a.UsuarioID ,1, m.Plan_Med_Codigo  
  FROM gd_esquema.Maestra m
  inner join Usuarios a on CAST(m.Paciente_DNI AS Nvarchar(MAX))= a.Username
  WHERE m.Turno_Fecha is NULL AND m.Bono_Consulta_Numero is not null  
GO
PRINT 'Ingresando los Bonos Farmacia'
INSERT INTO Bonos(NumeroDeBono,Fecha_Impresion,Afiliado_Compro,Tipo_Bono,PlanMedico)
SELECT distinct m.Bono_Farmacia_Numero , m.Bono_Farmacia_Fecha_Impresion, a.UsuarioID,2, m.Plan_Med_Codigo  
  FROM gd_esquema.Maestra m
  inner join Usuarios a on CAST(m.Paciente_DNI AS Nvarchar(MAX))= a.Username
  WHERE m.Turno_Fecha is NULL AND m.Bono_Farmacia_Numero is not null   
GO
/*
--Rellenando Agendas
PRINT 'Rellenando Agendas...'
INSERT INTO Agendas(Profesional,Horario)
SELECT distinct x.UsuarioID , m.Turno_Fecha
FROM gd_esquema.Maestra m
inner join Usuarios x on x.Username =CAST(m.Medico_DNI AS Nvarchar(MAX))
WHERE m.Turno_Fecha is not null
order by 1


--Ingresando Turnos
PRINT 'Ingresando los Turnos...'
GO
INSERT INTO Turnos (Numero,Afiliado,Agenda)
SELECT distinct m.Turno_Numero , u.UsuarioID , a.AgendaID 
FROM gd_esquema.Maestra m
INNER JOIN Agendas a ON a.Horario = m.Turno_Fecha
INNER JOIN Usuarios x ON x.UsuarioID = a.Profesional
INNER JOIN Usuarios U on u.Username = CAST(m.Paciente_Dni AS Nvarchar(MAX))
WHERE m.Turno_Fecha is not null
ORDER by 1
*/

--Ingresando Turnos
DELETE FROM TURNOS
PRINT 'Ingresando los Turnos...'
GO
INSERT INTO Turnos (Numero,Profesional,Afiliado,Agenda,FechaHoraLlegada)
SELECT distinct m.Turno_Numero , x.UsuarioID , u.UsuarioID, m.Turno_Fecha, null -- ver como descontar 15 minutos
FROM gd_esquema.Maestra m
inner join Usuarios u ON u.Username=CAST(m.Paciente_DNI AS Nvarchar(MAX))
inner join Usuarios x on x.Username =CAST(m.Medico_DNI AS Nvarchar(MAX))

WHERE m.Turno_Fecha is not null
order by 1

--Rellenando Agendas
PRINT 'Rellenando Agendas...'
INSERT INTO Agendas(Profesional,Horario)
SELECT t.Profesional,t.Agenda
FROM Turnos t


PRINT 'Rellenando Consultas...'
INSERT INTO Consultas(Turno,Bono,Sintomas,Enfermedad)
SELECT  distinct m.Turno_Numero , m.Bono_Consulta_Numero,m.Consulta_Sintomas,m.Consulta_Enfermedades
FROM gd_esquema.Maestra m 
INNER JOIN Turnos t ON t.Numero = m.Turno_Numero
INNER JOIN Bonos b ON m.Bono_Consulta_Numero = b.NumeroDeBono   
GO  


--Ingresando Planes
PRINT 'Ingresando los Planes...'
GO
INSERT INTO Planes_Medicos (Codigo,Descripcion,Precio_Bono_Consulta,Precio_Bono_Farmacia)
SELECT distinct m.Plan_Med_Codigo, m.Plan_Med_Descripcion, m.Plan_Med_Precio_Bono_Consulta , m.Plan_Med_Precio_Bono_Farmacia
FROM gd_esquema.Maestra m
GO


--Ingresando Profesionales Esp

PRINT 'Ingresando Tipos de Especialidades...'
GO
INSERT INTO Tipos_Especialidades (Codigo , Descripcion)
SELECT distinct m.Tipo_Especialidad_Codigo , m.Tipo_Especialidad_Descripcion
FROM gd_esquema.Maestra m
WHERE m.Tipo_Especialidad_Codigo is not null
GO

PRINT 'Ingresando Especialidades...'
GO
INSERT INTO Especialidades(Codigo , Descripcion , Tipo)
SELECT distinct m.Especialidad_Codigo , m.Especialidad_Descripcion, m.Tipo_Especialidad_Codigo
FROM gd_esquema.Maestra m
WHERE m.Tipo_Especialidad_Codigo is not null 
GO

PRINT 'Ingresando Relacion Profesionales-Especialidades...'
GO
INSERT INTO Profesionales_Especialidades(Profesional, Especialidad)
SELECT distinct a.Matricula , m.Especialidad_Codigo
FROM gd_esquema.Maestra m
inner join Usuarios u on u.Username = CAST(m.Medico_DNI AS Nvarchar(MAX))
inner join Profesionales a on u.UsuarioID = a.UsuarioID
GO



--Ingresando Recetas
PRINT 'Ingresando las Recetas...'
GO
INSERT INTO Recetas (BonoConsulta, BonoFarmacia)
SELECT  m.Bono_Farmacia_Numero , m.Bono_Consulta_Numero
FROM gd_esquema.Maestra m
WHERE ( m.Bono_Farmacia_Numero is not null AND m.Bono_Consulta_Numero is not null )
GO

--INGRESANDO MEDICAMENTOS
print 'Ingresando Medicamentos'
GO
INSERT INTO Medicamentos (Descripcion)
SELECT distinct m.Bono_Farmacia_Medicamento
FROM gd_esquema.Maestra m 
GO

--Ingresando Recetas_Medicamentos
PRINT 'Ingresando la relacion Recetas_Medicamentos...'
GO
INSERT INTO  Recetas_Medicamentos (Receta , Medicamento)
SELECT  m.Bono_Farmacia_Numero , me.Codigo
FROM gd_esquema.Maestra m
inner join Medicamentos me on me.Descripcion = m.Bono_Farmacia_Medicamento 
GO

-----MIGRANDO ROLES


PRINT 'Ingresando Relacion Usuarios-Roles...'
PRINT 'Profesionales...'
INSERT INTO Usuarios_Roles(Usuario , Rol) --- Lo hago 2 veces ya que uno puede ser para paciente y otro Medico pero ambos tienen el mismo Usuario(DNI)  y se le aignan 2 roles
SELECT distinct CAST(m.UsuarioID AS Nvarchar(MAX))  , 2    
FROM Profesionales m 

PRINT 'Afiliados...'
INSERT INTO Usuarios_Roles(Usuario , Rol) 
SELECT distinct CAST( a.UsuarioID AS Nvarchar(MAX)),1      
FROM Afiliados a


PRINT 'Administrador...'
INSERT INTO Usuarios_Roles (Rol,Usuario)
SELECT R.RolID, U.UsuarioID
FROM Roles R, Usuarios U
WHERE R.Descripcion = 'Administrador'
AND U.Username = 'Administrador'

PRINT 'Proceso finalizado con éxito!'
GO