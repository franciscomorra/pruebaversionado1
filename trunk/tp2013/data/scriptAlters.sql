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
