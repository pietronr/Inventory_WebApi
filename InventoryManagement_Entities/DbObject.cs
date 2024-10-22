﻿using System;

namespace InventoryManagement.Entities
{
    public abstract class DbObject
    {
        /// <summary>
        /// Obtém ou define o ID no banco de dados.
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// Representa uma entidade rastreável do banco de dados.
    /// </summary>
    public abstract class Traceable : DbObject
    {
        /// <summary>
        /// Obtém ou define a data de criação da entidade.
        /// </summary>
        public DateTime? CreationDate { get; set; }

        /// <summary>
        /// Obtém ou define a última data de modificação da entidade.
        /// </summary>
        public DateTime? LastWriteDate { get; set; }
    }
}
