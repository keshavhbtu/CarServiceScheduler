CREATE TABLE [Operator] (
    [Id]            INT           NOT NULL IDENTITY PRIMARY KEY,
    [Name]          VARCHAR(50)   Not Null,
    [Email]         VARCHAR(50)   Not Null,
    [Phone]         VARCHAR(20)   Not Null
    );


CREATE TABLE [Customer] (
    [Id]            INT           NOT NULL IDENTITY PRIMARY KEY,
    [Name]          VARCHAR(50)   Not Null,
    [Email]         VARCHAR(50)   Not Null,
    [Phone]         VARCHAR(20)   Not Null
    );


CREATE TABLE [Appointment] (
    [Id]                INT           NOT NULL IDENTITY PRIMARY KEY,
    [OperatorId]        INT   Not Null,
    [CustomerId]        INT      NOT NULL,
    [AppointmentDate]   DATE      NOT NULL,
    [TimeSlot]              INT           NOT NULL,
    CONSTRAINT [FK_Appointment_OperatorId_Operator] FOREIGN KEY ([OperatorId]) REFERENCES [Operator] (Id),
    CONSTRAINT [FK_Appointment_CustomerId_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [Customer] (Id),
    );
--https://stackoverflow.com/questions/15800250/add-unique-constraint-to-combination-of-two-columns
    CREATE UNIQUE INDEX UQ_Appointment
  ON [Appointment](OperatorId, AppointmentDate,TimeSlot);


--data backfill
INSERT INTO [Operator] 
VALUES ('Sachin', 'Sachin@car24service.com', '9898789876');
INSERT INTO [Operator] 
VALUES ('Ankit', 'Ankit@car24service.com', '9898789878');
INSERT INTO [Customer] 
VALUES ('Bhavik', 'Bhavik@gmail.com', '9898789898');
