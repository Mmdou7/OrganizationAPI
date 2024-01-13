CREATE PROCEDURE [dbo].[spGetRecordsById]
	@tableName VARCHAR(50),
	@columns VARCHAR(MAX) = NULL,
	@id VARCHAR(22)
AS
BEGIN 
	DECLARE @sql NVARCHAR(MAX);

	IF @columns IS NULL
		SET @columns = '*';

	SET @sql = N'SELECT ' + @columns + ' From ' + QUOTENAME(@tableName)+ ' WHERE Id=@id AND ISDELETED=0';

	EXEC sp_executesql @sql,N'@id VARCHAR(22)',@id
END
