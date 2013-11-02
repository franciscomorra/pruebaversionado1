USE [GD2C2013]
GO

/****** Object:  StoredProcedure [dbo].[GetRoleFunctionalities]    Script Date: 11/02/2013 16:53:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetRoleFunctionalities]
	@Rol_ID int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT F.Descripcion FROM Funcionalidades F
	INNER JOIN Roles_Funcionalidades RF ON F.Codigo = RF.Funcionalidad
	WHERE RF.Rol = @Rol_ID
END

GO

/****** Object:  StoredProcedure [dbo].[GetUserLoginAttempts]    Script Date: 11/02/2013 16:53:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserLoginAttempts]
	@Nombre nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Intentos FROM Usuarios WHERE username = @Nombre
	IF(@@ROWCOUNT = 0)
		SELECT 0 AS Intentos
END

GO

/****** Object:  StoredProcedure [dbo].[GetUserRoles]    Script Date: 11/02/2013 16:54:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserRoles] 
@userID int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT r.RolID as ID, r.Descripcion, r.Perfil as PerfilId, p.Descripcion as PerfilNombre
	FROM Roles r
	INNER JOIN Usuarios_Roles ur ON ur.Rol = r.RolID
	INNER JOIN Perfiles p on p.PerfilID = r.Perfil
	WHERE ur.usuario = @userID

END
	
GO

/****** Object:  StoredProcedure [dbo].[Login]    Script Date: 11/02/2013 16:54:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Login]
	@Nombre nvarchar(255),
	@Password nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT UsuarioID as ID, username as Nombre, activo as estado FROM Usuarios WHERE
	username = @Nombre AND Password = @Password AND Activo = 1
	
	IF @@ROWCOUNT = 0
		BEGIN
			UPDATE Usuarios SET Intentos = Intentos + 1
			WHERE username = @Nombre
		END
	ELSE
		BEGIN
			UPDATE Usuarios SET Intentos = 0
			WHERE username = @Nombre
		END
END

GO