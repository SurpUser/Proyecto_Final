create database StrongerDB

use StrongerDB;

create table Usuarios
(
	IdUsuario int identity(1,1) primary key,
	Nombre varchar(40),
	Contrasena Varchar(30),
	FechaInicio varchar(11),
	Area varchar(40) 
);
drop table Usuarios
insert into Usuarios Values('Francis','Francis1234','27/10/2015','Administrativa');
select * from Usuarios;
select IdUsuario from Usuarios where Nombre = 'Francis' And Contrasena = 'Francis1234';