﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccesoDatos.Data.Repository.IRepository
{
    public interface IContenedorTrabajo : IDisposable
    {
        //Aqui se deben ir agregando los diferenteas repositorios
        ICategoriaRepository Categoria { get; }
        //IArticuloRepository Articulo { get; }
        void Save();

    }
}
