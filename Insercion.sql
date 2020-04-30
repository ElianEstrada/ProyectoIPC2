use fase3_proyecto;

insert into Clasificacion(nombre) values ('Alimentos');

insert into Presentacion (nombre) values('En Polvo');

insert into Producto(codigoProducto, codigoBarra, nombre,  fk_clasificacion, fk_presentacion) 
values(1, 0011221, 'Leche', 1, 1);

select P.codigoProducto, P.nombre, C.nombre, Pr.nombre from Producto as P
join Clasificacion as C
on P.fk_clasificacion = C.idClasificacion
join Presentacion as Pr
on P.fk_presentacion = Pr.idPresentacion;

insert into TipoEmpresa (nombre) values ('Comercial');
insert into TipoEmpresa (nombre) values ('Financiera');
insert into TipoEmpresa (nombre) values ('Servicios');


select * from TipoEmpresa;

insert into TamañoEmpresa values ('1 - 10');
insert into TamañoEmpresa values ('11 - 20');
insert into TamañoEmpresa values ('21 - 30');
insert into TamañoEmpresa values ('31 - 40');
insert into TamañoEmpresa values ('41 - 50');
insert into TamañoEmpresa values ('50 o mas');

update TamañoEmpresa set nombre = '11 - 15' where idTamañoEmpresa = 2;
update TamañoEmpresa set nombre = '16 - 25' where idTamañoEmpresa = 3;
update TamañoEmpresa set nombre = '26 - 40' where idTamañoEmpresa = 4;
update TamañoEmpresa set nombre = '41 - 50' where idTamañoEmpresa = 5;

select * from TamañoEmpresa;

insert into TipoTarjeta values ('Master Card');
insert into TipoTarjeta values ('Visa');
insert into TipoTarjeta values ('SiCard');
insert into TipoTarjeta values ('American Express');

select * from TipoTarjeta;

insert into Suscripcion values ('Anual');
insert into Suscripcion values ('Mensual');

insert into TipoModulo values ('Default');
insert into TipoModulo values ('Normal');

insert into TipoContacto values ('Comercial', 'Se encarga de los pagos');
insert into TipoContacto values ('General', 'Se encarga de la toma de desiciones');
insert into TipoContacto values ('Administrador', 'Se encarga del manejo del sistema');

insert into TipoUsuario values ('Administrador del Sistema');
insert into TipoUsuario values ('Administrador de Servicio');


insert into ClientePYME(nit, nombreEmpresa, fk_tipoEmpresa, fk_tamañoEmpresa, fk_suscripcion) values (1234567, 'LibreriaH45', 3, 1, 2);
insert into ClientePYME(nit, nombreEmpresa, fk_tipoEmpresa, fk_tamañoEmpresa, fk_suscripcion) values (5645789, 'Madera Fina Editorial', 1, 5, 1);
insert into ClientePYME(nit, nombreEmpresa, fk_tipoEmpresa, fk_tamañoEmpresa, fk_suscripcion) values (8987845, 'Carpineria Estrada', 3, 1, 2);
insert into ClientePYME(nit, nombreEmpresa, fk_tipoEmpresa, fk_tamañoEmpresa, fk_suscripcion) values (1245856, 'Mi Perro feliz', 3, 3, 1);
insert into ClientePYME(nit, nombreEmpresa, fk_tipoEmpresa, fk_tamañoEmpresa, fk_suscripcion) values (5463255, 'Tacos el alboroto', 1, 2, 2);
insert into ClientePYME(nit, nombreEmpresa, fk_tipoEmpresa, fk_tamañoEmpresa, fk_suscripcion) values (7895485, 'Estomago lleno corazon contento', 1, 6, 1);
insert into ClientePYME(nit, nombreEmpresa, fk_tipoEmpresa, fk_tamañoEmpresa, fk_suscripcion) values (1548468, 'Flora Divina', 1, 4, 1);

select * from ClientePYME;

select * from ClientePYME
JOIN Suscripcion
on ClientePYME.fk_Suscripcion = Suscripcion.idSuscripcion
where Suscripcion.idSuscripcion = 1;

select * from ClientePyme as CP
Join TamañoEmpresa as TE
on CP.fk_tamañoEmpresa = TE.idTamañoEmpresa
where TE.idTamañoEmpresa = 1;

select nit from clientePyme;

insert into TarjetaCredito(numeroTarjeta, nombreTarjeta, fechaVencimiento, crv, fk_tipoTarjeta, fk_ClientePyme) values (12365498, 'Elian Estrada', '2025-08-26', 358, 1, 1234567);
insert into TarjetaCredito(numeroTarjeta, nombreTarjeta, fechaVencimiento, crv, fk_tipoTarjeta, fk_ClientePyme) values (45648984, 'Alex Mendez', '2021-03-12', 365, 2,5463255);
insert into TarjetaCredito(numeroTarjeta, nombreTarjeta, fechaVencimiento, crv, fk_tipoTarjeta, fk_ClientePyme) values (12313155, 'Daniel Velásquez', '2027-06-01', 485, 3,7895485);
insert into TarjetaCredito(numeroTarjeta, nombreTarjeta, fechaVencimiento, crv, fk_tipoTarjeta, fk_ClientePyme) values (45874869, 'Allan Estrada', '2020-09-29', 151, 1,1245856);
insert into TarjetaCredito(numeroTarjeta, nombreTarjeta, fechaVencimiento, crv, fk_tipoTarjeta, fk_ClientePyme) values (32158868, 'Daniel Morales', '2022-01-31', 958, 2,8987845);

select * from tarjetaCredito;


select * from ClientePyme as CP
Join tarjetaCredito as TC
on TC.fk_clientepyme = CP.nit
join TamañoEmpresa as TE
on CP.fk_tamañoEmpresa = TE.idTamañoEmpresa
where TE.idtamañoempresa = 1;

select ClientePYME.nit, ClientePYME.nombreEmpresa from ClientePYME;


insert into Contacto (cui, nombreContacto, telefonoCelular, telefonoOficina, extension, correoElectronico, direccionOficina, fk_clientePyme, fk_tipoContacto)
values (30343661, 'Alex Mendez', 32654578, 12453245,'502', 'afm84@gmail.com', '13 Calle 15Av. Zona 2', 1245856, 1);
insert into Contacto (cui, nombreContacto, telefonoCelular, telefonoOficina, extension, correoElectronico, direccionOficina, fk_clientePyme, fk_tipoContacto)
values (12345678, 'Marco Solis', 32654578, 12453245,'502', 'afm84@gmail.com', '13 Calle 15Av. Zona 2', 1245856, 2);
insert into Contacto (cui, nombreContacto, telefonoCelular, telefonoOficina, extension, correoElectronico, direccionOficina, fk_clientePyme, fk_tipoContacto)
values (12345178, 'Aris Varela', 32654578, 12453245,'502', 'afm84@gmail.com', '13 Calle 15Av. Zona 2', 1234567, 1);
insert into Contacto (cui, nombreContacto, telefonoCelular, telefonoOficina, extension, correoElectronico, direccionOficina, fk_clientePyme, fk_tipoContacto)
values (32656494, 'Madelyn Mendoza', 32654578, 12453245,'502', 'afm84@gmail.com', '13 Calle 15Av. Zona 2', 1234567, 3);
insert into Contacto (cui, nombreContacto, telefonoCelular, telefonoOficina, extension, correoElectronico, direccionOficina, fk_clientePyme, fk_tipoContacto)
values (15784815, 'Delia Mendoza', 32654578, 12453245,'502', 'afm84@gmail.com', '13 Calle 15Av. Zona 2', 1234567, 2);
insert into Contacto (cui, nombreContacto, telefonoCelular, telefonoOficina, extension, correoElectronico, direccionOficina, fk_clientePyme, fk_tipoContacto)
values (35153154, 'Ana Castro', 32654578, 12453245,'502', 'afm84@gmail.com', '13 Calle 15Av. Zona 2', 1245856, 3);
insert into Contacto (cui, nombreContacto, telefonoCelular, telefonoOficina, extension, correoElectronico, direccionOficina, fk_clientePyme, fk_tipoContacto)
values (256457845, 'Ricardo Milos', 32654578, 12453245,'502', 'afm84@gmail.com', '13 Calle 15Av. Zona 2', 1245856, 3);

select * from Contacto;

select Cp.nombreEmpresa, c.nombreContacto, TC.nombre from ClientePYME as CP
Join Contacto as C
on C.fk_clientePyme = CP.nit
join TipoContacto as TC
on C.fk_tipoContacto = Tc.idTipoContacto;



insert into Usuario (nombreUsuario, contraseña, fk_Contacto, fk_tipoUsuario)
values ('Eliadelyn', 'pinponpan', 32656494, 2);

insert into Usuario (nombreUsuario, contraseña, fk_Contacto, fk_tipoUsuario)
values ('anita_Castro', '1234', 35153154, 2);

insert into Usuario (nombreUsuario, contraseña, fk_tipoUsuario) values ('Admin', 'Admin', 1);

select * from Usuario;


insert into Modulo(codigoModulo, nombre, abreviatura, fk_tipoModulo) values (1, 'Inventario', 'Inv', 2);
insert into Modulo(codigoModulo, nombre, abreviatura, fk_tipoModulo) values (2, 'Compras', 'Com', 1);
insert into Modulo(codigoModulo, nombre, abreviatura, fk_tipoModulo) values (3, 'Ventas', 'Ven', 1);
insert into Modulo(codigoModulo, nombre, abreviatura, fk_tipoModulo) values (4, 'Blog', 'Bl', 2);
insert into Modulo(codigoModulo, nombre, abreviatura, fk_tipoModulo) values (5, 'Facturacion', 'Fac', 2);

select * from Modulo;

insert into ListaPrecio (fechaInicio, fechaFin) values ('2020-04-02', '2020-05-02');

insert into Modulo_Precio (Precio, fk_suscripcion, fk_listaPrecio, fk_tamañoEmpresa, fk_modulo)
values (6.5, 2, 1, 2, 1);
insert into Modulo_Precio (Precio, fk_suscripcion, fk_listaPrecio, fk_tamañoEmpresa, fk_modulo)
values (16.5, 1, 1, 2, 1);
insert into Modulo_Precio (Precio, fk_suscripcion, fk_listaPrecio, fk_tamañoEmpresa, fk_modulo)
values (5.0, 2, 1, 2, 2);
insert into Modulo_Precio (Precio, fk_suscripcion, fk_listaPrecio, fk_tamañoEmpresa, fk_modulo)
values (12.75, 1, 1, 2, 2);
insert into Modulo_Precio (Precio, fk_suscripcion, fk_listaPrecio, fk_tamañoEmpresa, fk_modulo)
values (7.5, 2, 1, 2, 3);
insert into Modulo_Precio (Precio, fk_suscripcion, fk_listaPrecio, fk_tamañoEmpresa, fk_modulo)
values (21.75, 1, 1, 2, 3);
insert into Modulo_Precio (Precio, fk_suscripcion, fk_listaPrecio, fk_tamañoEmpresa, fk_modulo)
values (6.25, 2, 1, 2, 4);


select * from Modulo_Precio;

select M.nombre, Mp.Precio, S.nombre as Suscripcion, Te.nombre as TamañoEmpresa from Modulo_Precio as MP
join Suscripcion as S
on mp.fk_suscripcion = s.idSuscripcion
join Modulo as M
on Mp.fk_modulo = m.codigoModulo
join TamañoEmpresa as TE
on Mp.fk_tamañoEmpresa = TE.idTamañoEmpresa
where S.nombre = 'Mensual'
order by M.nombre;


insert into Puesto (nombre) values ('Vendedor');
insert into Puesto (nombre) values ('Comprador');

insert into UsuarioOperativo (cui, nombre, correoElectronico, celular, contraseña, fk_puesto, fk_usuario)
values (1, 'Raul', 'raul12@gmail.com', 35654578, 'R123', 1, 2);
insert into UsuarioOperativo (cui, nombre, correoElectronico, celular, contraseña, fk_puesto, fk_usuario)
values (2, 'Javier', 'javier12@gmail.com', 45789865, 'J123',2, 1);
insert into UsuarioOperativo (cui, nombre, correoElectronico, celular, contraseña, fk_puesto, fk_usuario)
values (3, 'Saul', 'saul15@gmail.com', 45789854, 'S123', 1,1);
insert into UsuarioOperativo (cui, nombre, correoElectronico, celular, contraseña, fk_puesto, fk_usuario)
values (4, 'Tono', 'tono14@gmail.com', 56457845,  'T123',2,2);

select * from UsuarioOperativo;


select * from Presentacion;

insert into Presentacion values ('Litro');
insert into Presentacion values ('Gramo');
insert into Presentacion values ('KiloGramo');
insert into Presentacion values ('Metro');

insert into Clasificacion values ('Comida');
insert into Clasificacion values ('Bebida');
insert into Clasificacion values ('Tela');

select * from UsuarioOperativo;

exec add_Producto 1, 123, 'Producto1', 'Es el Producto 1', 1, 2, 1;
select * from Producto;


exec add_Producto 2, 123, 'Producto2', 'Es el Producto 2', 1, 2, 1;
exec add_Producto 3, 123, 'Producto3', 'Es el Producto 3', 1, 2, 1;
exec add_Producto 4, 123, 'Producto4', 'Es el Producto 4', 1, 2, 1;
exec add_Producto 5, 123, 'Producto5', 'Es el Producto 5', 1, 2, 1;
exec add_Producto 6, 123, 'Producto6', 'Es el Producto 6', 1, 2, 1;
exec add_Producto 7, 123, 'Producto7', 'Es el Producto 7', 1, 2, 1;
exec add_Producto 8, 123, 'Producto8', 'Es el Producto 8', 1, 2, 1;
exec add_Producto 9, 123, 'Producto9', 'Es el Producto 9', 1, 2, 1;
exec add_Producto 10, 123, 'Producto10', 'Es el Producto 10', 2, 1, 1;
exec add_Producto 11, 123, 'Producto11', 'Es el Producto 11', 2, 1, 1;
exec add_Producto 12, 123, 'Producto12', 'Es el Producto 12', 2, 1, 1;
exec add_Producto 13, 123, 'Producto13', 'Es el Producto 13', 2, 1, 1;
exec add_Producto 14, 123, 'Producto14', 'Es el Producto 14', 2, 1, 1;
exec add_Producto 15, 123, 'Producto15', 'Es el Producto 15', 2, 1, 2;
exec add_Producto 16, 123, 'Producto16', 'Es el Producto 16', 3, 1, 2;
exec add_Producto 17, 123, 'Producto17', 'Es el Producto 17', 3, 1, 2;
exec add_Producto 18, 123, 'Producto18', 'Es el Producto 18', 3, 1, 2;
exec add_Producto 19, 123, 'Producto19', 'Es el Producto 19', 3, 1, 2;
exec add_Producto 20, 123, 'Producto20', 'Es el Producto 20', 3, 1, 2;
exec add_Producto 21, 123, 'Producto21', 'Es el Producto 21', 4, 3, 2;
exec add_Producto 22, 123, 'Producto22', 'Es el Producto 22', 4, 3, 2;
exec add_Producto 23, 123, 'Producto23', 'Es el Producto 23', 4, 3, 2;
exec add_Producto 24, 123, 'Producto24', 'Es el Producto 24', 4, 3, 2;
exec add_Producto 25, 123, 'Producto25', 'Es el Producto 25', 4, 3, 2;


select * from Proveedor;

insert into Proveedor values(3214565, 'Tortrix', 'Direccion 1', 36542544, 'Contacto1', 'correo1@gmail.com', 520, 1, 2);
insert into Proveedor values(3214123, 'Pepsi', 'Direccion 2', 45124565, 'Contacto2', 'correo2@gmail.com', 654.5, 1,2);

insert into Proveedor values(3214565, 'Tortrix', 'Direccion 1', 36542544, 'Contacto1', 'correo1@gmail.com', 520, 2, 3);
insert into Proveedor values(3214123, 'Pepsi', 'Direccion 2', 45124565, 'Contacto2', 'correo2@gmail.com', 654.5, 2,3);

