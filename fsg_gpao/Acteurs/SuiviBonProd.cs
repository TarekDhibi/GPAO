using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fsg_gpao.Acteurs
{
    class SuiviBonProd
    {
        private int id;
        private int idBon;
        private String pourcentage;
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
        public int IDBON
        {
            get
            {
                return this.idBon;
            }
            set
            {
                this.idBon = value;
            }
        }
        public String POURCENTAGE
        {
            get
            {
                return this.pourcentage;
            }
            set
            {
                this.pourcentage = value;
            }
        }
        public SuiviBonProd()
        {
            this.id = 0;
            this.idBon = 0;
            this.pourcentage = "";
        }
        public SuiviBonProd(int id)
        {
            this.id = id;
            this.idBon = 0;
            this.pourcentage = "";
        }
        public SuiviBonProd(int id, int idBon)
        {
            this.id = id;
            this.idBon = idBon;
            this.pourcentage = "";
        }
        public SuiviBonProd(int id, int idBon, String pourcentage)
        {
            this.id = id;
            this.idBon = idBon;
            this.pourcentage = pourcentage;
        }
    }
}
