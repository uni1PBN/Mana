namespace Data.Controllers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public partial class WorkflowRepositoryController
    {
        private DBManaEntities _dbcontext = DBManaEntitiesSingleton.Instance;

        public WorkflowRepository WorkflowRepositoryCurrent { get; set; }
        public List<WorkflowRepository> WorkflowRepositoryCollection { get; set; }

        public WorkflowRepositoryController() { }

        public List<String> GetNameList(Boolean fullName = true)
        {
            if (fullName)
            {
                return _dbcontext.MANA_WorkflowRepository.Select(x => x.Name).ToList();
            }
            else
            {
                List<String> WFRepoItems = new List<string>();
                foreach (string item in _dbcontext.MANA_WorkflowRepository.Select(x => x.Name).ToList())
                {
                    WFRepoItems.Add(item.Split('\\').ToList().Last());
                }
                return WFRepoItems;
            }
        }
        public WorkflowRepository GetItem(string name)
        {
            WorkflowRepositoryCurrent = _dbcontext.MANA_WorkflowRepository
                .Where(x => x.Name.Contains(name)).FirstOrDefault();
            return WorkflowRepositoryCurrent;
        }

        public bool Exist(string name)
        {
            return _dbcontext.MANA_WorkflowRepository.Any(x => x.Name.Contains(name));
        }
        public List<WorkflowRepository> GetAll()
        {
            WorkflowRepositoryCollection = _dbcontext.MANA_WorkflowRepository.ToList();
            return WorkflowRepositoryCollection;
        }
        public WorkflowRepository GetItem(int pk)
        {
            WorkflowRepositoryCurrent = _dbcontext.MANA_WorkflowRepository.Where(x => x.PK == pk).FirstOrDefault();
            return WorkflowRepositoryCurrent;
        }
        public void AddNewItem(WorkflowRepository workflow)
        {
            try
            {
                if (workflow != null)
                {
                    _dbcontext.MANA_WorkflowRepository.Add(workflow);
                    WorkflowRepositoryCurrent = workflow;
                    Save();
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error when adding new WorkflowRepository Item in DB", ex);
            }
        }
        public void RemoveItem(int pk)
        {
            try
            {
                if (pk > 0)
                {
                    _dbcontext.MANA_WorkflowRepository.Remove(GetItem(pk));
                    WorkflowRepositoryCurrent = null;
                    Save();
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error when removing new WorkflowRepository Item in DB", ex);
            }
        }
        public void Save()
        {
            _dbcontext.SaveChanges();
        }
    }
}