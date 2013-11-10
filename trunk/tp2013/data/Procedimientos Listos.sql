CREATE PROCEDURE [SHARPS].UpdateUserPassword
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
		WHERE idUser = @ID_Usuario
	END

END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE SHARPS.Login
	@Nombre nvarchar(255),
	@Password nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT idUser FROM Usuarios WHERE
	username = @Nombre AND password = @Password AND Activo = 1
	
	IF @@ROWCOUNT = 0
		BEGIN
			UPDATE Usuarios SET intentos = intentos + 1
			WHERE username = @Nombre
		END
	ELSE
		BEGIN
			UPDATE Usuarios SET intentos = 0
			WHERE username = @Nombre
		END
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

use GD2C2013

CREATE PROCEDURE [GetAfiliadoInfo] 
(
@userId INT
)
AS 
BEGIN
select distinct u.username UserName , pm.codigo Plan_ID , pm.Precio_Bono_Consulta PrecioConsulta, pm.Precio_Bono_Farmacia PrecioFarmacia, a.cantHijos CantHijos, ((a.GrupoFamiliar*100)+a.tipoAfiliado) nroAfiliado, a.estadoCivil EstadoCivil, dp.apellido Apellido, dp.nombre Nombre, dp.sexo Sexo
, dp.mail Email,dp.fechaNac FechaNacimiento, dp.TipoDNI TipoDoc, dp.telefono Telefono, dp.direccion Direccion, dp.dni DNI
from [SHARPS].Usuarios u
inner join [SHARPS].Afiliados a on a.usuarioID = @userId
inner join [SHARPS].Planes_Medicos pm on pm.codigo = a.planMedico
inner join [SHARPS].Detalles_Persona dp on dp.usuarioID = @userId
WHERE u.usuarioID = @userId
END



CREATE PROCEDURE [GetAfiliados]

AS
BEGIN
	select distinct u.username UserName , pm.codigo Plan_ID , pm.Precio_Bono_Consulta PrecioConsulta, pm.Precio_Bono_Farmacia PrecioFarmacia, a.cantHijos CantHijos, ((a.GrupoFamiliar*100)+a.tipoAfiliado) nroAfiliado, a.estadoCivil EstadoCivil, dp.apellido Apellido, dp.nombre Nombre, dp.sexo Sexo
	, dp.mail Email,dp.fechaNac FechaNacimiento, dp.TipoDNI TipoDoc, dp.telefono Telefono, dp.direccion Direccion, dp.dni DNI
	from Usuarios u
	inner join Afiliados a on a.usuarioID = u.usuarioID
	inner join Planes_Medicos pm on pm.codigo = a.planMedico
	inner join Detalles_Persona dp on dp.usuarioID = u.usuarioID

END


create procedure [InsertAfiliado]
@PlanMedico numeric(18,0),
@ID numeric (18,0),
@EstadoCivil nchar(10),
@CantHijos int

as 
begin  transaction 
declare @NroAfiliado int
declare @codCivil int
select @codCivil = Codigo from [SHARPS].Estados_Civiles where Descripcion = @EstadoCivil
SELECT @NroAfiliado = MAX(GrupoFamiliar) + 101 FROM [SHARPS].Afiliados
insert into [SHARPS].Afiliados (GrupoFamiliar , planMedico , cantHijos , estadoCivil , UsuarioID)
values (@NroAfiliado , @PlanMedico , @CantHijos ,@codCivil  , @ID) 
commit transaction 



create procedure [InsertMiembroGrupoFamiliar]
@PlanMedico numeric(18,0),
@ID numeric (18,0),
@EstadoCivil nchar(10),
@CantHijos int,
@NroAfiliado numeric(18,0),
@RolAfiliado numeric(10,2) -----?????

as
begin
insert into Afiliados (nroAfiliado , planMedico , cantHijos , estadoCivil , userId)
values (@NroAfiliado + 1 , @PlanMedico , @CantHijos , @EstadoCivil , @ID) 
end 
go



create procedure [UpdateAfiliado]

@PlanMedico numeric(18,0),
@ID numeric (18,0),
@EstadoCivil nchar(10),
@CantHijos int,
@RolAfiliado numeric(10,2), 
@Motivo char(10)
as 
begin
declare @nroAfiliado int
select @nroAfiliado = a.GrupoFamiliar from SHARPS.Afiliados a where a.UsuarioID = @ID
update [SHARPS].Afiliados set planMedico = @PlanMedico , estadoCivil = @EstadoCivil , cantHijos = @CantHijos 
where usuarioId = @ID
insert into [SHARPS].Cambios_Afiliado(Motivo_Cambio , Fecha , Afiliado)
values (@Motivo , GETDATE() ,@nroAfiliado )

end
go


create function [GetProfesionalInfo]
( @userId numeric(18,0)
)


returns table
as 
return

select distinct u.username UserName , a.matricula matricula,  dp.apellido Apellido, dp.nombre Nombre, dp.sexo Sexo
, dp.mail Email,dp.fechaNac FechaNacimiento, dp.tipo TipoDoc, dp.telefono Telefono, dp.direccion Direccion, dp.dni DNI
from Usuarios u
inner join Medicos a on a.userId = @userId
inner join Detalles_Persona dp on dp.userId = @userId
where u.idUser = @userId




create procedure [GetProfesionales]

as
begin
select [GetProfesionalInfo]( u.idUser ) ---ver si se puede hacer
from Usuarios u
inner join Medicos m on m.userId =  u.idUser
end





create function [GetRolesByPerfil]
(
@nombrePerfil nchar(255)
)

returns table
as 
return
select r.idRol ID , r.descripRol Descripcion 
from Perfil p 
inner join Roles r on r.perfil = p.idPerfil
where p.detallesPerf = @nombrePerfil





create procedure [InsertDetallePersona]

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

as
begin
insert into [SHARPS].Detalles_Persona (telefono ,TipoDNI , sexo, UsuarioID , direccion , apellido , nombre , mail , fechaNac,dni)
values ( @Telefono , @TipoDNI , @Sexo , @ID_Usuario , @Direccion , @Apellido , @Nombre , @Email , @FechaNacimiento , @DNI)

end 
go


create procedure [UpdateDetallePersona]

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

as
begin

update [SHARPS].Detalles_Persona set
telefono = @Telefono , mail = @Email , nombre = @Nombre , apellido = @Apellido , direccion = @Direccion 
, dni = @DNI , tipoDNI = @TipoDNI  , sexo = @Sexo , fechaNac = @FechaNacimiento
where @ID_Usuario = UsuarioID

end
go


create procedure [GetRoles]


as 
begin
select [GetRolesByPerfil](detallesPerfil)
from Perfil
end 
go



create procedure[InsertRole]
@Description nchar(10)
as
begin

insert into Roles (descripRol)
values( @Description )

end
go


create procedure [UpdateRole]
@Description nchar(10),
@ID numeric(10,2)

as
begin

update Roles set
descripRol = @Description
where idRol = @ID

end
go



create procedure [DeleteRole]

@Description nchar(10)

as 
begin

delete Roles where descripRol = @Description

end 
go


--- cuando mandes cambios de especialidades , borrar todo lo relacionado con el medico y insert lo nuevo.







--------------------------------------------------------------

CREATE PROCEDURE [UpdateDetallePersona]

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


CREATE PROCEDURE [InsertDetallePersona]

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





CREATE PROCEDURE [InsertAfiliado]
@PlanMedico numeric(18,0),
@ID numeric (18,0),
@EstadoCivil nchar(10),
@CantHijos int

AS 
BEGIN  TRANSACTION 
DECLARE @NroAfiliado int
DECLARE @codCivil int
SELECT @codCivil = Codigo from [SHARPS].Estados_Civiles where Descripcion = @EstadoCivil
SELECT @NroAfiliado = MAX(GrupoFamiliar) + 101 FROM [SHARPS].Afiliados
INSERT INTO [SHARPS].Afiliados (GrupoFamiliar , planMedico , cantHijos , estadoCivil , UsuarioID)
VALUES (@NroAfiliado , @PlanMedico , @CantHijos ,@codCivil  , @ID) 
COMMIT TRANSACTION 


CREATE PROCEDURE [UpdateAfiliado]

@PlanMedico numeric(18,0),
@ID numeric (18,0),
@EstadoCivil nchar(10),
@CantHijos int,
@RolAfiliado numeric(10,2), 
@Motivo char(10)
AS 
BEGIN
DECLARE @nroAfiliado int
SELECT @nroAfiliado = a.GrupoFamiliar from SHARPS.Afiliados a WHERE a.UsuarioID = @ID
UPDATE [SHARPS].Afiliados set planMedico = @PlanMedico , estadoCivil = @EstadoCivil , cantHijos = @CantHijos 
WHERE usuarioId = @ID
INSERT INTO [SHARPS].Cambios_Afiliado(Motivo_Cambio , Fecha , Afiliado)
VALUES (@Motivo , GETDATE() ,@nroAfiliado )

END
GO


CREATE PROCEDURE InsertMiembroGrupoFamiliar
@PlanMedico int,
@ID int,
@EstadoCivil int,
@CantHijos int,
@RolAfiliado nvarchar(MAX),
@nroAfiliado int   -------------sera grupo familiar
AS
BEGIN TRANSACTION

INSERT INTO [SHARPS].Afiliados (GrupoFamiliar , UsuarioID , TipoAfiliado , CantHijos , Activo , PlanMedico )
VALUES (@nroAfiliado +1 , @ID , NULL , @CantHijos ,1 , @PlanMedico)----VER LO DEL +1 YA QUE HAY CAMPO TIPO DE AFILIADO

INSERT INTO [SHARPS].Usuarios_Roles (Usuario, Rol) 
VALUES (@ID , @RolAfiliado)

UPDATE [SHARPS].Roles SET  Descripcion = 'Afiliado' , Activo = 1, Perfil = 1
WHERE RolID = @RolAfiliado



COMMIT TRANSACTION


CREATE PROCEDURE [SHARPS].InsertProfesional
@Matricula  int,
@ID int,
@Rol int

AS
BEGIN TRANSACTION
INSERT INTO Profesionales (Matricula , Activo , UsuarioID)
VALUES (@Matricula , 1 , @ID)

INSERT INTO [SHARPS].Usuarios_Roles (Usuario, Rol) --CREA UN NUEVO PROFESIONAL PERO YA ME DA EL NROL QUE VA A TENER?
VALUES (@ID , @Rol)

UPDATE [SHARPS].Roles SET  Descripcion = 'Profesional' , Activo = 1, Perfil = 2
WHERE RolID = @Rol 

COMMIT TRANSACTION



CREATE PROCEDURE [SHARPS].UpdateProfesional
@Matricula int,
@ID int

AS
BEGIN

UPDATE [SHARPS].Profesionales SET Matricula = @Matricula 
WHERE UsuarioID = @ID 

END
GO


CREATE PROCEDURE [SHARPS].InsertSpeciality
@MedicoID int,
@Especialidad int

AS
BEGIN
INSERT INTO [SHARPS].Profesionales_Especialidades (Profesional , Especialidad) VALUES (@MedicoID , @Especialidad)
/*SELECT TOP 1  @MedicoID , E.Codigo
FROM Especialidades E
WHERE E.Descripcion = @Especialidad*/

END
GO


CREATE PROCEDURE [SHARPS].CancelarDiaProfesional
@MedicoID int,
@Fecha date

AS
BEGIN



UPDATE [SHARPS].Estados_Turno
SET MotivoCancelacion = 'cancelacion medico'  ---<---  REVISAR
,Descripcion ='cancelado'
FROM [SHARPS].Estados_Turno ET
INNER JOIN Agendas A  ON A.AgendaID = @MedicoID
INNER JOIN  [SHARPS].Turnos T ON T.Estado = ET.Estado
WHERE T.Agenda = A.AgendaID AND CONVERT(CHAR(10), T.FechaHoraLlegada ,112) = @Fecha

END
GO


CREATE PROCEDURE [SHARPS].GetBonos

@userId int

AS
BEGIN

SELECT BC.Fecha_Impresion AS Fecha , BC.NumeroDeBono AS Numero , P.Precio_Bono_Consulta AS Precio
FROM [SHARPS].BonosConsulta BC
INNER JOIN Planes_Medicos P ON P.Codigo = BC.PlanMedico
WHERE BC.Afiliado_Compro = @userId
UNION
SELECT BF.Fecha_Impresion AS Fecha, BF.NumeroDeBono AS Numero ,P.Precio_Bono_Farmacia AS Precio
FROM [SHARPS].BonosFarmacia BF
INNER JOIN Planes_Medicos P ON P.Codigo = BF.PlanMedico
WHERE BF.Afiliado_Compro = @userId



END
GO



CREATE PROCEDURE [SHARPS].ComprarBonoConsulta
@Precio INT,
@AfiliadoCompro INT,
@Fecha DATE
AS 
BEGIN
DECLARE @NUMEROBONO INT
DECLARE @PLAN INT
SELECT @PLAN = A.PlanMedico FROM Afiliados A WHERE A.UsuarioID = @AfiliadoCompro
SELECT @NUMEROBONO = MAX(NumeroDeBono) + 1 FROM [SHARPS].Bonos_Consulta 
INSERT INTO [SHARPS].Bonos_Consulta (NumeroDeBono,PlanMedico,Fecha_Impresion,Afiliado_Compro)
VALUES (@NUMEROBONO , @PLAN , @Fecha , @AfiliadoCompro)
END
GO



CREATE PROCEDURE [SHARPS].ComprarBonoReceta --<-- TERMINAR DE REVISAR
@Precio INT,
@AfiliadoCompro INT,
@Fecha DATE
AS 
BEGIN
DECLARE @NUMEROBONO INT
DECLARE @PLAN INT
SELECT @PLAN = A.PlanMedico FROM Afiliados A WHERE A.UsuarioID = @AfiliadoCompro
SELECT @NUMEROBONO = MAX(NumeroDeBono) + 1 FROM [SHARPS].Bonos_Farmacia
INSERT INTO [SHARPS].Bonos_Farmacia(NumeroDeBono,PlanMedico,Fecha_Impresion,Afiliado_Compro)
VALUES (@NUMEROBONO , @PLAN , @Fecha , @AfiliadoCompro)
END
GO



CREATE PROCEDURE [SHARPS].GetTurnos
@userId INT


AS
BEGIN

SELECT T.FechaHoraLlegada as Fecha ,T.Numero as Numero ,A.Profesional AS UserProfesional ,P.Matricula AS Matricula
FROM Turnos T
INNER JOIN Agendas A ON A.AgendaID = T.Agenda
INNER JOIN Profesionales P ON P.UsuarioID = A.Profesional
WHERE T.Afiliado = @userId

END
GO



CREATE PROCEDURE [SHARPS].GetTurnos
@profesionalID INT,
@fecha DATE

AS
BEGIN

SELECT Hora , Minuto, CONVERT(CHAR(10), T.FechaHoraLlegada ,112) AS Fecha ------<<--------terminar
FROM Turnos T
INNER JOIN Agendas A ON A.Profesional = @profesionalID
WHERE A.AgendaID = T.Agenda

END
GO


CREATE PROCEDURE [SHARPS].InsertTurno
@Fecha DATE,
@Profesional_ID INT,
@Afiliado_ID INT

AS
BEGIN

DECLARE @IDAGENDA INT
DECLARE @ESTADO INT
DECLARE @NUMERO INT
SELECT @NUMERO = MAX(Numero) + 1 FROM [SHARPS].Turnos
SELECT @IDAGENDA = AgendaID FROM [SHARPS].Agendas A WHERE A.Profesional = @Profesional_ID
INSERT INTO [SHARPS].Estados_Turno (Descripcion, MotivoCancelacion)
VALUES (NULL,NULL)
SELECT @ESTADO = MAX(Estado)FROM [SHARPS].Estados_Turno


INSERT INTO [SHARPS].Turnos (Numero , Afiliado , Estado , FechaHoraLlegada , Agenda )
VALUES (@NUMERO , @Afiliado_ID, @ESTADO, @Fecha,@IDAGENDA)
END
GO 


