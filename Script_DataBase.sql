use fase3_proyecto;


create table TipoEmpresa (
	idTipoEmpresa int identity(1,1) primary key not null,
	nombre varchar(45) not null,
	descripcio text
);

create table TamañoEmpresa (
	idTamañoEmpresa int identity(1,1) primary key not null,
	nombre varchar(45) not null
);

create table TipoTarjeta (
	idTipoTarjeta int identity(1,1) primary key not null,
	nombre varchar(45) not null
);

create table Suscripcion (
	idSuscripcion int identity(1,1) primary key not null,
	nombre varchar(45)
);


create table ClientePYME (
	nit bigint primary key not null,
	nombreEmpresa varchar(100) not null,
	fk_tipoEmpresa int not null,
	fk_tamañoEmpresa int not null,
	fk_suscripcion int not null
);

alter table ClientePYME add constraint fk_TipoEmpresa foreign key (fk_tipoEmpresa) references TipoEmpresa(idTipoEmpresa);
alter table ClientePYME add constraint fk_TamañoEmpresa foreign key (fk_tamañoEmpresa) references TamañoEmpresa(idTamañoEmpresa);
alter table ClientePYME add constraint fk_Suscripcion foreign key (fk_suscripcion) references Suscripcion(idSuscripcion);


create table TarjetaCredito (
	numeroTarjeta int primary key not null,
	nombreTarjeta varchar(45) not null,
	fechaVencimiento Date not null,
	crv varchar(10) not null,
	fk_tipoTarjeta int not null, 
	fk_clientePyme bigint not null
);

alter table TarjetaCredito add constraint fk_tipoTarjeta foreign key (fk_tipoTarjeta) references TipoTarjeta(idTipoTarjeta);
alter table TarjetaCredito add constraint fk_clientePyme foreign key (fk_clientePyme) references ClientePYME (nit);


create table TipoContacto (
	idTipoContacto int identity(1,1) primary key not null,
	nombre varchar(45) not null,
	descripcion text not null,
);

create table Contacto(
	cui bigint primary key not null, 
	nombreContacto varchar(45) not null,
	telefonoCelular int not null,
	telefonoOficina int not null,
	extension varchar(10) not null,
	correoElectronico varchar(45) not null,
	direccionOficina varchar(100) not null,
	fk_tipoContacto int not null,
	fk_clientePyme bigint not null
);

alter table Contacto add constraint fk_tipoContacto foreign key (fk_tipoContacto) references TipoContacto(idTipoContacto);
alter table Contacto add constraint fk_clientePymes foreign key (fk_clientePyme) references ClientePYME(nit);
alter table Contacto drop column fk_usuario;

alter table Contacto alter column cui bigint;
alter table Contacto alter column cui bigint;

select * from Contacto;

create table TipoUsuario(
	idTipoUsuario int identity(1,1) primary key not null,
	nombre varchar(45) not null
);

create table Usuario(
	idUsuario int identity(1,1) primary key not null,
	nombreUsuario varchar(45) not null,
	contraseña varchar(15) not null,
	fk_tipoUsuario int not null,
	fk_contacto bigint
);

alter table Usuario add constraint fk_tipoUsuario foreign key (fk_tipoUsuario) references TipoUsuario(idTipoUsuario);
alter table Usuario add constraint fk_contacto foreign key (fk_contacto) references Contacto(cui);


select * from Usuario;

create table TipoModulo (
	idTipoModulo int identity(1,1) primary key not null,
	nombre varchar(45)
);

create table Modulo (
	codigoModulo int primary key not null,
	nombre varchar(45) not null,
	abreviatura varchar(20) not null,
	descripcion text,
	fk_tipoModulo int not null
);

alter table Modulo add constraint fk_tipoModulo foreign key (fk_tipoModulo) references TipoModulo(idTipoModulo);


create table ListaPrecio (
	idListaPrecio int identity(1,1) primary key not null,
	fechaInicio date not null,
	fechaFin date
);

create table Modulo_Precio (
	idModulo_Precio int identity(1,1) primary key not null,
	Precio Decimal(7,2) not null,
	fk_suscripcion int not null,
	fk_modulo int not null,
	fk_listaPrecio int not null,
	fk_tamañoEmpresa int not null
);

alter table Modulo_Precio add constraint fk_suscripcion2 foreign key (fk_suscripcion) references Suscripcion(idSuscripcion);
alter table Modulo_Precio add constraint fk_modulo2 foreign key (fk_modulo) references Modulo(codigoModulo);
alter table Modulo_Precio add constraint fk_listaPrecio foreign key (fk_listaPrecio) references ListaPrecio(idListaPrecio);
alter table Modulo_Precio add constraint fk_tamañoEmpresa2 foreign key (fk_tamañoEmpresa) references TamañoEmpresa(idTamañoEmpresa);


create table Puesto(
	idPuesto int identity(1,1) primary key not null,
	nombre varchar(45) not null, 
	descripcin text
);

create table UsuarioOperativo (
	cui int primary key not null,
	nombre varchar(45) not null,
	correoElectronico varchar(45) not null,	
	celular int not null,
	contraseña varchar(45) not null,
	fk_puesto int not null,
	fk_usuario int not null
);

alter table UsuarioOperativo add constraint fk_puesto foreign key(fk_puesto) references Puesto(idPuesto);
alter table UsuarioOperativo add constraint fk_usuario foreign key (fk_usuario) references Usuario(idUsuario);


create table AsignacionModulo (
	idAsignacionModulo int identity(1,1) primary key not null,
	fk_usuarioOperativo int not null,
	fk_codigoModulo int not null
);

alter table AsignacionModulo add constraint fk_usuarioOperativo foreign key (fk_usuarioOperativo) references UsuarioOperativo(cui);
alter table AsignacionModulo add constraint fk_Modulo foreign key (fk_codigoModulo) references Modulo(codigoModulo);


create table Proveedor(
	nit int primary key not null,
	nombre varchar(45) not null,
	direccion text not null,
	celular int not null,
	contacto varchar(45) not null,
	correoElectronico varchar(45) not null,
	limiteCredito decimal(5, 2)
);


alter table Proveedor add fk_UsuarioOperativo int not null;

alter table Proveedor add constraint fk_UserOperativo2 foreign key (fk_UsuarioOperativo) references UsuarioOperativo(cui);


create table Categoria (
	codigoCategoria int identity(1,1) primary key not null,
	abreviatura varchar(10) not null,
	descripcion text not null
);

create table Cliente (
	nit bigint primary key not null,
	nombre varchar(45) not null,
	direccion text not null,
	celular int not null,
	contacto varchar(45) not null,
	correoElectronico varchar(45) not null,
	fk_categoria int not null
);

alter table Cliente add constraint fk_categoriaCliente foreign key (fk_categoria) references Categoria(codigoCategoria);

alter table Cliente add fk_UsuarioOperativo int not null;

alter table Cliente add constraint fk_UserOperativo foreign key (fk_UsuarioOperativo) references UsuarioOperativo(cui);

create table Credito (
	idCredito int identity(1,1) primary key not null,
	limite decimal (5, 2) not null,
	dias int not null,
	fk_cliente bigint not null
);


alter table Credito add constraint fk_cliente2 foreign key (fk_cliente) references Cliente(nit);


create table Usuario_Modulo (
	idUsuarioModulo int identity(1,1) primary key not null,
	fk_usuario int not null,
	fk_modulo int not null
);

alter table Usuario_Modulo add constraint fk_UsuarioComprador foreign key (fk_usuario) references Usuario(idUsuario);
alter table Usuario_Modulo add constraint fk_ModuloComprado foreign key (fk_modulo) references Modulo(codigoModulo);




create table Clasificacion (
	idClasificacion int identity (1,1) primary key not null,
	nombre varchar(45) not null
);


create table Presentacion (
	idPresentacion int identity(1,1) primary key not null,
	nombre varchar(45) not null
);


create table Producto (
	codigoProducto int primary key not null,
	codigoBarra int not null,
	nombre varchar(45) not null,
	descripcion text,
	fk_presentacion int not null, 
	fk_clasificacion int not null,
	fk_usuarioOperativo int not null
);

alter table Producto add constraint fk_UsuarioOperativo2 foreign key (fk_usuarioOperativo) references UsuarioOperativo(cui);



create table Bodega(
	idBodega int primary key not null, 
	nombreBodega varchar(45) not null, 
	descripcion text,
	direccionFisica text not null,
	fk_usuarioOperativo int not null
);

alter table Bodega add constraint fk_UsuarioOperativo3 foreign key (fk_usuarioOperativo) references UsuarioOperativo(cui);

create table Pasillo(
	idPasillo int primary key not null,
	largo decimal(5,2) not null,
	ancho decimal(5,2) not null,
	fk_bodega int not null
);

alter table Pasillo add constraint fk_Bodega foreign key (fk_bodega) references Bodega(idBodega);

create table Estante(
	letra varchar(10) primary key not null,
	largo decimal(5,2) not null,
	ancho decimal(5,2) not null,
	alto decimal(5,2) not null,
	fk_pasillo int not null
);

alter table Estante add constraint fk_Pasillo foreign key (fk_pasillo) references Pasillo(idPasillo);

create table Nivel(
	idNivel int primary key not null, 
	fk_estante varchar(10) not null
);

alter table Nivel add constraint fk_Estante foreign key (fk_estante) references Estante(letra);