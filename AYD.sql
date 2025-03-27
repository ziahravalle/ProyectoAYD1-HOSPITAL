if db_id('AYD') is not null
	begin
		use master
		drop database AYD
	end

/*crear*/
CREATE DATABASE AYD
GO

/*usar*/

USE AYD
go

CREATE TABLE TB_PACIENTES (
    paciente_id int primary key identity(1,1),
    nombre VARCHAR(100) NOT NULL,
    apellido VARCHAR(100) NOT NULL,
    fecha_nacimiento DATE NOT NULL,
    genero VARCHAR(10) CHECK (genero IN ('Masculino', 'Femenino', 'Otro')) NOT NULL,
    telefono VARCHAR(20),
    email VARCHAR(100),
    direccion TEXT,
	num_identificacion VARCHAR(20),
   fecha_registro DATETIME DEFAULT GETDATE()
);

select*from TB_PACIENTES

-------------------------------------------------------------------------------------------------------------------

CREATE TABLE TB_MEDICOS (
    medico_id int primary key identity(1,1),
    nombre VARCHAR(100) NOT NULL,
    apellido VARCHAR(100) NOT NULL,
    especialidad VARCHAR(100) NOT NULL,
    telefono VARCHAR(20),
    email VARCHAR(100),
    fecha_registro DATETIME DEFAULT GETDATE()
);
select*from TB_MEDICOS

-------------------------------------------------------------------------------------------------------------------

CREATE TABLE TB_CITAS (
    cita_id int primary key identity(1,1),
    paciente_id INT,
    medico_id INT,
    fecha_cita DATETIME NOT NULL,
    motivo TEXT,
    estado VARCHAR(20) CHECK (estado IN ('Pendiente', 'Atendida', 'Cancelada')) DEFAULT 'Pendiente',
    fecha_registro DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (paciente_id) REFERENCES TB_PACIENTES(paciente_id),
    FOREIGN KEY (medico_id) REFERENCES TB_MEDICOS(medico_id)
);
select*from TB_CITAS

-------------------------------------------------------------------------------------------------------------------

CREATE TABLE TB_HISTORIA_CLINICA (
    historia_id int primary key identity(1,1),
    paciente_id INT,
    fecha DATE NOT NULL,
    diagnostico TEXT,
    tratamiento TEXT,
    observaciones TEXT,
    fecha_registro DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (paciente_id) REFERENCES TB_PACIENTES(paciente_id)
);
select*from TB_HISTORIA_CLINICA

-------------------------------------------------------------------------------------------------------------------
CREATE TABLE TB_PRESCRIPCIONES (
    prescripcion_id  int primary key identity(1,1),
    historia_id INT,
    medicamento VARCHAR(255) NOT NULL,
	medico_id INT,
	paciente_id INT,
    dosis VARCHAR(255) NOT NULL,
    indicaciones TEXT,
    fecha_registro DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (historia_id) REFERENCES TB_HISTORIA_CLINICA(historia_id),
	FOREIGN KEY (medico_id) REFERENCES TB_MEDICOS(medico_id),
	FOREIGN KEY (paciente_id) REFERENCES TB_PACIENTES(paciente_id)
);
select*from TB_HISTORIA_CLINICA


-------------------------------------------------------------------------------------------------------------------

CREATE TABLE TB_USUARIO (
    usuario_id  int primary key identity(1,1),
    paciente_id int , /* funcionara como user */
    password VARCHAR(255) NOT NULL,
    rol VARCHAR(20) CHECK (rol IN ('Admin', 'Medico', 'Paciente', 'Trabajador')) NOT NULL,
    fecha_registro DATETIME DEFAULT GETDATE(),
	FOREIGN KEY (paciente_id) REFERENCES TB_PACIENTES(paciente_id)
);
select*from TB_USUARIO





----------INSERTSSSSSSSSSS---------------------------------------------------------------------------------------------------------

/*USER TB*/

INSERT INTO TB_USUARIO (paciente_id, password, rol) 
VALUES (1, 'contraseñaSegura123', 'Paciente');
select*from TB_USUARIO

/*PACIENTE TB*/

INSERT INTO TB_PACIENTES (nombre, apellido, fecha_nacimiento, genero, telefono, email, direccion, num_identificacion)
VALUES ('Juan', 'Pérez', '1985-05-15', 'Masculino', '987654321', 'juan.perez@email.com', 'Av. Siempre Viva 123, Lima', '12345678');

select*from TB_PACIENTES