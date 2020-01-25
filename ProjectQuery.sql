CREATE TABLE tblEmployee 
(
firstName varchar(15) NOT NULL,
lastName varchar(15) NULL,
id int IDENTITY(1,1) PRIMARY KEY,
emailId varchar(15) UNIQUE NOT NULL,
mobileNumber varchar(10) UNIQUE NOT NULL,
userName varchar(15) NOT NULL,
password varchar(15) UNIQUE NOT NULL ,
designation varchar(15) NOT NULL,
role varchar(5) NOT NULL
)

DROP TABLE tblEmployee 
SELECT * FROM tblEmployee 

CREATE TABLE tblAdmin
(
userName varchar(20),
password varchar(15) ,
role varchar(5) 
)
DROP TABLE tblAdmin

DROP PROCEDURE spInsertAdmin
SELECT * FROM tblAdmin
CREATE PROCEDURE spInsertAdmin
(
@userName varchar(20),
@password varchar(15) ,
@role varchar(5)
)
AS
BEGIN
INSERT INTO tblAdmin(userName,password,Role) VALUES(@userName,@password,@role)
END
--DECLARE @temp varchar(5)
INSERT INTO tblAdmin VALUES('Arun','arun@123','Admin')

DROP PROCEDURE spLogin

CREATE PROCEDURE spLogin
(
@userName varchar(20),
@password varchar(15) ,
@role varchar(5) OUT
)
AS

BEGIN
SELECT @role=role FROM tblAdmin WHERE userName=@userName AND password= @password
END