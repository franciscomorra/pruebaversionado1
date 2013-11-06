USE [GD2C2013]

GO
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = 'SHARPS')
DROP SCHEMA [SHARPS]
GO
CREATE SCHEMA [SHARPS] AUTHORIZATION [gd]
GO



CREATE TABLE [SHARPS].Afiliados ( 
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

CREATE TABLE [SHARPS].Agendas ( 
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

CREATE TABLE [SHARPS].Bonos ( 
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

CREATE TABLE [SHARPS].Cambios_Afiliado ( 
	Afiliado [int],
	Fecha datetime,
	Motivo_Cambio char(10)
)
;

CREATE TABLE [SHARPS].Consultas ( --Revisar, Numero_Consulta es la cantidad de veces que el paciente se atendio
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

CREATE TABLE [SHARPS].Detalles_Persona ( 
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
CREATE TABLE [SHARPS].Feriados ( 
	Fecha datetime NOT NULL
)
;
*/
CREATE TABLE [SHARPS].Especialidades ( 
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
CREATE TABLE [SHARPS].Estados_Civiles ( 
	Codigo [int] IDENTITY(1,1) NOT NULL,
	Descripcion nvarchar(MAX),
CONSTRAINT [PK_Estados_Civiles] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;
CREATE TABLE [SHARPS].Estados_Turno ( 
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

CREATE TABLE [SHARPS].Funcionalidades ( 
	Codigo [int] IDENTITY (1,1) NOT NULL,
	Descripcion nvarchar(MAX),
CONSTRAINT [PK_Funcionalidades] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE [SHARPS].Medicamentos ( 
	Codigo [int] IDENTITY (1,1),
	Descripcion nvarchar(MAX),
CONSTRAINT [PK_Medicamentos] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE [SHARPS].Profesionales ( 
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

CREATE TABLE [SHARPS].Profesionales_Especialidades ( 
	Profesional [int],
	Especialidad [int]
)
;

CREATE TABLE [SHARPS].Perfiles ( 
	PerfilID [int] identity(1,1) NOT NULL,
	Descripcion nvarchar(MAX),

CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED 
(
	[PerfilID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE [SHARPS].Perfiles_Funcionalidades ( 
	Perfil [int] ,
	Funcionalidad [int]
)
;

CREATE TABLE [SHARPS].Planes_Medicos ( 
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

CREATE TABLE [SHARPS].Recetas ( 
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

CREATE TABLE [SHARPS].Recetas_Medicamentos ( 
	Receta nvarchar(50),
	Medicamento [int]
CONSTRAINT [PK_Recetas_Medicamen] PRIMARY KEY CLUSTERED 
(
	[Receta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE [SHARPS].Roles ( 
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

CREATE TABLE [SHARPS].Roles_Funcionalidades ( 
	Rol [int],
	Funcionalidad [int] NOT NULL
)
;

CREATE TABLE [SHARPS].Tipos_Bonos ( 
	Codigo [int] identity(1,1) NOT NULL,
	Descripcion nvarchar(MAX),
CONSTRAINT [PK_Tipos_Bonos] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE [SHARPS].Tipos_Especialidades ( 
	Codigo [int] NOT NULL,
	Descripcion nvarchar(MAX),
CONSTRAINT [PK_Tipos_Especialidad] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE [SHARPS].Turnos ( 
	Numero [int] NOT NULL,
	Afiliado [int],
	Estado [int]  ,
	FechaHoraLlegada datetime,
	Agenda int,--Tiene que ser [int],
	--Profesional [int] --No tiene que ir!
CONSTRAINT [PK_Turnos] PRIMARY KEY CLUSTERED 
(
	[Numero] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE [SHARPS].Usuarios ( 
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

CREATE TABLE [SHARPS].Usuarios_Roles ( 
	Usuario [int] NOT NULL,
	Rol [int] NOT NULL
)
;






-------MIGRACIONES------------------------------------------------------
PRINT 'INICIO DE MIGRACION DE DATOS'

PRINT 'Creando Funcionalidades'
INSERT INTO [SHARPS].Funcionalidades (Descripcion) VALUES ('AdministrarAfiliados'); --Listado de Afiliados
INSERT INTO [SHARPS].Funcionalidades (Descripcion) VALUES ('AbmEspecialidadesMedicas'); --No se requiere
INSERT INTO [SHARPS].Funcionalidades (Descripcion) VALUES ('AbmPlanes'); --No se requiere
INSERT INTO [SHARPS].Funcionalidades (Descripcion) VALUES ('AdministrarProfesionales'); --Listado de Profesionales
INSERT INTO [SHARPS].Funcionalidades (Descripcion) VALUES ('AdministrarRoles'); --Listado de Roles
INSERT INTO [SHARPS].Funcionalidades (Descripcion) VALUES ('AdministrarTurnos'); --Listado de Turnos de Afiliado
INSERT INTO [SHARPS].Funcionalidades (Descripcion) VALUES ('CancelarDia'); --Cancelar dia para Profesional
INSERT INTO [SHARPS].Funcionalidades (Descripcion) VALUES ('ComprarBonos'); --Comprar Bonos para Afiliado
INSERT INTO [SHARPS].Funcionalidades (Descripcion) VALUES ('GenerarRecetas'); --Generar una Receta
INSERT INTO [SHARPS].Funcionalidades (Descripcion) VALUES ('ListarEstadisticas'); --Listados Estadisticos
INSERT INTO [SHARPS].Funcionalidades (Descripcion) VALUES ('RegistrarAgenda'); --Registrar Agenda de Profesional
INSERT INTO [SHARPS].Funcionalidades (Descripcion) VALUES ('RegistroLlegada'); --Registrar llegada de Afiliado
INSERT INTO [SHARPS].Funcionalidades (Descripcion) VALUES ('RegistroResultadoAtencion'); --Registrar Resultados
INSERT INTO [SHARPS].Funcionalidades (Descripcion) VALUES ('RegistroUsuario'); --No se requiere


PRINT 'Creando Perfiles'
INSERT INTO [SHARPS].Perfiles (Descripcion) VALUES ('Afiliado');
INSERT INTO [SHARPS].Perfiles (Descripcion) VALUES ('Profesional');
INSERT INTO [SHARPS].Perfiles (Descripcion) VALUES ('Administrativo')
INSERT INTO [SHARPS].Perfiles (Descripcion) VALUES ('Administrador')

PRINT 'Asignando Funcionalidades a los Perfiles'
INSERT INTO [SHARPS].Perfiles_Funcionalidades (Perfil , Funcionalidad)
SELECT p.perfilID, f.Codigo FROM [SHARPS].Perfiles p, [SHARPS].Funcionalidades f
WHERE p.Descripcion = 'Administrador'

INSERT INTO [SHARPS].Perfiles_Funcionalidades (Perfil , Funcionalidad)
SELECT p.perfilID, f.Codigo FROM [SHARPS].Perfiles p, [SHARPS].Funcionalidades f
WHERE p.Descripcion = 'Afiliado' AND f.Descripcion = 'AdministrarTurnos'

INSERT INTO [SHARPS].Perfiles_Funcionalidades (Perfil , Funcionalidad)
SELECT p.perfilID, f.Codigo FROM [SHARPS].Perfiles p, [SHARPS].Funcionalidades f
WHERE p.Descripcion = 'Afiliado' AND f.Descripcion = 'ComprarBonos'

INSERT INTO [SHARPS].Perfiles_Funcionalidades (Perfil , Funcionalidad)
SELECT p.perfilID, f.Codigo FROM [SHARPS].Perfiles p, [SHARPS].Funcionalidades f
WHERE p.Descripcion = 'Administrativo' AND f.Descripcion = 'ListarEstadisticas'

INSERT INTO [SHARPS].Perfiles_Funcionalidades (Perfil , Funcionalidad)
SELECT p.perfilID, f.Codigo FROM [SHARPS].Perfiles p, [SHARPS].Funcionalidades f
WHERE p.Descripcion = 'Administrativo' AND f.Descripcion = 'AdministrarAfiliados'

INSERT INTO [SHARPS].Perfiles_Funcionalidades (Perfil , Funcionalidad)
SELECT p.perfilID, f.Codigo FROM [SHARPS].Perfiles p, [SHARPS].Funcionalidades f
WHERE p.Descripcion = 'Administrativo' AND f.Descripcion = 'AbmEspecialidadesMedicas'

INSERT INTO [SHARPS].Perfiles_Funcionalidades (Perfil , Funcionalidad)
SELECT p.perfilID, f.Codigo FROM [SHARPS].Perfiles p, [SHARPS].Funcionalidades f
WHERE p.Descripcion = 'Administrativo' AND f.Descripcion = 'AbmPlanes'

INSERT INTO [SHARPS].Perfiles_Funcionalidades (Perfil , Funcionalidad)
SELECT p.perfilID, f.Codigo FROM [SHARPS].Perfiles p, [SHARPS].Funcionalidades f
WHERE p.Descripcion = 'Administrativo' AND f.Descripcion = 'AdministrarProfesionales'

INSERT INTO [SHARPS].Perfiles_Funcionalidades (Perfil , Funcionalidad)
SELECT p.perfilID, f.Codigo FROM [SHARPS].Perfiles p, [SHARPS].Funcionalidades f
WHERE p.Descripcion = 'Administrativo' AND f.Descripcion = 'AdministrarRoles'

INSERT INTO [SHARPS].Perfiles_Funcionalidades (Perfil , Funcionalidad)
SELECT p.perfilID, f.Codigo FROM [SHARPS].Perfiles p, [SHARPS].Funcionalidades f
WHERE p.Descripcion = 'Administrativo' AND f.Descripcion = 'RegistroLlegada'

INSERT INTO [SHARPS].Perfiles_Funcionalidades (Perfil , Funcionalidad)
SELECT p.perfilID, f.Codigo FROM [SHARPS].Perfiles p, [SHARPS].Funcionalidades f
WHERE p.Descripcion = 'Administrativo' AND f.Descripcion = 'RegistroUsuario'

INSERT INTO [SHARPS].Perfiles_Funcionalidades (Perfil , Funcionalidad)
SELECT p.perfilID, f.Codigo FROM [SHARPS].Perfiles p, [SHARPS].Funcionalidades f
WHERE p.Descripcion = 'Profesional' AND f.Descripcion = 'CancelarDia'


INSERT INTO [SHARPS].Perfiles_Funcionalidades (Perfil , Funcionalidad)
SELECT p.perfilID, f.Codigo FROM [SHARPS].Perfiles p, [SHARPS].Funcionalidades f
WHERE p.Descripcion = 'Profesional' AND f.Descripcion = 'GenerarRecetas'

INSERT INTO [SHARPS].Perfiles_Funcionalidades (Perfil , Funcionalidad)
SELECT p.perfilID, f.Codigo FROM [SHARPS].Perfiles p, [SHARPS].Funcionalidades f
WHERE p.Descripcion = 'Profesional' AND f.Descripcion = 'RegistrarAgenda'


INSERT INTO [SHARPS].Perfiles_Funcionalidades (Perfil , Funcionalidad)
SELECT p.perfilID, f.Codigo FROM [SHARPS].Perfiles p, [SHARPS].Funcionalidades f
WHERE p.Descripcion = 'Profesional' AND f.Descripcion = 'RegistroResultadoAtencion'

PRINT 'Agregando Roles' --Los roles por defecto tienen los mismos nombres que sus perfiles
INSERT INTO [SHARPS].Roles (Descripcion,Perfil) 
SELECT p.Descripcion, p.PerfilID FROM [SHARPS].Perfiles p

-- ROLES FUNC 
PRINT 'Asignando Funcionalidades a los Roles' --Los roles tienen todas las funcionalidades del perfil
INSERT INTO [SHARPS].Roles_Funcionalidades (Rol, Funcionalidad)
SELECT PF.Perfil AS ROL, PF.Funcionalidad AS FUNCIONALIDAD FROM [SHARPS].Perfiles_Funcionalidades PF


PRINT 'Generando Usuario Administrador...'
INSERT INTO [SHARPS].Usuarios (Activo,Intentos,Username,Password)
values (1,0,'Administrador','E6-B8-70-50-BF-CB-81-43-FC-B8-DB-01-70-A4-DC-9E-D0-0D-90-4D-DD-3E-2A-4A-D1-B1-E8-DC-0F-DC-9B-E7')


PRINT 'Ingresando Estados Civiles...'
INSERT INTO [SHARPS].Estados_Civiles (Descripcion) VALUES ('Soltero'); 
INSERT INTO [SHARPS].Estados_Civiles (Descripcion) VALUES ('Casado');
INSERT INTO [SHARPS].Estados_Civiles (Descripcion) VALUES ('Viudo');
INSERT INTO [SHARPS].Estados_Civiles (Descripcion) VALUES ('En Pareja');

PRINT 'Ingresando los Usuarios de Afiliados...'
INSERT INTO [SHARPS].Usuarios (Activo,Intentos,Username,Password)
SELECT DISTINCT 1,0,LTRIM(RTRIM(CAST(Paciente_DNI AS Nvarchar(MAX)))),'E6-B8-70-50-BF-CB-81-43-FC-B8-DB-01-70-A4-DC-9E-D0-0D-90-4D-DD-3E-2A-4A-D1-B1-E8-DC-0F-DC-9B-E7' 
FROM gd_esquema.Maestra 
WHERE Paciente_DNI is not null


PRINT 'Ingresando los Detalles Personales de Afiliados...'
INSERT INTO [SHARPS].Detalles_Persona(DNI,TipoDNI,Telefono,Direccion,Sexo,Mail,Apellido,Nombre,UsuarioID,FechaNac) 
SELECT distinct m.Paciente_DNI,'DNI',m.Paciente_Telefono,m.Paciente_Direccion,NULL, m.Paciente_Mail,m.Paciente_Apellido,m.Paciente_Nombre, u.UsuarioID, m.Paciente_Fecha_Nac 
FROM gd_esquema.Maestra m INNER JOIN [SHARPS].Usuarios u ON CAST(m.Paciente_DNI AS Nvarchar(MAX))=u.Username 

PRINT 'Ingresando las Entidades de Afiliados...'
DELETE FROM [SHARPS].Afiliados
INSERT INTO [SHARPS].Afiliados(GrupoFamiliar,PlanMedico,Activo, EstadoCivil,CantHijos,TipoAfiliado,UsuarioID)
SELECT DISTINCT (RANK() OVER (ORDER BY m.Paciente_DNI DESC)* 100), m.Plan_Med_Codigo,1, es.Codigo,0,01,u.UsuarioID  FROM [SHARPS].Usuarios u 
INNER JOIN gd_esquema.Maestra m ON u.Username = CAST(m.Paciente_DNI AS Nvarchar(MAX))
INNER JOIN [SHARPS].Estados_Civiles es ON es.Descripcion = 'Soltero'
GO

PRINT 'Ingresando los Usuarios de Profesionales...'
INSERT INTO [SHARPS].Usuarios (Activo,Intentos,Username,Password)
SELECT DISTINCT 1,0, LTRIM(RTRIM(CAST(m.Medico_DNI AS Nvarchar(MAX)))),'E6-B8-70-50-BF-CB-81-43-FC-B8-DB-01-70-A4-DC-9E-D0-0D-90-4D-DD-3E-2A-4A-D1-B1-E8-DC-0F-DC-9B-E7' 
FROM gd_esquema.Maestra m 
WHERE Medico_DNI is not null

PRINT 'Ingresando los Detalles Personales de Profesionales...'
INSERT INTO [SHARPS].Detalles_Persona(DNI,TipoDNI,Telefono,Direccion,Sexo,Mail,Apellido,Nombre,UsuarioID,FechaNac) 
SELECT distinct m.Medico_DNI,NULL,m.Medico_Telefono,m.Medico_Direccion,NULL,m.Medico_Mail,m.Medico_Apellido,m.Medico_Nombre, u.UsuarioID,m.Medico_Fecha_Nac FROM gd_esquema.Maestra m 
 INNER JOIN [SHARPS].Usuarios u ON CAST(m.Medico_DNI AS Nvarchar(MAX))=u.Username 
 --INNER JOIN [SHARPS].Detalles_Persona dp on dp.DNI < > m.Medico_DNI ------AUN NO PROBADO


PRINT 'Ingresando las Entidades de Profesionales...'

INSERT INTO [SHARPS].Profesionales (Matricula, UsuarioID , Activo)
SELECT DISTINCT (RANK() OVER (ORDER BY m.Medico_DNI DESC)+ 723), u.UsuarioID, 1 
FROM gd_esquema.Maestra m
INNER JOIN [SHARPS].Usuarios u ON u.Username= CAST(m.Medico_DNI AS Nvarchar(MAX))





--Ingresando los Bonos
PRINT 'Ingresando los Tipos de Bonos'
INSERT INTO [SHARPS].Tipos_Bonos (Descripcion) VALUES ('Consulta'); ---- correspode al 1 de Tipos
INSERT INTO [SHARPS].Tipos_Bonos (Descripcion) VALUES ('Farmacia'); ---corresponde al 2 de Tipos

PRINT 'Ingresando los Bonos Consulta'
GO
INSERT INTO [SHARPS].Bonos(NumeroDeBono,Fecha_Impresion,Afiliado_Compro,Tipo_Bono,PlanMedico)
SELECT distinct m.Bono_Consulta_Numero , m.Bono_Consulta_Fecha_Impresion,a.UsuarioID ,1, m.Plan_Med_Codigo  
  FROM gd_esquema.Maestra m
  INNER JOIN [SHARPS].Usuarios a on CAST(m.Paciente_DNI AS Nvarchar(MAX))= a.Username
  WHERE m.Turno_Fecha is NULL AND m.Bono_Consulta_Numero is not null  
GO
PRINT 'Ingresando los Bonos Farmacia'
INSERT INTO [SHARPS].Bonos(NumeroDeBono,Fecha_Impresion,Afiliado_Compro,Tipo_Bono,PlanMedico)
SELECT distinct m.Bono_Farmacia_Numero , m.Bono_Farmacia_Fecha_Impresion, a.UsuarioID,2, m.Plan_Med_Codigo  
  FROM gd_esquema.Maestra m
  INNER JOIN [SHARPS].Usuarios a on CAST(m.Paciente_DNI AS Nvarchar(MAX))= a.Username
  WHERE m.Turno_Fecha is NULL AND m.Bono_Farmacia_Numero is not null   
GO

--Rellenando Agendas
PRINT 'Rellenando Agendas...'
INSERT INTO [SHARPS].Agendas(Profesional,Horario)
SELECT distinct x.UsuarioID , m.Turno_Fecha
FROM gd_esquema.Maestra m
INNER JOIN [SHARPS].Usuarios x on x.Username =CAST(m.Medico_DNI AS Nvarchar(MAX))
WHERE m.Turno_Fecha is not null
order by 1


--Ingresando Turnos
PRINT 'Ingresando los Turnos...'
GO
INSERT INTO [SHARPS].Turnos (Numero , Afiliado , Agenda)
SELECT distinct m.Turno_Numero , U.UsuarioID , a.AgendaID 
FROM gd_esquema.Maestra m
INNER JOIN [SHARPS].Agendas a ON a.Horario = m.Turno_Fecha
INNER JOIN [SHARPS].Usuarios x ON x.UsuarioID = a.Profesional
INNER JOIN [SHARPS].Usuarios U on U.Username = CAST(m.Paciente_Dni AS Nvarchar(MAX))
WHERE m.Turno_Fecha is not null and CAST(m.Medico_DNI AS Nvarchar(MAX)) = x.Username
ORDER by 1



/*--Ingresando Turnos
DELETE FROM [SHARPS].TURNOS
PRINT 'Ingresando los Turnos...'
GO
INSERT INTO [SHARPS].Turnos (Numero,Profesional,Afiliado,Agenda,FechaHoraLlegada)
SELECT distinct m.Turno_Numero , x.UsuarioID , u.UsuarioID, m.Turno_Fecha, null -- ver como descontar 15 minutos
FROM gd_esquema.Maestra m
INNER JOIN [SHARPS].Usuarios u ON u.Username=CAST(m.Paciente_DNI AS Nvarchar(MAX))
INNER JOIN [SHARPS].Usuarios x on x.Username =CAST(m.Medico_DNI AS Nvarchar(MAX))

WHERE m.Turno_Fecha is not null
order by 1

--Rellenando Agendas
PRINT 'Rellenando Agendas...'
INSERT INTO [SHARPS].Agendas(Profesional,Horario)
SELECT t.Profesional,t.Agenda
FROM [SHARPS].Turnos t
*/

PRINT 'Rellenando Consultas...'
INSERT INTO [SHARPS].Consultas(Turno,Bono,Sintomas,Enfermedad,Numero_Consulta)
SELECT  distinct m.Turno_Numero , m.Bono_Consulta_Numero,m.Consulta_Sintomas,m.Consulta_Enfermedades
FROM gd_esquema.Maestra m 
INNER JOIN [SHARPS].Turnos t ON t.Numero = m.Turno_Numero
INNER JOIN [SHARPS].Bonos b ON m.Bono_Consulta_Numero = b.NumeroDeBono   
GO  


--Ingresando Planes
PRINT 'Ingresando los Planes...'
GO
INSERT INTO [SHARPS].Planes_Medicos (Codigo,Descripcion,Precio_Bono_Consulta,Precio_Bono_Farmacia)
SELECT distinct m.Plan_Med_Codigo, m.Plan_Med_Descripcion, m.Plan_Med_Precio_Bono_Consulta , m.Plan_Med_Precio_Bono_Farmacia
FROM gd_esquema.Maestra m
GO


--Ingresando Profesionales Esp

PRINT 'Ingresando Tipos de Especialidades...'
GO
INSERT INTO [SHARPS].Tipos_Especialidades (Codigo , Descripcion)
SELECT distinct m.Tipo_Especialidad_Codigo , m.Tipo_Especialidad_Descripcion
FROM gd_esquema.Maestra m
WHERE m.Tipo_Especialidad_Codigo is not null
GO

PRINT 'Ingresando Especialidades...'
GO
INSERT INTO [SHARPS].Especialidades(Codigo , Descripcion , Tipo)
SELECT distinct m.Especialidad_Codigo , m.Especialidad_Descripcion, m.Tipo_Especialidad_Codigo
FROM gd_esquema.Maestra m
WHERE m.Tipo_Especialidad_Codigo is not null 
GO

PRINT 'Ingresando Relacion Profesionales-Especialidades...'
GO
INSERT INTO [SHARPS].Profesionales_Especialidades(Profesional, Especialidad)
SELECT distinct a.Matricula , m.Especialidad_Codigo
FROM gd_esquema.Maestra m
INNER JOIN [SHARPS].Usuarios u on u.Username = CAST(m.Medico_DNI AS Nvarchar(MAX))
INNER JOIN [SHARPS].Profesionales a on u.UsuarioID = a.UsuarioID
GO



--Ingresando Recetas
PRINT 'Ingresando las Recetas...'
GO
INSERT INTO [SHARPS].Recetas (BonoConsulta, BonoFarmacia)
SELECT  m.Bono_Farmacia_Numero , m.Bono_Consulta_Numero
FROM gd_esquema.Maestra m
WHERE ( m.Bono_Farmacia_Numero is not null AND m.Bono_Consulta_Numero is not null )
GO

--INGRESANDO MEDICAMENTOS
print 'Ingresando Medicamentos'
GO
INSERT INTO [SHARPS].Medicamentos (Descripcion)
SELECT distinct m.Bono_Farmacia_Medicamento
FROM gd_esquema.Maestra m 
GO

--Ingresando Recetas_Medicamentos
PRINT 'Ingresando la relacion Recetas_Medicamentos...'
GO
INSERT INTO [SHARPS]. Recetas_Medicamentos (Receta , Medicamento)
SELECT  m.Bono_Farmacia_Numero , me.Codigo
FROM gd_esquema.Maestra m
INNER JOIN [SHARPS].Medicamentos me on me.Descripcion = m.Bono_Farmacia_Medicamento 
GO

-----MIGRANDO ROLES


PRINT 'Ingresando Relacion Usuarios-Roles...'
PRINT 'Profesionales...'
INSERT INTO [SHARPS].Usuarios_Roles(Usuario , Rol) --- Lo hago 2 veces ya que uno puede ser para paciente y otro Medico pero ambos tienen el mismo Usuario(DNI)  y se le aignan 2 roles
SELECT distinct CAST(m.UsuarioID AS Nvarchar(MAX))  , 2    
FROM [SHARPS].Profesionales m 

PRINT 'Afiliados...'
INSERT INTO [SHARPS].Usuarios_Roles(Usuario , Rol) 
SELECT distinct CAST( a.UsuarioID AS Nvarchar(MAX)),1      
FROM [SHARPS].Afiliados a


PRINT 'Administrador...'
INSERT INTO [SHARPS].Usuarios_Roles (Rol,Usuario)
SELECT R.RolID, U.UsuarioID
FROM [SHARPS].Roles R, [SHARPS].Usuarios U
WHERE R.Descripcion = 'Administrador'
AND U.Username = 'Administrador'

PRINT 'Proceso finalizado con éxito!'
GO