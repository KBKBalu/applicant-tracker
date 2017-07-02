--User Table inserts scripts 

INSERT INTO `apptrack`.`candidatestatus` (`CanStatusId`, `Name`, `Description`, `IsActive`) 
VALUES 
(1,'Created', 'Created', true)
,(2, 'Yet to Schedule', 'Yet to Schedule', true)
, (3, 'Yet Get Feed back', 'Yet Get Feed back', true)
,(4, 'Short Listed', 'Short Listed', true)
,(5, 'Yet submit documents', 'Yet submit documents', true)
,(6, 'Onboard', 'Onboard', true)
,(7, 'Absconded', 'Absconded', true)
,(8, 'Joined', 'Joined', true)
,(9, 'Not Joined', 'Not Joined', true)


INSERT INTO `apptrack`.`profilestatus` (`ProfileStatusId`, `Name`, `Description`, `IsActive`) 
VALUES 
(1,'Created', 'Created', true)
,(2, 'Yet to Schedule', 'Yet to Schedule', true)
, (3, 'Yet Get Feed back', 'Yet Get Feed back', true)
,(4, 'Short Listed', 'Short Listed', true)
,(5, 'Yet submit documents', 'Yet submit documents', true)

/*Data for the table `userrole` */


INSERT INTO `apptrack`.`role` (`RoleId`, `Name`, `Description`, `IsActive`) 
VALUES 
(1, 'Associate', 'Associate', true)
,(2, 'Team Leader', 'Team Leader', true)
,(3, 'Manager', 'Manager', true)


/*Data for the table `industry` */
INSERT INTO `apptrack`.`industry` 
(`Name`, `Description`, `IsActive`) 
VALUES 
('IT', 'Technology', true)
,('Insurance', 'General Insurance', true)
,('Life', 'Life insurance', true)
,('Retail', 'Retail industry', true)
,('Banking', 'Bank and financial services', true)
,('FMCG', 'Consumer goods', true)
,('Other','Other',true)

/*Data for the table `company` */
INSERT INTO `apptrack`.`company` 
(`Name`, `Description`,`Image`, `IsActive`) 
VALUES 
('Aditya Birla Money', 'Technology','', true)
,('Aegon Life Insurance Amsure', 'General Insurance','', true)
,('Apollo Munich Health Insurance', 'Life insurance','', true)
,('Askme.com', '', '',true)
,('Aviva Life Insurance', 'Insurance','', true)
,('Bharati Axa Life Insurance ', 'Insurance', '',true)
,('Birla Sunlife Insurance', 'Insurance', '',true)
,('Cigna ttk', 'Cigna ttk', '',true)
,('DHFL Pramerica', '','', true)
,('ET Life ', 'ET Life ', '',true)
,('Exide Life Insurance', 'Insurance', '',true)
,('FG Life Insurance', 'Insurance ','', true)
,('Fincare', '', '',true)
,('HDFC', 'Banking', '',true)
,('HDFC Ergo', 'General Insurance','', true)
,('ICICI Lombard', 'Insurance ','', true)
,('Kotak Life Insurance', 'Insurance ','', true)
,('Max Life Insurance', 'Insurance ','', true)
,('Max Bhupa', '','', true)
,('Piramal', '','', true)
,('Reliance Life Insurance', 'Insurance','', true)
,('Religare Health', 'Health','', true)
,('Religare Securities', '','', true)
,('Sterling Holidays', '','', true)
,('Videocon Liberty', '','', true)

INSERT INTO `apptrack`.`user` 
(`FirstName`, `LastName`, `MiddleName`, `Password`, `Details`, `Address`, `MaritalStatus`, `Gender`, `Mobile`, `Email`,`Branch`, `IsActive`)
 VALUES 
 ('Admin', 'Admin User', '', '12345', '', '', 'Single', 'Male', '1234567892', 'admin@gmail.com','Punjagutta-1', 1) 
,('Gopu', 'Chandrakala', '', '12345', '', '', 'Single', 'FeMale', '1234567892', 'admin1@gmail.com','Punjagutta-1', 1)
,('Venkatlakshmi', 'M', '', '12345', '', '', 'Single', 'FeMale', '1234567892', 'admin2@gmail.com','Punjagutta-1', 1)
,('Jyothirmayi', 'P', '', '12345', '', '', 'Married', 'FeMale', '1234567892', 'admin3@gmail.com','Punjagutta-1', 1)
,('Prameela Rani', '', 'test2', '12345', '', '', 'Single', 'FeMale', '1234567892', 'admin4@gmail.com','Punjagutta-1', 1)
,('Sravanthi', 'Mamidala', '', '12345', '', '', 'Single', 'FeMale', '1234567892', 'admin5@gmail.com','Punjagutta-1', 1)
,('Mangali', 'Swetha', '', '12345', '', '', 'Single', 'MFeale', '1234567892', 'admin6@gmail.com','Punjagutta-1',1)
,('Gayathri', 'Chatla', '', '12345', '', '', 'Single', 'FeMale', '1234567892', 'admin7@gmail.com','Punjagutta-1',1)
,('Anjali', 'A', '', '12345', '', '', 'Single', 'FeMale', '1234567892', 'admin8@gmail.com','Punjagutta-1',1)
,('Raji', 'Lagadapati', '', '12345', '', '', 'Single', 'FeMale', '1234567892', 'admin9@gmail.com','Punjagutta-1',1)
,('Shravya', 'Chinthala', '', '12345', '', '', 'Single', 'FeMale', '1234567892', 'admin10@gmail.com','Punjagutta-1',1)
,('Durga', 'Manogna', '', '12345', '', '', 'Single', 'FeMale', '1234567892', 'admin11@gmail.com','Punjagutta-1',1)
,('Sireesha', 'A', '', '12345', '', '', 'Single', 'FeMale', '1234567892', 'admin12@gmail.com','Punjagutta-1',1)
,('Sireesha', 'M', '', '12345', '', '', 'Single', 'FeMale', '1234567892', 'admin13@gmail.com','Punjagutta-1',1)
,('Divya', '', '', '12345', '', '', 'Single', 'FeMale', '1234567892', 'admin14@gmail.com','Punjagutta-1',1)
,('Vijay Kumar', 'A', '', '12345', '', '', 'Single', 'Male', '1234567892', 'admin15@gmail.com','Punjagutta-1',1)
,('Bhandari', 'Parul', '', '12345', '', '', 'Single', 'Male', '1234567892', 'admin16@gmail.com','Punjagutta-1',1)

,('Dudekula', 'Kullayappa', '', '12345', '', '', 'Single', 'FeMale', '1234567892', 'admin17@gmail.com','Punjagutta-2',1)
,('Gowthami', 'P', '', '12345', '', '', 'Single', 'FeMale', '1234567892', 'admin18@gmail.com','Punjagutta-2',1)
,('Sowjanya', 'S', '', '12345', '', '', 'Single', 'FeMale', '1234567892', 'admin19@gmail.com','Punjagutta-2',1)
,('Malleswari', 'S', '', '12345', '', '', 'Single', 'FeMale', '1234567892', 'admin20@gmail.com','Punjagutta-2',1)
,('Anita', 'Jena', '', '12345', '', '', 'Single', 'FeMale', '1234567892', 'admin21@gmail.com','Punjagutta-2',1)
,('Sruthi', 'Jena', '', '12345', '', '', 'Single', 'FeMale', '1234567892', 'admin22@gmail.com','Punjagutta-2',1)
,('Sashi', 'B', '', '12345', '', '', 'Single', 'Male', '1234567892', 'admin23@gmail.com','Punjagutta-2',1)
,('Sonideep', 'Parul', '', '12345', '', '', 'Single', 'Male', '1234567892', 'admin24@gmail.com','Punjagutta-2',1)

,('Pavan Varma', 'Alluri', '', '12345', '', '', 'Single', 'Male', '1234567892', 'admin25@gmail.com','Punjagutta-3',1)
,('Dilip Varma', 'U', '', '12345', '', '', 'Single', 'Male', '1234567892', 'admin26@gmail.com','Punjagutta-3',1)
,('Aparna', 'M', '', '12345', '', '', 'Single', 'FeMale', '1234567892', 'admin27@gmail.com','Punjagutta-3',1)
,('Jyotsna', '', '', '12345', '', '', 'Single', 'FeMale', '1234567892', 'admin28@gmail.com','Punjagutta-3',1)
,('Achala', '', '', '12345', '', '', 'Single', 'FeMale', '1234567892', 'admin29@gmail.com','Punjagutta-3',1)




INSERT INTO `apptrack`.`userrole` (`UserRoleId`,`RoleId`, `UserId`) 
VALUES (1,1,1)
,(2,2,2)
,(3,2,3)
,(4,2,4)
,(5,1,5)
,(6,1,6)
,(7,1,7)
,(8,1,8)
,(9,1,9)
,(10,1,10)
,(11,1,11)
,(12,1,12)
,(13,2,13)
,(14,1,14)
,(15,1,15)
,(16,2,16)
,(17,1,17)
,(18,2,18)
,(19,2,19)
,(20,2,20)
,(21,2,21)
,(22,1,22)
,(23,1,23)
,(24,2,24)
,(25,1,25)
,(26,3,26)
,(27,3,27)
,(28,1,28)
,(29,1,29)
,(30,1,30)

set global optimizer_switch='derived_merge=off';

