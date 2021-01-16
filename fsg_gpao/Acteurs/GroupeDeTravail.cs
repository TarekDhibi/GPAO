using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fsg_gpao.Acteurs
{
    class GroupeDeTravail
    {
        private int id;
        private String nom;
        private String prenom;
        private int idAtelier;
        private String date;
        private String remarque;
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
        public String PRENOM
        {
            get
            {
                return this.prenom;
            }
            set
            {
                this.prenom = value;
            }
        }
        public int IDATELIER
        {
            get
            {
                return this.idAtelier;
            }
            set
            {
                this.idAtelier = value;
            }
        }
        public String DATE
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }
        public String REMARQUE
        {
            get
            {
                return this.remarque;
            }
            set
            {
                this.remarque = value;
            }
        }
        public GroupeDeTravail()
        {
            this.id = 0;
            this.nom = "";
            this.prenom = "";
            this.idAtelier = 0;
            this.date = "";
            this.remarque = "";
        }
        public GroupeDeTravail(int id)
        {
            this.id = id;
            this.nom = "";
            this.prenom = "";
            this.idAtelier = 0;
            this.date = "";
            this.remarque = "";
        }
        public GroupeDeTravail(int id, String nom,String prenom )
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.idAtelier = 0;
            this.date = "";
            this.remarque = "";
        }
        public GroupeDeTravail(int id, String nom, String prenom, int idAtelier)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.idAtelier = idAtelier;
            this.date = "";
            this.remarque = "";
        }
        public GroupeDeTravail(int id, String nom, String prenom, int idAtelier, String date)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.idAtelier = idAtelier;
            this.date = date;
            this.remarque = "";
        }
        public GroupeDeTravail(int id, String nom, String prenom, int idAtelier, String date, String remarque)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.idAtelier = idAtelier;
            this.date = date;
            this.remarque = remarque;
        }
    }
}
