# MMTShop
dotnet Core Technical Test

this is the stored procedure

CREATE PROCEDURE spFilterProductByCategory
	
	@name varchar(50)
	
AS
	select p.Name, p.Description, p.Price
from Products p
inner join Categories c on p.CategoryId = c.Id
where  p.Name = @name;


CREATE PROCEDURE spAllProducts
 
AS
	SELECT * From Products


CREATE PROCEDURE spAllCategories
 
AS
	SELECT * From Categories

