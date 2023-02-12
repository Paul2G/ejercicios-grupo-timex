CREATE DATABASE IF NOT EXISTS `grupo_timex`;

USE `grupo_timex`;

CREATE TABLE IF NOT EXISTS `employees` (
    `IdRegistro` INT UNSIGNED NOT NULL AUTO_INCREMENT,
    `Nombre` VARCHAR(255)NOT NULL,
    `Apellidos` VARCHAR(255) NOT NULL,
    `FechaNacimiento` DATE NOT NULL,
    `FechaDeRegistroEnSistema` DATE NOT NULL DEFAULT(CURDATE()),
    PRIMARY KEY (`IdRegistro`)
);

/*Importacion de datos desde script MySQL*/
/*INSERT INTO `employees` (`Nombre`, `Apellidos`, `FechaNacimiento`) VALUES 
    ('Pedro', 'Mola', '1979-10-11'),
    ('Pablo', 'Videgaray', '1975-01-05'),
    ('Sonia', 'Lopez', '1985-04-06'),
    ('Alex', 'Perez', '1980-07-08')
;*/

CREATE USER 'developer_jr'@'localhost' IDENTIFIED BY 'superStrongPassword';

GRANT ALL ON grupo_timex.* TO 'developer_jr'@'localhost';