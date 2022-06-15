create database TestPichincha
go
use TestPichincha
go
create table persona
(
	persona_id int primary key identity(1,1),
	nombre varchar(50),
	genero varchar(20),
	edad int,
	identificacion varchar(20),
	direccion varchar(250),
	telefono varchar(15)
);
go
create table cliente
(
	cliente_id int primary key identity(1,1),
	contrasena varchar(25),
	estado varchar(20),
	persona_id int
	FOREIGN KEY (persona_id) REFERENCES persona(persona_id)
);

go
create table cuenta
(
	cuenta_id int primary key identity(1,1),
	numero_cuenta varchar(20),
	tipo_cuenta varchar(10),
	saldo_inicial decimal(18,2),
	estado varchar(10),
	cliente_id int
	FOREIGN KEY (cliente_id) REFERENCES cliente(cliente_id)
);
go
create table movimientos
(
	movimiento_id int primary key identity(1,1),
	fecha datetime,
	tipo_movimiento varchar(10),
	valor decimal(18,2),
	saldo decimal(18,2),
	cuenta_id int,
	FOREIGN KEY (cuenta_id) REFERENCES cuenta(cuenta_id)
);
go

--DATOS

--insert into TestPichincha.dbo.persona
--(direccion,edad,genero,identificacion,nombre,telefono)
--values
--('Otavalo sn y principal',30,'MASCULINO','1312250515','Jose Lema','098254785'),
--('Amazonas y NNUU',30,'FEMENINA','1312250515','Marianela Montalvo','097548965'),
--('13 junio y equinocial',30,'MASCULINO','1312250515','Juan Osorio','098874587')

--insert into TestPichincha.dbo.cliente
--(contrasena,estado,persona_id)
--values
--('1234','true',1),
--('5678','true',2),
--('1245','true',3)


--insert into TestPichincha.dbo.cuenta
--(estado,numero_cuenta,saldo_inicial,tipo_cuenta,cliente_id)
--values
--('true','478758',2000,'Ahorro',1),
--('true','225487',1000,'Corriente',2),
--('true','495878',0,'Ahorro',3),
--('true','496825',540,'Ahorro',2)


