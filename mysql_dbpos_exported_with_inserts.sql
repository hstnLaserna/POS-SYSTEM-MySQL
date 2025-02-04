-- Adminer 4.6.3 MySQL dump

SET NAMES utf8;
SET time_zone = '+00:00';
SET foreign_key_checks = 0;
SET sql_mode = 'NO_AUTO_VALUE_ON_ZERO';

CREATE DATABASE `dbpos` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `dbpos`;

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
						values	(uname ,MD5(pword), fname, lname, pos, ans1, ans2, substring(MD5(RAND()), -4), enabled);
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
CREATE PROCEDURE `saveTransaction`(IN sino_ INT(11), IN customer_ VARCHAR(50), IN vatable_ DECIMAL(13,2), IN vat_ DECIMAL(13,2), IN total_ DECIMAL(13,2), IN cash_ DECIMAL(13,2), IN change_ DECIMAL(13,2), IN loginid_ INT(8))
BEGIN
		IF ((SELECT EXISTS (SELECT 1 FROM tblSales)) = 1)
		THEN
			INSERT INTO tblSales(sino, customer, vatable, vat, total, cash, `change`, loginid) values(sino_, customer_, vatable_, vat_, total_, cash_, change_, loginid_);
		ELSE
			INSERT INTO tblSales(sino, customer, vatable, vat, total, cash, `change`, loginid) values(190001, customer_, vatable_, vat_, total_, cash_, change_, loginid_);
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

INSERT INTO `tbladdons` (`addonID`, `name`, `price`, `forProductType`, `isAvailable`) VALUES
(29000,	'Pearl',	10.00,	'milktea',	1),
(29001,	'Coffee Jelly',	10.00,	'milktea',	1),
(29002,	'Coconut Jelly',	15.00,	'milktea',	1),
(29003,	'Pudding',	15.00,	'Milktea',	1),
(29004,	'Aloe',	15.00,	'milktea',	1),
(29005,	'Red Bean',	20.00,	'Milktea',	1),
(29006,	'Oreo Cookies',	20.00,	'Milkshake',	1),
(29007,	'Cherry',	18.00,	'Milkshake',	1),
(29008,	'Wafer Stick',	25.00,	'Milkshake',	1),
(29009,	'Candy Sprinkles',	15.00,	'Milkshake',	1),
(29010,	'Choco Sprinkles',	15.00,	'Milkshake',	1),
(29011,	'Marshmallow',	20.00,	'Milkshake',	1),
(29012,	'Whipped Cream',	10.00,	'Frappe',	1),
(29013,	'Choco Syrup',	15.00,	'Frappe',	1),
(29014,	'Cinnamon',	10.00,	'Frappe',	1),
(29015,	'Vanilla',	10.00,	'Frappe',	1),
(29016,	'Choco Sprinkles',	10.00,	'Frappe',	0),
(29017,	'Sugar',	10.00,	'Frappe',	1),
(29018,	'Stick O',	25.00,	'Milktea',	0),
(29019,	'Coco jelly',	10.00,	'Milkshake',	0),
(29020,	'Strawberry Syrup',	15.00,	'Frappe',	1);

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

INSERT INTO `tblproducts` (`productID`, `name`, `price1`, `price2`, `price3`, `productType`, `isAvailable`, `dateadded`) VALUES
(190001,	'Classic Milktea',	69.00,	79.00,	0.00,	'Milktea',	1,	'2019-10-19 05:38:17'),
(190002,	'Wintermelon',	69.00,	79.00,	90.00,	'Milktea',	0,	'2019-10-19 05:38:17'),
(190003,	'Okinawa',	69.00,	79.00,	0.00,	'Milktea',	1,	'2019-10-19 05:38:17'),
(190004,	'Taro',	69.00,	79.00,	0.00,	'Milktea',	1,	'2019-10-19 05:38:17'),
(190005,	'Matcha',	69.00,	79.00,	120.00,	'Milktea',	1,	'2019-10-19 05:38:17'),
(190006,	'Hokkaido',	69.00,	79.00,	0.00,	'Milktea',	1,	'2019-10-19 05:38:17'),
(190007,	'Honey Lemon',	69.00,	79.00,	0.00,	'Milktea',	1,	'2019-10-19 05:38:17'),
(190008,	'Red Velvet',	69.00,	79.00,	0.00,	'Milktea',	1,	'2019-10-19 05:38:17'),
(190009,	'Hazelnut',	69.00,	79.00,	0.00,	'Milktea',	1,	'2019-10-19 05:38:17'),
(190010,	'Rocky Caramel',	69.00,	79.00,	0.00,	'Milktea',	0,	'2019-10-19 05:38:17'),
(190011,	'Almond',	69.00,	79.00,	0.00,	'Milktea',	1,	'2019-10-19 05:38:17'),
(190012,	'Salted Caramel',	69.00,	79.00,	0.00,	'Milktea',	1,	'2019-10-19 05:38:17'),
(190013,	'Cookies and Cream',	69.00,	79.00,	0.00,	'Milktea',	0,	'2019-10-19 05:38:17'),
(190014,	'Zagu',	69.00,	79.00,	0.00,	'Milktea',	1,	'2019-10-19 05:38:17'),
(190015,	'Black Forest',	69.00,	79.00,	0.00,	'Milktea',	0,	'2019-10-19 05:38:17'),
(190016,	'Hershey Chocolate',	64.00,	74.00,	0.00,	'Milkshake',	1,	'2019-10-19 05:38:17'),
(190017,	'Mint',	64.00,	74.00,	0.00,	'Milkshake',	0,	'2019-10-19 05:38:17'),
(190018,	'Cappuccino',	64.00,	74.00,	0.00,	'Milkshake',	1,	'2019-10-19 05:38:17'),
(190019,	'Cinnamon',	64.00,	74.00,	0.00,	'Milkshake',	1,	'2019-10-19 05:38:17'),
(190020,	'Frappuccino',	89.00,	99.00,	0.00,	'Frappe',	1,	'2019-10-19 05:38:17'),
(190021,	'Caramel Macchiato',	89.00,	99.00,	0.00,	'Frappe',	1,	'2019-10-19 05:38:17'),
(190022,	'Java Chip',	89.00,	99.00,	0.00,	'Frappe',	1,	'2019-10-19 05:38:17'),
(190023,	'White Mocha',	89.00,	0.00,	0.00,	'Frappe',	1,	'2019-10-19 05:38:17'),
(190024,	'Soju Tea',	69.00,	75.00,	0.00,	'Milktea',	0,	'2019-10-20 08:53:46'),
(190025,	'Coke',	25.00,	50.00,	75.00,	'Milktea',	0,	'2019-10-21 04:06:01'),
(190026,	'Niskafooz',	25.00,	0.00,	0.00,	'Milktea',	0,	'2019-10-21 04:10:25'),
(190027,	'Chocox',	50.00,	0.00,	0.00,	'Milktea',	1,	'2019-10-21 04:12:04'),
(190028,	'Machu',	55.00,	75.00,	150.00,	'Milktea',	0,	'2019-10-21 06:22:11'),
(190029,	'Chokolet',	120.00,	150.00,	165.00,	'Milkshake',	1,	'2019-10-21 06:25:18'),
(190030,	'Milk Mocha',	50.00,	25.00,	10.00,	'Frappe',	1,	'2019-10-21 06:47:50'),
(190031,	'Americano Iced',	8.00,	9.00,	0.00,	'Milktea',	0,	'2019-10-25 04:23:54'),
(190032,	'Winter Cream Cheese',	65.00,	75.00,	0.00,	'Milktea',	0,	'2019-10-25 05:29:09'),
(190036,	'Choco Milktea',	15.00,	30.00,	100.00,	'Milktea',	1,	'2019-10-28 08:53:19'),
(190037,	'Banana',	64.00,	74.00,	0.00,	'Milkshake',	1,	'2019-11-12 10:54:23'),
(190038,	'Mango',	64.00,	74.00,	0.00,	'Milkshake',	1,	'2019-11-12 10:54:36'),
(190039,	'Vanilla',	64.00,	74.00,	0.00,	'Milkshake',	1,	'2019-11-12 10:54:51'),
(190040,	'Strawberry',	64.00,	74.00,	0.00,	'Milkshake',	1,	'2019-11-12 10:55:00'),
(190041,	'Coconut',	64.00,	74.00,	0.00,	'Milkshake',	1,	'2019-11-12 10:55:35'),
(190042,	'Chocolate Strawberry',	64.00,	74.00,	0.00,	'Milkshake',	1,	'2019-11-12 10:55:47'),
(190043,	'Pumpkin Spice',	89.00,	99.00,	0.00,	'Frappe',	1,	'2019-11-12 10:56:27'),
(190044,	'Strawberries & Creme',	89.00,	99.00,	0.00,	'Frappe',	1,	'2019-11-12 10:56:47'),
(190045,	'Mocha',	89.00,	99.00,	0.00,	'Frappe',	1,	'2019-11-12 10:57:10'),
(190046,	'Green Tea',	89.00,	99.00,	0.00,	'Frappe',	1,	'2019-11-12 10:57:23'),
(190047,	'Vanilla Bean',	89.00,	99.00,	0.00,	'Frappe',	1,	'2019-11-12 10:57:42'),
(190048,	'Smores',	89.00,	99.00,	100.00,	'Frappe',	1,	'2019-11-12 10:58:00'),
(190051,	'Mint Milktea',	5.00,	6.00,	5.00,	'Milktea',	1,	'2019-11-14 04:59:51');

DROP TABLE IF EXISTS `tblsales`;
CREATE TABLE `tblsales` (
  `salesid` int(11) NOT NULL AUTO_INCREMENT,
  `sino` int(11) NOT NULL,
  `customer` varchar(50) DEFAULT NULL,
  `vatable` decimal(13,2) NOT NULL,
  `vat` decimal(13,2) NOT NULL,
  `total` decimal(13,2) NOT NULL,
  `cash` decimal(13,2) DEFAULT NULL,
  `change` decimal(13,2) DEFAULT NULL,
  `loginid` int(8) NOT NULL,
  `transdate` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`salesid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

INSERT INTO `tblsales` (`salesid`, `sino`, `customer`, `vatable`, `vat`, `total`, `cash`, `change`, `loginid`, `transdate`) VALUES
(1,	190000,	NULL,	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-10-17 07:08:45'),
(2,	190001,	'',	405.36,	48.65,	454.00,	500.00,	46.00,	20190002,	'2019-10-17 07:10:37'),
(3,	190002,	NULL,	100.00,	12.00,	112.00,	200.00,	88.00,	20190001,	'2019-10-18 06:42:13'),
(4,	190003,	NULL,	200.00,	24.00,	224.00,	500.00,	276.00,	20190001,	'2019-10-18 06:42:32'),
(5,	190004,	NULL,	200.00,	24.00,	224.00,	500.00,	276.00,	20190001,	'2019-10-18 06:42:41'),
(6,	190005,	NULL,	200.00,	24.00,	224.00,	500.00,	276.00,	20190001,	'2019-10-19 06:43:17'),
(7,	190006,	NULL,	200.00,	24.00,	224.00,	500.00,	276.00,	20190001,	'2019-10-19 06:43:17'),
(8,	190007,	NULL,	200.00,	24.00,	224.00,	500.00,	276.00,	20190001,	'2019-10-19 06:43:17'),
(9,	190008,	'',	615.18,	73.83,	689.00,	800.00,	111.00,	20190002,	'2019-10-23 07:01:11'),
(10,	190009,	'',	813.40,	97.61,	911.00,	1500.00,	589.00,	20190002,	'2019-10-23 07:20:01'),
(11,	190010,	'nobs',	1982.15,	237.86,	2220.00,	NULL,	NULL,	20190002,	'2019-10-24 05:20:48'),
(12,	190011,	'',	61.61,	7.40,	69.00,	75.00,	6.00,	20190002,	'2019-10-24 05:26:08'),
(13,	190012,	'laserna pogi',	416.08,	49.93,	466.00,	500.00,	34.00,	20190002,	'2019-10-25 05:22:40'),
(14,	190013,	'Ralph',	79.47,	9.54,	89.00,	100.00,	11.00,	20190002,	'2019-10-28 06:49:32'),
(15,	190014,	'Ralph',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-10-28 06:51:16'),
(16,	190015,	'Ralph',	70.54,	8.47,	79.00,	100.00,	21.00,	20190002,	'2019-10-28 06:53:51'),
(17,	190016,	'Matt',	70.54,	8.47,	79.00,	100.00,	21.00,	20190002,	'2019-10-28 07:00:47'),
(18,	190017,	'',	61.61,	7.40,	69.00,	75.00,	6.00,	20190002,	'2019-10-28 07:10:45'),
(19,	190018,	'',	61.61,	7.40,	69.00,	75.00,	6.00,	20190002,	'2019-10-28 07:17:18'),
(20,	190019,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-10-28 07:17:36'),
(21,	190020,	'',	61.61,	7.40,	69.00,	75.00,	6.00,	20190002,	'2019-10-28 07:21:24'),
(22,	190021,	'',	61.61,	7.40,	69.00,	75.00,	6.00,	20190002,	'2019-10-28 07:22:24'),
(23,	190022,	'',	83.93,	10.08,	94.00,	100.00,	6.00,	20190002,	'2019-10-28 07:25:46'),
(24,	190023,	'',	61.61,	7.40,	69.00,	75.00,	6.00,	20190002,	'2019-10-28 07:28:46'),
(25,	190024,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-10-28 07:31:59'),
(26,	190025,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-10-28 07:33:48'),
(27,	190026,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-10-28 07:35:58'),
(28,	190027,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-10-28 07:37:04'),
(29,	190028,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-10-28 07:37:53'),
(30,	190029,	'sdfasg',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-10-28 07:38:36'),
(31,	190030,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-10-28 08:20:05'),
(32,	190031,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-10-28 08:22:07'),
(33,	190032,	'',	83.93,	10.08,	94.00,	100.00,	6.00,	20190002,	'2019-10-28 08:23:17'),
(34,	190033,	'ahgg',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-10-28 08:23:34'),
(35,	190034,	'machu',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-10-28 08:25:55'),
(36,	190035,	'',	66.97,	8.04,	75.00,	100.00,	25.00,	20190002,	'2019-10-28 08:27:14'),
(37,	190036,	'hakdog',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-10-28 08:27:34'),
(38,	190037,	'asdg',	44.65,	5.36,	50.00,	75.00,	25.00,	20190002,	'2019-10-28 08:30:14'),
(39,	190038,	'mat',	100.00,	12.00,	112.00,	200.00,	88.00,	20190001,	'2019-10-28 08:45:26'),
(40,	190039,	'',	83.93,	10.08,	94.00,	100.00,	6.00,	20190001,	'2019-10-28 08:47:02'),
(41,	190040,	'',	92.86,	11.15,	104.00,	200.00,	96.00,	20190002,	'2019-10-29 00:26:44'),
(42,	190041,	'',	92.86,	11.15,	104.00,	200.00,	96.00,	20190002,	'2019-10-29 00:27:31'),
(43,	190042,	'',	194.65,	23.36,	218.00,	500.00,	282.00,	20190002,	'2019-11-06 05:54:04'),
(44,	190043,	'KUGP',	61.61,	7.40,	69.00,	75.00,	6.00,	20190002,	'2019-11-06 05:57:52'),
(45,	190044,	'',	53.58,	6.43,	60.00,	75.00,	15.00,	20190002,	'2019-11-06 06:08:23'),
(46,	190045,	'',	267.86,	32.15,	300.00,	500.00,	200.00,	20190002,	'2019-11-06 06:08:51'),
(47,	190046,	'',	318.75,	38.25,	357.00,	500.00,	143.00,	20190002,	'2019-11-06 06:09:58'),
(48,	190047,	'',	0.00,	0.00,	0.00,	50.00,	50.00,	20190002,	'2019-11-08 03:48:02'),
(49,	190048,	'',	303.58,	36.43,	340.00,	500.00,	160.00,	20190002,	'2019-11-08 03:48:13'),
(50,	190049,	'',	628.58,	75.43,	704.00,	800.00,	96.00,	20190002,	'2019-11-08 03:56:36'),
(51,	190050,	'',	1088.40,	130.61,	1219.00,	1500.00,	281.00,	20190002,	'2019-11-08 04:02:10'),
(52,	190051,	'',	243.75,	29.25,	273.00,	500.00,	227.00,	20190002,	'2019-11-08 05:00:25'),
(53,	190052,	'',	220.54,	26.47,	247.00,	500.00,	253.00,	20190002,	'2019-11-08 05:01:01'),
(54,	190053,	'',	264.29,	31.72,	296.00,	500.00,	204.00,	20190002,	'2019-11-08 05:01:23'),
(55,	190054,	'',	369.65,	44.36,	414.00,	500.00,	86.00,	20190002,	'2019-11-08 05:02:22'),
(56,	190055,	'300',	259.83,	31.18,	291.00,	500.00,	209.00,	20190002,	'2019-11-08 05:03:12'),
(57,	190056,	'',	246.43,	29.58,	276.00,	500.00,	224.00,	20190002,	'2019-11-08 05:06:58'),
(58,	190057,	'',	220.54,	26.47,	247.00,	500.00,	253.00,	20190002,	'2019-11-08 05:14:54'),
(59,	190058,	'',	508.93,	61.08,	570.00,	800.00,	230.00,	20190002,	'2019-11-08 05:15:50'),
(60,	190059,	'',	277.68,	33.33,	311.00,	500.00,	189.00,	20190002,	'2019-11-08 05:16:35'),
(61,	190060,	'',	538.40,	64.61,	603.00,	800.00,	197.00,	20190002,	'2019-11-08 05:17:36'),
(62,	190061,	'',	287.50,	34.50,	322.00,	500.00,	178.00,	20190002,	'2019-11-08 05:18:57'),
(63,	190062,	'',	61.61,	7.40,	69.00,	75.00,	6.00,	20190002,	'2019-11-08 05:19:32'),
(64,	190063,	'',	476.79,	57.22,	534.00,	800.00,	266.00,	20190002,	'2019-11-11 05:11:25'),
(65,	190064,	'',	141.08,	16.93,	158.00,	200.00,	42.00,	20190002,	'2019-11-11 08:41:31'),
(66,	190065,	'',	425.00,	51.00,	476.00,	500.00,	24.00,	20190002,	'2019-11-11 08:42:29'),
(67,	190066,	'',	163.40,	19.61,	183.00,	200.00,	17.00,	20190002,	'2019-11-11 10:55:32'),
(68,	190067,	'',	159.83,	19.18,	179.00,	200.00,	21.00,	20190002,	'2019-11-11 10:57:00'),
(69,	190068,	'',	10.00,	1.20,	12.00,	50.00,	38.00,	20190002,	'2019-11-12 01:30:39'),
(70,	190069,	'sdh',	10.00,	1.20,	12.00,	50.00,	38.00,	20190002,	'2019-11-12 01:37:04'),
(71,	190070,	'',	10.00,	1.20,	12.00,	50.00,	38.00,	20190002,	'2019-11-12 01:37:33'),
(72,	190071,	'',	10.00,	1.20,	12.00,	50.00,	38.00,	20190002,	'2019-11-12 01:53:21'),
(73,	190072,	'',	10.00,	1.20,	12.00,	50.00,	38.00,	20190002,	'2019-11-12 02:00:24'),
(74,	190073,	'',	10.00,	1.20,	12.00,	50.00,	38.00,	20190002,	'2019-11-12 02:02:14'),
(75,	190074,	'',	10.00,	1.20,	12.00,	50.00,	38.00,	20190002,	'2019-11-12 02:02:53'),
(76,	190075,	'',	10.00,	1.20,	12.00,	50.00,	38.00,	20190002,	'2019-11-12 02:58:03'),
(77,	190076,	'',	10.00,	1.20,	12.00,	50.00,	38.00,	20190002,	'2019-11-12 03:10:06'),
(78,	190077,	'',	10.00,	1.20,	12.00,	50.00,	38.00,	20190002,	'2019-11-12 03:10:22'),
(79,	190078,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-11-12 03:11:13'),
(80,	190079,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-11-12 03:12:15'),
(81,	190080,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-11-12 03:16:12'),
(82,	190081,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-11-12 03:16:41'),
(83,	190082,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-11-12 03:18:07'),
(84,	190083,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-11-12 03:19:24'),
(85,	190084,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-11-12 03:21:09'),
(86,	190085,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-11-12 03:22:04'),
(87,	190086,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-11-12 03:23:08'),
(88,	190087,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-11-12 03:24:03'),
(89,	190088,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-11-12 03:26:09'),
(90,	190089,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-11-12 03:33:03'),
(91,	190090,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-11-12 03:34:14'),
(92,	190091,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-11-12 03:35:33'),
(93,	190092,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-11-12 03:37:02'),
(94,	190093,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-11-12 03:37:39'),
(95,	190094,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-11-12 03:38:58'),
(96,	190095,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-11-12 03:41:00'),
(97,	190096,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-11-12 03:41:56'),
(98,	190097,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-11-12 03:44:19'),
(99,	190098,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-11-12 03:44:31'),
(100,	190099,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-11-12 03:48:57'),
(101,	190100,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-11-12 03:50:57'),
(102,	190101,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-11-12 03:52:11'),
(103,	190102,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-11-12 03:53:25'),
(104,	190103,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-11-12 03:56:00'),
(105,	190104,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-11-12 03:56:56'),
(106,	190105,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-11-12 03:58:36'),
(107,	190106,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-11-12 03:59:32'),
(108,	190107,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-11-12 04:01:02'),
(109,	190108,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-11-12 04:02:44'),
(110,	190109,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-11-12 04:03:30'),
(111,	190110,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-11-12 04:04:32'),
(112,	190111,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-11-12 04:42:09'),
(113,	190112,	'matt',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-11-12 04:44:00'),
(114,	190113,	'',	10.00,	1.20,	12.00,	50.00,	38.00,	20190002,	'2019-11-12 04:52:12'),
(115,	190114,	'',	10.00,	1.20,	12.00,	50.00,	38.00,	20190002,	'2019-11-12 04:56:52'),
(116,	190115,	'',	10.00,	1.20,	12.00,	50.00,	38.00,	20190002,	'2019-11-12 04:57:21'),
(117,	190116,	'531',	10.00,	1.20,	12.00,	50.00,	38.00,	20190002,	'2019-11-12 04:58:18'),
(118,	190117,	'',	10.00,	1.20,	12.00,	50.00,	38.00,	20190002,	'2019-11-12 05:34:03'),
(119,	190118,	'',	10.00,	1.20,	12.00,	50.00,	38.00,	20190002,	'2019-11-12 09:10:29'),
(120,	190119,	'',	10.00,	1.20,	12.00,	50.00,	38.00,	20190002,	'2019-11-12 09:15:23'),
(121,	190120,	'',	10.00,	1.20,	12.00,	50.00,	38.00,	20190002,	'2019-11-12 09:17:32'),
(122,	190121,	'',	10.00,	1.20,	12.00,	50.00,	38.00,	20190002,	'2019-11-12 09:18:11'),
(123,	190122,	'',	10.00,	1.20,	12.00,	50.00,	38.00,	20190002,	'2019-11-12 09:20:10'),
(124,	190123,	'',	10.00,	1.20,	12.00,	50.00,	38.00,	20190002,	'2019-11-12 09:20:35'),
(125,	190124,	'',	10.00,	1.20,	12.00,	50.00,	38.00,	20190002,	'2019-11-12 09:22:03'),
(126,	190125,	'',	10.00,	1.20,	12.00,	50.00,	38.00,	20190002,	'2019-11-12 09:22:41'),
(127,	190126,	'',	10.00,	1.20,	12.00,	50.00,	38.00,	20190002,	'2019-11-12 09:23:20'),
(128,	190127,	'sdf',	10.00,	1.20,	12.00,	50.00,	38.00,	20190002,	'2019-11-12 09:26:47'),
(129,	190128,	'',	10.00,	1.20,	12.00,	50.00,	38.00,	20190002,	'2019-11-12 09:27:40'),
(130,	190129,	'',	10.00,	1.20,	12.00,	50.00,	38.00,	20190002,	'2019-11-12 09:28:26'),
(131,	190130,	'',	10.00,	1.20,	12.00,	50.00,	38.00,	20190002,	'2019-11-12 09:29:57'),
(132,	190131,	'',	10.00,	1.20,	12.00,	50.00,	38.00,	20190002,	'2019-11-12 09:30:31'),
(133,	190132,	'Hsutingcvx',	10.00,	1.20,	12.00,	50.00,	38.00,	20190002,	'2019-11-12 09:31:16'),
(134,	190133,	'',	10.00,	1.20,	12.00,	50.00,	38.00,	20190002,	'2019-11-12 09:31:45'),
(135,	190134,	'',	10.00,	1.20,	12.00,	50.00,	38.00,	20190002,	'2019-11-12 09:33:03'),
(136,	190135,	'',	10.00,	1.20,	12.00,	50.00,	38.00,	20190002,	'2019-11-12 09:34:02'),
(137,	190136,	'',	10.00,	1.20,	12.00,	50.00,	38.00,	20190002,	'2019-11-12 09:35:02'),
(138,	190137,	'',	61.61,	7.40,	69.00,	75.00,	6.00,	20190002,	'2019-11-12 23:54:40'),
(139,	190138,	'',	1094.65,	131.36,	1226.00,	1500.00,	274.00,	20190002,	'2019-11-13 00:09:47'),
(140,	190139,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-11-13 00:33:35'),
(141,	190140,	'Hustino',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-11-13 00:34:35'),
(142,	190141,	'jujj uy uyu yu',	61.61,	7.40,	69.00,	75.00,	6.00,	20190002,	'2019-11-13 00:45:52'),
(143,	190142,	'',	107.15,	12.86,	120.00,	200.00,	80.00,	20190002,	'2019-11-13 00:53:13'),
(144,	190143,	'',	141.08,	16.93,	158.00,	200.00,	42.00,	20190002,	'2019-11-13 01:14:02'),
(145,	190144,	'fgj',	98.22,	11.79,	110.00,	200.00,	90.00,	20190002,	'2019-11-13 01:15:23'),
(146,	190145,	'',	70.54,	8.47,	79.00,	100.00,	21.00,	20190002,	'2019-11-13 01:16:18'),
(147,	190146,	'',	70.54,	8.47,	79.00,	100.00,	21.00,	20190002,	'2019-11-13 01:17:06'),
(148,	190147,	'',	369.65,	44.36,	414.00,	500.00,	86.00,	20190002,	'2019-11-13 06:26:17'),
(149,	190148,	'',	100.00,	12.00,	112.00,	200.00,	88.00,	20190002,	'2019-11-13 06:30:15'),
(150,	190149,	'',	184.83,	22.18,	207.00,	500.00,	293.00,	20190002,	'2019-11-13 06:56:56'),
(151,	190150,	'',	5147.33,	617.68,	5765.00,	NULL,	NULL,	20190002,	'2019-11-14 04:46:28'),
(152,	190151,	'qq11',	2744.65,	329.36,	3074.00,	NULL,	NULL,	20190014,	'2019-11-14 05:07:47'),
(153,	190152,	'',	62.50,	7.50,	70.00,	75.00,	5.00,	20190014,	'2019-11-14 05:14:52'),
(154,	190153,	'laserna',	345.54,	41.47,	387.00,	500.00,	113.00,	20190002,	'2019-11-15 04:00:01'),
(155,	190154,	'Matthew',	101.79,	12.22,	114.00,	200.00,	86.00,	20190006,	'2019-11-15 04:06:15'),
(156,	190155,	'',	203.58,	24.43,	228.00,	500.00,	272.00,	20190002,	'2019-11-15 05:04:44'),
(157,	190156,	'',	141.97,	17.04,	159.00,	200.00,	41.00,	20190002,	'2019-11-15 05:07:05'),
(158,	190157,	'',	425.90,	51.11,	477.00,	500.00,	23.00,	20190002,	'2019-11-15 05:08:04'),
(159,	190158,	'',	567.86,	68.15,	636.00,	800.00,	164.00,	20190002,	'2019-11-15 05:09:36'),
(160,	190159,	'',	141.97,	17.04,	159.00,	200.00,	41.00,	20190002,	'2019-11-15 05:10:28'),
(161,	190160,	'',	150.90,	18.11,	169.00,	200.00,	31.00,	20190002,	'2019-11-15 05:11:47'),
(162,	190161,	'',	562.50,	67.50,	630.00,	800.00,	170.00,	20190002,	'2019-11-15 05:12:38'),
(163,	190162,	'',	301.79,	36.22,	338.00,	500.00,	162.00,	20190002,	'2019-11-15 05:13:45'),
(164,	190163,	'',	340.18,	40.83,	381.00,	500.00,	119.00,	20190002,	'2019-11-15 05:14:08'),
(165,	190164,	'',	486.61,	58.40,	545.00,	800.00,	255.00,	20190002,	'2019-11-15 05:16:54'),
(166,	190165,	'',	567.86,	68.15,	636.00,	800.00,	164.00,	20190002,	'2019-11-15 05:17:31'),
(167,	190166,	'',	199.11,	23.90,	223.00,	500.00,	277.00,	20190002,	'2019-11-16 04:13:39'),
(168,	190167,	'',	500.00,	60.00,	560.00,	800.00,	240.00,	20190002,	'2019-11-16 09:08:23'),
(169,	190168,	'',	613.40,	73.61,	687.00,	800.00,	113.00,	20190002,	'2019-11-16 09:17:42'),
(170,	190169,	'',	760.72,	91.29,	852.00,	1500.00,	648.00,	20190002,	'2019-11-16 09:20:10'),
(171,	190170,	'',	895.54,	107.47,	1003.00,	1500.00,	497.00,	20190002,	'2019-11-16 09:21:21'),
(172,	190171,	'',	172.33,	20.68,	193.00,	200.00,	7.00,	20190002,	'2019-11-16 09:21:56'),
(173,	190172,	'',	1012.50,	121.50,	1134.00,	1500.00,	366.00,	20190002,	'2019-11-16 09:25:40'),
(174,	190173,	'',	660.72,	79.29,	740.00,	800.00,	60.00,	20190002,	'2019-11-17 14:26:02'),
(175,	190174,	'adu',	570.54,	68.47,	639.00,	800.00,	161.00,	20190002,	'2019-11-17 14:27:05'),
(176,	190175,	'',	203.58,	24.43,	228.00,	500.00,	272.00,	20190002,	'2019-11-17 21:33:00'),
(177,	190176,	'',	358.93,	43.08,	402.00,	500.00,	98.00,	20190002,	'2019-11-17 22:01:50'),
(178,	190177,	'',	119.65,	14.36,	134.00,	200.00,	66.00,	20190002,	'2019-11-18 02:08:47'),
(179,	190178,	'',	348.22,	41.79,	390.00,	500.00,	110.00,	20190002,	'2019-11-18 02:09:52'),
(180,	190179,	'',	837.50,	100.50,	938.00,	1500.00,	562.00,	20190002,	'2019-11-18 03:38:18'),
(181,	190180,	'',	1256.25,	150.75,	1407.00,	1500.00,	93.00,	20190002,	'2019-11-18 08:33:45'),
(182,	190181,	'',	371.43,	44.58,	416.00,	500.00,	84.00,	20190004,	'2019-11-19 06:46:48'),
(183,	190182,	'',	61.61,	7.40,	69.00,	75.00,	6.00,	20190004,	'2019-11-19 06:47:19'),
(184,	190183,	'',	123.22,	14.79,	138.00,	200.00,	62.00,	20190004,	'2019-11-19 06:47:51'),
(185,	190184,	'',	151.79,	18.22,	170.00,	200.00,	30.00,	20190004,	'2019-11-20 03:48:16'),
(186,	190185,	'',	332.15,	39.86,	372.00,	500.00,	128.00,	20190004,	'2019-11-20 04:27:10'),
(187,	190186,	'',	233.93,	28.08,	262.00,	500.00,	238.00,	20190004,	'2019-11-20 05:05:50'),
(188,	190187,	'',	225.90,	27.11,	253.00,	500.00,	247.00,	20190004,	'2019-11-20 05:15:37'),
(189,	190188,	'',	456.25,	54.75,	511.00,	800.00,	289.00,	20190004,	'2019-11-20 05:16:45'),
(190,	190189,	'',	583.93,	70.08,	654.00,	700.00,	46.00,	20190004,	'2019-11-20 08:53:51'),
(191,	190190,	'',	314.29,	37.72,	352.00,	400.00,	48.00,	20190000,	'2019-11-20 10:21:14');

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
(20190000,	'x',	'9dd4e461268c8034f5c8564e155c67a6',	'Super',	'User',	'Developer',	1,	0,	'super',	'jr',	'8d6c'),
(20190001,	'happyt',	'a6a98a936dff30f6320a03ff3430a8f4',	'Jaycel',	'Beliganio',	'Admin',	1,	0,	'harbor',	'mmg1',	'2d23'),
(20190002,	'cashier1',	'912ec803b2ce49e4a541068d495ab570',	'Lich',	'King',	'Cashier',	1,	0,	'iced',	'throne',	'asdf'),
(20190003,	'cashier2',	'912ec803b2ce49e4a541068d495ab570',	'Mirana',	'Nightshade',	'Admin',	1,	0,	'arrow',	'hahahaha',	'asdf'),
(20190004,	'cashier3',	'f5bb0c8de146c67b44babbf4e6584cc0',	'Traxex',	'Drow',	'Admin',	1,	1,	'arrow',	'silence',	'45f3'),
(20190005,	'manager',	'81dc9bdb52d04dc20036dbd8313ed055',	'Helcurt',	'Nightstalker',	'Admin',	1,	0,	'dart',	'blink',	'1234'),
(20190006,	'matthew',	'e807f1fcf82d132f9bb018ca6738a19f',	'Matthew',	'Vasquez',	'Admin',	1,	0,	'2311',	'1998',	'shikimat'),
(20190007,	'hustinow',	'14acbed198e2456a400321cd9b065ce3',	'justine',	'laserna',	'Admin',	1,	0,	'tino',	'kyut',	'aaaf'),
(20190008,	'sanjiv',	'3d801aa532c1cec3ee82d87a99fdf63f',	'Sanjiv',	'Manalig',	'Admin',	1,	0,	'nautre',	'springz',	'temp'),
(20190009,	'noble25',	'912ec803b2ce49e4a541068d495ab570',	'Michael',	'Noble',	'Admin',	1,	0,	'michael',	'noble',	'asdf'),
(20190010,	'jbeliganio',	'912ec803b2ce49e4a541068d495ab570',	'Jaycelx',	'Beliganio',	'Admin',	1,	0,	'itcsa',	'cl14',	'asdf'),
(20190011,	'cashier4',	'912ec803b2ce49e4a541068d495ab570',	'Mema na',	'Cashier name',	'Cashier',	1,	0,	'clay',	'gogo',	'a674'),
(20190012,	'allain',	'473732ecf904f9950da106e14d238b9b',	'frederick',	'delacruz',	'Admin',	1,	0,	'ochado',	'milktea',	'812f'),
(20190013,	'Cashier5',	'e2031979cacff4879a6c3ea68ce61a8b',	'charlene',	'gatmin',	'Cashier',	1,	0,	'wahaha',	'kapot',	'e950'),
(20190014,	'AngeLo1992',	'81dc9bdb52d04dc20036dbd8313ed055',	'Michael',	'Noble',	'Cashier',	1,	0,	'answer',	'answer',	'1234');

-- 2019-11-20 10:25:33
