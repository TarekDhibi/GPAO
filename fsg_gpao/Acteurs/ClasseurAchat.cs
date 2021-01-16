using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fsg_gpao.Acteurs
{
    class ClasseurAchat
    {
        private int id;
        private int idAdmin;
        private int idFournisseur;
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
        public int IDFOURNISSEUR
        {
            get
            {
                return this.idFournisseur;
            }
            set
            {
                this.idFournisseur = value;
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
        public ClasseurAchat()
        {
            this.id = 0;
            this.idAdmin = 0;
            this.idFournisseur = 0;
            this.heure = "";
        }
        public ClasseurAchat(int id)
        {
            this.id = id;
            this.idAdmin = 0;
            this.idFournisseur = 0;
            this.heure = "";
        }
        public ClasseurAchat(int id, int idAdmin)
        {
            this.id = id;
            this.idAdmin = idAdmin;
            this.idFournisseur = 0;
            this.heure = "";
        }
        public ClasseurAchat(int id, int idAdmin, int idClient)
        {
            this.id = id;
            this.idAdmin = idAdmin;
            this.idFournisseur = idClient;
            this.heure = "";
        }
        public ClasseurAchat(int idAdmin, int idClient, String heure)
        {
            this.id = 0;
            this.idAdmin = idAdmin;
            this.idFournisseur = idClient;
            this.heure = heure;
        }
        public ClasseurAchat(int id, int idAdmin, int idClient, String heure)
        {
            this.id = id;
            this.idAdmin = idAdmin;
            this.idFournisseur = idClient;
            this.heure = heure;
        }
    }
}
