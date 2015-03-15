using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Datastore
{
    public class WorkerDataStore
    {
        static ManaliDataStoreDataContext db = new ManaliDataStoreDataContext();

        public static int InsertNewWorker(WorkerDTO WorkerDTO)
        {
            try
            {
                int? NewWorkerID = 0;

                db.Manali_Worker_CreateWorker(
                    WorkerDTO.Name,
                    WorkerDTO.NIC,
                    WorkerDTO.Mobile,
                    WorkerDTO.Address,
                    WorkerDTO.Image,
                    WorkerDTO.Designation,
                    ref NewWorkerID);

                if (NewWorkerID != null && NewWorkerID != 0)
                {
                    return NewWorkerID.Value;
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        public static List<WorkerDTO> GetAllWorkers()
        {
            try
            {
                List<WorkerDTO> lstWorkers = new List<WorkerDTO>();

                var lstWorkersFromDatabase = db.Manali_Worker_GetAllWorkers();

                foreach (var item in lstWorkersFromDatabase)
                {
                    WorkerDTO worker = new WorkerDTO
                    {
                        WorkerID = item.WorkerID,
                        Name = item.Name,
                        NIC = item.NIC,
                        Mobile = item.Mobile,
                        Address = item.Address,
                        Designation = item.Designation,
                        Image = item.Image
                    };

                    lstWorkers.Add(worker);
                }

                return lstWorkers;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public static WorkerDTO GetWorkerByID(int WorkerID)
        {
            try
            {
                var WorkerFromDatabase = db.Manali_Worker_GetWorkerByID(WorkerID).FirstOrDefault();

                if (WorkerFromDatabase != null)
                {
                    WorkerDTO worker = new WorkerDTO
                    {
                        WorkerID = WorkerFromDatabase.WorkerID,
                        Name = WorkerFromDatabase.Name,
                        NIC = WorkerFromDatabase.NIC,
                        Mobile = WorkerFromDatabase.Mobile,
                        Address = WorkerFromDatabase.Address,
                        Designation = WorkerFromDatabase.Designation,
                        Image = WorkerFromDatabase.Image
                    };

                    return worker;
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public static WorkerDTO GetQuotationsMarketedByWorker(int WorkerID)
        {
            try
            {
                var WorkerFromDatabase = db.Manali_Worker_GetWorkerByID(WorkerID).FirstOrDefault();

                if (WorkerFromDatabase != null)
                {
                    WorkerDTO worker = new WorkerDTO
                    {
                        WorkerID = WorkerFromDatabase.WorkerID,
                        Name = WorkerFromDatabase.Name,
                        NIC = WorkerFromDatabase.NIC,
                        Mobile = WorkerFromDatabase.Mobile,
                        Address = WorkerFromDatabase.Address,
                        Designation = WorkerFromDatabase.Designation,
                        Image = WorkerFromDatabase.Image,
                        ListOfMarketedQuotations = new List<QuotationDTO>(),
                        ListOfSuccessfullQuotations = new List<QuotationDTO>()
                    };

                    List<QuotationDTO> lstQuotationsMarketedByWorker = new List<QuotationDTO>();

                    var QuotationsMarketedByWorkerFromDatabase = db.Manali_Worker_GetAllQuotationsByWorkerID(WorkerID);

                    foreach (var item in QuotationsMarketedByWorkerFromDatabase)
                    {
                        QuotationDTO quotation = new QuotationDTO
                        {
                            QuotationID = item.QuotationID,
                            DateOfWedding = item.DateOfWedding.Value,
                            NameOfBride = item.Bride,
                            BrideAddress = item.BrideAddress,
                            BrideEmail = item.BrideEmail,
                            BrideContactNo = item.BrideContactNo,
                            DateOfHomecoming = item.DateOfHomecoming.Value,
                            NameOfGroom = item.Groom,
                            GroomAddress = item.GroomAddress,
                            GroomContactNo = item.GroomContactNo
                        };

                        worker.ListOfMarketedQuotations.Add(quotation);

                        if (item.EventID != null)
                        {
                            worker.ListOfSuccessfullQuotations.Add(quotation);
                        }
                    }

                    return worker;
                }

                
            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }
}
