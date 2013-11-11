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
	CantConsultas [int],  
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
	Activo [bit],
CONSTRAINT [PK_Agendas] PRIMARY KEY CLUSTERED 
(
	[AgendaID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE [SHARPS].Bonos_Farmacia ( 
	NumeroDeBono [int]  NOT NULL,
	Fecha_Impresion datetime,
	Afiliado_Compro [int],
	PlanMedico [int],
CONSTRAINT [PK_Bonos_Farmacia] PRIMARY KEY CLUSTERED 
(
	[NumeroDeBono] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;


CREATE TABLE [SHARPS].Bonos_Consulta ( 
	NumeroDeBono [int]  NOT NULL,
	Fecha_Impresion datetime,
	Afiliado_Compro [int],
	PlanMedico [int],
CONSTRAINT [PK_Bonos_Consulta] PRIMARY KEY CLUSTERED 
(
	[NumeroDeBono] ASC
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

CREATE TABLE [SHARPS].Consultas ( --Numero_Consulta es la cantidad de veces que el paciente se atendio
	Turno [int],
	Bono [int],
	Sintomas nvarchar(MAX),
	Enfermedad nvarchar(MAX),
	Numero_Consulta [int],
CONSTRAINT [PK_Consultas] PRIMARY KEY CLUSTERED 
(
	[Numero_Consulta] ASC
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

CREATE TABLE [SHARPS].Especialidades ( 
	Codigo [int] NOT NULL,
	Descripcion nvarchar(MAX),
	Tipo [int],
	Activo [bit],
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
	Estado [int] NOT NULL,
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
	[UsuarioID] ASC
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
	Activo [bit],
CONSTRAINT [PK_Planes_Medicos] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE [SHARPS].Recetas ( 
	BonoConsulta [int],
	BonoFarmacia [int],
	RecetaID [int] identity(1,1),
CONSTRAINT [PK_Recetas] PRIMARY KEY CLUSTERED 
(
	[BonoFarmacia] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE [SHARPS].Recetas_Medicamentos ( 
	Receta [int],
	Medicamento [int]
) 
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


CREATE TABLE [SHARPS].Tipos_Especialidades ( 
	Codigo [int] NOT NULL,
	Descripcion nvarchar(MAX),
CONSTRAINT [PK_Tipos_Especialidades] PRIMARY KEY CLUSTERED 
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
	Agenda [int],
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
	Pass nvarchar(MAX) NOT NULL,
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

ALTER TABLE [SHARPS].[Afiliados] ADD  CONSTRAINT [DF_Afiliados_Activo]  DEFAULT ((1)) FOR [Activo]
GO

ALTER TABLE [SHARPS].[Afiliados] ADD CONSTRAINT [DF_Afiliados_CantConsultas] DEFAULT ((0)) FOR [CantConsultas]
GO

ALTER TABLE [SHARPS].[Afiliados]  WITH CHECK ADD  CONSTRAINT [CK_Afiliados_CantHijos] CHECK  (([CantHijos]>=(0)))
GO
ALTER TABLE [SHARPS].[Afiliados] CHECK CONSTRAINT [CK_Afiliados_CantHijos]
GO

ALTER TABLE [SHARPS].[Agendas] ADD  CONSTRAINT [DF_Agendas_Activo]  DEFAULT ((1)) FOR [Activo]
GO

ALTER TABLE [SHARPS].[Detalles_Persona] ADD  CONSTRAINT [DF_Detalles_Persona_Sexo]  DEFAULT (('M')) FOR [Sexo]
GO

ALTER TABLE [SHARPS].[Especialidades] ADD  CONSTRAINT [DF_Especialidades_Activo]  DEFAULT ((1)) FOR [Activo]
GO

ALTER TABLE [SHARPS].[Profesionales] ADD  CONSTRAINT [DF_Profesionales_Activo]  DEFAULT ((1)) FOR [Activo]
GO

ALTER TABLE [SHARPS].[Planes_Medicos] ADD  CONSTRAINT [DF_PlanesMedicos_Activo]  DEFAULT ((1)) FOR [Activo]
GO

ALTER TABLE [SHARPS].[Planes_Medicos]  WITH CHECK ADD  CONSTRAINT [CK_Planes_Medicos_Precio_Bono_Consulta] CHECK  (([Precio_Bono_Consulta]>=(0)))
GO
ALTER TABLE [SHARPS].[Planes_Medicos] CHECK CONSTRAINT [CK_Planes_Medicos_Precio_Bono_Consulta]
GO

ALTER TABLE [SHARPS].[Planes_Medicos]  WITH CHECK ADD  CONSTRAINT [CK_Planes_Medicos_Precio_Bono_Farmacia] CHECK  (([Precio_Bono_Farmacia]>=(0)))
GO
ALTER TABLE [SHARPS].[Planes_Medicos] CHECK CONSTRAINT [CK_Planes_Medicos_Precio_Bono_Farmacia]
GO

ALTER TABLE [SHARPS].[Roles] ADD  CONSTRAINT [DF_Roles_Activo]  DEFAULT ((1)) FOR [Activo]
GO

ALTER TABLE [SHARPS].[Usuarios] ADD  CONSTRAINT [DF_Usuarios_Intentos]  DEFAULT ((0)) FOR [Intentos]
GO

ALTER TABLE [SHARPS].[Usuarios] ADD  CONSTRAINT [DF_Usuarios_Activo]  DEFAULT ((1)) FOR [Activo]
GO

ALTER TABLE [SHARPS].[Recetas_Medicamentos]  WITH CHECK ADD  CONSTRAINT [FK_Recetas_Medicamentos_Recetas] FOREIGN KEY([Receta])
REFERENCES [SHARPS].[Recetas] ([BonoFarmacia])
GO
ALTER TABLE [SHARPS].[Recetas_Medicamentos] CHECK CONSTRAINT [FK_Recetas_Medicamentos_Recetas]
GO

ALTER TABLE [SHARPS].[Recetas_Medicamentos]  WITH CHECK ADD  CONSTRAINT [FK_Recetas_Medicamentos_Medicamentos] FOREIGN KEY([Medicamento])
REFERENCES [SHARPS].[Medicamentos] ([Codigo])
GO
ALTER TABLE [SHARPS].[Recetas_Medicamentos] CHECK CONSTRAINT [FK_Recetas_Medicamentos_Medicamentos]
GO

ALTER TABLE [SHARPS].[Consultas]  WITH CHECK ADD  CONSTRAINT [FK_Consultas_Turnos] FOREIGN KEY([Turno])
REFERENCES [SHARPS].[Turnos] ([Numero])
GO
ALTER TABLE [SHARPS].[Consultas] CHECK CONSTRAINT [FK_Consultas_Turnos]
GO

ALTER TABLE [SHARPS].[Turnos]  WITH CHECK ADD  CONSTRAINT [FK_Turnos_Estados_Turno] FOREIGN KEY([Estado])
REFERENCES [SHARPS].[Estados_Turno] ([Estado])
GO
ALTER TABLE [SHARPS].[Turnos] CHECK CONSTRAINT [FK_Turnos_Estados_Turno]
GO

ALTER TABLE [SHARPS].[Consultas]  WITH CHECK ADD  CONSTRAINT [FK_Consultas_Bonos_Consulta] FOREIGN KEY([Bono])
REFERENCES [SHARPS].[Bonos_Consulta] ([NumeroDeBono])
GO
ALTER TABLE [SHARPS].[Consultas] CHECK CONSTRAINT [FK_Consultas_Bonos_Consulta]
GO


ALTER TABLE [SHARPS].[Recetas]  WITH CHECK ADD  CONSTRAINT [FK_Recetas_Bonos_Farmacia] FOREIGN KEY([BonoFarmacia])
REFERENCES [SHARPS].[Bonos_Farmacia] ([NumeroDeBono])
GO
ALTER TABLE [SHARPS].[Recetas] CHECK CONSTRAINT [FK_Recetas_Bonos_Farmacia]
GO

ALTER TABLE [SHARPS].[Afiliados]  WITH CHECK ADD  CONSTRAINT [FK_Afiliados_Planes_Medicos] FOREIGN KEY([PlanMedico])
REFERENCES [SHARPS].[Planes_Medicos] ([Codigo])
GO
ALTER TABLE [SHARPS].[Afiliados] CHECK CONSTRAINT [FK_Afiliados_Planes_Medicos]
GO

ALTER TABLE [SHARPS].[Cambios_Afiliado]  WITH CHECK ADD  CONSTRAINT [FK_Cambios_Afiliado_Afiliados] FOREIGN KEY([Afiliado])
REFERENCES [SHARPS].[Afiliados] ([UsuarioID])
GO
ALTER TABLE [SHARPS].[Cambios_Afiliado] CHECK CONSTRAINT [FK_Cambios_Afiliado_Afiliados]
GO

ALTER TABLE [SHARPS].[Afiliados]  WITH CHECK ADD  CONSTRAINT [FK_Afiliados_Estados_Civiles] FOREIGN KEY([EstadoCivil])
REFERENCES [SHARPS].[Estados_Civiles] ([Codigo])
GO
ALTER TABLE [SHARPS].[Afiliados] CHECK CONSTRAINT [FK_Afiliados_Estados_Civiles]
GO

ALTER TABLE [SHARPS].[Bonos_Consulta]  WITH CHECK ADD  CONSTRAINT [FK_Bonos_Consulta_Afiliados] FOREIGN KEY([Afiliado_Compro])
REFERENCES [SHARPS].[Afiliados] ([UsuarioID])
GO
ALTER TABLE [SHARPS].[Bonos_Consulta] CHECK CONSTRAINT [FK_Bonos_Consulta_Afiliados]
GO

ALTER TABLE [SHARPS].[Bonos_Farmacia]  WITH CHECK ADD  CONSTRAINT [FK_Bonos_Farmacia_Afiliados] FOREIGN KEY([Afiliado_Compro])
REFERENCES [SHARPS].[Afiliados] ([UsuarioID])
GO
ALTER TABLE [SHARPS].[Bonos_Farmacia] CHECK CONSTRAINT [FK_Bonos_Farmacia_Afiliados]
GO

ALTER TABLE [SHARPS].[Turnos]  WITH CHECK ADD  CONSTRAINT [FK_Turnos_Afiliados] FOREIGN KEY([Afiliado])
REFERENCES [SHARPS].[Afiliados] ([UsuarioID])
GO
ALTER TABLE [SHARPS].[Turnos] CHECK CONSTRAINT [FK_Turnos_Afiliados]
GO

ALTER TABLE [SHARPS].[Agendas]  WITH CHECK ADD  CONSTRAINT [FK_Agendas_Profesionales] FOREIGN KEY([Profesional])
REFERENCES [SHARPS].[Profesionales] ([UsuarioID])
GO
ALTER TABLE [SHARPS].[Agendas] CHECK CONSTRAINT [FK_Agendas_Profesionales]
GO

ALTER TABLE [SHARPS].[Turnos]  WITH CHECK ADD  CONSTRAINT [FK_Turnos_Agendas] FOREIGN KEY([Agenda])
REFERENCES [SHARPS].[Agendas] ([AgendaID])
GO
ALTER TABLE [SHARPS].[Turnos] CHECK CONSTRAINT [FK_Turnos_Agendas]
GO

ALTER TABLE [SHARPS].[Profesionales_Especialidades]  WITH CHECK ADD  CONSTRAINT [FK_Profesionales_Especialidades_Profesionales] FOREIGN KEY([Profesional])
REFERENCES [SHARPS].[Profesionales] ([UsuarioID])
GO
ALTER TABLE [SHARPS].[Profesionales_Especialidades] CHECK CONSTRAINT [FK_Profesionales_Especialidades_Profesionales]
GO

ALTER TABLE [SHARPS].[Especialidades]  WITH CHECK ADD  CONSTRAINT [FK_Especialidades_Tipos_Especialidades] FOREIGN KEY([Tipo])
REFERENCES [SHARPS].[Tipos_Especialidades] ([Codigo])
GO
ALTER TABLE [SHARPS].[Especialidades] CHECK CONSTRAINT [FK_Especialidades_Tipos_Especialidades]
GO

ALTER TABLE [SHARPS].[Profesionales_Especialidades]  WITH CHECK ADD  CONSTRAINT [FK_Profesionales_Especialidades_Especialidades] FOREIGN KEY([Especialidad])
REFERENCES [SHARPS].[Especialidades] ([Codigo])
GO
ALTER TABLE [SHARPS].[Profesionales_Especialidades] CHECK CONSTRAINT [FK_Profesionales_Especialidades_Especialidades]
GO

ALTER TABLE [SHARPS].[Detalles_Persona]  WITH CHECK ADD  CONSTRAINT [FK_Detalles_Persona_Usuarios] FOREIGN KEY([UsuarioID])
REFERENCES [SHARPS].[Usuarios] ([UsuarioID])
GO
ALTER TABLE [SHARPS].[Detalles_Persona] CHECK CONSTRAINT [FK_Detalles_Persona_Usuarios]
GO

ALTER TABLE [SHARPS].[Afiliados]  WITH CHECK ADD  CONSTRAINT [FK_Afiliados_Usuarios] FOREIGN KEY([UsuarioID])
REFERENCES [SHARPS].[Usuarios] ([UsuarioID])
GO
ALTER TABLE [SHARPS].[Afiliados] CHECK CONSTRAINT [FK_Afiliados_Usuarios]
GO

ALTER TABLE [SHARPS].[Profesionales]  WITH CHECK ADD  CONSTRAINT [FK_Profesionales_Usuarios] FOREIGN KEY([UsuarioID])
REFERENCES [SHARPS].[Usuarios] ([UsuarioID])
GO
ALTER TABLE [SHARPS].[Profesionales] CHECK CONSTRAINT [FK_Profesionales_Usuarios]
GO

ALTER TABLE [SHARPS].[Usuarios_Roles]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Roles_Usuarios] FOREIGN KEY([Usuario])
REFERENCES [SHARPS].[Usuarios] ([UsuarioID])
GO
ALTER TABLE [SHARPS].[Usuarios_Roles]  CHECK CONSTRAINT [FK_Usuarios_Roles_Usuarios]
GO

ALTER TABLE [SHARPS].[Usuarios_Roles]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Roles_Roles] FOREIGN KEY([Rol])
REFERENCES [SHARPS].[Roles] ([RolID])
GO
ALTER TABLE [SHARPS].[Usuarios_Roles] CHECK CONSTRAINT [FK_Usuarios_Roles_Roles]
GO

ALTER TABLE [SHARPS].[Roles_Funcionalidades]  WITH CHECK ADD  CONSTRAINT [FK_Roles_Funcionalidades_Roles] FOREIGN KEY([Rol])
REFERENCES [SHARPS].[Roles] ([RolID])
GO
ALTER TABLE [SHARPS].[Roles_Funcionalidades] CHECK CONSTRAINT [FK_Roles_Funcionalidades_Roles]
GO

ALTER TABLE [SHARPS].[Roles_Funcionalidades]  WITH CHECK ADD  CONSTRAINT [FK_Roles_Funcionalidades_Funcionalidades] FOREIGN KEY([Funcionalidad])
REFERENCES [SHARPS].[Funcionalidades] ([Codigo])
GO
ALTER TABLE [SHARPS].[Roles_Funcionalidades] CHECK CONSTRAINT [FK_Roles_Funcionalidades_Funcionalidades]
GO

ALTER TABLE [SHARPS].[Perfiles_Funcionalidades]  WITH CHECK ADD  CONSTRAINT [FK_Perfiles_Funcionalidades_Funcionalidades] FOREIGN KEY([Funcionalidad])
REFERENCES [SHARPS].[Funcionalidades] ([Codigo])
GO
ALTER TABLE [SHARPS].[Perfiles_Funcionalidades] CHECK CONSTRAINT [FK_Perfiles_Funcionalidades_Funcionalidades]
GO

ALTER TABLE [SHARPS].[Roles]  WITH CHECK ADD  CONSTRAINT [FK_Roles_Perfiles] FOREIGN KEY([Perfil])
REFERENCES [SHARPS].[Perfiles] ([PerfilID])
GO
ALTER TABLE [SHARPS].[Roles] CHECK CONSTRAINT [FK_Roles_Perfiles]
GO

ALTER TABLE [SHARPS].[Perfiles_Funcionalidades]  WITH CHECK ADD  CONSTRAINT [FK_Perfiles_Funcionalidades_Perfiles] FOREIGN KEY([Perfil])
REFERENCES [SHARPS].[Perfiles] ([PerfilID])
GO
ALTER TABLE [SHARPS].[Perfiles_Funcionalidades] CHECK CONSTRAINT [FK_Perfiles_Funcionalidades_Perfiles]
GO





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
INSERT INTO [SHARPS].Usuarios (Activo,Intentos,Username,Pass)
values (1,0,'Administrador','E6-B8-70-50-BF-CB-81-43-FC-B8-DB-01-70-A4-DC-9E-D0-0D-90-4D-DD-3E-2A-4A-D1-B1-E8-DC-0F-DC-9B-E7')


PRINT 'Ingresando Estados Civiles...'
INSERT INTO [SHARPS].Estados_Civiles (Descripcion) VALUES ('Soltero'); 
INSERT INTO [SHARPS].Estados_Civiles (Descripcion) VALUES ('Casado');
INSERT INTO [SHARPS].Estados_Civiles (Descripcion) VALUES ('Viudo');
INSERT INTO [SHARPS].Estados_Civiles (Descripcion) VALUES ('En Pareja');

PRINT 'Ingresando Estados de un Turno...'
INSERT INTO [SHARPS].Estados_Turno (Estado) VALUES ('Atendido'); 
INSERT INTO [SHARPS].Estados_Turno (Estado) VALUES ('Cancelado');
INSERT INTO [SHARPS].Estados_Turno (Estado) VALUES ('Activo');---todavia no es el dia del turno


PRINT 'Ingresando los Usuarios de Afiliados...'
INSERT INTO [SHARPS].Usuarios (Activo,Intentos,Username,Pass)
SELECT DISTINCT 1,0,LTRIM(RTRIM(CAST(Paciente_DNI AS Nvarchar(MAX)))),'E6-B8-70-50-BF-CB-81-43-FC-B8-DB-01-70-A4-DC-9E-D0-0D-90-4D-DD-3E-2A-4A-D1-B1-E8-DC-0F-DC-9B-E7' 
FROM gd_esquema.Maestra 
WHERE Paciente_DNI is not null


PRINT 'Ingresando los Detalles Personales de Afiliados...'
INSERT INTO [SHARPS].Detalles_Persona(DNI,TipoDNI,Telefono,Direccion,Sexo,Mail,Apellido,Nombre,UsuarioID,FechaNac) 
SELECT distinct m.Paciente_DNI,'DNI',m.Paciente_Telefono,m.Paciente_Direccion,'M', m.Paciente_Mail,m.Paciente_Apellido,m.Paciente_Nombre, u.UsuarioID, m.Paciente_Fecha_Nac 
FROM gd_esquema.Maestra m INNER JOIN [SHARPS].Usuarios u ON CAST(m.Paciente_DNI AS Nvarchar(MAX))=u.Username 

PRINT 'Ingresando las Entidades de Afiliados...'
DELETE FROM [SHARPS].Afiliados
INSERT INTO [SHARPS].Afiliados(GrupoFamiliar,PlanMedico,Activo, EstadoCivil,CantHijos,TipoAfiliado,UsuarioID, CantConsultas)
SELECT DISTINCT (RANK() OVER (ORDER BY m.Paciente_DNI DESC)* 100), m.Plan_Med_Codigo,1, es.Codigo,0,01,u.UsuarioID, NULL  
FROM [SHARPS].Usuarios u 
INNER JOIN gd_esquema.Maestra m ON u.Username = CAST(m.Paciente_DNI AS Nvarchar(MAX))
INNER JOIN [SHARPS].Estados_Civiles es ON es.Descripcion = 'Soltero'
INNER JOIN [SHARPS].Afiliados af ON af.Activo = 0
GO

PRINT 'Ingresando los Usuarios de Profesionales...'
INSERT INTO [SHARPS].Usuarios (Activo,Intentos,Username,Pass)
SELECT DISTINCT 1,0, LTRIM(RTRIM(CAST(m.Medico_DNI AS Nvarchar(MAX)))),'E6-B8-70-50-BF-CB-81-43-FC-B8-DB-01-70-A4-DC-9E-D0-0D-90-4D-DD-3E-2A-4A-D1-B1-E8-DC-0F-DC-9B-E7' 
FROM gd_esquema.Maestra m 
WHERE Medico_DNI is not null

PRINT 'Ingresando los Detalles Personales de Profesionales...'
INSERT INTO [SHARPS].Detalles_Persona(DNI,TipoDNI,Telefono,Direccion,Sexo,Mail,Apellido,Nombre,UsuarioID,FechaNac) 
SELECT distinct m.Medico_DNI,'DNI',m.Medico_Telefono,m.Medico_Direccion,'M',m.Medico_Mail,m.Medico_Apellido,m.Medico_Nombre, u.UsuarioID,m.Medico_Fecha_Nac FROM gd_esquema.Maestra m 
INNER JOIN [SHARPS].Usuarios u ON CAST(m.Medico_DNI AS Nvarchar(MAX))=u.Username 


PRINT 'Ingresando las Entidades de Profesionales...'

INSERT INTO [SHARPS].Profesionales (Matricula, UsuarioID , Activo)
SELECT DISTINCT NULL, u.UsuarioID, 1 
FROM gd_esquema.Maestra m
INNER JOIN [SHARPS].Usuarios u ON u.Username= CAST(m.Medico_DNI AS Nvarchar(MAX))
INNER JOIN [SHARPS].Profesionales p ON p.Activo = 0

PRINT 'Ingresando los Bonos Consulta'
GO
INSERT INTO [SHARPS].Bonos_Consulta(NumeroDeBono,Fecha_Impresion,Afiliado_Compro,PlanMedico)
SELECT distinct m.Bono_Consulta_Numero , m.Bono_Consulta_Fecha_Impresion,a.UsuarioID , m.Plan_Med_Codigo  
  FROM gd_esquema.Maestra m
  INNER JOIN [SHARPS].Usuarios a on CAST(m.Paciente_DNI AS Nvarchar(MAX))= a.UsuarioID
  WHERE m.Turno_Fecha is NULL AND m.Bono_Consulta_Numero is not null  
GO
PRINT 'Ingresando los Bonos Farmacia'
INSERT INTO [SHARPS].Bonos_Farmacia(NumeroDeBono,Fecha_Impresion,Afiliado_Compro,PlanMedico)
SELECT distinct m.Bono_Farmacia_Numero , m.Bono_Farmacia_Fecha_Impresion, a.UsuarioID, m.Plan_Med_Codigo  
  FROM gd_esquema.Maestra m
  INNER JOIN [SHARPS].Usuarios a on CAST(m.Paciente_DNI AS Nvarchar(MAX))= a.UsuarioID
  WHERE m.Turno_Fecha is NULL AND m.Bono_Farmacia_Numero is not null   
GO

--Rellenando Agendas
PRINT 'Rellenando Agendas...'
INSERT INTO [SHARPS].Agendas(Profesional,Horario)
SELECT distinct x.UsuarioID , m.Turno_Fecha
FROM gd_esquema.Maestra m
INNER JOIN [SHARPS].Usuarios x on x.UsuarioID =CAST(m.Medico_DNI AS Nvarchar(MAX))
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

--Rellenando Consultas
PRINT 'Rellenando Consultas...'
INSERT INTO [SHARPS].Consultas(Turno,Bono,Sintomas,Enfermedad,Numero_Consulta)
SELECT  distinct m.Turno_Numero , m.Bono_Consulta_Numero,m.Consulta_Sintomas,m.Consulta_Enfermedades, af.CantConsultas
FROM gd_esquema.Maestra m, [SHARPS].Afiliados af
INNER JOIN [SHARPS].Turnos t ON t.Numero = m.Turno_Numero
INNER JOIN [SHARPS].Bonos_Consulta b ON m.Bono_Consulta_Numero = b.NumeroDeBono 
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
SELECT distinct a.UsuarioID , m.Especialidad_Codigo
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