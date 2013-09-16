/****** Object:  StoredProcedure [dbo].[InsertClient]    Script Date: 09/16/2013 01:08:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertClient]
	-- Add the parameters for the stored procedure here
	@Name nvarchar(max),
	@Address nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO Clients(Name, Address) VALUES
	(@Name, @Address)
	SELECT @@Identity AS ID
END
GO
/****** Object:  StoredProcedure [dbo].[modificarCliente]    Script Date: 09/16/2013 01:08:08 ******/
CREATE PROCEDURE [dbo].[modificarCliente]
	-- Add the parameters for the stored procedure here
	@Id int,
	@Name nvarchar(max),
	@Address nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE Clients SET
	name = @Name, 
	address = @Address
	WHERE ID = @Id
END
GO
CREATE PROCEDURE [dbo].[GetClients] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Clients
END
GO
CREATE PROCEDURE [dbo].[buscarCliente]
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT Name, Address,id
	FROM dbo.Clients
	WHERE id = @id
END
GO
CREATE PROCEDURE [dbo].[borrarCliente]
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DELETE FROM Clients
	WHERE ID = @Id
END
GO


