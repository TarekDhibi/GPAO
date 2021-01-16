using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fsg_gpao.Acteurs
{
    class JournalAchat
  {
         #region proprietes

        private int id;
        private int idAdmin;
        private int idProd;
        private int idProduit;
        private String heure;
        private String action;
        private String remarque;

        #endregion

        #region getter and setter

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

        public int IDPROD
        {
            get
            {
                return this.idProd;
            }
            set
            {
                this.idProd = value;
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

        public String ACTION
        {
             get
            {
                return this.action;
            }
             set
            {
                this.action = value;
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

        #endregion

        #region contructeurs

        public JournalAchat()
        {
            this.id = 0;
            this.idAdmin = 0;
            this.heure = "";
            this.action = "";
            this.remarque = "";
        }

        public JournalAchat(int idAdmin, String heure,String action,String remarque)
        {
            this.id = 0;
            this.idAdmin = idAdmin;
            this.heure = heure;
            this.action = action;
            this.remarque = remarque;
        }

        public JournalAchat(int idAdmin, int idProd, String heure, String action, String remarque)
        {
            this.idAdmin = idAdmin;
            this.idProd = idProd;
            this.heure = heure;
            this.action = action;
            this.remarque = remarque;
        }
        public JournalAchat(int id, int idAdmin, int idProd, String heure, String action, String remarque)
        {
            this.id = id;
            this.idAdmin = idAdmin;
            this.idProd = idProd;
            this.heure = heure;
            this.action = action;
            this.remarque = remarque;
        }

        #endregion
    }
}
