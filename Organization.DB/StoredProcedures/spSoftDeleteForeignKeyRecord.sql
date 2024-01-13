CREATE PROCEDURE [dbo].[spSoftDeleteForeignKeyRecord]
	@tableName VARCHAR(50),
	@foreignKeyColumnName VARCHAR(50),
	@foreignKeyColumnValue VARCHAR(22)
AS
BEGIN
	DECLARE @sql NVARCHAR(MAX)

	SET @sql = N'UPDATE ' + QUOTENAME(@tableName) + ' SET IsDeleted=1 WHERE ' + @foreignKeyColumnName + '@foreignKeyColumnValue'

	EXEC sp_executesql @sql,N'@foreignKeyColumnValue VARCHAR(22)', @foreignKeyColumnValue
END
