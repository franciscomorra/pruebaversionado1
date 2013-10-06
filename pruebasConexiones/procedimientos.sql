SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertarStudent] 
	@Name nvarchar(max),
	@Address nvarchar(max),
	@Id int
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO dbo.Students(Name, Address) VALUES
	(@Name, @Address)
	SELECT @@Identity AS ID
END
GO
