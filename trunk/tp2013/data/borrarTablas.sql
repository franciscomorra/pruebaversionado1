USE [GD2C2013]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[SHARPS].[FK_Afiliados_Estados_Civiles]') AND parent_object_id = OBJECT_ID(N'[SHARPS].[Afiliados]'))
ALTER TABLE [SHARPS].[Afiliados] DROP CONSTRAINT [FK_Afiliados_Estados_Civiles]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[SHARPS].[FK_Afiliados_Planes_Medicos]') AND parent_object_id = OBJECT_ID(N'[SHARPS].[Afiliados]'))
ALTER TABLE [SHARPS].[Afiliados] DROP CONSTRAINT [FK_Afiliados_Planes_Medicos]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[SHARPS].[FK_Afiliados_Usuarios]') AND parent_object_id = OBJECT_ID(N'[SHARPS].[Afiliados]'))
ALTER TABLE [SHARPS].[Afiliados] DROP CONSTRAINT [FK_Afiliados_Usuarios]
GO

IF  EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[SHARPS].[CK_Afiliados_CantHijos]') AND parent_object_id = OBJECT_ID(N'[SHARPS].[Afiliados]'))
ALTER TABLE [SHARPS].[Afiliados] DROP CONSTRAINT [CK_Afiliados_CantHijos]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Afiliados_Activo]') AND type = 'D')
BEGIN
ALTER TABLE [SHARPS].[Afiliados] DROP CONSTRAINT [DF_Afiliados_Activo]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Afiliados_CantConsultas]') AND type = 'D')
BEGIN
ALTER TABLE [SHARPS].[Afiliados] DROP CONSTRAINT [DF_Afiliados_CantConsultas]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Afiliados__Falta__78E06F01]') AND type = 'D')
BEGIN
ALTER TABLE [SHARPS].[Afiliados] DROP CONSTRAINT [DF__Afiliados__Falta__78E06F01]
END

GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[SHARPS].[FK_Agendas_Profesionales]') AND parent_object_id = OBJECT_ID(N'[SHARPS].[Agendas]'))
ALTER TABLE [SHARPS].[Agendas] DROP CONSTRAINT [FK_Agendas_Profesionales]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Agendas_Activo]') AND type = 'D')
BEGIN
ALTER TABLE [SHARPS].[Agendas] DROP CONSTRAINT [DF_Agendas_Activo]
END

GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[SHARPS].[FK_Bonos_Consulta_Compras]') AND parent_object_id = OBJECT_ID(N'[SHARPS].[Bonos_Consulta]'))
ALTER TABLE [SHARPS].[Bonos_Consulta] DROP CONSTRAINT [FK_Bonos_Consulta_Compras]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[SHARPS].[FK_Bonos_Consulta_Planes_Medicos]') AND parent_object_id = OBJECT_ID(N'[SHARPS].[Bonos_Consulta]'))
ALTER TABLE [SHARPS].[Bonos_Consulta] DROP CONSTRAINT [FK_Bonos_Consulta_Planes_Medicos]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[SHARPS].[FK_Bonos_Farmacia_Compras]') AND parent_object_id = OBJECT_ID(N'[SHARPS].[Bonos_Farmacia]'))
ALTER TABLE [SHARPS].[Bonos_Farmacia] DROP CONSTRAINT [FK_Bonos_Farmacia_Compras]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[SHARPS].[FK_Bonos_Farmacia_Planes_Medicos]') AND parent_object_id = OBJECT_ID(N'[SHARPS].[Bonos_Farmacia]'))
ALTER TABLE [SHARPS].[Bonos_Farmacia] DROP CONSTRAINT [FK_Bonos_Farmacia_Planes_Medicos]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[SHARPS].[FK_Cambios_Afiliado_Afiliados]') AND parent_object_id = OBJECT_ID(N'[SHARPS].[Cambios_Afiliado]'))
ALTER TABLE [SHARPS].[Cambios_Afiliado] DROP CONSTRAINT [FK_Cambios_Afiliado_Afiliados]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[SHARPS].[FK_Compras_Afiliados]') AND parent_object_id = OBJECT_ID(N'[SHARPS].[Compras]'))
ALTER TABLE [SHARPS].[Compras] DROP CONSTRAINT [FK_Compras_Afiliados]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[SHARPS].[FK_Consultas_Bonos_Consulta]') AND parent_object_id = OBJECT_ID(N'[SHARPS].[Consultas]'))
ALTER TABLE [SHARPS].[Consultas] DROP CONSTRAINT [FK_Consultas_Bonos_Consulta]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[SHARPS].[FK_Consultas_Turnos]') AND parent_object_id = OBJECT_ID(N'[SHARPS].[Consultas]'))
ALTER TABLE [SHARPS].[Consultas] DROP CONSTRAINT [FK_Consultas_Turnos]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[SHARPS].[FK_Detalles_Persona_Usuarios]') AND parent_object_id = OBJECT_ID(N'[SHARPS].[Detalles_Persona]'))
ALTER TABLE [SHARPS].[Detalles_Persona] DROP CONSTRAINT [FK_Detalles_Persona_Usuarios]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Detalles_Persona_Sexo]') AND type = 'D')
BEGIN
ALTER TABLE [SHARPS].[Detalles_Persona] DROP CONSTRAINT [DF_Detalles_Persona_Sexo]
END

GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[SHARPS].[FK_Especialidades_Tipos_Especialidades]') AND parent_object_id = OBJECT_ID(N'[SHARPS].[Especialidades]'))
ALTER TABLE [SHARPS].[Especialidades] DROP CONSTRAINT [FK_Especialidades_Tipos_Especialidades]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Especialidades_Activo]') AND type = 'D')
BEGIN
ALTER TABLE [SHARPS].[Especialidades] DROP CONSTRAINT [DF_Especialidades_Activo]
END

GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[SHARPS].[FK_Perfiles_Funcionalidades_Funcionalidades]') AND parent_object_id = OBJECT_ID(N'[SHARPS].[Perfiles_Funcionalidades]'))
ALTER TABLE [SHARPS].[Perfiles_Funcionalidades] DROP CONSTRAINT [FK_Perfiles_Funcionalidades_Funcionalidades]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[SHARPS].[FK_Perfiles_Funcionalidades_Perfiles]') AND parent_object_id = OBJECT_ID(N'[SHARPS].[Perfiles_Funcionalidades]'))
ALTER TABLE [SHARPS].[Perfiles_Funcionalidades] DROP CONSTRAINT [FK_Perfiles_Funcionalidades_Perfiles]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_PlanesMedicos_Activo]') AND type = 'D')
BEGIN
ALTER TABLE [SHARPS].[Planes_Medicos] DROP CONSTRAINT [DF_PlanesMedicos_Activo]
END

GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[SHARPS].[FK_Profesionales_Usuarios]') AND parent_object_id = OBJECT_ID(N'[SHARPS].[Profesionales]'))
ALTER TABLE [SHARPS].[Profesionales] DROP CONSTRAINT [FK_Profesionales_Usuarios]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Profesionales_Activo]') AND type = 'D')
BEGIN
ALTER TABLE [SHARPS].[Profesionales] DROP CONSTRAINT [DF_Profesionales_Activo]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Profesion__Falta__11AC1CCB]') AND type = 'D')
BEGIN
ALTER TABLE [SHARPS].[Profesionales] DROP CONSTRAINT [DF__Profesion__Falta__11AC1CCB]
END

GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[SHARPS].[FK_Profesionales_Especialidades_Especialidades]') AND parent_object_id = OBJECT_ID(N'[SHARPS].[Profesionales_Especialidades]'))
ALTER TABLE [SHARPS].[Profesionales_Especialidades] DROP CONSTRAINT [FK_Profesionales_Especialidades_Especialidades]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[SHARPS].[FK_Profesionales_Especialidades_Profesionales]') AND parent_object_id = OBJECT_ID(N'[SHARPS].[Profesionales_Especialidades]'))
ALTER TABLE [SHARPS].[Profesionales_Especialidades] DROP CONSTRAINT [FK_Profesionales_Especialidades_Profesionales]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[SHARPS].[FK_Recetas_Bonos_Farmacia]') AND parent_object_id = OBJECT_ID(N'[SHARPS].[Recetas]'))
ALTER TABLE [SHARPS].[Recetas] DROP CONSTRAINT [FK_Recetas_Bonos_Farmacia]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[SHARPS].[FK_Recetas_Medicamentos_Medicamentos]') AND parent_object_id = OBJECT_ID(N'[SHARPS].[Recetas_Medicamentos]'))
ALTER TABLE [SHARPS].[Recetas_Medicamentos] DROP CONSTRAINT [FK_Recetas_Medicamentos_Medicamentos]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[SHARPS].[FK_Recetas_Medicamentos_Recetas]') AND parent_object_id = OBJECT_ID(N'[SHARPS].[Recetas_Medicamentos]'))
ALTER TABLE [SHARPS].[Recetas_Medicamentos] DROP CONSTRAINT [FK_Recetas_Medicamentos_Recetas]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[SHARPS].[FK_Roles_Perfiles]') AND parent_object_id = OBJECT_ID(N'[SHARPS].[Roles]'))
ALTER TABLE [SHARPS].[Roles] DROP CONSTRAINT [FK_Roles_Perfiles]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Roles_Activo]') AND type = 'D')
BEGIN
ALTER TABLE [SHARPS].[Roles] DROP CONSTRAINT [DF_Roles_Activo]
END

GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[SHARPS].[FK_Roles_Funcionalidades_Funcionalidades]') AND parent_object_id = OBJECT_ID(N'[SHARPS].[Roles_Funcionalidades]'))
ALTER TABLE [SHARPS].[Roles_Funcionalidades] DROP CONSTRAINT [FK_Roles_Funcionalidades_Funcionalidades]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[SHARPS].[FK_Roles_Funcionalidades_Roles]') AND parent_object_id = OBJECT_ID(N'[SHARPS].[Roles_Funcionalidades]'))
ALTER TABLE [SHARPS].[Roles_Funcionalidades] DROP CONSTRAINT [FK_Roles_Funcionalidades_Roles]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[SHARPS].[FK_Turnos_Afiliados]') AND parent_object_id = OBJECT_ID(N'[SHARPS].[Turnos]'))
ALTER TABLE [SHARPS].[Turnos] DROP CONSTRAINT [FK_Turnos_Afiliados]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[SHARPS].[FK_Turnos_Agendas]') AND parent_object_id = OBJECT_ID(N'[SHARPS].[Turnos]'))
ALTER TABLE [SHARPS].[Turnos] DROP CONSTRAINT [FK_Turnos_Agendas]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[SHARPS].[FK_Turnos_Especialidades]') AND parent_object_id = OBJECT_ID(N'[SHARPS].[Turnos]'))
ALTER TABLE [SHARPS].[Turnos] DROP CONSTRAINT [FK_Turnos_Especialidades]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[SHARPS].[FK_Turnos_Estados_Turno]') AND parent_object_id = OBJECT_ID(N'[SHARPS].[Turnos]'))
ALTER TABLE [SHARPS].[Turnos] DROP CONSTRAINT [FK_Turnos_Estados_Turno]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Usuarios_Intentos]') AND type = 'D')
BEGIN
ALTER TABLE [SHARPS].[Usuarios] DROP CONSTRAINT [DF_Usuarios_Intentos]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Usuarios_Activo]') AND type = 'D')
BEGIN
ALTER TABLE [SHARPS].[Usuarios] DROP CONSTRAINT [DF_Usuarios_Activo]
END

GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[SHARPS].[FK_Usuarios_Roles_Roles]') AND parent_object_id = OBJECT_ID(N'[SHARPS].[Usuarios_Roles]'))
ALTER TABLE [SHARPS].[Usuarios_Roles] DROP CONSTRAINT [FK_Usuarios_Roles_Roles]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[SHARPS].[FK_Usuarios_Roles_Usuarios]') AND parent_object_id = OBJECT_ID(N'[SHARPS].[Usuarios_Roles]'))
ALTER TABLE [SHARPS].[Usuarios_Roles] DROP CONSTRAINT [FK_Usuarios_Roles_Usuarios]
GO

USE [GD2C2013]
GO

/****** Object:  Table [SHARPS].[Afiliados]    Script Date: 12/05/2013 20:59:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[Afiliados]') AND type in (N'U'))
DROP TABLE [SHARPS].[Afiliados]
GO

/****** Object:  Table [SHARPS].[Agendas]    Script Date: 12/05/2013 20:59:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[Agendas]') AND type in (N'U'))
DROP TABLE [SHARPS].[Agendas]
GO

/****** Object:  Table [SHARPS].[Bonos_Consulta]    Script Date: 12/05/2013 20:59:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[Bonos_Consulta]') AND type in (N'U'))
DROP TABLE [SHARPS].[Bonos_Consulta]
GO

/****** Object:  Table [SHARPS].[Bonos_Farmacia]    Script Date: 12/05/2013 20:59:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[Bonos_Farmacia]') AND type in (N'U'))
DROP TABLE [SHARPS].[Bonos_Farmacia]
GO

/****** Object:  Table [SHARPS].[Cambios_Afiliado]    Script Date: 12/05/2013 20:59:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[Cambios_Afiliado]') AND type in (N'U'))
DROP TABLE [SHARPS].[Cambios_Afiliado]
GO

/****** Object:  Table [SHARPS].[Compras]    Script Date: 12/05/2013 20:59:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[Compras]') AND type in (N'U'))
DROP TABLE [SHARPS].[Compras]
GO

/****** Object:  Table [SHARPS].[Consultas]    Script Date: 12/05/2013 20:59:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[Consultas]') AND type in (N'U'))
DROP TABLE [SHARPS].[Consultas]
GO

/****** Object:  Table [SHARPS].[Detalles_Persona]    Script Date: 12/05/2013 20:59:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[Detalles_Persona]') AND type in (N'U'))
DROP TABLE [SHARPS].[Detalles_Persona]
GO

/****** Object:  Table [SHARPS].[Especialidades]    Script Date: 12/05/2013 20:59:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[Especialidades]') AND type in (N'U'))
DROP TABLE [SHARPS].[Especialidades]
GO

/****** Object:  Table [SHARPS].[Estados_Civiles]    Script Date: 12/05/2013 20:59:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[Estados_Civiles]') AND type in (N'U'))
DROP TABLE [SHARPS].[Estados_Civiles]
GO

/****** Object:  Table [SHARPS].[Estados_Turno]    Script Date: 12/05/2013 20:59:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[Estados_Turno]') AND type in (N'U'))
DROP TABLE [SHARPS].[Estados_Turno]
GO

/****** Object:  Table [SHARPS].[Funcionalidades]    Script Date: 12/05/2013 20:59:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[Funcionalidades]') AND type in (N'U'))
DROP TABLE [SHARPS].[Funcionalidades]
GO

/****** Object:  Table [SHARPS].[Medicamentos]    Script Date: 12/05/2013 20:59:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[Medicamentos]') AND type in (N'U'))
DROP TABLE [SHARPS].[Medicamentos]
GO

/****** Object:  Table [SHARPS].[Perfiles]    Script Date: 12/05/2013 20:59:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[Perfiles]') AND type in (N'U'))
DROP TABLE [SHARPS].[Perfiles]
GO

/****** Object:  Table [SHARPS].[Perfiles_Funcionalidades]    Script Date: 12/05/2013 20:59:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[Perfiles_Funcionalidades]') AND type in (N'U'))
DROP TABLE [SHARPS].[Perfiles_Funcionalidades]
GO

/****** Object:  Table [SHARPS].[Planes_Medicos]    Script Date: 12/05/2013 20:59:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[Planes_Medicos]') AND type in (N'U'))
DROP TABLE [SHARPS].[Planes_Medicos]
GO

/****** Object:  Table [SHARPS].[Profesionales]    Script Date: 12/05/2013 20:59:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[Profesionales]') AND type in (N'U'))
DROP TABLE [SHARPS].[Profesionales]
GO

/****** Object:  Table [SHARPS].[Profesionales_Especialidades]    Script Date: 12/05/2013 20:59:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[Profesionales_Especialidades]') AND type in (N'U'))
DROP TABLE [SHARPS].[Profesionales_Especialidades]
GO

/****** Object:  Table [SHARPS].[Recetas]    Script Date: 12/05/2013 20:59:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[Recetas]') AND type in (N'U'))
DROP TABLE [SHARPS].[Recetas]
GO

/****** Object:  Table [SHARPS].[Recetas_Medicamentos]    Script Date: 12/05/2013 20:59:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[Recetas_Medicamentos]') AND type in (N'U'))
DROP TABLE [SHARPS].[Recetas_Medicamentos]
GO

/****** Object:  Table [SHARPS].[Roles]    Script Date: 12/05/2013 20:59:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[Roles]') AND type in (N'U'))
DROP TABLE [SHARPS].[Roles]
GO

/****** Object:  Table [SHARPS].[Roles_Funcionalidades]    Script Date: 12/05/2013 20:59:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[Roles_Funcionalidades]') AND type in (N'U'))
DROP TABLE [SHARPS].[Roles_Funcionalidades]
GO

/****** Object:  Table [SHARPS].[Tipos_Especialidades]    Script Date: 12/05/2013 20:59:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[Tipos_Especialidades]') AND type in (N'U'))
DROP TABLE [SHARPS].[Tipos_Especialidades]
GO

/****** Object:  Table [SHARPS].[Turnos]    Script Date: 12/05/2013 20:59:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[Turnos]') AND type in (N'U'))
DROP TABLE [SHARPS].[Turnos]
GO

/****** Object:  Table [SHARPS].[Usuarios]    Script Date: 12/05/2013 20:59:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[Usuarios]') AND type in (N'U'))
DROP TABLE [SHARPS].[Usuarios]
GO

/****** Object:  Table [SHARPS].[Usuarios_Roles]    Script Date: 12/05/2013 20:59:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[Usuarios_Roles]') AND type in (N'U'))
DROP TABLE [SHARPS].[Usuarios_Roles]
GO

USE [GD2C2013]
GO

/****** Object:  StoredProcedure [SHARPS].[InsertAgendaProfesional]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[InsertAgendaProfesional]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[InsertAgendaProfesional]
GO

/****** Object:  StoredProcedure [SHARPS].[InsertAfiliado]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[InsertAfiliado]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[InsertAfiliado]
GO

/****** Object:  StoredProcedure [SHARPS].[GetUserRoles]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[GetUserRoles]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[GetUserRoles]
GO

/****** Object:  StoredProcedure [SHARPS].[InsertarCompra]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[InsertarCompra]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[InsertarCompra]
GO

/****** Object:  StoredProcedure [SHARPS].[InsertEspecialidad]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[InsertEspecialidad]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[InsertEspecialidad]
GO

/****** Object:  StoredProcedure [SHARPS].[InsertDetallePersona]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[InsertDetallePersona]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[InsertDetallePersona]
GO

/****** Object:  StoredProcedure [SHARPS].[InsertConsulta]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[InsertConsulta]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[InsertConsulta]
GO

/****** Object:  StoredProcedure [SHARPS].[GetUserLoginAttempts]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[GetUserLoginAttempts]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[GetUserLoginAttempts]
GO

/****** Object:  StoredProcedure [SHARPS].[GetProfesionalInfo]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[GetProfesionalInfo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[GetProfesionalInfo]
GO

/****** Object:  StoredProcedure [SHARPS].[GetProfesionales]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[GetProfesionales]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[GetProfesionales]
GO

/****** Object:  StoredProcedure [SHARPS].[GetPlanesMedicos]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[GetPlanesMedicos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[GetPlanesMedicos]
GO

/****** Object:  StoredProcedure [SHARPS].[GetRoleFunctionalities]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[GetRoleFunctionalities]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[GetRoleFunctionalities]
GO

/****** Object:  StoredProcedure [SHARPS].[GetTurnosByProfesional]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[GetTurnosByProfesional]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[GetTurnosByProfesional]
GO

/****** Object:  StoredProcedure [SHARPS].[GetRolesByPerfil]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[GetRolesByPerfil]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[GetRolesByPerfil]
GO

/****** Object:  StoredProcedure [SHARPS].[GetRoles]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[GetRoles]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[GetRoles]
GO

/****** Object:  StoredProcedure [SHARPS].[RegistrarLlegada]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[RegistrarLlegada]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[RegistrarLlegada]
GO

/****** Object:  StoredProcedure [SHARPS].[NuevoGrupoFamiliar]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[NuevoGrupoFamiliar]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[NuevoGrupoFamiliar]
GO

/****** Object:  StoredProcedure [SHARPS].[Login]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[Login]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[Login]
GO

/****** Object:  StoredProcedure [SHARPS].[UpdateAfiliado]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[UpdateAfiliado]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[UpdateAfiliado]
GO

/****** Object:  StoredProcedure [SHARPS].[UpdateRole]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[UpdateRole]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[UpdateRole]
GO

/****** Object:  StoredProcedure [SHARPS].[UpdateProfesional]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[UpdateProfesional]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[UpdateProfesional]
GO

/****** Object:  StoredProcedure [SHARPS].[UpdateDetallePersona]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[UpdateDetallePersona]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[UpdateDetallePersona]
GO

/****** Object:  StoredProcedure [SHARPS].[LimpiarEspecialidadesDeProfesional]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[LimpiarEspecialidadesDeProfesional]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[LimpiarEspecialidadesDeProfesional]
GO

/****** Object:  StoredProcedure [SHARPS].[InsertReceta]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[InsertReceta]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[InsertReceta]
GO

/****** Object:  StoredProcedure [SHARPS].[InsertProfesional]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[InsertProfesional]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[InsertProfesional]
GO

/****** Object:  StoredProcedure [SHARPS].[InsertMiembroGrupoFamiliar]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[InsertMiembroGrupoFamiliar]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[InsertMiembroGrupoFamiliar]
GO

/****** Object:  StoredProcedure [SHARPS].[InsertRole]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[InsertRole]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[InsertRole]
GO

/****** Object:  StoredProcedure [SHARPS].[InsertUser]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[InsertUser]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[InsertUser]
GO

/****** Object:  StoredProcedure [SHARPS].[InsertTurno]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[InsertTurno]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[InsertTurno]
GO

/****** Object:  StoredProcedure [SHARPS].[InsertRoleFunctionality]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[InsertRoleFunctionality]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[InsertRoleFunctionality]
GO

/****** Object:  StoredProcedure [SHARPS].[DeleteRoleFunctionalities]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[DeleteRoleFunctionalities]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[DeleteRoleFunctionalities]
GO

/****** Object:  StoredProcedure [SHARPS].[DeleteRole]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[DeleteRole]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[DeleteRole]
GO

/****** Object:  StoredProcedure [SHARPS].[DeleteProfesional]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[DeleteProfesional]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[DeleteProfesional]
GO

/****** Object:  StoredProcedure [SHARPS].[Get_TOPCancelaciones]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[Get_TOPCancelaciones]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[Get_TOPCancelaciones]
GO

/****** Object:  StoredProcedure [SHARPS].[Get_TOPVividores]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[Get_TOPVividores]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[Get_TOPVividores]
GO

/****** Object:  StoredProcedure [SHARPS].[Get_TOPVencidos]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[Get_TOPVencidos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[Get_TOPVencidos]
GO

/****** Object:  StoredProcedure [SHARPS].[Get_TOPRecetados]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[Get_TOPRecetados]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[Get_TOPRecetados]
GO

/****** Object:  StoredProcedure [SHARPS].[DeleteAgenda]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[DeleteAgenda]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[DeleteAgenda]
GO

/****** Object:  StoredProcedure [SHARPS].[CancelarTurnoAfiliado]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[CancelarTurnoAfiliado]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[CancelarTurnoAfiliado]
GO

/****** Object:  StoredProcedure [SHARPS].[CancelarDiaProfesional]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[CancelarDiaProfesional]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[CancelarDiaProfesional]
GO

/****** Object:  StoredProcedure [SHARPS].[AgregarMedicamentos]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[AgregarMedicamentos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[AgregarMedicamentos]
GO

/****** Object:  StoredProcedure [SHARPS].[CancelarTurnoAgenda]    Script Date: 12/05/2013 21:51:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[CancelarTurnoAgenda]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[CancelarTurnoAgenda]
GO

/****** Object:  StoredProcedure [SHARPS].[DeleteAfiliado]    Script Date: 12/05/2013 21:52:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[DeleteAfiliado]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[DeleteAfiliado]
GO

/****** Object:  StoredProcedure [SHARPS].[ComprarBonoReceta]    Script Date: 12/05/2013 21:52:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[ComprarBonoReceta]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[ComprarBonoReceta]
GO

/****** Object:  StoredProcedure [SHARPS].[ComprarBonoConsulta]    Script Date: 12/05/2013 21:52:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[ComprarBonoConsulta]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[ComprarBonoConsulta]
GO

/****** Object:  StoredProcedure [SHARPS].[GetEspecialidadesForUser]    Script Date: 12/05/2013 21:52:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[GetEspecialidadesForUser]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[GetEspecialidadesForUser]
GO

/****** Object:  StoredProcedure [SHARPS].[GetDetallesPersona]    Script Date: 12/05/2013 21:52:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[GetDetallesPersona]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[GetDetallesPersona]
GO

/****** Object:  StoredProcedure [SHARPS].[GetConsultaInfo]    Script Date: 12/05/2013 21:52:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[GetConsultaInfo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[GetConsultaInfo]
GO

/****** Object:  StoredProcedure [SHARPS].[GetMedicamentos]    Script Date: 12/05/2013 21:52:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[GetMedicamentos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[GetMedicamentos]
GO

/****** Object:  StoredProcedure [SHARPS].[GetPerfilInfo]    Script Date: 12/05/2013 21:52:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[GetPerfilInfo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[GetPerfilInfo]
GO

/****** Object:  StoredProcedure [SHARPS].[GetPerfilFunctionalities]    Script Date: 12/05/2013 21:52:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[GetPerfilFunctionalities]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[GetPerfilFunctionalities]
GO

/****** Object:  StoredProcedure [SHARPS].[GetPerfiles]    Script Date: 12/05/2013 21:52:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[GetPerfiles]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[GetPerfiles]
GO

/****** Object:  StoredProcedure [SHARPS].[GetBonos]    Script Date: 12/05/2013 21:52:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[GetBonos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[GetBonos]
GO

/****** Object:  StoredProcedure [SHARPS].[GetAfiliadosFromGrupoFamiliar]    Script Date: 12/05/2013 21:52:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[GetAfiliadosFromGrupoFamiliar]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[GetAfiliadosFromGrupoFamiliar]
GO

/****** Object:  StoredProcedure [SHARPS].[GetAfiliados]    Script Date: 12/05/2013 21:52:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[GetAfiliados]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[GetAfiliados]
GO

/****** Object:  StoredProcedure [SHARPS].[GetAfiliadoInfo]    Script Date: 12/05/2013 21:52:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[GetAfiliadoInfo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[GetAfiliadoInfo]
GO

/****** Object:  StoredProcedure [SHARPS].[GetAfiliadoTurnosConsulta]    Script Date: 12/05/2013 21:52:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[GetAfiliadoTurnosConsulta]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[GetAfiliadoTurnosConsulta]
GO

/****** Object:  StoredProcedure [SHARPS].[GetAllEspecialidades]    Script Date: 12/05/2013 21:52:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[GetAllEspecialidades]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[GetAllEspecialidades]
GO

/****** Object:  StoredProcedure [SHARPS].[GetAllAfiliadoTurnos]    Script Date: 12/05/2013 21:52:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[GetAllAfiliadoTurnos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[GetAllAfiliadoTurnos]
GO

/****** Object:  StoredProcedure [SHARPS].[GetAgendaByProfesional]    Script Date: 12/05/2013 21:52:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SHARPS].[GetAgendaByProfesional]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SHARPS].[GetAgendaByProfesional]
GO


