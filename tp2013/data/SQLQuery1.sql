CREATE FUNCTION [ClinicaFrba].[GetIdRolByName]
(
	@RoleName NVARCHAR(100)
)
RETURNS int
AS
BEGIN
	DECLARE @Rol_ID int

	SELECT @Rol_ID = ID FROM GRUPO_N.Rol
	WHERE Descripcion = @RoleName

	RETURN @Rol_ID
END
GO

CREATE PROCEDURE [ClinicaFrba].[DeleteUser]
	@User_ID int
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE GRUPO_N.Usuario SET Activo = 0 WHERE ID = @User_ID
END
GO

CREATE PROCEDURE [ClinicaFrba].[DeleteRole]
	@Rol_ID int
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE GRUPO_N.Rol SET Activo = 0 WHERE ID = @Rol_ID
	UPDATE GRUPO_N.Usuario SET ID_Rol = [GRUPO_N].[GetIdRolDefault]() WHERE ID_Rol = @Rol_ID
END
GO

CREATE PROCEDURE [ClinicaFrba].[GetRoleFunctionalities]
	@Rol_ID int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT F.Descripcion AS Descripcion FROM GRUPO_N.Funcionalidad F
	INNER JOIN GRUPO_N.RolesFuncionalidades RF ON F.ID = RF.ID_Funcionalidad
	WHERE RF.ID_Rol = @Rol_ID
END
GO

CREATE FUNCTION [ClinicaFrba].[GetIdRoleByProfile]
(
	@ProfileName NVARCHAR(100)
)
RETURNS int
AS
BEGIN
	DECLARE @ID_Rol int

	SELECT @ID_Rol = ID_Rol FROM GRUPO_N.Perfil
	WHERE Descripcion = @ProfileName

	RETURN @ID_Rol
END
GO

CREATE FUNCTION [ClinicaFrba].[GetIdProfileByName]
(
	@ProfileName NVARCHAR(100)
)
RETURNS int
AS
BEGIN
	DECLARE @Profile_ID int

	SELECT @Profile_ID = ID FROM GRUPO_N.Perfil
	WHERE Descripcion = @ProfileName

	RETURN @Profile_ID
END
GO

CREATE PROCEDURE [ClinicaFrba].[UpdateUserPassword]
	@ID_Usuario int,
	@OldPassword nvarchar(255),
	@NewPassword nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;

    SELECT 1 FROM GRUPO_N.Usuario
	WHERE ID = @ID_Usuario AND Password = @OldPassword

	IF @@ROWCOUNT = 1
	BEGIN
		UPDATE GRUPO_N.Usuario 
		SET Password = @NewPassword
		WHERE ID = @ID_Usuario
	END

END
GO

CREATE PROCEDURE [ClinicaFrba].[Login]
	@Nombre nvarchar(255),
	@Password nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT ID, ID_Rol, Nombre FROM GRUPO_N.Usuario WHERE
	Nombre = @Nombre AND Password = @Password AND Activo = 1
	
	IF @@ROWCOUNT = 0
		BEGIN
			UPDATE GRUPO_N.Usuario SET Intentos = Intentos + 1
			WHERE Nombre = @Nombre
		END
	ELSE
		BEGIN
			UPDATE GRUPO_N.Usuario SET Intentos = 0
			WHERE Nombre = @Nombre
		END
END
GO

CREATE PROCEDURE [ClinicaFrba].[InsertUser]
	@UserName nvarchar(255),
	@Password nvarchar(255),
	@ID_Rol int
AS
BEGIN
	INSERT INTO GRUPO_N.Usuario (Nombre, Password, ID_Rol, Activo, Intentos) VALUES
	(@UserName, @Password, @ID_Rol, 1, 0)
	SELECT @@Identity AS ID
END
GO

CREATE PROCEDURE [ClinicaFrba].[InsertRoleFunctionality]
	@Rol_ID int,
	@Funcionalidad nvarchar(255)
AS
BEGIN
	INSERT INTO GRUPO_N.RolesFuncionalidades (ID_Rol, ID_Funcionalidad)
	VALUES (@Rol_ID, [GRUPO_N].[GetFunctionalityByName](@Funcionalidad))
END
GO

CREATE PROCEDURE [ClinicaFrba].[UpdateCliente]
	@ID int,
	@DNI numeric(18,0),
	@Nombre nvarchar(255),
	@Apellido nvarchar(255),
	@FechaNacimiento datetime
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE GRUPO_N.Cliente SET
	DNI = @DNI, Nombre = @Nombre, Apellido = @Apellido, FechaNacimiento = @FechaNacimiento
	WHERE ID = @ID
	
END
GO

CREATE PROCEDURE [ClinicaFrba].[UpdateProveedor]
	@CUIT nvarchar(20),
	@RazonSocial nvarchar(255),
	@ID_Rubro int,
	@ID int,
	@Contacto nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE GRUPO_N.Proveedor SET
	RazonSocial = @RazonSocial, ID_Rubro = @ID_Rubro, CUIT = @CUIT, Contacto = @Contacto
	WHERE ID = @ID
END
GO

CREATE FUNCTION [ClinicaFrba].[GetIdProveedorByName]
(
	@ProveedorName NVARCHAR(100)
)
RETURNS int
AS
BEGIN
	DECLARE @Proveedor_ID int

	SELECT @Proveedor_ID = ID FROM GRUPO_N.Proveedor
	WHERE RazonSocial = @ProveedorName

	RETURN @Proveedor_ID
END
GO

CREATE PROCEDURE [ClinicaFrba].[InsertProveedor]
	@CUIT nvarchar(20),
	@RazonSocial nvarchar(255),
	@ID_Rubro int,
	@ID int,
	@Contacto nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO GRUPO_N.Proveedor(RazonSocial, ID_Rubro, CUIT, ID, Contacto) VALUES 
	(@RazonSocial, @ID_Rubro, @CUIT, @ID, @Contacto)
	
	SELECT @@Identity AS ID
END
GO

REATE PROCEDURE [ClinicaFrba].[InsertProfileUser]
	@UserName nvarchar(255),
	@Password nvarchar(255),
	@ProfileName nvarchar(100)
AS
BEGIN
	INSERT INTO GRUPO_N.Usuario (Nombre, Password, ID_Rol, Activo, Intentos) VALUES
	(@UserName, @Password, GRUPO_N.GetIdRoleByProfile(@ProfileName), 1, 0)
	SELECT @@Identity AS ID
END
GO

CREATE PROCEDURE [ClinicaFrba].[InsertCliente]
	@ID int,
	@DNI numeric(18,0),
	@Nombre nvarchar(255),
	@Apellido nvarchar(255),
	@FechaNacimiento datetime
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO GRUPO_N.Cliente(ID, DNI, Nombre, Apellido, FechaNacimiento) VALUES 
	(@ID, @DNI, @Nombre, @Apellido, @FechaNacimiento)
	
	SELECT @@Identity AS ID
END
GO





---------------------------CREACION DE TABLAS------------------------------------------------



CREATE TABLE Afiliados ( 
	nroAfiliado numeric(18) NOT NULL,
	planMedico numeric(18),
	activoAfiliado char(10),
	estadoCivil nchar(10),
	cantHijos int,
	userId numeric(18)
)
;

CREATE TABLE Agendas ( 
	medico numeric(18),
	dia date,
	horaIngreso time(7),
	horaEgreso time(7)
)
;

CREATE TABLE Bonos ( 
	numeroBono numeric(18)  NOT NULL,
	fechaImp datetime,
	afiliadoCompro bit,
	tipoBono nchar(10),
	planMedico numeric(18)
)
;

CREATE TABLE Cambios_Afiliado ( 
	afiliado numeric(18),
	fecha date,
	motivo char(10)
)
;

CREATE TABLE Consulta ( 
	turno numeric(18),
	bono numeric(18),
	sintomas varchar(255),
	enfermedad varchar(255)
)
;

CREATE TABLE Detalles_Persona ( 
	dni numeric(18),
	tipo varchar(255),
	telefono numeric(18),
	direccion varchar(255),
	sexo char(10),
	mail varchar(255),
	apellido varchar(255),
	nombre varchar(255),
	userId numeric(18) NOT NULL,
	fechaNac date
)
;

CREATE TABLE Dias_Laborales ( 
	fecha date NOT NULL
)
;

CREATE TABLE Especialidades ( 
	codigoEspecialidad numeric(18) NOT NULL,
	descripcionEsp varchar(255),
	tipoEsp numeric(18)
)
;

CREATE TABLE Estados_turno ( 
	idEstado numeric(18) NOT NULL,
	descTurno nchar(10),
	motivoCancel nchar(10)
)
;

CREATE TABLE Funcionalidades ( 
	idFunc numeric(10,2) IDENTITY ( 1,1 ) NOT NULL,
	descripcion nchar(10)
)
;

CREATE TABLE Medicamentos ( 
	idMedic numeric(18),
	descrip nchar(10)
)
;

CREATE TABLE Medicos ( 
	matricula numeric(18),
	userId numeric(18) NOT NULL,
	activoMedico char(10)
)
;

CREATE TABLE Medicos_Esp ( 
	medico numeric(18),
	especialidad numeric(18)
)
;

CREATE TABLE Perfil ( 
	idPerfil numeric(10,2) NOT NULL,
	detallesPerf bit
)
;

CREATE TABLE Perfil_Func ( 
	perfil numeric(10,2),
	funcion numeric(10,2)
)
;

CREATE TABLE Planes_Medicos ( 
	codigo numeric(18) NOT NULL,
	descripcionPM varchar(255),
	precioConsulta numeric(18),
	precioFarmacia numeric(18)
)
;

CREATE TABLE Receta ( 
	bonoConsulta nchar(10),
	bonoFarmacia nchar(10)
)
;

CREATE TABLE Recetas_Medicamen ( 
	receta nchar(10),
	medicamento numeric(18)
)
;

CREATE TABLE Roles ( 
	idRol numeric(10,2) NOT NULL,
	descripRol nchar(10),
	activoRol bit,
	perfil numeric(10,2)
)
;

CREATE TABLE Roles_Func ( 
	rol numeric(10,2),
	funcionalidad numeric(10,2) NOT NULL
)
;

CREATE TABLE Tipo_Doc ( 
	idTipo varchar(255) NOT NULL,
	descripcion varchar(255)
)
;

CREATE TABLE Tipos_Especialidad ( 
	codigoEsp numeric(18) NOT NULL,
	descripcionEsp varchar(255)
)
;

CREATE TABLE Turnos ( 
	numero numeric(18) NOT NULL,
	medico numeric(18),
	afiliado numeric(18),
	fechaHora datetime,
	estado numeric(18) ,
	fechaHoraLlegada datetime
)
;

CREATE TABLE Usuarios ( 
	idUser numeric(18) identity(1000,1)  NOT NULL,
	username numeric(10,2),
	password nchar(10) NOT NULL,
	intentos int,
	activo bit
)
;

CREATE TABLE Usuarios_Roles ( 
	usuario numeric(10,2) NOT NULL,
	rol numeric(10,2) NOT NULL
)
;


ALTER TABLE Agendas
	ADD CONSTRAINT UQ_Agendas_dia UNIQUE (dia)
;

ALTER TABLE Agendas
	ADD CONSTRAINT UQ_Agendas_medico UNIQUE (medico)
;

ALTER TABLE Cambios_Afiliado
	ADD CONSTRAINT UQ_Cambios_Afiliado_afiliado UNIQUE (afiliado)
;

ALTER TABLE Consulta
	ADD CONSTRAINT UQ_Consulta_bono UNIQUE (bono)
;

ALTER TABLE Consulta
	ADD CONSTRAINT UQ_Consulta_turno UNIQUE (turno)
;

ALTER TABLE Detalles_Persona
	ADD CONSTRAINT UQ_Detalles_Persona_userId UNIQUE (userId)
;

ALTER TABLE Medicos
	ADD CONSTRAINT UQ_Medicos_matricula UNIQUE (matricula)
;

ALTER TABLE Medicos
	ADD CONSTRAINT UQ_Medicos_userId UNIQUE (userId)
;

ALTER TABLE Medicos_Esp
	ADD CONSTRAINT UQ_Medicos_Esp_medico UNIQUE (medico)
;

ALTER TABLE Perfil_Func
	ADD CONSTRAINT UQ_Perfil_Func_funcion UNIQUE (funcion)
;

ALTER TABLE Perfil_Func
	ADD CONSTRAINT UQ_Perfil_Func_perfil UNIQUE (perfil)
;

ALTER TABLE Turnos
	ADD CONSTRAINT UQ_Turnos_afiliado UNIQUE (afiliado)
;

ALTER TABLE Turnos
	ADD CONSTRAINT UQ_Turnos_medico UNIQUE (medico)
;

ALTER TABLE Usuarios
	ADD CONSTRAINT UQ_Usuarios_username UNIQUE (username)
;

ALTER TABLE Afiliados ADD CONSTRAINT PK_Afiliados 
	PRIMARY KEY CLUSTERED (nroAfiliado)
;

ALTER TABLE Bonos ADD CONSTRAINT PK_Bonos 
	PRIMARY KEY CLUSTERED (numeroBono)
;

ALTER TABLE Dias_Laborales ADD CONSTRAINT PK_Dias_Laborales 
	PRIMARY KEY CLUSTERED (fecha)
;

ALTER TABLE Especialidades ADD CONSTRAINT PK_Especialidades 
	PRIMARY KEY CLUSTERED (codigoEspecialidad)
;

ALTER TABLE Estados_turno ADD CONSTRAINT PK_Estados_turno 
	PRIMARY KEY CLUSTERED (idEstado)
;

ALTER TABLE Funcionalidades ADD CONSTRAINT PK_Funcionalidades 
	PRIMARY KEY CLUSTERED (idFunc)
;

ALTER TABLE Perfil ADD CONSTRAINT PK_Perfil 
	PRIMARY KEY CLUSTERED (idPerfil)
;

ALTER TABLE Planes_Medicos ADD CONSTRAINT PK_Planes_Medcos 
	PRIMARY KEY CLUSTERED (codigo)
;

ALTER TABLE Roles ADD CONSTRAINT PK_Roles 
	PRIMARY KEY CLUSTERED (idRol)
;

ALTER TABLE Tipo_Doc ADD CONSTRAINT PK_Tipo_Doc 
	PRIMARY KEY CLUSTERED (idTipo)
;

ALTER TABLE Tipos_Especialidad ADD CONSTRAINT PK_Tipos_Especialidad 
	PRIMARY KEY CLUSTERED (codigoEsp)
;

ALTER TABLE Turnos ADD CONSTRAINT PK_Turnos 
	PRIMARY KEY CLUSTERED (numero)
;

ALTER TABLE Usuarios ADD CONSTRAINT PK_Usuarios 
	PRIMARY KEY CLUSTERED (idUser)
;

ALTER TABLE Usuarios_Roles ADD CONSTRAINT PK_Usuarios Roles 
	PRIMARY KEY CLUSTERED (usuario)
;



ALTER TABLE Afiliados ADD CONSTRAINT FK_Afiliados_Planes_Medcos 
	FOREIGN KEY (planMedico) REFERENCES Planes_Medicos (codigo)
;

ALTER TABLE Afiliados ADD CONSTRAINT FK_Afiliados_Turnos 
	FOREIGN KEY (nroAfiliado) REFERENCES Turnos (afiliado)
;

ALTER TABLE Afiliados ADD CONSTRAINT FK_Afiliados_Usuarios 
	FOREIGN KEY (userId) REFERENCES Usuarios (idUser)
;

ALTER TABLE Agendas ADD CONSTRAINT FK_Agendas_Dias_Laborales 
	FOREIGN KEY (dia) REFERENCES Dias_Laborales (fecha)
;

ALTER TABLE Bonos ADD CONSTRAINT FK_Bonos_Consulta 
	FOREIGN KEY (numeroBono) REFERENCES Consulta (bono)
;

ALTER TABLE Detalles_Persona ADD CONSTRAINT FK_Detalles_Persona_Tipo_Doc 
	FOREIGN KEY (tipo) REFERENCES Tipo_Doc (idTipo)
;

ALTER TABLE Detalles_Persona ADD CONSTRAINT FK_Detalles_Persona_Usuarios 
	FOREIGN KEY (userId) REFERENCES Usuarios (idUser)
;

ALTER TABLE Especialidades ADD CONSTRAINT FK_Especialidades_Tipos_Especialidad 
	FOREIGN KEY (tipoEsp) REFERENCES Tipos_Especialidad (codigoEsp)
;

ALTER TABLE Medicos ADD CONSTRAINT FK_Medicos_Agendas 
	FOREIGN KEY (matricula) REFERENCES Agendas (medico)
;

ALTER TABLE Medicos ADD CONSTRAINT FK_Medicos_Medicos_Esp 
	FOREIGN KEY (matricula) REFERENCES Medicos_Esp (medico)
;

ALTER TABLE Medicos ADD CONSTRAINT FK_Medicos_Turnos 
	FOREIGN KEY (matricula) REFERENCES Turnos (medico)
;

ALTER TABLE Medicos ADD CONSTRAINT FK_Medicos_Usuarios 
	FOREIGN KEY (userId) REFERENCES Usuarios (idUser)
;

ALTER TABLE Medicos_Esp ADD CONSTRAINT FK_Medicos_Esp_Especialidades 
	FOREIGN KEY (especialidad) REFERENCES Especialidades (codigoEspecialidad)
;

ALTER TABLE Perfil_Func ADD CONSTRAINT FK_Perfil_Func_Funcionalidades 
	FOREIGN KEY (funcion) REFERENCES Funcionalidades (idFunc)
;

ALTER TABLE Perfil_Func ADD CONSTRAINT FK_Perfil_Func_Perfil 
	FOREIGN KEY (perfil) REFERENCES Perfil (idPerfil)
;

ALTER TABLE Roles ADD CONSTRAINT FK_Roles_Perfil 
	FOREIGN KEY (perfil) REFERENCES Perfil (idPerfil)
;

ALTER TABLE Roles_Func ADD CONSTRAINT FK_Roles_Func_Funcionalidades 
	FOREIGN KEY (funcionalidad) REFERENCES Funcionalidades (idFunc)
;

ALTER TABLE Turnos ADD CONSTRAINT FK_Turnos_Consulta 
	FOREIGN KEY (numero) REFERENCES Consulta (turno)
;

ALTER TABLE Turnos ADD CONSTRAINT FK_Turnos_Estados_turno 
	FOREIGN KEY (estado) REFERENCES Estados_turno (idEstado)
;

ALTER TABLE Usuarios_Roles ADD CONSTRAINT FK_Usuarios Roles_Roles 
	FOREIGN KEY (rol) REFERENCES Roles (idRol)
;








































































-------MIGRACIONES------------------------------------------------------
PRINT 'INICIO DE MIGRACION DE DATOS'


INSERT INTO Funcionalidades (Descripcion) VALUES ('DarDeAltaPaciente');
INSERT INTO Funcionalidades (Descripcion) VALUES ('ModificarDatos');
INSERT INTO Funcionalidades (Descripcion) VALUES ('EliminarUsuarios');
INSERT INTO Funcionalidades (Descripcion) VALUES ('Recetar');
INSERT INTO Funcionalidades (Descripcion) VALUES ('habilitarRol');
INSERT INTO Funcionalidades (Descripcion) VALUES ('inhabilitarRol');
INSERT INTO Funcionalidades (Descripcion) VALUES ('venderBonosFarmacia');
INSERT INTO Funcionalidades (Descripcion) VALUES ('comprarBonosFarmacia');
INSERT INTO Funcionalidades (Descripcion) VALUES ('venderBonosConsulta');
INSERT INTO Funcionalidades (Descripcion) VALUES ('comprarBonosConsulta');
INSERT INTO Funcionalidades (Descripcion) VALUES ('RegistrarUsuarios');
INSERT INTO Funcionalidades (Descripcion) VALUES ('CancelarTurno');
INSERT INTO Funcionalidades (Descripcion) VALUES ('RegistrarTurno');
INSERT INTO Funcionalidades (Descripcion) VALUES ('SolicitarTurno');

INSERT INTO Roles (descripRol) VALUES ('administrador')
INSERT INTO Roles (descripRol) VALUES ('Administrativo')
INSERT INTO Roles (descripRol) VALUES ('Medico');
INSERT INTO Roles (descripRol) VALUES ('Afiliado');

INSERT INTO Roles_Func (funcionalidad)  
SELECT idFunc FROM Funcionalidades



------------terminar ROLES FUNC
INSERT INTO RolesFunc (rol, funcionalidad)
VALUES (GetIdRolByName('Afiliado'), 4)
INSERT INTO RolesFunc (rol, funcionalidad)
VALUES (GetIdRolByName('Afiliado'), 6)
INSERT INTO RolesFunc (rol, funcionalidad)
VALUES (GetIdRolByName('Afiliado'), 7)
INSERT INTO RolesFunc(rol, funcionalidad)
VALUES (GetIdRolByName('Afiliado'), 11)
INSERT INTO RolesFunc (rol, funcionalidad)
VALUES (GetIdRolByName('Afiliado'), 9)

INSERT INTO RolesFunc (rol, funcionalidad)
VALUES (GetIdRolByName('medico'), 5)
INSERT INTO RolesFunc (rol, funcionalidad)
VALUES (GetIdRolByName('medico'), 13)

INSERT INTO Usuarios_Roles( usuario  ) -------rol con identity?
Select u.username , 
from Usuarios u 


INSERT INTO Roles(idRol , descripRol , activoRol , perfil) ---perfil identity
select u.rol , NULL , 1 
from Usuarios_Roles u




----agregar todas las que faltan


-- mirar por relacion entre perfilfunc y perfil
INSERT INTO Perfil (idPerfil, detallesPerf) VALUES (GRUPO_N.GetIdRolByName('Administrador'),'Administrador' );
INSERT INTO Perfil (idPerfil, detallesPerf) VALUES (GRUPO_N.GetIdRolByName('Afiliado'),'Afiliado');
INSERT INTO Perfil (idPerfil, detallesPerf) VALUES (GRUPO_N.GetIdRolByName('medico'),'medico');

GO











-- Ingresando los clientes.
PRINT 'Ingresando los Afiliados...'
GO

INSERT INTO Usuarios (activo,Intentos,username,Password)
SELECT DISTINCT 1,0,LTRIM(RTRIM(CAST(Paciente_Telefono AS NVARCHAR(255)))),'bed9ae713b440eed894573977256ed12a992b93804975fa09aff32dd1572b658' 
FROM gd_esquema.Maestra WHERE 1=1;

INSERT INTO Detalles_Persona(dni,tipo,telefono,direccion,sexo,mail,apellido,nombre,userId,fechaNac) 
SELECT distinct m.Paciente_Dni,NULL,m.Paciente_Telefono,m.Paciente_Direccion,NULL, m.Paciente_Mail,m.Paciente_Apellido,m.Paciente_Nombre, u.idUser, m.Paciente_Fecha_Nac 
FROM gd_esquema.Maestra m INNER JOIN Usuarios u ON CAST(m.Paciente_Telefono AS NVARCHAR(255))=u.username 


INSERT INTO Afiliados(nroAfiliado,planMedico,activoAefiliado, estadoCivil,cantHijos,userId)
SELECT DISTINCT NULL, m.Plan_Med_Codigo,1, NULL,NULL, u.idUser  FROM Usuarios u 
INNER JOIN gd_esquema.Maestra m ON u.username = CAST(m.Paciente_Telefono AS NVARCHAR(255))
GO


--Ingresando los Medicos
PRINT 'Ingresando los Medicos...'
GO


INSERT INTO Usuarios (activo,intentos,username,password)
SELECT DISTINCT 1,0, LTRIM(RTRIM(CAST(Medico_Telefono AS NVARCHAR(255)))),'bed9ae713b440eed894573977256ed12a992b93804975fa09aff32dd1572b658' 
FROM gd_esquema.Maestra  

INSERT INTO Detalles_Persona(dni,tipo,telefono,direccion,sexo,mail,apellido,nombre,userid,fechaNac) 
SELECT distinct m.Medico_Dni,NULL,m.Medico_Telefono,m.Medico_Direccion,NULL,m.Medico_Mail,m.Medico_Apellido,m.Medico_Nombre, u.idUser,m.Medico_Fecha_Nac FROM gd_esquema.Maestra m 
 INNER JOIN Usuarios u ON CAST(m.Medico_Telefono AS NVARCHAR(255))=u.username 


INSERT INTO Medicos (matricula, userId , activoMedico)
SELECT DISTINCT NULL, u.idUser, 1 
FROM gd_esquema.Maestra m
INNER JOIN Usuarios u ON u.username= CAST(m.Medico_Telefono AS NVARCHAR(255))





--Ingresando los bonos ---ver
PRINT 'Ingresando los Bonos '
GO
INSERT INTO Bonos(numeroBono,fechaImp,afiliadoCompro,tipoBono,planMedico)
SELECT distinct m.Bono_Consulta_Numero , m.Bono_Consulta_Fecha_Impresion,a.idUser ,'consulta', m.Plan_Med_Codigo  
  FROM gd_esquema.Maestra m
  inner join Usuarios a on CAST(m.Paciente_Telefono AS NVARCHAR(255))= a.username
  WHERE m.Turno_Fecha is NULL AND m.Turno_Fecha is null  
GO

INSERT INTO Bonos(numeroBono,fechaImp,afiliadoCompro,tipoBono,planMedico)
SELECT distinct m.Bono_Farmacia_Numero , m.Bono_Farmacia_Fecha_Impresion, a.idUser,'farmacia', m.Plan_Med_Codigo  
  FROM gd_esquema.Maestra m
  inner join Usuarios a on CAST(m.Paciente_Telefono AS NVARCHAR(255))= a.username
  WHERE m.Turno_Fecha is NULL AND m.Turno_Fecha is null  
GO


INSERT INTO Consulta(turno,bono,sintomas,enfermedad)
SELECT  distinct m.Turno_Numero , m.Bono_Consulta_Numero,m.Consulta_Sintomas,m.Consulta_Enfermedades
FROM gd_esquema.Maestra m 
INNER JOIN Turnos t ON t.numero = m.Turno_Numero
INNER JOIN Bonos b ON m.Bono_Consulta_Numero = b.numeroBono   
GO  


--Ingresando Turnos
PRINT 'Ingresando los turnos...'
GO
INSERT INTO Turnos (numero,medico,afiliado,fechaHora,estado,fechaHoraLlegada)
SELECT distinct m.Turno_Numero , x.userId , a.userId, m.Turno_Fecha,'ver q poner',null -- ver como descontar 15 minutos
FROM gd_esquema.Maestra m
INNER JOIN Usuarios u ON u.username=CAST(m.Paciente_Telefono AS NVARCHAR(255))
inner JOIN Afiliados a ON u.idUser= a.userId
INNER JOIN Medicos x ON u.idUser= x.userId
WHERE u.username=CAST(m.Medico_Telefono AS NVARCHAR(255))
AND m.Turno_Numero is not null
GO


--Ingresando Planes
PRINT 'Ingresando los Planes...'
GO
INSERT INTO Planes_Medicos (codigo,descripcionPM,precioConsulta,precioFarmacia)
SELECT distinct m.Plan_Med_Codigo, m.Plan_Med_Descripcion, m.Plan_Med_Precio_Bono_Consulta , m.Plan_Med_Precio_Bono_Farmacia
FROM gd_esquema.Maestra m
GO


--Ingresando Medicos Esp

PRINT 'Ingresando TipoESP...'
GO
INSERT INTO Tipos_Especialidad (codigoEsp , descripcionEsp)
SELECT distinct m.Tipo_Especialidad_Codigo , m.Tipo_Especialidad_Descripcion
FROM gd_esquema.Maestra m
WHERE m.Tipo_Especialidad_Codigo is not null
GO

PRINT 'Ingresando especialidades...'
GO
INSERT INTO Especialidades(codigoEspecialidad , descripcionEsp , tipoEsp)
SELECT distinct m.Especialidad_Codigo , m.Especialidad_Descripcion, m.Tipo_Especialidad_Codigo
FROM gd_esquema.Maestra m
WHERE m.Tipo_Especialidad_Codigo is not null 
GO

PRINT 'Ingresando Medicos_Esp...'
GO
INSERT INTO Medicos_Esp(medico , especialidad)
SELECT distinct a.matricula , m.Especialidad_Codigo
FROM gd_esquema.Maestra m
inner join Usuarios u on u.username = CAST(m.Medico_Telefono AS NVARCHAR(255))
inner join Medicos a on u.idUser = a.userId
GO






--IGNORAR
PRINT 'Creando usuario administrador...'
DECLARE @ID_Administrador_Inicial INT
DECLARE @ID_Detalle_Administrador_Inicial INT

INSERT INTO Usuarios (Nombre, Password, ID_Rol)
VALUES ('Admin', 'bed9ae713b440eed894573977256ed12a992b93804975fa09aff32dd1572b658', 1)
SET @ID_Administrador_Inicial = @@IDENTITY
INSERT INTO Detalles_Persona (dni,tipo,telefono,direccion,sexo,mail,apellido,nombre,userid,fechaNac) VALUES ()  ---- QUE VALORES VAN PARA EL ADMINISTRADOR EN DETALLE ENTIDAD
SET @ID_Detalle_Administrador_Inicial = @@IDENTITY


---- arreglar
INSERT INTO GRUPO_N.Direccion (Descripcion, ID_Ciudad, ID_Detalle) VALUES (' ', 1, @ID_Detalle_Administrador_Inicial)
INSERT INTO GRUPO_N.Cliente (ID, DNI, Nombre, Apellido, FechaNacimiento) VALUES (@ID_Administrador_Inicial, 0, 'Administrador', 'Administrador', GETDATE())
INSERT INTO GRUPO_N.ClienteCiudad (ID_Ciudad, ID_Cliente) SELECT ID, @ID_Administrador_Inicial FROM GRUPO_N.Ciudad
INSERT INTO GRUPO_N.Proveedor (CUIT, ID, ID_Rubro, RazonSocial) VALUES ('Administrador', @ID_Administrador_Inicial, 1, 'Administrador')
GO
------





















PRINT 'Proceso finalizado con éxito!'
GO