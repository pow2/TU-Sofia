CREATE PROCEDURE dbo.AddNewZast
(
/*@ID int OUTPUT,*/
@fName nvarchar(20),
@lName nvarchar(20),
@carNum nvarchar(20),
@carBrand nvarchar(20),
@carModel nvarchar(20),
@carType smallint,
@carAddinfo nvarchar(10),
@expireDateDay smallint,
@expireDateMonth smallint,
@expireDateYear int,
@eemployee int,
@price nvarchar(20),
@city smallint
)
AS
INSERT INTO [ZAST] (FName, LName, CarNum, CarBrand, CarModel, CarType, CarAddinfo, ExpireDateDay, ExpireDateMonth, ExpireDateYear, employee, Price, City)
VALUES (@fName , @lName, @carNum, @carBrand, @carModel,
@carType, @carAddinfo, @expireDateDay, @expireDateMonth, @expireDateYear, @eemployee, @price, @city)
