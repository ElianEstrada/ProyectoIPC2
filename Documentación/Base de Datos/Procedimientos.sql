use fase3_proyecto;

create procedure listaUsuarios
as
begin
select * from Usuario as U
join TipoUsuario as TU
on U.fk_tipoUsuario = TU.idTipoUsuario;
end;


create procedure listaUsuariosOperativos
as
begin
select * from UsuarioOperativo as UO
join Usuario as U
on UO.fk_usuario = U.idUsuario;
end;

select * from UsuarioOperativo;

create procedure add_Bodega
@idBodega int, @nombre varchar(45), @descripcion text, @direccion text, @usuarioOperativo int
as
begin 
insert into Bodega(idBodega, nombreBodega, descripcion, direccionFisica, fk_usuarioOperativo) 
values(@idBodega, @nombre, @descripcion, @direccion, @usuarioOperativo);
end;

exec add_Bodega 2, 'Bodega2', 'Bodega de alimentos no perecederos', 'Direccion 2', 4; 

create procedure search_UsuarioOperativo_email
@email varchar(45)
as
begin
select UO.cui, UO.nombre, UO.correoElectronico, UO.celular, UO.contraseña, UO.fk_usuario, P.nombre as puesto, P.descripcin from UsuarioOperativo as UO
join Puesto as P
on UO.fk_puesto = P.idPuesto
where UO.correoElectronico = @email;
end;

select UO.cui, UO.nombre, UO.correoElectronico, UO.celular, UO.contraseña, UO.fk_usuario, P.nombre as puesto from UsuarioOperativo as UO
join Puesto as P
on UO.fk_puesto = P.idPuesto
where UO.correoElectronico = 'raul12@gmail.com';


exec search_UsuarioOperativo_email 'raul12@gmail.com';

select * from Bodega;


select * from Usuario_Modulo;

select * from UsuarioOperativo;

select * from Puesto;

create procedure show_Bodegas 
@idUsuario int
as
begin
select * from Bodega as B
join UsuarioOperativo as UO
on B.fk_usuarioOperativo = UO.cui
join Usuario as U
on UO.fk_usuario = U.idUsuario
where U.idUsuario = @idUsuario;
end;

exec show_Bodegas 2;


create procedure add_Pasillo
@idPasillo int, @largo decimal(5,2), @ancho decimal (5,2), @idBodega int
as
begin
insert into Pasillo (idPasillo, largo, ancho, fk_bodega) values (@idPasillo, @largo, @ancho, @idBodega);
end;

exec add_Pasillo 1, 6.5, 3, 1;

select * from Pasillo;

create procedure add_Estante
@letra varchar(10), @largo decimal(5,2), @ancho decimal(5,2), @alto decimal(5,2), @idPasillo int
as 
begin
insert into Estante (letra, largo, ancho, alto, fk_pasillo) values (@letra, @largo, @ancho, @alto, @idPasillo);
end;


exec add_Estante 'A', 3.25, 3, 2, 1;


select * from Estante;

create procedure add_Nivel
@idNivel int, @alto decimal(5,2), @letraEstante varchar(45)
as
begin 
insert into Nivel (idNivel, alto, fk_estante) values (@idNivel, @alto, @letraEstante);
end;

exec add_Nivel 1, 1, 'A';

select * from Nivel;

select * from UsuarioOperativo;


create procedure show_Pasillo
@idUsuario int
as 
begin 
select * from Pasillo as P
join Bodega as B
on P.fk_bodega = B.idBodega
join UsuarioOperativo as UO
on B.fk_usuarioOperativo = UO.cui
join Usuario as U
on UO.fk_usuario = U.idUsuario
where U.idUsuario = @idUsuario;
end;

exec show_Pasillo 2;

delete from Nivel;

alter table Nivel add alto decimal(5,2) not null;

select * from Bodega;

exec add_Bodega 3, 'Bodega 3', 'Bodega 3 nada mas', 'Dirección 3', 3;

exec add_Pasillo 3, 7, 2.5, 1;



exec show_Bodegas 3;


create procedure show_Estante
@idUsuario int
as
begin
select * from Estante as E
join Pasillo as P
on E.fk_pasillo = P.idPasillo
join Bodega as B
on P.fk_bodega = B.idBodega
join UsuarioOperativo as UO
on B.fk_usuarioOperativo = UO.cui
join Usuario as U
on UO.fk_usuario = U.idUsuario
where U.idUsuario = @idUsuario;
end;

exec show_Estante 2;


create procedure show_Nivel
@idUsuario int
as 
begin
select * from Nivel as N
join Estante as E
on N.fk_estante = E.letra
join Pasillo as P
on E.fk_pasillo = P.idPasillo
join Bodega as B
on P.fk_bodega = B.idBodega
join UsuarioOperativo as UO
on B.fk_usuarioOperativo = UO.cui
join Usuario as U
on UO.fk_usuario = U.idUsuario
where U.idUsuario = @idUsuario;
end;

exec show_Nivel 2;


create procedure updatePassword
@password varchar(45), @email varchar(45)
as
begin
update UsuarioOperativo set contraseña = @password where correoElectronico = @email;
end;

exec updatePassword 'R123', 'raul12@gmail.com';



select * from UsuarioOperativo;


create procedure add_Producto
@codigoProducto int, @codigoBarra int, @nombre varchar(45), @descripcion text, @presentacion int, @clasificacion int,
@usuarioOperativo int
as
begin
insert into Producto(codigoProducto, codigoBarra, nombre, descripcion, fk_presentacion, fk_clasificacion, fk_usuarioOperativo)
values (@codigoProducto, @codigoBarra, @nombre, @descripcion, @presentacion, @clasificacion, @usuarioOperativo);
end;


create procedure show_Proveedor
@idUsuario int
as
begin
select * from Proveedor as P
where P.pk_usuario = @idUsuario;
end;

create procedure entradaBodega
as
begin 
select * from EntradaBodega;
end;

select * from Bodega;

exec show_Proveedor 2;




create procedure show_Producto
@idUsuario int
as 
begin
select P.codigoProducto, P.codigoBarra, P.nombre as nombreProducto, P.descripcion,
C.nombre as nombreClasificacion, Pre.nombre as nombrePresentacion, U.idUsuario from Producto as P
join Clasificacion as C
on P.fk_clasificacion = C.idClasificacion
join Presentacion as Pre
on P.fk_presentacion = Pre.idPresentacion
join UsuarioOperativo as UO
on P.fk_usuarioOperativo = UO.cui
join Usuario as U
on UO.fk_usuario = U.idUsuario
where U.idUsuario = @idUsuario;
end;

exec show_Producto 3;

create procedure add_Entrada
@idEntrada int, @proveedor int, @fecha date, @usuarioOperativo int, @usuario int
as
begin
insert into EntradaBodega (idEntrada, fechaEntrada, fk_proveedor, fk_usuarioOperativo, fk_usuario)
values (@idEntrada, @fecha, @proveedor, @usuarioOperativo, @usuario);
end;

exec add_Entrada 1, 1234321, '2020-04-12', 1, 2;

select * from EntradaBodega;

delete from EntradaBodega;
delete from Detalle_Entrada;
delete from AsignacionNivel;

select * from TipoCosteo;
select * from LogicaLote;

insert into TipoCosteo values (1, 'Saldo');
insert into TipoCosteo values (2, 'Lote');

insert into LogicaLote values (1, 'UEPS');
insert into LogicaLote values (2, 'PEPS');

select * from Detalle_Entrada;
select * from Producto;

create procedure add_detalleEntrada
@precio decimal (5,2), @cantidad int, @producto int, @entrdad int, @costeo int, @logica int
as
begin
insert into Detalle_Entrada (precio, cantidad, subtotal, fk_producto, fk_entrada, fk_tipoCosteo, fk_logica, conteo)
values (@precio, @cantidad, (@precio*@cantidad), @producto, @entrdad, @costeo, @logica, 1);
end;

exec add_detalleEntrada 12.5, 68, 1, 1, 2, 2;

update Detalle_Entrada set conteo = 1 
where idDetalleEntrada between 1 and 4;

alter table Detalle_Entrada add conteo int;

create procedure existeProducto
@idProducto int, @idUsuario int, @idCosteo int, @idEntrada int
as
begin
select * from Producto as P
join Detalle_Entrada as DE
on DE.fk_producto = P.codigoProducto
join EntradaBodega as EB
on DE.fk_entrada = EB.idEntrada
join TipoContacto as TC
on DE.fk_tipoCosteo = TC.idTipoContacto
where P.codigoProducto = @idProducto
and EB.fk_usuario = @idUsuario
and TC.idTipoContacto = @idCosteo
and EB.idEntrada = @idEntrada;
end;


exec existeProducto 1, 2, 2, 2;


update Detalle_Entrada set precio = 6.85, cantidad += 20
where idDetalleEntrada = 1;

create procedure modificarPrecio
@precio decimal(5,2), @idDetalle int, @cantidad int
as
begin
update Detalle_Entrada set precio += @precio, cantidad += @cantidad, conteo += 1, subtotal += (@precio * @cantidad)
where idDetalleEntrada = @idDetalle;
end;

exec modificarPrecio 13.43, 24, 15;

create procedure modificarCantidad
@cantidad int, @idAsigancion int, @idDetalleEntrada int
as
begin
update AsignacionNivel set cantidad -= @cantidad
where idAsignacionNivel = @idAsigancion;
update Detalle_Entrada set cantidad -= @cantidad
where idDetalleEntrada = @idDetalleEntrada;
end;

exec modificarCantidad 7, 6, 27;

exec searchAsignacionNivel 1, 1;

create procedure show_DetalleEntrada
@idEntrada int
as
begin
select DE.idDetalleEntrada, De.precio, DE.cantidad, P.nombre, TC.nombreCosteo, LL.nombreLogica, DE.conteo from Detalle_Entrada as DE
join EntradaBodega EB
on DE.fk_entrada = EB.idEntrada
join Producto as P
on DE.fk_producto = P.codigoProducto
join TipoCosteo as TC
on DE.fk_tipoCosteo = TC.idTipoCosteo
left join LogicaLote as LL
on DE.fk_logica = LL.idLogica
where EB.idEntrada =@idEntrada;
end;

exec show_DetalleEntrada 4;

select * from LogicaLote;

select * from Detalle_Entrada;


select DE.cantidad - 0 as cantidad from Detalle_Entrada as DE
where DE.fk_producto = 1 and DE.fk_tipoCosteo = 1;


select DE.idDetalleEntrada, De.precio, DE.cantidad, P.nombre, TC.nombreCosteo, LL.nombreLogica, DE.conteo from Detalle_Entrada as DE
join EntradaBodega EB
on DE.fk_entrada = EB.idEntrada
join Producto as P
on DE.fk_producto = P.codigoProducto
join TipoCosteo as TC
on DE.fk_tipoCosteo = TC.idTipoCosteo
left join LogicaLote as LL
on DE.fk_logica = LL.idLogica
where EB.idEntrada =2;


select * from AsignacionNivel;

create procedure add_AsigancionNivel
@cantidad int, @nivel int, @detalle int
as
begin
insert into AsignacionNivel (cantidad, fk_nivel, fk_detalleEntrada)
values (@cantidad, @nivel, @detalle);
end;


select * from Nivel;


create procedure add_SalidaBodega
@idSalidaBodega int, @fecha date, @cliente int, @usuarioOperativo int, @usuario int
as
begin
insert into SalidaBodega(idSalidaBodega, fechaSalida, fk_cliente, fk_usuario, fk_usuarioOperativo)
values (@idSalidaBodega, @fecha,  @cliente, @usuario, @usuarioOperativo);
end;

select * from SalidaBodega;

select * from Cliente;

create procedure show_Cliente
@idUsuario int
as
begin
select * from Cliente as C
where C.pk_usuario = @idUsuario;
end;

exec show_Cliente 2;


select DISTINCT P.nombre, DE.precio, DE.cantidad from AsignacionNivel as AN
join Detalle_Entrada as DE
on AN.fk_detalleEntrada = DE.idDetalleEntrada
join Producto as P
on DE.fk_producto = P.codigoProducto;


Select * from Detalle_Entrada as DE
join Producto as P
on DE.fk_producto = P.codigoProducto;


select * from Detalle_Entrada as DE
join EntradaBodega as EB
on DE.fk_entrada = EB.idEntrada;




create procedure productoAsignados
@idUsuario int
as
begin
select P.codigoProducto, P.nombre as NombreProducto, sum(precio) as Precio, sum(conteo) as Conteo, Sum(cantidad) as Cantidad, Tc.nombreCosteo, 
LL.nombreLogica from Detalle_Entrada as DE
join Producto as P
on DE.fk_producto = P.codigoProducto
join TipoCosteo as TC
on DE.fk_tipoCosteo = TC.idTipoCosteo
left join LogicaLote as LL
on DE.fk_logica = LL.idLogica
join EntradaBodega as EB
on De.fk_entrada = EB.idEntrada
where EB.fk_usuario = @idUsuario
group by fk_producto, TC.nombreCosteo, P.nombre, P.codigoProducto, LL.nombreLogica;
end;


exec productoAsignados 2;


select P.codigoProducto, P.nombre,B.nombreBodega, Pa.idPasillo, E.letra, N.idNivel, AN.cantidad from AsignacionNivel as AN
join Nivel as N
on AN.fk_nivel = N.idNivel
join Detalle_Entrada as DE
on AN.fk_detalleEntrada = DE.idDetalleEntrada
join Producto as P
on DE.fk_producto = P.codigoProducto
join TipoCosteo as TC
on DE.fk_tipoCosteo = TC.idTipoCosteo
join EntradaBodega as EB
on DE.fk_entrada = EB.idEntrada
join Estante as E
on N.fk_estante = E.letra
join Pasillo as Pa
on E.fk_pasillo = Pa.idPasillo
join Bodega as B
on Pa.fk_bodega = B.idBodega
where TC.nombreCosteo = 'Saldo'
and EB.fk_usuario = 2
and P.codigoProducto = 3;

create procedure ubicaciones 
@idUsuario int, @idProducto int
as
begin
select B.nombreBodega, Pa.idPasillo, E.letra, N.idNivel, AN.cantidad from AsignacionNivel as AN
join Nivel as N
on AN.fk_nivel = N.idNivel
join Detalle_Entrada as DE
on AN.fk_detalleEntrada = DE.idDetalleEntrada
join Producto as P
on DE.fk_producto = P.codigoProducto
join TipoCosteo as TC
on DE.fk_tipoCosteo = TC.idTipoCosteo
join EntradaBodega as EB
on DE.fk_entrada = EB.idEntrada
join Estante as E
on N.fk_estante = E.letra
join Pasillo as Pa
on E.fk_pasillo = Pa.idPasillo
join Bodega as B
on Pa.fk_bodega = B.idBodega
where TC.nombreCosteo = 'Saldo'
and EB.fk_usuario = @idUsuario
and P.codigoProducto = @idProducto;
end;

select * from SalidaBodega;

select * from Detalle_Salida;

select * from AsignacionNivel as AN
join Nivel as N
on AN.fk_nivel = N.idNivel
join Detalle_Entrada as DE
on AN.fk_detalleEntrada = DE.idDetalleEntrada
where N.idNivel = 3
and DE.fk_producto = 1
and fk_tipoCosteo = 1;


create procedure add_DetalleSalida
@cantidad int, @salida int, @asignacionNivel int
as 
begin
insert into Detalle_Salida values(@cantidad, @salida, @asignacionNivel);
end;


exec add_DetalleSalida 12, 4, 7;

alter table Detalle_Salida add constraint FK_Asignacion foreign key (fk_asignacionNivel) references AsignacionNivel(idAsignacionNivel);


select * from AsignacionNivel;

create procedure searchAsignacionNivel 
@nivel int, @idProducto int
as
begin
select * from AsignacionNivel as AN
join Nivel as N
on AN.fk_nivel = N.idNivel
join Detalle_Entrada as DE
on AN.fk_detalleEntrada = DE.idDetalleEntrada
where N.idNivel = @nivel
and DE.fk_producto = @idProducto
and fk_tipoCosteo = 1;
end;

exec searchAsignacionNivel 3, 1;


create procedure buscarDetalle
@asignacion int
as
begin
select * from AsignacionNivel as AN
join Detalle_Entrada as DE
on AN.fk_detalleEntrada = DE.idDetalleEntrada
where AN.idAsignacionNivel = @asignacion;
end;

exec buscarDetalle 6;

select Pro.nombre as nombreProducto, DE.precio, P.idPasillo, E.letra, N.idNivel, TC.nombreCosteo, LL.nombreLogica from AsignacionNivel as AN
join Nivel as N
on AN.fk_nivel = N.idNivel
join Estante as E
on N.fk_estante = E.letra
join Pasillo as P
on E.fk_pasillo = P.idPasillo
join Bodega as B
on P.fk_bodega = B.idBodega
join Detalle_Entrada as DE
on AN.fk_detalleEntrada = DE.idDetalleEntrada
join Producto as Pro
on DE.fk_producto = Pro.codigoProducto
join EntradaBodega as EB
on DE.fk_entrada = EB.idEntrada
join TipoCosteo as TC
on DE.fk_tipoCosteo = TC.idTipoCosteo
left Join LogicaLote as LL
on DE.fk_logica = LL.idLogica
where B.idBodega = 1
and EB.fk_usuario = 2;

create procedure invetarioBodega
@idUsuario int, @idBodega int
as
begin
select Pro.nombre as nombreProducto, DE.precio, P.idPasillo, E.letra, N.idNivel, TC.nombreCosteo, LL.nombreLogica from AsignacionNivel as AN
join Nivel as N
on AN.fk_nivel = N.idNivel
join Estante as E
on N.fk_estante = E.letra
join Pasillo as P
on E.fk_pasillo = P.idPasillo
join Bodega as B
on P.fk_bodega = B.idBodega
join Detalle_Entrada as DE
on AN.fk_detalleEntrada = DE.idDetalleEntrada
join Producto as Pro
on DE.fk_producto = Pro.codigoProducto
join EntradaBodega as EB
on DE.fk_entrada = EB.idEntrada
join TipoCosteo as TC
on DE.fk_tipoCosteo = TC.idTipoCosteo
left Join LogicaLote as LL
on DE.fk_logica = LL.idLogica
where B.idBodega = @idBodega
and EB.fk_usuario = @idUsuario;
end;

exec invetarioBodega 2, 1;

select * from Producto as P
where P.codigoProducto = 1;

create procedure inventarioProducto
@idUsuario int, @codigoProducto int
as
begin
select P.codigoProducto, P.codigoBarra, P.nombre, AN.cantidad, DE.precio, N.idNivel, PA.idPasillo, E.letra, B.idBodega, TC.nombreCosteo, LL.nombreLogica from AsignacionNivel as AN
join Detalle_Entrada as DE
on AN.fk_detalleEntrada = DE.idDetalleEntrada
join EntradaBodega as EB
on DE.fk_entrada = EB.idEntrada
join Producto as P
on DE.fk_producto = P.codigoProducto
join TipoCosteo as TC
on DE.fk_tipoCosteo = TC.idTipoCosteo
LEFT join LogicaLote as LL
on DE.fk_logica = LL.idLogica
join Nivel as N
on AN.fk_nivel = N.idNivel
join Estante as E
on N.fk_estante = E.letra
join Pasillo as PA
on E.fk_pasillo = PA.idPasillo
join Bodega as B
on PA.fk_bodega = B.idBodega
where P.codigoProducto = @codigoProducto
and EB.fk_usuario = @idUsuario;
end;

exec inventarioProducto 2, 1;

select * from Producto;

select * from Detalle_Entrada as DE
join Producto as P 
on DE.fk_producto = P.codigoProducto
join EntradaBodega as EB
on DE.fk_entrada = EB.idEntrada
where P.codigoProducto = 1 
and EB.fk_usuario = 2;




