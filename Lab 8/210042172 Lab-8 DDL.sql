CREATE TABLE Branch (
    Branch_ID INT NOT NULL,
    Location VARCHAR2(50) NOT NULL,
    CONSTRAINT PK_Branch PRIMARY KEY(Branch_ID)
);

CREATE TABLE Employee (
    Employee_ID INT NOT NULL,
    Name VARCHAR2(50) NOT NULL,
    DOB DATE NOT NULL,
    Contact_No VARCHAR2(11) NOT NULL,
    Branch_ID INT NOT NULL,

    CONSTRAINT PK_Employee PRIMARY KEY(Employee_ID),
    CONSTRAINT FK_Branch FOREIGN KEY (Branch_ID) REFERENCES Branch(Branch_ID)
);

CREATE TABLE Item (
    Item_ID INT NOT NULL,
    Name VARCHAR2(50) NOT NULL,
    Description VARCHAR2(50) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    
    CONSTRAINT PK_Book PRIMARY KEY(ISBN),
    CONSTRAINT FK_Publisher FOREIGN KEY (Publisher_ID) REFERENCES Publisher(Publisher_ID)
);

CREATE TABLE Customer

CREATE TABLE Division

CREATE TABLE District

CREATE TABLE Department

CREATE TABLE Rent

CREATE TABLE Buy
