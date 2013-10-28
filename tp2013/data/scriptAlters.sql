ALTER TABLE [SHARPS].[Usuarios] ADD  CONSTRAINT [DF_Usuarios_intentos]  DEFAULT ((0)) FOR [intentos]
GO

ALTER TABLE [SHARPS].[Usuarios] ADD  CONSTRAINT [DF_Usuarios_activo]  DEFAULT ((1)) FOR [activo]
GO

ALTER TABLE [SHARPS].[Rol] ADD  CONSTRAINT [DF_Rol_activoRol]  DEFAULT ((1)) FOR [activoRol]
GO

ALTER TABLE [SHARPS].[Medico] ADD  CONSTRAINT [DF_Medico_activoMedico]  DEFAULT ((1)) FOR [activoMedico]
GO

ALTER TABLE [SHARPS].[Afiliado] ADD  CONSTRAINT [DF_Afiliado_activoAfiliado]  DEFAULT ((1)) FOR [activoAfiliado]
GO

ALTER TABLE [SHARPS].[Receta]  WITH CHECK ADD  CONSTRAINT [FK_Receta_RecetasMedicamen] FOREIGN KEY([bonoFarmacia])
REFERENCES [SHARPS].[RecetasMedicamen] ([receta])
GO
ALTER TABLE [SHARPS].[Receta] CHECK CONSTRAINT [FK_Receta_RecetasMedicamen]
GO

ALTER TABLE [SHARPS].[RecetasMedicamen]  WITH CHECK ADD  CONSTRAINT [FK_RecetasMedicamen_Medicamentos] FOREIGN KEY([medicamento])
REFERENCES [SHARPS].[Medicamentos] ([idMedic])
GO
ALTER TABLE [SHARPS].[RecetasMedicamen] CHECK CONSTRAINT [FK_RecetasMedicamen_Medicamentos]
GO

ALTER TABLE [SHARPS].[Consulta]  WITH CHECK ADD  CONSTRAINT [FK_Consulta_Turno] FOREIGN KEY([turno])
REFERENCES [SHARPS].[Turno] ([numero])
GO
ALTER TABLE [SHARPS].[Consulta] CHECK CONSTRAINT [FK_RecetasMedicamen_Consulta]
GO

ALTER TABLE [SHARPS].[Turnos]  WITH CHECK ADD  CONSTRAINT [FK_Turnos_Estadosturno] FOREIGN KEY([estado])
REFERENCES [SHARPS].[Turno] ([idEstado])
GO
ALTER TABLE [SHARPS].[Turnos] CHECK CONSTRAINT [FK_Turnos_Estadosturno]
GO

ALTER TABLE [SHARPS].[Consulta]  WITH CHECK ADD  CONSTRAINT [FK_Consulta_Bono] FOREIGN KEY([bono])
REFERENCES [SHARPS].[Bono] ([numeroBono])
GO
ALTER TABLE [SHARPS].[Consulta] CHECK CONSTRAINT [FK_Consulta_Bono]
GO

ALTER TABLE [SHARPS].[Afiliado]  WITH CHECK ADD  CONSTRAINT [FK_Afliado_PlanesMedicos] FOREIGN KEY([planMedico])
REFERENCES [SHARPS].[PlanesMedicos] ([codigo])
GO
ALTER TABLE [SHARPS].[Afiliado] CHECK CONSTRAINT [FK_Afiliado_PlanesMedicos]
GO

ALTER TABLE [SHARPS].[CambiosAfiliado]  WITH CHECK ADD  CONSTRAINT [FK_CambiosAfiliado_Afiliados] FOREIGN KEY([afiliado])
REFERENCES [SHARPS].[Afiliados] ([nroAfiliado])
GO
ALTER TABLE [SHARPS].[CambiosAfiliado] CHECK CONSTRAINT [FK_CambiosAfiliado_Afiliados]
GO

ALTER TABLE [SHARPS].[Turnos]  WITH CHECK ADD  CONSTRAINT [FK_Turnos_Afiliados] FOREIGN KEY([afiliado])
REFERENCES [SHARPS].[Afiliados] ([nroAfiliado])
GO
ALTER TABLE [SHARPS].[Turnos] CHECK CONSTRAINT [FK_Turnos_Afiliados]
GO

ALTER TABLE [SHARPS].[Agendas]  WITH CHECK ADD  CONSTRAINT [FK_Agendas_Medicos] FOREIGN KEY([medico])
REFERENCES [SHARPS].[Medicos] ([matricula])
GO
ALTER TABLE [SHARPS].[Agendas] CHECK CONSTRAINT [FK_Agendas_Medicos]
GO

ALTER TABLE [SHARPS].[MedicosEsp]  WITH CHECK ADD  CONSTRAINT [FK_MedicosEsp_Medicos] FOREIGN KEY([medico])
REFERENCES [SHARPS].[Medicos] ([matricula])
GO
ALTER TABLE [SHARPS].[MedicosEsp] CHECK CONSTRAINT [FK_MedicosEsp_Medicos]
GO

ALTER TABLE [SHARPS].[Agendas]  WITH CHECK ADD  CONSTRAINT [FK_Agendas_DiasLaborales] FOREIGN KEY([dia])
REFERENCES [SHARPS].[DiasLaborables] ([fecha])
GO
ALTER TABLE [SHARPS].[Agendas] CHECK CONSTRAINT [FK_Agendas_DiasLaborales]
GO

ALTER TABLE [SHARPS].[Especialidades]  WITH CHECK ADD  CONSTRAINT [FK_Especialidades_TiposEspecialidad] FOREIGN KEY([tipoEsp])
REFERENCES [SHARPS].[TiposEspecialidad] ([codigoEsp])
GO
ALTER TABLE [SHARPS].[Especialidades] CHECK CONSTRAINT [FK_Especialidades_TiposEspecialidad]
GO

ALTER TABLE [SHARPS].[MedicosEsp]  WITH CHECK ADD  CONSTRAINT [FK_MedicosEsp_Especialidades] FOREIGN KEY([especialidad])
REFERENCES [SHARPS].[Especialidades] ([codigoEspecialidad])
GO
ALTER TABLE [SHARPS].[MedicosEsp] CHECK CONSTRAINT [FK_MedicosEsp_Especialidades]
GO

ALTER TABLE [SHARPS].[DetallesPersona]  WITH CHECK ADD  CONSTRAINT [FK_DetallesPersona_Usuarios] FOREIGN KEY([userId])
REFERENCES [SHARPS].[Usuarios] ([idUser])
GO
ALTER TABLE [SHARPS].[DetallesPersona] CHECK CONSTRAINT [FK_DetallesPersona_Usuarios]
GO

ALTER TABLE [SHARPS].[Afiliados]  WITH CHECK ADD  CONSTRAINT [FK_Afiliados_Usuarios] FOREIGN KEY([userId])
REFERENCES [SHARPS].[Usuarios] ([idUser])
GO
ALTER TABLE [SHARPS].[Afiliados] CHECK CONSTRAINT [FK_Afiliados_Usuarios]
GO

ALTER TABLE [SHARPS].[Medicos]  WITH CHECK ADD  CONSTRAINT [FK_Medicos_Usuarios] FOREIGN KEY([userId])
REFERENCES [SHARPS].[Usuarios] ([idUser])
GO
ALTER TABLE [SHARPS].[Medicos] CHECK CONSTRAINT [FK_Medicos_Usuarios]
GO

ALTER TABLE [SHARPS].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_UsuariosRoles] FOREIGN KEY([username])
REFERENCES [SHARPS].[UsuariosRoles] ([usuario])
GO
ALTER TABLE [SHARPS].[Usuarios]  CHECK CONSTRAINT [FK_Usuarios_UsuariosRoles]
GO

ALTER TABLE [SHARPS].[UsuariosRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsuariosRoles_Rol] FOREIGN KEY([rol])
REFERENCES [SHARPS].[Rol] ([idRol])
GO
ALTER TABLE [SHARPS].[UsuariosRoles] CHECK CONSTRAINT [FK_UsuariosRoles_Rol]
GO

ALTER TABLE [SHARPS].[RolesFunc]  WITH CHECK ADD  CONSTRAINT [FK_RolesFunc_Rol] FOREIGN KEY([rol])
REFERENCES [SHARPS].[Rol] ([idRol])
GO
ALTER TABLE [SHARPS].[RolesFunc] CHECK CONSTRAINT [FK_RolesFunc_Rol]
GO

ALTER TABLE [SHARPS].[RolesFunc]  WITH CHECK ADD  CONSTRAINT [FK_RolesFunc_Funcionalidades] FOREIGN KEY([funcionalidad])
REFERENCES [SHARPS].[Funcionalidades] ([idFunc])
GO
ALTER TABLE [SHARPS].[RolesFunc] CHECK CONSTRAINT [FK_RolesFunc_Funcionalidades]
GO

ALTER TABLE [SHARPS].[PerfilFunc]  WITH CHECK ADD  CONSTRAINT [FK_PerfilFunc_Funcionalidades] FOREIGN KEY([funcion])
REFERENCES [SHARPS].[Funcionalidades] ([idFunc])
GO
ALTER TABLE [SHARPS].[PerfilFunc] CHECK CONSTRAINT [FK_PerfilFunc_Funcionalidades]
GO

ALTER TABLE [SHARPS].[Roles]  WITH CHECK ADD  CONSTRAINT [FK_Roles_Perfil] FOREIGN KEY([perfil])
REFERENCES [SHARPS].[Perfil] ([idPerfil])
GO
ALTER TABLE [SHARPS].[Roles] CHECK CONSTRAINT [FK_Roles_Perfil]
GO

ALTER TABLE [SHARPS].[PerfilFunc]  WITH CHECK ADD  CONSTRAINT [FK_PerfilFunc_Perfil] FOREIGN KEY([perfil])
REFERENCES [SHARPS].[Perfil] ([idPerfil])
GO
ALTER TABLE [SHARPS].[PerfilFunc] CHECK CONSTRAINT [FK_PerfilFunc_Perfil]
GO
