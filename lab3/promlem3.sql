/*1*/
select *
from Orders
where ShippedDate > RequiredDate;

/*2*/
select distinct country
from Employees
where Country IS NOT NULL;
/*3*/
select EmployeeID
from Employees
where ReportsTo is null

/*4*/
select ProductName
from Products
where Discontinued =1
/*5*/
select ProductID
from Products
where Discontinued =0
/*6*/
select CustomerID
from Customers
where Region is null
/*7*/
select CustomerID,Phone
from Customers
where Country IN ('UK' , 'USA')
/*8*/
select CompanyName
from Suppliers
WHERE HomePage is not null;
/*9*/
select distinct shipCountry
from Orders
WHERE YEAR(OrderDate) = 1997;

/*10*/
SELECT DISTINCT I.CustomerID
FROM Customers I
LEFT JOIN Orders o ON I.CustomerID = o.CustomerID
WHERE o.ShippedDate IS NULL;
/*11*/
Select SupplierID,CompanyName,City
from Suppliers
/*12*/
SELECT EmployeeID, FirstName+LastName as employeename, Country, City
FROM Employees
WHERE City = 'London';
/*13*/
SELECT ProductName
FROM Products
WHERE Discontinued=0;
/*14*/
SELECT OrderID
FROM [Order Details]
WHERE Discount <= 0.1;
/*15*/
SELECT EmployeeID,FirstName+LastName as EmployeeName,HomePhone
FROM Employees
WHERE Region is NULL;









