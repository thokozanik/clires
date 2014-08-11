using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tateeda.Clires.Core.Appointments;
using Tateeda.Clires.Core.Data.EF;
using Tateeda.Clires.Core.Data.Enums;

namespace Tateeda.Clires.CodeTest.EFFakes {
    internal class AppointmentRepositoryFake : IAppointmentRepository {
        #region Implementation of IRepository<Appointment>

        public IQueryable<Appointment> All { get; private set; }
        public Appointment GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Implementation of IAppointmentRepository

        public IEnumerable<IAppointment> SiteAppointmentsByDates(int siteId, DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IAppointment> SiteAppointmentsByDates(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IAppointment> SiteAppointmentsByDates(DateTime start, DateTime end, int siteId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IAppointment> GetSubjectVisits(int subjectId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IVisit> GetAllVisitsInStep(int stepSequenceId)
        {
            throw new NotImplementedException();
        }

        public AppointmentStatusType GetAppointmentStatus(int appointmentId)
        {
            throw new NotImplementedException();
        }

        public IAppointmentForm GetAppointmentForm(int apptId, int formId)
        {
            throw new NotImplementedException();
        }

        public IAppointmentForm GetAppointmentForm(int apptFormId)
        {
            throw new NotImplementedException();
        }

        public void CreateOrUpdateAppointmentForm(IAppointmentForm apptForm)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
