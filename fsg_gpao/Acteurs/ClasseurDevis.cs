using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fsg_gpao.Acteurs
{
    class ClasseurDevis
    {
        private int id;
        private int idAdmin;
        private int idClient;
        private String heure;
        private Boolean livraison;
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
        public int IDADMIN
        {
            get
            {
                return this.idAdmin;
            }
            set
            {
                this.idAdmin = value;
            }
        }
        public int IDCLIENT
        {
            get
            {
                return this.idClient;
            }
            set
            {
                this.idClient = value;
            }
        }
        public String HEURE
        {
            get
            {
                return this.heure;
            }
            set
            {
                this.heure = value;
            }
        }
        public Boolean LIVRAISON
        {
            get
            {
                return this.livraison;
            }
            set
            {
                this.livraison = value;
            }
        }
        public ClasseurDevis()
        {
            this.id = 0;
            this.idAdmin = 0;
            this.idClient = 0;
            this.heure = "";
            this.livraison = false;
        }
        public ClasseurDevis(int id)
        {
            this.id = id;
            this.idAdmin = 0;
            this.idClient = 0;
            this.heure = "";
            this.livraison = false;
        }
        public ClasseurDevis(int id, int idAdmin)
        {
            this.id = id;
            this.idAdmin = idAdmin;
            this.idClient = 0;
            this.heure = "";
            this.livraison = false;
        }
        public ClasseurDevis(int id, int idAdmin, int idClient)
        {
            this.id = id;
            this.idAdmin = idAdmin;
            this.idClient = idClient;
            this.heure = "";
            this.livraison = false;
        }
        public ClasseurDevis(int idAdmin, int idClient, String heure)
        {
            this.id = 0;
            this.idAdmin = idAdmin;
            this.idClient = idClient;
            this.heure = heure;
            this.livraison = false;
        }
        public ClasseurDevis(int id, int idAdmin, int idClient, String heure)
        {
            this.id = id;
            this.idAdmin = idAdmin;
            this.idClient = idClient;
            this.heure = heure;
            this.livraison = false;
        }
        public ClasseurDevis(int id, int idAdmin, int idClient, String heure, Boolean livraison)
        {
            this.id = id;
            this.idAdmin = idAdmin;
            this.idClient = idClient;
            this.heure = heure;
            this.livraison = livraison;
        }
    }
}
