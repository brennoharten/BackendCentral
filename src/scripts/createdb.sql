CREATE DATABASE `drhabit` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
use drhabit;
CREATE TABLE `activity` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Description` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Deadline` datetime NOT NULL,
  `Status` bit(1) NOT NULL,
  `Type` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Score` int NOT NULL,
  `DailyActivity` bit(1) NOT NULL,
  `InclusionDate` datetime NOT NULL,
  `AlterationDate` datetime NOT NULL,
  `AlterationUser` int NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `group` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Description` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `InclusionDate` datetime NOT NULL,
  `AlterationDate` datetime NOT NULL,
  `AlterationUser` int NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `activityhistory` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `GroupId` int NOT NULL,
  `ActivityId` int NOT NULL,
  `Count` int NOT NULL,
  `Date` datetime NOT NULL,
  `InclusionDate` datetime NOT NULL,
  `AlterationDate` datetime NOT NULL,
  `AlterationUser` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_ActivityHistory_ActivityId` (`ActivityId`),
  KEY `IX_ActivityHistory_GroupId` (`GroupId`),
  CONSTRAINT `FK_ActivityHistory_Activity_ActivityId` FOREIGN KEY (`ActivityId`) REFERENCES `activity` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_ActivityHistory_Group_GroupId` FOREIGN KEY (`GroupId`) REFERENCES `group` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `user` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Username` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Email` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Password` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Role` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `InclusionDate` datetime NOT NULL,
  `AlterationDate` datetime NOT NULL,
  `AlterationUser` int NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


CREATE TABLE `ranktype` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Description` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `InclusionDate` datetime NOT NULL,
  `AlterationDate` datetime NOT NULL,
  `AlterationUser` int NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `profile` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UserId` int NOT NULL,
  `Name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Birthdate` datetime NOT NULL,
  `Phone` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Genre` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `InclusionDate` datetime NOT NULL,
  `AlterationDate` datetime NOT NULL,
  `AlterationUser` int NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_Profile_UserId` (`UserId`),
  CONSTRAINT `FK_Profile_User_UserId` FOREIGN KEY (`UserId`) REFERENCES `user` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `rank` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ProfileId` int NOT NULL,
  `RankTypeId` int NOT NULL,
  `Score` int NOT NULL,
  `InclusionDate` datetime NOT NULL,
  `AlterationDate` datetime NOT NULL,
  `AlterationUser` int NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_Rank_ProfileId` (`ProfileId`),
  CONSTRAINT `FK_Rank_Profile_ProfileId` FOREIGN KEY (`ProfileId`) REFERENCES `profile` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `groupprofile` (
  `ProfileId` int NOT NULL,
  `GroupId` int NOT NULL,
  `ScoreGroup` int NOT NULL,
  `Id` int NOT NULL,
  `InclusionDate` datetime NOT NULL,
  `AlterationDate` datetime NOT NULL,
  `AlterationUser` int NOT NULL,
  PRIMARY KEY (`GroupId`,`ProfileId`),
  KEY `IX_GroupProfile_ProfileId` (`ProfileId`),
  CONSTRAINT `FK_GroupProfile_Group_GroupId` FOREIGN KEY (`GroupId`) REFERENCES `group` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_GroupProfile_Profile_ProfileId` FOREIGN KEY (`ProfileId`) REFERENCES `profile` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `note` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ProfileId` int NOT NULL,
  `Name` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Description` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `InclusionDate` datetime NOT NULL,
  `AlterationDate` datetime NOT NULL,
  `AlterationUser` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Note_ProfileId` (`ProfileId`),
  CONSTRAINT `FK_Note_Profile_ProfileId` FOREIGN KEY (`ProfileId`) REFERENCES `profile` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

INSERT INTO `drhabit`.`user` (`Id`, `Username`, `Email`, `Password`, `Role`, `InclusionDate`, `AlterationDate`, `AlterationUser`) VALUES ('1', 'brennoharten', 'brennoharten@gmail.com', 'senha123', 'admin', now(), now(), '1');



