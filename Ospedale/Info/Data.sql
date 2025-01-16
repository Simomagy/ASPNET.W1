create database Ospedale
go
use Ospedale
go

create table dbo.Ospedali
(
    id       int identity constraint Ospedali_pk PRIMARY KEY ,

    sede     varchar(255),
    nome     varchar(255),
    pubblico bit
)
go

INSERT INTO Ospedale.dbo.Ospedali (sede, nome, pubblico) VALUES (N'Roma', N' Policlinico Umberto I', 1);
INSERT INTO Ospedale.dbo.Ospedali (sede, nome, pubblico) VALUES (N'Milano', N' Ospedale San Raffaele', 1);
INSERT INTO Ospedale.dbo.Ospedali (sede, nome, pubblico) VALUES (N'Piacenza', N' Casa di Cura', 0);

create table dbo.Medici
(
    id              int identity
        constraint Medici_pk
            primary key,
    nome            varchar(255),
    cognome         varchar(255),
    dob             date,
    residenza       varchar(255),
    reparto         varchar(255),
    primario        bit,
    pazientiGuariti int,
    totaleDecessi   int,
    ospedale        int
        constraint Medici_Ospedali_id_fk
            references dbo.Ospedali (id)
)
go

INSERT INTO Ospedale.dbo.Medici (nome, cognome, dob, residenza, reparto, primario, pazientiGuariti, totaleDecessi, ospedale) VALUES (N'Mario', N'Rossi', N'1981-02-02', N'Roma', N'Neurologia', 1, 10, 2, 2);
INSERT INTO Ospedale.dbo.Medici (nome, cognome, dob, residenza, reparto, primario, pazientiGuariti, totaleDecessi, ospedale) VALUES (N'Luca', N'Bianchi', N'1982-03-03', N'Milano', N'Oncologia', 0, 10, 2, 3);
INSERT INTO Ospedale.dbo.Medici (nome, cognome, dob, residenza, reparto, primario, pazientiGuariti, totaleDecessi, ospedale) VALUES (N'Giuseppe', N'Verdi', N'1983-04-04', N'Napoli', N'Pediatria', 1, 10, 2, 1);
INSERT INTO Ospedale.dbo.Medici (nome, cognome, dob, residenza, reparto, primario, pazientiGuariti, totaleDecessi, ospedale) VALUES (N'Giacomo', N'Gialli', N'1984-05-05', N'Torino', N'Ortopedia', 0, 10, 2, 2);
INSERT INTO Ospedale.dbo.Medici (nome, cognome, dob, residenza, reparto, primario, pazientiGuariti, totaleDecessi, ospedale) VALUES (N'Paolo', N'Neri', N'1985-06-06', N'Palermo', N'Dermatologia', 1, 10, 2, 3);
INSERT INTO Ospedale.dbo.Medici (nome, cognome, dob, residenza, reparto, primario, pazientiGuariti, totaleDecessi, ospedale) VALUES (N'Antonio', N'Marroni', N'1986-07-22', N'Bari', N'Ginecologia', 0, 10, 2, 1);
