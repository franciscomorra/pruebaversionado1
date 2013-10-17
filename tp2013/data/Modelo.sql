USE [GD2C2013]
;




CREATE TABLE Afiliados ( 
	nroAfiliado numeric(18) NOT NULL,
	planMedico numeric(18) NULL,
	activoAfiliado char(10) NULL,
	estadoCivil nchar(10) NULL,
	cantHijos int NULL,
	userId numeric(18) NULL
)
;

CREATE TABLE Agendas ( 
	medico numeric(18) NULL,
	dia date NULL,
	horaIngreso time(7) NULL,
	horaEgreso time(7) NULL
)
;

CREATE TABLE Bonos ( 
	numeroBono numeric(18) NOT NULL,
	fechaImp datetime NULL,
	afiliadoCompro numeric(18) NULL,
	tipoBono nchar(10) NULL,
	plan numeric(18) NULL
)
;

CREATE TABLE Cambios_Afiliado ( 
	afiliado numeric(18) NULL,
	fecha date NULL,
	motivo char(10) NULL
)
;

CREATE TABLE Consulta ( 
	turno numeric(18) NULL,
	bono numeric(18) NULL,
	sintomas varchar(255) NULL,
	enfermedad varchar(255) NULL,
	nroConsulta numeric(18) NULL
)
;

CREATE TABLE Detalles_Persona ( 
	dni numeric(18) NULL,
	tipo varchar(255) NULL,
	telefono numeric(18) NULL,
	direccion varchar(255) NULL,
	sexo char(10) NULL,
	mail varchar(255) NULL,
	apellido varchar(255) NULL,
	nombre varchar(255) NULL,
	userId numeric(18) NOT NULL,
	fechaNac date NULL
)
;

CREATE TABLE Dias_Laborales ( 
	fecha date NOT NULL
)
;

CREATE TABLE Especialidades ( 
	codigoEspecialidad numeric(18) NOT NULL,
	descripcionEsp varchar(255) NULL,
	tipoEsp numeric(18) NULL
)
;

CREATE TABLE Estados_turno ( 
	idEstado numeric(18) NOT NULL,
	descTurno nchar(10) NULL,
	motivoCancel nchar(10) NULL
)
;

CREATE TABLE Funcionalidades ( 
	idFunc numeric(10,2) NOT NULL,
	descripcion nchar(10) NULL
)
;

CREATE TABLE Medicamentos ( 
	idMedic numeric(18) NULL,
	descrip nchar(10) NULL
)
;

CREATE TABLE Medicos ( 
	matricula numeric(18) NULL,
	userId numeric(18) NOT NULL,
	activoMedico char(10) NULL
)
;

CREATE TABLE Medicos_Esp ( 
	medico numeric(18) NULL,
	especialidad numeric(18) NULL
)
;

CREATE TABLE Perfil ( 
	idPerfil numeric(10,2) NOT NULL,
	detallesPerf char(10) NULL
)
;

CREATE TABLE Perfil_Func ( 
	perfil numeric(10,2) NULL,
	funcion numeric(10,2) NULL
)
;

CREATE TABLE Planes_Medicos ( 
	codigo numeric(18) NOT NULL,
	descripcionPM varchar(255) NULL,
	precioConsulta numeric(18) NULL,
	precioFarmacia numeric(18) NULL
)
;

CREATE TABLE Receta ( 
	bonoConsulta nchar(10) NULL,
	bonoFarmacia nchar(10) NULL
)
;

CREATE TABLE Recetas_Medicamen ( 
	receta nchar(10) NULL,
	medicamento numeric(18) NULL
)
;

CREATE TABLE Roles ( 
	idRol numeric(10,2) NOT NULL,
	descripRol nchar(10) NULL,
	activoRol bit NULL,
	perfil numeric(10,2) NULL
)
;

CREATE TABLE Roles_Func ( 
	rol numeric(10,2) NULL,
	funcionalidad numeric(10,2) NOT NULL
)
;

CREATE TABLE Tipo_Doc ( 
	idTipo varchar(255) NOT NULL,
	descripcion varchar(255) NULL
)
;

CREATE TABLE Tipos_Especialidad ( 
	codigoEsp numeric(18) NOT NULL,
	descripcionEsp varchar(255) NULL
)
;

CREATE TABLE Turnos ( 
	numero numeric(18) NOT NULL,
	medico numeric(18) NULL,
	afiliado numeric(18) NULL,
	fechaHora datetime NULL,
	estado numeric(18) NULL,
	fechaHoraLlegada datetime NULL
)
;

CREATE TABLE Usuarios ( 
	idUser numeric(18) NOT NULL,
	username numeric(10,2) NULL,
	clave nchar(10) NOT NULL,
	intentos int NULL,
	activo bit NULL
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

ALTER TABLE Bonos
	ADD CONSTRAINT UQ_Bonos_afiliadoCompro UNIQUE (afiliadoCompro)
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



ALTER TABLE Afiliados ADD CONSTRAINT FK_Afiliados_Bonos 
	FOREIGN KEY (nroAfiliado) REFERENCES Bonos (afiliadoCompro)
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
