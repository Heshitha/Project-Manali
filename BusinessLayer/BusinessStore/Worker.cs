using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BusinessStore
{
    public class Worker
    {
        public static int SaveNewWorker(WorkerDTO worker)
        {
            return DataAccessLayer.Datastore.WorkerDataStore.InsertNewWorker(worker);
        }

        public static List<WorkerDTO> GetAllWorkers()
        {
            return DataAccessLayer.Datastore.WorkerDataStore.GetAllWorkers();
        }

        public static WorkerDTO GetWorkerByID(int WorkerID)
        {
            return DataAccessLayer.Datastore.WorkerDataStore.GetWorkerByID(WorkerID);
        }

        public static WorkerDTO GetWorkerWithQuotations(int WorkerID)
        {
            return DataAccessLayer.Datastore.WorkerDataStore.GetQuotationsMarketedByWorker(WorkerID);
        }
    }
}
