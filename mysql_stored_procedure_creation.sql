-- STORED PROCEDURES
-- UPDATE Sales


DROP PROCEDURE saveTransaction;

DELIMITER $$
CREATE PROCEDURE invalidLogin(IN uname varchar(20), OUT logAttempt INT(1), OUT userIsEnabled TINYINT)
    BEGIN
		UPDATE tbllogin SET log_attempts = log_attempts + 1 WHERE tbllogin.username = uname;
        
        IF (SELECT log_attempts FROM tbllogin WHERE tbllogin.username = uname) > 2
        THEN UPDATE tbllogin SET isEnabled = 0 WHERE tbllogin.username = uname;
        SET userIsEnabled = 0;
        ELSE SET userIsEnabled = 1;
        END IF;
        SET logAttempt = (select log_attempts from tbllogin WHERE tbllogin.username = uname);
    END$$
DELIMITER ;


SELECT * FROM tblusers;

-- ADD Users

DROP PROCEDURE addUser;

DELIMITER $$
CREATE PROCEDURE addUser(IN uname varchar(20), IN pword varchar(20), IN fname varchar(50), IN lname varchar(50), IN pos varchar(20), IN ans1 varchar(20), IN ans2 varchar(20), IN enabled TINYINT)
    BEGIN
		DECLARE msg varchar(120);
		IF
			((SELECT COUNT(*) as userCount FROM tblusers where username = uname) = 0) AND (pos = 'Developer' OR pos = 'Admin' or pos = 'Cashier')
        THEN
			INSERT INTO tblUsers(username,password,firstname,lastname,position,answer1,answer2,tempopw,isEnabled)
						values	(uname ,MD5(pword), fname, lname, pos, ans1, ans2, pword, enabled);
			SET msg = 'Account has been created!';
		ELSE
			SET msg = 'Username already exists or Position is Invalid!';
        END IF;
    END$$
DELIMITER ;


-- Update Users

DROP PROCEDURE updateUser;

DELIMITER $$
CREATE PROCEDURE updateUser(IN uname varchar(20), IN pword varchar(20), IN fname varchar(50), IN lname varchar(50), IN pos varchar(20), IN ans1 varchar(20), IN ans2 varchar(20), IN enabled TINYINT, IN selectedid INT(10))
    BEGIN
    DECLARE counts INT DEFAULT 0; 
    DECLARE msg varchar(120);
        IF (pos = 'Admin' OR pos = 'Cashier')
        THEN
			UPDATE tblUsers SET
				username = uname,
                password = MD5(pword),
                tempopw = pword,
                firstname = fname,
                lastname = lname,
                position = pos,
                isEnabled = enabled,
                log_attempts = 0,
                answer1 = ans1,
                answer2 = ans2
                WHERE loginid = selectedid;
                
			SET msg = "Account successfully updated!";

        ELSE
			SET msg = "Details are invalid.";
        END IF;
    END$$
DELIMITER ;


-- Update User Without Password

DROP PROCEDURE updateUserNoPassword;

DELIMITER $$
CREATE PROCEDURE updateUserNoPassword(IN uname varchar(20), IN fname varchar(50), IN lname varchar(50), IN pos varchar(20), IN ans1 varchar(20), IN ans2 varchar(20), IN enabled TINYINT, IN selectedid INT(10))
    BEGIN
    DECLARE counts INT DEFAULT 0; 
    DECLARE msg varchar(120);
        IF (pos = 'Admin' OR pos = 'Cashier')
        THEN
			UPDATE tblUsers SET
				username = uname,
                firstname = fname,
                lastname = lname,
                position = pos,
                isEnabled = enabled,
                log_attempts = 0,
                answer1 = ans1,
                answer2 = ans2
                WHERE loginid = selectedid;
                
			SET msg = "Account successfully updated!";

        ELSE
			SET msg = "Details are invalid.";
        END IF;
    END$$
DELIMITER ;


-- Invalid Login

DROP PROCEDURE invalidLogin;

DELIMITER $$
CREATE PROCEDURE invalidLogin(IN uname varchar(20))
    BEGIN
		UPDATE tblUsers SET log_attempts = log_attempts + 1 WHERE tblUsers.username = uname;
        
        IF 2 > 2
        THEN UPDATE tblUsers SET isEnabled = 0 WHERE username = uname;
        END IF;
    END$$
DELIMITER ;


-- Activate User
DROP PROCEDURE activateUser;

DELIMITER $$
CREATE PROCEDURE activateUser(IN uname varchar(20))
    BEGIN
		UPDATE tblUsers
        SET isEnabled = 1, log_attempts = 0
		WHERE username = uname;
    END$$
DELIMITER ;


-- SAVE transaction

DROP PROCEDURE IF EXISTS saveTransaction;

DELIMITER $$
CREATE PROCEDURE saveTransaction(IN sino_ INT(11), IN customer_ VARCHAR(50), IN vatable_ DECIMAL(13,2), IN vat_ DECIMAL(13,2), IN total_ DECIMAL(13,2), IN cash_ DECIMAL(13,2), IN change_ DECIMAL(13,2), IN loginid_ INT(8))
    BEGIN
		IF ((SELECT EXISTS (SELECT 1 FROM tblSales)) = 1)
		THEN
			INSERT INTO tblSales(sino, customer, vatable, vat, total, cash, `change`, loginid) values(sino_, customer_, vatable_, vat_, total_, cash_, change_, loginid_);
		ELSE
			INSERT INTO tblSales(sino, customer, vatable, vat, total, cash, `change`, loginid) values(190001, customer_, vatable_, vat_, total_, cash_, change_, loginid_);
        END IF;
    END$$
DELIMITER ;


-- ADD Product

DROP PROCEDURE addProduct;

DELIMITER $$
CREATE PROCEDURE addProduct(IN prod_name varchar(50), IN price_1 DECIMAL(13,2), IN price_2  DECIMAL(13,2), IN price_3  DECIMAL(13,2), IN prod_type varchar(20), IN is_available TINYINT)
    BEGIN
			INSERT INTO tblProducts(name, price1, price2, price3, productType, isAvailable)
						values	(prod_name, price_1, price_2, price_3, prod_type, is_available);
    END$$
DELIMITER ;


-- Update Product

DROP PROCEDURE updateProduct;

DELIMITER $$
CREATE PROCEDURE updateProduct(IN prod_name varchar(50), IN price_1 DECIMAL(13,2), IN price_2  DECIMAL(13,2), IN price_3  DECIMAL(13,2), IN prod_type varchar(20), IN is_available TINYINT, IN selectedID INT(10))
    BEGIN
			UPDATE tblProducts SET
				name = prod_name,
                price1 = price_1,
                price2 = price_2,
                price3 = price_3,
                productType = prod_type,
                isAvailable = is_available
                WHERE productID = selectedID;
    END$$
DELIMITER ;


-- ADD Add-ons

DROP PROCEDURE addAddOns;

DELIMITER $$
CREATE PROCEDURE addAddOns(IN addon_name varchar(50), IN price1 DECIMAL(13,2), IN for_prod_type varchar(20), IN is_available TINYINT)
    BEGIN
			INSERT INTO tblAddOns(name, price, forProductType, isAvailable)
						values	(addon_name, price1, for_prod_type, is_available);
    END$$
DELIMITER ;


-- Update Product

DROP PROCEDURE updateAddOns;

DELIMITER $$
CREATE PROCEDURE updateAddOns(IN addon_name varchar(50), IN price1 DECIMAL(13,2), IN for_prod_type varchar(20), IN is_available TINYINT, IN selectedID INT(10))
    BEGIN
			UPDATE tblAddOns SET
				name = addon_name,
                price = price1,
                forProductType = for_prod_type,
                isAvailable = is_available
                WHERE addonID = selectedID;
    END$$
DELIMITER ;


-- ----------------------------------------
-- ----------------------------------------
-- ----------------------------------------
-- ----------------------------------------
-- ----------------------------------------