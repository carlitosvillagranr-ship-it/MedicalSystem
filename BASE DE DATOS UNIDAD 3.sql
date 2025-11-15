-- BASE DE DATOS UNIDAD 3
 DROP DATABASE PRN3_S2_B1_23_SMH;

-- Crear la base de datos
CREATE DATABASE IF NOT EXISTS PRN3_S2_B1_23_SMH;

-- Usar la base de datos
USE PRN3_S2_B1_23_SMH;

-- Crear la tabla EstadoCivil_SMH
CREATE TABLE EstadoCivil_SMH (
    Id_EstadoCivil INT AUTO_INCREMENT PRIMARY KEY,
    EstadoCivil_nombre VARCHAR(50)
);

-- Crear la tabla Especialidades_SMH
CREATE TABLE Especialidades_SMH (
    Id_Especialidad INT AUTO_INCREMENT PRIMARY KEY,
    Especialidad_nombre VARCHAR(50),
    Descripcion_Especialidad TEXT
);

-- Crear la tabla Pacientes_SMH
CREATE TABLE Pacientes_SMH (
    Id_paciente INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100),
    ApellidoPaterno VARCHAR(100),
    ApellidoMaterno VARCHAR(100),
    Direccion VARCHAR(100),
    Telefono VARCHAR(10),
    Celular VARCHAR(10),
    Edad INT,
    Sexo CHAR(1),
    Email VARCHAR(50),
    Id_EstadoCivil INT,
    
    FOREIGN KEY (Id_EstadoCivil) REFERENCES EstadoCivil_SMH(Id_EstadoCivil)
);

-- Crear la tabla Medicos_SMH
CREATE TABLE Medicos_SMH (
    Id_medico INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(50),
    ApellidoPaterno VARCHAR(50),
    ApellidoMaterno VARCHAR(50),
    Cedula VARCHAR(15)
);

-- Crear la tabla que relaciona médicos y especialidades (relación muchos a muchos)
CREATE TABLE Medicos_Especialidades_SMH (
    Id_medico INT,
    Id_Especialidad INT,
    PRIMARY KEY (Id_medico, Id_Especialidad),
    FOREIGN KEY (Id_medico) REFERENCES Medicos_SMH(Id_medico),
    FOREIGN KEY (Id_Especialidad) REFERENCES Especialidades_SMH(Id_Especialidad)
);

-- Crear la tabla Pacientes_Medico_SMH
CREATE TABLE Pacientes_Medico_SMH (
    Id_medico INT,
    Id_paciente INT,
    Diagnostico TEXT,
    PRIMARY KEY (Id_medico, Id_paciente),
    FOREIGN KEY (Id_medico) REFERENCES Medicos_SMH(Id_medico),
    FOREIGN KEY (Id_paciente) REFERENCES Pacientes_SMH(Id_paciente)
);