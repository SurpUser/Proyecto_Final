create database StrongerDB

use StrongerDB;

create table Usuarios
(
	IdUsuario int identity(1,1) primary key,
	Nombre varchar(40),
	Contrasena Varchar(30),
	FechaInicio Date,
	Area varchar(40) 
);

insert into Usuarios Values('Francis','Francis1234',null,'Administrativa');
select * from Usuarios;
select IdUsuario from Usuarios where Nombre = 'Francis' And Contrasena = 'Francis1234';