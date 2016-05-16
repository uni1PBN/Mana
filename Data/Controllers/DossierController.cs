namespace Data.Controllers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public partial class DossierController
    {
        private DBManaEntities _dbcontext = DBManaEntitiesSingleton.Instance;

        public Dossier DossierCurrent { get; set; }
        public List<Dossier> DossierCollection { get; set; }

        public DossierController()
        {
        }

        public Dossier GetItem(int pk)
        {
            DossierCurrent =  _dbcontext.MANA_Dossier.Where(x => x.PK == pk).FirstOrDefault();
            return DossierCurrent;
        }
        public void AddNewItem(Dossier dossier)
        {
            try
            {
                if (dossier != null)
                {
                    _dbcontext.MANA_Dossier.Add(dossier);
                    DossierCurrent = dossier;
                    Save();
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error when adding new ActivityLog Item in DB", ex);
            }
        }
        public void UpdateItem(Dossier dossier)
        {
            try
            {
                if (dossier != null)
                {
                    DossierCurrent = GetItem(dossier.PK);
                    DossierCurrent = dossier;
                    Save();
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error when adding new ActivityLog Item in DB", ex);
            }
        }

        public void Save()
        {
            _dbcontext.SaveChanges();
        }
    }
}

//