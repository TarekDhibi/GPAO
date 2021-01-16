using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fsg_gpao.Acteurs
{
    class BonProduction
    {
        private int id;
        private int idArticle;
        private int idAtelier;
        private int nbArticle;
        private String dateDepart;
        private String dateFin;
        private int cout;
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
        public int IDARTICLE
        {
            get
            {
                return this.idArticle;
            }
            set
            {
                this.idArticle = value;
            }
        }
        public int IDATELIER
        {
            get
            {
                return this.idAtelier;
            }
            set
            {
                this.idAtelier = value;
            }
        }
        public int NBARTICLE
        {
            get
            {
                return this.nbArticle;
            }
            set
            {
                this.nbArticle = value;
            }
        }
        public String DATEDEPART
        {
            get
            {
                return this.dateDepart;
            }
            set
            {
                this.dateDepart = value;
            }
        }
        public String DATEFIN
        {
            get
            {
                return this.dateFin;
            }
            set
            {
                this.dateFin = value;
            }
        }
        public int COUT
        {
            get
            {
                return this.cout;
            }
            set
            {
                this.cout = value;
            }
        }
        public BonProduction()
        {
            this.id = 0;
            this.idArticle = 0;
            this.idAtelier = 0;
            this.nbArticle = 0;
            this.dateDepart = "";
            this.dateFin = "";
            this.cout = 0;
        }
        public BonProduction(int id)
        {
            this.id = id;
            this.idArticle = 0;
            this.idAtelier = 0;
            this.nbArticle = 0;
            this.dateDepart = "";
            this.dateFin = "";
            this.cout = 0;
        }
        public BonProduction(int id, int idArticle)
        {
            this.id = id;
            this.idArticle = idArticle;
            this.idAtelier = 0;
            this.nbArticle = 0;
            this.dateDepart = "";
            this.dateFin = "";
            this.cout = 0;
        }
        public BonProduction(int id, int idArticle, int idAtelier)
        {
            this.id = id;
            this.idArticle = idArticle;
            this.idAtelier = idAtelier;
            this.nbArticle = 0;
            this.dateDepart = "";
            this.dateFin = "";
            this.cout = 0;
        }
        public BonProduction(int id, int idArticle, int idAtelier, int nbArticle)
        {
            this.id = id;
            this.idArticle = idArticle;
            this.idAtelier = idAtelier;
            this.nbArticle = idArticle;
            this.dateDepart = "";
            this.dateFin = "";
            this.cout = 0;
        }
        public BonProduction(int id, int idArticle, int idAtelier, int nbArticle, String dateDepart)
        {
            this.id = id;
            this.idArticle = idArticle;
            this.idAtelier = idAtelier;
            this.nbArticle = idArticle;
            this.dateDepart = dateDepart;
            this.dateFin = "";
            this.cout = 0;
        }
        public BonProduction(int id, int idArticle, int idAtelier, int nbArticle, String dateDepart, String dateFin)
        {
            this.id = id;
            this.idArticle = idArticle;
            this.idAtelier = idAtelier;
            this.nbArticle = idArticle;
            this.dateDepart = dateDepart;
            this.dateFin = dateFin;
            this.cout = 0;
        }
        public BonProduction(int id, int idArticle, int idAtelier, int nbArticle, String dateDepart, String dateFin, int cout)
        {
            this.id = id;
            this.idArticle = idArticle;
            this.idAtelier = idAtelier;
            this.nbArticle = nbArticle;
            this.dateDepart = dateDepart;
            this.dateFin = dateFin;
            this.cout = cout;
        }
    }
}
