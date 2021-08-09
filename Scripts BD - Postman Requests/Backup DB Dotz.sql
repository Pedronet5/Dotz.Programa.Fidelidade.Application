CREATE DATABASE  IF NOT EXISTS `dotz` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `dotz`;
-- MySQL dump 10.13  Distrib 8.0.25, for Win64 (x86_64)
--
-- Host: localhost    Database: dotz
-- ------------------------------------------------------
-- Server version	8.0.25

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

--
-- Table structure for table `address`
--

DROP TABLE IF EXISTS `address`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `address` (
  `id` int NOT NULL AUTO_INCREMENT,
  `userid` int NOT NULL,
  `address` varchar(200) NOT NULL,
  `number` int NOT NULL,
  `district` varchar(150) NOT NULL,
  `state` varchar(2) NOT NULL,
  `city` varchar(150) NOT NULL,
  `cep` varchar(9) NOT NULL,
  `complement` varchar(120) DEFAULT NULL,
  `updatedate` date NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fkuserid_idx` (`userid`),
  CONSTRAINT `fkuserid` FOREIGN KEY (`userid`) REFERENCES `useraccount` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `address`
--

LOCK TABLES `address` WRITE;
/*!40000 ALTER TABLE `address` DISABLE KEYS */;
INSERT INTO `address` VALUES (1,12,'Rua teste da avenida 202',2314,'District 2012','SP','Itu','13659-987',NULL,'2021-08-07'),(4,12,'Rua teste da avenida',2314,'District 2','SP','Itu','13859-477',NULL,'2021-08-07'),(7,12,'Rua teste da avenida 2',87,'District 12','SP','Itu','13652-234',NULL,'2021-08-07'),(8,12,'Rua teste da avenida 2',87,'District 12','SP','Itu','13652-234',NULL,'2021-08-07'),(9,12,'Rua teste da avenida 2',87,'District 12','SP','Itu','13652-234',NULL,'2021-08-07'),(10,12,'Rua teste da avenida 2',87,'District 12','SP','Itu','13652-234',NULL,'2021-08-07'),(11,11,'Rua joão maranhão',123,'District 2','SP','Itu','13859-234',NULL,'2021-08-08'),(12,1,'Rua Francisco Fernandes Netto',79,'Jardim Carlos Gomes','SP','Jundiaí','13203-542',NULL,'2021-08-08'),(14,17,'Rua Francisco Fernandes Netto',79,'Jardim Carlos Gomes','SP','Jundiaí','13203-542',NULL,'2021-08-08');
/*!40000 ALTER TABLE `address` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `category`
--

DROP TABLE IF EXISTS `category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `category` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `updatedate` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `category`
--

LOCK TABLES `category` WRITE;
/*!40000 ALTER TABLE `category` DISABLE KEYS */;
INSERT INTO `category` VALUES (1,'CDs','2021-08-08 17:52:25'),(2,'DVDs','2021-08-08 17:52:25'),(3,'Livros','2021-08-08 17:52:25'),(4,'Viagem','2021-08-08 17:52:25');
/*!40000 ALTER TABLE `category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `company`
--

DROP TABLE IF EXISTS `company`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `company` (
  `id` int NOT NULL AUTO_INCREMENT,
  `cnpj` varchar(45) DEFAULT NULL,
  `name` varchar(150) NOT NULL,
  `category` varchar(80) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `company`
--

LOCK TABLES `company` WRITE;
/*!40000 ALTER TABLE `company` DISABLE KEYS */;
INSERT INTO `company` VALUES (1,'78564343000176','Drogaria São Paulo','Farmacia'),(2,'93315997000150','Posto Betão','Posto de Combistivel'),(3,'51530820000126','livraria Saraiva','Livraria');
/*!40000 ALTER TABLE `company` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `deliverystatus`
--

DROP TABLE IF EXISTS `deliverystatus`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `deliverystatus` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(80) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `deliverystatus`
--

LOCK TABLES `deliverystatus` WRITE;
/*!40000 ALTER TABLE `deliverystatus` DISABLE KEYS */;
INSERT INTO `deliverystatus` VALUES (1,'Troca em Separação'),(2,'Troca enviada'),(3,'Troca recebida');
/*!40000 ALTER TABLE `deliverystatus` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `exchange`
--

DROP TABLE IF EXISTS `exchange`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `exchange` (
  `id` int NOT NULL AUTO_INCREMENT,
  `userid` int NOT NULL,
  `companyid` int NOT NULL,
  `addressid` int NOT NULL,
  `deliverystatus` int NOT NULL,
  `exchangedate` datetime NOT NULL,
  `updatedate` datetime NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_companyid_idx` (`companyid`),
  KEY `fk_userid_idx` (`userid`),
  KEY `fk_useridd_idx` (`userid`),
  KEY `fk_addressid_idx` (`addressid`),
  CONSTRAINT `fk_address` FOREIGN KEY (`addressid`) REFERENCES `address` (`id`),
  CONSTRAINT `fk_companyid` FOREIGN KEY (`companyid`) REFERENCES `company` (`id`),
  CONSTRAINT `fk_useridd` FOREIGN KEY (`userid`) REFERENCES `useraccount` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `exchange`
--

LOCK TABLES `exchange` WRITE;
/*!40000 ALTER TABLE `exchange` DISABLE KEYS */;
INSERT INTO `exchange` VALUES (6,1,1,12,1,'2021-08-08 20:47:33','2021-08-08 20:47:33'),(7,17,1,14,1,'2021-08-08 22:18:08','2021-08-08 22:18:08'),(8,17,1,14,1,'2021-08-08 22:35:54','2021-08-08 22:35:54'),(9,17,1,14,1,'2021-08-08 22:38:57','2021-08-08 22:38:57'),(10,17,1,14,1,'2021-08-08 23:03:20','2021-08-08 23:03:20');
/*!40000 ALTER TABLE `exchange` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `exchangeitens`
--

DROP TABLE IF EXISTS `exchangeitens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `exchangeitens` (
  `id` int NOT NULL AUTO_INCREMENT,
  `exchangeid` int NOT NULL,
  `productid` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_productid_idx` (`productid`),
  KEY `fk_exchangeid_idx` (`exchangeid`),
  CONSTRAINT `fk_exchangeid` FOREIGN KEY (`exchangeid`) REFERENCES `exchange` (`id`),
  CONSTRAINT `fk_productid` FOREIGN KEY (`productid`) REFERENCES `product` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `exchangeitens`
--

LOCK TABLES `exchangeitens` WRITE;
/*!40000 ALTER TABLE `exchangeitens` DISABLE KEYS */;
INSERT INTO `exchangeitens` VALUES (3,6,1),(4,6,4),(5,7,1),(6,8,1),(7,9,4),(8,10,6);
/*!40000 ALTER TABLE `exchangeitens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pointstransation`
--

DROP TABLE IF EXISTS `pointstransation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pointstransation` (
  `id` int NOT NULL AUTO_INCREMENT,
  `userid` int NOT NULL,
  `companyid` int NOT NULL,
  `operationtype` varchar(1) NOT NULL,
  `value` float NOT NULL,
  `updatedate` datetime NOT NULL,
  `description` varchar(200) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_userid_idx` (`userid`),
  KEY `fk_empresaid_idx` (`companyid`),
  CONSTRAINT `fk_empresaid` FOREIGN KEY (`companyid`) REFERENCES `company` (`id`),
  CONSTRAINT `fk_userid` FOREIGN KEY (`userid`) REFERENCES `useraccount` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pointstransation`
--

LOCK TABLES `pointstransation` WRITE;
/*!40000 ALTER TABLE `pointstransation` DISABLE KEYS */;
INSERT INTO `pointstransation` VALUES (1,1,1,'C',15,'2021-08-08 09:14:12','Credito de pontos adquiridos na compra de medicamentos'),(2,1,1,'D',5,'2021-08-08 09:20:34','Débito de pontos efetuado pela troca de produtos'),(3,1,1,'C',50,'2021-08-08 10:27:15','Créditos de pontos adquiridos na compra de livros'),(4,1,2,'C',5,'2021-08-08 10:33:45','Créditos de pontos adquiridos no abastecimento de veiculos '),(5,1,2,'C',14,'2021-08-08 10:52:50','Créditos de pontos adquiridos no abastecimento de veiculos '),(6,1,2,'C',1000,'2021-08-08 11:11:52','Créditos de pontos adquiridos no abastecimento de veiculos '),(7,1,1,'D',5,'2021-08-08 20:21:08','Débito de pontos efetuado pela troca de produtos'),(8,17,2,'C',1000,'2021-08-08 22:16:49','Créditos de pontos adquiridos no abastecimento de veiculos '),(9,17,1,'D',1000,'2021-08-08 22:35:54','Débito referente a troca dos produtos: System.Collections.Generic.List`1[System.Int32]'),(10,17,2,'C',1000,'2021-08-08 22:37:58','Créditos de pontos adquiridos no abastecimento de veiculos '),(11,17,1,'D',500,'2021-08-08 22:42:26','Débito referente a troca dos produtos: '),(12,17,1,'D',50,'2021-08-08 23:03:20','Débito referente a troca dos produtos: 6,');
/*!40000 ALTER TABLE `pointstransation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product`
--

DROP TABLE IF EXISTS `product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(150) NOT NULL,
  `valor` float NOT NULL,
  `categoryid` int NOT NULL,
  `updatedate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_categoryid_idx` (`categoryid`),
  CONSTRAINT `fk_categoryid` FOREIGN KEY (`categoryid`) REFERENCES `category` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product`
--

LOCK TABLES `product` WRITE;
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product` VALUES (1,'Harry Poter',1000,3,'2021-08-08 00:00:00'),(4,'Guerra nas Estrelas',500,3,'2021-08-07 00:00:00'),(6,'Veloses e Furiosos 9',50,2,'2021-08-08 11:21:09');
/*!40000 ALTER TABLE `product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `useraccount`
--

DROP TABLE IF EXISTS `useraccount`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `useraccount` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(250) NOT NULL,
  `email` varchar(100) NOT NULL,
  `password` varchar(45) NOT NULL,
  `role` varchar(50) NOT NULL,
  `updatedate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `useraccount`
--

LOCK TABLES `useraccount` WRITE;
/*!40000 ALTER TABLE `useraccount` DISABLE KEYS */;
INSERT INTO `useraccount` VALUES (1,'Pedro Henrique Leite de Camargo','pedronet5@gmail.com','123456','admin','2021-08-06 20:33:11'),(7,'Shallana Camargo','shallana@gmail.com','123456789','manager','2021-08-07 14:03:01'),(11,'Felipe Carreiro','fcarreiro@gmail.com','123456','employee','2021-08-07 16:17:36'),(12,'Mike Carvalho','mike@gmail.com','9521362','admin','2021-08-07 16:27:24'),(14,'Ricardo','ricardo@gmail.com','963284','user','2021-08-08 11:13:39'),(17,'Matheus','matheus@gmail.com','3344','user','2021-08-08 21:58:19');
/*!40000 ALTER TABLE `useraccount` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-08-08 23:16:23
