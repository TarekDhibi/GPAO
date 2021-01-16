using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fsg_gpao.Acteurs
{
    class Fournisseur
    {
         #region porpriétés
        private int id;
        private string nom;
        private string telephone;
        private string adresse;
        private string specialite;
        private Boolean etat;

        #endregion

        #region Getter & Setter
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
        public string NOM
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
        public string TELEPHONE
        {
            get
            {
                return this.telephone;
            }
            set
            {
                this.telephone = value;
            }
        }
        public string ADRESSE
        {
            get
            {
                return this.adresse;
            }
            set
            {
                this.adresse = value;
            }
        }

        public string SPECIALITE
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


        public Boolean ETAT
        {
            get
            {
                return this.etat;
            }
            set
            {
                this.etat = value;
            }
        }

        #endregion

        #region constructeurs

        public Fournisseur()
        {
            this.id = 0;
            this.nom = "";
            this.telephone = "";
            this.adresse = "";
            this.specialite = "";
            this.etat = false;

        }
        public Fournisseur(int id)
        {
            this.id = id;
            this.nom = "";
            this.telephone = "";
            this.adresse = "";
            this.specialite = "";
            this.etat = false;

        }

        public Fournisseur(int id, string nom)
        {
            this.id = id;
            this.nom = nom;
            this.telephone = "";
            this.adresse = "";
            this.specialite = "";
            this.etat = false;

        }
        public Fournisseur(string nom, string adresse)
        {
            this.id = 0;
            this.nom = nom;
            this.telephone = "";
            this.adresse = adresse;
            this.specialite = "";
            this.etat = false;

        }
        public Fournisseur(int id, string nom, string telephone, string adresse)
        {
            this.id = id;
            this.nom = nom;
            this.telephone = telephone;
            this.adresse = adresse;
            this.specialite = "";
            this.etat = false;

        }
        public Fournisseur(int id, string nom, string telephone, string adresse, string service)
        {
            this.id = id;
            this.nom = nom;
            this.telephone = telephone;
            this.adresse = adresse;
            this.specialite = service;
            this.etat = false;

        }
        public Fournisseur(int id, string nom, string telephone, string adresse, string service, bool etat)
        {
            this.id = id;
            this.nom = nom;
            this.telephone = telephone;
            this.adresse = adresse;
            this.specialite = service;
            this.etat = etat;

        }
        #endregion

    }
}
