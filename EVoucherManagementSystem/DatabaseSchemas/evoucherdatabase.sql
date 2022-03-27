-- MySQL dump 10.13  Distrib 8.0.26, for Win64 (x86_64)
--
-- Host: localhost    Database: evoucherdatabase
-- ------------------------------------------------------
-- Server version	5.7.33-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
SET @MYSQLDUMP_TEMP_LOG_BIN = @@SESSION.SQL_LOG_BIN;
SET @@SESSION.SQL_LOG_BIN= 0;

--
-- GTID state at the beginning of the backup 
--

SET @@GLOBAL.GTID_PURGED=/*!80000 '+'*/ '';

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20220326160318_DBInit','6.0.3'),('20220326163414_PaymentMethodsAdd','6.0.3'),('20220326180015_BuyTypesAdd','6.0.3'),('20220326180620_BuyTypesAdd_ChangeColumnName','6.0.3'),('20220326215000_EVouchersAdd','6.0.3'),('20220327052555_PurchaseEVoucherAdd','6.0.3'),('20220327061628_PurchaseEVoucherUpdateNetAmountColumn','6.0.3'),('20220327092429_ItemPurchaseAdd','6.0.3');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `buytypes`
--

DROP TABLE IF EXISTS `buytypes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `buytypes` (
  `id` char(37) NOT NULL,
  `isMyself` int(11) NOT NULL,
  `isGiftOthers` int(11) NOT NULL,
  `eVoucher_maxlimit` int(11) NOT NULL DEFAULT '0',
  `giftUser_maxlimit` int(11) NOT NULL DEFAULT '0',
  `createdDateTime` datetime NOT NULL,
  `updatedDateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `buytypes`
--

LOCK TABLES `buytypes` WRITE;
/*!40000 ALTER TABLE `buytypes` DISABLE KEYS */;
INSERT INTO `buytypes` VALUES ('458915ad-4d4c-4d33-b24e-058bd745989a',1,0,5,0,'2022-03-27 22:21:47','2022-03-27 22:21:47'),('f416e79c-4c9b-4e65-8473-a613577c19a0',0,1,20,0,'2022-03-27 22:20:07','2022-03-27 22:20:07');
/*!40000 ALTER TABLE `buytypes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `evouchers`
--

DROP TABLE IF EXISTS `evouchers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `evouchers` (
  `id` char(37) NOT NULL,
  `title` varchar(100) CHARACTER SET utf8 NOT NULL,
  `description` varchar(1000) CHARACTER SET utf8 NOT NULL,
  `expiryDate` datetime NOT NULL,
  `image` varchar(300) CHARACTER SET utf8 NOT NULL,
  `amount` int(11) NOT NULL,
  `quantity` int(11) NOT NULL,
  `isActive` int(11) NOT NULL,
  `user_id` char(37) NOT NULL,
  `userName` varchar(50) CHARACTER SET utf8 NOT NULL,
  `phoneNo` varchar(25) CHARACTER SET utf8 NOT NULL,
  `qrCode` varchar(300) CHARACTER SET utf8 NOT NULL,
  `createdDateTime` datetime NOT NULL,
  `updatedDateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `evouchers`
--

LOCK TABLES `evouchers` WRITE;
/*!40000 ALTER TABLE `evouchers` DISABLE KEYS */;
INSERT INTO `evouchers` VALUES ('a66fedd7-393b-4aa3-9e85-e1cb01818bd1','NewYearGiftYoucher ','Myanmar New Year celebration','2022-04-17 00:00:00','giftvoucher.jpg',50000,1,1,'f95e379a-e171-4928-a634-37218d6dd8aa','AyeSuSuHan','09798109478','09798109478_QRCode.png','2022-03-27 22:32:28','2022-03-27 22:32:28');
/*!40000 ALTER TABLE `evouchers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `itempurchase`
--

DROP TABLE IF EXISTS `itempurchase`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `itempurchase` (
  `id` char(37) NOT NULL,
  `item` varchar(200) CHARACTER SET utf8 NOT NULL,
  `promocode` varchar(100) NOT NULL,
  `totalamount` int(11) NOT NULL,
  `userid` longtext,
  `createdDateTime` datetime NOT NULL,
  `updatedDateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `itempurchase`
--

LOCK TABLES `itempurchase` WRITE;
/*!40000 ALTER TABLE `itempurchase` DISABLE KEYS */;
INSERT INTO `itempurchase` VALUES ('4bf6944b-8166-4d55-b43a-a461575f7073','Madnest Tshirt NewYear Collection','015829CZJCH',45000,'f95e379a-e171-4928-a634-37218d6dd8aa','0001-01-01 00:00:00',NULL),('a3753be6-f72e-4205-96f2-b1ffb66f7a0e','Madnest Tshirt NewYear Collection','067699ZWBVY',45000,'f95e379a-e171-4928-a634-37218d6dd8aa','0001-01-01 00:00:00',NULL),('b69846d1-8ec2-4fb7-8765-d99c3b9660ad','Madnest Tshirt NewYear Collection','004327USUYC',45000,'f95e379a-e171-4928-a634-37218d6dd8aa','0001-01-01 00:00:00',NULL);
/*!40000 ALTER TABLE `itempurchase` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `paymentmethods`
--

DROP TABLE IF EXISTS `paymentmethods`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `paymentmethods` (
  `id` char(37) NOT NULL,
  `name` varchar(100) CHARACTER SET utf8 NOT NULL,
  `discountPercent` int(11) NOT NULL DEFAULT '0',
  `createdDateTime` datetime NOT NULL,
  `updatedDateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `paymentmethods`
--

LOCK TABLES `paymentmethods` WRITE;
/*!40000 ALTER TABLE `paymentmethods` DISABLE KEYS */;
INSERT INTO `paymentmethods` VALUES ('3aa67a8e-76e8-4c64-8435-de7fdb8e8230','Master',0,'2022-03-27 22:17:09','2022-03-27 22:17:09'),('88a014bc-7d2f-4b32-81e7-1fc47601e854','Bank Transfers',0,'2022-03-27 22:18:30','2022-03-27 22:18:30'),('e02e2583-28e3-458d-b25c-7c9b0a02fbc3','Visa',10,'2022-03-27 22:16:32','2022-03-27 22:16:32'),('f77e11ab-2a6f-43d3-a088-82c71ef84983','Money Gram',0,'2022-03-27 22:17:46','2022-03-27 22:17:46');
/*!40000 ALTER TABLE `paymentmethods` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `purchaseevouchers`
--

DROP TABLE IF EXISTS `purchaseevouchers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `purchaseevouchers` (
  `id` char(37) NOT NULL,
  `eVoucher_id` char(37) NOT NULL,
  `buyType_id` char(37) NOT NULL,
  `paymentMethod_id` char(37) NOT NULL,
  `netAmount` int(11) NOT NULL,
  `promoCode` varchar(100) NOT NULL,
  `isUsed` int(11) NOT NULL,
  `createdDateTime` datetime(6) NOT NULL,
  `updatedDateTime` datetime(6) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `purchaseevouchers`
--

LOCK TABLES `purchaseevouchers` WRITE;
/*!40000 ALTER TABLE `purchaseevouchers` DISABLE KEYS */;
INSERT INTO `purchaseevouchers` VALUES ('186d9967-8c31-4d80-8e83-0ac6c85828b5','a66fedd7-393b-4aa3-9e85-e1cb01818bd1','f416e79c-4c9b-4e65-8473-a613577c19a0','e02e2583-28e3-458d-b25c-7c9b0a02fbc3',45000,'015829CZJCH',1,'2022-03-27 22:48:14.263361','2022-03-27 22:53:49.758504'),('2f9780bb-7657-4cf1-8efe-01cb34ee8ade','a66fedd7-393b-4aa3-9e85-e1cb01818bd1','f416e79c-4c9b-4e65-8473-a613577c19a0','e02e2583-28e3-458d-b25c-7c9b0a02fbc3',45000,'067699ZWBVY',1,'2022-03-27 22:48:14.263361','2022-03-27 23:29:15.239704'),('38fbd119-bb7d-4b08-bace-3f2f094aff8e','a66fedd7-393b-4aa3-9e85-e1cb01818bd1','f416e79c-4c9b-4e65-8473-a613577c19a0','e02e2583-28e3-458d-b25c-7c9b0a02fbc3',45000,'004327USUYC',1,'2022-03-27 22:48:14.263361','2022-03-27 23:33:56.710229'),('4df27e04-52f9-4c75-b61d-81c3fd252774','a66fedd7-393b-4aa3-9e85-e1cb01818bd1','f416e79c-4c9b-4e65-8473-a613577c19a0','e02e2583-28e3-458d-b25c-7c9b0a02fbc3',45000,'054135MSKCL',0,'2022-03-27 22:48:14.263361','2022-03-27 22:48:14.263362'),('58e97ed6-0c30-49d0-a60a-26fc5da73354','a66fedd7-393b-4aa3-9e85-e1cb01818bd1','f416e79c-4c9b-4e65-8473-a613577c19a0','e02e2583-28e3-458d-b25c-7c9b0a02fbc3',45000,'009922DIEMK',0,'2022-03-27 22:48:14.263361','2022-03-27 22:48:14.263362'),('5a4ebdeb-8fe9-40a1-ad30-64e909ffc885','a66fedd7-393b-4aa3-9e85-e1cb01818bd1','f416e79c-4c9b-4e65-8473-a613577c19a0','e02e2583-28e3-458d-b25c-7c9b0a02fbc3',45000,'022332AYFCF',0,'2022-03-27 22:48:14.263361','2022-03-27 22:48:14.263362'),('5cb46c73-618c-4016-a883-65f13b83b673','a66fedd7-393b-4aa3-9e85-e1cb01818bd1','f416e79c-4c9b-4e65-8473-a613577c19a0','e02e2583-28e3-458d-b25c-7c9b0a02fbc3',45000,'024293KEMRZ',0,'2022-03-27 22:48:14.263361','2022-03-27 22:48:14.263362'),('69399672-e825-41ce-900c-b03cd1d450db','a66fedd7-393b-4aa3-9e85-e1cb01818bd1','f416e79c-4c9b-4e65-8473-a613577c19a0','e02e2583-28e3-458d-b25c-7c9b0a02fbc3',45000,'031343TARVN',0,'2022-03-27 22:48:14.263361','2022-03-27 22:48:14.263362'),('779cdac5-86de-4e8e-b4d1-9c04c254b0b7','a66fedd7-393b-4aa3-9e85-e1cb01818bd1','f416e79c-4c9b-4e65-8473-a613577c19a0','e02e2583-28e3-458d-b25c-7c9b0a02fbc3',45000,'029434MKMAA',0,'2022-03-27 22:48:14.263361','2022-03-27 22:48:14.263362'),('79c1fdfb-e3d6-4f3e-81b5-1fdc2ca48388','a66fedd7-393b-4aa3-9e85-e1cb01818bd1','f416e79c-4c9b-4e65-8473-a613577c19a0','e02e2583-28e3-458d-b25c-7c9b0a02fbc3',45000,'019752DAHVV',0,'2022-03-27 22:48:14.263361','2022-03-27 22:48:14.263362'),('7a19a1dd-a019-43da-bdd0-c344ddb08093','a66fedd7-393b-4aa3-9e85-e1cb01818bd1','f416e79c-4c9b-4e65-8473-a613577c19a0','e02e2583-28e3-458d-b25c-7c9b0a02fbc3',45000,'002391JYEGB',0,'2022-03-27 22:48:14.263361','2022-03-27 22:48:14.263362'),('83aa8778-b5eb-4a40-830d-813f57c09f4c','a66fedd7-393b-4aa3-9e85-e1cb01818bd1','f416e79c-4c9b-4e65-8473-a613577c19a0','e02e2583-28e3-458d-b25c-7c9b0a02fbc3',45000,'056617KOOEH',0,'2022-03-27 22:48:14.263361','2022-03-27 22:48:14.263362'),('8c2ece0c-0db2-4340-aa2f-e18d27c50885','a66fedd7-393b-4aa3-9e85-e1cb01818bd1','f416e79c-4c9b-4e65-8473-a613577c19a0','e02e2583-28e3-458d-b25c-7c9b0a02fbc3',45000,'085473JNRTE',0,'2022-03-27 22:48:14.263361','2022-03-27 22:48:14.263362'),('9c2a8b5b-6ffe-4b2e-afe7-a21cecf9179c','a66fedd7-393b-4aa3-9e85-e1cb01818bd1','f416e79c-4c9b-4e65-8473-a613577c19a0','e02e2583-28e3-458d-b25c-7c9b0a02fbc3',45000,'031364EJDWC',0,'2022-03-27 22:48:14.263361','2022-03-27 22:48:14.263362'),('b1dc111a-c50e-4da2-8e70-229eb0eb9e5a','a66fedd7-393b-4aa3-9e85-e1cb01818bd1','f416e79c-4c9b-4e65-8473-a613577c19a0','e02e2583-28e3-458d-b25c-7c9b0a02fbc3',45000,'001437BNSPI',0,'2022-03-27 22:48:14.263361','2022-03-27 22:48:14.263362'),('ba528f3a-4fce-4a5e-a928-59ddc94f09b8','a66fedd7-393b-4aa3-9e85-e1cb01818bd1','f416e79c-4c9b-4e65-8473-a613577c19a0','e02e2583-28e3-458d-b25c-7c9b0a02fbc3',45000,'024788KNCIS',0,'2022-03-27 22:48:14.263361','2022-03-27 22:48:14.263362'),('bac7ff1a-fb6a-4e88-85a5-b7f811cc5970','a66fedd7-393b-4aa3-9e85-e1cb01818bd1','f416e79c-4c9b-4e65-8473-a613577c19a0','e02e2583-28e3-458d-b25c-7c9b0a02fbc3',45000,'093502NZJUV',0,'2022-03-27 22:48:14.263361','2022-03-27 22:48:14.263362'),('cb7805e7-10dd-451f-8507-284907019959','a66fedd7-393b-4aa3-9e85-e1cb01818bd1','f416e79c-4c9b-4e65-8473-a613577c19a0','e02e2583-28e3-458d-b25c-7c9b0a02fbc3',45000,'070148PWQBP',0,'2022-03-27 22:48:14.263361','2022-03-27 22:48:14.263362'),('df8af77c-5aea-43bc-8cff-9e877c08702e','a66fedd7-393b-4aa3-9e85-e1cb01818bd1','f416e79c-4c9b-4e65-8473-a613577c19a0','e02e2583-28e3-458d-b25c-7c9b0a02fbc3',45000,'098367VLLIT',0,'2022-03-27 22:48:14.263361','2022-03-27 22:48:14.263362'),('ebebbd2e-d60a-44fe-861c-49af576953cc','a66fedd7-393b-4aa3-9e85-e1cb01818bd1','f416e79c-4c9b-4e65-8473-a613577c19a0','e02e2583-28e3-458d-b25c-7c9b0a02fbc3',45000,'056967NHXIQ',0,'2022-03-27 22:48:14.263361','2022-03-27 22:48:14.263362'),('edebb4af-e1c8-4e92-988c-832f1e74627c','a66fedd7-393b-4aa3-9e85-e1cb01818bd1','f416e79c-4c9b-4e65-8473-a613577c19a0','e02e2583-28e3-458d-b25c-7c9b0a02fbc3',45000,'050657VSYYM',0,'2022-03-27 22:48:14.263361','2022-03-27 22:48:14.263362');
/*!40000 ALTER TABLE `purchaseevouchers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `id` char(37) NOT NULL,
  `userName` varchar(50) CHARACTER SET utf8 NOT NULL,
  `phoneNo` varchar(25) CHARACTER SET utf8 NOT NULL,
  `password` varchar(50) CHARACTER SET utf8 NOT NULL,
  `createdDateTime` datetime NOT NULL,
  `updatedDateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES ('f95e379a-e171-4928-a634-37218d6dd8aa','AyeSuSuHan','09798109478','!@#$%123abc','2022-03-27 21:53:29','2022-03-27 21:53:29');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
SET @@SESSION.SQL_LOG_BIN = @MYSQLDUMP_TEMP_LOG_BIN;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-03-28  0:43:40
