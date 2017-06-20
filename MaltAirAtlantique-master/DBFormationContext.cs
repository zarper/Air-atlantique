using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaltAirAtlantique
{
    class DBFormationContext: DbContext
    {

        public DBFormationContext() : base("MaltAirAtlantique"){}

        /// <summary>
        /// les catalogues dans la DB
        /// </summary>
        public virtual DbSet<Catalogue> Catalogues { get; set; }

        /// <summary>
        /// les organismes dans la DB
        /// </summary>
        public virtual DbSet<Organisme> Organismes { get; set; }

        /// <summary>
        /// les sessions dans la DB
        /// </summary>
        public virtual DbSet<Session> Sessions { get; set; }

        /// <summary>
        /// les formations dans la DB
        /// </summary>
        public virtual DbSet<Formation> Formations { get; set; }

        /// <summary>
        /// les employees dans la DB
        /// </summary>
        public virtual DbSet<Employee> Employees { get; set; }


    }
}