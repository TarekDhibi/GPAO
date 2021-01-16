using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fsg_gpao.Acteurs
{
    class Atelier
    {
        private int id;
        private String nom;
        private String description;
        private String specialite;
        public int ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }
        public String NOM
        {
            get
            {
                return this.nom;
            }
            set
            {
                this.nom = value;
            }
        }
        public String DESCRIPTION
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }
        public String SPECIALITE
        {
            get
            {
                return this.specialite;
            }
            set
            {
                this.specialite = value;
            }
        }
        public Atelier()
        {
            this.id = 0;
            this.nom = "";
            this.description = "";
            this.specialite = "";
        }
        public Atelier(int id)
        {
            this.id = id;
            this.nom = "";
            this.description = "";
            this.specialite = "";
        }
        public Atelier(int id, String nom)
        {
            this.id = id;
            this.nom = nom;
            this.description = "";
            this.specialite = "";
        }
        public Atelier(int id, String nom, String description)
        {
            this.id = id;
            this.nom = nom;
            this.description = description;
            this.specialite = "";
        }
        public Atelier(int id, String nom, String description, String specialite)
        {
            this.id = id;
            this.nom = nom;
            this.description = description;
            this.specialite = specialite;
        }
    }
}
