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



select * from UsuarioOperativo;