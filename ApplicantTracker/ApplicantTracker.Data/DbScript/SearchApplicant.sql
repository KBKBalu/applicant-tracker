USE `apptrack`;
DROP procedure IF EXISTS `SearchApplicant`;

DELIMITER $$
USE `apptrack`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `SearchApplicant`(
IN SearchText VARCHAR(100),
IN CanStatus VARCHAR(100),
IN Company VARCHAR(100),
IN Experience VARCHAR(100),
IN CreatedBy VARCHAR(100),
IN Salary VARCHAR(100),
IN Location VARCHAR(100),
IN Industry VARCHAR(100),
IN Days VARCHAR(100),
IN StartRecord INT,
IN PageLimit INT,
OUT TotalRecord INT)
BEGIN

DROP TEMPORARY TABLE  IF EXISTS SelectedCandidate;
CREATE TEMPORARY TABLE SelectedCandidate(candidateid VARCHAR(1));
IF SearchText IS NOT NULL THEN
	INSERT INTO SelectedCandidate (candidateid) SELECT CandidateId FROM candidate WHERE FirstName LIKE CONCAT('%', SearchText, '%') OR LastName LIKE CONCAT('%', SearchText, '%') OR MiddleName LIKE CONCAT('%', SearchText, '%') OR MobileNumber LIKE CONCAT('%', SearchText, '%') OR AlternateNumber LIKE CONCAT('%', SearchText, '%') OR PrimaryEmail LIKE CONCAT('%', SearchText, '%') OR SecondaryEmail LIKE CONCAT('%', SearchText, '%') OR CurrentEmployer LIKE CONCAT('%', SearchText, '%') OR CurrentDesignation LIKE CONCAT('%', SearchText, '%') OR CurrentLocation LIKE CONCAT('%', SearchText, '%') OR HomeTown LIKE CONCAT('%', SearchText, '%') OR Source LIKE CONCAT('%', SearchText, '%');
	   
	IF CanStatus IS NOT NULL THEN
		CALL SplitSearchParams(CanStatus,',');
		DELETE FROM SelectedCandidate WHERE candidateid NOT IN (SELECT CandidateId FROM candidate WHERE CanStatusId IN (SELECT NAME FROM SplitString));
    END IF;
   
    IF Company IS NOT NULL THEN
		CALL SplitSearchParams(Company,',');
		DELETE FROM SelectedCandidate WHERE candidateid NOT IN (SELECT CandidateId FROM candidate WHERE Company IN (SELECT NAME FROM SplitString));
	END IF;
    
	-- Experience
    IF Experience IS NOT NULL THEN
		CALL SplitSearchParams(Experience,',');
        DELETE FROM SelectedCandidate WHERE candidateid NOT IN (SELECT CandidateId FROM candidate Join SplitString Where ExperienceYears >= split_string(Name,'|',1) and ExperienceYears <= split_string(Name,'|',2));
    ENd IF;
    
    IF CreatedBy IS NOT NULL THEN
		CALL SplitSearchParams(CreatedBy,',');
		DELETE FROM SelectedCandidate WHERE candidateid NOT IN (SELECT CandidateId FROM candidate WHERE CreatedBy IN (SELECT NAME FROM SplitString));
	END IF;
    
    -- Salary
	IF Salary IS NOT NULL THEN
		CALL SplitSearchParams(Salary,',');
        DELETE FROM SelectedCandidate WHERE candidateid NOT IN (SELECT CandidateId FROM candidate Join SplitString Where Salary >= split_string(Name,'|',1) and Salary <= split_string(Name,'|',2));
    ENd IF;
    
    IF Location IS NOT NULL THEN
		CALL SplitSearchParams(Location,',');
		DELETE FROM SelectedCandidate WHERE candidateid NOT IN (SELECT CandidateId FROM candidate WHERE CurrentLocation IN (SELECT NAME FROM SplitString));
	END IF;
    
     -- Industry
    IF Industry IS NOT NULL THEN
		CALL SplitSearchParams(Industry,',');
        DELETE FROM SelectedCandidate WHERE CandidateId NOT IN (SELECT CandidateId FROM candidate WHERE IndustryId In (SELECT NAME FROM SplitString));
        DELETE FROM SelectedCandidate WHERE CandidateId NOT IN (SELECT candidateId FROM profileinfo WHERE IndustryId IN (SELECT NAME FROM SplitString));
    END IF;
    
    -- Days
    IF Days IS NOT NULL THEN
		DELETE FROM SelectedCandidate WHERE CandidateId NOT IN (SELECT CandidateId FROM candidate WHERE TO_DAYS(CreateDate) <= Days);
    END IF;
    
END IF;
 
IF SearchText IS NULL THEN
	
    IF CanStatus IS NOT NULL THEN
		CALL SplitSearchParams(CanStatus,',');
        INSERT INTO SelectedCandidate (candidateid) SELECT CandidateId FROM candidate WHERE CanStatusId IN (SELECT NAME FROM SplitString);
	END IF;
    
   IF Company IS NOT NULL THEN
		CALL SplitSearchParams(Company,',');
		INSERT INTO SelectedCandidate (candidateid) SELECT CandidateId FROM candidate WHERE Company IN (SELECT NAME FROM SplitString);
	END IF;
    
    -- Experience
    IF Experience IS NOT NULL THEN
		CALL SplitSearchParams(Experience,',');
        INSERT INTO SelectedCandidate(candidateid) SELECT CandidateId FROM candidate Join SplitString Where ExperienceYears >= split_string(Name,'|',1) and ExperienceYears <= split_string(Name,'|',2);
    ENd IF;
    
    IF CreatedBy IS NOT NULL THEN
		CALL SplitSearchParams(CreatedBy,',');
		INSERT INTO SelectedCandidate (candidateid) SELECT CandidateId FROM candidate WHERE CreatedBy IN (SELECT NAME FROM SplitString);
	END IF;
    
    -- Salary
     IF Salary IS NOT NULL THEN
		CALL SplitSearchParams(Salary,',');
        INSERT INTO SelectedCandidate(candidateid) SELECT CandidateId FROM candidate Join SplitString Where Salary >= split_string(Name,'|',1) and Salary <= split_string(Name,'|',2);
    ENd IF;
    
    IF Location IS NOT NULL THEN
		CALL SplitSearchParams(Location,',');
		INSERT INTO SelectedCandidate (candidateid) SELECT CandidateId FROM candidate WHERE CurrentLocation IN (SELECT NAME FROM SplitString);
	END IF;
    
    -- Industry
    IF Industry IS NOT NULL THEN
		CALL SplitSearchParams(Industry,',');
        INSERT INTO SelectedCandidate(candidateid) SELECT CandidateId FROM candidate WHERE IndustryId In (SELECT NAME FROM SplitString);
        INSERT INTO SelectedCandidate(candidateId) SELECT candidateId FROM profileinfo WHERE IndustryId IN (SELECT NAME FROM SplitString);
    END IF;
    
    -- Days
    IF Days IS NOT NULL THEN
		INSERT INTO SelectedCandidate(candidateId) SELECT CandidateId FROM candidate WHERE TO_DAYS(CreateDate) <= Days;
    END IF;
	
END IF;



SELECT `candidate`.`CandidateId`,
    `candidate`.`FirstName`,
    `candidate`.`LastName`,
    `candidate`.`MiddleName`,
    `candidate`.`MobileNumber`,
    `candidate`.`AlternateNumber`,
    `candidate`.`DOB`,
    `candidate`.`PrimaryEmail`,
    `candidate`.`SecondaryEmail`,
    `candidate`.`CanStatusId`,
    `candidate`.`CurrentEmployer`,
    `candidate`.`CurrentDesignation`,
    `candidate`.`SalaryInLacks`,
    `candidate`.`SalaryInThousands`,
    `candidate`.`ExperienceYears`,
    `candidate`.`ExperienceMonths`,
    `candidate`.`Skills`,
    `candidate`.`IndustryId`,
    `candidate`.`NoticePeriod`,
    `candidate`.`AssignedTo`,
    `candidate`.`Resume`,
    `candidate`.`CurrentLocation`,
    `candidate`.`HomeTown`,
    `candidate`.`Source`,
    `candidate`.`Qualification`,
    `candidate`.`Age`,
    `candidate`.`DateofSpoken`,
    `candidate`.`PreferredLocation`,
    `candidate`.`CreateDate`,
    `candidate`.`CreatedBy`,
    `candidate`.`ModifiedDate`,
    `candidate`.`ModifiedBy`FROM candidate where  candidate.CandidateId in (select candidateid from SelectedCandidate)  LIMIT StartRecord, PageLimit;
    
END$$

DELIMITER ;

