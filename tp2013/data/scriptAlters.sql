ALTER TABLE [SHARPS].[Usuarios] ADD  CONSTRAINT [DF_Usuarios_Intentos]  DEFAULT ((0)) FOR [Intentos]
GO

ALTER TABLE [SHARPS].[Usuarios] ADD  CONSTRAINT [DF_Usuarios_Activo]  DEFAULT ((1)) FOR [Activo]
GO

ALTER TABLE [SHARPS].[Roles] ADD  CONSTRAINT [DF_Roles_Activo]  DEFAULT ((1)) FOR [Activo]
GO

ALTER TABLE [SHARPS].[Profesionales] ADD  CONSTRAINT [DF_Profesionales_Activo]  DEFAULT ((1)) FOR [Activo]
GO

ALTER TABLE [SHARPS].[Afiliados] ADD  CONSTRAINT [DF_Afiliados_Activo]  DEFAULT ((1)) FOR [Activo]
GO

--ALTER TABLE [SHARPS].[Recetas]  WITH CHECK ADD  CONSTRAINT [FK_Recetas_RecetasMedicamentos] FOREIGN KEY([bonoFarmacia])
--REFERENCES [SHARPS].[RecetasMedicamen] ([receta])
--GO
--ALTER TABLE [SHARPS].[Receta] CHECK CONSTRAINT [FK_Receta_RecetasMedicamen]
--GO

ALTER TABLE [SHARPS].[RecetasMedicamentos]  WITH CHECK ADD  CONSTRAINT [FK_RecetasMedicamentos_Medicamentos] FOREIGN KEY([Medicamento])
REFERENCES [SHARPS].[Medicamentos] ([Codigo])
GO
ALTER TABLE [SHARPS].[RecetasMedicamentos] CHECK CONSTRAINT [FK_RecetasMedicamentos_Medicamentos]
GO

ALTER TABLE [SHARPS].[Consultas]  WITH CHECK ADD  CONSTRAINT [FK_Consultas_Turnos] FOREIGN KEY([Turno])
REFERENCES [SHARPS].[Turnos] ([Numero])
GO
ALTER TABLE [SHARPS].[Consultas] CHECK CONSTRAINT [FK_Consultas_Turnos]
GO

ALTER TABLE [SHARPS].[Turnos]  WITH CHECK ADD  CONSTRAINT [FK_Turnos_EstadosTurno] FOREIGN KEY([Numero])
REFERENCES [SHARPS].[EstadosTurno] ([Estado])
GO
ALTER TABLE [SHARPS].[Turnos] CHECK CONSTRAINT [FK_Turnos_EstadosTurno]
GO

--ALTER TABLE [SHARPS].[Consulta]  WITH CHECK ADD  CONSTRAINT [FK_Consulta_Bono] FOREIGN KEY([bono])
--REFERENCES [SHARPS].[Bono] ([numeroBono])
--GO
--ALTER TABLE [SHARPS].[Consulta] CHECK CONSTRAINT [FK_Consulta_Bono]
--GO

ALTER TABLE [SHARPS].[Afiliados]  WITH CHECK ADD  CONSTRAINT [FK_Afiliados_PlanesMedicos] FOREIGN KEY([PlanMedico])
REFERENCES [SHARPS].[PlanesMedicos] ([Codigo])
GO
ALTER TABLE [SHARPS].[Afiliados] CHECK CONSTRAINT [FK_Afiliados_PlanesMedicos]
GO

ALTER TABLE [SHARPS].[CambiosAfiliado]  WITH CHECK ADD  CONSTRAINT [FK_CambiosAfiliado_Afiliados] FOREIGN KEY([Afiliado])
REFERENCES [SHARPS].[Afiliados] ([UsuarioID])
GO
ALTER TABLE [SHARPS].[CambiosAfiliado] CHECK CONSTRAINT [FK_CambiosAfiliado_Afiliados]
GO

--ALTER TABLE [SHARPS].[Turnos]  WITH CHECK ADD  CONSTRAINT [FK_Turnos_Afiliados] FOREIGN KEY([afiliado])
--REFERENCES [SHARPS].[Afiliados] ([nroAfiliado])
--GO
--ALTER TABLE [SHARPS].[Turnos] CHECK CONSTRAINT [FK_Turnos_Afiliados]
--GO

ALTER TABLE [SHARPS].[Agendas]  WITH CHECK ADD  CONSTRAINT [FK_Agendas_Profesionales] FOREIGN KEY([Profesional])
REFERENCES [SHARPS].[Profesionales] ([Matricula])
GO
ALTER TABLE [SHARPS].[Agendas] CHECK CONSTRAINT [FK_Agendas_Profesionales]
GO

ALTER TABLE [SHARPS].[ProfesionalesEspecialidades]  WITH CHECK ADD  CONSTRAINT [FK_ProfesionalesEspecialidades_Profesionales] FOREIGN KEY([Profesional])
REFERENCES [SHARPS].[Profesionales] ([Matricula])
GO
ALTER TABLE [SHARPS].[ProfesionalesESpecialidades] CHECK CONSTRAINT [FK_ProfesionalesEspecialidades_Profesionales]
GO

ALTER TABLE [SHARPS].[Especialidades]  WITH CHECK ADD  CONSTRAINT [FK_Especialidades_TiposEspecialidades] FOREIGN KEY([Tipo])
REFERENCES [SHARPS].[TiposEspecialidades] ([Codigo])
GO
ALTER TABLE [SHARPS].[Especialidades] CHECK CONSTRAINT [FK_Especialidades_TiposEspecialidades]
GO

ALTER TABLE [SHARPS].[ProfesionalesEspecialidades]  WITH CHECK ADD  CONSTRAINT [FK_ProfesionalesEspecialidades_Especialidades] FOREIGN KEY([Especialidad])
REFERENCES [SHARPS].[Especialidades] ([Codigo])
GO
ALTER TABLE [SHARPS].[ProfesionalesEspecialidades] CHECK CONSTRAINT [FK_ProfesionalesEspecialidades_Especialidades]
GO

ALTER TABLE [SHARPS].[DetallesPersona]  WITH CHECK ADD  CONSTRAINT [FK_DetallesPersona_Usuarios] FOREIGN KEY([UsuarioID])
REFERENCES [SHARPS].[Usuarios] ([UsuarioID])
GO
ALTER TABLE [SHARPS].[DetallesPersona] CHECK CONSTRAINT [FK_DetallesPersona_Usuarios]
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

--ALTER TABLE [SHARPS].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_UsuariosRoles] FOREIGN KEY([username])
--REFERENCES [SHARPS].[UsuariosRoles] ([usuario])
--GO
--ALTER TABLE [SHARPS].[Usuarios]  CHECK CONSTRAINT [FK_Usuarios_UsuariosRoles]
--GO

ALTER TABLE [SHARPS].[UsuariosRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsuariosRoles_Roles] FOREIGN KEY([Rol])
REFERENCES [SHARPS].[Roles] ([RolID])
GO
ALTER TABLE [SHARPS].[UsuariosRoles] CHECK CONSTRAINT [FK_UsuariosRoles_Roles]
GO

ALTER TABLE [SHARPS].[RolesFuncionalidades]  WITH CHECK ADD  CONSTRAINT [FK_RolesFuncionalidades_Roles] FOREIGN KEY([Rol])
REFERENCES [SHARPS].[Roles] ([RolID])
GO
ALTER TABLE [SHARPS].[RolesFuncionalidades] CHECK CONSTRAINT [FK_RolesFuncionalidades_Roles]
GO

ALTER TABLE [SHARPS].[RolesFuncionalidades]  WITH CHECK ADD  CONSTRAINT [FK_RolesFuncionalidades_Funcionalidades] FOREIGN KEY([Funcionalidad])
REFERENCES [SHARPS].[Funcionalidades] ([Codigo])
GO
ALTER TABLE [SHARPS].[RolesFuncionalidades] CHECK CONSTRAINT [FK_RolesFuncionalidades_Funcionalidades]
GO

ALTER TABLE [SHARPS].[PerfilesFuncionalidades]  WITH CHECK ADD  CONSTRAINT [FK_PerfilesFuncionalidades_Funcionalidades] FOREIGN KEY([Funcionalidad])
REFERENCES [SHARPS].[Funcionalidades] ([Codigo])
GO
ALTER TABLE [SHARPS].[PerfilesFuncionalidades] CHECK CONSTRAINT [FK_PerfilesFuncionalidades_Funcionalidades]
GO

ALTER TABLE [SHARPS].[Roles]  WITH CHECK ADD  CONSTRAINT [FK_Roles_Perfiles] FOREIGN KEY([Perfil])
REFERENCES [SHARPS].[Perfiles] ([PerfilID])
GO
ALTER TABLE [SHARPS].[Roles] CHECK CONSTRAINT [FK_Roles_Perfiles]
GO

ALTER TABLE [SHARPS].[PerfilesFuncionalidades]  WITH CHECK ADD  CONSTRAINT [FK_PerfilesFuncionalidades_Perfiles] FOREIGN KEY([Perfil])
REFERENCES [SHARPS].[Perfiles] ([PerfilID])
GO
ALTER TABLE [SHARPS].[PerfilesFuncionalidades] CHECK CONSTRAINT [FK_PerfilesFuncionalidades_Perfiles]
GO
