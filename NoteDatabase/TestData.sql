/**
 *
 * Script to generate test-data
 *
 **/

INSERT INTO Employees
(Id, Username)
VALUES
(NEWID(), 'Piet'),
(NEWID(), 'Henk'),
(NEWID(), 'Sjaak'),
(NEWID(), 'Trudy'),
(NEWID(), 'Froukje')

DECLARE @EmployeeId uniqueidentifier

DECLARE MY_CURSOR CURSOR 
    LOCAL STATIC READ_ONLY FORWARD_ONLY
FOR 
    SELECT DISTINCT Id FROM Employees

OPEN MY_CURSOR
FETCH NEXT FROM MY_CURSOR INTO @EmployeeId
WHILE @@FETCH_STATUS = 0
BEGIN 
    
    INSERT INTO Notations
    (Id, "Name", Number, "Status", EmployeeId, "Message")
    VALUES
    (NEWID(), 'Piet', '0612345678', 0, @EmployeeId, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam'),
    (NEWID(), 'Piet', '0687654321', 0, @EmployeeId, 'quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat'),
    (NEWID(), 'Piet', '0612378456', 1, @EmployeeId, 'Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.'),
    (NEWID(), 'Piet', '0645613287', 1, @EmployeeId, 'Id diam maecenas ultricies mi. Purus semper eget duis at tellus at urna. '),
    (NEWID(), 'Piet', '0687652314', 2, @EmployeeId, 'Sorry, verkeerd nummer..'),
    (NEWID(), 'Piet', '0612345678', 0, @EmployeeId, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam'),
    (NEWID(), 'Piet', '0687654321', 0, @EmployeeId, 'quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat'),
    (NEWID(), 'Piet', '0612378456', 1, @EmployeeId, 'Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.'),
    (NEWID(), 'Piet', '0645613287', 1, @EmployeeId, 'Id diam maecenas ultricies mi. Purus semper eget duis at tellus at urna. '),
    (NEWID(), 'Henk', '0687652314', 2, @EmployeeId, 'Sorry, verkeerd nummer..'),
    (NEWID(), 'Henk', '0612345678', 0, @EmployeeId, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam'),
    (NEWID(), 'Henk', '0687654321', 0, @EmployeeId, 'quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat'),
    (NEWID(), 'Henk', '0612378456', 1, @EmployeeId, 'Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.'),
    (NEWID(), 'Henk', '0645613287', 1, @EmployeeId, 'Id diam maecenas ultricies mi. Purus semper eget duis at tellus at urna. '),
    (NEWID(), 'Henk', '0687652314', 2, @EmployeeId, 'Sorry, verkeerd nummer..'),
    (NEWID(), 'Henk', '0612345678', 0, @EmployeeId, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam'),
    (NEWID(), 'Sonja', '0687654321', 0, @EmployeeId, 'quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat'),
    (NEWID(), 'Sonja', '0612378456', 1, @EmployeeId, 'Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.'),
    (NEWID(), 'Sonja', '0645613287', 1, @EmployeeId, 'Id diam maecenas ultricies mi. Purus semper eget duis at tellus at urna. '),
    (NEWID(), 'Sonja', '0687652314', 2, @EmployeeId, 'Sorry, verkeerd nummer..')

    FETCH NEXT FROM MY_CURSOR INTO @EmployeeId
END
CLOSE MY_CURSOR
DEALLOCATE MY_CURSOR