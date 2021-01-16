using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fsg_gpao.Acteurs
{
    class ClasseurVente
    {
        private int id;
        private int idAdmin;
        private int idClient;
        private String heure;
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
        public ClasseurVente()
        {
            this.id = 0;
            this.idAdmin = 0;
            this.idClient = 0;
            this.heure = "";
        }
        public ClasseurVente(int id)
        {
            this.id = id;
            this.idAdmin = 0;
            this.idClient = 0;
            this.heure = "";
        }
        public ClasseurVente(int id, int idAdmin)
        {
            this.id = id;
            this.idAdmin = idAdmin;
            this.idClient = 0;
            this.heure = "";
        }
        public ClasseurVente(int id, int idAdmin, int idClient)
        {
            this.id = id;
            this.idAdmin = idAdmin;
            this.idClient = idClient;
            this.heure = "";
        }
        public ClasseurVente(int idAdmin, int idClient, String heure)
        {
            this.id = 0;
            this.idAdmin = idAdmin;
            this.idClient = idClient;
            this.heure = heure;
        }
        public ClasseurVente(int id, int idAdmin, int idClient, String heure)
        {
            this.id = id;
            this.idAdmin = idAdmin;
            this.idClient = idClient;
            this.heure = heure;
        }
    }
}
