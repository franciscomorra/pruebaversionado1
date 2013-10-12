CREATE TABLE Afiliados ( 
	nroAfiliado numeric(18) NOT NULL,
	plan numeric(18),
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
	numeroBono numeric(18) NOT NULL,
	fechaImp datetime,
	afiliadoCompro bit,
	tipoBono nchar(10),
	plan numeric(18)
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
	idFunc numeric(10,2) NOT NULL,
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
	estado numeric(18),
	fechaHoraLlegada datetime
)
;

CREATE TABLE Usuarios ( 
	idUser numeric(18) NOT NULL,
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
	FOREIGN KEY (plan) REFERENCES Planes_Medicos (codigo)
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
