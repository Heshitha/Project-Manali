using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BusinessStore
{
    public class Appointment
    {
        public static int CreateNewAppointment(AppointmentDTO Appointment)
        {
            return DataAccessLayer.Datastore.AppointmentDataStore.CreateNewAppointment(Appointment);
        }

        public static List<AppointmentDTO> GetAllAppointments()
        {
            return DataAccessLayer.Datastore.AppointmentDataStore.GetAllAppointments();
        }

        public static AppointmentDTO GetAppointmentDetailsByID(int AppointID)
        {
            return DataAccessLayer.Datastore.AppointmentDataStore.GetAppointmentDetailsByID(AppointID);
        }

        public static List<AppointmentDTO> GetAppointmentsAssignForWorker(int WorkerID)
        {
            return DataAccessLayer.Datastore.AppointmentDataStore.GetAppointmentsAssignForWorker(WorkerID);
        }

        public static List<AppointmentDTO> GetAppointmentsByQuotationID(int QuotationID)
        {
            return DataAccessLayer.Datastore.AppointmentDataStore.GetAppointmentsByQuotationID(QuotationID);
        }
    }
}
