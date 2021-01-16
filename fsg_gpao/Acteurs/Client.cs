using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fsg_gpao.Acteurs
{
    class Client
    {
        #region proprietes
        private int id;
        private String nom;
        private String adresse;
        private String tel;
        private String remarque;
        private Boolean etat;
        #endregion
        #region get & set
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
        public String ADRESSE
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
        public String TEL
        {
            get
            {
                return this.tel;
            }
            set
            {
                this.tel = value;
            }
        }
        public String Remarque
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
        public Client()
        {
            this.id = 1;
            this.nom = "Passager";
            this.adresse = "-----------";
            this.tel = "-----------";
            this.remarque = "-----------";
            this.etat = true;
        }
        public Client(int id)
        {
            this.id = id;
            this.nom = "";
            this.adresse = "";
            this.tel = "";
            this.remarque = "";
            this.etat = false;
        }
        public Client(int id, String nom)
        {
            this.id = id;
            this.nom = nom;
            this.adresse = "";
            this.tel = "";
            this.remarque = "";
            this.etat = false;
        }
        public Client(int id, String nom, String adresse)
        {
            this.id = id;
            this.nom = nom;
            this.adresse = adresse;
            this.tel = "";
            this.remarque = "";
            this.etat = false;
        }
        public Client(int id, String nom, String adresse, String tel)
        {
            this.id = id;
            this.nom = nom;
            this.adresse = adresse;
            this.tel = tel;
            this.remarque = "";
            this.etat = false;
        }
        public Client(int id, String nom, String adresse, String tel, String remarque)
        {
            this.id = id;
            this.nom = nom;
            this.adresse = adresse;
            this.tel = tel;
            this.remarque = remarque;
            this.etat = false;
        }
        public Client(int id, String nom, String adresse, String tel, String remarque, Boolean etat)
        {
            this.id = id;
            this.nom = nom;
            this.adresse = adresse;
            this.tel = tel;
            this.remarque = remarque;
            this.etat = etat;
        }
        #endregion
    }
}
