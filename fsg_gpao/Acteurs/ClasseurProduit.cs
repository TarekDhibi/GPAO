using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fsg_gpao.Acteurs
{
    class ClasseurProduit
    {
        private int id;
        private int idFactureProduction;
        private int idProduit;
        private int nbEx;
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
        public int IDFACTUREPRODUCTION
        {
            get
            {
                return this.idFactureProduction;
            }
            set
            {
                this.idFactureProduction = value;
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
        public ClasseurProduit()
        {
            this.id = 0;
            this.idFactureProduction = 0;
            this.idProduit = 0;
            this.nbEx = 0;
        }
        public ClasseurProduit(int id)
        {
            this.id = id;
            this.idFactureProduction = 0;
            this.idProduit = 0;
            this.nbEx = 0;
        }
        public ClasseurProduit(int id, int idFacture)
        {
            this.id = id;
            this.idFactureProduction = idFacture;
            this.idProduit = 0;
            this.nbEx = 0;
        }
        public ClasseurProduit(int id, int idFacture, int idpoduit)
        {
            this.id = id;
            this.idFactureProduction = idFacture;
            this.idProduit = idpoduit;
            this.nbEx = 0;
        }
        public ClasseurProduit(int id, int idFacture, int idpoduit, int nbex)
        {
            this.id = id;
            this.idFactureProduction = idFacture;
            this.idProduit = idpoduit;
            this.nbEx = nbex;
        }
    }
}
