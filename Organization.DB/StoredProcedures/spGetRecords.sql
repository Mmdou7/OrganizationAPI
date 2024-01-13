CREATE PROCEDURE [dbo].[spGetRecords]
	@tableName VARCHAR(50),
	@columns VARCHAR(MAX) = NULL
AS
BEGIN 
	DECLARE @sql NVARCHAR(MAX);

	IF @columns IS NULL
		SET @columns = '*';

	SET @sql = N'SELECT ' + @columns + ' From ' + QUOTENAME(@tableName)+ ' WHERE ISDELETED=0';

	EXEC sp_executesql @sql
END
