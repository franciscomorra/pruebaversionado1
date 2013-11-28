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
	Horario DATETIME,
	Activo [bit],
CONSTRAINT [PK_Agendas] PRIMARY KEY CLUSTERED 
(
	[AgendaID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;

CREATE TABLE [SHARPS].Compras (

   CompraID int IDENTITY ( 1 , 1 ) not null,
   Precio_BonoConsulta int , 
   Precio_BonoFarmacia int,
   Afiliado int,
   fecha_Compra DATETIME,
   CONSTRAINT [PK_Compras] PRIMARY KEY CLUSTERED 
(
	[CompraID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;


CREATE TABLE [SHARPS].Bonos_Farmacia ( 
	Numero numeric(18,0)  NOT NULL,
	Fecha_Impresion DATETIME,
	Compra int,
	PlanMedico numeric(18,0),
CONSTRAINT [PK_Bonos_Farmacia] PRIMARY KEY CLUSTERED 
(
	[Numero] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;


CREATE TABLE [SHARPS].Bonos_Consulta ( 
	Numero numeric(18,0) NOT NULL,
	Fecha_Impresion DATETIME,
	Compra int,
	PlanMedico numeric(18,0),
CONSTRAINT [PK_Bonos_Consulta] PRIMARY KEY CLUSTERED 
(
	[Numero] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
;





CREATE TABLE [SHARPS].Cambios_Afiliado ( 
	Afiliado [int],
	Fecha DATETIME,
	Motivo_Cambio varchar(30)
)
GO
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
	FechaNac DATETIME
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
GO
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
GO
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
GO
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
	Username nvarchar(50) UNIQUE,
	Password nvarchar(100) NOT NULL,
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
GO
;


CREATE TRIGGER TR_Planes
ON SHARPS.Afiliados
AFTER UPDATE
AS 
BEGIN
	SET NOCOUNT ON;
	IF UPDATE(Plan_Medico)
	BEGIN 
		INSERT INTO SHARPS.Cambios_Afiliado
		(Afiliado, Fecha, Motivo_Cambio)
		SELECT UsuarioID ,getdate(), 'CambioPlan' 
		FROM INSERTED
	END
END
GO

ALTER TABLE [SHARPS].[Afiliados] ADD  CONSTRAINT [DF_Afiliados_Activo]  DEFAULT ((1)) FOR [Activo]
GO

ALTER TABLE [SHARPS].[Afiliados] ADD CONSTRAINT [DF_Afiliados_CantConsultas] DEFAULT ((0)) FOR [CantConsultas]
GO

ALTER TABLE [SHARPS].[Afiliados]  WITH CHECK ADD  CONSTRAINT [CK_Afiliados_CantHijos] CHECK  (([CantHijos]>=(0)))
GO
ALTER TABLE [SHARPS].[Afiliados] CHECK CONSTRAINT [CK_Afiliados_CantHijos]
GO

/*ALTER TABLE [SHARPS].[Bonos_Consulta]  WITH CHECK ADD  CONSTRAINT [CK_Bonos_Consulta_Precio_Pagado] CHECK  (([Precio_Pagado]>=(0)))
GO
ALTER TABLE [SHARPS].[Bonos_Consulta] CHECK CONSTRAINT [CK_Bonos_Consulta_Precio_Pagado]
GO

ALTER TABLE [SHARPS].[Bonos_Farmacia]  WITH CHECK ADD  CONSTRAINT [CK_Bonos_Farmacia_Precio_Pagado] CHECK  (([Precio_Pagado]>=(0)))
GO
ALTER TABLE [SHARPS].[Bonos_Farmacia] CHECK CONSTRAINT [CK_Bonos_Farmacia_Precio_Pagado]
GO*/

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

/*ALTER TABLE [SHARPS].[Planes_Medicos]  WITH CHECK ADD  CONSTRAINT [CK_Planes_Medicos_Precio_Bono_Consulta] CHECK  (([Precio_Bono_Consulta]>=(0)))
GO
ALTER TABLE [SHARPS].[Planes_Medicos] CHECK CONSTRAINT [CK_Planes_Medicos_Precio_Bono_Consulta]
GO

ALTER TABLE [SHARPS].[Planes_Medicos]  WITH CHECK ADD  CONSTRAINT [CK_Planes_Medicos_Precio_Bono_Farmacia] CHECK  (([Precio_Bono_Farmacia]>=(0)))
GO
ALTER TABLE [SHARPS].[Planes_Medicos] CHECK CONSTRAINT [CK_Planes_Medicos_Precio_Bono_Farmacia]*/
GO

ALTER TABLE [SHARPS].[Roles] ADD  CONSTRAINT [DF_Roles_Activo]  DEFAULT ((1)) FOR [Activo]
GO

ALTER TABLE [SHARPS].[Usuarios] ADD  CONSTRAINT [DF_Usuarios_Intentos]  DEFAULT ((0)) FOR [Intentos]
GO

ALTER TABLE [SHARPS].[Usuarios] ADD  CONSTRAINT [DF_Usuarios_Activo]  DEFAULT ((1)) FOR [Activo]
GO


ALTER TABLE [SHARPS].[Bonos_Consulta]  WITH CHECK ADD  CONSTRAINT [FK_Bonos_Consulta_Planes_Medicos] FOREIGN KEY([planMedico])
REFERENCES [SHARPS].[Planes_Medicos] ([Codigo])
ALTER TABLE [SHARPS].[Bonos_Consulta] CHECK CONSTRAINT [FK_Bonos_Consulta_Planes_Medicos]
GO

ALTER TABLE [SHARPS].[Bonos_Farmacia]  WITH CHECK ADD  CONSTRAINT [FK_Bonos_Farmacia_Planes_Medicos] FOREIGN KEY([planMedico])
REFERENCES [SHARPS].[Planes_Medicos] ([Codigo])
ALTER TABLE [SHARPS].[Bonos_Farmacia] CHECK CONSTRAINT [FK_Bonos_Farmacia_Planes_Medicos]
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

ALTER TABLE [SHARPS].[Bonos_Consulta]  WITH CHECK ADD  CONSTRAINT [FK_Bonos_Consulta_Compras] FOREIGN KEY([Compra])
REFERENCES [SHARPS].[Compras] ([CompraID])
GO
ALTER TABLE [SHARPS].[Bonos_Consulta] CHECK CONSTRAINT [FK_Bonos_Consulta_Compras]
GO

ALTER TABLE [SHARPS].[Bonos_Farmacia]  WITH CHECK ADD  CONSTRAINT [FK_Bonos_Farmacia_Compras] FOREIGN KEY([Compra])
REFERENCES [SHARPS].[Compras] ([CompraID])
GO
ALTER TABLE [SHARPS].[Bonos_Farmacia] CHECK CONSTRAINT [FK_Bonos_Farmacia_Compras]
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

ALTER TABLE [SHARPS].[Compras]  WITH CHECK ADD  CONSTRAINT [FK_Compras_Afiliados] FOREIGN KEY([Afiliado])
REFERENCES [SHARPS].[Afiliados] ([UsuarioID])
GO
ALTER TABLE [SHARPS].[Compras] CHECK CONSTRAINT [FK_Compras_Afiliados]
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
values (1,0,'Admin','E6-B8-70-50-BF-CB-81-43-FC-B8-DB-01-70-A4-DC-9E-D0-0D-90-4D-DD-3E-2A-4A-D1-B1-E8-DC-0F-DC-9B-E7')


PRINT 'Ingresando Estados Civiles...'
INSERT INTO [SHARPS].Estados_Civiles (Descripcion) VALUES ('Soltero'); 
INSERT INTO [SHARPS].Estados_Civiles (Descripcion) VALUES ('Casado');
INSERT INTO [SHARPS].Estados_Civiles (Descripcion) VALUES ('Viudo');
INSERT INTO [SHARPS].Estados_Civiles (Descripcion) VALUES ('Concubinato');
INSERT INTO [SHARPS].Estados_Civiles (Descripcion) VALUES ('Divorciado')

PRINT 'Ingresando Estados de un Turno...'
INSERT INTO [SHARPS].Estados_Turno (Descripcion) VALUES ('Activo'); ---todavia no es el dia del turno
INSERT INTO [SHARPS].Estados_Turno (Descripcion) VALUES ('CanceladoAfiliado');
INSERT INTO [SHARPS].Estados_Turno (Descripcion) VALUES ('CanceladoProfesional');
INSERT INTO [SHARPS].Estados_Turno (Descripcion) VALUES ('Atendido');
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



/*INSERT INTO [SHARPS].Bonos_Consulta(Numero,Fecha_Impresion,Compra,PlanMedico)
SELECT distinct m.Bono_Consulta_Numero , m.Bono_Consulta_Fecha_Impresion, [SHARPS].UltimoCompra(), m.Plan_Med_Codigo
  FROM gd_esquema.Maestra m
  INNER JOIN [SHARPS].Usuarios a on CAST(m.Paciente_DNI AS Nvarchar(MAX))= a.Username
  WHERE m.Turno_Fecha is NULL AND m.Bono_Consulta_Numero is not null  
GO

INSERT INTO  SHARPS.Compras (Precio_BonoConsulta , Precio_BonoFarmacia , Afiliado , fecha_Compra)
SELECT DISTINCT  M.Plan_Med_Precio_Bono_Consulta, M.Plan_Med_Precio_Bono_Farmacia , U.UsuarioID , M.Compra_Bono_Fecha
FROM gd_esquema.Maestra M
INNER JOIN SHARPS.Usuarios U ON U.Username =  CAST(M.Paciente_DNI AS Nvarchar(MAX))
INNER JOIN SHARPS.Bonos_Consulta  BC ON BC.Numero = M.Bono_Consulta_Numero 
WHERE m.Turno_Fecha is NULL AND m.Bono_Consulta_Numero is not null
GO

PRINT 'Ingresando los Bonos Farmacia'
INSERT INTO [SHARPS].Bonos_Farmacia(Numero,Fecha_Impresion,Compra ,PlanMedico)
SELECT distinct m.Bono_Farmacia_Numero , m.Bono_Farmacia_Fecha_Impresion,[SHARPS].UltimoCompra() ,m.Plan_Med_Codigo
  FROM gd_esquema.Maestra m
  INNER JOIN [SHARPS].Usuarios a on CAST(m.Paciente_DNI AS Nvarchar(MAX))= a.Username
  WHERE m.Turno_Fecha is NULL AND m.Bono_Farmacia_Numero is not null   
GO

INSERT INTO  SHARPS.Compras (Precio_BonoConsulta , Precio_BonoFarmacia , Afiliado , fecha_Compra)
SELECT DISTINCT  M.Plan_Med_Precio_Bono_Consulta, M.Plan_Med_Precio_Bono_Farmacia , U.UsuarioID , M.Compra_Bono_Fecha
FROM gd_esquema.Maestra M
INNER JOIN SHARPS.Usuarios U ON U.Username =  CAST(M.Paciente_DNI AS Nvarchar(MAX))
INNER JOIN SHARPS.Bonos_Farmacia BF ON BF.Numero = M.Bono_Farmacia_Numero  
WHERE m.Turno_Fecha is NULL AND m.Bono_Farmacia_Numero is not null
GO
*/


-- PARA BONOS DE FARMACIA
/*INSERT INTO [SHARPS].Compras (Precio_BonoConsulta , Precio_BonoFarmacia , Afiliado , fecha_Compra)
SELECT DISTINCT m.Plan_Med_Precio_Bono_Consulta , m.Plan_Med_Precio_Bono_Farmacia , U.UsuarioID , m.Compra_Bono_Fecha
FROM gd_esquema.Maestra m
INNER JOIN SHARPS.Usuarios U ON U.Username =  CAST(m.Paciente_DNI AS Nvarchar(MAX))
WHERE m.Turno_Fecha is NULL AND m.Bono_Farmacia_Numero is not null AND m.Paciente_Dni IS NOT NULL
order by m.Compra_Bono_Fecha , U.UsuarioID

INSERT INTO [SHARPS].Bonos_Farmacia (Numero, Fecha_Impresion, Compra ,PlanMedico)
SELECT DISTINCT m.Bono_Farmacia_Numero , m.Bono_Farmacia_Fecha_Impresion , C.CompraID , m.Plan_Med_Codigo
FROM gd_esquema.Maestra m
INNER JOIN SHARPS.Usuarios U ON U.Username =  CAST(m.Paciente_DNI AS Nvarchar(MAX))
INNER JOIN SHARPS.Compras C ON U.UsuarioID = C.Afiliado 
WHERE  m.Bono_Farmacia_Numero is not null

--PARA BONOS DE CONSULTA

INSERT INTO [SHARPS].Compras (Precio_BonoConsulta , Precio_BonoFarmacia , Afiliado , fecha_Compra)
SELECT DISTINCT m.Plan_Med_Precio_Bono_Consulta , m.Plan_Med_Precio_Bono_Farmacia , U.UsuarioID , m.Compra_Bono_Fecha
FROM gd_esquema.Maestra m
INNER JOIN SHARPS.Usuarios U ON U.Username =  CAST(m.Paciente_DNI AS Nvarchar(MAX))
WHERE m.Turno_Fecha is NULL AND m.Bono_Consulta_Numero IS NOT NULL AND m.Paciente_Dni IS NOT NULL
order by m.Compra_Bono_Fecha , U.UsuarioID

INSERT INTO [SHARPS].Bonos_Consulta(Numero, Fecha_Impresion, Compra ,PlanMedico)
SELECT  DISTINCT m.Bono_Consulta_Numero , m.Bono_Consulta_Fecha_Impresion , C.CompraID , m.Plan_Med_Codigo
FROM gd_esquema.Maestra m
INNER JOIN SHARPS.Usuarios U ON U.Username =  CAST(m.Paciente_DNI AS Nvarchar(MAX))
INNER JOIN SHARPS.Compras C ON U.UsuarioID = C.Afiliado 
WHERE  m.Bono_Consulta_Numero is not null*/

CREATE TABLE SHARPS.#compras(
CodID int identity (1,1) ,
Precio_Consulta int ,
Precio_Farmacia int,
usuario int,
Fecha_Compra DATETIME,
numero_Bono int,
plan_Medico int,
tipo_Bono nvarchar (50),
Fecha_Impresion date
)


INSERT INTO  SHARPS.#compras (Precio_Consulta, Precio_Farmacia , usuario, Fecha_Compra, numero_Bono, plan_Medico, tipo_Bono, Fecha_Impresion)
SELECT  m.Plan_Med_Precio_Bono_Consulta , m.Plan_Med_Precio_Bono_Farmacia , U.UsuarioID , m.Compra_Bono_Fecha , m.Bono_Farmacia_Numero  , M.Plan_Med_Codigo ,'farmacia', m.Bono_Farmacia_Fecha_Impresion
FROM gd_esquema.Maestra m
INNER JOIN SHARPS.Usuarios U ON U.Username =  CAST(m.Paciente_DNI AS Nvarchar(255))
WHERE m.Turno_Fecha is NULL AND m.Bono_Farmacia_Numero is not null  



INSERT INTO  SHARPS.#compras (Precio_Consulta, Precio_Farmacia , usuario, Fecha_Compra, numero_Bono, plan_Medico, tipo_Bono, Fecha_Impresion)
SELECT  m.Plan_Med_Precio_Bono_Consulta , m.Plan_Med_Precio_Bono_Farmacia , U.UsuarioID , m.Compra_Bono_Fecha , m.Bono_Consulta_Numero  , M.Plan_Med_Codigo ,'consultas', m.Bono_Consulta_Fecha_Impresion
FROM gd_esquema.Maestra m
INNER JOIN SHARPS.Usuarios U ON U.Username =  CAST(m.Paciente_DNI AS Nvarchar(255))
WHERE m.Turno_Fecha is NULL AND m.Bono_Consulta_Numero is not null  


PRINT 'Ingresando Compras'
GO

INSERT INTO [SHARPS].Compras (Precio_BonoConsulta , Precio_BonoFarmacia , Afiliado , fecha_Compra)
SELECT  C.Precio_Consulta , C.Precio_Farmacia, C.usuario, C.Fecha_Compra
FROM SHARPS.#compras C



PRINT 'Ingresando los Bonos Farmacia'
GO

INSERT INTO SHARPS.Bonos_Farmacia(Numero , Fecha_Impresion , PlanMedico , Compra)
select  C.numero_Bono , C.Fecha_Impresion , C.plan_Medico , C.CodID
from  SHARPS.#compras C
INNER JOIN SHARPS.Compras CO ON CO.CompraID = C.CodID
where C.tipo_Bono = 'farmacia'

PRINT 'Ingresando los Bonos Consulta'
GO

INSERT INTO SHARPS.Bonos_Consulta(Numero , Fecha_Impresion , PlanMedico , Compra)
select  C.numero_Bono , C.Fecha_Impresion , C.plan_Medico , C.CodID
from  SHARPS.#compras C
INNER JOIN SHARPS.Compras CO ON CO.CompraID = C.CodID
where C.tipo_Bono = 'consultas'








DROP TABLE SHARPS.#compras





--Rellenando Agendas
PRINT 'Rellenando Agendas...'
INSERT INTO [SHARPS].Agendas(Profesional,Horario,Activo)
SELECT distinct x.UsuarioID , m.Turno_Fecha,0
FROM gd_esquema.Maestra m
INNER JOIN [SHARPS].Usuarios x on x.Username =CAST(m.Medico_DNI AS Nvarchar(MAX))
WHERE m.Turno_Fecha is not null
order by 1

GO
--Ingresando Turnos

	
PRINT 'Ingresando los Turnos...'
GO
DECLARE @idEstadoAtendido INT
SELECT @idEstadoAtendido = et.EstadoID  FROM SHARPS.Estados_Turno et WHERE et.Descripcion = 'Atendido'

INSERT INTO [SHARPS].Turnos (Numero , Afiliado , Agenda, Estado)
SELECT distinct m.Turno_Numero , U.UsuarioID , a.AgendaID ,@idEstadoAtendido
FROM gd_esquema.Maestra m
INNER JOIN [SHARPS].Agendas a ON a.Horario = m.Turno_Fecha
INNER JOIN [SHARPS].Usuarios x ON x.UsuarioID = a.Profesional
INNER JOIN [SHARPS].Usuarios U on U.Username = CAST(m.Paciente_Dni AS Nvarchar(MAX))
WHERE m.Turno_Fecha is not null and CAST(m.Medico_DNI AS Nvarchar(MAX)) = x.Username
ORDER by 1

--Rellenando Consultas
PRINT 'Rellenando Consultas...'
INSERT INTO [SHARPS].Consultas(Turno,Bono_Consulta,Sintomas,Enfermedad,Numero_Consulta)
SELECT  distinct m.Turno_Numero , m.Bono_Consulta_Numero,m.Consulta_Sintomas,m.Consulta_Enfermedades,1
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
INSERT INTO [SHARPS].Recetas (Bono_Farmacia)
SELECT  m.Bono_Farmacia_Numero
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
AND U.Username = 'Admin'

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
		a.faltan_datos FaltanDatos,
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
	DECLARE @FuncionalidadID INT
	SELECT @FuncionalidadID = Codigo FROM Funcionalidades WHERE Descripcion = @Funcionalidad
	
	INSERT INTO SHARPS.Roles_Funcionalidades (Rol, Funcionalidad)
	VALUES (@Rol_ID, @FuncionalidadID)
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
@FechaNacimiento DATETIME,
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
@FechaNacimiento DATETIME,
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
VALUES (@NroAfiliado , @PlanMedico , @CantHijos ,@codCivil  , @ID,0) 
RETURN @NroAfiliado
END
GO 


CREATE PROCEDURE [SHARPS].[UpdateAfiliado]

@PlanMedico INT,
@ID INT,
@EstadoCivil nchar(10),
@CantHijos int,
@RolAfiliado INT, 
@Motivo char(10),
@fecha datetime
AS 
BEGIN
DECLARE @rolActual INT
DECLARE @codigoEstadoCivil INT
SELECT @codigoEstadoCivil = ec.codigo FROM [SHARPS].Estados_Civiles ec WHERE ec.descripcion = @EstadoCivil

UPDATE [SHARPS].Afiliados set Plan_Medico = @PlanMedico , Estado_Civil = @codigoEstadoCivil  , cantHijos = @CantHijos , Faltan_Datos = 0
WHERE usuarioId = @ID
INSERT INTO [SHARPS].Cambios_Afiliado(Motivo_Cambio , Fecha , Afiliado)
VALUES (@Motivo , @fecha ,@ID )

SELECT @rolActual = r.RolID FROM Roles r 
INNER JOIN [SHARPS].Perfiles P ON r.Perfil = p.PerfilID
WHERE p.Descripcion = 'Afiliado'

DELETE FROM SHARPS.Usuarios_Roles WHERE Rol = @rolActual AND Usuario = @ID
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
VALUES (@GrupoFamiliar , @UserID , NULL , @CantHijos ,1 , @PlanMedico,0)

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
VALUES (@Matricula , 1 , @ID,0)

DELETE SHARPS.Usuarios_Roles WHERE Usuario = @ID AND Rol = @Rol
INSERT INTO [SHARPS].Usuarios_Roles (Usuario, Rol) 
VALUES (@ID , @Rol)

UPDATE [SHARPS].Roles SET  Descripcion = 'Profesional' , Activo = 1, Perfil = 2
WHERE RolID = @Rol 

END
GO



CREATE PROCEDURE [SHARPS].[UpdateProfesional]
@Matricula int,
@ID int,
@RolProfesional INT
AS
BEGIN

	DECLARE @rolActual INT

	UPDATE [SHARPS].Profesionales SET Matricula = @Matricula , Faltan_Datos = 0
	WHERE UsuarioID = @ID 

	SELECT @rolActual = r.RolID FROM Roles r 
	INNER JOIN [SHARPS].Perfiles P ON r.Perfil = p.PerfilID
	WHERE p.Descripcion = 'Profesional'

	DELETE FROM SHARPS.Usuarios_Roles WHERE Rol = @rolActual AND Usuario = @ID
	INSERT INTO SHARPS.Usuarios_Roles (Usuario , Rol) VALUES (@ID , @RolProfesional)

END
GO



CREATE PROCEDURE [SHARPS].[LimpiarEspecialidadesDeProfesional]
@profesionalID int

AS
BEGIN
	DELETE FROM [SHARPS].Profesionales_Especialidades WHERE Profesional = @profesionalID
END
GO


CREATE PROCEDURE [SHARPS].[InsertEspecialidad]
@profesionalID int,
@Especialidad int

AS
BEGIN
	INSERT INTO [SHARPS].Profesionales_Especialidades (Profesional , Especialidad) 
	VALUES (@profesionalID , @Especialidad)
END
GO


CREATE  PROCEDURE [SHARPS].[CancelarDiaProfesional]
@Profesional int,
@Fecha DATETIME

AS
BEGIN
	DECLARE @idEstadoCanceladoProfesional INT
	SELECT @idEstadoCanceladoProfesional = et.EstadoID  FROM SHARPS.Estados_Turno et WHERE et.Descripcion = 'CanceladoProfesional'
	UPDATE SHARPS.Agendas 
	SET Activo = 0 
	WHERE DAY(Horario) = DAY(@Fecha)
	AND MONTH(Horario) = MONTH(@Fecha)
	AND YEAR(Horario) = YEAR(@Fecha) 
	AND Profesional = @Profesional
	UPDATE SHARPS.Turnos SET Estado = @idEstadoCanceladoProfesional
	FROM Turnos T
	INNER JOIN Agendas A ON a.AgendaID = t.Agenda
	WHERE 
	a.Profesional = @Profesional
	AND DAY(Horario) = DAY(@Fecha)
	AND MONTH(Horario) = MONTH(@Fecha)
	AND YEAR(Horario) = YEAR(@Fecha)
	
END

GO

CREATE PROCEDURE [SHARPS].[GetBonos] --Agregar que no fueron usados!!!! /////////MODIFICADO PERO NO PROBADO

@userId int,
@fecha DATETIME
AS
BEGIN
DECLARE @GRUPO INT
DECLARE @Plan INT
SELECT @GRUPO = GrupoFamiliar, @Plan = Plan_Medico FROM [SHARPS].Afiliados WHERE UsuarioID = @userId

SELECT BC.Fecha_Impresion AS Fecha , BC.Numero AS Numero , X.Precio_BonoConsulta AS Precio ,'Consulta' AS TipoBono,X.CompraID CompraID
FROM [SHARPS].Bonos_Consulta BC
INNER JOIN [SHARPS].Compras X ON X.CompraID = BC.Compra
INNER JOIN [SHARPS].Afiliados A ON A.UsuarioID = X.Afiliado
LEFT JOIN [SHARPS].Consultas CON ON CON.Bono_Consulta = BC.Numero
WHERE A.GrupoFamiliar = @GRUPO
AND A.Plan_Medico = @Plan
AND CON.Numero_Consulta IS NULL

UNION

SELECT BF.Fecha_Impresion AS Fecha, BF.Numero AS Numero ,X.Precio_BonoFarmacia AS Precio , 'Farmacia' AS TipoBono,X.CompraID CompraID
FROM [SHARPS].Bonos_Farmacia BF
INNER JOIN [SHARPS].Compras X ON X.CompraID = BF.Compra
INNER JOIN [SHARPS].Afiliados A ON A.UsuarioID = X.Afiliado
LEFT JOIN Recetas R ON R.Bono_Farmacia = BF.Numero
WHERE A.GrupoFamiliar = @GRUPO
AND A.Plan_Medico = @Plan
AND DATEADD(DAY, 60, BF.Fecha_Impresion) >= @fecha
AND R.RecetaID IS NULL

END
GO



CREATE PROCEDURE [SHARPS].[ComprarBonoConsulta]
@Precio INT,
@AfiliadoCompro INT,
@Fecha DATE,
@COMPRA INT
AS 
BEGIN
DECLARE @NUMEROBONO INT
DECLARE @PLAN INT
SELECT @PLAN = A.Plan_Medico FROM Afiliados A WHERE A.UsuarioID = @AfiliadoCompro 
SELECT @NUMEROBONO = MAX(Numero) + 1  FROM [SHARPS].Bonos_Consulta 
INSERT INTO [SHARPS].Bonos_Consulta (Numero,Fecha_Impresion,PlanMedico, Compra)
VALUES (@NUMEROBONO  , @Fecha , @PLAN,@COMPRA)
RETURN @NUMEROBONO 
END
GO


/*
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
GO */

CREATE PROCEDURE [SHARPS].[ComprarBonoReceta] -------//////////MODIFICADO
@Precio INT,
@AfiliadoCompro INT,
@Fecha DATETIME,
@COMPRA INT
AS 
BEGIN
DECLARE @NUMEROBONO INT
DECLARE @PLAN INT
SELECT @PLAN = A.Plan_Medico FROM Afiliados A WHERE A.UsuarioID = @AfiliadoCompro 
SELECT @NUMEROBONO = MAX(Numero) + 1 FROM [SHARPS].Bonos_Farmacia
INSERT INTO [SHARPS].Bonos_Farmacia (Numero,Fecha_Impresion,PlanMedico, Compra)
VALUES (@NUMEROBONO  , @Fecha , @PLAN, @COMPRA)
RETURN @NUMEROBONO 
END
GO


CREATE PROCEDURE [SHARPS].[GetAllAfiliadoTurnos]
@userId INT
,@fecha DATETIME
AS
BEGIN


SELECT a.horario as Fecha ,T.Numero as Numero ,A.Profesional AS UserProfesional ,P.Matricula AS Matricula
FROM Turnos T
INNER JOIN Agendas A ON A.AgendaID = T.Agenda
INNER JOIN Profesionales P ON P.UsuarioID = A.Profesional
INNER JOIN Estados_Turno et ON t.estado = et.EstadoID
WHERE T.Afiliado = @userId 
	AND YEAR(A.Horario) >= YEAR(@fecha) 
	AND MONTH(a.Horario) >= MONTH(@fecha) 
	AND DAY(a.Horario) >= DAY(@fecha) 
AND et.Descripcion = 'Activo'
ORDER BY a.AgendaID
END
GO



CREATE PROCEDURE [SHARPS].[GetAgendaByProfesional]
@profesionalID INT,
@fecha DATETIME
AS
BEGIN
SELECT a.Horario  Fecha
FROM Agendas A
WHERE A.Profesional = @profesionalID
AND YEAR(A.Horario) = YEAR(@fecha) 
AND MONTH(a.Horario) = MONTH(@fecha) 
AND DAY(a.Horario) = DAY(@fecha) 
AND A.Activo = 1
END
GO

CREATE PROCEDURE [SHARPS].[GetTurnosByProfesional]
@profesionalID INT,
@fecha DATETIME
AS
BEGIN
	SELECT t.Estado, a.Horario  Fecha, t.Afiliado
	FROM [SHARPS].[Agendas] A
	INNER JOIN [SHARPS].[Turnos] T ON t.Agenda = A.AgendaID
	INNER JOIN [sharps].Estados_Turno et ON et.EstadoID = t.Estado
	WHERE A.Profesional = @profesionalID
	
	AND YEAR(A.Horario) = YEAR(@fecha) 
	AND MONTH(a.Horario) = MONTH(@fecha) 
	AND DAY(a.Horario) = DAY(@fecha) 
	AND A.Activo = 0
	AND et.Descripcion = 'Activo'
END
GO

CREATE PROCEDURE [SHARPS].[InsertTurno]
@Fecha DATETIME,
@Profesional_ID INT,
@Afiliado_ID INT

AS
BEGIN
	DECLARE @idEstadoActivo INT
	DECLARE @IDAGENDA INT
	DECLARE @NUMERO INT
	SELECT @idEstadoActivo = et.EstadoID  FROM SHARPS.Estados_Turno et WHERE et.Descripcion = 'Activo'
	
	SELECT @NUMERO = MAX(Numero) + 1 FROM [SHARPS].Turnos
	
	SELECT @IDAGENDA = AgendaID FROM [SHARPS].Agendas A WHERE A.Profesional = @Profesional_ID AND a.Horario = @Fecha
	
	INSERT INTO [SHARPS].Turnos (Numero , Afiliado , Estado , FechaHoraLlegada , Agenda )
	VALUES (@NUMERO , @Afiliado_ID, @idEstadoActivo , NULL,@IDAGENDA)
	UPDATE [SHARPS].Agendas SET Activo = 0 WHERE AgendaID = @IDAGENDA

END
GO 


CREATE PROCEDURE [SHARPS].[RegistrarLlegada]
@TURNO INT,
@NCONSULTA INT,
@HORA DATETIME
AS
BEGIN
DECLARE @IDAFILIADO INT

DECLARE @idEstadoLlego INT
SELECT @idEstadoLlego = et.EstadoID  FROM SHARPS.Estados_Turno et WHERE et.Descripcion = 'Atendido'


UPDATE SHARPS.Turnos SET Estado = @idEstadoLlego , FechaHoraLlegada = @HORA
WHERE Numero = @TURNO

SELECT @IDAFILIADO = T.Afiliado FROM SHARPS.Turnos T WHERE T.Numero = @TURNO

SELECT @NCONSULTA = MAX(A.cantConsultas) + 1 FROM [SHARPS].Afiliados A WHERE A.UsuarioID = @IDAFILIADO
UPDATE Afiliados SET CantConsultas = @NCONSULTA  WHERE UsuarioID = @IDAFILIADO
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

CREATE PROCEDURE [SHARPS].[DeleteAfiliado]
@ID INT
AS
BEGIN

UPDATE SHARPS.Afiliados SET Activo = 0
WHERE UsuarioID = @ID

UPDATE SHARPS.Turnos SET Estado = 5
FROM SHARPS.Turnos T
INNER JOIN SHARPS.Agendas A ON A.AgendaID = T.Agenda
WHERE T.Afiliado = @ID
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


CREATE PROCEDURE  [SHARPS].CancelarTurnoAfiliado
@turno INT
AS
BEGIN
DECLARE @idEstadoCanceladoAfiliado INT
DECLARE @IDAGENDA INT
SELECT @idEstadoCanceladoAfiliado = et.EstadoID  FROM Estados_Turno et WHERE et.Descripcion = 'CanceladoAfiliado'
SELECT @IDAGENDA = T.Agenda FROM TURNOS T WHERE T.Numero = @turno
UPDATE SHARPS.Turnos SET Estado = @idEstadoCanceladoAfiliado WHERE Numero = @turno
UPDATE SHARPS.Agendas SET Activo = 1 WHERE AgendaID = @IDAGENDA AND Activo = 0
END
GO


CREATE PROCEDURE [SHARPS].[DeleteProfesional]
@ID INT
AS
BEGIN
DECLARE @estadoCanceladoBaja int
SELECT @estadoCanceladoBaja =EstadoID FROM Estados_Turno WHERE Descripcion = 'Desactivo'


UPDATE SHARPS.Profesionales SET Activo = 0
WHERE UsuarioID = @ID


UPDATE SHARPS.Agendas SET Activo = 0
WHERE Profesional = @ID
UPDATE SHARPS.Turnos SET Estado = @estadoCanceladoBaja
FROM SHARPS.Turnos T
INNER JOIN SHARPS.Agendas A ON A.AgendaID = T.Agenda
WHERE A.Profesional = @ID


END
GO

CREATE PROCEDURE [SHARPS].[InsertAgendaProfesional]
	@Fecha DATETIME,
	@Profesional int
AS
BEGIN
	SET NOCOUNT ON;
	IF (NOT EXISTS (SELECT * FROM Agendas WHERE Profesional = @Profesional AND Horario = @Fecha))
		INSERT INTO SHARPS.Agendas(Horario,Profesional, Activo) VALUES (@Fecha,@Profesional,1)
	ELSE
		UPDATE SHARPS.Agendas SET Activo = 1 WHERE Profesional = @Profesional AND Horario = @Fecha
END
GO


CREATE PROCEDURE [SHARPS].[GetAfiliadoTurnosConsulta]
@userId INT
,@fecha DATETIME
AS
BEGIN


SELECT a.horario as Fecha ,T.Numero as Numero ,A.Profesional AS UserProfesional ,P.Matricula AS Matricula,C.Numero_Consulta NROCONSULTA
FROM [SHARPS].Turnos T
INNER JOIN [SHARPS].Agendas A ON A.AgendaID = T.Agenda
INNER JOIN [SHARPS].Profesionales P ON P.UsuarioID = A.Profesional
INNER JOIN [SHARPS].Estados_Turno et ON t.estado = et.EstadoID
INNER JOIN [SHARPS].Consultas C ON C.Turno = T.Numero
WHERE T.Afiliado = @userId 
	AND YEAR(A.Horario) = YEAR(@fecha) 
	AND MONTH(a.Horario) = MONTH(@fecha) 
	AND DAY(a.Horario) = DAY(@fecha) 
AND et.Descripcion = 'Atendido'
AND C.Sintomas IS NULL
ORDER BY a.AgendaID
END
GO

CREATE PROCEDURE [SHARPS].[GetAfiliadosFromGrupoFamiliar]
@GrupoFamiliar INT
AS
BEGIN
	SELECT UsuarioID FROM Afiliados WHERE GrupoFamiliar = @GrupoFamiliar AND Activo = 1
END
GO

CREATE PROCEDURE [SHARPS].[InsertarCompra]
	@AfiliadoID INT,
	@Fecha DATETIME,
	@precioCons INT,
	@precioFar INT
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO SHARPS.Compras
	(Afiliado,Precio_BonoConsulta,Precio_BonoFarmacia,fecha_Compra) 
	VALUES (@AfiliadoID,@precioCons,@precioFar,@Fecha)
	SELECT @@Identity AS CompraID
END
GO

PRINT 'Procedimientos Cargados con Exito'
