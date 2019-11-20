SET NAMES utf8;
SET time_zone = '+00:00';
SET foreign_key_checks = 0;
SET sql_mode = 'NO_AUTO_VALUE_ON_ZERO';

CREATE DATABASE `dbHappyThirstday` /* DEFAULT CHARACTER SET utf8 */;
USE `dbHappyThirstday`;

DROP TABLE IF EXISTS `tbladdons`;
CREATE TABLE `tbladdons` (
  `addonID` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  `price` decimal(13,2) NOT NULL DEFAULT '0.00',
  `forProductType` varchar(20) DEFAULT 'none',
  `isAvailable` tinyint(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`addonID`),
  UNIQUE KEY `addonid_UNIQUE` (`addonID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `tblproducts`;
CREATE TABLE `tblproducts` (
  `productID` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  `price1` decimal(13,2) DEFAULT '0.00',
  `price2` decimal(13,2) DEFAULT '0.00',
  `price3` decimal(13,2) DEFAULT '0.00',
  `productType` varchar(20) NOT NULL,
  `isAvailable` tinyint(4) NOT NULL DEFAULT '0',
  `dateadded` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`productID`),
  UNIQUE KEY `productid_UNIQUE` (`productID`),
  UNIQUE KEY `name_UNIQUE` (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `tblsales`;
CREATE TABLE `tblsales` (
  `salesid` int(11) NOT NULL AUTO_INCREMENT,
  `sino` int(11) NOT NULL,
  `customer` varchar(50) DEFAULT NULL,
  `total` decimal(13,2) NOT NULL,
  `vatable` decimal(13,2) NOT NULL,
  `vat` decimal(13,2) NOT NULL,
  `loginid` int(8) NOT NULL,
  `transdate` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`salesid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `tblusers`;
CREATE TABLE `tblusers` (
  `loginid` int(8) NOT NULL AUTO_INCREMENT,
  `username` varchar(20) NOT NULL,
  `password` varchar(90) NOT NULL,
  `firstname` varchar(50) NOT NULL,
  `lastname` varchar(50) NOT NULL,
  `position` varchar(20) NOT NULL,
  `isEnabled` tinyint(4) NOT NULL DEFAULT '1',
  `log_attempts` int(1) NOT NULL DEFAULT '0',
  `answer1` varchar(20) NOT NULL,
  `answer2` varchar(20) NOT NULL,
  `tempopw` varchar(20) DEFAULT 'temp',
  PRIMARY KEY (`loginid`),
  UNIQUE KEY `loginid_UNIQUE` (`loginid`),
  UNIQUE KEY `username_UNIQUE` (`username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

INSERT INTO `tblusers` (`loginid`, `username`, `password`, `firstname`, `lastname`, `position`, `isEnabled`, `log_attempts`, `answer1`, `answer2`, `tempopw`) VALUES
(20190001,	'admin',	MD5('admin'),	'Temporary',	'Admin',	'Admin',	1,	0,	'tempoanswer1',	'tempoanswer2',	'admin');


DELIMITER ;;

DROP PROCEDURE IF EXISTS `activateUser`;;
CREATE PROCEDURE `activateUser`(IN uname varchar(20))
BEGIN
		UPDATE tblUsers
        SET isEnabled = 1, log_attempts = 0
		WHERE username = uname;
    END;;

DROP PROCEDURE IF EXISTS `addAddOns`;;
CREATE PROCEDURE `addAddOns`(IN addon_name varchar(50), IN price1 DECIMAL(13,2), IN for_prod_type varchar(20), IN is_available TINYINT)
BEGIN
			INSERT INTO tblAddOns(name, price, forProductType, isAvailable)
						values	(addon_name, price1, for_prod_type, is_available);
    END;;

DROP PROCEDURE IF EXISTS `addProduct`;;
CREATE PROCEDURE `addProduct`(IN prod_name varchar(50), IN price_1 DECIMAL(13,2), IN price_2  DECIMAL(13,2), IN price_3  DECIMAL(13,2), IN prod_type varchar(20), IN is_available TINYINT)
BEGIN
			INSERT INTO tblProducts(name, price1, price2, price3, productType, isAvailable)
						values	(prod_name, price_1, price_2, price_3, prod_type, is_available);
    END;;

DROP PROCEDURE IF EXISTS `addUser`;;
CREATE PROCEDURE `addUser`(IN uname varchar(20), IN pword varchar(20), IN fname varchar(50), IN lname varchar(50), IN pos varchar(20), IN ans1 varchar(20), IN ans2 varchar(20), IN enabled TINYINT)
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
    END;;

DROP PROCEDURE IF EXISTS `invalidLogin`;;
CREATE PROCEDURE `invalidLogin`(IN uname varchar(20))
BEGIN
		UPDATE tblUsers SET log_attempts = log_attempts + 1 WHERE tblUsers.username = uname;

        IF (SELECT log_attempts FROM tblUsers WHERE username = uname) > 2
        THEN UPDATE tblUsers SET isEnabled = 0 WHERE username = uname;
        END IF;
    END;;

DROP PROCEDURE IF EXISTS `saveTransaction`;;
CREATE PROCEDURE `saveTransaction`(IN sino_ INT(11), IN customer_ VARCHAR(50), IN total_ DECIMAL(13,2), IN vatable_ DECIMAL(13,2), IN vat_ DECIMAL(13,2), IN loginid_ INT(8))
BEGIN
		IF ((SELECT EXISTS (SELECT 1 FROM tblSales)) = 1)
		THEN
			INSERT INTO tblSales(sino, customer, total,vatable,vat,loginid) values(sino_, customer_, total_, vatable_, vat_, loginid_);
		ELSE
			INSERT INTO tblSales(sino, customer, total, vatable, vat, loginid) values(190001, customer_, total_, vatable_, vat_, loginid_);
        END IF;
    END;;

DROP PROCEDURE IF EXISTS `updateAddOns`;;
CREATE PROCEDURE `updateAddOns`(IN addon_name varchar(50), IN price1 DECIMAL(13,2), IN for_prod_type varchar(20), IN is_available TINYINT, IN selectedID INT(10))
BEGIN
			UPDATE tblAddOns SET
				name = addon_name,
                price = price1,
                forProductType = for_prod_type,
                isAvailable = is_available
                WHERE addonID = selectedID;
    END;;

DROP PROCEDURE IF EXISTS `updateProduct`;;
CREATE PROCEDURE `updateProduct`(IN prod_name varchar(50), IN price_1 DECIMAL(13,2), IN price_2  DECIMAL(13,2), IN price_3  DECIMAL(13,2), IN prod_type varchar(20), IN is_available TINYINT, IN selectedID INT(10))
BEGIN
			UPDATE tblProducts SET
				name = prod_name,
                price1 = price_1,
                price2 = price_2,
                price3 = price_3,
                productType = prod_type,
                isAvailable = is_available
                WHERE productID = selectedID;
    END;;

DROP PROCEDURE IF EXISTS `updateUser`;;
CREATE PROCEDURE `updateUser`(IN uname varchar(20), IN pword varchar(20), IN fname varchar(50), IN lname varchar(50), IN pos varchar(20), IN ans1 varchar(20), IN ans2 varchar(20), IN enabled TINYINT, IN selectedid INT(10))
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
    END;;

DROP PROCEDURE IF EXISTS `updateUserNoPassword`;;
CREATE PROCEDURE `updateUserNoPassword`(IN uname varchar(20), IN fname varchar(50), IN lname varchar(50), IN pos varchar(20), IN ans1 varchar(20), IN ans2 varchar(20), IN enabled TINYINT, IN selectedid INT(10))
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
    END;;

DELIMITER ;

-- 2019-11-15 01:25:45
-- Updated for Happy Thirstday POS (v1.0.0.0)
