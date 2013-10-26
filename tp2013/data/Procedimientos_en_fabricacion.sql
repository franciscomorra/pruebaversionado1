CREATE PROCEDURE [Sharps].[UpdateUserPassword]
	@ID_Usuario int,
	@OldPassword nvarchar(255),
	@NewPassword nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;

    SELECT 1 FROM Usuarios
	WHERE idUser = @ID_Usuario AND password = @OldPassword

	IF @@ROWCOUNT = 1
	BEGIN
		UPDATE Usuarios 
		SET password = @NewPassword
		WHERE isUser = @ID_Usuario
	END

END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [Sharps].[Login]
	@Nombre nvarchar(255),
	@Password nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT ID, ID_Rol, Nombre FROM Usuarios WHERE
	idUser = @Nombre AND password = @Password AND Activo = 1
	
	IF @@ROWCOUNT = 0
		BEGIN
			UPDATE Usuarios SET intentos = intentos + 1
			WHERE idUser = @Nombre
		END
	ELSE
		BEGIN
			UPDATE Usuarios SET intentos = 0
			WHERE Nombre = @Nombre
		END
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [Sharps].[InsertUser]
	@password nvarchar(10),
	@username nchar(10),
	@idUser numeric(18)
AS
BEGIN
	SELECT @idUser = MAX(iduser) + 1 FROM Usuarios
	IF @idUser IS NULL
		SET @iduser = 1
	
	INSERT INTO Usuarios (@idUser , @username, password, Activo, Intentos) VALUES
	(@idUser , @username, @password, 1, 0)
	
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [Sharps].[InsertRoleFunctionality]
	@rol int,
	@funcionalidad nvarchar(255)
AS
BEGIN
	INSERT INTO Roles_Func (rol, funcionalidad)
	VALUES (@rol, [Sharps].[GetFunctionalityByName](@funcionalidad)) -------Crear la funcion getfunctionality by tipo
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [Sharps].[Updateafiliado]  
   @nroAfiliado numeric(18,0), ---se va poder cambiar?
   @detalles numeric(18), ---se va poder cambiar?
   @plan numeric(18),
   @estadoCivil nchar(10),
   @cantHijos int,
   @tipoAfiliado int,

AS
BEGIN
	
	
	UPDATE Detalle_persona SET  
	idPersona = @detalles ------MODIFICAR
	WHERE idPersona = @detalles
	
	UPDATE Afiliados SET
	detalles = @detalles, plan = @plan, estadoCivil = @estadoCivil, cantHijos = @cantHijos
	WHERE nroAfiliado = @nroAfiliado

    	
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Afiliado].[InsertAfiliado]  
	@nroAfiliado numeric(18,0),
	@detalles numeric(18,0),
	@plan numeric(18,0),
	@estadoCivil nchar(10),
	@cantHijos int,
	@tipo
AS
BEGIN
	
	SELECT @nroAfiliado = MAX(nroAfiliado) + 1 FROM Afiliados
	
	INSERT INTO Afiliados(nroAfiliado, detalles, plan, activoAfiliado, estadoCivil, cantHijos , tipoAfiliado) VALUES 
	(@nroAfiliado, @detalles, @plan, 1, @estadoCivil, @cantHijos)----REVisar detalles
	
	
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Sharps].[InsertBono]   
	@numeroBono numeric(18,0),
	@afiliadoCompro bit,
	@tipoBono nchar(10),
	@plan numeric(18),
	
AS
BEGIN
	
    SELECT @numeroBono = MAX(numeroBono) + 1 FROM Bonos
	INSERT INTO Bonos
	   (numeroBono, fechaImp, afiliadoCompro, tipoBono, plan)
	 VALUES
	   (@numeroBono, GETDATE(), @afiliadoCompro, @tipoBono,	@plan)
	
	
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [Sharps].[InsertTurno] 
	@numero numeric(18,0),
	@medico numeric(18,0),
	@afiliado numeric(18,0),
	@fechaHora datetime,
	@estado numeric(18,0),
	@fechaHoraLlegada datetime,
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @numero numeric(18,0)
	SELECT @numero = MAX(numero) + 1 FROM Turnos
	
	IF @numero IS NULL
		SET @numero = 1

	INSERT INTO Turnos(numero, medico, afiliado, fechaHora, estado, fechaHoraLlegada)
	VALUES (@numero,
	@medico,
	@afiliado,
	GETDATE(),----ver i incluye la hora
	@estado,
	@fechaHoraLlegada)
	
	
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [Sharps].[InsertDetalleEntidad] 
	@Telefono numeric(18,0),
	@mail nvarchar(255),
	@tipo nvarchar(255),
	@Direccion nvarchar(255),
	@sexo char,
	@apellido nvarchar(255),
	@nombre nvarchar (255),
	@fechaNac date
AS
BEGIN
	DECLARE @DetalleEntidad int
	SET NOCOUNT ON;
	INSERT INTO Detalles_Persona(Telefono, mail, dni ,tipo,direccion,sexo,apellido,nombre,fechaNac) VALUES 
	(@Telefono, @mail, @dni, @tipo , @Direccion , @sexo , @apellido , @nombre , @fechaNac)
	
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE[Sharps].[UpdateDetalleEntidad] 
	@telefono numeric(18,0),
	@mail nvarchar(255),
	@idpersona numeric(18,0),
	@direccion nvarchar(255),
	@nombre varchar(255),
	@apellido varchar(255),
	@sexo char(10),
	@tipo varchar(255),
	@dni numeric(18,0)
AS
BEGIN
	DECLARE @DetalleEntidad int
	
	UPDATE Detalles_Persona SET 
	telefono = @telefono, mail = @mail, dni = @dni, direccion = @direccion, nombre = @nombre, apellido = @apellido, sexo = @sexo, tipo = @tipo
	WHERE userId = @idPersona
	
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [Sharps].[InsertReceta] 
	@bonoConsulta nchar(10),
	@bonoFarmacia nchar(10)
AS
BEGIN
	INSERT INTO Receta
	   (bonoConsulta, bonoFarmacia)
	 VALUES
	   (@bonoConsulta, @bonoFarmacia)
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO


CREATE PROCEDURE [Sharps].[InhabilitarAfiliado]---falta modificar mucho
 @nroAfiliado numeric(18,0)

 AS
 BEGIN

 UPDATE Afiliados SET
 activoAfiliado = 0
 WHERE   nroAfiliado = @nroAfiliado

 END
GO

CREATE PROCEDURE [Sharps].[InsertProfesionalNuevo]
	@matricula numeric(18,0),
	@detalles numeric(18,0),
	@especialidad numeric(18,0),
	@descripcionEsp varchar(255),
	@tipoEsp numeric(18,0),
	@descripcionEsp varchar(255),
AS
BEGIN
	
	INSERT INTO Medicos(matricula, detalles, activoMedico) VALUES 
	(@matricula, @detalles, 1)
	
	INSERT INTO Medicos_Esp(medico , especialidad) VALUES
	(@matricula, @especialidad)

	INSERT INTO Especialidades(codigoEspecialidad, descripcionEsp, tipoEsp) VALUES
	(@especialidad, @descripcionEsp, @tipoEsp)

	INSERT INTO Tipos_Especialidades(codigoEsp , descripcionEsp) VALUES
	(@tipoEsp, @descripcionEsp)

 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [ClinicaFrba].[UpdateProfesional]
@matricula numeric(18,0),
@detalles numeric(18,0) ---MOdificar

AS
BEGIN
UPDATE Detalles_Persona SET
idpersona = @detalles
WHERE idpersona = @detalles 

UPDATE Medicos SET
matricula = @matricula
detalles = @detalles
WHERE matricula = @matricula

END


CREATE PROCEDURE [Sharps].[insertConsulta]
 @turno numeric(18,0),
 @bono numeric(18,0),
 @sintomas varchar(255),
 @enfermedad varchar(255)  

AS
BEGIN

INSERT INTO Consulta (turno, bono, sintomas, enfermedad) VALUES
(@turno, @bono, @sintomas, @enfermedad )
  
END
GO 




