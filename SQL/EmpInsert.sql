CREATE PROCEDURE [dbo].[EmpInsert]
	@FirstName varchar(25),
	@LastName varchar(35)
AS
	INSERT Employees (FirstName, LastName) values (@FirstName, @LastName)
RETURN 0
