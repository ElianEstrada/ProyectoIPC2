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
select * from UsuarioOperativo as UO
where UO.correoElectronico = @email;
end;

exec search_UsuarioOperativo_email 'raul12@gmail.com';

select * from Bodega;


select * from Usuario_Modulo;

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