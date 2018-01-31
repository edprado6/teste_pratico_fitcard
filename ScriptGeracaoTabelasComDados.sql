-- MySQL dump 10.13  Distrib 5.7.9, for Win64 (x86_64)
--
-- Host: localhost    Database: teste_fitcard_db
-- ------------------------------------------------------
-- Server version	5.6.17

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
-- Table structure for table `categoria`
--

DROP TABLE IF EXISTS `categoria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `categoria` (
  `Id` varchar(36) NOT NULL,
  `NomeCategoria` varchar(45) NOT NULL,
  `Excluido` tinyint(1) NOT NULL DEFAULT '0',
  `Ativo` tinyint(1) NOT NULL DEFAULT '1',
  `DataCadastro` datetime DEFAULT NULL,
  `DataAtualizacao` datetime DEFAULT NULL,
  `DataExclusao` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categoria`
--

LOCK TABLES `categoria` WRITE;
/*!40000 ALTER TABLE `categoria` DISABLE KEYS */;
INSERT INTO `categoria` VALUES ('1b51b466-6194-450c-aa49-1caa17a2be12','Resturante',1,1,'2017-11-21 21:42:58',NULL,NULL),('52c0d23c-b2dd-405a-bcfc-73b55554f62c','Oficina',0,1,'2017-11-23 15:07:55',NULL,NULL),('55939f45-e7be-4a3d-bce5-e9bf0b5e07df','Supermercado',0,1,'2017-11-22 02:13:23','2017-11-22 04:36:57',NULL),('735096bd-2cab-4384-b697-f612198cf5cc','Restaurante',0,1,'2017-11-17 02:37:53',NULL,NULL),('8029e6b2-3ee5-49c0-8572-2debcbb3b579','Posto de gasolina',0,1,'2017-11-22 00:30:54','2017-11-22 04:36:46',NULL),('c1a73050-5066-40af-8bff-4b3df0063e55','Borracharia',0,1,'2017-11-17 02:36:33','2017-11-23 22:48:21',NULL);
/*!40000 ALTER TABLE `categoria` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `estabelecimento`
--

DROP TABLE IF EXISTS `estabelecimento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `estabelecimento` (
  `Id` varchar(36) NOT NULL,
  `RazaoSocial` varchar(255) NOT NULL,
  `Excluido` tinyint(1) NOT NULL DEFAULT '0',
  `Ativo` tinyint(1) NOT NULL DEFAULT '1',
  `DataCadastro` datetime DEFAULT NULL,
  `DataAtualizacao` datetime DEFAULT NULL,
  `DataExclusao` datetime DEFAULT NULL,
  `NomeFantasia` varchar(255) DEFAULT NULL,
  `Cnpj` varchar(20) NOT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `Endereco` varchar(100) DEFAULT NULL,
  `Numero` int(11) DEFAULT NULL,
  `Bairro` varchar(100) DEFAULT NULL,
  `Complemento` varchar(100) DEFAULT NULL,
  `Cep` varchar(15) DEFAULT NULL,
  `Cidade` varchar(100) DEFAULT NULL,
  `Estado` varchar(2) DEFAULT NULL,
  `Ddd` varchar(2) DEFAULT NULL,
  `Telefone` varchar(15) DEFAULT NULL,
  `CategoriaId` varchar(36) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_CategoriaId_idx` (`CategoriaId`),
  CONSTRAINT `FK_CategoriaId` FOREIGN KEY (`CategoriaId`) REFERENCES `categoria` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='\n        public int Numero { get; set; }\n        public string Bairro { get; set; }\n        public string Complemento { get; set; }\n        public string Cep { get; set; }\n        public string Cidade { get; set; }\n        public string Estado { get; set; }\n        public string Ddd { get; set; }\n        public string Telefone { get; set; }\n        public string CategoriaId { get; set; }';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `estabelecimento`
--

LOCK TABLES `estabelecimento` WRITE;
/*!40000 ALTER TABLE `estabelecimento` DISABLE KEYS */;
INSERT INTO `estabelecimento` VALUES ('2d811b43-1075-40a8-baff-b92830c2792d','Supermercado Irmãos Lima',0,1,'2017-11-23 20:46:16','2017-11-23 23:02:36',NULL,'Irmãos Lima','19.861.350/0004-13','lima@hotmail.com','Rua Sete de Setembro',1000,'Centro','Térreo','37.890-000','Muzambinho','MG','35','9663-33333','55939f45-e7be-4a3d-bce5-e9bf0b5e07df'),('829f56f7-e20b-45bc-b797-f955843ca24f','Supermercado Magalhães',0,1,'2017-11-23 01:41:11','2017-11-23 15:44:24',NULL,'Magalhães','00.881.753/0001-53','magalhaes@hotmail.com','Rua Treze de Maio',510,'Centro','Fundos','37.880-000','Cabo Verde','MG','35','9878-88888','55939f45-e7be-4a3d-bce5-e9bf0b5e07df'),('b10a9790-7421-4314-a8bd-0687d670c0d5','Auto Posto Violeta',0,1,'2017-11-23 15:38:39',NULL,NULL,'Posto Violeta','19.861.350/0001-70','postovioleta@hotmail.com','Rua Sete de Setembro',15,'Centro','Esquina','37.890-000','Muzambinho','MG','35','9373-61191','8029e6b2-3ee5-49c0-8572-2debcbb3b579'),('b1f52df6-7ab3-42a2-9560-0d45aa3c84c9','A.W.A. Equipamentos Hidraulicos LTDA',0,1,'2017-11-23 23:05:31',NULL,NULL,'A.W.A. Equipamentos Hidraulicos','06.130.273/0001-37','awaequipamentos@hotmail.com','Rua Anita Ferraz',500,'Sé','Térreo','01.505-010','São Paulo','SP','35','9995-55222','52c0d23c-b2dd-405a-bcfc-73b55554f62c');
/*!40000 ALTER TABLE `estabelecimento` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-11-23 23:44:12



----Master MASTER
