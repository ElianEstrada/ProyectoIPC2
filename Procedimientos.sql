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
