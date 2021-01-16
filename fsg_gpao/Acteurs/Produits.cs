using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fsg_gpao.Acteurs
{
    class Produits
    {
        private int id;
        private String nom;
        private String cat;
        private String desc;
        private int quantite;
        private String prix;

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
        public String DESC
        {
            get
            {
                return this.desc;
            }
            set
            {
                this.desc = value;
            }
        }
        public String CAT
        {
            get
            {
                return this.cat;
            }
            set
            {
                this.cat = value;
            }
        }
        public int QUANTITE
        {
            get
            {
                return this.quantite;
            }
            set
            {
                this.quantite = value;
            }
        }
        public String PRIX
        {
            get
            {
                return this.prix;
            }
            set
            {
                this.prix = value;
            }
        }
        #endregion
        #region constructeurs

        public Produits ()
        {
            this.id = 0;
            this.nom = "";
            this.cat = "";
            this.desc = "";
            this.quantite = 0;
            this.prix = "0";
        }
        public Produits(int id)
        {
            this.id = id;
            this.nom = "";
            this.cat = "";
            this.desc = "";
            this.quantite = 0;
            this.prix = "0";
        }
        public Produits(int id, String nom)
        {
            this.id = id;
            this.nom = nom;
            this.cat = "";
            this.desc = "";
            this.quantite = 0;
            this.prix = "0";
        }
        public Produits(int id, String nom, String cat)
        {
            this.id = id;
            this.nom = nom;
            this.cat = cat;
            this.desc = "";
            this.quantite = 0;
            this.prix = "0";
        }
        public Produits(int id, String nom, String cat, String desc)
        {
            this.id = id;
            this.nom = nom;
            this.cat = cat;
            this.desc = desc;
            this.quantite = 0;
            this.prix = "0";
        }

        public Produits(int id, String nom, String cat, String desc, int quantite)
        {
            this.id = id;
            this.nom = nom;
            this.cat = cat;
            this.desc = desc;
            this.quantite = quantite;
            this.prix = "0";
        }
        public Produits(int id, String nom, String cat, String desc, int quantite, String prix)
        {
            this.id = id;
            this.nom = nom;
            this.cat = cat;
            this.desc = desc;
            this.quantite = quantite;
            this.prix = prix;
        }
        #endregion
    }
}
