SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

CREATE SCHEMA IF NOT EXISTS `university` DEFAULT CHARACTER SET latin1 ;
USE `university` ;

-- -----------------------------------------------------
-- Table `university`.`Faculties`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `university`.`Faculties` (
  `Id` INT NOT NULL AUTO_INCREMENT ,
  `Name` VARCHAR(45) NOT NULL ,
  PRIMARY KEY (`Id`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `university`.`Departments`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `university`.`Departments` (
  `Id` INT NOT NULL AUTO_INCREMENT ,
  `Name` VARCHAR(45) NULL ,
  `Faculty_Id` INT NOT NULL ,
  PRIMARY KEY (`Id`) ,
  INDEX `fk_Department_Faculty_idx` (`Faculty_Id` ASC) ,
  CONSTRAINT `fk_Department_Faculty`
    FOREIGN KEY (`Faculty_Id` )
    REFERENCES `university`.`Faculties` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `university`.`Professors`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `university`.`Professors` (
  `Id` INT NOT NULL AUTO_INCREMENT ,
  `Name` VARCHAR(45) NULL ,
  `Department_Id` INT NOT NULL ,
  PRIMARY KEY (`Id`) ,
  INDEX `fk_Professor_Department1_idx` (`Department_Id` ASC) ,
  CONSTRAINT `fk_Professor_Department1`
    FOREIGN KEY (`Department_Id` )
    REFERENCES `university`.`Departments` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `university`.`Courses`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `university`.`Courses` (
  `Id` INT NOT NULL AUTO_INCREMENT ,
  `Name` VARCHAR(45) NOT NULL ,
  `Professors_Id` INT NOT NULL ,
  `Departments_Id` INT NOT NULL ,
  PRIMARY KEY (`Id`) ,
  INDEX `fk_Courses_Professors1_idx` (`Professors_Id` ASC) ,
  INDEX `fk_Courses_Departments1_idx` (`Departments_Id` ASC) ,
  CONSTRAINT `fk_Courses_Professors1`
    FOREIGN KEY (`Professors_Id` )
    REFERENCES `university`.`Professors` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Courses_Departments1`
    FOREIGN KEY (`Departments_Id` )
    REFERENCES `university`.`Departments` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `university`.`ProfessorTitles`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `university`.`ProfessorTitles` (
  `Id` INT NOT NULL AUTO_INCREMENT ,
  `Title` VARCHAR(45) NOT NULL ,
  `Professors_Id` INT NOT NULL ,
  PRIMARY KEY (`Id`) ,
  INDEX `fk_ProfessorTitles_Professors1_idx` (`Professors_Id` ASC) ,
  CONSTRAINT `fk_ProfessorTitles_Professors1`
    FOREIGN KEY (`Professors_Id` )
    REFERENCES `university`.`Professors` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `university`.`Students`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `university`.`Students` (
  `Id` INT NOT NULL AUTO_INCREMENT ,
  `Name` VARCHAR(45) NULL ,
  `Courses_Id` INT NOT NULL ,
  `Faculties_Id` INT NOT NULL ,
  PRIMARY KEY (`Id`) ,
  INDEX `fk_Students_Courses1_idx` (`Courses_Id` ASC) ,
  INDEX `fk_Students_Faculties1_idx` (`Faculties_Id` ASC) ,
  CONSTRAINT `fk_Students_Courses1`
    FOREIGN KEY (`Courses_Id` )
    REFERENCES `university`.`Courses` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Students_Faculties1`
    FOREIGN KEY (`Faculties_Id` )
    REFERENCES `university`.`Faculties` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

USE `university` ;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
