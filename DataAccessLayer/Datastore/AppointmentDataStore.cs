using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Datastore
{
    public class AppointmentDataStore
    {
        static ManaliDataStoreDataContext db = new ManaliDataStoreDataContext();

        public static int CreateNewAppointment(AppointmentDTO Appointment)
        {
            try
            {
                int? AppointmentID = 0;

                db.Manali_Appointment_CreateAppointment(
                    Appointment.Quotation.QuotationID,
                    Appointment.AppointmentDateTime,
                    Appointment.ResponsibleWorker.WorkerID,
                    Appointment.Duration,
                    Appointment.Notes,
                    ref AppointmentID);

                if (AppointmentID != null && AppointmentID != 0)
                {
                    return AppointmentID.Value;
                }
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        public static List<AppointmentDTO> GetAllAppointments()
        {
            try
            {
                List<AppointmentDTO> lstAppointment = new List<AppointmentDTO>();

                var lstAppointmentsFromDB = db.Manali_Appointment_GetAllAppointments();

                foreach (var item in lstAppointmentsFromDB)
                {
                    QuotationDTO quotation = new QuotationDTO
                    {
                        QuotationID = item.QuotationID,
                        DateOfWedding = item.DateOfWedding.Value,
                        NameOfBride = item.Bride,
                        BrideAddress = item.BrideAddress,
                        BrideEmail = item.BrideEmail,
                        DateOfHomecoming = item.DateOfHomecoming.Value,
                        NameOfGroom = item.Groom,
                        GroomAddress = item.GroomAddress,
                        GroomContactNo = item.GroomContactNo,
                        createdDate = item.CreatedDate.Value
                    };

                    WorkerDTO worker = new WorkerDTO
                    {
                        WorkerID = item.WorkerID,
                        Name = item.Name,
                        NIC = item.NIC,
                        Mobile = item.Mobile,
                        Address = item.Address,
                        Image = item.Image,
                        Designation = item.Designation
                    };

                    AppointmentDTO appointment = new AppointmentDTO
                    {
                        AppointmentID = item.AppointmentID,
                        Quotation = quotation,
                        AppointmentDateTime = item.AppointmentDateTime.Value,
                        ResponsibleWorker = worker,
                        IsBrideVisited = item.IsBrideVisited.Value,
                        Duration = item.Duration.Value,
                        Notes = item.Notes,
                        Status = item.Status.Value
                    };

                    lstAppointment.Add(appointment);
                }

                return lstAppointment;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public static AppointmentDTO GetAppointmentDetailsByID(int AppointID)
        {
            try
            {

                var item = db.Manali_Appointment_GetAppointmentDetailsByID(AppointID).FirstOrDefault();

                QuotationDTO quotation = new QuotationDTO
                {
                    QuotationID = item.QuotationID,
                    DateOfWedding = item.DateOfWedding.Value,
                    NameOfBride = item.Bride,
                    BrideAddress = item.BrideAddress,
                    BrideEmail = item.BrideEmail,
                    DateOfHomecoming = item.DateOfHomecoming.Value,
                    NameOfGroom = item.Groom,
                    GroomAddress = item.GroomAddress,
                    GroomContactNo = item.GroomContactNo,
                    createdDate = item.CreatedDate.Value
                };

                WorkerDTO worker = new WorkerDTO
                {
                    WorkerID = item.WorkerID,
                    Name = item.Name,
                    NIC = item.NIC,
                    Mobile = item.Mobile,
                    Address = item.Address,
                    Image = item.Image,
                    Designation = item.Designation
                };

                AppointmentDTO appointment = new AppointmentDTO
                {
                    AppointmentID = item.AppointmentID,
                    Quotation = quotation,
                    AppointmentDateTime = item.AppointmentDateTime.Value,
                    ResponsibleWorker = worker,
                    IsBrideVisited = item.IsBrideVisited.Value,
                    Duration = item.Duration.Value,
                    Notes = item.Notes,
                    Status = item.Status.Value
                };

                return appointment;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public static List<AppointmentDTO> GetAppointmentsAssignForWorker(int WorkerID)
        {
            try
            {
                List<AppointmentDTO> lstAppointment = new List<AppointmentDTO>();

                var lstAppointmentsFromDB = db.Manali_Appointment_GetAppointmentsAssignForWorker(WorkerID);

                foreach (var item in lstAppointmentsFromDB)
                {
                    QuotationDTO quotation = new QuotationDTO
                    {
                        QuotationID = item.QuotationID,
                        DateOfWedding = item.DateOfWedding.Value,
                        NameOfBride = item.Bride,
                        BrideAddress = item.BrideAddress,
                        BrideEmail = item.BrideEmail,
                        DateOfHomecoming = item.DateOfHomecoming.Value,
                        NameOfGroom = item.Groom,
                        GroomAddress = item.GroomAddress,
                        GroomContactNo = item.GroomContactNo,
                        createdDate = item.CreatedDate.Value
                    };

                    WorkerDTO worker = new WorkerDTO
                    {
                        WorkerID = item.WorkerID,
                        Name = item.Name,
                        NIC = item.NIC,
                        Mobile = item.Mobile,
                        Address = item.Address,
                        Image = item.Image,
                        Designation = item.Designation
                    };

                    AppointmentDTO appointment = new AppointmentDTO
                    {
                        AppointmentID = item.AppointmentID,
                        Quotation = quotation,
                        AppointmentDateTime = item.AppointmentDateTime.Value,
                        ResponsibleWorker = worker,
                        IsBrideVisited = item.IsBrideVisited.Value,
                        Duration = item.Duration.Value,
                        Notes = item.Notes,
                        Status = item.Status.Value
                    };

                    lstAppointment.Add(appointment);
                }

                return lstAppointment;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public static List<AppointmentDTO> GetAppointmentsByQuotationID(int QuotationID)
        {
            try
            {
                List<AppointmentDTO> lstAppointment = new List<AppointmentDTO>();

                var lstAppointmentsFromDB = db.Manali_Appointment_GetAppointmentsByQuotationID(QuotationID);

                foreach (var item in lstAppointmentsFromDB)
                {
                    QuotationDTO quotation = new QuotationDTO
                    {
                        QuotationID = item.QuotationID,
                        DateOfWedding = item.DateOfWedding.Value,
                        NameOfBride = item.Bride,
                        BrideAddress = item.BrideAddress,
                        BrideEmail = item.BrideEmail,
                        DateOfHomecoming = item.DateOfHomecoming.Value,
                        NameOfGroom = item.Groom,
                        GroomAddress = item.GroomAddress,
                        GroomContactNo = item.GroomContactNo,
                        createdDate = item.CreatedDate.Value
                    };

                    WorkerDTO worker = new WorkerDTO
                    {
                        WorkerID = item.WorkerID,
                        Name = item.Name,
                        NIC = item.NIC,
                        Mobile = item.Mobile,
                        Address = item.Address,
                        Image = item.Image,
                        Designation = item.Designation
                    };

                    AppointmentDTO appointment = new AppointmentDTO
                    {
                        AppointmentID = item.AppointmentID,
                        Quotation = quotation,
                        AppointmentDateTime = item.AppointmentDateTime.Value,
                        ResponsibleWorker = worker,
                        IsBrideVisited = item.IsBrideVisited.Value,
                        Duration = item.Duration.Value,
                        Notes = item.Notes,
                        Status = item.Status.Value
                    };

                    lstAppointment.Add(appointment);
                }

                return lstAppointment;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

    }
}
