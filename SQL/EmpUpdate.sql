create procedure EmpUpdate
	@ID int,
	@FirstName varchar(25),
	@LastName varchar(35)
as 
begin
	update Employees
	set FirstName = @FirstName,
		LastName = @LastName
	where
		Id = @ID
end