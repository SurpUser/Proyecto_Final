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

create table Proteina(
IdProteina int identity(1,1),
IdProveedor int,
Nombre varchar(50),
Precio double,
Cantidad int,
ITBS double,
Çosto double,
);

create table Proveedores(
IdProveedor int identity(1,1)
IdCiudad int,
NombreEmpresa varchar(100),
RNC varchar(100),
Direccion varchar(100),
Telefono numeric,
NombreRepresentante varchar(100)
);

create table Clientes(
IdClientes int identity(1,1),
IdCiudad int,
IdProteinas int,
IdCuotas int,
IdAsistencia int,
Imagen image,
Nombre varchar(100),
Dirrecion varchar(100),
Telefono numeric,
Celular, numeric
Altura, double,
Sexo int
);

çreate table Cuotas(
IdCuota int identity(1,1),
FechaUltimoPago date,
FechaVendicimeto date,
Ingreso double,
TotalIngreso
);

create table DetalleCompras(
IdDetalleCompra int identity(1,1),
IdProveedor int,
IdUsuario int,
IdCompra int,
IdProteina int
);

create table Compras(
IdCompra int identity(1,1),
IdProveedor int,
IdUsuario int,
Cantidad int,
NCF varchar(50),
Monto double,
Fecha date
);

create table Ventas(
IdVenta int identity(1,1),
IdUsuario int,
IdProteina int,
IdConfiguracion int,
Fecha date,
NFC varchar(50),
TotalVenta double,
);

create table DetalleVentas(
IdDetalleVenta int identity(1,1),
IdVenta int,
IdUsuario int,
IdProteina int
);

create table Ciudades(
IdCiudad int identity(1,1),
Nombre varchar(100)
);

create table TiposProteinas(
IdTipoProteina int identity(1,1),
Nombre varchar(100)
);

create table ClienteProteinas(
IdClienteProteina int identity(1,1),
IdCliente int,
IdProteina int
);

create table ClienteCuotas(
IdClienteCuota int identity(1,1),
IdCliente int,
IdCuota int
);

create table Configuracion(
IdConfiguracion int identity(1,1),
ITBS double,
PorDia int,
PorSemana int,
PorMes int,
PorAno int,
RutaFotos varchar(200)
);


drop table Usuarios
insert into Usuarios Values('Francis','Francis1234','27/10/2015','Administrativa');
select * from Usuarios;
select IdUsuario from Usuarios where Nombre = 'Francis' And Contrasena = 'Francis1234';