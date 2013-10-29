CREATE PROCEDURE SHARPS.UpdateUserPassword
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


Create function [SHARPS].[GetAfiliadoInfo] 
(
@userId numeric (18,0)
)
returns table
as 
return

select u.username UserName , pm.codigo Plan_ID , pm.precioConsulta PrecioConsulta, pm.precioFarmacia PrecioFarmacia, a.cantHijos CantHijos, a.nroAfiliado nroAfiliado, a.estadoCivil EstadoCivil, dp.apellido Apellido, dp.nombre Nombre, dp.sexo Sexo
, dp.mail Email,dp.fechaNac FechaNacimiento, dp.tipo TipoDoc, dp.telefono Telefono, dp.direccion Direccion, dp.dni DNI
from Usuarios u
inner join Afiliados a on a.userId = @userId
inner join Planes_Medicos pm on pm.codigo = a.planMedico
inner join Detalles_Persona dp on dp.userId = @userId
where u.idUser = @userId




create procedure [SHARPS].[GetAfiliados]

as
begin
select [SHARPS].[GetAfiliadoInfo]( u.idUser )
from Usuarios u
inner join Afiliados a on a.userId = u.idUser
end


create procedure [SHARPS].[InsertAfiliado]
@PlanMedico numeric(18,0),
@ID numeric (18,0),
@EstadoCivil nchar(10),
@CantHijos int,
@NroAfiliado numeric(18,0)

as 
begin
SELECT @NroAfiliado = MAX(nroAfiliado) + 101 FROM Afiliados
insert into Afiliados (nroAfiliado , planMedico , cantHijos , estadoCivil , userId)
values (@NroAfiliado , @PlanMedico , @CantHijos , @EstadoCivil , @ID) 
end 
go




create procedure [SHARPS].[InsertMiembroGrupoFamiliar]
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



create procedure [SHARPS].[UpdateAfiliado]

@PlanMedico numeric(18,0),
@ID numeric (18,0),
@EstadoCivil nchar(10),
@CantHijos int,
@RolAfiliado numeric(10,2), 
@Motivo char(10)
as 
begin

update Afiliados set planMedico = @PlanMedico , estadoCivil = @EstadoCivil , cantHijos = @CantHijos 
where userId = @ID



insert into Cambios_Afiliado (motivo , fecha , afiliado)
values (@Motivo , GETDATE() , nroAfiliado) --- ver lo del nro de afiliado

end
go


create function [SHARPS].[GetProfesionalInfo]
( @userId numeric(18,0)
)


returns table
as 
return

select u.username UserName , a.matricula matricula,  dp.apellido Apellido, dp.nombre Nombre, dp.sexo Sexo
, dp.mail Email,dp.fechaNac FechaNacimiento, dp.tipo TipoDoc, dp.telefono Telefono, dp.direccion Direccion, dp.dni DNI
from Usuarios u
inner join Medicos a on a.userId = @userId
inner join Detalles_Persona dp on dp.userId = @userId
where u.idUser = @userId




create procedure [SHARPS].[GetProfesionales]

as
begin
select [SHARPS].[GetProfesionalInfo]( u.idUser ) ---ver si se puede hacer
from Usuarios u
inner join Medicos m on m.userId =  u.idUser
end





create function [SHARPS].[GetRolesByPerfil]
(
@nombrePerfil nchar(255)
)

returns table
as 
return
select r.idRol ID , r.descripRol Descripcion , r.perfil Perfil -----cuando dice perfil quiere el codigo o la descripcion denuevo
from Perfil p 
inner join Roles r on r.perfil = p.idPerfil
where p.detallesPerf = @nombrePerfil



----HACER LA DE TODOS LOS ROLES


create procedure [SHARPS].[InsertDetallePersona]

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
insert into Detalles_Persona (telefono ,tipo , sexo, userId , direccion , apellido , nombre , mail , fechaNac,dni)
values ( @Telefono , @TipoDNI , @Sexo , @ID_Usuario , @Direccion , @Apellido , @Nombre , @Email , @FechaNacimiento , @DNI)

end 
go


create procedure [SHARPS].[UpdateDetallePersona]

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

update Detalles_Persona set
telefono = @Telefono , mail = @Email , nombre = @Nombre , apellido = @Apellido , direccion = @Direccion 
, dni = @DNI , tipo = @TipoDNI  , sexo = @Sexo , fechaNac = @FechaNacimiento
where @ID_Usuario = userId

end
go


create procedure [SHARPS].[GetRoles]


as 
begin
select [SHARPS].[GetRolesByPerfil](detallesPerfil)
from Perfil
end 
go



create procedure[SHARPS].[InsertRole]
@Description nchar(10)
as
begin

insert into Roles (descripRol)
values( @Description )

end
go


create procedure [SHARPS].[UpdateRole]
@Description nchar(10),
@ID numeric(10,2)

as
begin

update Roles set
descripRol = @Description
where idRol = @ID

end
go



create procedure [SHARPS].[DeleteRole]

@Description nchar(10)

as 
begin

delete Roles where descripRol = @Description

end 
go


