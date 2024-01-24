Drop database if exists TodoApp;
CREATE DATABASE TodoApp;

CREATE TABLE Mitarbeiter(
    Mitarbeiter_ID int Primary Key IDENTITY(1,1),
    Name varchar(255) not null,
    Admin int
);

CREATE TABLE Projekte(
    Projekt_ID int Primary Key IDENTITY(1,1),
    Name varchar(255) not null,
    Beschreibung varchar(255) not null,
    Mitarbeiter_ID int,
    Foreign Key (Mitarbeiter_ID) References Mitarbeiter(Mitarbeiter_ID)
);

CREATE TABLE Todos(
    Todo_ID int Primary Key IDENTITY(1,1),
    Name varchar(255) not null,
    Beschreibung varchar(255) not null,
    Status int,
    Projekt_ID int,
    Foreign Key (Projekt_ID) References Projekte(Projekt_ID)
);

CREATE TABLE Mitarbeiter_Todo(
    Mitarbeiter_Todo_ID int Primary Key IDENTITY(1,1),
    Mitarbeiter_ID int,
    Todo_ID int,
    Foreign Key (Mitarbeiter_ID) References Mitarbeiter(Mitarbeiter_ID),
    Foreign Key (Todo_ID) References Todos(Todo_ID)
);