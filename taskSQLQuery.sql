CREATE DATABASE task

USE task

CREATE TABLE RTODetails
(
employeeID INT PRIMARY KEY,
complianceType VARCHAR(15),
dateRange VARCHAR(15),
dateSelected DATE,
dateSelectedTill DATE
);

SELECT * FROM RTODetails

Insert INTO RTODetails VALUES (20231, 'WFH', 'Date', '2023-04-15','2023-04-15')
