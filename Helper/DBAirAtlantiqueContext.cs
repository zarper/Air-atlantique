using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaltAirAtlantique.Model;

namespace MaltAirAtlantique.Helper
{
    //Gestion de la base de donnée en code first
    class DBAirAtlantiqueContext : DbContext
    {
        public DBAirAtlantiqueContext()
            :base("MaltAirAtlantique"){ }

        /// <summary>
        /// les formations dans la DB
        /// </summary>
        public DbSet<Formation> Formations { get; set; }

        /// <summary>
        /// les employees dans la DB
        /// </summary>
        public DbSet<Employee> Employees { get; set; }



        /// <summary>
        /// les organismes dans la DB
        /// </summary>
        public DbSet<Organisme> Organismes { get; set; }

        /// <summary>
        /// les postes dans la DB
        /// </summary>
        public DbSet<Poste> Postes { get; set; }

        public DbSet<EmployeeFormation> EmployeeFormation { get; set; }

        public DbSet<SessionEmployee> SessionEmployees { get; set; }
        /// <summary>
        /// les sessions dans la DB
        /// </summary>
        public DbSet<Session> Sessions { get; set; }

        /// <summary>
        /// les précisions prix et notes de la formation par rapport a l'organisme dans la DB
        /// </summary>
        public DbSet<OrganismeFormation> OrganismeFormation { get; set; }

        public DbSet<PosteFormation> PosteFormation{ get; set; }
    }
}

