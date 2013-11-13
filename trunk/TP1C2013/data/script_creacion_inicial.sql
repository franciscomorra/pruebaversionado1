--CREACION DE TABLAS, FUNCIONES, PROCEDURES

USE [GD1C2013]
GO
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'ACTITUD_GDD')
DROP SCHEMA [ACTITUD_GDD]
GO
/****** Object:  Schema [ACTITUD_GDD]    Script Date: 07/19/2013 05:37:35 ******/
CREATE SCHEMA [ACTITUD_GDD] AUTHORIZATION [gd]
GO
/****** Object:  Table [ACTITUD_GDD].[ROL]    Script Date: 07/19/2013 05:37:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ACTITUD_GDD].[ROL](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [nvarchar](100) NOT NULL,
	[BAJA_LOGICA] [bit] NOT NULL,
 CONSTRAINT [PK_ROL] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ACTITUD_GDD].[SERVICIO]    Script Date: 07/19/2013 05:37:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ACTITUD_GDD].[SERVICIO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TIPO_SERVICIO] [nvarchar](255) NOT NULL,
	[RECARGO] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_SERVICIO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ACTITUD_GDD].[MODELO]    Script Date: 07/19/2013 05:37:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ACTITUD_GDD].[MODELO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MODELO] [nvarchar](255) NOT NULL,
	[MARCA] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_MODELO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ACTITUD_GDD].[MICRO]    Script Date: 07/19/2013 05:37:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ACTITUD_GDD].[MICRO](
	[PATENTE] [nvarchar](255) NOT NULL,
	[TIPO_SERVICIO] [int] NOT NULL,
	[ID_MODELO] [int] NOT NULL,
	[FECHA_ALTA] [datetime] NOT NULL,
	[FECHA_BAJA_DEFINITIVA] [datetime] NULL,
	[KG_DISPONIBLES] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_MICRO] PRIMARY KEY CLUSTERED 
(
	[PATENTE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ACTITUD_GDD].[CIUDAD]    Script Date: 07/19/2013 05:37:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ACTITUD_GDD].[CIUDAD](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_CIUDAD] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ACTITUD_GDD].[PRECIO_BASE]    Script Date: 07/19/2013 05:37:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ACTITUD_GDD].[PRECIO_BASE](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PRECIO_BASE_KG] [numeric](18, 2) NULL,
	[PRECIO_BASE_PASAJE] [numeric](18, 2) NULL,
 CONSTRAINT [PK_PRECIO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ACTITUD_GDD].[RECORRIDO]    Script Date: 07/19/2013 05:37:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ACTITUD_GDD].[RECORRIDO](
	[RECORRIDO_CODIGO] [numeric](18, 0) NOT NULL,
	[ID_CIUDAD_ORIGEN] [int] NOT NULL,
	[ID_CIUDAD_DESTINO] [int] NOT NULL,
	[ID_SERVICIO] [int] NOT NULL,
	[ID_PRECIO_BASE] [int] NOT NULL,
	[BAJA_LOGICA] [bit] NOT NULL,
 CONSTRAINT [PK_RECORRIDO] PRIMARY KEY CLUSTERED 
(
	[RECORRIDO_CODIGO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ACTITUD_GDD].[VIAJE]    Script Date: 07/19/2013 05:37:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ACTITUD_GDD].[VIAJE](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PATENTE] [nvarchar](255) NOT NULL,
	[FECHA_SALIDA] [datetime] NOT NULL,
	[FECHA_LLEGADA] [datetime] NULL,
	[FECHA_LLEGADA_ESTIMADA] [datetime] NOT NULL,
	[RECORRIDO_CODIGO] [numeric](18, 0) NOT NULL,
	[BAJA_LOGICA] [bit] NOT NULL,
 CONSTRAINT [PK_VIAJE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [ACTITUD_GDD].[VIAJESCRUZAN]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [ACTITUD_GDD].[VIAJESCRUZAN] (
	
	@ID_VIAJE1 INT,
	@ID_VIAJE2 INT
)
RETURNS BIT
AS
BEGIN
	DECLARE @RETORNO BIT
	SET @RETORNO = 0
	
	SELECT @RETORNO = 1
	FROM ACTITUD_GDD.VIAJE VJ1,ACTITUD_GDD.VIAJE VJ2
	WHERE  VJ1.ID = @ID_VIAJE1 AND VJ2.ID = @ID_VIAJE2 AND (VJ1.FECHA_SALIDA <= VJ2.FECHA_LLEGADA_ESTIMADA AND VJ1.FECHA_LLEGADA_ESTIMADA >= VJ2.FECHA_SALIDA)
	
	RETURN @RETORNO

END
GO
/****** Object:  Table [ACTITUD_GDD].[CLIENTE]    Script Date: 07/19/2013 05:37:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ACTITUD_GDD].[CLIENTE](
	[DNI] [numeric](18, 0) NOT NULL,
	[NOMBRE] [nvarchar](255) NOT NULL,
	[APELLIDO] [nvarchar](255) NOT NULL,
	[DIRECCION] [nvarchar](255) NOT NULL,
	[MAIL] [nvarchar](255) NULL,
	[TELEFONO] [numeric](18, 0) NOT NULL,
	[FECHA_NAC] [datetime] NOT NULL,
	[SEXO] [nchar](1) NULL,
	[DISCAPACITADO] [bit] NOT NULL,
 CONSTRAINT [PK_CLIENTE] PRIMARY KEY CLUSTERED 
(
	[DNI] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ACTITUD_GDD].[COMPRA]    Script Date: 07/19/2013 05:37:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ACTITUD_GDD].[COMPRA](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DNI] [numeric](18, 0) NOT NULL,
	[FECHA_COMP] [datetime] NULL,
	[FORMA_DE_PAGO] [nchar](1) NULL,
	[ID_TARJETA_CREDITO] [int] NULL,
 CONSTRAINT [PK_COMPRA_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ACTITUD_GDD].[CANCELACION]    Script Date: 07/19/2013 05:37:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ACTITUD_GDD].[CANCELACION](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FECHA_CANCELACION] [datetime] NOT NULL,
	[MOTIVO_CANCELACION] [nvarchar](255) NULL,
 CONSTRAINT [PK_CANCELACION] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ACTITUD_GDD].[PASAJE]    Script Date: 07/19/2013 05:37:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ACTITUD_GDD].[PASAJE](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DNI] [numeric](18, 0) NOT NULL,
	[BUTACA_NUMERO] [numeric](18, 0) NOT NULL,
	[PUNTOS_CANJEADOS] [numeric](18, 0) NOT NULL,
	[ID_VIAJE] [int] NOT NULL,
	[ID_COMPRA] [int] NOT NULL,
	[PRECIO] [numeric](18, 2) NOT NULL,
	[ID_CANCELACION] [int] NULL,
 CONSTRAINT [PK_PASAJE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [ACTITUD_GDD].[KG_MICRO]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [ACTITUD_GDD].[KG_MICRO]
(
	@PATENTE NVARCHAR(255)	
)
RETURNS NUMERIC(18,0)
AS
BEGIN
	RETURN(SELECT KG_DISPONIBLES
		   FROM ACTITUD_GDD.MICRO 
		   WHERE PATENTE = @PATENTE)

END
GO
/****** Object:  UserDefinedFunction [ACTITUD_GDD].[KG_LIBRES_VIAJE]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [ACTITUD_GDD].[KG_LIBRES_VIAJE]
(
	@ID_VIAJE INT, 
	@PATENTE NVARCHAR(255)
)
RETURNS NUMERIC(18,0)
AS
BEGIN
	
	RETURN(	select ACTITUD_GDD.KG_MICRO(@PATENTE) - (
				SELECT  ISNULL(SUM(isnull(PQ.PESO,0)),0)
				FROM ACTITUD_GDD.VIAJE VJ left join ACTITUD_GDD.PAQUETE PQ ON (PQ.ID_VIAJE = VJ.ID)
				WHERE VJ.ID = @ID_VIAJE AND (ISNULL(PQ.ID_CANCELACION,0) = 0)) )

END
GO
/****** Object:  Table [ACTITUD_GDD].[PAQUETE]    Script Date: 07/19/2013 05:37:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ACTITUD_GDD].[PAQUETE](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DNI] [numeric](18, 0) NOT NULL,
	[PESO] [numeric](18, 0) NOT NULL,
	[PUNTOS_CANJEADOS] [numeric](18, 0) NOT NULL,
	[ID_VIAJE] [int] NOT NULL,
	[ID_COMPRA] [int] NOT NULL,
	[PRECIO] [numeric](18, 2) NOT NULL,
	[ID_CANCELACION] [int] NULL,
 CONSTRAINT [PK_PAQUETE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [ACTITUD_GDD].[CALCULAR_PUNTOS_PERSONA]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [ACTITUD_GDD].[CALCULAR_PUNTOS_PERSONA]
(
	@DNI NUMERIC(18,0),
	@FECHA DATETIME
)
RETURNS INT
AS
BEGIN

RETURN(

	   (ISNULL((SELECT (SUM(PS.PRECIO/5) - SUM(PS.PUNTOS_CANJEADOS))
	   FROM ACTITUD_GDD.PASAJE PS JOIN ACTITUD_GDD.VIAJE VJ ON (PS.ID_VIAJE = VJ.ID)
	   WHERE PS.DNI = @DNI AND (ISNULL(VJ.FECHA_LLEGADA,0) <> 0) AND (DATEDIFF(DAY,VJ.FECHA_LLEGADA, @FECHA) < 365) AND (ISNULL(PS.ID_CANCELACION,0) = 0)),0))
	   +
	   (ISNULL((SELECT (SUM(PQ.PRECIO/5) - SUM(PQ.PUNTOS_CANJEADOS))
	   FROM ACTITUD_GDD.PAQUETE PQ JOIN ACTITUD_GDD.VIAJE VJ ON (PQ.ID_VIAJE = VJ.ID)
	   WHERE PQ.DNI = @DNI AND (ISNULL(VJ.FECHA_LLEGADA,0) <> 0) AND (DATEDIFF(DAY,VJ.FECHA_LLEGADA, @FECHA) < 365) AND (ISNULL(PQ.ID_CANCELACION,0) = 0)),0))
	   
	   )

END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[CALCULARPUNTOS]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[CALCULARPUNTOS]
	-- Add the parameters for the stored procedure here
	@DNI INT,
	@FECHA DATETIME
	
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   
   SELECT ACTITUD_GDD.CALCULAR_PUNTOS_PERSONA(@DNI,@FECHA) PUNTOS
   
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[HABILITAR_ROL]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [ACTITUD_GDD].[HABILITAR_ROL]
	@ROL_ID int
AS
BEGIN
	UPDATE [GD1C2013].[ACTITUD_GDD].[ROL]
	SET [BAJA_LOGICA] = 0
	WHERE ID = @ROL_ID
END
GO
/****** Object:  Table [ACTITUD_GDD].[FUNCIONALIDAD]    Script Date: 07/19/2013 05:37:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ACTITUD_GDD].[FUNCIONALIDAD](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_FUNCIONALIDAD] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_FUNCIONALIDAD] UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ACTITUD_GDD].[FUNCIONALIDADXROL]    Script Date: 07/19/2013 05:37:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ACTITUD_GDD].[FUNCIONALIDADXROL](
	[ID_ROL] [int] NOT NULL,
	[ID_FUNCIONALIDAD] [int] NOT NULL,
 CONSTRAINT [PK_FUNCIONALIDADXROL] PRIMARY KEY CLUSTERED 
(
	[ID_ROL] ASC,
	[ID_FUNCIONALIDAD] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[BORRAR_ROL_FUNCIONALIDADES]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[BORRAR_ROL_FUNCIONALIDADES] 
	@ROL_ID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DELETE FROM ACTITUD_GDD.FUNCIONALIDADXROL
	WHERE ID_ROL = @ROL_ID
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[CREARPAQUETE]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[CREARPAQUETE]
	@DNI NUMERIC(18,0),
	@PESO NUMERIC(18,0),
    @ID_VIAJE INT,
	@ID_COMPRA INT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO [GD1C2013].[ACTITUD_GDD].[PAQUETE]
           ([DNI]
           ,[PESO]
           ,[PUNTOS_CANJEADOS]
           ,[ID_VIAJE]
           ,[ID_COMPRA]
           ,[PRECIO])
     VALUES
           (@DNI
           ,@PESO
           ,0
           ,@ID_VIAJE
           ,@ID_COMPRA
           ,0)
           
  DECLARE @A  BIT
     set @A = 0
     IF ISNULL(@@IDENTITY, 0) > 0
     begin
		set @A = 1
     end
     
     SELECT @A INSERTO
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[ELIMINAR_ROL]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [ACTITUD_GDD].[ELIMINAR_ROL]
	@ROL_ID int
AS
BEGIN
	DELETE FROM ACTITUD_GDD.ROL
	WHERE ID = @ROL_ID
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[ACTUALIZARROL]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [ACTITUD_GDD].[ACTUALIZARROL]
	@NOMBRE nvarchar(100),
	@ID int
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE ACTITUD_GDD.ROL SET NOMBRE = @NOMBRE
	WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[ListarRol]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[ListarRol]
AS
BEGIN
	SELECT *
	FROM ACTITUD_GDD.ROL
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[INSERTAR_ROL]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [ACTITUD_GDD].[INSERTAR_ROL]
	@NOMBRE nvarchar(100)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO ACTITUD_GDD.ROL (NOMBRE) VALUES (@NOMBRE)
	SELECT @@Identity AS ID
END
GO
/****** Object:  UserDefinedFunction [ACTITUD_GDD].[CANTIDAD_DIAS_QUE_SE_CRUZAN]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [ACTITUD_GDD].[CANTIDAD_DIAS_QUE_SE_CRUZAN] 
(
	-- Add the parameters for the function here
	@FECHA_INICIO_SEMESTRE DATETIME, 
	@FECHA_FIN_SEMESTRE DATETIME, 
	@FECHA_FUERA_SERVICIO DATETIME,
	@FECHA_REINICIO_SERVICIO DATETIME
)
RETURNS INT
AS
BEGIN
	
	DECLARE @RESULTADO INT
	SET @RESULTADO = DATEDIFF(DAY, @FECHA_FUERA_SERVICIO, @FECHA_REINICIO_SERVICIO)
	
	IF @FECHA_FUERA_SERVICIO < @FECHA_INICIO_SEMESTRE
	BEGIN
		SET @RESULTADO = @RESULTADO - DATEDIFF(DAY,@FECHA_FUERA_SERVICIO,@FECHA_INICIO_SEMESTRE)
	END
	
	IF @FECHA_FIN_SEMESTRE < @FECHA_REINICIO_SERVICIO
	BEGIN
		SET @RESULTADO =  @RESULTADO - DATEDIFF(DAY, @FECHA_FIN_SEMESTRE, @FECHA_REINICIO_SERVICIO)
	END
	
	RETURN @RESULTADO

END
GO
/****** Object:  Table [ACTITUD_GDD].[USUARIO]    Script Date: 07/19/2013 05:37:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ACTITUD_GDD].[USUARIO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PASSWORD] [varchar](100) NOT NULL,
	[INTENTOS] [tinyint] NOT NULL,
	[USERNAME] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_USUARIO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_USUARIO] UNIQUE NONCLUSTERED 
(
	[USERNAME] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [ACTITUD_GDD].[USUARIOXROL]    Script Date: 07/19/2013 05:37:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ACTITUD_GDD].[USUARIOXROL](
	[ID_USUARIO] [int] NOT NULL,
	[ID_ROL] [int] NOT NULL,
 CONSTRAINT [PK_USUARIOXROL] PRIMARY KEY CLUSTERED 
(
	[ID_USUARIO] ASC,
	[ID_ROL] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[RECARGARFUNCIONALIDADES]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[RECARGARFUNCIONALIDADES]

	@USUARIO int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    select F.NOMBRE FUNCIONALIDAD	
    from ACTITUD_GDD.USUARIOXROL UXR JOIN ACTITUD_GDD.FUNCIONALIDADXROL FXR ON (FXR.ID_ROL = UXR.ID_ROL) JOIN FUNCIONALIDAD F ON (FXR.ID_FUNCIONALIDAD = F.ID)
    WHERE @USUARIO = UXR.ID_USUARIO
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[LISTARFUNCIONALIDADESKIOSKO]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[LISTARFUNCIONALIDADESKIOSKO]
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   
   
   SELECT F.NOMBRE FUNCIONALIDAD
   FROM ACTITUD_GDD.FUNCIONALIDADXROL FXR JOIN ACTITUD_GDD.FUNCIONALIDAD F ON (FXR.ID_FUNCIONALIDAD = F.ID) JOIN ROL R ON (R.ID = FXR.ID_ROL)
   --Rol Kiosko por defecto
   WHERE FXR.ID_ROL = 1 AND R.BAJA_LOGICA = 0
   
   
   
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[FuncionalidadesRol]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[FuncionalidadesRol]
	@ID_ROL int
AS
BEGIN
	SELECT F.NOMBRE AS NOMBRE, F.ID as ID
	FROM ACTITUD_GDD.FUNCIONALIDADXROL FXR JOIN ACTITUD_GDD.FUNCIONALIDAD F ON (F.ID = FXR.ID_FUNCIONALIDAD)
	WHERE FXR.ID_ROL = @ID_ROL
END
GO
/****** Object:  Table [ACTITUD_GDD].[BUTACA]    Script Date: 07/19/2013 05:37:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ACTITUD_GDD].[BUTACA](
	[NUMERO] [numeric](18, 0) NOT NULL,
	[PATENTE] [nvarchar](255) NOT NULL,
	[TIPO] [nvarchar](255) NOT NULL,
	[PISO] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_BUTACA] PRIMARY KEY CLUSTERED 
(
	[NUMERO] ASC,
	[PATENTE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [ACTITUD_GDD].[CALCULAR_FECHA_DE_COMPRA]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [ACTITUD_GDD].[CALCULAR_FECHA_DE_COMPRA]
(
	-- Add the parameters for the function here
	@FECHA_PASAJE DATETIME, @FECHA_PAQUETE DATETIME 
)
RETURNS DATETIME
AS
BEGIN
	
	IF(@FECHA_PASAJE > @FECHA_PAQUETE)
		RETURN @FECHA_PASAJE
	
	RETURN @FECHA_PAQUETE

END
GO
/****** Object:  UserDefinedFunction [ACTITUD_GDD].[CALCULAR_EDAD]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [ACTITUD_GDD].[CALCULAR_EDAD] 
(
	-- Add the parameters for the function here
	@FNACIMIENTO DATETIME,
	@FECHA_ACTUAL DATETIME
)RETURNS INT
AS
BEGIN 
DECLARE @RETURN INT, @FHOY DATETIME
SET @FHOY = @FECHA_ACTUAL
SET @RETURN = DATEDIFF(year,@FNACIMIENTO,@FHOY )+    
CASE 
WHEN( Month(@FHOY) < Month(@fNacimiento) Or (Month(@FHOY) = Month(@FNACIMIENTO) And Day(@FHOY) < day(@FNACIMIENTO))) THEN -1 ELSE 0 END
RETURN @RETURN
END
GO
/****** Object:  UserDefinedFunction [ACTITUD_GDD].[CALCULAR_CANTIDAD]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [ACTITUD_GDD].[CALCULAR_CANTIDAD]
(
	-- Add the parameters for the function here
	@STOCK_PRODUCTO INT,
	@CANTIDAD_PTOS_PRODUCTO NUMERIC(18,0), 
	@PUNTOS_USUARIO NUMERIC(18,0)
)
RETURNS INT
AS
BEGIN
	
	
	DECLARE @A INT
	
	SET @A = CONVERT(INT,(@PUNTOS_USUARIO/@CANTIDAD_PTOS_PRODUCTO))
	
	
	IF(@STOCK_PRODUCTO > @A)
	BEGIN
		RETURN @A
	END
	
	RETURN @STOCK_PRODUCTO
		
	
	

END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[LOGUEARSE]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

-- Devuelve FUNCIONES, 0 si logro loguearse (aunque no tenga funciones)
-- Devuelve NULL, 1 si la contraseña es incorrecta
-- Devuelve NULL, 2 si el usuario es inexistente
-- Devuelve NULL, 3 si el usuario exedio la cantidad de intentos

CREATE PROCEDURE [ACTITUD_GDD].[LOGUEARSE]
	@USUARIO nvarchar(255),
	@CONTRASENIA nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;
	   
	declare @CANT_INT INT
	set @CANT_INT = -1
	
	
	select @CANT_INT = INTENTOS
	from ACTITUD_GDD.USUARIO
	where @USUARIO = USERNAME
	
	IF (@CANT_INT >= 3)
	BEGIN
		select NULL FUNCIONALIDAD, 3 ESTADO, -1 ID
	END
	IF (@CANT_INT = -1)
	BEGIN
		
		select NULL FUNCIONALIDAD, 2 ESTADO, -1 ID
	END
	
	IF (@CANT_INT >= 0 AND @CANT_INT < 3)
	BEGIN
	
		IF(ISNULL((select TOP 1 1 from ACTITUD_GDD.USUARIO where @USUARIO = USERNAME and @CONTRASENIA = PASSWORD),0) = 1)
		BEGIN
	
		
			UPDATE [GD1C2013].[ACTITUD_GDD].[USUARIO]
			SET [INTENTOS] = 0
			WHERE USERNAME = @USUARIO
    	
    		
			select DISTINCT FN.NOMBRE FUNCIONALIDAD, 0 ESTADO, US.ID ID
			from ACTITUD_GDD.USUARIO US LEFT JOIN ACTITUD_GDD.USUARIOXROL UR ON (US.ID = UR.ID_USUARIO) LEFT JOIN ACTITUD_GDD.FUNCIONALIDADXROL FR ON (FR.ID_ROL = UR.ID_ROL) LEFT JOIN ACTITUD_GDD.FUNCIONALIDAD FN ON (FN.ID = FR.ID_FUNCIONALIDAD)
			where @USUARIO =  us.USERNAME and @CONTRASENIA = us.PASSWORD
			
			
		END
		ELSE
		BEGIN
	
			
			UPDATE [GD1C2013].[ACTITUD_GDD].[USUARIO]
			SET [INTENTOS] += 1
			WHERE USERNAME = @USUARIO
		
			select null FUNCIONALIDAD, 1 ESTADO, -1 ID

		END
	END

END
GO
/****** Object:  Table [ACTITUD_GDD].[TIPO_TARJETA]    Script Date: 07/19/2013 05:37:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ACTITUD_GDD].[TIPO_TARJETA](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DESCRIPCION] [nvarchar](255) NOT NULL,
	[CANT_CUOTAS] [int] NOT NULL,
 CONSTRAINT [PK_TIPO_TARJETA] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ACTITUD_GDD].[PRODUCTO]    Script Date: 07/19/2013 05:37:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ACTITUD_GDD].[PRODUCTO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [nvarchar](255) NOT NULL,
	[STOCK] [int] NOT NULL,
	[CANTIDAD_PTOS] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_PRODUCTO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[CALCULARPOSIBLESCANJES]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[CALCULARPOSIBLESCANJES]
	-- Add the parameters for the stored procedure here
	
	
	@DNI INT,
	@FECHA DATETIME
	
	
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

 
 
	DECLARE @PUNTOS NUMERIC(18,0)
	
	SET @PUNTOS = ACTITUD_GDD.CALCULAR_PUNTOS_PERSONA(@DNI,@FECHA)
	
	
	
	SELECT PR.NOMBRE NOMBREPRODUCTO, ACTITUD_GDD.CALCULAR_CANTIDAD(PR.STOCK, PR.CANTIDAD_PTOS, @PUNTOS)  CANTIDAD, PR.CANTIDAD_PTOS PUNTOSNECESARIOS
	FROM ACTITUD_GDD.PRODUCTO PR
	WHERE (PR.STOCK > 0) AND (PR.CANTIDAD_PTOS < @PUNTOS)
	

 
 
END
GO
/****** Object:  UserDefinedFunction [ACTITUD_GDD].[NOMBRE_TIPO_SERVICIO]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [ACTITUD_GDD].[NOMBRE_TIPO_SERVICIO] 
(
	-- Add the parameters for the function here
	@ID_SERVICIO INT
)
RETURNS NVARCHAR(255)
AS
BEGIN
	
	RETURN(SELECT TIPO_SERVICIO
		   FROM ACTITUD_GDD.SERVICIO
		   WHERE ID = @ID_SERVICIO)
END
GO
/****** Object:  UserDefinedFunction [ACTITUD_GDD].[NOMBRE_CIUDAD]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [ACTITUD_GDD].[NOMBRE_CIUDAD] 
(
	@ID INT
)
RETURNS NVARCHAR(255)
AS
BEGIN
	
	RETURN (SELECT NOMBRE
		   FROM ACTITUD_GDD.CIUDAD
		   WHERE @ID = ID)
	

END
GO
/****** Object:  Table [ACTITUD_GDD].[TARJETA_DE_CREDITO]    Script Date: 07/19/2013 05:37:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ACTITUD_GDD].[TARJETA_DE_CREDITO](
	[ID] [int] NOT NULL,
	[DNI] [numeric](18, 0) NOT NULL,
	[CODIGO_SEGURIDAD] [nvarchar](100) NOT NULL,
	[FECHA_VENC] [date] NOT NULL,
	[ID_TIPO] [int] NOT NULL,
 CONSTRAINT [PK_TARJETA_DE_CREDITO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[DNI] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [ACTITUD_GDD].[CALCULAR_CANT_PTOS]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [ACTITUD_GDD].[CALCULAR_CANT_PTOS]
(
	-- Add the parameters for the function here
	@ID_PRODUCTO INT,
	@CANTIDAD INT
)
RETURNS NUMERIC(18,0)
AS
BEGIN
	
	
	
	RETURN (SELECT TOP 1 (P.CANTIDAD_PTOS * @CANTIDAD)
			FROM ACTITUD_GDD.PRODUCTO P
			WHERE P.ID = @ID_PRODUCTO)

END
GO
/****** Object:  UserDefinedFunction [ACTITUD_GDD].[CALCULAR_FECHA_DE_VIAJE]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [ACTITUD_GDD].[CALCULAR_FECHA_DE_VIAJE]
(
	-- Add the parameters for the function here
	@ID_VIAJE INT
)
RETURNS DATETIME
AS
BEGIN
	
	
	RETURN (SELECT VJ.FECHA_LLEGADA
	
			FROM ACTITUD_GDD.VIAJE VJ
	
			WHERE VJ.ID = @ID_VIAJE)

END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[DESCONTARPUNTOS]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[DESCONTARPUNTOS] 
	-- Add the parameters for the stored procedure here
	
	@DNI NUMERIC(18,0),
	@PTOS INT,
	@FECHA DATETIME
AS	
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DECLARE @ID INT, @PUNTOS NUMERIC(18,0), @PUNTOS_TOTALES NUMERIC(18,0), @FECHA_OBTENIDA DATETIME, @TIPO NVARCHAR(2) 

    
    DECLARE CURSOR_INSERTED CURSOR LOCAL
    FOR
    ((SELECT PQ.ID, PQ.PUNTOS_CANJEADOS, (PQ.PRECIO/5), ACTITUD_GDD.CALCULAR_FECHA_DE_VIAJE(PQ.ID_VIAJE) FECHA,'PQ'
    FROM ACTITUD_GDD.PAQUETE PQ
    WHERE (PQ.DNI = @DNI) AND ISNULL(PQ.ID_CANCELACION,0) = 0 AND (ISNULL(DATEDIFF(DAY,ACTITUD_GDD.CALCULAR_FECHA_DE_VIAJE(PQ.ID_VIAJE), @FECHA),366) < 366) AND (PQ.PUNTOS_CANJEADOS < (PQ.PRECIO/5)))
    UNION
    (SELECT PS.ID, PS.PUNTOS_CANJEADOS, (PS.PRECIO/5), ACTITUD_GDD.CALCULAR_FECHA_DE_VIAJE(PS.ID_VIAJE) FECHA, 'PS'
    FROM ACTITUD_GDD.PASAJE PS
    WHERE (PS.DNI = @DNI) AND ISNULL(PS.ID_CANCELACION,0) = 0  AND (ISNULL(DATEDIFF(DAY,ACTITUD_GDD.CALCULAR_FECHA_DE_VIAJE(PS.ID_VIAJE), @FECHA),366) < 366) AND (PS.PUNTOS_CANJEADOS < (PS.PRECIO/5)))
    )
    ORDER BY FECHA ASC
           
    OPEN CURSOR_INSERTED
    
    FETCH CURSOR_INSERTED INTO @ID, @PUNTOS_TOTALES, @PUNTOS, @FECHA_OBTENIDA, @TIPO
    WHILE @@FETCH_STATUS = 0 AND (@PTOS > 0)
    BEGIN
    
		IF(@PTOS > (@PUNTOS - @PUNTOS_TOTALES))
		BEGIN
			
			SET @PTOS = @PTOS - (@PUNTOS - @PUNTOS_TOTALES)
			
			IF(@TIPO = 'PQ')
			BEGIN
				UPDATE ACTITUD_GDD.PAQUETE
				SET PUNTOS_CANJEADOS = @PUNTOS
				WHERE ID = @ID
			END
			ELSE
			BEGIN
				UPDATE ACTITUD_GDD.PASAJE
				SET PUNTOS_CANJEADOS = @PUNTOS
				WHERE ID = @ID
			END
						
		END
		
		ELSE
		BEGIN
			
			IF(@TIPO = 'PQ')
			BEGIN
				UPDATE ACTITUD_GDD.PAQUETE
				SET PUNTOS_CANJEADOS = (PUNTOS_CANJEADOS + @PTOS)
				WHERE ID = @ID
			END
			ELSE
			BEGIN
				UPDATE ACTITUD_GDD.PASAJE
				SET PUNTOS_CANJEADOS = (PUNTOS_CANJEADOS + @PTOS)
				WHERE ID = @ID
			END
			
			SET @PTOS = 0
		END
		
		
    
    FETCH CURSOR_INSERTED INTO @ID, @PUNTOS_TOTALES, @PUNTOS, @FECHA_OBTENIDA, @TIPO
    END
    
    CLOSE CURSOR_INSERTED
    
    
    
END
GO
/****** Object:  Table [ACTITUD_GDD].[CANJE]    Script Date: 07/19/2013 05:37:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ACTITUD_GDD].[CANJE](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DNI] [numeric](18, 0) NOT NULL,
	[ID_PRODUCTO] [int] NOT NULL,
	[FECHA] [datetime] NOT NULL,
	[CANTIDAD_PRODUCTO] [int] NOT NULL,
 CONSTRAINT [PK_CANJE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[BUTACASDEMICRO]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[BUTACASDEMICRO]
	-- Add the parameters for the stored procedure here
	@PATENTE_MICRO NVARCHAR(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT BT.NUMERO NUMERO, BT.PATENTE PATENTE, BT.TIPO TIPO, BT.PISO PISO
    FROM ACTITUD_GDD.BUTACA BT
    WHERE BT.PATENTE = @PATENTE_MICRO
    
END
GO
/****** Object:  UserDefinedFunction [ACTITUD_GDD].[ID_CIUDAD]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [ACTITUD_GDD].[ID_CIUDAD]
(
	@NOMBRE_CIUDAD NVARCHAR(255)
)
RETURNS INT
AS
BEGIN
	
	RETURN (SELECT  ID
	FROM ACTITUD_GDD.CIUDAD
	WHERE NOMBRE = @NOMBRE_CIUDAD)

END
GO
/****** Object:  UserDefinedFunction [ACTITUD_GDD].[FECHA_CANCELACION]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [ACTITUD_GDD].[FECHA_CANCELACION]
(
	@ID_CANCELACION INT
)
RETURNS DATETIME
AS
BEGIN
	RETURN(SELECT FECHA_CANCELACION
	FROM ACTITUD_GDD.CANCELACION
	WHERE ID = @ID_CANCELACION)
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[CrearCancelacion]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[CrearCancelacion]
	-- Add the parameters for the stored procedure here
	@FECHA DATETIME,
	@MOTIVO NVARCHAR(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [GD1C2013].[ACTITUD_GDD].[CANCELACION]
           ([FECHA_CANCELACION]
           ,[MOTIVO_CANCELACION])
     VALUES
           (@FECHA,
           @MOTIVO)
           
     SELECT @@IDENTITY IDCANCELACION
     
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[conseguirCuotaMaxima]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[conseguirCuotaMaxima]
	-- Add the parameters for the stored procedure here
	@DESCRIPCION NVARCHAR(255)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT TP.CANT_CUOTAS CUOTASMAXIMAS
	
	FROM ACTITUD_GDD.TIPO_TARJETA TP
	
	WHERE TP.DESCRIPCION = @DESCRIPCION
	
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[EncontrarCliente]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[EncontrarCliente](

	@DNI numeric(18,0)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT TOP 1 *
	FROM ACTITUD_GDD.CLIENTE
	WHERE @DNI = DNI
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[AgregaractualizarCliente]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[AgregaractualizarCliente]
	@DNI numeric(18,0),
	@NOMBRE nvarchar(255),
	@APELLIDO nvarchar(255),
	@DIRECCION nvarchar(255),
	@TELEFONO numeric(18,0),
	@MAIL nvarchar(255),
	@FECHA_NAC datetime,
	@SEXO nchar(1),
	@DISCAPACITADO bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	if (select 1 from ACTITUD_GDD.CLIENTE where DNI = @DNI) = 1 
	begin
		UPDATE ACTITUD_GDD.CLIENTE SET NOMBRE = @NOMBRE, APELLIDO = @APELLIDO,
		DIRECCION = @DIRECCION, TELEFONO = @TELEFONO, MAIL =@MAIL, FECHA_NAC = @FECHA_NAC,
		SEXO = @SEXO, DISCAPACITADO = @DISCAPACITADO  
		WHERE DNI = @DNI
	end
	else
	begin
	
		INSERT INTO ACTITUD_GDD.CLIENTE (DNI, NOMBRE, APELLIDO, DIRECCION, TELEFONO, MAIL,
		FECHA_NAC, SEXO, DISCAPACITADO) VALUES (@DNI, @NOMBRE, @APELLIDO, @DIRECCION, @TELEFONO,
		@MAIL, @FECHA_NAC, @SEXO, @DISCAPACITADO)
	
	end
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[ESDISCAPACITADO]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[ESDISCAPACITADO]
	@DNI numeric(18,0)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	select DISCAPACITADO
	from ACTITUD_GDD.CLIENTE
	where dni = @DNI
END
GO
/****** Object:  UserDefinedFunction [ACTITUD_GDD].[CANTIDAD_BUTACAS]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [ACTITUD_GDD].[CANTIDAD_BUTACAS]
(
	@PATENTE NVARCHAR(255)
)
RETURNS INT
AS
BEGIN
	
	RETURN(SELECT COUNT(*)
		   FROM ACTITUD_GDD.BUTACA
	       WHERE PATENTE = @PATENTE)

END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[ACTUALIZARPROPIEDADESBUTACA]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[ACTUALIZARPROPIEDADESBUTACA]
	@PATENTE_MICRO nvarchar(255),
	@NUMERO numeric(18,0),
	@PISO numeric(18,0),
	@TIPO nvarchar(255)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE [GD1C2013].[ACTITUD_GDD].[BUTACA]
		SET  [TIPO] = @TIPO,[PISO] = @PISO
		WHERE NUMERO = @NUMERO and PATENTE = @PATENTE_MICRO
	
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[INSERTARBUTACA]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[INSERTARBUTACA]
	-- Add the parameters for the stored procedure here
	@PATENTE_MICRO NVARCHAR(255),
	@NUMERO NUMERIC(18,0),
	@PISO NUMERIC(18,0),
	@TIPO NVARCHAR(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO [GD1C2013].[ACTITUD_GDD].[BUTACA]
           ([NUMERO]
           ,[PATENTE]
           ,[TIPO]
           ,[PISO])
     VALUES
           (@NUMERO
           ,@PATENTE_MICRO
           ,@TIPO
           ,@PISO)



END
GO
/****** Object:  UserDefinedFunction [ACTITUD_GDD].[ID_TIPO_TARJETA]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [ACTITUD_GDD].[ID_TIPO_TARJETA]
(
	-- Add the parameters for the function here
	@DESCRIPCION NVARCHAR(255)
)
RETURNS INT
AS
BEGIN
	
	RETURN (SELECT ID
			FROM ACTITUD_GDD.TIPO_TARJETA	
			WHERE DESCRIPCION = @DESCRIPCION)

END
GO
/****** Object:  UserDefinedFunction [ACTITUD_GDD].[ID_SERVICIO]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [ACTITUD_GDD].[ID_SERVICIO]
(
	@TIPO_SERVICIO NVARCHAR(255)
)
RETURNS INT
AS
BEGIN
	
	RETURN (SELECT  ID
	FROM ACTITUD_GDD.SERVICIO
	WHERE TIPO_SERVICIO = @TIPO_SERVICIO)

END
GO
/****** Object:  UserDefinedFunction [ACTITUD_GDD].[ID_PRODUCTO]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [ACTITUD_GDD].[ID_PRODUCTO]
(
	-- Add the parameters for the function here
	@NOMBRE_PRODUCTO NVARCHAR(255)
)
RETURNS INT
AS
BEGIN

	RETURN (SELECT P.ID
			FROM ACTITUD_GDD.PRODUCTO P
			WHERE P.NOMBRE = @NOMBRE_PRODUCTO)

END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[INSERTAR_CANJE]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[INSERTAR_CANJE]
	-- Add the parameters for the stored procedure here
	@NOMBRE_PRODUCTO NVARCHAR(255),
	@CANTIDAD INT,
	@DNI NUMERIC(18,0),
	@FECHA DATETIME
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO ACTITUD_GDD.CANJE (DNI,FECHA,ID_PRODUCTO,CANTIDAD_PRODUCTO)
    VALUES(@DNI,@FECHA,ACTITUD_GDD.ID_PRODUCTO(@NOMBRE_PRODUCTO), @CANTIDAD)
   
    
        
END
GO
/****** Object:  UserDefinedFunction [ACTITUD_GDD].[ID_PRECIO_BASE]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [ACTITUD_GDD].[ID_PRECIO_BASE]
(
	@PRECIO_KG NUMERIC(18,2),
	@PRECIO_PASAJE NUMERIC(18,2)
)
RETURNS INT
AS
BEGIN
	
	RETURN (SELECT ID
	FROM ACTITUD_GDD.PRECIO_BASE
	WHERE (PRECIO_BASE_KG = @PRECIO_KG and PRECIO_BASE_PASAJE = @PRECIO_PASAJE))
	
END
GO
/****** Object:  UserDefinedFunction [ACTITUD_GDD].[ID_MODELO]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [ACTITUD_GDD].[ID_MODELO]
(
	@MARCA NVARCHAR(255),
	@MODELO NVARCHAR(255)
)
RETURNS INT
AS
BEGIN
	
	RETURN (SELECT ID
	FROM ACTITUD_GDD.MODELO
	WHERE (MARCA = @MARCA and MODELO = @MODELO))
	
END
GO
/****** Object:  UserDefinedFunction [ACTITUD_GDD].[ID_FUNCIONALIDAD]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [ACTITUD_GDD].[ID_FUNCIONALIDAD] 
(
	@FUNCIONALIDAD nvarchar(255)
)
RETURNS int
AS
BEGIN
	DECLARE @FUNCIONALIDAD_ID int

	SELECT @FUNCIONALIDAD_ID = ID FROM ACTITUD_GDD.FUNCIONALIDAD
	WHERE NOMBRE = @FUNCIONALIDAD

	RETURN @FUNCIONALIDAD_ID
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[INSERTARFUNCIONALIDADES]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [ACTITUD_GDD].[INSERTARFUNCIONALIDADES]
	@ROL_ID int,
	@FUNCIONALIDAD nvarchar(255)
AS
BEGIN
	INSERT INTO ACTITUD_GDD.FUNCIONALIDADXROL (ID_ROL, ID_FUNCIONALIDAD)
	VALUES (@ROL_ID, ACTITUD_GDD.ID_FUNCIONALIDAD(@FUNCIONALIDAD))
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[LISTARCIUDADES]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[LISTARCIUDADES]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT *
	FROM ACTITUD_GDD.CIUDAD
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[ListarFuncionalidad]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[ListarFuncionalidad]
AS
BEGIN
	SELECT *
	FROM ACTITUD_GDD.FUNCIONALIDAD
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[ListarClientes]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[ListarClientes]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT *
	FROM ACTITUD_GDD.CLIENTE
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[LISTARCIUDADESMENOSCIUDAD]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[LISTARCIUDADESMENOSCIUDAD]
@CIUDAD nvarchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT *
	FROM ACTITUD_GDD.CIUDAD
	where NOMBRE != @CIUDAD
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[LISTARMODELOSDEMARCA]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create  PROCEDURE [ACTITUD_GDD].[LISTARMODELOSDEMARCA]
@MARCA nvarchar(255)
AS
BEGIN
	SELECT *
	FROM ACTITUD_GDD.MODELO
	where MARCA = @MARCA
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[LISTARMODELOS]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[LISTARMODELOS]
AS
BEGIN
	SELECT *
	FROM ACTITUD_GDD.MODELO
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[LISTARSERVICIOS]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [ACTITUD_GDD].[LISTARSERVICIOS]
AS
BEGIN
	SELECT *
	FROM ACTITUD_GDD.SERVICIO
	
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[LISTARMARCASDEMODELO]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create  PROCEDURE [ACTITUD_GDD].[LISTARMARCASDEMODELO]
@MODELO nvarchar(255)
AS
BEGIN
	SELECT *
	FROM ACTITUD_GDD.MODELO
	where MODELO = @MODELO
END
GO
/****** Object:  UserDefinedFunction [ACTITUD_GDD].[PENSIONADO]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [ACTITUD_GDD].[PENSIONADO]
(
	@FNACIMIENTO DATETIME,
	@GENERO NCHAR(1),
	@FECHA_DE_HOY DATETIME
)
RETURNS BIT
AS
BEGIN
	DECLARE @EDAD int
	SET @EDAD = ACTITUD_GDD.CALCULAR_EDAD(@FNACIMIENTO,@FECHA_DE_HOY)
	IF (@EDAD >= 65)
	BEGIN
		RETURN 1
	END
	IF (@EDAD < 60)
	BEGIN
		RETURN 0
	END
	IF (@GENERO = 'F')
	BEGIN
		RETURN 1
	END
	IF (@GENERO = 'M')
	BEGIN
		RETURN 0
	END
	RETURN NULL
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[MIGRAR_CLIENTE]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[MIGRAR_CLIENTE] 
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO ACTITUD_GDD.CLIENTE (DNI, NOMBRE, APELLIDO, DIRECCION, TELEFONO, MAIL, FECHA_NAC)
	SELECT Cli_Dni, Cli_Nombre, Cli_Apellido, Cli_Dir, Cli_Telefono, Cli_Mail, Cli_Fecha_Nac
	FROM gd_esquema.Maestra
	GROUP BY Cli_Dni, Cli_Nombre, Cli_Apellido, Cli_Dir, Cli_Telefono, Cli_Mail, Cli_Fecha_Nac
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[MIGRAR_CIUDAD]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[MIGRAR_CIUDAD]
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO ACTITUD_GDD.CIUDAD (NOMBRE)
	SELECT Recorrido_Ciudad_Origen
	FROM gd_esquema.Maestra
	GROUP BY Recorrido_Ciudad_Origen
	UNION
	SELECT Recorrido_Ciudad_Destino
	FROM gd_esquema.Maestra
	GROUP BY Recorrido_Ciudad_Destino

END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[MIGRAR_BUTACA]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[MIGRAR_BUTACA]

AS
BEGIN
	SET NOCOUNT ON;
	
	INSERT INTO ACTITUD_GDD.BUTACA (PATENTE, NUMERO, PISO, TIPO)
	SELECT Micro_Patente, Butaca_Nro, Butaca_Piso, Butaca_Tipo
	FROM gd_esquema.Maestra
	WHERE Butaca_Tipo != '0'
	GROUP BY Micro_Patente, Butaca_Nro, Butaca_Piso, Butaca_Tipo

END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[MIGRAR_PRECIO_BASE]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[MIGRAR_PRECIO_BASE]
AS
BEGIN
	SET NOCOUNT ON;
	
	INSERT INTO ACTITUD_GDD.PRECIO_BASE (PRECIO_BASE_KG, PRECIO_BASE_PASAJE)
	SELECT	DISTINCT SUM(DISTINCT Recorrido_Precio_BaseKG), SUM(DISTINCT Recorrido_Precio_BasePasaje)
	FROM gd_esquema.Maestra
	GROUP BY Recorrido_Codigo
	
	
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[MIGRAR_MODELO]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[MIGRAR_MODELO]
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO ACTITUD_GDD.MODELO (MARCA, MODELO)
	SELECT Micro_Marca, Micro_Modelo
	FROM gd_esquema.Maestra
	GROUP BY Micro_Marca, Micro_Modelo

END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[MIGRAR_SERVICIO]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[MIGRAR_SERVICIO]

AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO ACTITUD_GDD.SERVICIO (TIPO_SERVICIO , RECARGO)
	SELECT Tipo_Servicio,ROUND(((SUM(Pasaje_Precio) / SUM(Recorrido_Precio_BasePasaje)) -1)*100,1)
	FROM gd_esquema.Maestra
	GROUP BY Tipo_Servicio

END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[ListarTiposTarjeta]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[ListarTiposTarjeta] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	
	SELECT DESCRIPCION
	FROM ACTITUD_GDD.TIPO_TARJETA TP
	
	
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[ListarServiciosCiudadOrigenDestino]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[ListarServiciosCiudadOrigenDestino] 
	@CIUDAD_ORIGEN nvarchar(255),
	@CIUDAD_DESTINO nvarchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	select SV.ID ID, SV.TIPO_SERVICIO TIPO_SERVICIO, SV.RECARGO RECARGO
	from ACTITUD_GDD.RECORRIDO RE join ACTITUD_GDD.SERVICIO SV ON (SV.ID = RE.ID_SERVICIO)
	where RE.ID_CIUDAD_ORIGEN = ACTITUD_GDD.ID_CIUDAD(@CIUDAD_ORIGEN) AND RE.ID_CIUDAD_DESTINO = ACTITUD_GDD.ID_CIUDAD(@CIUDAD_DESTINO) and re.BAJA_LOGICA = 0
	
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[MIGRAR_RECORRIDO]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[MIGRAR_RECORRIDO]
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO ACTITUD_GDD.RECORRIDO (RECORRIDO_CODIGO, ID_CIUDAD_ORIGEN, ID_CIUDAD_DESTINO, ID_SERVICIO, ID_PRECIO_BASE)
	SELECT Recorrido_Codigo, ACTITUD_GDD.ID_CIUDAD(Recorrido_Ciudad_Origen), ACTITUD_GDD.ID_CIUDAD(Recorrido_Ciudad_Destino), ACTITUD_GDD.ID_SERVICIO(Tipo_Servicio), ACTITUD_GDD.ID_PRECIO_BASE(SUM ( DISTINCT Recorrido_Precio_BaseKG), SUM ( DISTINCT Recorrido_Precio_BasePasaje))
	FROM gd_esquema.Maestra
	GROUP BY Recorrido_Codigo, Recorrido_Ciudad_Origen, Recorrido_Ciudad_Destino, Tipo_Servicio

END
GO
/****** Object:  UserDefinedFunction [ACTITUD_GDD].[MICRO_REEMPLAZABLE]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [ACTITUD_GDD].[MICRO_REEMPLAZABLE] 
(
	-- Add the parameters for the function here
	@POR_EL_QUE_QUIERO_REEMPLAZAR NVARCHAR(255),
	@EL_QUE_QUIERO_REEMPLAZAR NVARCHAR(255)
)
RETURNS BIT
AS
BEGIN
	DECLARE @RETORNO BIT
	SET @RETORNO = 0
	
	
	SELECT @RETORNO = 1
	FROM ACTITUD_GDD.MICRO MC1, ACTITUD_GDD.MICRO MC2
	WHERE (MC1.PATENTE = @POR_EL_QUE_QUIERO_REEMPLAZAR) AND 
		  (MC2.PATENTE = @EL_QUE_QUIERO_REEMPLAZAR) AND
		  (MC2.KG_DISPONIBLES <= MC1.KG_DISPONIBLES) AND
		  (ACTITUD_GDD.CANTIDAD_BUTACAS(MC2.PATENTE) <= ACTITUD_GDD.CANTIDAD_BUTACAS(MC1.PATENTE)AND
		  (MC1.TIPO_SERVICIO = MC2.TIPO_SERVICIO))
	
	
	
	
	RETURN @RETORNO 

END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[ListarRecorrido]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [ACTITUD_GDD].[ListarRecorrido]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT R.RECORRIDO_CODIGO, ACTITUD_GDD.NOMBRE_CIUDAD (R.ID_CIUDAD_DESTINO) CIUDAD_DESTINO, ACTITUD_GDD.NOMBRE_CIUDAD (R.ID_CIUDAD_ORIGEN)CIUDAD_ORIGEN,S.TIPO_SERVICIO TIPO_SERVICIO,S.RECARGO RECARGO ,B.PRECIO_BASE_KG PRECIO_BASE_KG,B.PRECIO_BASE_PASAJE PRECIO_BASE_PASAJE, R.BAJA_LOGICA BAJA_LOGICA
	FROM ACTITUD_GDD.RECORRIDO R JOIN ACTITUD_GDD.PRECIO_BASE B ON (R.ID_PRECIO_BASE = B.ID) JOIN ACTITUD_GDD.SERVICIO S ON (S.ID = R.ID_SERVICIO)
		
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[ListarMicros]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[ListarMicros] 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT MC.PATENTE, ACTITUD_GDD.NOMBRE_TIPO_SERVICIO(MC.TIPO_SERVICIO) TIPO_SERVICIO, MC.FECHA_ALTA, MC.FECHA_BAJA_DEFINITIVA, MC.KG_DISPONIBLES, MD.MODELO, MD.MARCA
    FROM ACTITUD_GDD.MICRO MC JOIN ACTITUD_GDD.MODELO MD ON (MC.ID_MODELO = MD.ID)
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[LISTARCIUDADESCONRECORRIDO]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[LISTARCIUDADESCONRECORRIDO]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT distinct CD.ID ID, CD.NOMBRE NOMBRE
	FROM ACTITUD_GDD.CIUDAD CD JOIN ACTITUD_GDD.RECORRIDO RE ON (RE.ID_CIUDAD_ORIGEN = CD.ID)
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[LISTARCIUDADESSALIENDODE]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[LISTARCIUDADESSALIENDODE] 
	@CIUDAD nvarchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	select distinct CD.ID ID, CD.NOMBRE NOMBRE
	from ACTITUD_GDD.RECORRIDO RE join ACTITUD_GDD.CIUDAD CD ON (CD.ID = RE.ID_CIUDAD_DESTINO)
	where RE.ID_CIUDAD_ORIGEN = ACTITUD_GDD.ID_CIUDAD(@CIUDAD) and re.BAJA_LOGICA = 0
	
END
GO
/****** Object:  UserDefinedFunction [ACTITUD_GDD].[ID_CIUDAD_ORIGEN]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [ACTITUD_GDD].[ID_CIUDAD_ORIGEN] 
(
	-- Add the parameters for the function here
	@RECORRIDO_CODIGO NUMERIC(18,0)
)
RETURNS INT
AS
BEGIN
	
	RETURN(SELECT R.ID_CIUDAD_ORIGEN
		   FROM ACTITUD_GDD.RECORRIDO R
		   WHERE R.RECORRIDO_CODIGO = @RECORRIDO_CODIGO)

END
GO
/****** Object:  UserDefinedFunction [ACTITUD_GDD].[ID_CIUDAD_DESTINO]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [ACTITUD_GDD].[ID_CIUDAD_DESTINO]
(
	-- Add the parameters for the function here
	@RECORRIDO_CODIGO NUMERIC(18,0)
)
RETURNS INT
AS
BEGIN
	
	RETURN(SELECT R.ID_CIUDAD_DESTINO
		   FROM ACTITUD_GDD.RECORRIDO R
		   WHERE R.RECORRIDO_CODIGO = @RECORRIDO_CODIGO)

END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[INSERTAR_RECORRIDO]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [ACTITUD_GDD].[INSERTAR_RECORRIDO]
	@CIUDAD_ORIGEN NVARCHAR(255),
	@CIUDAD_DESTINO NVARCHAR(255),
	@TIPO_SERVICIO NVARCHAR(255),
	@PRECIO_BASE_KG  NUMERIC(12,2),
	@PRECIO_BASE_PASAJE NUMERIC(12,2)
	
AS
BEGIN
	DECLARE @ID_PRECIO_BASE INT, @RECORRIDO_CODIGO INT
	
	SELECT TOP 1 @RECORRIDO_CODIGO = RECORRIDO_CODIGO
	FROM ACTITUD_GDD.RECORRIDO
	ORDER BY RECORRIDO_CODIGO DESC
	
	SET @RECORRIDO_CODIGO = @RECORRIDO_CODIGO + 1
	
	SET @ID_PRECIO_BASE = ACTITUD_GDD.ID_PRECIO_BASE(@PRECIO_BASE_KG,@PRECIO_BASE_PASAJE)
	
	SET NOCOUNT ON;
	
	IF ISNULL(@ID_PRECIO_BASE, 0) = 0
	BEGIN
		INSERT INTO ACTITUD_GDD.PRECIO_BASE (PRECIO_BASE_KG, PRECIO_BASE_PASAJE)
		VALUES (@PRECIO_BASE_KG, @PRECIO_BASE_PASAJE)
		
		SET @ID_PRECIO_BASE = @@IDENTITY
	END
	
	declare @existe int
	set @existe = 0
	select @existe = re.RECORRIDO_CODIGO
	from ACTITUD_GDD.RECORRIDO re
	where re.BAJA_LOGICA = 0 and  re.ID_CIUDAD_DESTINO = ACTITUD_GDD.ID_CIUDAD(@CIUDAD_DESTINO)
		and re.ID_CIUDAD_ORIGEN = ACTITUD_GDD.ID_CIUDAD(@CIUDAD_ORIGEN) and re.ID_SERVICIO =  ACTITUD_GDD.ID_SERVICIO(@TIPO_SERVICIO)
	
	
	if @existe != 0
	begin
		UPDATE [GD1C2013].[ACTITUD_GDD].[RECORRIDO]
	SET [ID_PRECIO_BASE] = @ID_PRECIO_BASE
	WHERE recorrido_codigo = @existe


	end
	else
	begin
		INSERT INTO ACTITUD_GDD.RECORRIDO (RECORRIDO_CODIGO, ID_CIUDAD_ORIGEN, ID_CIUDAD_DESTINO, ID_SERVICIO, ID_PRECIO_BASE) VALUES (@RECORRIDO_CODIGO, ACTITUD_GDD.ID_CIUDAD(@CIUDAD_ORIGEN), 
		ACTITUD_GDD.ID_CIUDAD(@CIUDAD_DESTINO), ACTITUD_GDD.ID_SERVICIO(@TIPO_SERVICIO), @ID_PRECIO_BASE )
		SELECT @RECORRIDO_CODIGO AS RECORRIDO_CODIGO
	end
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[INSERTAR_MICRO]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [ACTITUD_GDD].[INSERTAR_MICRO]
	@PATENTE nvarchar(100),
	@KG_DISPONIBLES NUMERIC(18,0),
	@TIPO_SERVICIO nvarchar(255),
	@MODELO nvarchar(255),
	@MARCA nvarchar(255),
	@FECHA_ALTA DATETIME
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO ACTITUD_GDD.MICRO(PATENTE, KG_DISPONIBLES, TIPO_SERVICIO, ID_MODELO, FECHA_ALTA) VALUES (@PATENTE, @KG_DISPONIBLES, ACTITUD_GDD.ID_SERVICIO(@TIPO_SERVICIO), ACTITUD_GDD.ID_MODELO(@MARCA,@MODELO), @FECHA_ALTA)
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[INSERTAR_COMPRA]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[INSERTAR_COMPRA] 

	@IDCOMPRA INT OUTPUT,
	@ULTIMAFECHA DATETIME OUTPUT,
	@ULTIMODNI NUMERIC(18,0) OUTPUT,
	@DNI NUMERIC(18,0),
	@PAQUETEFECHA DATETIME

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
		
	
	
	IF(@ULTIMAFECHA < @PAQUETEFECHA OR @ULTIMODNI < @DNI) 
	BEGIN
		INSERT INTO ACTITUD_GDD.COMPRA(DNI,FECHA_COMP,FORMA_DE_PAGO)
		VALUES (@DNI,@PAQUETEFECHA,'E')
		SET @IDCOMPRA = @@IDENTITY
		SET @ULTIMAFECHA = @PAQUETEFECHA
		SET @ULTIMODNI = @DNI
	END
    
  
  
  
  
  
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[IDRecorrido]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[IDRecorrido](
	@CIUDAD_ORIGEN nvarchar(255),
	@CIUDAD_DESTINO nvarchar(255),
	@TIPO_SERVICIO nvarchar(255)
)AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	select re.RECORRIDO_CODIGO CODIGO_RECORRIDO
	from ACTITUD_GDD.RECORRIDO re
	where re.ID_CIUDAD_DESTINO = ACTITUD_GDD.ID_CIUDAD(@CIUDAD_DESTINO) AND re.ID_CIUDAD_ORIGEN = ACTITUD_GDD.ID_CIUDAD(@CIUDAD_ORIGEN) 
	AND re.ID_SERVICIO = ACTITUD_GDD.ID_SERVICIO(@TIPO_SERVICIO) and re.BAJA_LOGICA = 0
	
		
END
GO
/****** Object:  UserDefinedFunction [ACTITUD_GDD].[FECHA_COMPRA]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [ACTITUD_GDD].[FECHA_COMPRA]
(
	@COD_COMPRA INT
)
RETURNS DATETIME
AS
BEGIN
	RETURN (SELECT FECHA_COMP
	FROM ACTITUD_GDD.COMPRA
	WHERE ID = @COD_COMPRA)

END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[ACTUALIZARRECORRIDO]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [ACTITUD_GDD].[ACTUALIZARRECORRIDO]
	@RECORRIDO_CODIGO NUMERIC(18,0),
	@CIUDAD_ORIGEN NVARCHAR(255),
	@CIUDAD_DESTINO NVARCHAR(255),
	@TIPO_SERVICIO NVARCHAR(255),
	@PRECIO_BASE_KG  NUMERIC(12,2),
	@PRECIO_BASE_PASAJE NUMERIC(12,2)
AS
BEGIN
	DECLARE @ID_PRECIO_BASE INT
	
	SET @ID_PRECIO_BASE = ACTITUD_GDD.ID_PRECIO_BASE(@PRECIO_BASE_KG,@PRECIO_BASE_PASAJE)
	SET NOCOUNT ON;
	IF ISNULL(@ID_PRECIO_BASE, 0) = 0
	BEGIN
		INSERT INTO ACTITUD_GDD.PRECIO_BASE (PRECIO_BASE_KG, PRECIO_BASE_PASAJE)
		VALUES (@PRECIO_BASE_KG, @PRECIO_BASE_PASAJE)
		
		SET @ID_PRECIO_BASE = @@IDENTITY
	END


	SET NOCOUNT ON;
	UPDATE ACTITUD_GDD.RECORRIDO SET ID_CIUDAD_ORIGEN = ACTITUD_GDD.ID_CIUDAD(@CIUDAD_ORIGEN),
	ID_CIUDAD_DESTINO = ACTITUD_GDD.ID_CIUDAD(@CIUDAD_DESTINO),
	ID_SERVICIO = ACTITUD_GDD.ID_SERVICIO(@TIPO_SERVICIO),
	ID_PRECIO_BASE = @ID_PRECIO_BASE
	WHERE RECORRIDO_CODIGO = @RECORRIDO_CODIGO
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[ACTUALIZARMICRO]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [ACTITUD_GDD].[ACTUALIZARMICRO]
	@PATENTE nvarchar(100),
	@KG_DISPONIBLES NUMERIC(18,0),
	@TIPO_SERVICIO nvarchar(255),
	@MODELO nvarchar(255),
	@MARCA nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE ACTITUD_GDD.MICRO SET KG_DISPONIBLES = @KG_DISPONIBLES, 
	TIPO_SERVICIO = ACTITUD_GDD.ID_SERVICIO(@TIPO_SERVICIO),
	ID_MODELO = ACTITUD_GDD.ID_MODELO(@MARCA, @MODELO)
	WHERE PATENTE = @PATENTE
END
GO
/****** Object:  UserDefinedFunction [ACTITUD_GDD].[ES_PENSIONADO]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [ACTITUD_GDD].[ES_PENSIONADO]
(
	-- Add the parameters for the function here
	@DNI NUMERIC(18),
	@FECHA_ACTUAL DATE
)
RETURNS BIT
AS
BEGIN
	DECLARE @GENERO NCHAR(1)
	DECLARE @FECHA_NACIMIENTO DATE
	
	SET @GENERO = NULL
	
	SELECT @GENERO = CL.SEXO, @FECHA_NACIMIENTO = CL.FECHA_NAC
	FROM ACTITUD_GDD.CLIENTE CL
	WHERE CL.DNI = @DNI
	
	RETURN ACTITUD_GDD.PENSIONADO(@FECHA_NACIMIENTO, @GENERO, @FECHA_ACTUAL)

END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[ELIMINAR_MICRO]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[ELIMINAR_MICRO]
	-- Add the parameters for the stored procedure here
	@PATENTE NVARCHAR(255),
	@FECHA_BAJA DATETIME
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	UPDATE [GD1C2013].[ACTITUD_GDD].[MICRO]
	SET 
      [FECHA_BAJA_DEFINITIVA] = @FECHA_BAJA
    WHERE PATENTE = @PATENTE


   
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[CREARCOMPRA]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[CREARCOMPRA] 
	@DNI NUMERIC(18,0)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

INSERT INTO [GD1C2013].[ACTITUD_GDD].[COMPRA]
           ([DNI])
     VALUES
           (@DNI)

     SELECT @@IDENTITY AS ID_COMPRA
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[CONFIRMARCOMPRA]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[CONFIRMARCOMPRA]
	-- Add the parameters for the stored procedure here
	@ID_COMPRA INT,
	@DNI NUMERIC(18,0),
	@CODIGO_TARJETA INT,
	@FECHA_COMPRA DATETIME
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    IF(@CODIGO_TARJETA = -1)
		BEGIN
			UPDATE [GD1C2013].[ACTITUD_GDD].[COMPRA]
			SET [DNI] = @DNI
			,[FECHA_COMP] = @FECHA_COMPRA
			,[FORMA_DE_PAGO] = 'E'
			,[ID_TARJETA_CREDITO] = NULL
			WHERE ID = @ID_COMPRA
		END
	ELSE
		BEGIN
			UPDATE [GD1C2013].[ACTITUD_GDD].[COMPRA]
			SET [DNI] = @DNI
			,[FECHA_COMP] = @FECHA_COMPRA
			,[FORMA_DE_PAGO] = 'T'
			,[ID_TARJETA_CREDITO] = @CODIGO_TARJETA				
			WHERE ID = @ID_COMPRA
		END
		
		
    
	
END
GO
/****** Object:  UserDefinedFunction [ACTITUD_GDD].[BUTACA_PROXIMA]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [ACTITUD_GDD].[BUTACA_PROXIMA]
(
	@BUTACA_ANTERIOR INT,
	@MICRO_ELEGIDO NVARCHAR(255)
)
RETURNS NUMERIC(18,0)
AS
BEGIN
	
	DECLARE @BUTACA NUMERIC(18,0)
	
	IF( @BUTACA_ANTERIOR = -1)
	BEGIN
		SELECT TOP 1 @BUTACA = BT.NUMERO
		FROM ACTITUD_GDD.MICRO MC JOIN ACTITUD_GDD.BUTACA BT ON (MC.PATENTE = BT.PATENTE)
		WHERE MC.PATENTE = @MICRO_ELEGIDO
		ORDER BY BT.NUMERO ASC
	END
	ELSE
	BEGIN
		SELECT TOP 1 @BUTACA = BT.NUMERO
		FROM ACTITUD_GDD.MICRO MC JOIN ACTITUD_GDD.BUTACA BT ON (MC.PATENTE = BT.PATENTE)
		WHERE MC.PATENTE = @MICRO_ELEGIDO AND BT.NUMERO > @BUTACA_ANTERIOR
		ORDER BY BT.NUMERO ASC
	END
	
	
	
	RETURN @BUTACA

END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[CargarNuevaTarjeta]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[CargarNuevaTarjeta] 
	-- Add the parameters for the stored procedure here
	@DNI NUMERIC(18,0),
	@ID INT,
	@CODIGO NVARCHAR(100),
	@VENCIMIENTO DATE,
	@DESCRIPCION NVARCHAR(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    
    INSERT INTO [GD1C2013].[ACTITUD_GDD].[TARJETA_DE_CREDITO]
           ([ID]
           ,[DNI]
           ,[CODIGO_SEGURIDAD]
           ,[FECHA_VENC]
           ,[ID_TIPO])
     VALUES
           (@ID
           ,@DNI
           ,@CODIGO
           ,@VENCIMIENTO
           ,ACTITUD_GDD.ID_TIPO_TARJETA(@DESCRIPCION))
    
    
END
GO
/****** Object:  Table [ACTITUD_GDD].[BAJA_TEMPORAL]    Script Date: 07/19/2013 05:37:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ACTITUD_GDD].[BAJA_TEMPORAL](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PATENTE] [nvarchar](255) NOT NULL,
	[FECHA_FUERA_SERVICIO] [datetime] NOT NULL,
	[FECHA_REINICIO_SERVICIO] [datetime] NOT NULL,
 CONSTRAINT [PK_BAJA_TEMPORAL] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[MIGRAR_MICRO]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[MIGRAR_MICRO]
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO ACTITUD_GDD.MICRO (PATENTE, TIPO_SERVICIO, ID_MODELO, KG_DISPONIBLES)
	SELECT Micro_Patente, ACTITUD_GDD.ID_SERVICIO(Tipo_Servicio), ACTITUD_GDD.ID_MODELO(Micro_Marca, Micro_Modelo), Micro_KG_Disponibles
	FROM gd_esquema.Maestra
	GROUP BY Micro_Patente, Tipo_Servicio, Micro_Marca, Micro_Modelo, Micro_KG_Disponibles
	ORDER BY MICRO_PATENTE

END
GO
/****** Object:  UserDefinedFunction [ACTITUD_GDD].[PRECIO_DE_PASAJE]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [ACTITUD_GDD].[PRECIO_DE_PASAJE]
(
	@RECORRIDO_CODIGO NUMERIC(18,0)
)
RETURNS NUMERIC(18,2)
AS
BEGIN
	
	RETURN( SELECT (PB.PRECIO_BASE_PASAJE * (1 + (S.RECARGO / 100)))
			FROM RECORRIDO R JOIN SERVICIO S ON (R.ID_SERVICIO = S.ID) JOIN PRECIO_BASE PB ON (R.ID_PRECIO_BASE = PB.ID)
			WHERE @RECORRIDO_CODIGO = R.RECORRIDO_CODIGO
		  )

END
GO
/****** Object:  UserDefinedFunction [ACTITUD_GDD].[PRECIO_DE_PAQUETE]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [ACTITUD_GDD].[PRECIO_DE_PAQUETE]
(
	@RECORRIDO_CODIGO NUMERIC(18,0),
	@PESO NUMERIC(18,0)
)
RETURNS NUMERIC(18,2)
AS
BEGIN
		RETURN( SELECT (PB.PRECIO_BASE_KG * @PESO)
			FROM RECORRIDO R JOIN PRECIO_BASE PB ON (R.ID_PRECIO_BASE = PB.ID)
			WHERE @RECORRIDO_CODIGO = R.RECORRIDO_CODIGO
		  )

END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[CalcularSetearMontoPaquetes]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[CalcularSetearMontoPaquetes]
	-- Add the parameters for the stored procedure here
	@ID INT
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   
   
	
	
	UPDATE [GD1C2013].[ACTITUD_GDD].[PAQUETE]
	SET 	 
		 [PRECIO] = ACTITUD_GDD.PRECIO_DE_PAQUETE(
		 (SELECT TOP 1 VJ.RECORRIDO_CODIGO
		  FROM ACTITUD_GDD.VIAJE VJ
		  WHERE VJ.ID = ID_VIAJE)
		 ,PESO)
	WHERE ID_COMPRA = @ID
   
   
   SELECT ISNULL(SUM(PQ.PRECIO),0) MONTO
   FROM ACTITUD_GDD.PAQUETE PQ
   WHERE PQ.ID_COMPRA = @ID
   
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[ObtenerTarjetaCompra]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[ObtenerTarjetaCompra]
	-- Add the parameters for the stored procedure here
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT TOP 1 ISNULL(CMP.ID_TARJETA_CREDITO,-1) as IDTARJETA
	FROM ACTITUD_GDD.COMPRA CMP
	WHERE CMP.ID = @ID
	
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[ObtenerTarjeta]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[ObtenerTarjeta]
	-- Add the parameters for the stored procedure here
	@DNI numeric(18,0),
	@ID int
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    
    SELECT TOP 1 TJ.CODIGO_SEGURIDAD CODIGO_SEGURIDAD, TP.CANT_CUOTAS CANT_CUOTAS, TP.DESCRIPCION DESCRIPCION, TJ.FECHA_VENC VENCIMIENTO
    FROM ACTITUD_GDD.CLIENTE CL JOIN ACTITUD_GDD.TARJETA_DE_CREDITO TJ ON (CL.DNI = TJ.DNI) JOIN ACTITUD_GDD.TIPO_TARJETA TP ON (TJ.ID_TIPO = TP.ID)
    WHERE CL.DNI = @DNI AND TJ.ID = @ID
    
    
END
GO
/****** Object:  UserDefinedFunction [ACTITUD_GDD].[NoSalio]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [ACTITUD_GDD].[NoSalio]
(
	-- Add the parameters for the function here
	@ID_VIAJE INT, 
	@FECHA DATETIME
)
RETURNS BIT
AS
BEGIN
	DECLARE @FECHA_SALIDA DATETIME
	
	
	SELECT @FECHA_SALIDA = VJ.FECHA_SALIDA
	FROM ACTITUD_GDD.VIAJE VJ
	WHERE VJ.ID = @ID_VIAJE AND (ISNULL(VJ.FECHA_LLEGADA, 0) = 0)
	
	
	IF(@FECHA < @FECHA_SALIDA)
	BEGIN
	RETURN 0
	END
	
	RETURN 1
	

END
GO
/****** Object:  UserDefinedFunction [ACTITUD_GDD].[VIAJE_CON_BAJA_LOGICA]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [ACTITUD_GDD].[VIAJE_CON_BAJA_LOGICA] 
(
	-- Add the parameters for the function here
	@ID_VIAJE INT
)
RETURNS BIT
AS
BEGIN
	RETURN(SELECT VJ.BAJA_LOGICA
		   FROM ACTITUD_GDD.VIAJE VJ
		   WHERE VJ.ID = @ID_VIAJE
	)
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[TOP5MICROS]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[TOP5MICROS]
	-- Add the parameters for the stored procedure here
	@FECHA datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DECLARE @FECHA_INICIO_SEMESTRE DATETIME
	SET @FECHA_INICIO_SEMESTRE = DATEDIFF(DAY,182,@FECHA)
	
		select TOP 5 SUM(ACTITUD_GDD.CANTIDAD_DIAS_QUE_SE_CRUZAN(@FECHA_INICIO_SEMESTRE, @FECHA, BT.FECHA_FUERA_SERVICIO, BT.FECHA_REINICIO_SERVICIO)) [Días Fuera de Servicio], BT.PATENTE [Patente]
		from ACTITUD_GDD.BAJA_TEMPORAL BT
		where (BT.FECHA_FUERA_SERVICIO < @FECHA) AND ( FECHA_REINICIO_SERVICIO > @FECHA_INICIO_SEMESTRE)
		group by BT.PATENTE
		having SUM(ACTITUD_GDD.CANTIDAD_DIAS_QUE_SE_CRUZAN(@FECHA_INICIO_SEMESTRE, @FECHA, BT.FECHA_FUERA_SERVICIO, BT.FECHA_REINICIO_SERVICIO)) > 0
		ORDER BY SUM(ACTITUD_GDD.CANTIDAD_DIAS_QUE_SE_CRUZAN(@FECHA_INICIO_SEMESTRE, @FECHA, BT.FECHA_FUERA_SERVICIO, BT.FECHA_REINICIO_SERVICIO)) DESC

END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[BUSCAR_ID_VIAJE]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[BUSCAR_ID_VIAJE]	
(@PATENTE NVARCHAR(255),
@CIUDAD_ORIGEN NVARCHAR(255),
@CIUDAD_DESTINO NVARCHAR(255),
@FECHA_LLEGADA DATETIME )
AS
BEGIN
	SELECT TOP 1(VJ.ID) ID_VIAJE
	FROM ACTITUD_GDD.VIAJE VJ JOIN ACTITUD_GDD.RECORRIDO RE ON (VJ.RECORRIDO_CODIGO = RE.RECORRIDO_CODIGO)
	WHERE VJ.PATENTE = @PATENTE 
	AND RE.ID_CIUDAD_DESTINO = ACTITUD_GDD.ID_CIUDAD(@CIUDAD_DESTINO) 
	AND RE.ID_CIUDAD_ORIGEN = ACTITUD_GDD.ID_CIUDAD(@CIUDAD_ORIGEN) 
	AND VJ.FECHA_LLEGADA IS NULL
	AND VJ.BAJA_LOGICA = 0
	AND VJ.FECHA_SALIDA < @FECHA_LLEGADA
	ORDER BY VJ.FECHA_SALIDA ASC
	
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[ANIOS_POSIBLES]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[ANIOS_POSIBLES]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT isnull(MAX( YEAR(BT.FECHA_REINICIO_SERVICIO)),0) as valor
	FROM ACTITUD_GDD.BAJA_TEMPORAL BT

END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[CARGAR_FECHAS_LLEGADAS_MICROS]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[CARGAR_FECHAS_LLEGADAS_MICROS]
	@FECHA_LLEGADA DATETIME,
	@ID_VIAJE INT
AS
BEGIN
	
	UPDATE ACTITUD_GDD.VIAJE SET FECHA_LLEGADA = @FECHA_LLEGADA WHERE @ID_VIAJE = ID
		
END
GO
/****** Object:  UserDefinedFunction [ACTITUD_GDD].[ESTA_DISPONIBLE]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [ACTITUD_GDD].[ESTA_DISPONIBLE]
(
	-- Add the parameters for the function here
	@MIC_PATENTE NVARCHAR(255),
	@FECHA_SALIDA DATETIME,
	@FECHA_LLEGADA_ESTIMADA DATETIME,
	@ID_CIUDAD_ORIGEN INT,
	@ID_CIUDAD_DESTINO INT
	
)
RETURNS BIT
AS
BEGIN
	-- 1 si está disponible, 0 sino
	DECLARE @RETORNO BIT
	SET @RETORNO = 1
	
	
	SELECT @RETORNO = 0
	FROM ACTITUD_GDD.VIAJE VJ 
	WHERE VJ.PATENTE = @MIC_PATENTE AND 
	NOT((((@ID_CIUDAD_DESTINO != ACTITUD_GDD.ID_CIUDAD_ORIGEN(VJ.RECORRIDO_CODIGO)))AND((DATEADD(DAY,1,@FECHA_LLEGADA_ESTIMADA) <= VJ.FECHA_SALIDA))) OR 
	(((@ID_CIUDAD_ORIGEN != ACTITUD_GDD.ID_CIUDAD_DESTINO(VJ.RECORRIDO_CODIGO)))AND(@FECHA_SALIDA >= (DATEADD(DAY,1,VJ.FECHA_LLEGADA_ESTIMADA)))) OR
	((@ID_CIUDAD_DESTINO = ACTITUD_GDD.ID_CIUDAD_ORIGEN(VJ.RECORRIDO_CODIGO)) AND (@FECHA_LLEGADA_ESTIMADA < VJ.FECHA_SALIDA)) OR
	((@ID_CIUDAD_ORIGEN = ACTITUD_GDD.ID_CIUDAD_DESTINO(VJ.RECORRIDO_CODIGO))AND(@FECHA_SALIDA > VJ.FECHA_LLEGADA_ESTIMADA))
	)
	
	RETURN @RETORNO
END
GO
/****** Object:  UserDefinedFunction [ACTITUD_GDD].[ESTA_DADO_DE_BAJA_TEMPORAL]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [ACTITUD_GDD].[ESTA_DADO_DE_BAJA_TEMPORAL]
(
	-- Add the parameters for the function here
	@MIC_PATENTE NVARCHAR(255),
	@FECHA_SALIDA DATETIME,
	@FECHA_LLEGADA_ESTIMADA DATETIME
)
RETURNS BIT
AS
BEGIN
	
	--1 Si está dado de baja temporal para esa fecha, 0 sino
	
	DECLARE @RETORNO BIT
	
	SET @RETORNO = 0
	
	
	SELECT @RETORNO = 1
	FROM ACTITUD_GDD.BAJA_TEMPORAL BT
	WHERE BT.PATENTE = @MIC_PATENTE AND (@FECHA_SALIDA <= BT.FECHA_REINICIO_SERVICIO AND @FECHA_LLEGADA_ESTIMADA >= BT.FECHA_FUERA_SERVICIO) 
	
	
	RETURN @RETORNO
	
	
END
GO
/****** Object:  UserDefinedFunction [ACTITUD_GDD].[FECHA_PRIMER_VIAJE]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [ACTITUD_GDD].[FECHA_PRIMER_VIAJE]
(
	-- Add the parameters for the function here
	@PATENTE NVARCHAR(255)
)
RETURNS DATETIME
AS
BEGIN
	
	
	RETURN(SELECT TOP 1 VJ.FECHA_SALIDA
		   FROM ACTITUD_GDD.VIAJE VJ
		   WHERE VJ.PATENTE = @PATENTE
		   ORDER BY VJ.FECHA_SALIDA asc)

END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[DAR_DE_BAJA_TEMPORAL]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [ACTITUD_GDD].[DAR_DE_BAJA_TEMPORAL]
	-- Add the parameters for the stored procedure here
	@PATENTE NVARCHAR(255),
	@FECHA_FUERA_SERVICIO DATETIME,
	@FECHA_REINICIO_SERVICIO DATETIME
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DECLARE @FLAG INT
	
	SET @FLAG = 1
	
	
	SELECT @FLAG = 0
	FROM ACTITUD_GDD.BAJA_TEMPORAL BT
	WHERE BT.PATENTE = @PATENTE AND (@FECHA_FUERA_SERVICIO <= BT.FECHA_REINICIO_SERVICIO AND @FECHA_REINICIO_SERVICIO >= BT.FECHA_FUERA_SERVICIO) 
	
	
	
	
	IF(@FLAG = 1)
	BEGIN
	INSERT INTO [GD1C2013].[ACTITUD_GDD].[BAJA_TEMPORAL]
           ([PATENTE]
           ,[FECHA_FUERA_SERVICIO]
           ,[FECHA_REINICIO_SERVICIO])
     VALUES
           (@PATENTE
           ,@FECHA_FUERA_SERVICIO
           ,@FECHA_REINICIO_SERVICIO)
     
	 SET @FLAG = @@IDENTITY
     END
     
     
     
     SELECT @FLAG FLAG


   
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[InsertarViaje]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[InsertarViaje] 
	-- Add the parameters for the stored procedure here
	@RECORRIDO_CODIGO NUMERIC(18,0),
	@PATENTE NVARCHAR(255),
	@FECHA_SALIDA DATETIME,
	@FECHA_LLEGADA_ESTIMADA DATETIME
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   INSERT INTO [GD1C2013].[ACTITUD_GDD].[VIAJE]
           ([PATENTE]
           ,[FECHA_SALIDA]
           ,[FECHA_LLEGADA_ESTIMADA]
           ,[RECORRIDO_CODIGO]
           )
     VALUES
           (@PATENTE
           ,@FECHA_SALIDA
           ,@FECHA_LLEGADA_ESTIMADA
           ,@RECORRIDO_CODIGO
           )


   
   
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[INSERTAR_VIAJE]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[INSERTAR_VIAJE]
	-- Add the parameters for the stored procedure here
	@IDVIAJE INT OUTPUT,
	@PATENTE NVARCHAR(255),
	@FECHASALIDA DATETIME,
	@FECHALLEGADA DATETIME,
	@FECHALLEGADAESTIMADA DATETIME,
	@RECORRIDO NUMERIC(18,0)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	SET @IDVIAJE = (SELECT TOP 1 ID
				    FROM ACTITUD_GDD.VIAJE
					WHERE @PATENTE = PATENTE AND @FECHASALIDA = FECHA_SALIDA AND @FECHALLEGADA = FECHA_LLEGADA AND @FECHALLEGADAESTIMADA = FECHA_LLEGADA_ESTIMADA AND @RECORRIDO = RECORRIDO_CODIGO)
	
	IF(ISNULL(@IDVIAJE,0) = 0)
	BEGIN
		INSERT INTO ACTITUD_GDD.VIAJE (PATENTE, FECHA_SALIDA, FECHA_LLEGADA, FECHA_LLEGADA_ESTIMADA, RECORRIDO_CODIGO)
		VALUES (@PATENTE, @FECHASALIDA, @FECHALLEGADA, @FECHALLEGADAESTIMADA, @RECORRIDO)
		SET @IDVIAJE = @@IDENTITY
	END
    
    
    
    
END
GO
/****** Object:  UserDefinedFunction [ACTITUD_GDD].[MICRO_DEL_VIAJE]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [ACTITUD_GDD].[MICRO_DEL_VIAJE] 
(
	-- Add the parameters for the function here
	@ID_VIAJE INT
)
RETURNS NVARCHAR(255)
AS
BEGIN
	RETURN(SELECT VJ.PATENTE
		   FROM ACTITUD_GDD.VIAJE VJ
		   WHERE VJ.ID = @ID_VIAJE
	)
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[PatentesPosibles]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[PatentesPosibles]
	-- Add the parameters for the stored procedure here
	@RECORRIDO_CODIGO INT,
	@FECHA_SALIDA DATETIME,
	@FECHA_LLEGADA_ESTIMADA DATETIME
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	
	SELECT DISTINCT MIC.PATENTE PATENTE
	
	FROM ACTITUD_GDD.MICRO MIC JOIN ACTITUD_GDD.RECORRIDO REC ON (MIC.TIPO_SERVICIO =REC.ID_SERVICIO)
	
	WHERE (ISNULL(MIC.FECHA_BAJA_DEFINITIVA,0) = 0) AND (MIC.FECHA_ALTA <= @FECHA_SALIDA) AND REC.RECORRIDO_CODIGO = @RECORRIDO_CODIGO AND (ACTITUD_GDD.ESTA_DISPONIBLE(MIC.PATENTE, @FECHA_SALIDA, @FECHA_LLEGADA_ESTIMADA, REC.ID_CIUDAD_ORIGEN, REC.ID_CIUDAD_DESTINO) = 1) AND (ACTITUD_GDD.ESTA_DADO_DE_BAJA_TEMPORAL(MIC.PATENTE,@FECHA_SALIDA, @FECHA_LLEGADA_ESTIMADA) = 0)
	
	
	
	
END
GO
/****** Object:  UserDefinedFunction [ACTITUD_GDD].[CALCULAR_PUNTOS_PERSONA_TOP5]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [ACTITUD_GDD].[CALCULAR_PUNTOS_PERSONA_TOP5]
(
	@DNI NUMERIC(18,0),
	@FECHA DATETIME
)
RETURNS INT
AS
BEGIN

RETURN(

	   (ISNULL((SELECT (SUM(PS.PRECIO/5) - SUM(PS.PUNTOS_CANJEADOS))
	   FROM ACTITUD_GDD.PASAJE PS JOIN ACTITUD_GDD.VIAJE VJ ON (PS.ID_VIAJE = VJ.ID)
	   WHERE PS.DNI = @DNI AND (ISNULL(VJ.FECHA_LLEGADA,0) <> 0) AND (DATEDIFF(DAY,VJ.FECHA_LLEGADA, @FECHA) BETWEEN 0 AND 182) AND (ISNULL(PS.ID_CANCELACION,0) = 0)),0))
	   +
	   (ISNULL((SELECT (SUM(PQ.PRECIO/5) - SUM(PQ.PUNTOS_CANJEADOS))
	   FROM ACTITUD_GDD.PAQUETE PQ JOIN ACTITUD_GDD.VIAJE VJ ON (PQ.ID_VIAJE = VJ.ID)
	   WHERE PQ.DNI = @DNI AND (ISNULL(VJ.FECHA_LLEGADA,0) <> 0) AND (DATEDIFF(DAY,VJ.FECHA_LLEGADA, @FECHA) BETWEEN 0 AND 182) AND (ISNULL(PQ.ID_CANCELACION,0) = 0)),0))
	   
	   )

END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[TOP5CLIENTES]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[TOP5CLIENTES]
	-- Add the parameters for the stored procedure here
	@FECHA datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT top 5 DNI, NOMBRE, APELLIDO, ACTITUD_GDD.CALCULAR_PUNTOS_PERSONA_TOP5(DNI,@FECHA) [PUNTOS DISPONIBLES]
	FROM ACTITUD_GDD.CLIENTE
--	WHERE ACTITUD_GDD.CALCULAR_PUNTOS_PERSONA_TOP5(DNI,@FECHA) != 0
	WHERE DNI IN (	select DISTINCT CL.DNI
					from ACTITUD_GDD.CLIENTE CL JOIN ACTITUD_GDD.PASAJE PS ON (PS.DNI = CL.DNI) JOIN ACTITUD_GDD.VIAJE VJ ON (PS.ID_VIAJE = VJ.ID)
					where ISNULL(PS.ID_CANCELACION,0) = 0 AND (ISNULL(VJ.FECHA_LLEGADA,0) <> 0) AND (DATEDIFF(DAY,VJ.FECHA_LLEGADA, @FECHA) BETWEEN 0 AND 182) and (((PS.PRECIO/5) - PS.PUNTOS_CANJEADOS) > 1)
					) 
		OR DNI IN (	select DISTINCT CL.DNI
					from ACTITUD_GDD.CLIENTE CL JOIN ACTITUD_GDD.PAQUETE PQ ON (PQ.DNI = CL.DNI) JOIN ACTITUD_GDD.VIAJE VJ ON (PQ.ID_VIAJE = VJ.ID)
					where ISNULL(PQ.ID_CANCELACION,0) = 0 AND (ISNULL(VJ.FECHA_LLEGADA,0) <> 0) AND (DATEDIFF(DAY,VJ.FECHA_LLEGADA, @FECHA) BETWEEN 0 AND 182) and (((PQ.PRECIO/5) - PQ.PUNTOS_CANJEADOS) > 1)
					)

	ORDER BY [PUNTOS DISPONIBLES] DESC
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[MIGRAR_VIAJE_COMPRA_PASAJE_PAQUETE]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[MIGRAR_VIAJE_COMPRA_PASAJE_PAQUETE] 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	
	 DECLARE @IDVIAJE INT, @IDCOMPRA INT,
	 @DNI NUMERIC(18,0), 
	 @PATENTE NVARCHAR(255), 
	 @FECHASALIDA DATETIME, 
	 @FECHALLEGADA DATETIME, 
	 @FECHALLEGADAESTIMADA DATETIME,
	 @RECORRIDO NUMERIC(18,0), 
	 @PAQUETEFECHA DATETIME, 
	 @PASAJEFECHA DATETIME, 
	 @BUTACANRO NUMERIC(18,0), 
	 @PAQUETEKG NUMERIC(18,0), 
	 @PAQUETE NUMERIC(18,0), 
	 @PASAJE NUMERIC(18,0),	 
	 @PASAJE_PRECIO NUMERIC(18,2),
	 @PAQUETE_PRECIO NUMERIC(18,2),
	 
	 --CORTE CONTROL
	 @ULTIMODNI NUMERIC(18,0), 
	 @ULTIMAFECHA DATETIME
	 
	 SET @ULTIMAFECHA = 0
	 SET @ULTIMODNI = 0
	
	
	
	
	DECLARE CURSOR_MIGRACION CURSOR FOR (SELECT Cli_Dni, Micro_Patente, FechaSalida, FechaLLegada, Fecha_LLegada_Estimada, Recorrido_Codigo, Paquete_FechaCompra, Pasaje_FechaCompra, Butaca_Nro, Paquete_KG, Paquete_Codigo, Pasaje_Codigo, Pasaje_Precio, Paquete_Precio
		 FROM gd_esquema.Maestra) ORDER BY ACTITUD_GDD.CALCULAR_FECHA_DE_COMPRA(Paquete_FechaCompra, Pasaje_FechaCompra) asc, Cli_Dni ASC
	
	
	OPEN CURSOR_MIGRACION
	FETCH CURSOR_MIGRACION INTO @DNI, @PATENTE, @FECHASALIDA, @FECHALLEGADA, @FECHALLEGADAESTIMADA, @RECORRIDO, @PAQUETEFECHA, @PASAJEFECHA, @BUTACANRO, @PAQUETEKG, @PAQUETE, @PASAJE, @PASAJE_PRECIO, @PAQUETE_PRECIO
		WHILE (@@FETCH_STATUS = 0)
			BEGIN
			
			EXEC ACTITUD_GDD.INSERTAR_VIAJE @IDVIAJE OUTPUT,@PATENTE,@FECHASALIDA,@FECHALLEGADA,@FECHALLEGADAESTIMADA,@RECORRIDO
			
			IF (@PAQUETE > @PASAJE)
			BEGIN
				EXEC ACTITUD_GDD.INSERTAR_COMPRA @IDCOMPRA OUTPUT, @ULTIMAFECHA OUTPUT, @ULTIMODNI OUTPUT, @DNI,@PAQUETEFECHA
				
				SET IDENTITY_INSERT [GD1C2013].[ACTITUD_GDD].[PAQUETE] ON;
				INSERT INTO ACTITUD_GDD.PAQUETE (ID, DNI, PESO, ID_VIAJE, ID_COMPRA, PRECIO) VALUES (@PAQUETE, @DNI, @PAQUETEKG, @IDVIAJE, @IDCOMPRA, @PAQUETE_PRECIO)
				SET IDENTITY_INSERT [GD1C2013].[ACTITUD_GDD].[PAQUETE] OFF;
			END
			ELSE
			BEGIN
				EXEC ACTITUD_GDD.INSERTAR_COMPRA @IDCOMPRA OUTPUT, @ULTIMAFECHA OUTPUT, @ULTIMODNI OUTPUT, @DNI,@PASAJEFECHA
				SET IDENTITY_INSERT [GD1C2013].[ACTITUD_GDD].[PASAJE] ON;
				INSERT INTO ACTITUD_GDD.PASAJE(ID, DNI, BUTACA_NUMERO,ID_VIAJE,ID_COMPRA, PRECIO) VALUES (@PASAJE, @DNI, @BUTACANRO, @IDVIAJE, @IDCOMPRA, @PASAJE_PRECIO)
				SET IDENTITY_INSERT [GD1C2013].[ACTITUD_GDD].[PASAJE] OFF;
			END
			
			
			
			
			
			FETCH CURSOR_MIGRACION INTO @DNI, @PATENTE, @FECHASALIDA, @FECHALLEGADA, @FECHALLEGADAESTIMADA, @RECORRIDO, @PAQUETEFECHA, @PASAJEFECHA, @BUTACANRO, @PAQUETEKG, @PAQUETE, @PASAJE, @PASAJE_PRECIO, @PAQUETE_PRECIO
			END
	CLOSE CURSOR_MIGRACION
	DEALLOCATE CURSOR_MIGRACION
	

 
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[ListarItemsCompra]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[ListarItemsCompra] 
	-- Add the parameters for the stored procedure here
	@DNI NUMERIC(18),
	@ID_COMPRA INT,
	@FECHA DATETIME
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT  PS.ID ID, PS.BUTACA_NUMERO KG_BUTACA, PS.PRECIO PRECIO, 'Pasaje' TIPO
	FROM ACTITUD_GDD.PASAJE PS JOIN ACTITUD_GDD.COMPRA CMP ON (PS.ID_COMPRA = CMP.ID)
	WHERE PS.ID_COMPRA = @ID_COMPRA AND CMP.DNI = @DNI AND (ISNULL(PS.ID_CANCELACION,0) = 0) AND (ACTITUD_GDD.NoSalio(PS.ID_VIAJE, @FECHA) = 0) 
	UNION
	SELECT  PQ.ID ID, PQ.PESO KG_BUTACA, PQ.PRECIO PRECIO, 'Paquete' TIPO
	FROM ACTITUD_GDD.PAQUETE PQ JOIN ACTITUD_GDD.COMPRA CMP ON (PQ.ID_COMPRA = CMP.ID)
	WHERE PQ.ID_COMPRA = @ID_COMPRA AND CMP.DNI = @DNI AND (ISNULL(PQ.ID_CANCELACION,0) = 0) AND (ACTITUD_GDD.NoSalio(PQ.ID_VIAJE, @FECHA) = 0) 
	
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[ELIMINAR_RECORRIDO]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [ACTITUD_GDD].[ELIMINAR_RECORRIDO]
	@RECORRIDO_CODIGO int,
	@FECHA_AHORA datetime
AS
BEGIN

	DECLARE @IDCANCELACION INT
 
	INSERT INTO [GD1C2013].[ACTITUD_GDD].[CANCELACION]
           ([FECHA_CANCELACION]
           ,[MOTIVO_CANCELACION])
    VALUES
           (@FECHA_AHORA
           ,'Cancelado debido a la baja definitiva del recorrido asignado al viaje.')
           
	SET @IDCANCELACION = @@IDENTITY


	update [GD1C2013].[ACTITUD_GDD].[PASAJE]
	SET [ID_CANCELACION] = @IDCANCELACION
	where ID IN (
			select PJ.ID 
			from ACTITUD_GDD.VIAJE VJ JOIN ACTITUD_GDD.PASAJE PJ ON (PJ.ID_VIAJE = VJ.ID)
			where VJ.RECORRIDO_CODIGO = @RECORRIDO_CODIGO AND VJ.FECHA_SALIDA > @FECHA_AHORA 
				AND VJ.BAJA_LOGICA = 0 
				AND ISNULL(VJ.FECHA_LLEGADA,0) = 0
				AND ISNULL(PJ.ID_CANCELACION,0) = 0)
				
	update [GD1C2013].[ACTITUD_GDD].[PAQUETE]
	SET [ID_CANCELACION] = @IDCANCELACION
	where ID IN (
			select PQ.ID 
			from ACTITUD_GDD.VIAJE VJ JOIN ACTITUD_GDD.PAQUETE PQ ON (PQ.ID_VIAJE = VJ.ID)
			where VJ.RECORRIDO_CODIGO = @RECORRIDO_CODIGO AND VJ.FECHA_SALIDA > @FECHA_AHORA 
				AND VJ.BAJA_LOGICA = 0 
				AND ISNULL(VJ.FECHA_LLEGADA,0) = 0
				AND ISNULL(PQ.ID_CANCELACION,0) = 0)
				
				
	DELETE FROM [GD1C2013].[ACTITUD_GDD].[VIAJE]
	WHERE RECORRIDO_CODIGO = @RECORRIDO_CODIGO
	
	DELETE FROM ACTITUD_GDD.RECORRIDO
	WHERE @RECORRIDO_CODIGO = RECORRIDO_CODIGO
	
	DECLARE @SE_CANCELO_ALGUN_PASAJE INT
	
	SET @SE_CANCELO_ALGUN_PASAJE = 0
	
	SELECT @SE_CANCELO_ALGUN_PASAJE = 1
	FROM ACTITUD_GDD.PASAJE PS
	WHERE PS.ID_CANCELACION = @IDCANCELACION
	
	SELECT @SE_CANCELO_ALGUN_PASAJE = 1
	FROM ACTITUD_GDD.PAQUETE PQ
	WHERE PQ.ID_CANCELACION = @IDCANCELACION
	
	IF(@SE_CANCELO_ALGUN_PASAJE = 0)
	BEGIN
		DELETE FROM [GD1C2013].[ACTITUD_GDD].[CANCELACION]
		WHERE ID = @IDCANCELACION
	END
 
	
	
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[CancelarItem]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[CancelarItem]
	-- Add the parameters for the stored procedure here
	@ID INT,
	@TIPO NVARCHAR(20),
	@ID_CANCELACION INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    
    IF(@TIPO = 'Pasaje')
		BEGIN
			UPDATE [GD1C2013].[ACTITUD_GDD].[PASAJE]
			SET [ID_CANCELACION] = @ID_CANCELACION
			WHERE @ID = ID
		END
    ELSE
		BEGIN
			UPDATE [GD1C2013].[ACTITUD_GDD].[PAQUETE] 
			SET [ID_CANCELACION] = @ID_CANCELACION
			WHERE @ID = ID
		END
    
    
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[CANCELARCOMPRA]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[CANCELARCOMPRA]
	@ID_COMPRA INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DELETE FROM [GD1C2013].[ACTITUD_GDD].[PAQUETE]
      WHERE ID_COMPRA = @ID_COMPRA
      
    DELETE FROM [GD1C2013].[ACTITUD_GDD].[PASAJE]
      WHERE ID_COMPRA = @ID_COMPRA
      
    DELETE FROM [GD1C2013].[ACTITUD_GDD].[COMPRA]
      WHERE ID = @ID_COMPRA
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[CANCELAR_TODO_POR_BAJA_TEMPORAL]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[CANCELAR_TODO_POR_BAJA_TEMPORAL]
	-- Add the parameters for the stored procedure here
	@ID_BAJA_TEMPORAL INT,
	@FECHA_ACTUAL DATETIME
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DECLARE @FECHA_FUERA_SERVICIO DATETIME
	DECLARE @FECHA_REINICIO_SERVICIO DATETIME
	DECLARE @PATENTE NVARCHAR(255)
	
	SELECT @FECHA_FUERA_SERVICIO = BT.FECHA_FUERA_SERVICIO, @FECHA_REINICIO_SERVICIO = BT.FECHA_REINICIO_SERVICIO, @PATENTE = BT.PATENTE
	FROM ACTITUD_GDD.BAJA_TEMPORAL BT
	WHERE BT.ID = @ID_BAJA_TEMPORAL
	
	
	
	-- Chequear que el trigger de delete de viaje solo setee a BAJA_LOGICA
	
	DELETE FROM [GD1C2013].[ACTITUD_GDD].[VIAJE]
      WHERE PATENTE = @PATENTE AND (FECHA_SALIDA >= @FECHA_FUERA_SERVICIO AND FECHA_SALIDA <= @FECHA_REINICIO_SERVICIO)
      
    
	INSERT INTO [GD1C2013].[ACTITUD_GDD].[CANCELACION]
           ([FECHA_CANCELACION]
           ,[MOTIVO_CANCELACION])
    VALUES
           (@FECHA_ACTUAL
           ,'Cancelado debido a la baja temporal del micro asignado al viaje')
           
    DECLARE @ID_CANCELACION INT
    SET @ID_CANCELACION = @@IDENTITY 
	     
     
	UPDATE [GD1C2013].[ACTITUD_GDD].[PAQUETE]
	SET [ID_CANCELACION] = @ID_CANCELACION
	WHERE ACTITUD_GDD.MICRO_DEL_VIAJE(ID_VIAJE) = @PATENTE AND ACTITUD_GDD.VIAJE_CON_BAJA_LOGICA(ID_VIAJE) = 1
	
	UPDATE [GD1C2013].[ACTITUD_GDD].[PASAJE]
	SET [ID_CANCELACION] = @ID_CANCELACION
	WHERE ACTITUD_GDD.MICRO_DEL_VIAJE(ID_VIAJE) = @PATENTE AND ACTITUD_GDD.VIAJE_CON_BAJA_LOGICA(ID_VIAJE) = 1
	
	DECLARE @SE_CANCELO_ALGUN_PASAJE INT
	
	SET @SE_CANCELO_ALGUN_PASAJE = 0
	
	SELECT @SE_CANCELO_ALGUN_PASAJE = 1
	FROM ACTITUD_GDD.PASAJE PS
	WHERE PS.ID_CANCELACION = @ID_CANCELACION
	
	SELECT @SE_CANCELO_ALGUN_PASAJE = 1
	FROM ACTITUD_GDD.PAQUETE PQ
	WHERE PQ.ID_CANCELACION = @ID_CANCELACION
	
	IF(@SE_CANCELO_ALGUN_PASAJE = 0)
	BEGIN
		DELETE FROM [GD1C2013].[ACTITUD_GDD].[CANCELACION]
		WHERE ID = @ID_CANCELACION
	END
	

 
  
  
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[CANCELAR_TODO_POR_BAJA_LOGICA]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[CANCELAR_TODO_POR_BAJA_LOGICA]
	-- Add the parameters for the stored procedure here
	@PATENTE NVARCHAR(255),
	@FECHA_ACTUAL DATETIME
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DECLARE @FECHA_DE_BAJA DATETIME
	
	SELECT @FECHA_DE_BAJA = MC.FECHA_BAJA_DEFINITIVA
	FROM ACTITUD_GDD.MICRO MC
	WHERE MC.PATENTE = @PATENTE
	
	
	
	-- Chequear que el trigger de delete de viaje solo setee a BAJA_LOGICA
	
	DELETE FROM [GD1C2013].[ACTITUD_GDD].[VIAJE]
      WHERE PATENTE = @PATENTE AND FECHA_SALIDA >= @FECHA_DE_BAJA
      
    
	INSERT INTO [GD1C2013].[ACTITUD_GDD].[CANCELACION]
           ([FECHA_CANCELACION]
           ,[MOTIVO_CANCELACION])
    VALUES
           (@FECHA_ACTUAL
           ,'Cancelado debido a la baja definitiva del micro asignado al viaje')
           
    DECLARE @ID_CANCELACION INT
    SET @ID_CANCELACION = @@IDENTITY 
	     
     
	UPDATE [GD1C2013].[ACTITUD_GDD].[PAQUETE]
	SET [ID_CANCELACION] = @ID_CANCELACION
	WHERE ACTITUD_GDD.MICRO_DEL_VIAJE(ID_VIAJE) = @PATENTE AND ACTITUD_GDD.VIAJE_CON_BAJA_LOGICA(ID_VIAJE) = 1
	
	UPDATE [GD1C2013].[ACTITUD_GDD].[PASAJE]
	SET [ID_CANCELACION] = @ID_CANCELACION
	WHERE ACTITUD_GDD.MICRO_DEL_VIAJE(ID_VIAJE) = @PATENTE AND ACTITUD_GDD.VIAJE_CON_BAJA_LOGICA(ID_VIAJE) = 1
	
	DECLARE @SE_CANCELO_ALGUN_PASAJE INT
	
	SET @SE_CANCELO_ALGUN_PASAJE = 0
	
	SELECT @SE_CANCELO_ALGUN_PASAJE = 1
	FROM ACTITUD_GDD.PASAJE PS
	WHERE PS.ID_CANCELACION = @ID_CANCELACION
	
	SELECT @SE_CANCELO_ALGUN_PASAJE = 1
	FROM ACTITUD_GDD.PAQUETE PQ
	WHERE PQ.ID_CANCELACION = @ID_CANCELACION
	
	IF(@SE_CANCELO_ALGUN_PASAJE = 0)
	BEGIN
		DELETE FROM [GD1C2013].[ACTITUD_GDD].[CANCELACION]
		WHERE ID = @ID_CANCELACION
	END
 
  
  
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[CALCULARFORMACIONPUNTOS]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[CALCULARFORMACIONPUNTOS]
	-- Add the parameters for the stored procedure here
		@DNI INT,
	    @FECHA DATETIME
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   
   
   
   ((SELECT 'PUNTOS_PQ' TIPO, CONVERT(INT,(PQ.PRECIO / 5)) [PUNTOS], V.FECHA_LLEGADA FECHA
	FROM ACTITUD_GDD.PAQUETE PQ INNER JOIN ACTITUD_GDD.VIAJE V ON (PQ.ID_VIAJE = V.ID)
	WHERE PQ.DNI = @DNI AND (ISNULL(V.FECHA_LLEGADA,0) <> 0) AND (DATEDIFF(DAY,V.FECHA_LLEGADA, @FECHA) < 365) /*AND (PQ.PRECIO / 5) > PUNTOS_CANJEADOS*/ AND (ISNULL(PQ.ID_CANCELACION,0) = 0) )
	UNION
	(SELECT 'PUNTOS_PS' TIPO, CONVERT(INT,(PS.PRECIO / 5)) [PUNTOS], V.FECHA_LLEGADA FECHA
	FROM ACTITUD_GDD.PASAJE PS INNER JOIN ACTITUD_GDD.VIAJE V ON (PS.ID_VIAJE = V.ID)
	WHERE PS.DNI = @DNI AND (ISNULL(V.FECHA_LLEGADA,0) <> 0) AND (DATEDIFF(DAY,V.FECHA_LLEGADA, @FECHA) < 365) /*AND (PS.PRECIO / 5) > PUNTOS_CANJEADOS*/ AND (ISNULL(PS.ID_CANCELACION,0) = 0) )
	UNION
	(SELECT 'CANJE' TIPO, 0 - P.CANTIDAD_PTOS * C.CANTIDAD_PRODUCTO [PUNTOS], C.FECHA FECHA
	FROM ACTITUD_GDD.CANJE C INNER JOIN ACTITUD_GDD.PRODUCTO P ON (C.ID_PRODUCTO = P.ID)
	WHERE C.DNI = @DNI AND (DATEDIFF(DAY,C.FECHA,@FECHA) < 365))
	)
	ORDER BY FECHA DESC
   
   
   
   
   
END
GO
/****** Object:  UserDefinedFunction [ACTITUD_GDD].[CALCULAR_PUNTOS_PERSONA_PRECIO_ACTUALIZADO]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [ACTITUD_GDD].[CALCULAR_PUNTOS_PERSONA_PRECIO_ACTUALIZADO]
(
	@DNI NUMERIC(18,0)
)
RETURNS INT
AS
BEGIN

--FUNCION PARA PRUEBAS

RETURN(

	   (SELECT (SUM(ACTITUD_GDD.PRECIO_DE_PASAJE(VJ.RECORRIDO_CODIGO)/5) - SUM(PS.PUNTOS_CANJEADOS))
	   FROM ACTITUD_GDD.PASAJE PS JOIN ACTITUD_GDD.VIAJE VJ ON (PS.ID_VIAJE = VJ.ID)
	   WHERE PS.DNI = @DNI AND (ISNULL(VJ.FECHA_LLEGADA,0) <> 0) AND (DATEDIFF(DAY,VJ.FECHA_LLEGADA, GETDATE()) < 365))
	   +
	   (SELECT (SUM(ACTITUD_GDD.PRECIO_DE_PAQUETE(VJ.RECORRIDO_CODIGO,PQ.PESO)/5) - SUM(PQ.PUNTOS_CANJEADOS))
	   FROM ACTITUD_GDD.PAQUETE PQ JOIN ACTITUD_GDD.VIAJE VJ ON (PQ.ID_VIAJE = VJ.ID)
	   WHERE PQ.DNI = @DNI AND (ISNULL(VJ.FECHA_LLEGADA,0) <> 0) AND (DATEDIFF(DAY,VJ.FECHA_LLEGADA, GETDATE()) < 365))
	   
	   )
	   


END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[MIGRAR_MICRO_FECHA_ALTA]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[MIGRAR_MICRO_FECHA_ALTA]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	UPDATE [GD1C2013].[ACTITUD_GDD].[MICRO]
	SET 
      [FECHA_ALTA] = ACTITUD_GDD.FECHA_PRIMER_VIAJE(PATENTE)
     
    
    ALTER TABLE [GD1C2013].[ACTITUD_GDD].[MICRO]
	ALTER COLUMN FECHA_ALTA DATETIME NOT NULL
 
    
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[LISTARBUTACASLIBRES]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
CREATE PROCEDURE [ACTITUD_GDD].[LISTARBUTACASLIBRES] 
	@ID_VIAJE INT,
	@PATENTE NVARCHAR(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT NUMERO, PISO, tipo
	FROM ACTITUD_GDD.BUTACA BU
	WHERE BU.PATENTE = @PATENTE	
	AND BU.NUMERO NOT IN (	SELECT PJ.BUTACA_NUMERO
							FROM ACTITUD_GDD.PASAJE	PJ
							WHERE ID_VIAJE = @ID_VIAJE 
							AND ISNULL(ID_CANCELACION,0) = 0)
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[CREARPASAJE]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[CREARPASAJE]
	@DNI NUMERIC(18,0),
	@BUTACA_NRO NUMERIC(18,0),
    @ID_VIAJE INT,
	@ID_COMPRA INT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

INSERT INTO [GD1C2013].[ACTITUD_GDD].[PASAJE]
           ([DNI]
           ,[BUTACA_NUMERO]
           ,[PUNTOS_CANJEADOS]
           ,[ID_VIAJE]
           ,[ID_COMPRA]
           ,[PRECIO])
     VALUES
           (@DNI
           ,@BUTACA_NRO
           ,0
           ,@ID_VIAJE
           ,@ID_COMPRA
           ,0)
     
     DECLARE @A  BIT
     set @A = 0
     IF ISNULL(@@IDENTITY, 0) > 0
     begin
		set @A = 1
     end
     
     SELECT @A INSERTO
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[ACTUALIZARBUTACACOMPLETA]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[ACTUALIZARBUTACACOMPLETA]
	@PATENTE_MICRO nvarchar(255),
	@NUMERO numeric(18,0),
	@PISO numeric(18,0),
	@TIPO nvarchar(255),
	@NUMERO_VIEJO numeric(18,0),
	@FECHA DATETIME
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE [GD1C2013].[ACTITUD_GDD].[BUTACA]
		SET  [TIPO] = @TIPO,[PISO] = @PISO, [NUMERO] = @NUMERO
		WHERE NUMERO = @NUMERO_VIEJO and PATENTE = @PATENTE_MICRO
		
		
		UPDATE [GD1C2013].[ACTITUD_GDD].[PASAJE]
			SET BUTACA_NUMERO = @NUMERO
			WHERE @PATENTE_MICRO = ACTITUD_GDD.MICRO_DEL_VIAJE(ID_VIAJE) AND  BUTACA_NUMERO = @NUMERO_VIEJO  AND (ISNULL(ID_CANCELACION, 0) = 0) AND ACTITUD_GDD.NoSalio(ID_VIAJE, @FECHA) = 0

END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[CAMBIAR_NUMERO_BUTACAS_PASAJES]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[CAMBIAR_NUMERO_BUTACAS_PASAJES] 
	-- Add the parameters for the stored procedure here
	@ID_VIAJE INT,
	@MICRO_ELEGIDO NVARCHAR(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DECLARE @ID_PASAJE INT
	DECLARE @BUTACA_ANTERIOR NUMERIC(18,0)
	SET @BUTACA_ANTERIOR = -1
	
	DECLARE CURSOR_PASAJES CURSOR LOCAL
	FOR SELECT PSJ.ID
	FROM ACTITUD_GDD.PASAJE PSJ
	WHERE PSJ.ID_VIAJE = @ID_VIAJE AND ISNULL(ID_CANCELACION,0) = 0
	OPEN CURSOR_PASAJES	
	FETCH CURSOR_PASAJES INTO @ID_PASAJE
	WHILE @@FETCH_STATUS = 0 
	BEGIN
   
		UPDATE [GD1C2013].[ACTITUD_GDD].[PASAJE]
		SET [BUTACA_NUMERO] = ACTITUD_GDD.BUTACA_PROXIMA(@BUTACA_ANTERIOR, @MICRO_ELEGIDO)
		WHERE ID = @ID_PASAJE
		
		SELECT @BUTACA_ANTERIOR = P.BUTACA_NUMERO
		FROM ACTITUD_GDD.PASAJE P
		WHERE P.ID = @ID_PASAJE
	
	
	FETCH CURSOR_PASAJES INTO @ID_PASAJE
    END
    
    CLOSE CURSOR_PASAJES
   
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[CalcularSetearMontoPasajes]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[CalcularSetearMontoPasajes]
	-- Add the parameters for the stored procedure here
	@ID INT,
	@FECHA_ACTUAL DATE
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   
   
	
	
	UPDATE [GD1C2013].[ACTITUD_GDD].[PASAJE]
	SET 	 
		 [PRECIO] = CASE 
					WHEN ISNULL(ACTITUD_GDD.ES_PENSIONADO(DNI,@FECHA_ACTUAL),0) = 0
					THEN (ACTITUD_GDD.PRECIO_DE_PASAJE(
						 (SELECT TOP 1 VJ.RECORRIDO_CODIGO
						  FROM ACTITUD_GDD.VIAJE VJ
						  WHERE VJ.ID = ID_VIAJE)))
					ELSE ((ACTITUD_GDD.PRECIO_DE_PASAJE(
						 (SELECT TOP 1 VJ.RECORRIDO_CODIGO
						  FROM ACTITUD_GDD.VIAJE VJ
						  WHERE VJ.ID = ID_VIAJE))) * 0.5)
					END
		
	WHERE ID_COMPRA = @ID
   
   
   SELECT ISNULL(SUM(PS.PRECIO),0) MONTO
   FROM ACTITUD_GDD.PASAJE PS
   WHERE PS.ID_COMPRA = @ID
   
END
GO
/****** Object:  UserDefinedFunction [ACTITUD_GDD].[BUTACAS_LIBRES_VIAJE]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [ACTITUD_GDD].[BUTACAS_LIBRES_VIAJE]
(
	@ID_VIAJE INT,
	@PATENTE NVARCHAR(255) 
)
RETURNS INT
AS
BEGIN

	RETURN(SELECT ACTITUD_GDD.CANTIDAD_BUTACAS(@PATENTE)-
			(ISNULL((SELECT SUM(1)
		   FROM ACTITUD_GDD.PASAJE	
		   WHERE ID_VIAJE = @ID_VIAJE AND ISNULL(ID_CANCELACION,0) = 0),0)))

END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[ListarViajesPosibles]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[ListarViajesPosibles]
	-- Add the parameters for the stored procedure here
	@FECHA DATETIME,
	@ORIGEN NVARCHAR(255),
	@DESTINO NVARCHAR(255),
	@FECHA_CONSULTA DATETIME
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	
	select VJ.ID ID, ACTITUD_GDD.KG_LIBRES_VIAJE(VJ.ID, VJ.PATENTE) KG_DISPONIBLES, VJ.PATENTE PATENTE, ACTITUD_GDD.NOMBRE_TIPO_SERVICIO(RE.ID_SERVICIO) TIPO_SERVICIO, VJ.FECHA_SALIDA FECHA_SALIDA, VJ.FECHA_LLEGADA_ESTIMADA FECHA_LLEGADA_ESTIMADA
	from ACTITUD_GDD.VIAJE VJ JOIN ACTITUD_GDD.RECORRIDO RE ON (VJ.RECORRIDO_CODIGO = RE.RECORRIDO_CODIGO)
	WHERE  (FECHA_SALIDA > @FECHA_CONSULTA) AND (VJ.BAJA_LOGICA = 0) AND (ISNULL(VJ.FECHA_LLEGADA,0) = 0) AND (DATEDIFF(DAY, @FECHA, VJ.FECHA_SALIDA) = 0) AND (ACTITUD_GDD.ID_CIUDAD(@ORIGEN) = RE.ID_CIUDAD_ORIGEN) AND (ACTITUD_GDD.ID_CIUDAD(@DESTINO) = RE.ID_CIUDAD_DESTINO) AND ((ACTITUD_GDD.BUTACAS_LIBRES_VIAJE(VJ.ID, VJ.PATENTE) > 0) OR (ACTITUD_GDD.KG_LIBRES_VIAJE(VJ.ID, VJ.PATENTE) > 0))
	
	
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[TOP5DESTINOSPASAJES]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[TOP5DESTINOSPASAJES]
	-- Add the parameters for the stored procedure here
	@FECHA datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SELECT TOP 5 ACTITUD_GDD.NOMBRE_CIUDAD(RE.ID_CIUDAD_DESTINO) CIUDAD, COUNT(*) [CANTIDAD DE PASAJES VENDIDOS]
FROM ACTITUD_GDD.PASAJE P JOIN ACTITUD_GDD.VIAJE VJ ON (P.ID_VIAJE = VJ.ID) JOIN ACTITUD_GDD.RECORRIDO RE ON (RE.RECORRIDO_CODIGO = VJ.RECORRIDO_CODIGO)
WHERE (ISNULL(P.ID_CANCELACION,0) = 0) AND (DATEDIFF(DAY,ACTITUD_GDD.FECHA_COMPRA(P.ID_COMPRA), @FECHA) BETWEEN 0 AND 182)
GROUP BY RE.ID_CIUDAD_DESTINO
ORDER BY COUNT(*) DESC
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[TOP5DESTINOSMASVACIOS]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[TOP5DESTINOSMASVACIOS]
	-- Add the parameters for the stored procedure here
	@FECHA datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT TOP 5 ACTITUD_GDD.NOMBRE_CIUDAD(R.ID_CIUDAD_DESTINO) CIUDAD, 
		(	SELECT SUM(ACTITUD_GDD.CANTIDAD_BUTACAS(VI.PATENTE))
			FROM ACTITUD_GDD.VIAJE VI JOIN ACTITUD_GDD.RECORRIDO RE ON (VI.RECORRIDO_CODIGO = RE.RECORRIDO_CODIGO)
			WHERE (R.ID_CIUDAD_DESTINO = RE.ID_CIUDAD_DESTINO) AND (VI.BAJA_LOGICA = 0) AND 
				(ISNULL(VI.FECHA_LLEGADA,0) != 0) AND
				(DATEDIFF(DAY,VI.FECHA_SALIDA,@FECHA) BETWEEN 0 AND 182)) 
				- 
				(COUNT(R.ID_CIUDAD_DESTINO)) AS [CANTIDAD DE BUTACAS VACIAS]
	FROM ACTITUD_GDD.RECORRIDO R JOIN ACTITUD_GDD.VIAJE V ON(R.RECORRIDO_CODIGO = V.RECORRIDO_CODIGO) JOIN ACTITUD_GDD.PASAJE P ON (V.ID = P.ID_VIAJE)
	WHERE V.BAJA_LOGICA = 0 AND ISNULL(P.ID_CANCELACION,0) = 0 AND ISNULL(V.FECHA_LLEGADA,0) != 0 AND DATEDIFF(DAY,V.FECHA_LLEGADA,@FECHA) BETWEEN 0 AND 182
	GROUP BY R.ID_CIUDAD_DESTINO
	ORDER BY [CANTIDAD DE BUTACAS VACIAS] DESC
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[TOP5PASAJESCANCELADOS]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[TOP5PASAJESCANCELADOS]
	-- Add the parameters for the stored procedure here
	@FECHA datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SELECT TOP 5 ACTITUD_GDD.NOMBRE_CIUDAD(RE.ID_CIUDAD_DESTINO) CIUDAD, COUNT(*) [CANTIDAD DE PASAJES CANCELADOS]
FROM ACTITUD_GDD.PASAJE P JOIN ACTITUD_GDD.VIAJE VJ ON (P.ID_VIAJE = VJ.ID) JOIN ACTITUD_GDD.RECORRIDO RE ON (RE.RECORRIDO_CODIGO = VJ.RECORRIDO_CODIGO)
WHERE (ISNULL(P.ID_CANCELACION,0) <> 0) AND (DATEDIFF(DAY,ACTITUD_GDD.FECHA_CANCELACION(P.ID_CANCELACION),@FECHA) BETWEEN 0 AND 182)
GROUP BY RE.ID_CIUDAD_DESTINO
ORDER BY [CANTIDAD DE PASAJES CANCELADOS] DESC

END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[REEMPLAZAR_MICRO_VIAJES_TEMPORAL]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[REEMPLAZAR_MICRO_VIAJES_TEMPORAL] 
	-- Add the parameters for the stored procedure here
	@PATENTE NVARCHAR(255), 
	@MICRO_ELEGIDO NVARCHAR(255), 
	@FECHA_FUERA_SERVICIO DATETIME, 
	@FECHA_REINICIO_SERVICIO DATETIME
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DECLARE @ID_VIAJE INT
	
	DECLARE CURSOR_VIAJES CURSOR LOCAL
	FOR SELECT VJE.ID
	FROM ACTITUD_GDD.VIAJE VJE 
	WHERE VJE.PATENTE = @PATENTE AND VJE.FECHA_SALIDA >= @FECHA_FUERA_SERVICIO AND VJE.FECHA_SALIDA <= @FECHA_REINICIO_SERVICIO AND (ISNULL(VJE.BAJA_LOGICA,0) = 0) AND (ISNULL(VJE.FECHA_LLEGADA,0) = 0)
	OPEN CURSOR_VIAJES 	
	FETCH CURSOR_VIAJES INTO @ID_VIAJE
	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		EXEC ACTITUD_GDD.CAMBIAR_NUMERO_BUTACAS_PASAJES @ID_VIAJE, @MICRO_ELEGIDO
	
		UPDATE [GD1C2013].[ACTITUD_GDD].[VIAJE]
		SET [PATENTE] = @MICRO_ELEGIDO
		WHERE ID = @ID_VIAJE

	
	FETCH CURSOR_VIAJES INTO @ID_VIAJE
	END
	CLOSE CURSOR_VIAJES

	
    
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[REEMPLAZAR_TODO_POR_BAJA_TEMPORAL]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[REEMPLAZAR_TODO_POR_BAJA_TEMPORAL] 
	-- Add the parameters for the stored procedure here
	@ID_BAJA_TEMPORAL INT,
	@FECHA_ACTUAL DATETIME
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @FECHA_FUERA_SERVICIO DATETIME
	DECLARE @FECHA_REINICIO_SERVICIO DATETIME
	DECLARE @PATENTE NVARCHAR(255)
	
	SELECT @FECHA_FUERA_SERVICIO = BT.FECHA_FUERA_SERVICIO, @FECHA_REINICIO_SERVICIO = BT.FECHA_REINICIO_SERVICIO, @PATENTE = BT.PATENTE
	FROM ACTITUD_GDD.BAJA_TEMPORAL BT
	WHERE BT.ID = @ID_BAJA_TEMPORAL
	
	
	DECLARE @MICRO_CURSOR NVARCHAR(255)
	DECLARE @SE_ENCONTRO_MICRO BIT
	SET @SE_ENCONTRO_MICRO = 0
	DECLARE @MICRO_ELEGIDO NVARCHAR(255)
	
	DECLARE CURSOR_MICROS CURSOR LOCAL
    FOR SELECT MIC.PATENTE
	FROM ACTITUD_GDD.MICRO MIC
	WHERE (ISNULL(MIC.FECHA_BAJA_DEFINITIVA,0) = 0) AND (MIC.FECHA_ALTA <= @FECHA_FUERA_SERVICIO) AND (ACTITUD_GDD.MICRO_REEMPLAZABLE(MIC.PATENTE, @PATENTE) = 1 AND (MIC.PATENTE != @PATENTE))
	OPEN CURSOR_MICROS
	FETCH CURSOR_MICROS INTO @MICRO_CURSOR
    WHILE (@@FETCH_STATUS = 0) AND (@SE_ENCONTRO_MICRO = 0)
    BEGIN
    
		DECLARE @FECHA_SALIDA_VIAJE_CURSOR DATETIME
		DECLARE @FECHA_LLEGADA_VIAJE_CURSOR DATETIME
		DECLARE @ID_CIUDAD_ORIGEN_CURSOR INT
		DECLARE @ID_CIUDAD_DESTINO_CURSOR INT
		DECLARE @VIAJE_REEMPLAZABLE BIT
		SET @VIAJE_REEMPLAZABLE = 1
		
		DECLARE CURSOR_VIAJES CURSOR LOCAL
		FOR SELECT VJE.FECHA_SALIDA, VJE.FECHA_LLEGADA_ESTIMADA, RDO.ID_CIUDAD_ORIGEN, RDO.ID_CIUDAD_DESTINO
		FROM ACTITUD_GDD.VIAJE VJE JOIN ACTITUD_GDD.RECORRIDO RDO ON (VJE.RECORRIDO_CODIGO = RDO.RECORRIDO_CODIGO)
		WHERE VJE.PATENTE = @PATENTE AND VJE.FECHA_SALIDA >= @FECHA_FUERA_SERVICIO AND VJE.FECHA_SALIDA <= @FECHA_REINICIO_SERVICIO AND (ISNULL(VJE.BAJA_LOGICA,0) = 0) AND (ISNULL(VJE.FECHA_LLEGADA,0) = 0)
		OPEN CURSOR_VIAJES
		FETCH CURSOR_VIAJES INTO @FECHA_SALIDA_VIAJE_CURSOR, @FECHA_LLEGADA_VIAJE_CURSOR, @ID_CIUDAD_ORIGEN_CURSOR, @ID_CIUDAD_DESTINO_CURSOR
		WHILE (@@FETCH_STATUS = 0 AND @VIAJE_REEMPLAZABLE = 1) 
		BEGIN
			
			SET @VIAJE_REEMPLAZABLE = 0
			
			IF(ACTITUD_GDD.ESTA_DISPONIBLE(@MICRO_CURSOR, @FECHA_SALIDA_VIAJE_CURSOR, @FECHA_LLEGADA_VIAJE_CURSOR, @ID_CIUDAD_ORIGEN_CURSOR, @ID_CIUDAD_DESTINO_CURSOR) = 1)
			BEGIN
				IF(ACTITUD_GDD.ESTA_DADO_DE_BAJA_TEMPORAL(@MICRO_CURSOR, @FECHA_SALIDA_VIAJE_CURSOR, @FECHA_LLEGADA_VIAJE_CURSOR) = 0)
				BEGIN
					SET @VIAJE_REEMPLAZABLE = 1
				END
			END
		
		
		FETCH CURSOR_VIAJES INTO @FECHA_SALIDA_VIAJE_CURSOR, @FECHA_LLEGADA_VIAJE_CURSOR, @ID_CIUDAD_ORIGEN_CURSOR, @ID_CIUDAD_DESTINO_CURSOR
		END
		CLOSE CURSOR_VIAJES
		
		IF(@VIAJE_REEMPLAZABLE = 1)
		BEGIN
			SET @SE_ENCONTRO_MICRO = 1
			SET @MICRO_ELEGIDO = @MICRO_CURSOR
		END
    
    
    
    FETCH CURSOR_MICROS INTO @MICRO_CURSOR
    END
    
    CLOSE CURSOR_MICROS
    
    
    IF(@SE_ENCONTRO_MICRO = 1)
    BEGIN
		EXEC ACTITUD_GDD.REEMPLAZAR_MICRO_VIAJES_TEMPORAL @PATENTE, @MICRO_ELEGIDO, @FECHA_FUERA_SERVICIO, @FECHA_REINICIO_SERVICIO
    END
    ELSE
    BEGIN
		EXEC ACTITUD_GDD.CANCELAR_TODO_POR_BAJA_TEMPORAL @ID_BAJA_TEMPORAL, @FECHA_ACTUAL
    END
    
    
    if( @SE_ENCONTRO_MICRO = 1)
    begin
		select @MICRO_ELEGIDO SE_ENCONTRO_MICRO 
    end
    else
    begin
		SELECT 'SinPatente' SE_ENCONTRO_MICRO 
	end
	
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[REEMPLAZAR_MICRO_VIAJES]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[REEMPLAZAR_MICRO_VIAJES] 
	-- Add the parameters for the stored procedure here
	@PATENTE NVARCHAR(255),
	@MICRO_ELEGIDO NVARCHAR(255),
	@FECHA_DE_BAJA DATETIME
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DECLARE @ID_VIAJE INT
	
	DECLARE CURSOR_VIAJES CURSOR LOCAL
	FOR SELECT VJE.ID
	FROM ACTITUD_GDD.VIAJE VJE 
	WHERE VJE.PATENTE = @PATENTE AND VJE.FECHA_SALIDA >= @FECHA_DE_BAJA AND (ISNULL(VJE.BAJA_LOGICA,0) = 0) AND (ISNULL(VJE.FECHA_LLEGADA,0) = 0)
	
	OPEN CURSOR_VIAJES	
	FETCH CURSOR_VIAJES INTO @ID_VIAJE
	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		EXEC ACTITUD_GDD.CAMBIAR_NUMERO_BUTACAS_PASAJES @ID_VIAJE, @MICRO_ELEGIDO
	
		UPDATE [GD1C2013].[ACTITUD_GDD].[VIAJE]
		SET [PATENTE] = @MICRO_ELEGIDO
		WHERE ID = @ID_VIAJE

	
	FETCH CURSOR_VIAJES INTO @ID_VIAJE
	END
	CLOSE CURSOR_VIAJES

	
    
END
GO
/****** Object:  StoredProcedure [ACTITUD_GDD].[REEMPLAZAR_TODO_POR_BAJA_LOGICA]    Script Date: 07/19/2013 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ACTITUD_GDD].[REEMPLAZAR_TODO_POR_BAJA_LOGICA] 
	-- Add the parameters for the stored procedure here
	@PATENTE NVARCHAR(255),
	@FECHA_ACTUAL DATETIME
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DECLARE @FECHA_DE_BAJA DATETIME
    DECLARE @FECHA_MENOR_DE_TODOS_LOS_VIAJES DATETIME
	
	SELECT @FECHA_DE_BAJA = MC.FECHA_BAJA_DEFINITIVA
	FROM ACTITUD_GDD.MICRO MC
	WHERE MC.PATENTE = @PATENTE
	
	SELECT TOP 1 @FECHA_MENOR_DE_TODOS_LOS_VIAJES = VJ.FECHA_SALIDA
	FROM ACTITUD_GDD.VIAJE VJ
	WHERE VJ.PATENTE = @PATENTE AND VJ.FECHA_SALIDA >= @FECHA_DE_BAJA
	ORDER BY VJ.FECHA_SALIDA ASC
	
	
	DECLARE @MICRO_CURSOR NVARCHAR(255)
	DECLARE @SE_ENCONTRO_MICRO BIT
	SET @SE_ENCONTRO_MICRO = 0
	DECLARE @MICRO_ELEGIDO NVARCHAR(255)
	
	DECLARE CURSOR_MICROS CURSOR LOCAL
    FOR SELECT MIC.PATENTE
	FROM ACTITUD_GDD.MICRO MIC
	WHERE (ISNULL(MIC.FECHA_BAJA_DEFINITIVA,0) = 0) AND (MIC.FECHA_ALTA <= @FECHA_MENOR_DE_TODOS_LOS_VIAJES) AND (ACTITUD_GDD.MICRO_REEMPLAZABLE(MIC.PATENTE, @PATENTE) = 1)
	
	OPEN CURSOR_MICROS
	FETCH CURSOR_MICROS INTO @MICRO_CURSOR
    WHILE (@@FETCH_STATUS = 0) AND (@SE_ENCONTRO_MICRO = 0)
    BEGIN
    
		DECLARE @FECHA_SALIDA_VIAJE_CURSOR DATETIME
		DECLARE @FECHA_LLEGADA_VIAJE_CURSOR DATETIME
		DECLARE @ID_CIUDAD_ORIGEN_CURSOR INT
		DECLARE @ID_CIUDAD_DESTINO_CURSOR INT
		DECLARE @VIAJE_REEMPLAZABLE BIT
		SET @VIAJE_REEMPLAZABLE = 1
		
		DECLARE CURSOR_VIAJES CURSOR LOCAL
		FOR SELECT VJE.FECHA_SALIDA, VJE.FECHA_LLEGADA_ESTIMADA, RDO.ID_CIUDAD_ORIGEN, RDO.ID_CIUDAD_DESTINO
		FROM ACTITUD_GDD.VIAJE VJE JOIN ACTITUD_GDD.RECORRIDO RDO ON (VJE.RECORRIDO_CODIGO = RDO.RECORRIDO_CODIGO)
		WHERE VJE.PATENTE = @PATENTE AND VJE.FECHA_SALIDA >= @FECHA_DE_BAJA AND (ISNULL(VJE.BAJA_LOGICA,0) = 0) AND (ISNULL(VJE.FECHA_LLEGADA,0) = 0)
		
		OPEN CURSOR_VIAJES
		FETCH CURSOR_VIAJES INTO @FECHA_SALIDA_VIAJE_CURSOR, @FECHA_LLEGADA_VIAJE_CURSOR, @ID_CIUDAD_ORIGEN_CURSOR, @ID_CIUDAD_DESTINO_CURSOR
		WHILE (@@FETCH_STATUS = 0 AND @VIAJE_REEMPLAZABLE = 1) 
		BEGIN
			
			SET @VIAJE_REEMPLAZABLE = 0
			
			IF(ACTITUD_GDD.ESTA_DISPONIBLE(@MICRO_CURSOR, @FECHA_SALIDA_VIAJE_CURSOR, @FECHA_LLEGADA_VIAJE_CURSOR, @ID_CIUDAD_ORIGEN_CURSOR, @ID_CIUDAD_DESTINO_CURSOR) = 1)
			BEGIN
				IF(ACTITUD_GDD.ESTA_DADO_DE_BAJA_TEMPORAL(@MICRO_CURSOR, @FECHA_SALIDA_VIAJE_CURSOR, @FECHA_LLEGADA_VIAJE_CURSOR) = 0)
				BEGIN
					SET @VIAJE_REEMPLAZABLE = 1
				END
			END
		
		
		FETCH CURSOR_VIAJES INTO @FECHA_SALIDA_VIAJE_CURSOR, @FECHA_LLEGADA_VIAJE_CURSOR, @ID_CIUDAD_ORIGEN_CURSOR, @ID_CIUDAD_DESTINO_CURSOR
		END
		CLOSE CURSOR_VIAJES
		
		IF(@VIAJE_REEMPLAZABLE = 1)
		BEGIN
			SET @SE_ENCONTRO_MICRO = 1
			SET @MICRO_ELEGIDO = @MICRO_CURSOR
		END
    
    
    
    FETCH CURSOR_MICROS INTO @MICRO_CURSOR
    END
    
    CLOSE CURSOR_MICROS
    
    
    IF(@SE_ENCONTRO_MICRO = 1)
    BEGIN
		EXEC ACTITUD_GDD.REEMPLAZAR_MICRO_VIAJES @PATENTE, @MICRO_ELEGIDO, @FECHA_DE_BAJA
    END
    ELSE
    BEGIN
		EXEC ACTITUD_GDD.CANCELAR_TODO_POR_BAJA_LOGICA @PATENTE, @FECHA_ACTUAL
    END
    
    
    if( @SE_ENCONTRO_MICRO = 1)
    begin
		select @MICRO_ELEGIDO SE_ENCONTRO_MICRO 
    end
    else
    begin
		SELECT 'SinPatente' SE_ENCONTRO_MICRO 
	end
	
END
GO
/****** Object:  Default [DF_CLIENTE_DISCAPACITADO]    Script Date: 07/19/2013 05:37:34 ******/
ALTER TABLE [ACTITUD_GDD].[CLIENTE] ADD  CONSTRAINT [DF_CLIENTE_DISCAPACITADO]  DEFAULT ((0)) FOR [DISCAPACITADO]
GO
/****** Object:  Default [DF_PAQUETE_PUNTOS_CANJEADOS]    Script Date: 07/19/2013 05:37:34 ******/
ALTER TABLE [ACTITUD_GDD].[PAQUETE] ADD  CONSTRAINT [DF_PAQUETE_PUNTOS_CANJEADOS]  DEFAULT ((0)) FOR [PUNTOS_CANJEADOS]
GO
/****** Object:  Default [DF_PASAJE_PUNTOS_CANJEADOS]    Script Date: 07/19/2013 05:37:34 ******/
ALTER TABLE [ACTITUD_GDD].[PASAJE] ADD  CONSTRAINT [DF_PASAJE_PUNTOS_CANJEADOS]  DEFAULT ((0)) FOR [PUNTOS_CANJEADOS]
GO
/****** Object:  Default [DF_RECORRIDO_BAJA_LOGICA]    Script Date: 07/19/2013 05:37:34 ******/
ALTER TABLE [ACTITUD_GDD].[RECORRIDO] ADD  CONSTRAINT [DF_RECORRIDO_BAJA_LOGICA]  DEFAULT ((0)) FOR [BAJA_LOGICA]
GO
/****** Object:  Default [DF_ROL_BAJA_LOGICA]    Script Date: 07/19/2013 05:37:34 ******/
ALTER TABLE [ACTITUD_GDD].[ROL] ADD  CONSTRAINT [DF_ROL_BAJA_LOGICA]  DEFAULT ((0)) FOR [BAJA_LOGICA]
GO
/****** Object:  Default [DF_USUARIO_INTENTOS]    Script Date: 07/19/2013 05:37:34 ******/
ALTER TABLE [ACTITUD_GDD].[USUARIO] ADD  CONSTRAINT [DF_USUARIO_INTENTOS]  DEFAULT ((0)) FOR [INTENTOS]
GO
/****** Object:  Default [DF_VIAJE_BAJA_LOGICA]    Script Date: 07/19/2013 05:37:34 ******/
ALTER TABLE [ACTITUD_GDD].[VIAJE] ADD  CONSTRAINT [DF_VIAJE_BAJA_LOGICA]  DEFAULT ((0)) FOR [BAJA_LOGICA]
GO
/****** Object:  ForeignKey [FK_BAJA_TEMPORAL_MICRO]    Script Date: 07/19/2013 05:37:34 ******/
ALTER TABLE [ACTITUD_GDD].[BAJA_TEMPORAL]  WITH CHECK ADD  CONSTRAINT [FK_BAJA_TEMPORAL_MICRO] FOREIGN KEY([PATENTE])
REFERENCES [ACTITUD_GDD].[MICRO] ([PATENTE])
GO
ALTER TABLE [ACTITUD_GDD].[BAJA_TEMPORAL] CHECK CONSTRAINT [FK_BAJA_TEMPORAL_MICRO]
GO
/****** Object:  ForeignKey [FK_CANJE_CLIENTE]    Script Date: 07/19/2013 05:37:34 ******/
ALTER TABLE [ACTITUD_GDD].[CANJE]  WITH CHECK ADD  CONSTRAINT [FK_CANJE_CLIENTE] FOREIGN KEY([DNI])
REFERENCES [ACTITUD_GDD].[CLIENTE] ([DNI])
GO
ALTER TABLE [ACTITUD_GDD].[CANJE] CHECK CONSTRAINT [FK_CANJE_CLIENTE]
GO
/****** Object:  ForeignKey [FK_CANJE_PRODUCTO]    Script Date: 07/19/2013 05:37:34 ******/
ALTER TABLE [ACTITUD_GDD].[CANJE]  WITH CHECK ADD  CONSTRAINT [FK_CANJE_PRODUCTO] FOREIGN KEY([ID_PRODUCTO])
REFERENCES [ACTITUD_GDD].[PRODUCTO] ([ID])
GO
ALTER TABLE [ACTITUD_GDD].[CANJE] CHECK CONSTRAINT [FK_CANJE_PRODUCTO]
GO
/****** Object:  ForeignKey [FK_COMPRA_CLIENTE]    Script Date: 07/19/2013 05:37:34 ******/
ALTER TABLE [ACTITUD_GDD].[COMPRA]  WITH CHECK ADD  CONSTRAINT [FK_COMPRA_CLIENTE] FOREIGN KEY([DNI])
REFERENCES [ACTITUD_GDD].[CLIENTE] ([DNI])
GO
ALTER TABLE [ACTITUD_GDD].[COMPRA] CHECK CONSTRAINT [FK_COMPRA_CLIENTE]
GO
/****** Object:  ForeignKey [FK_FUNCIONALIDADXROL_FUNCIONALIDAD]    Script Date: 07/19/2013 05:37:34 ******/
ALTER TABLE [ACTITUD_GDD].[FUNCIONALIDADXROL]  WITH CHECK ADD  CONSTRAINT [FK_FUNCIONALIDADXROL_FUNCIONALIDAD] FOREIGN KEY([ID_FUNCIONALIDAD])
REFERENCES [ACTITUD_GDD].[FUNCIONALIDAD] ([ID])
GO
ALTER TABLE [ACTITUD_GDD].[FUNCIONALIDADXROL] CHECK CONSTRAINT [FK_FUNCIONALIDADXROL_FUNCIONALIDAD]
GO
/****** Object:  ForeignKey [FK_FUNCIONALIDADXROL_ROL]    Script Date: 07/19/2013 05:37:34 ******/
ALTER TABLE [ACTITUD_GDD].[FUNCIONALIDADXROL]  WITH CHECK ADD  CONSTRAINT [FK_FUNCIONALIDADXROL_ROL] FOREIGN KEY([ID_ROL])
REFERENCES [ACTITUD_GDD].[ROL] ([ID])
GO
ALTER TABLE [ACTITUD_GDD].[FUNCIONALIDADXROL] CHECK CONSTRAINT [FK_FUNCIONALIDADXROL_ROL]
GO
/****** Object:  ForeignKey [FK_MICRO_MODELO]    Script Date: 07/19/2013 05:37:34 ******/
ALTER TABLE [ACTITUD_GDD].[MICRO]  WITH CHECK ADD  CONSTRAINT [FK_MICRO_MODELO] FOREIGN KEY([ID_MODELO])
REFERENCES [ACTITUD_GDD].[MODELO] ([ID])
GO
ALTER TABLE [ACTITUD_GDD].[MICRO] CHECK CONSTRAINT [FK_MICRO_MODELO]
GO
/****** Object:  ForeignKey [FK_MICRO_SERVICIO]    Script Date: 07/19/2013 05:37:34 ******/
ALTER TABLE [ACTITUD_GDD].[MICRO]  WITH CHECK ADD  CONSTRAINT [FK_MICRO_SERVICIO] FOREIGN KEY([TIPO_SERVICIO])
REFERENCES [ACTITUD_GDD].[SERVICIO] ([ID])
GO
ALTER TABLE [ACTITUD_GDD].[MICRO] CHECK CONSTRAINT [FK_MICRO_SERVICIO]
GO
/****** Object:  ForeignKey [FK_PAQUETE_CANCELACION]    Script Date: 07/19/2013 05:37:34 ******/
ALTER TABLE [ACTITUD_GDD].[PAQUETE]  WITH CHECK ADD  CONSTRAINT [FK_PAQUETE_CANCELACION] FOREIGN KEY([ID_CANCELACION])
REFERENCES [ACTITUD_GDD].[CANCELACION] ([ID])
GO
ALTER TABLE [ACTITUD_GDD].[PAQUETE] CHECK CONSTRAINT [FK_PAQUETE_CANCELACION]
GO
/****** Object:  ForeignKey [FK_PAQUETE_CLIENTE]    Script Date: 07/19/2013 05:37:34 ******/
ALTER TABLE [ACTITUD_GDD].[PAQUETE]  WITH CHECK ADD  CONSTRAINT [FK_PAQUETE_CLIENTE] FOREIGN KEY([DNI])
REFERENCES [ACTITUD_GDD].[CLIENTE] ([DNI])
GO
ALTER TABLE [ACTITUD_GDD].[PAQUETE] CHECK CONSTRAINT [FK_PAQUETE_CLIENTE]
GO
/****** Object:  ForeignKey [FK_PAQUETE_COMPRA]    Script Date: 07/19/2013 05:37:34 ******/
ALTER TABLE [ACTITUD_GDD].[PAQUETE]  WITH CHECK ADD  CONSTRAINT [FK_PAQUETE_COMPRA] FOREIGN KEY([ID_COMPRA])
REFERENCES [ACTITUD_GDD].[COMPRA] ([ID])
GO
ALTER TABLE [ACTITUD_GDD].[PAQUETE] CHECK CONSTRAINT [FK_PAQUETE_COMPRA]
GO
/****** Object:  ForeignKey [FK_PAQUETE_VIAJE]    Script Date: 07/19/2013 05:37:34 ******/
ALTER TABLE [ACTITUD_GDD].[PAQUETE]  WITH CHECK ADD  CONSTRAINT [FK_PAQUETE_VIAJE] FOREIGN KEY([ID_VIAJE])
REFERENCES [ACTITUD_GDD].[VIAJE] ([ID])
GO
ALTER TABLE [ACTITUD_GDD].[PAQUETE] CHECK CONSTRAINT [FK_PAQUETE_VIAJE]
GO
/****** Object:  ForeignKey [FK_PASAJE_CANCELACION]    Script Date: 07/19/2013 05:37:34 ******/
ALTER TABLE [ACTITUD_GDD].[PASAJE]  WITH CHECK ADD  CONSTRAINT [FK_PASAJE_CANCELACION] FOREIGN KEY([ID_CANCELACION])
REFERENCES [ACTITUD_GDD].[CANCELACION] ([ID])
GO
ALTER TABLE [ACTITUD_GDD].[PASAJE] CHECK CONSTRAINT [FK_PASAJE_CANCELACION]
GO
/****** Object:  ForeignKey [FK_PASAJE_CLIENTE]    Script Date: 07/19/2013 05:37:34 ******/
ALTER TABLE [ACTITUD_GDD].[PASAJE]  WITH CHECK ADD  CONSTRAINT [FK_PASAJE_CLIENTE] FOREIGN KEY([DNI])
REFERENCES [ACTITUD_GDD].[CLIENTE] ([DNI])
GO
ALTER TABLE [ACTITUD_GDD].[PASAJE] CHECK CONSTRAINT [FK_PASAJE_CLIENTE]
GO
/****** Object:  ForeignKey [FK_PASAJE_COMPRA]    Script Date: 07/19/2013 05:37:34 ******/
ALTER TABLE [ACTITUD_GDD].[PASAJE]  WITH CHECK ADD  CONSTRAINT [FK_PASAJE_COMPRA] FOREIGN KEY([ID_COMPRA])
REFERENCES [ACTITUD_GDD].[COMPRA] ([ID])
GO
ALTER TABLE [ACTITUD_GDD].[PASAJE] CHECK CONSTRAINT [FK_PASAJE_COMPRA]
GO
/****** Object:  ForeignKey [FK_PASAJE_VIAJE]    Script Date: 07/19/2013 05:37:34 ******/
ALTER TABLE [ACTITUD_GDD].[PASAJE]  WITH CHECK ADD  CONSTRAINT [FK_PASAJE_VIAJE] FOREIGN KEY([ID_VIAJE])
REFERENCES [ACTITUD_GDD].[VIAJE] ([ID])
GO
ALTER TABLE [ACTITUD_GDD].[PASAJE] CHECK CONSTRAINT [FK_PASAJE_VIAJE]
GO
/****** Object:  ForeignKey [FK_RECORRIDO_CIUDAD]    Script Date: 07/19/2013 05:37:34 ******/
ALTER TABLE [ACTITUD_GDD].[RECORRIDO]  WITH CHECK ADD  CONSTRAINT [FK_RECORRIDO_CIUDAD] FOREIGN KEY([ID_CIUDAD_DESTINO])
REFERENCES [ACTITUD_GDD].[CIUDAD] ([ID])
GO
ALTER TABLE [ACTITUD_GDD].[RECORRIDO] CHECK CONSTRAINT [FK_RECORRIDO_CIUDAD]
GO
/****** Object:  ForeignKey [FK_RECORRIDO_CIUDAD1]    Script Date: 07/19/2013 05:37:34 ******/
ALTER TABLE [ACTITUD_GDD].[RECORRIDO]  WITH CHECK ADD  CONSTRAINT [FK_RECORRIDO_CIUDAD1] FOREIGN KEY([ID_CIUDAD_ORIGEN])
REFERENCES [ACTITUD_GDD].[CIUDAD] ([ID])
GO
ALTER TABLE [ACTITUD_GDD].[RECORRIDO] CHECK CONSTRAINT [FK_RECORRIDO_CIUDAD1]
GO
/****** Object:  ForeignKey [FK_RECORRIDO_PRECIO_BASE]    Script Date: 07/19/2013 05:37:34 ******/
ALTER TABLE [ACTITUD_GDD].[RECORRIDO]  WITH CHECK ADD  CONSTRAINT [FK_RECORRIDO_PRECIO_BASE] FOREIGN KEY([ID_PRECIO_BASE])
REFERENCES [ACTITUD_GDD].[PRECIO_BASE] ([ID])
GO
ALTER TABLE [ACTITUD_GDD].[RECORRIDO] CHECK CONSTRAINT [FK_RECORRIDO_PRECIO_BASE]
GO
/****** Object:  ForeignKey [FK_RECORRIDO_SERVICIO]    Script Date: 07/19/2013 05:37:34 ******/
ALTER TABLE [ACTITUD_GDD].[RECORRIDO]  WITH CHECK ADD  CONSTRAINT [FK_RECORRIDO_SERVICIO] FOREIGN KEY([ID_SERVICIO])
REFERENCES [ACTITUD_GDD].[SERVICIO] ([ID])
GO
ALTER TABLE [ACTITUD_GDD].[RECORRIDO] CHECK CONSTRAINT [FK_RECORRIDO_SERVICIO]
GO
/****** Object:  ForeignKey [FK_TARJETA_DE_CREDITO_CLIENTE]    Script Date: 07/19/2013 05:37:34 ******/
ALTER TABLE [ACTITUD_GDD].[TARJETA_DE_CREDITO]  WITH CHECK ADD  CONSTRAINT [FK_TARJETA_DE_CREDITO_CLIENTE] FOREIGN KEY([DNI])
REFERENCES [ACTITUD_GDD].[CLIENTE] ([DNI])
GO
ALTER TABLE [ACTITUD_GDD].[TARJETA_DE_CREDITO] CHECK CONSTRAINT [FK_TARJETA_DE_CREDITO_CLIENTE]
GO
/****** Object:  ForeignKey [FK_TARJETA_DE_CREDITO_TIPO_TARJETA]    Script Date: 07/19/2013 05:37:34 ******/
ALTER TABLE [ACTITUD_GDD].[TARJETA_DE_CREDITO]  WITH CHECK ADD  CONSTRAINT [FK_TARJETA_DE_CREDITO_TIPO_TARJETA] FOREIGN KEY([ID_TIPO])
REFERENCES [ACTITUD_GDD].[TIPO_TARJETA] ([ID])
GO
ALTER TABLE [ACTITUD_GDD].[TARJETA_DE_CREDITO] CHECK CONSTRAINT [FK_TARJETA_DE_CREDITO_TIPO_TARJETA]
GO
/****** Object:  ForeignKey [FK_USUARIOXROL_ROL]    Script Date: 07/19/2013 05:37:34 ******/
ALTER TABLE [ACTITUD_GDD].[USUARIOXROL]  WITH CHECK ADD  CONSTRAINT [FK_USUARIOXROL_ROL] FOREIGN KEY([ID_ROL])
REFERENCES [ACTITUD_GDD].[ROL] ([ID])
GO
ALTER TABLE [ACTITUD_GDD].[USUARIOXROL] CHECK CONSTRAINT [FK_USUARIOXROL_ROL]
GO
/****** Object:  ForeignKey [FK_USUARIOXROL_USUARIO]    Script Date: 07/19/2013 05:37:34 ******/
ALTER TABLE [ACTITUD_GDD].[USUARIOXROL]  WITH CHECK ADD  CONSTRAINT [FK_USUARIOXROL_USUARIO] FOREIGN KEY([ID_USUARIO])
REFERENCES [ACTITUD_GDD].[USUARIO] ([ID])
GO
ALTER TABLE [ACTITUD_GDD].[USUARIOXROL] CHECK CONSTRAINT [FK_USUARIOXROL_USUARIO]
GO
/****** Object:  ForeignKey [FK_VIAJE_MICRO]    Script Date: 07/19/2013 05:37:34 ******/
ALTER TABLE [ACTITUD_GDD].[VIAJE]  WITH CHECK ADD  CONSTRAINT [FK_VIAJE_MICRO] FOREIGN KEY([PATENTE])
REFERENCES [ACTITUD_GDD].[MICRO] ([PATENTE])
GO
ALTER TABLE [ACTITUD_GDD].[VIAJE] CHECK CONSTRAINT [FK_VIAJE_MICRO]
GO
/****** Object:  ForeignKey [FK_VIAJE_RECORRIDO]    Script Date: 07/19/2013 05:37:34 ******/
ALTER TABLE [ACTITUD_GDD].[VIAJE]  WITH CHECK ADD  CONSTRAINT [FK_VIAJE_RECORRIDO] FOREIGN KEY([RECORRIDO_CODIGO])
REFERENCES [ACTITUD_GDD].[RECORRIDO] ([RECORRIDO_CODIGO])
GO
ALTER TABLE [ACTITUD_GDD].[VIAJE] CHECK CONSTRAINT [FK_VIAJE_RECORRIDO]
GO


































-- Inicio Migracion

GO
ACTITUD_GDD.MIGRAR_BUTACA
GO
ACTITUD_GDD.MIGRAR_CIUDAD
GO
ACTITUD_GDD.MIGRAR_CLIENTE
GO
ACTITUD_GDD.MIGRAR_MODELO
GO
ACTITUD_GDD.MIGRAR_SERVICIO
GO
ACTITUD_GDD.MIGRAR_MICRO
GO
ACTITUD_GDD.MIGRAR_PRECIO_BASE
GO
ACTITUD_GDD.MIGRAR_RECORRIDO
GO
ACTITUD_GDD.MIGRAR_VIAJE_COMPRA_PASAJE_PAQUETE
GO
ACTITUD_GDD.MIGRAR_MICRO_FECHA_ALTA
GO







--TRIGGERS
USE [GD1C2013]
GO
/****** Object:  Trigger [ACTITUD_GDD].[DESCONTAR_STOCK_PUNTOS]    Script Date: 07/19/2013 05:40:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [ACTITUD_GDD].[DESCONTAR_STOCK_PUNTOS]
   ON  [ACTITUD_GDD].[CANJE]
   AFTER INSERT
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @DNI NUMERIC(18,0), @ID_PRODUCTO INT, @CANTIDAD INT, @FECHA DATETIME
	
	SELECT TOP 1 @DNI = INS.DNI, @ID_PRODUCTO = INS.ID_PRODUCTO, @CANTIDAD = INS.CANTIDAD_PRODUCTO, @FECHA = INS.FECHA
	FROM inserted INS
	
    
    UPDATE ACTITUD_GDD.PRODUCTO
    SET STOCK = (STOCK - @CANTIDAD)
    WHERE ID = @ID_PRODUCTO
    
    
    DECLARE @PTOS NUMERIC(18,0)
    
    SET @PTOS = ACTITUD_GDD.CALCULAR_CANT_PTOS(@ID_PRODUCTO,@CANTIDAD)
    
    EXEC ACTITUD_GDD.DESCONTARPUNTOS @DNI, @PTOS, @FECHA

END

GO


USE [GD1C2013]
GO
/****** Object:  Trigger [ACTITUD_GDD].[RESERVARPAQUETE]    Script Date: 07/11/2013 01:11:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [ACTITUD_GDD].[RESERVARPAQUETE] 
   ON  [ACTITUD_GDD].[PAQUETE] 
   INSTEAD OF INSERT
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DECLARE @PESO_A_CARGAR INT
    DECLARE @ID_VIAJE INT
    DECLARE @PESO_DISP INT
    DECLARE @PATENTE NVARCHAR(255)
    
    SELECT TOP 1 @PESO_A_CARGAR = PESO, @ID_VIAJE = ID_VIAJE
    FROM inserted
    
    SELECT TOP 1 @PATENTE = PATENTE FROM ACTITUD_GDD.VIAJE VJ WHERE VJ.ID = @ID_VIAJE
    
    
    SET @PESO_DISP = ACTITUD_GDD.KG_LIBRES_VIAJE(@ID_VIAJE, @PATENTE)
    
    IF @PESO_A_CARGAR <= @PESO_DISP
    BEGIN
		insert into PAQUETE( DNI, PESO, PUNTOS_CANJEADOS, ID_VIAJE, ID_COMPRA, PRECIO ) 
		select TOP 1 DNI, PESO, PUNTOS_CANJEADOS, ID_VIAJE, ID_COMPRA, PRECIO
		from inserted
    END
    
    

END

GO

USE [GD1C2013]
GO
/****** Object:  Trigger [ACTITUD_GDD].[RESERVARPASAJE]    Script Date: 07/19/2013 05:39:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [ACTITUD_GDD].[RESERVARPASAJE]
   ON  [ACTITUD_GDD].[PASAJE]
   INSTEAD OF INSERT
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DECLARE @BUTACA_NUMERO INT
    DECLARE @ID_VIAJE INT
    DECLARE @RESULTADO INT
    DECLARE @DNI NUMERIC(18,0)
    DECLARE @ESTAVIAJANDO INT
    
    SET @RESULTADO = 0
    
    SELECT TOP 1 @BUTACA_NUMERO = BUTACA_NUMERO, @ID_VIAJE = ID_VIAJE, @DNI = DNI
    FROM inserted    
    
    SELECT TOP 1 @RESULTADO = 1 
    FROM ACTITUD_GDD.PASAJE PJ 
    WHERE PJ.ID_VIAJE = @ID_VIAJE AND PJ.BUTACA_NUMERO = @BUTACA_NUMERO AND ISNULL(PJ.ID_CANCELACION, 0) = 0 
    
    SELECT  TOP 1 @RESULTADO = 1
	FROM ACTITUD_GDD.PASAJE PJ 
	WHERE PJ.DNI = @DNI AND ISNULL(PJ.ID_CANCELACION, 0) = 0 AND (ACTITUD_GDD.VIAJESCRUZAN(PJ.ID_VIAJE, @ID_VIAJE) = 1)
    
    
    
    
    IF @RESULTADO = 0
    BEGIN
		insert into PASAJE( DNI, BUTACA_NUMERO, PUNTOS_CANJEADOS, ID_VIAJE, ID_COMPRA, PRECIO ) 
		select TOP 1 DNI, BUTACA_NUMERO, PUNTOS_CANJEADOS, ID_VIAJE, ID_COMPRA, PRECIO
		from inserted
    END
    
    

END

GO

USE [GD1C2013]
GO
/****** Object:  Trigger [ACTITUD_GDD].[DESVINCULAR_RECORRIDO_VIAJE_PASAJE_PAQUETE]    Script Date: 07/11/2013 01:13:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [ACTITUD_GDD].[DESVINCULAR_RECORRIDO_VIAJE_PASAJE_PAQUETE]
   ON  [ACTITUD_GDD].[RECORRIDO] 
   INSTEAD OF DELETE
AS 
BEGIN

	UPDATE RE
	SET BAJA_LOGICA = 1
	FROM ACTITUD_GDD.RECORRIDO RE JOIN DELETED DT ON (RE.RECORRIDO_CODIGO = DT.RECORRIDO_CODIGO)
END

GO


USE [GD1C2013]
GO
/****** Object:  Trigger [ACTITUD_GDD].[DESBINCULAR_ROL_USUARIO]    Script Date: 07/11/2013 01:14:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [ACTITUD_GDD].[DESBINCULAR_ROL_USUARIO] 
   ON  [ACTITUD_GDD].[ROL] 
   INSTEAD OF DELETE
AS 
BEGIN
	DELETE FROM ACTITUD_GDD.USUARIOXROL
	WHERE (SELECT ID FROM DELETED) = ID_ROL
	
	UPDATE ACTITUD_GDD.ROL
	SET BAJA_LOGICA = 1
	WHERE ( SELECT ID FROM DELETED) = ID
	
END

GO

USE [GD1C2013]
GO
/****** Object:  Trigger [ACTITUD_GDD].[DESBINCULAR_ROL_USUARIO]    Script Date: 07/11/2013 01:14:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [ACTITUD_GDD].[BAJA_LOGICA_VIAJE] 
   ON  [ACTITUD_GDD].[VIAJE] 
   INSTEAD OF DELETE
AS 
BEGIN
	
	UPDATE ACTITUD_GDD.VIAJE
	SET BAJA_LOGICA = 1
	WHERE ( SELECT ID FROM DELETED) = ID
	
END

GO





--INDICES

USE [GD1C2013]
GO

/****** Object:  Index [DNI]    Script Date: 07/11/2013 01:22:40 ******/
CREATE NONCLUSTERED INDEX [DNI] ON [ACTITUD_GDD].[PAQUETE] 
(
	[DNI] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


USE [GD1C2013]
GO

/****** Object:  Index [DNI]    Script Date: 07/11/2013 01:23:09 ******/
CREATE NONCLUSTERED INDEX [DNI] ON [ACTITUD_GDD].[PASAJE] 
(
	[DNI] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO








--INSERTAR FUNCIONALIDADES
INSERT INTO ACTITUD_GDD.FUNCIONALIDAD (NOMBRE) VALUES ('abmRol');
INSERT INTO ACTITUD_GDD.FUNCIONALIDAD (NOMBRE) VALUES ('abmMicro');
INSERT INTO ACTITUD_GDD.FUNCIONALIDAD (NOMBRE) VALUES ('abmRecorrido');
INSERT INTO ACTITUD_GDD.FUNCIONALIDAD (NOMBRE) VALUES ('puntosCliente');
INSERT INTO ACTITUD_GDD.FUNCIONALIDAD (NOMBRE) VALUES ('canjearPuntoClientes');
INSERT INTO ACTITUD_GDD.FUNCIONALIDAD (NOMBRE) VALUES ('comprar');
INSERT INTO ACTITUD_GDD.FUNCIONALIDAD (NOMBRE) VALUES ('registroLLegada');
INSERT INTO ACTITUD_GDD.FUNCIONALIDAD (NOMBRE) VALUES ('devolucionItems');
INSERT INTO ACTITUD_GDD.FUNCIONALIDAD (NOMBRE) VALUES ('generarViaje');
INSERT INTO ACTITUD_GDD.FUNCIONALIDAD (NOMBRE) VALUES ('listado');



--INSERTAR ROLES
INSERT INTO ACTITUD_GDD.ROL (NOMBRE) VALUES ('Kiosko');
INSERT INTO ACTITUD_GDD.ROL (NOMBRE) VALUES ('Administrador General');


--INSERTAR USUARIOS CON UN PASSWORD CREADO USANDO EL ALGORITMO SHA256
INSERT INTO ACTITUD_GDD.USUARIO (USERNAME,PASSWORD) VALUES ('admin','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7');

--INSERTAR FUNCIONALIDADESXROL ADMIN
INSERT INTO ACTITUD_GDD.FUNCIONALIDADXROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (2,1)
INSERT INTO ACTITUD_GDD.FUNCIONALIDADXROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (2,2)
INSERT INTO ACTITUD_GDD.FUNCIONALIDADXROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (2,3)
INSERT INTO ACTITUD_GDD.FUNCIONALIDADXROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (2,4)
INSERT INTO ACTITUD_GDD.FUNCIONALIDADXROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (2,5)
INSERT INTO ACTITUD_GDD.FUNCIONALIDADXROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (2,6)
INSERT INTO ACTITUD_GDD.FUNCIONALIDADXROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (2,7)
INSERT INTO ACTITUD_GDD.FUNCIONALIDADXROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (2,8)
INSERT INTO ACTITUD_GDD.FUNCIONALIDADXROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (2,9)
INSERT INTO ACTITUD_GDD.FUNCIONALIDADXROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (2,10)

--INSERTAR USUARIOXROL ADMIN
INSERT INTO ACTITUD_GDD.USUARIOXROL (ID_USUARIO,ID_ROL) VALUES (1,2)

--INSERTAR FUNCIONALIDADESXROL KIOSKO
INSERT INTO ACTITUD_GDD.FUNCIONALIDADXROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (1,6)
INSERT INTO ACTITUD_GDD.FUNCIONALIDADXROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (1,4)

--INSERTAR PRODUCTOS CANJEABLES
INSERT INTO ACTITUD_GDD.PRODUCTO (NOMBRE,STOCK,CANTIDAD_PTOS) VALUES ('Patito',400,1)
INSERT INTO ACTITUD_GDD.PRODUCTO (NOMBRE,STOCK,CANTIDAD_PTOS) VALUES ('Patote',200,20)
INSERT INTO ACTITUD_GDD.PRODUCTO (NOMBRE,STOCK,CANTIDAD_PTOS) VALUES ('Fosforos',100,100)
INSERT INTO ACTITUD_GDD.PRODUCTO (NOMBRE,STOCK,CANTIDAD_PTOS) VALUES ('Patito de Goma',200,1000)
INSERT INTO ACTITUD_GDD.PRODUCTO (NOMBRE,STOCK,CANTIDAD_PTOS) VALUES ('Patito de Hule',220,1000)
INSERT INTO ACTITUD_GDD.PRODUCTO (NOMBRE,STOCK,CANTIDAD_PTOS) VALUES ('Blasfemias',10,1000)


--INSERTAR TIPOS DE TARJETA DE CREDITO
INSERT INTO [GD1C2013].[ACTITUD_GDD].[TIPO_TARJETA] ([DESCRIPCION],[CANT_CUOTAS]) VALUES ('Platinium', 12)
INSERT INTO [GD1C2013].[ACTITUD_GDD].[TIPO_TARJETA] ([DESCRIPCION],[CANT_CUOTAS]) VALUES ('Gold', 18)
INSERT INTO [GD1C2013].[ACTITUD_GDD].[TIPO_TARJETA] ([DESCRIPCION],[CANT_CUOTAS]) VALUES ('Black', 24)
INSERT INTO [GD1C2013].[ACTITUD_GDD].[TIPO_TARJETA] ([DESCRIPCION],[CANT_CUOTAS]) VALUES ('Bronce', 6)
INSERT INTO [GD1C2013].[ACTITUD_GDD].[TIPO_TARJETA] ([DESCRIPCION],[CANT_CUOTAS]) VALUES ('Plastico', 4)
INSERT INTO [GD1C2013].[ACTITUD_GDD].[TIPO_TARJETA] ([DESCRIPCION],[CANT_CUOTAS]) VALUES ('Trucha', 5)






