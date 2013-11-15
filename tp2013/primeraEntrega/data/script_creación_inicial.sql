USE [GD2C2013]

GO
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = 'SHARPS')
DROP SCHEMA [SHARPS]
GO
CREATE SCHEMA [SHARPS] AUTHORIZATION [gd]
GO



CREATE TABLE [SHARPS].Afiliados ( 
	GrupoFamiliar [int] NOT NULL,
	Plan_Medico numeric(18,0),
	Activo [bit],
	Estado_Civil [int],
	CantHijos [int],
	UsuarioID [int],
	TipoAfiliado [int],  
	CantConsultas [int],  
	Faltan_Datos [bit] default 0 ,
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
	Numero numeric(18,0)  NOT NULL,
	Fecha_Impresion datetime,
	Afiliado_Compro [int],
	Precio_Pagado numeric (18,0),
CONSTRAINT [PK_Bonos_Farmacia] PRIMARY KEY CLUSTERED 
(
	[Numero] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;


CREATE TABLE [SHARPS].Bonos_Consulta ( 
	Numero numeric(18,0) NOT NULL,
	Fecha_Impresion datetime,
	Afiliado_Compro [int],
	Precio_Pagado numeric (18,0),
CONSTRAINT [PK_Bonos_Consulta] PRIMARY KEY CLUSTERED 
(
	[Numero] ASC
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
	Turno numeric(18,0),
	Bono_Consulta numeric(18,0),
	Sintomas nvarchar(MAX),
	Enfermedad nvarchar(MAX),
	Numero_Consulta [int],
CONSTRAINT [PK_Consultas] PRIMARY KEY CLUSTERED 
(
	[Bono_Consulta] ASC
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
CONSTRAINT [PK_Detalles_Persona] PRIMARY KEY CLUSTERED 
(
	UsuarioID
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
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
	EstadoID [int] IDENTITY(1,1) NOT NULL,
	Descripcion nvarchar(50),
CONSTRAINT [PK_Estados_Turno] PRIMARY KEY CLUSTERED 
(
	[EstadoID] ASC
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
	Faltan_Datos [bit] default 0,
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
	Codigo numeric(18,0) NOT NULL,
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
	Consulta numeric(18,0),
	Bono_Farmacia numeric(18,0),
	RecetaID [int] identity(1,1),
CONSTRAINT [PK_Recetas] PRIMARY KEY CLUSTERED 
(
	[Bono_Farmacia] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE [SHARPS].Recetas_Medicamentos ( 
	Receta numeric(18,0),
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
	Numero numeric(18,0) NOT NULL,
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

ALTER TABLE [SHARPS].[Afiliados] ADD  CONSTRAINT [DF_Afiliados_Activo]  DEFAULT ((1)) FOR [Activo]
GO

ALTER TABLE [SHARPS].[Afiliados] ADD CONSTRAINT [DF_Afiliados_CantConsultas] DEFAULT ((0)) FOR [CantConsultas]
GO

ALTER TABLE [SHARPS].[Afiliados]  WITH CHECK ADD  CONSTRAINT [CK_Afiliados_CantHijos] CHECK  (([CantHijos]>=(0)))
GO
ALTER TABLE [SHARPS].[Afiliados] CHECK CONSTRAINT [CK_Afiliados_CantHijos]
GO

ALTER TABLE [SHARPS].[Bonos_Consulta]  WITH CHECK ADD  CONSTRAINT [CK_Bonos_Consulta_Precio_Pagado] CHECK  (([Precio_Pagado]>=(0)))
GO
ALTER TABLE [SHARPS].[Bonos_Consulta] CHECK CONSTRAINT [CK_Bonos_Consulta_Precio_Pagado]
GO

ALTER TABLE [SHARPS].[Bonos_Farmacia]  WITH CHECK ADD  CONSTRAINT [CK_Bonos_Farmacia_Precio_Pagado] CHECK  (([Precio_Pagado]>=(0)))
GO
ALTER TABLE [SHARPS].[Bonos_Farmacia] CHECK CONSTRAINT [CK_Bonos_Farmacia_Precio_Pagado]
GO

ALTER TABLE [SHARPS].[Agendas] ADD  CONSTRAINT [DF_Agendas_Activo]  DEFAULT ((1)) FOR [Activo]
GO

ALTER TABLE [SHARPS].[Detalles_Persona] ADD  CONSTRAINT [DF_Detalles_Persona_Sexo]  DEFAULT (('Masculino')) FOR [Sexo]
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
REFERENCES [SHARPS].[Recetas] ([Bono_Farmacia])
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

ALTER TABLE [SHARPS].[Recetas]  WITH CHECK ADD  CONSTRAINT [FK_Recetas_Consultas] FOREIGN KEY([Consulta])
REFERENCES [SHARPS].[Consultas] ([Bono_Consulta])
GO
ALTER TABLE [SHARPS].[Recetas] CHECK CONSTRAINT [FK_Recetas_Consultas]
GO

ALTER TABLE [SHARPS].[Turnos]  WITH CHECK ADD  CONSTRAINT [FK_Turnos_Estados_Turno] FOREIGN KEY([Estado])
REFERENCES [SHARPS].[Estados_Turno] ([EstadoID])
GO
ALTER TABLE [SHARPS].[Turnos] CHECK CONSTRAINT [FK_Turnos_Estados_Turno]
GO

ALTER TABLE [SHARPS].[Consultas]  WITH CHECK ADD  CONSTRAINT [FK_Consultas_Bonos_Consulta] FOREIGN KEY([Bono_Consulta])
REFERENCES [SHARPS].[Bonos_Consulta] ([Numero])
GO
ALTER TABLE [SHARPS].[Consultas] CHECK CONSTRAINT [FK_Consultas_Bonos_Consulta]
GO


ALTER TABLE [SHARPS].[Recetas]  WITH CHECK ADD  CONSTRAINT [FK_Recetas_Bonos_Farmacia] FOREIGN KEY([Bono_Farmacia])
REFERENCES [SHARPS].[Bonos_Farmacia] ([Numero])
GO
ALTER TABLE [SHARPS].[Recetas] CHECK CONSTRAINT [FK_Recetas_Bonos_Farmacia]
GO

ALTER TABLE [SHARPS].[Afiliados]  WITH CHECK ADD  CONSTRAINT [FK_Afiliados_Planes_Medicos] FOREIGN KEY([Plan_Medico])
REFERENCES [SHARPS].[Planes_Medicos] ([Codigo])
GO
ALTER TABLE [SHARPS].[Afiliados] CHECK CONSTRAINT [FK_Afiliados_Planes_Medicos]
GO

ALTER TABLE [SHARPS].[Cambios_Afiliado]  WITH CHECK ADD  CONSTRAINT [FK_Cambios_Afiliado_Afiliados] FOREIGN KEY([Afiliado])
REFERENCES [SHARPS].[Afiliados] ([UsuarioID])
GO
ALTER TABLE [SHARPS].[Cambios_Afiliado] CHECK CONSTRAINT [FK_Cambios_Afiliado_Afiliados]
GO

ALTER TABLE [SHARPS].[Afiliados]  WITH CHECK ADD  CONSTRAINT [FK_Afiliados_Estados_Civiles] FOREIGN KEY([Estado_Civil])
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
PRINT 'Migrando los datos'

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
INSERT INTO [SHARPS].Estados_Civiles (Descripcion) VALUES ('Concubinato');
INSERT INTO [SHARPS].Estados_Civiles (Descripcion) VALUES ('Divorciado')

PRINT 'Ingresando Estados de un Turno...'
INSERT INTO [SHARPS].Estados_Turno (Descripcion) VALUES ('Atendido'); 
INSERT INTO [SHARPS].Estados_Turno (Descripcion) VALUES ('CanceladoAfiliado');
INSERT INTO [SHARPS].Estados_Turno (Descripcion) VALUES ('CanceladoAProfesional');
INSERT INTO [SHARPS].Estados_Turno (Descripcion) VALUES ('Activo');---todavia no es el dia del turno
INSERT INTO [SHARPS].Estados_Turno (Descripcion) VALUES ('Desactivo')


--Ingresando Planes
PRINT 'Ingresando los Planes...'
GO
INSERT INTO [SHARPS].Planes_Medicos (Codigo,Descripcion,Precio_Bono_Consulta,Precio_Bono_Farmacia)
SELECT distinct m.Plan_Med_Codigo, m.Plan_Med_Descripcion, m.Plan_Med_Precio_Bono_Consulta , m.Plan_Med_Precio_Bono_Farmacia
FROM gd_esquema.Maestra m
GO

PRINT 'Ingresando los Usuarios de Afiliados...'
INSERT INTO [SHARPS].Usuarios (Activo,Intentos,Username,Password)
SELECT DISTINCT 1,0,LTRIM(RTRIM(CAST(Paciente_DNI AS Nvarchar(MAX)))),'E6-B8-70-50-BF-CB-81-43-FC-B8-DB-01-70-A4-DC-9E-D0-0D-90-4D-DD-3E-2A-4A-D1-B1-E8-DC-0F-DC-9B-E7' 
FROM gd_esquema.Maestra 
WHERE Paciente_DNI is not null


PRINT 'Ingresando los Detalles Personales de Afiliados...'
INSERT INTO [SHARPS].Detalles_Persona(DNI,TipoDNI,Telefono,Direccion,Sexo,Mail,Apellido,Nombre,UsuarioID,FechaNac) 
SELECT distinct m.Paciente_DNI,'DNI',m.Paciente_Telefono,m.Paciente_Direccion,'Masculino', m.Paciente_Mail,m.Paciente_Apellido,m.Paciente_Nombre, u.UsuarioID, m.Paciente_Fecha_Nac 
FROM gd_esquema.Maestra m INNER JOIN [SHARPS].Usuarios u ON CAST(m.Paciente_DNI AS Nvarchar(MAX))=u.Username 

PRINT 'Ingresando las Entidades de Afiliados...'
INSERT INTO [SHARPS].Afiliados(GrupoFamiliar,Plan_Medico,Activo, Estado_Civil,CantHijos,TipoAfiliado,UsuarioID, CantConsultas , Faltan_Datos)
SELECT DISTINCT (RANK() OVER (ORDER BY m.Paciente_DNI DESC)* 100), m.Plan_Med_Codigo,1, es.Codigo,0,01,u.UsuarioID, 0  ,1
FROM [SHARPS].Usuarios u 
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
SELECT distinct m.Medico_DNI,'DNI',m.Medico_Telefono,m.Medico_Direccion,'Masculino',m.Medico_Mail,m.Medico_Apellido,m.Medico_Nombre, u.UsuarioID,m.Medico_Fecha_Nac FROM gd_esquema.Maestra m 
INNER JOIN [SHARPS].Usuarios u ON CAST(m.Medico_DNI AS Nvarchar(MAX))=u.Username 


PRINT 'Ingresando las Entidades de Profesionales...'

INSERT INTO [SHARPS].Profesionales (Matricula, UsuarioID , Activo , Faltan_Datos)
SELECT DISTINCT NULL, u.UsuarioID, 1 , 1
FROM gd_esquema.Maestra m
INNER JOIN [SHARPS].Usuarios u ON u.Username= CAST(m.Medico_DNI AS Nvarchar(MAX))


PRINT 'Ingresando los Bonos Consulta'
GO
INSERT INTO [SHARPS].Bonos_Consulta(Numero,Fecha_Impresion,Afiliado_Compro,Precio_Pagado)
SELECT distinct m.Bono_Consulta_Numero , m.Bono_Consulta_Fecha_Impresion,a.UsuarioID , m.Plan_Med_Precio_Bono_Consulta 
  FROM gd_esquema.Maestra m
  INNER JOIN [SHARPS].Usuarios a on CAST(m.Paciente_DNI AS Nvarchar(MAX))= a.Username
  WHERE m.Turno_Fecha is NULL AND m.Bono_Consulta_Numero is not null  
GO

PRINT 'Ingresando los Bonos Farmacia'
INSERT INTO [SHARPS].Bonos_Farmacia(Numero,Fecha_Impresion,Afiliado_Compro,Precio_Pagado)
SELECT distinct m.Bono_Farmacia_Numero , m.Bono_Farmacia_Fecha_Impresion, a.UsuarioID, m.Plan_Med_Precio_Bono_Farmacia
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

--Rellenando Consultas
PRINT 'Rellenando Consultas...'
INSERT INTO [SHARPS].Consultas(Turno,Bono_Consulta,Sintomas,Enfermedad,Numero_Consulta)
SELECT  distinct m.Turno_Numero , m.Bono_Consulta_Numero,m.Consulta_Sintomas,m.Consulta_Enfermedades,0
FROM gd_esquema.Maestra m
INNER JOIN [SHARPS].Turnos t ON t.Numero = m.Turno_Numero
INNER JOIN [SHARPS].Bonos_Consulta b ON m.Bono_Consulta_Numero = b.Numero 
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
INSERT INTO [SHARPS].Recetas (Bono_Farmacia, Consulta)
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

PRINT 'Migracion finalizada'
GO



-------------------

PRINT 'Cargando Procedimientos'

USE [GD2C2013]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SHARPS].[NuevoGrupoFamiliar] 
	@max int
AS
begin
	select @max  = @max + 1
end
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SHARPS].[UpdateRole]
	@Description nvarchar(100),
	@ID int
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE SHARPS.Roles SET Descripcion = @Description
	WHERE RolID = @ID
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SHARPS].[InsertRole]
	@Description nvarchar(100),
	@PerfilID int
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO SHARPS.Roles (Descripcion,Perfil) VALUES (@Description,@PerfilID)
	SELECT @@Identity AS ID
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SHARPS].[GetUserRoles] 
@userID int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT r.RolID as ID, r.Descripcion as Descripcion, r.Perfil as PerfilId, p.Descripcion as PerfilNombre
	FROM  [SHARPS].Roles r
	INNER JOIN [SHARPS].Usuarios_Roles ur ON ur.Rol = r.RolID
	INNER JOIN [SHARPS].Perfiles p on p.PerfilID = r.Perfil
	WHERE ur.usuario = @userID
	AND r.Activo = 1
	ORDER BY r.Descripcion

END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SHARPS].[GetUserLoginAttempts]
	@Nombre nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Intentos FROM  [SHARPS].Usuarios WHERE username = @Nombre
	IF(@@ROWCOUNT = 0)
		SELECT 0 AS Intentos
END
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SHARPS].[GetRolesByPerfil]
@Perfil nvarchar(max)
AS
BEGIN
	SELECT
		r.RolID,
		r.Descripcion
	FROM  [SHARPS].Roles r
	INNER JOIN [SHARPS].Perfiles p ON r.Perfil = p.PerfilID 
	WHERE r.Activo = 1
	AND p.Descripcion = @Perfil 
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SHARPS].[GetRoles]

AS
BEGIN
	SELECT
		r.RolID ID,
		r.Descripcion,
		r.Perfil as PerfilID,
		p.Descripcion as PerfilNombre
	FROM  [SHARPS].Roles r
	 JOIN [SHARPS].Perfiles p ON p.PerfilID = r.Perfil
	 WHERE r.Activo = 1
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SHARPS].[GetRoleFunctionalities]
	@Rol_ID int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT F.Descripcion FROM  [SHARPS].Funcionalidades F
	INNER JOIN [SHARPS].Roles_Funcionalidades RF ON F.Codigo = RF.Funcionalidad
	WHERE RF.Rol = @Rol_ID
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SHARPS].[GetPerfilInfo]
@NombrePerfil varchar(MAX)
AS
BEGIN
	SELECT
		p.PerfilID
	FROM  [SHARPS].Perfiles p
	WHERE p.Descripcion = @NombrePerfil
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SHARPS].[GetPerfilFunctionalities]
	@Perfil_ID int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT F.Descripcion FROM  [SHARPS].Funcionalidades F
	INNER JOIN [SHARPS].Perfiles_Funcionalidades PF ON F.Codigo = PF.Funcionalidad
	WHERE PF.Perfil = @Perfil_ID
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SHARPS].[GetProfesionales]

AS
BEGIN
	SELECT
		u.usuarioID ID,
		u.username UserName,
		p.Matricula Matricula,
		dp.apellido Apellido, 
		dp.nombre Nombre, 
		dp.sexo Sexo, 
		dp.mail Email,
		dp.fechaNac FechaNacimiento, 
		dp.TipoDNI TipoDoc, 
		dp.telefono Telefono, 
		dp.direccion Direccion, 
		dp.dni DNI, 
		p.Faltan_Datos FaltanDatos
	FROM  [SHARPS].USUARIOS u
	INNER JOIN [SHARPS].PROFESIONALES P on p.usuarioID = u.usuarioID
	INNER JOIN [SHARPS].DETALLES_PERSONA dp on dp.usuarioID = u.usuarioID
	WHERE P.Activo = 1
	ORDER BY U.UsuarioID

END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SHARPS].[GetPlanesMedicos]

AS
BEGIN
	SELECT
		pm.Codigo,
		pm.Descripcion,
		pm.Precio_Bono_Consulta,
		pm.Precio_Bono_Farmacia
	FROM  [SHARPS].Planes_Medicos pm
	WHERE pm.Activo = 1
END
GO


CREATE PROCEDURE [SHARPS].[GetPerfiles]

AS
BEGIN
	SELECT
		p.PerfilID ID,
		p.Descripcion
	FROM  [SHARPS].Perfiles p
END
GO


CREATE FUNCTION [SHARPS].[GetFunctionalityByName] 
(
	@Func_Name nvarchar(255)
)
RETURNS int
AS
BEGIN
	DECLARE @Func_ID int

	SELECT @Func_ID = Codigo FROM SHARPS.Funcionalidades
	WHERE Descripcion = @Func_Name

	RETURN @Func_ID
END
GO


CREATE PROCEDURE [SHARPS].[GetEspecialidadesForUser]
@userId INT
AS
BEGIN
	SELECT
		e.Codigo ID,
		e.Descripcion
	FROM  [SHARPS].Especialidades e
	INNER JOIN [SHARPS].Profesionales_Especialidades pe ON pe.Especialidad = e.Codigo
	WHERE pe.Profesional= @userId AND E.Activo = 1
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SHARPS].[GetDetallesPersona]
@userId INT
AS
BEGIN
	SELECT
		dp.apellido Apellido, 
		dp.nombre Nombre, 
		dp.sexo Sexo, 
		dp.mail Email,
		dp.fechaNac FechaNacimiento, 
		dp.TipoDNI TipoDoc, 
		dp.telefono Telefono, 
		dp.direccion Direccion, 
		dp.dni DNI
	FROM  [SHARPS].DETALLES_PERSONA dp
	WHERE dp.UsuarioID = @userId 
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [SHARPS].[GetAllEspecialidades]
AS
BEGIN
	SELECT
		e.Codigo ID,
		e.Descripcion
	FROM  [SHARPS].Especialidades e
	WHERE e.Activo = 1
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SHARPS].[GetAfiliados]

AS
BEGIN
	SELECT
		u.usuarioID ID,
		u.username UserName,
		pm.codigo Plan_ID,
		pm.Precio_Bono_Consulta PrecioConsulta, 
		pm.Precio_Bono_Farmacia PrecioFarmacia, 
		a.cantHijos CantHijos,
		a.GrupoFamiliar GrupoFamiliar,
		a.tipoAfiliado TipoAfiliado,
		ec.Descripcion EstadoCivil, 
		dp.apellido Apellido, 
		dp.nombre Nombre, 
		dp.sexo Sexo, 
		dp.mail Email,
		dp.fechaNac FechaNacimiento, 
		dp.TipoDNI TipoDoc, 
		dp.telefono Telefono, 
		dp.direccion Direccion, 
		dp.dni DNI,
		a.Faltan_Datos FaltanDatos
	FROM  [SHARPS].USUARIOS u
	INNER JOIN [SHARPS].AFILIADOS a on a.usuarioID = u.usuarioID
	INNER JOIN [SHARPS].PLANES_MEDICOS pm on pm.codigo = a.Plan_Medico
	INNER JOIN [SHARPS].DETALLES_PERSONA dp on dp.usuarioID = u.usuarioID
	INNER JOIN [SHARPS].Estados_Civiles ec on ec.Codigo = a.Estado_Civil
    WHERE a.Activo = 1
	ORDER BY U.UsuarioID

END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SHARPS].[GetAfiliadoInfo]
@userId INT
AS
BEGIN
	SELECT
		u.usuarioID ID,
		u.username UserName,
		pm.codigo Plan_ID,
		pm.Precio_Bono_Consulta PrecioConsulta, 
		pm.Precio_Bono_Farmacia PrecioFarmacia, 
		a.cantHijos CantHijos,
		a.GrupoFamiliar GrupoFamiliar,
		a.tipoAfiliado TipoAfiliado,
		ec.Descripcion EstadoCivil, 
		dp.apellido Apellido, 
		dp.nombre Nombre, 
		dp.sexo Sexo, 
		dp.mail Email,
		dp.fechaNac FechaNacimiento, 
		dp.TipoDNI TipoDoc, 
		dp.telefono Telefono, 
		dp.direccion Direccion, 
		dp.dni DNI
	FROM  [SHARPS].USUARIOS u
	INNER JOIN [SHARPS].AFILIADOS a on a.usuarioID = u.usuarioID
	INNER JOIN [SHARPS].PLANES_MEDICOS pm on pm.codigo = a.Plan_Medico
	INNER JOIN [SHARPS].DETALLES_PERSONA dp on dp.usuarioID = u.usuarioID
	INNER JOIN [SHARPS].Estados_Civiles ec on ec.Codigo = a.Estado_Civil
	WHERE A.UsuarioID = @userId
	AND a.Activo = 1
	ORDER BY U.UsuarioID

END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SHARPS].[DeleteRoleFunctionalities]
	@Rol_ID int
AS
BEGIN
	DELETE FROM SHARPS.Roles_Funcionalidades
	WHERE Rol = @Rol_ID
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SHARPS].[DeleteRole]
	@Rol_ID int
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE SHARPS.Roles SET Activo = 0 WHERE RolID = @Rol_ID
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [SHARPS].[Login]
	@Nombre nvarchar(255),
	@Password nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT UsuarioID as ID, username as Nombre, activo as estado FROM  [SHARPS].Usuarios WHERE
	username = @Nombre AND Password = @Password AND Activo = 1
	
	IF @@ROWCOUNT = 0
		BEGIN
			UPDATE [SHARPS].Usuarios SET Intentos = Intentos + 1
			WHERE username = @Nombre
		END
	ELSE
		BEGIN
			UPDATE [SHARPS].Usuarios SET Intentos = 0
			WHERE username = @Nombre
		END
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SHARPS].[InsertUser]
	@username nvarchar(max),
	@password nvarchar(max)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO SHARPS.Usuarios(Username,Password,Intentos,Activo) VALUES (@username,@password,0,1)
	SELECT @@Identity AS ID
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [SHARPS].[InsertRoleFunctionality]
	@Rol_ID int,
	@Funcionalidad nvarchar(255)
AS
BEGIN
	INSERT INTO SHARPS.Roles_Funcionalidades (Rol, Funcionalidad)
	VALUES (@Rol_ID, [SHARPS].[GetFunctionalityByName](@Funcionalidad))
END
GO





CREATE PROCEDURE [SHARPS].[UpdateDetallePersona]

@Telefono numeric (18,0),
@Email varchar(255),
@Nombre varchar(255),
@Apellido varchar(255),
@DNI numeric (18,0),
@TipoDNI varchar(255),
@Sexo char(10),
@FechaNacimiento date,
@Direccion varchar(255),
@ID_Usuario numeric (18,0)

AS
BEGIN

UPDATE [SHARPS].Detalles_Persona SET
telefono = @Telefono , mail = @Email , nombre = @Nombre , apellido = @Apellido , direccion = @Direccion 
, dni = @DNI , TipoDNI = @TipoDNI  , sexo = @Sexo , fechaNac = @FechaNacimiento
WHERE @ID_Usuario = UsuarioID

END
GO


CREATE PROCEDURE [SHARPS].[InsertDetallePersona]

@Telefono numeric (18,0),
@Email varchar(255),
@Nombre varchar(255),
@Apellido varchar(255),
@DNI numeric (18,0),
@TipoDNI varchar(255),
@Sexo char(10),
@FechaNacimiento date,
@Direccion varchar(255),
@ID_Usuario numeric (18,0)

AS
BEGIN
INSERT INTO [SHARPS].Detalles_Persona (telefono ,TipoDNI , sexo, UsuarioID , direccion , apellido , nombre , mail , fechaNac,dni)
VALUES ( @Telefono , @TipoDNI , @Sexo , @ID_Usuario , @Direccion , @Apellido , @Nombre , @Email , @FechaNacimiento , @DNI)

END 
GO





CREATE PROCEDURE [SHARPS].[InsertAfiliado]
@PlanMedico numeric(18,0),
@ID numeric (18,0),
@EstadoCivil nchar(10),
@CantHijos int

AS 
BEGIN  
DECLARE @NroAfiliado int
DECLARE @codCivil int
SELECT @codCivil = Codigo from [SHARPS].Estados_Civiles where Descripcion = @EstadoCivil
SELECT @NroAfiliado = MAX(GrupoFamiliar) + 101 FROM [SHARPS].Afiliados
INSERT INTO [SHARPS].Afiliados (GrupoFamiliar , Plan_Medico , cantHijos , Estado_Civil , UsuarioID,Faltan_Datos)
VALUES (@NroAfiliado , @PlanMedico , @CantHijos ,@codCivil  , @ID,1) 
RETURN @NroAfiliado
END
GO 


CREATE PROCEDURE [SHARPS].[UpdateAfiliado]

@PlanMedico INT,
@ID INT,
@EstadoCivil nchar(10),
@CantHijos int,
@RolAfiliado INT, 
@Motivo char(10)
AS 
BEGIN
UPDATE [SHARPS].Afiliados set Plan_Medico = @PlanMedico , Estado_Civil = @EstadoCivil , cantHijos = @CantHijos , Faltan_Datos = 0
WHERE usuarioId = @ID
INSERT INTO [SHARPS].Cambios_Afiliado(Motivo_Cambio , Fecha , Afiliado)
VALUES (@Motivo , GETDATE() ,@ID )
DELETE SHARPS.Usuarios_Roles WHERE Usuario = @ID AND Rol = @RolAfiliado
INSERT INTO SHARPS.Usuarios_Roles (Usuario , Rol) VALUES (@ID , @RolAfiliado)
END
GO


CREATE PROCEDURE [SHARPS].[InsertMiembroGrupoFamiliar]
@PlanMedico int,
@EstadoCivil int,
@CantHijos int,
@RolAfiliado nvarchar(MAX),
@GrupoFamiliar int,
@TipoAfiliado int,
@UserID int   
AS
BEGIN 


INSERT INTO [SHARPS].Afiliados (GrupoFamiliar , UsuarioID , TipoAfiliado , CantHijos , Activo , Plan_Medico ,Faltan_Datos)
VALUES (@GrupoFamiliar , @UserID , NULL , @CantHijos ,1 , @PlanMedico,1)

DELETE SHARPS.Usuarios_Roles WHERE Usuario = @UserID AND Rol = @RolAfiliado
INSERT INTO [SHARPS].Usuarios_Roles (Usuario, Rol) 
VALUES (@UserID , @RolAfiliado)

UPDATE [SHARPS].Roles SET  Descripcion = 'Afiliado' , Activo = 1, Perfil = 1
WHERE RolID = @RolAfiliado



END
GO


CREATE PROCEDURE [SHARPS].[InsertProfesional]
@Matricula  int,
@ID int,
@Rol int

AS
BEGIN 
INSERT INTO Profesionales (Matricula , Activo , UsuarioID,Faltan_Datos)
VALUES (@Matricula , 1 , @ID,1)

DELETE SHARPS.Usuarios_Roles WHERE Usuario = @ID AND Rol = @Rol
INSERT INTO [SHARPS].Usuarios_Roles (Usuario, Rol) 
VALUES (@ID , @Rol)

UPDATE [SHARPS].Roles SET  Descripcion = 'Profesional' , Activo = 1, Perfil = 2
WHERE RolID = @Rol 

END
GO



CREATE PROCEDURE [SHARPS].[UpdateProfesional]
@Matricula int,
@ID int

AS
BEGIN

UPDATE [SHARPS].Profesionales SET Matricula = @Matricula , Faltan_Datos = 0
WHERE UsuarioID = @ID 

END
GO


CREATE PROCEDURE [SHARPS].[InsertSpeciality]
@MedicoID int,
@Especialidad int

AS
BEGIN
INSERT INTO [SHARPS].Profesionales_Especialidades (Profesional , Especialidad) 
VALUES (@MedicoID , @Especialidad)
END
GO


CREATE PROCEDURE [SHARPS].[CancelarDiaProfesional]
@MedicoID int,
@Fecha date

AS
BEGIN

UPDATE [SHARPS].Turnos
SET Estado = 3  
FROM [SHARPS].Turnos T
INNER JOIN Agendas A  ON A.Profesional = @MedicoID
WHERE T.Agenda = A.AgendaID AND CONVERT(CHAR(10), A.Horario ,112) = @Fecha

UPDATE Agendas SET Activo = 0
WHERE Profesional = @MedicoID AND CONVERT(CHAR(10), Horario ,112) = @Fecha 
END
GO


CREATE PROCEDURE [SHARPS].[GetBonos]

@userId int

AS
BEGIN
DECLARE @GRUPO INT
SELECT @GRUPO = GrupoFamiliar FROM Afiliados WHERE UsuarioID =@userId

SELECT BC.Fecha_Impresion AS Fecha , BC.Numero AS Numero , BC.Precio_Pagado AS Precio ,'Consulta' AS TipoBono
FROM [SHARPS].Bonos_Consulta BC
INNER JOIN Afiliados A ON A.GrupoFamiliar = @GRUPO 
INNER JOIN Consultas C ON C.Bono_Consulta <> BC.Numero
WHERE BC.Afiliado_Compro = @userId OR BC.Afiliado_Compro = A.UsuarioID
 

UNION

SELECT BF.Fecha_Impresion AS Fecha, BF.Numero AS Numero ,BF.Precio_Pagado AS Precio , 'Farmacia' AS TipoBono
FROM [SHARPS].Bonos_Farmacia BF
INNER JOIN Afiliados A ON A.GrupoFamiliar = @GRUPO 
INNER JOIN Recetas R ON R.Bono_Farmacia <> BF.Numero
WHERE BF.Afiliado_Compro = @userId OR BF.Afiliado_Compro = A.UsuarioID
AND DATEADD(day, 60, BF.Fecha_Impresion) >= GETDATE()
order by 4

END
GO



CREATE PROCEDURE [SHARPS].[ComprarBonoConsulta]
@Precio INT,
@AfiliadoCompro INT,
@Fecha DATE
AS 
BEGIN
DECLARE @NUMEROBONO INT
DECLARE @PLAN INT
SELECT @PLAN = A.Plan_Medico FROM Afiliados A WHERE A.UsuarioID = @AfiliadoCompro 
SELECT @NUMEROBONO = MAX(Numero) + 1  FROM [SHARPS].Bonos_Consulta 
INSERT INTO [SHARPS].Bonos_Consulta (Numero,Fecha_Impresion,Afiliado_Compro,Precio_Pagado)
VALUES (@NUMEROBONO  , @Fecha , @AfiliadoCompro,@Precio)
RETURN @NUMEROBONO 
END
GO



CREATE PROCEDURE [SHARPS].[ComprarBonoReceta] 
@Precio INT,
@AfiliadoCompro INT,
@Fecha DATE
AS 
BEGIN
DECLARE @NUMEROBONO INT
DECLARE @PLAN INT
SELECT @PLAN = A.Plan_Medico FROM Afiliados A WHERE A.UsuarioID = @AfiliadoCompro 
SELECT @NUMEROBONO = MAX(Numero) + 1 FROM [SHARPS].Bonos_Farmacia
INSERT INTO [SHARPS].Bonos_Farmacia(Numero,Fecha_Impresion,Afiliado_Compro,Precio_Pagado)
VALUES (@NUMEROBONO  , @Fecha , @AfiliadoCompro,@Precio)
RETURN @NUMEROBONO
END
GO



CREATE PROCEDURE [SHARPS].[GetAllAfiliadoTurnos]
@userId INT,
@fecha DATE


AS
BEGIN

SELECT T.FechaHoraLlegada as Fecha ,T.Numero as Numero ,A.Profesional AS UserProfesional ,P.Matricula AS Matricula
FROM Turnos T
INNER JOIN Agendas A ON A.AgendaID = T.Agenda
INNER JOIN Profesionales P ON P.UsuarioID = A.Profesional
WHERE T.Afiliado = @userId AND CONVERT(CHAR(10), A.Horario ,112) >= @fecha 

END
GO



CREATE PROCEDURE [SHARPS].[GetTurnosByProfesional]
@profesionalID INT,
@fecha DATE

AS
BEGIN

SELECT CONVERT(VARCHAR,A.Horario,108) Hora , CONVERT(CHAR(10), A.Horario ,112) AS Fecha 
FROM Agendas A
WHERE A.Profesional = @profesionalID
AND A.Horario = @fecha AND A.Activo = 0

END
GO 


CREATE PROCEDURE [SHARPS].[InsertTurno]
@Fecha DATE,
@Profesional_ID INT,
@Afiliado_ID INT

AS
BEGIN

DECLARE @IDAGENDA INT
DECLARE @NUMERO INT
SELECT @NUMERO = MAX(Numero) + 1 FROM [SHARPS].Turnos
SELECT @IDAGENDA = AgendaID FROM [SHARPS].Agendas A WHERE A.Profesional = @Profesional_ID
INSERT INTO [SHARPS].Turnos (Numero , Afiliado , Estado , FechaHoraLlegada , Agenda )
VALUES (@NUMERO , @Afiliado_ID, 3 , NULL,@IDAGENDA)
UPDATE Agendas SET Activo = 1 
WHERE Horario = @Fecha AND Profesional = @Profesional_ID

END
GO 


CREATE PROCEDURE [SHARPS].[RegistrarLlegada]
@Profesional_ID INT,
@HoraLlegada DATE, 
@Afiliado_ID INT,
@NCONSULTA INT
AS
BEGIN
DECLARE @TURNO INT 

UPDATE SHARPS.Turnos SET Estado = 1 , FechaHoraLlegada = @HoraLlegada
FROM SHARPS.Turnos T 
INNER JOIN Agendas A ON A.Profesional = @Profesional_ID AND A.Activo = 1
WHERE T.Afiliado = @Afiliado_ID AND T.Agenda = A.AgendaID 

SELECT @TURNO = T.Numero FROM SHARPS.Turnos T 
INNER JOIN Agendas A ON A.Profesional = @Profesional_ID AND A.Activo = 1
WHERE T.Afiliado = @Afiliado_ID AND T.Agenda = A.AgendaID 
SELECT @NCONSULTA = MAX(A.cantConsultas) + 1 FROM [SHARPS].Afiliados A WHERE A.UsuarioID = @Afiliado_ID
UPDATE Afiliados SET CantConsultas = @NCONSULTA  WHERE UsuarioID = @Afiliado_ID
INSERT INTO Consultas (Turno,Numero_Consulta) VALUES (@TURNO,@NCONSULTA)
END
GO



CREATE PROCEDURE [SHARPS].[InsertConsulta]
@Turno INT,
@Sintomas NVARCHAR(MAX),
@Enfermedad NVARCHAR(MAX)
AS
BEGIN
UPDATE Consultas SET Sintomas = @Sintomas , Enfermedad = @Enfermedad WHERE Turno = @Turno

END
GO

CREATE PROCEDURE [SHARPS].[DeleteUser]
@User_ID INT
AS
BEGIN

UPDATE SHARPS.Usuarios SET
Activo = 0
WHERE UsuarioID = @User_ID

UPDATE SHARPS.Afiliados SET Activo = 0
WHERE UsuarioID = @User_ID

UPDATE SHARPS.Profesionales SET Activo = 0
WHERE UsuarioID = @User_ID
UPDATE SHARPS.Agendas SET Activo = 0
WHERE Profesional = @User_ID
UPDATE SHARPS.Turnos SET Estado = 5
FROM SHARPS.Turnos T
INNER JOIN SHARPS.Agendas A ON A.AgendaID = T.Agenda
WHERE A.Profesional = @User_ID OR T.Afiliado = @User_ID
END
GO


CREATE PROCEDURE [SHARPS].[InsertReceta]
@BonoFarmacia INT
AS
BEGIN

INSERT INTO Recetas (Bono_Farmacia) VALUES (@BonoFarmacia)

END
GO 

CREATE PROCEDURE [SHARPS].[AgregarMedicamentos]
@BonoFarmacia INT,
@Medicamento  INT  
AS
BEGIN
   
INSERT INTO SHARPS.Recetas_Medicamentos ( Receta, Medicamento)
VALUES (@BonoFarmacia , @Medicamento)

END
GO

create PROCEDURE [SHARPS].[GetProfesionalInfo]
@userId INT
as 
BEGIN

select 
distinct u.username UserName , 
		a.matricula matricula,  
		dp.apellido Apellido, 
		dp.nombre Nombre, 
		dp.sexo Sexo, 
		dp.mail Email,
		dp.fechaNac FechaNacimiento, 
		dp.TipoDNI TipoDoc, 
		dp.telefono Telefono, 
		dp.direccion Direccion, 
		dp.dni DNI,
		A.Faltan_Datos FaltanDatos
from SHARPS.Usuarios u
inner join SHARPS.Profesionales a on a.UsuarioID = @userId
inner join SHARPS.Detalles_Persona dp on dp.UsuarioID = @userId
where u.UsuarioID = @userId

END
GO  

CREATE PROCEDURE [SHARPS].[GetMedicamentos]

AS
BEGIN

SELECT Codigo AS Numero , Descripcion AS Nombre
FROM SHARPS.Medicamentos

END
GO



CREATE PROCEDURE [SHARPS].[GetTurnosAfiliadoDate]
@userId INT,
@fecha DATE
AS
BEGIN

SELECT T.Numero , T.Afiliado , A.Horario Fecha, a.Profesional UserProfesional
FROM Agendas A
INNER JOIN Turnos T ON T.Agenda = A.AgendaID AND A.Activo = 1
WHERE CONVERT(CHAR(10), A.Horario ,112) = @fecha AND t.Afiliado = @userId
END

GO


CREATE PROCEDURE  [SHARPS].CancelarTurnoAfiliado
@turno INT
AS
BEGIN

UPDATE SHARPS.Turnos SET Estado = 2
FROM Turnos T
INNER JOIN Agendas A ON A.AgendaID = T.Agenda
WHERE T.Numero = @turno  AND A.Activo = 1

END
GO


CREATE PROCEDURE [SHARPS].DeleteProfesional
@ID INT
AS
BEGIN

UPDATE SHARPS.Profesionales SET Activo = 0
WHERE UsuarioID = @ID

END
GO
USE [GD2C2013]
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SHARPS].[InsertDiaProfesional]
	@Fecha datetime,
	@Profesional int
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM SHARPS.Agendas WHERE Profesional = @Profesional AND Horario > @Fecha 
    --Si tiene un turno asignado en la fecha, deberiamos cancelarlo, de alguna manera
	INSERT INTO SHARPS.Agendas(Horario,Profesional, Activo) VALUES (@Fecha,@Profesional,1)
	--SELECT @@Identity AS ID
END
GO
CREATE PROCEDURE [SHARPS].[GetAfiliadosFromGrupoFamiliar]
@GrupoFamiliar INT
AS
BEGIN
	SELECT UsuarioID FROM Afiliados WHERE GrupoFamiliar = @GrupoFamiliar
END
GO
PRINT 'Procedimientos Cargados con Exito'
