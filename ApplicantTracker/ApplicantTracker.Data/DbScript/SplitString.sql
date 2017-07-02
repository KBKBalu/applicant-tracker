
DELIMITER $$

USE `apptrack`$$

DROP PROCEDURE IF EXISTS `SplitSearchParams`$$
CREATE PROCEDURE SplitSearchParams( IN inputString VARCHAR(256), IN splitChar VARCHAR(1))
BEGIN

DECLARE X INTEGER;
    
    DECLARE Y INTEGER;
    
    DROP TEMPORARY TABLE IF EXISTS `SplitString`;
    
    CREATE TEMPORARY TABLE IF NOT EXISTS `SplitString` (`ID` INT(11) NOT NULL AUTO_INCREMENT,`NAME` VARCHAR(256) NOT NULL,PRIMARY KEY (`ID`)) AUTO_INCREMENT=1 ;
    DELETE  FROM SplitString;
 
 SET Y = 1;
 SET X = 0;
    
    
    IF NOT inputString IS NULL 
    THEN 
           SELECT LENGTH(inputString) - LENGTH(REPLACE(inputString, splitChar, '')) INTO @noOfCommas; 
      
           IF  @noOfCommas = 0 
          THEN 
                 INSERT INTO SplitString(NAME) VALUES(inputString); 
          ELSE 
                SET X = @noOfCommas + 1; 
                WHILE Y  <=  X DO 
                   SELECT split_string(inputString, splitChar, Y) INTO @engName; 
                   INSERT INTO SplitString(NAME) VALUES(@engName); 
                   SET  Y = Y + 1; 
                END WHILE; 
        END IF; 
    END IF; 

END$$

DELIMITER ;