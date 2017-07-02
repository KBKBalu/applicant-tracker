--/*
--SQLyog Ultimate v11.11 (64 bit)
--MySQL - 5.6.17 : Database - apptrack
--*********************************************************************
--*/


--/*!40101 SET NAMES utf8 */;

--/*!40101 SET SQL_MODE=''*/;

--/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
--/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
--/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
--/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
--CREATE DATABASE /*!32312 IF NOT EXISTS*/`apptrack` /*!40100 DEFAULT CHARACTER SET latin1 */;

--USE `apptrack`;

--/*Table structure for table `candidate` */

--DROP TABLE IF EXISTS `candidate`;

--CREATE TABLE `candidate` (
--  `CandidateId` int(11) NOT NULL AUTO_INCREMENT,
--  `FirstName` varchar(100) DEFAULT NULL,
--  `LastName` varchar(100) DEFAULT NULL,
--  `MiddleName` varchar(100) DEFAULT NULL,
--  `MobileNumber` varchar(20) DEFAULT NULL,
--  `AlternateNumber` varchar(20) DEFAULT NULL,
--  `DOB` date DEFAULT NULL,
--  `PrimaryEmail` varchar(100) NOT NULL,
--  `SecondaryEmail` varchar(100) DEFAULT NULL,
--  `CanStatusId` int(11) NOT NULL,
--  `CurrentEmployer` varchar(200) DEFAULT NULL,
--  `CurrentDesignation` varchar(100) DEFAULT NULL,
--  `SalaryInLacks` int(11) DEFAULT NULL,
--  `SalaryInThousands` int(11) NOT NULL,
--  `ExperienceYears` int(11) DEFAULT NULL,
--  `ExperienceMonths` int(11) DEFAULT NULL,
--  `Skills` varchar(256) NOT NULL,
--  `IndustryId` int(11) NOT NULL,
--  `NoticePeriod` int(11) NOT NULL,
--  `AssignedTo` int(11) NOT NULL,
--  `Resume` blob,
--  `CurrentLocation` varchar(100) DEFAULT NULL,
--  `HomeTown` varchar(100) DEFAULT NULL,
--  `Source` varchar(100) DEFAULT NULL,
--  `Qualification` varchar(100) DEFAULT NULL,
--  `Age` int(11) NOT NULL,
--  `DateofSpoken` datetime DEFAULT NULL,
--  `PreferredLocation` varchar(1000) DEFAULT NULL,
--  `CreateDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
--  `CreatedBy` int(11) DEFAULT NULL,
--  `ModifiedDate` datetime DEFAULT NULL,
--  `ModifiedBy` int(11) DEFAULT NULL,
--  PRIMARY KEY (`CandidateId`),
--  KEY `FK_Candidate_CanStatus` (`CanStatusId`),
--  KEY `FK_Candidate_Industry` (`IndustryId`),
--  KEY `FK_Candidate_CreatedBy` (`CreatedBy`),
--  KEY `FK_Candidate_AssignedTo` (`AssignedTo`),
--  KEY `FK_Candidate_ModifiedBy` (`ModifiedBy`),
--  CONSTRAINT `FK_Candidate_AssignedTo` FOREIGN KEY (`AssignedTo`) REFERENCES `user` (`UserId`),
--  CONSTRAINT `FK_Candidate_CanStatus` FOREIGN KEY (`CanStatusId`) REFERENCES `candidatestatus` (`CanStatusId`),
--  CONSTRAINT `FK_Candidate_CreatedBy` FOREIGN KEY (`CreatedBy`) REFERENCES `user` (`UserId`),
--  CONSTRAINT `FK_Candidate_Industry` FOREIGN KEY (`IndustryId`) REFERENCES `industry` (`IndustryId`),
--  CONSTRAINT `FK_Candidate_ModifiedBy` FOREIGN KEY (`ModifiedBy`) REFERENCES `user` (`UserId`)
--) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;

--/*Table structure for table `candidatestatus` */

--DROP TABLE IF EXISTS `candidatestatus`;

--CREATE TABLE `candidatestatus` (
--  `CanStatusId` int(11) NOT NULL AUTO_INCREMENT,
--  `Name` varchar(100) DEFAULT NULL,
--  `Description` varchar(1000) DEFAULT NULL,
--  `IsActive` tinyint(1) DEFAULT '1',
--  `CreateDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
--  `CreatedBy` int(11) DEFAULT NULL,
--  `ModifiedDate` datetime DEFAULT NULL,
--  `ModifiedBy` int(11) DEFAULT NULL,
--  PRIMARY KEY (`CanStatusId`)
--) ENGINE=InnoDB  DEFAULT CHARSET=latin1;

--/*Table structure for table `company` */

--DROP TABLE IF EXISTS `company`;

--CREATE TABLE `company` (
--  `CompanyId` int(11) NOT NULL AUTO_INCREMENT,
--  `Name` varchar(100) DEFAULT NULL,
--  `Description` varchar(1000) DEFAULT NULL,
--  `Image` varchar(1000) DEFAULT NULL,
--  `IsActive` tinyint(1) DEFAULT '1',
--  `CreateDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
--  `CreatedBy` int(11) DEFAULT NULL,
--  `ModifiedDate` datetime DEFAULT NULL,
--  `ModifiedBy` int(11) DEFAULT NULL,
--  PRIMARY KEY (`CompanyId`)
--) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;

--/*Table structure for table `industry` */

--DROP TABLE IF EXISTS `industry`;

--CREATE TABLE `industry` (
--  `IndustryId` int(11) NOT NULL AUTO_INCREMENT,
--  `Name` varchar(100) DEFAULT NULL,
--  `Description` varchar(1000) DEFAULT NULL,
--  `IsActive` tinyint(1) DEFAULT '1',
--  `CreateDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
--  `CreatedBy` int(11) DEFAULT NULL,
--  `ModifiedDate` datetime DEFAULT NULL,
--  `ModifiedBy` int(11) DEFAULT NULL,
--  PRIMARY KEY (`IndustryId`)
--) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;


--/*Table structure for table `ProfileStatus` */

--DROP TABLE IF EXISTS `company`;

--CREATE TABLE `profilestatus` (
--  `ProfileStatusId` int(11) NOT NULL AUTO_INCREMENT,
--  `Name` varchar(100) DEFAULT NULL,
--  `Description` varchar(1000) DEFAULT NULL,
--  `IsActive` tinyint(1) DEFAULT '1',
--  `CreateDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
--  `CreatedBy` int(11) DEFAULT NULL,
--  `ModifiedDate` datetime DEFAULT NULL,
--  `ModifiedBy` int(11) DEFAULT NULL,
--  PRIMARY KEY (`ProfileStatusId`)
--) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;

--/*Table structure for table `profileinfo` */

--DROP TABLE IF EXISTS `profileinfo`;

--CREATE TABLE `profileinfo` (
--  `ProfileId` int(11) NOT NULL AUTO_INCREMENT,
--  `CandidateId` int(11) NOT NULL,
--  `CompanyId` int(11) DEFAULT NULL,
--  `IndustryId` int(11) NOT NULL,
--  `CompanyDetails` varchar(1000) DEFAULT NULL,
--  `DateOfInterview` date DEFAULT NULL,
--  `CurrentStatus` varchar(100) DEFAULT NULL,
--  `HRCopy` varchar(100) DEFAULT NULL,
--  `AppliedPositionFor` varchar(100) DEFAULT NULL,
--  `Interviewer` varchar(100) DEFAULT NULL,
--  `InterviewerMobile` varchar(20) DEFAULT NULL,
--  `CompanyContact` varchar(20) DEFAULT NULL,
--  `ReferenceType` varchar(100) DEFAULT NULL,
--  `NameOfRecruiter` varchar(100) DEFAULT NULL,
--  `ContactOfRecruiter` varchar(20) DEFAULT NULL,
--  `TeamLeadName` varchar(100) DEFAULT NULL,
--  `CreateDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
--  `CreatedBy` int(11) DEFAULT NULL,
--  `ModifiedDate` datetime DEFAULT NULL,
--  `ModifiedBy` int(11) DEFAULT NULL,
--  PRIMARY KEY (`ProfileId`),
--  KEY `FK_profileinfo` (`CandidateId`),
--  KEY `FK_CompanyId` (`CompanyId`),
--  KEY `FK_Industry` (`IndustryId`),
--  CONSTRAINT `FK_CompanyId` FOREIGN KEY (`CompanyId`) REFERENCES `company` (`CompanyId`),
--  CONSTRAINT `FK_Industry` FOREIGN KEY (`IndustryId`) REFERENCES `industry` (`IndustryId`),
--  CONSTRAINT `FK_profileinfo` FOREIGN KEY (`CandidateId`) REFERENCES `candidate` (`CandidateId`)
--) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--/*Table structure for table `role` */

--DROP TABLE IF EXISTS `role`;

--CREATE TABLE `role` (
--  `RoleId` int(11) NOT NULL AUTO_INCREMENT,
--  `Name` varchar(100) DEFAULT NULL,
--  `Description` varchar(1000) DEFAULT NULL,
--  `IsActive` tinyint(1) DEFAULT '1',
--  `CreateDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
--  `CreatedBy` int(11) DEFAULT NULL,
--  `ModifiedDate` datetime DEFAULT NULL,
--  `ModifiedBy` int(11) DEFAULT NULL,
--  PRIMARY KEY (`RoleId`)
--) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;

--/*Table structure for table `user` */

--DROP TABLE IF EXISTS `user`;

--CREATE TABLE `user` (
--  `UserId` int(11) NOT NULL AUTO_INCREMENT,
--  `FirstName` varchar(100) DEFAULT NULL,
--  `LastName` varchar(100) DEFAULT NULL,
--  `MiddleName` varchar(100) DEFAULT NULL,
--  `Password` varchar(50) DEFAULT NULL,
--  `Details` varchar(1000) DEFAULT NULL,
--  `DOB` date DEFAULT NULL,
--  `Address` char(50) DEFAULT NULL,
--  `MaritalStatus` char(10) NOT NULL,
--  `Gender` char(35) NOT NULL,
--  `Mobile` char(15) NOT NULL,
--  `Email` char(20) NOT NULL,
--  `Branch` char(30) DEFAULT NULL,
--  `Image` varchar(1000) DEFAULT NULL,
--  `IsActive` tinyint(1) DEFAULT NULL,
--  `CreateDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
--  `CreatedBy` int(11) DEFAULT NULL,
--  `ModifiedDate` datetime DEFAULT NULL,
--  `ModifiedBy` int(11) DEFAULT NULL,
--  PRIMARY KEY (`UserId`)
--) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;

--/*Table structure for table `userrole` */

--DROP TABLE IF EXISTS `userrole`;

--CREATE TABLE `userrole` (
--  `UserRoleId` int(11) NOT NULL AUTO_INCREMENT,
--  `RoleId` int(11) NOT NULL,
--  `UserId` int(11) NOT NULL,
--  `CreateDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
--  `CreatedBy` int(11) DEFAULT NULL,
--  `ModifiedDate` datetime DEFAULT NULL,
--  `ModifiedBy` int(11) DEFAULT NULL,
--  PRIMARY KEY (`UserRoleId`),
--  KEY `FK_userrole` (`UserId`),
--  KEY `FK_userrole_Role` (`RoleId`),
--  CONSTRAINT `FK_role_userrole` FOREIGN KEY (`RoleId`) REFERENCES `role` (`RoleId`),
--  CONSTRAINT `FK_user_userrole` FOREIGN KEY (`UserId`) REFERENCES `user` (`UserId`)
--) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--/* Function  structure for function  `split_string` */

--/*!50003 DROP FUNCTION IF EXISTS `split_string` */;
--DELIMITER $$

--/*!50003 CREATE DEFINER=`root`@`localhost` FUNCTION `split_string`(
--stringToSplit VARCHAR(256), SIGN VARCHAR(12), POSITION INT) RETURNS varchar(256) CHARSET latin1
--BEGIN
--        RETURN REPLACE(SUBSTRING(SUBSTRING_INDEX(stringToSplit, SIGN, POSITION),LENGTH(SUBSTRING_INDEX(stringToSplit, SIGN, POSITION -1)) + 1), SIGN, '');
	
--END */$$
--DELIMITER ;

--/* Procedure structure for procedure `SearchApplicant` */

--/*!50003 DROP PROCEDURE IF EXISTS  `SearchApplicant` */;

--DELIMITER $$

--/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `SearchApplicant`(
--IN SearchText VARCHAR(100),
--IN CanStatus VARCHAR(100),
--IN Role VARCHAR(100),
--IN Company VARCHAR(100),
--IN Experience VARCHAR(100),
--IN CreatedBy VARCHAR(100),
--IN Salary VARCHAR(100),
--IN Location VARCHAR(100),
--IN Industry VARCHAR(100),
--IN Days VARCHAR(100))
--BEGIN
--DROP TEMPORARY TABLE  IF EXISTS SelectedCandidate;
--CREATE TEMPORARY TABLE SelectedCandidate(candidateid VARCHAR(1));
--IF SearchText IS NOT NULL THEN
--	INSERT INTO SelectedCandidate (candidateid) SELECT CandidateId FROM candidate WHERE FirstName LIKE CONCAT('%', SearchText, '%') OR LastName LIKE CONCAT('%', SearchText, '%') OR MiddleName LIKE CONCAT('%', SearchText, '%') OR MobileNumber LIKE CONCAT('%', SearchText, '%') OR AlternateNumber LIKE CONCAT('%', SearchText, '%') OR PrimaryEmail LIKE CONCAT('%', SearchText, '%') OR SecondaryEmail LIKE CONCAT('%', SearchText, '%') OR CurrentEmployer LIKE CONCAT('%', SearchText, '%') OR CurrentDesignation LIKE CONCAT('%', SearchText, '%') OR CurrentLocation LIKE CONCAT('%', SearchText, '%') OR HomeTown LIKE CONCAT('%', SearchText, '%') OR Source LIKE CONCAT('%', SearchText, '%');
	
--	IF CanStatus IS NOT NULL THEN
--		CALL SplitSearchParams(CanStatus,',');
--		DELETE FROM SelectedCandidate WHERE candidateid NOT IN (SELECT CandidateId FROM candidate WHERE CanStatusId IN (SELECT NAME FROM SplitString));
--    END IF;
    
--    IF Role IS NOT NULL THEN
--		CALL SplitSearchParams(Role,',');
--		DELETE FROM SelectedCandidate WHERE candidateid NOT IN (SELECT CandidateId FROM candidate WHERE Role IN (SELECT NAME FROM SplitString));
--	END IF;
    
--    IF Company IS NOT NULL THEN
--		CALL SplitSearchParams(Company,',');
--		DELETE FROM SelectedCandidate WHERE candidateid NOT IN (SELECT CandidateId FROM candidate WHERE Company IN (SELECT NAME FROM SplitString));
--	END IF;
    
--	-- Experience
--    IF CreatedBy IS NOT NULL THEN
--		CALL SplitSearchParams(CreatedBy,',');
--		DELETE FROM SelectedCandidate WHERE candidateid NOT IN (SELECT CandidateId FROM candidate WHERE CreatedBy IN (SELECT NAME FROM SplitString));
--	END IF;
    
--    -- Salary
--    IF Location IS NOT NULL THEN
--		CALL SplitSearchParams(Location,',');
--		DELETE FROM SelectedCandidate WHERE candidateid NOT IN (SELECT CandidateId FROM candidate WHERE CurrentLocation IN (SELECT NAME FROM SplitString));
--	END IF;
    
--    -- Industry
    
--    -- Days
    
--END IF;
 
--IF SearchText IS NULL THEN
	
--    IF CanStatus IS NOT NULL THEN
--		CALL SplitSearchParams(CanStatus,',');
--        INSERT INTO SelectedCandidate (candidateid) SELECT CandidateId FROM candidate WHERE CanStatusId IN (SELECT NAME FROM SplitString);
--	END IF;
    
--    IF Role IS NOT NULL THEN
--		CALL SplitSearchParams(Role,',');
--		INSERT INTO SelectedCandidate (candidateid) SELECT CandidateId FROM candidate WHERE Role IN (SELECT NAME FROM SplitString);
--	END IF;
    
--    IF Company IS NOT NULL THEN
--		CALL SplitSearchParams(Company,',');
--		INSERT INTO SelectedCandidate (candidateid) SELECT CandidateId FROM candidate WHERE Company IN (SELECT NAME FROM SplitString);
--	END IF;
    
--    -- Experience
--    IF CreatedBy IS NOT NULL THEN
--		CALL SplitSearchParams(CreatedBy,',');
--		INSERT INTO SelectedCandidate (candidateid) SELECT CandidateId FROM candidate WHERE CreatedBy IN (SELECT NAME FROM SplitString);
--	END IF;
    
--    -- Salary
--    IF Location IS NOT NULL THEN
--		CALL SplitSearchParams(Location,',');
--		INSERT INTO SelectedCandidate (candidateid) SELECT CandidateId FROM candidate WHERE CurrentLocation IN (SELECT NAME FROM SplitString);
--	END IF;
    
--    -- Industry
    
--    -- Days
	
--END IF;
--SELECT * FROM candidate WHERE CandidateId IN (SELECT candidateid FROM SelectedCandidate);
--END */$$
--DELIMITER ;

--/* Procedure structure for procedure `SplitSearchParams` */

--/*!50003 DROP PROCEDURE IF EXISTS  `SplitSearchParams` */;

--DELIMITER $$

--/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `SplitSearchParams`( IN inputString VARCHAR(256), IN splitChar VARCHAR(1))
--BEGIN
--DECLARE X INTEGER;
    
--    DECLARE Y INTEGER;
    
--    DROP TEMPORARY TABLE IF EXISTS `SplitString`;
    
--    CREATE TEMPORARY TABLE IF NOT EXISTS `SplitString` (`ID` INT(11) NOT NULL AUTO_INCREMENT,`NAME` VARCHAR(256) NOT NULL,PRIMARY KEY (`ID`)) AUTO_INCREMENT=1 ;
--    DELETE  FROM SplitString;
 
-- SET Y = 1;
-- SET X = 0;
    
    
--    IF NOT inputString IS NULL 
--    THEN 
--           SELECT LENGTH(inputString) - LENGTH(REPLACE(inputString, splitChar, '')) INTO @noOfCommas; 
      
--           IF  @noOfCommas = 0 
--          THEN 
--                 INSERT INTO SplitString(NAME) VALUES(inputString); 
--          ELSE 
--                SET X = @noOfCommas + 1; 
--                WHILE Y  <=  X DO 
--                   SELECT split_string(inputString, splitChar, Y) INTO @engName; 
--                   INSERT INTO SplitString(NAME) VALUES(@engName); 
--                   SET  Y = Y + 1; 
--                END WHILE; 
--        END IF; 
--    END IF; 
--END */$$
--DELIMITER ;

--/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
--/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
--/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
--/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
