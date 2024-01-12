/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
--tblCompanies
INSERT INTO tblCompanies (Id, Name, Address, Country)
VALUES 
('1373101683567012254019', 'IBM', 'Address1', 'USA'),
('6106760751397364528369', 'AMAZON', 'Address2', 'EGY'),
('3654610624116113512653', 'NOON', 'Address3', 'INDIA')

--tblEmployees
INSERT INTO tblEmployees (Id, Name , Age, Position, CompanyId, Salary)
VALUES 
('3321422541215004151991','Ahmed Ali', 40 , 'Developer', '1373101683567012254019', 7000.00),
('3235834627737190158583','Mohamed Ahmed', 50 , 'Administrator', '6106760751397364528369', 9000.00),
('7640152307478518236657','Ashraf Yassin', 30 , 'Designer', '1373101683567012254019', 10000.00)