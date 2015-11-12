create database StrongerDB

use StrongerDB

create table Usuarios(
UsuarioId int identity(1,1) primary key,
Nombre varchar(40),
Contrasena Varchar(200),
FechaInicio varchar(11),
Area varchar(40) 
);

drop table Usuarios

select * from Usuarios

create table Ciudades(
CiudadId int primary key identity(1,1),
Nombre varchar(100)
);

create table Proveedores(
ProveedorId int primary key identity(1,1),
CiudadId int References Ciudades(CiudadId),
NombreEmpresa varchar(50),
RNC varchar(50),--12-15
Direccion varchar(100),
Telefono varchar(12),
Celular varchar(12),
Email varchar(100),
NombreRepresentante varchar(50)
);

create table Clientes(
ClienteId int primary key identity(1,1),
CiudadId int References Ciudades(CiudadId),
Imagen image,
Nombre varchar(50),
Sexo bit,
Direccion varchar(100),
Telefono varchar(12),
Celular varchar(12),
Peso varchar(10),
Altura varchar(10)
);

create table Asistencias(
AsistenciaId int primary key identity(1,1),
ClienteId int references Clientes(ClienteId),
Asistencia bit,
Fecha varchar(11)
);

create table Cuotas(
CuotaId int primary key identity(1,1),
ClienteId int References Clientes(ClienteId),
FechaCuota date,
MontoCuota float
);

create table TiposProteinas(
TipoProteinaId int primary key identity(1,1),
Nombre varchar(100)
);

create table Proteinas(
ProteinaId int primary key identity(1,1),
TipoProteinaId int References TiposProteinas(TipoProteinaId),
Nombre varchar(50),
Precio float,
ITBS float,
Cantidad int,
Costo float
);

create table Compras(
CompraId int primary key identity(1,1),
ProveedorId int References Proveedores(ProveedorId),
ProteinaId int References Proteinas(ProteinaId),
UsuarioId int References Usuarios(UsuarioId),
ITBS float,
Monto float,
NCF varchar(50),
Fecha date,
Cantidad int,
);

create table ComprasDetalle(
CompraDetalleId int primary key identity(1,1),
CompraId int References Compras(CompraId),
ProteinaId int References Proteinas(ProteinaId),
Cantidad int,
Costo float
);

create table Ventas(
VentaId int primary key identity(1,1),
UsuarioId int References Usuarios(UsuarioId),
ClienteId int References Clientes(ClienteId),
ITBS float,
Fecha date,
NCF varchar(50),
TotalVenta float,
Descuento float
);

create table VentasDetalle(
VentaDetalleId int primary key identity(1,1),
UsuarioId int References Usuarios(UsuarioId),
ProteinaId int References Proteinas(ProteinaId),
VentaId int References Ventas(VentaId)
);

create table Configuraciones(
ConfiguracionId int primary key identity(1,1),
Dia int,
Semana int,
Mes int,
Ano int
);

select * from Usuarios

select * from TiposProteinas

insert into TiposProteinas(Nombre) values ('Suplemento');

select * from Proveedores

select p.NombreEmpresa,c.Nombre from Proveedores p inner join Ciudades c on p.ciudadId = c.CiudadId where p.ProveedorId = 1;

select * from Ciudades;

select UsuarioId from Usuarios where Nombre = 'Francis' And Contrasena = 'ZgBjADEAMAAxADAA'

insert into Usuarios(Nombre,Contrasena,FechaInicio,Area) values('Edwin','MgA0ADEAMAAyADQAMQAwAA==','10-Nov-2015','Administrativa');

update Proveedores set CiudadId = 3,NombreEmpresa='FCPrograms',NombreRepresentante='Francis',RNC='3-23-12874-3',Direccion='Calle julia javier',Telefono='902-323-4354',Celular='323-434-5465',Email='info@fcprograms.com' where ProveedorId = 1;