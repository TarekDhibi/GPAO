using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fsg_gpao.Acteurs
{
    class Achat
    {
        private int id;
        private int idClasseur;
        private int idProduit;
        private int nbEx;
        private int prix;
        private int remise;
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
        public int IDCLASSEUR
        {
            get
            {
                return this.idClasseur;
            }
            set
            {
                this.idClasseur = value;
            }
        }
        public int IDPRODUIT
        {
            get
            {
                return this.idProduit;
            }
            set
            {
                this.idProduit = value;
            }
        }
        public int NBEX
        {
            get
            {
                return this.nbEx;
            }
            set
            {
                this.nbEx = value;
            }
        }
        public int PRIX
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
        public int REMISE
        {
            get
            {
                return this.remise;
            }
            set
            {
                this.remise = value;
            }
        }
        public Achat()
        {
            this.id = 0;
            this.idProduit = 0;
            this.nbEx = 0;
            this.prix = 0;
            this.remise = 0;
        }
        public Achat(int id)
        {
            this.id = id;
            this.idClasseur = 0;
            this.idProduit = 0;
            this.nbEx = 0;
            this.prix = 0;
            this.remise = 0;
        }
        public Achat(int id, int idClasseur)
        {
            this.id = id;
            this.idClasseur = idClasseur;
            this.idProduit = 0;
            this.nbEx = 0;
            this.prix = 0;
            this.remise = 0;
        }
        public Achat(int id, int idClasseur, int idArticle)
        {
            this.id = id;
            this.idClasseur = idClasseur;
            this.idProduit = idArticle;
            this.nbEx = 0;
            this.prix = 0;
            this.remise = 0;
        }
        public Achat(int id, int idClasseur, int idArticle, int nbEx)
        {
            this.id = id;
            this.idClasseur = idClasseur;
            this.idProduit = idArticle;
            this.nbEx = nbEx;
            this.prix = 0;
            this.remise = 0;
        }
        public Achat(int id, int idClasseur, int idArticle, int nbEx, int prix)
        {
            this.id = id;
            this.idClasseur = idClasseur;
            this.idProduit = idArticle;
            this.nbEx = nbEx;
            this.prix = prix;
            this.remise = 0;
        }
        public Achat(int id, int idClasseur, int idArticle, int nbEx, int prix, int remise)
        {
            this.id = id;
            this.idClasseur = idClasseur;
            this.idProduit = idArticle;
            this.nbEx = nbEx;
            this.prix = prix;
            this.remise = remise;
        }
    }
}
