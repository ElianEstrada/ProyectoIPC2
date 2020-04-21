﻿using Acceso_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class UsuarioOperativoLogic
    {

        UsuarioOperativoDA usuarioOperativoDA = new UsuarioOperativoDA();

        public bool verificarUsuarioOperativo(string email, string password)
        {

            foreach(var item in usuarioOperativoDA.listaUsuariosOperativos())
            {
                if(item.correoElectronico.Equals(email) && item.contraseña.Equals(password))
                {
                    return true;
                }
            }

            return false;
        }

    }
}
