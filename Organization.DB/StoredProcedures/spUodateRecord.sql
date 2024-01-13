CREATE PROCEDURE [dbo].[spUodateRecord]
	@tableName VARCHAR(50),
	@columnToUpdate VARCHAR(MAX),
	@id VARCHAR(22)
AS
BEGIN
	DECLARE @sql NVARCHAR(MAX)

	SET @sql = N'UPDATE ' + QUOTENAME(@tableName) + ' SET ' + @columnToUpdate + ' WHERE Id=@id'

	EXEC sp_executesql @sql,N'@id VARCHAR(22)',@id
END
