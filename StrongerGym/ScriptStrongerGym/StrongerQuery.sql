create database StrongerDB
go
use StrongerDB
go
create table Usuarios(
UsuarioId int identity(1,1) primary key,
Nombre varchar(40),
Contrasena Varchar(200),
FechaInicio varchar(11),
Area varchar(40) 
);
go
create table Ciudades(
CiudadId int primary key identity(1,1),
Nombre varchar(100)
);
go
create table Proveedores(
ProveedorId int primary key identity(1,1),
CiudadId int References Ciudades(CiudadId),
NombreEmpresa varchar(50),
RNC varchar(50),--12-15
Direccion varchar(100),
Telefono varchar(14),
Celular varchar(14),
Email varchar(100),
NombreRepresentante varchar(50)
);
go
create table Clientes(
ClienteId int primary key identity(1,1),
CiudadId int References Ciudades(CiudadId),
Imagen varchar(200),
Nombre varchar(50),
Sexo bit,
Direccion varchar(100),
Telefono varchar(14),
Celular varchar(14),
Fecha varchar(11),
Peso varchar(10),
Altura varchar(10)
);
go
create table Asistencias(
AsistenciaId int primary key identity(1,1),
ClienteId int references Clientes(ClienteId),
Asistencia bit,
Fecha varchar(11)
);
go
create table Cuotas(
CuotaId int primary key identity(1,1),
ClienteId int References Clientes(ClienteId),
FechaCuota date,
MontoCuota float
);
go
create table TiposProteinas(
TipoProteinaId int primary key identity(1,1),
Nombre varchar(100)
);
go
create table Proteinas(
ProteinaId int primary key identity(1,1),
TipoProteinaId int References TiposProteinas(TipoProteinaId),
Nombre varchar(50),
Precio float,
Costo float
);
go
create table Compras(
CompraId int primary key identity(1,1),
ProveedorId int References Proveedores(ProveedorId),
ProteinaId int References Proteinas(ProteinaId),
UsuarioId int References Usuarios(UsuarioId),
ITBS float,
Monto float,
NCF varchar(50),
Fecha varchar(11),
Cantidad int,
);
go
create table ComprasDetalle(
CompraDetalleId int primary key identity(1,1),
CompraId int References Compras(CompraId),
ProteinaId int References Proteinas(ProteinaId),
Cantidad int,
Costo float
);
go
create table Ventas(
VentaId int primary key identity(1,1),
UsuarioId int References Usuarios(UsuarioId),
ClienteId int References Clientes(ClienteId),
ITBS float,
Fecha varchar(11),
NCF varchar(50),
TotalVenta float,
Descuento float
);
go
create table VentasDetalle(
VentaDetalleId int primary key identity(1,1),
UsuarioId int References Usuarios(UsuarioId),
ProteinaId int References Proteinas(ProteinaId),
VentaId int References Ventas(VentaId)
);
go
create table Configuraciones(
ConfiguracionId int primary key identity(1,1),
Dia int,
Semana int,
Mes int,
Ano int
);

select * from Usuarios

select * from Clientes

select * from Proteinas

--select Area,COUNT(Area) as Cantidad from Usuarios group by Area

--select * from TiposProteinas

--select * from Proveedores

--select p.NombreEmpresa,c.Nombre from Proveedores p inner join Ciudades c on p.ciudadId = c.CiudadId where p.ProveedorId = 1;

--select * from Ciudades;

insert into Usuarios(Nombre,Contrasena,FechaInicio,Area) values('Francis','ZgBjADEAMAAxADAA','10-Nov-2015','Administrativa');

--update Proveedores set CiudadId = 3,NombreEmpresa='FCPrograms',NombreRepresentante='Francis',RNC='3-23-12874-3',Direccion='Calle julia javier',Telefono='902-323-4354',Celular='323-434-5465',Email='info@fcprograms.com' where ProveedorId = 1;