CREATE DATABASE  IF NOT EXISTS `supermarket` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `supermarket`;
-- MySQL dump 10.13  Distrib 5.5.16, for Win32 (x86)
--
-- Host: localhost    Database: supermarket
-- ------------------------------------------------------
-- Server version	5.5.24-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `measures`
--

DROP TABLE IF EXISTS `measures`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `measures` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Measure Name` varchar(50) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `measures`
--

LOCK TABLES `measures` WRITE;
/*!40000 ALTER TABLE `measures` DISABLE KEYS */;
INSERT INTO `measures` VALUES (1,'liters'),(2,'pieces'),(3,'kilograms'),(4,'grams'),(5,'number'),(6,'boxes');
/*!40000 ALTER TABLE `measures` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `products` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Product Name` varchar(50) NOT NULL,
  `Base Price` decimal(10,2) NOT NULL,
  `VendorID` int(11) NOT NULL,
  `MeasureID` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `fk_products_vendors_idx` (`VendorID`),
  KEY `fk_products_measures1_idx` (`MeasureID`),
  CONSTRAINT `fk_products_measures1` FOREIGN KEY (`MeasureID`) REFERENCES `measures` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_products_vendors` FOREIGN KEY (`VendorID`) REFERENCES `vendors` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=51 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES (1,'Beer “Zagorka”',0.86,2,1),(2,'Vodka “Targovishte”',7.56,3,1),(3,'Beer “Beck’s”',1.03,2,1),(4,'Chocolate “Milka”',2.80,1,2),(5,'Sweet Corn',1.00,4,6),(6,'Sweet Corn',0.85,14,6),(7,'Roasted Peanuts',1.29,4,2),(8,'Roasted Peanuts',1.79,20,2),(9,'Croissant',0.85,4,2),(10,'Beer \"Shumensko\"',0.80,5,1),(11,'Beer \"Boliarka\"',0.83,5,1),(12,'Beer \"Ariana\"',0.85,5,1),(13,'Coca Cola',1.35,6,1),(14,'Coca Cola Light',1.50,6,1),(15,'Fanta Orange',1.35,6,1),(16,'Spright',1.30,6,1),(17,'Tomato Chutney',1.45,7,2),(18,'Mayonnaise',1.35,7,2),(19,'Mustard',1.25,7,2),(20,'Tomato Chutney',1.55,8,2),(21,'Mayonnaise',1.45,8,2),(22,'Mustard',1.38,8,2),(23,'Vodka \"Savoy\"',8.15,9,1),(24,'Rum \"Savoy\"',7.55,9,1),(25,'Minced Meat',1.75,10,2),(26,'Weenie',7.25,10,3),(27,'Saussage',8.55,10,3),(28,'Yogurt',0.88,11,2),(29,'Weenie',7.65,13,3),(30,'Saussage',8.77,13,3),(31,'Margarine',1.55,15,2),(32,'Peel Pie',3.25,16,2),(33,'Margarine',1.95,16,2),(34,'Nescafe Classic',7.45,19,2),(35,'Nescafe Gold',11.25,19,2),(36,'Coffee',1.25,17,2),(37,'Jacobs Monarch',6.50,18,2),(38,'Jacobs 3in1',0.45,18,2),(39,'Nescafe 3in1',0.55,19,2),(40,'Sunflower',0.85,20,2),(41,'Milk',1.70,14,1),(42,'Yogurt',0.70,14,2),(43,'Fruit Yogurt',0.85,14,2),(44,'Fruit Yogurt',0.90,12,2),(45,'White Chocolate \"Milka\"',1.45,1,2),(46,'Dark Chocollate \"Milka\"',1.25,1,2),(47,'Beer \"Kamenitza\"',1.35,2,1),(48,'Icetea Nesty',1.35,6,1),(49,'Tequilla \"Savoy\"',7.00,9,1),(50,'Liqueur \"Savoy\"',7.20,9,1);
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vendors`
--

DROP TABLE IF EXISTS `vendors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `vendors` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Vendor Name` varchar(50) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vendors`
--

LOCK TABLES `vendors` WRITE;
/*!40000 ALTER TABLE `vendors` DISABLE KEYS */;
INSERT INTO `vendors` VALUES (1,'Nestle Sofia Corp.'),(2,'Zagorka Corp.'),(3,'Targovishte Bottling Company Ltd.'),(4,'Clever'),(5,'Boliarka VT'),(6,'CocaCola'),(7,'Meggle'),(8,'Olineza'),(9,'Deroni'),(10,'Savoy'),(11,'Leki'),(12,'Danone'),(13,'Ken'),(14,'Aro'),(15,'Kaliakra'),(16,'Bella'),(17,'Davidoff'),(18,'Jacobs'),(19,'Nescafe'),(20,'Grivas');
/*!40000 ALTER TABLE `vendors` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2013-07-23 14:13:39
