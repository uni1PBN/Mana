namespace Data.Controllers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public partial class ActivityLogController
    {
        private DBManaEntities _dbcontext = DBManaEntitiesSingleton.Instance;

        public ActivityLog ActivityLogCurrent { get; set; }
        public List<ActivityLog> ActivityLogCollection { get; set; }

        public ActivityLogController()
        {
        }

        public List<ActivityLog> GetAll()
        {
            ActivityLogCollection = _dbcontext.MANA_ActivityLog.ToList();
            return ActivityLogCollection;
        }
        public ActivityLog GetItem(int pk)
        {
            ActivityLogCurrent =  _dbcontext.MANA_ActivityLog.Where(x => x.PK == pk).FirstOrDefault();
            return ActivityLogCurrent;
        }
        public void AddNewItem(ActivityLog instanceLog)
        {
            try
            {
                if (instanceLog != null)
                {
                    _dbcontext.MANA_ActivityLog.Add(instanceLog);
                    ActivityLogCurrent = instanceLog;
                    Save();
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error when adding new ActivityLog Item in DB", ex);
            }
        }
        public void RemoveItem(int pk)
        {
            try
            {
                if (pk > 0)
                {
                    _dbcontext.MANA_ActivityLog.Remove(GetItem(pk));
                    ActivityLogCurrent = null;
                    Save();
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error when removing ActivityLog Item in DB", ex);
            }
        }
        //public void RemoveAll()
        //{
        //    try
        //    {
        //        List<int> pks = new List<int>();
        //        GetAll().Select(x => x.PK).ToList().ForEach(pks.Add);
        //        //actvities.ToList().ForEach(categoryFlowchart.Add);
        //        foreach (int pk in pks)
        //        {
        //            _dbcontext.MANA_ActivityLog.Remove(GetItem(pk));
        //        }
        //        Save();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new ApplicationException("Error when removing new ActivityLog Item in DB", ex);
        //    }
        //}
        public void Save()
        {
            _dbcontext.SaveChanges();
        }


    }
}

//