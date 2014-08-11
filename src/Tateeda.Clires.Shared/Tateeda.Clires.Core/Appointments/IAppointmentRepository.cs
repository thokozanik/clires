// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAppointmentRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The AppointmentRepository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Appointments
{
    using System;
    using System.Collections.Generic;

    using Tateeda.Clires.Core.Data;
    using Tateeda.Clires.Core.Data.EF;
    using Tateeda.Clires.Core.Data.Enums;

    /// <summary>
    /// The AppointmentRepository interface.
    /// </summary>
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        #region Public Methods and Operators

        /// <summary>
        /// The create or update appointment form.
        /// </summary>
        /// <param name="apptForm">
        /// The appt form.
        /// </param>
        void CreateOrUpdateAppointmentForm(IAppointmentForm apptForm);

        /// <summary>
        /// The get all visits in step.
        /// </summary>
        /// <param name="stepSequenceId">
        /// The step sequence id.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<IVisit> GetAllVisitsInStep(int stepSequenceId);

        /// <summary>
        /// The get appointment form.
        /// </summary>
        /// <param name="apptId">
        /// The appt id.
        /// </param>
        /// <param name="formId">
        /// The form id.
        /// </param>
        /// <returns>
        /// The <see cref="IAppointmentForm"/>.
        /// </returns>
        IAppointmentForm GetAppointmentForm(int apptId, int formId);

        /// <summary>
        /// The get appointment form.
        /// </summary>
        /// <param name="apptFormId">
        /// The appt form id.
        /// </param>
        /// <returns>
        /// The <see cref="IAppointmentForm"/>.
        /// </returns>
        IAppointmentForm GetAppointmentForm(int apptFormId);

        /// <summary>
        /// The get appointment status.
        /// </summary>
        /// <param name="appointmentId">
        /// The appointment id. 
        /// </param>
        /// <returns>
        /// The <see cref="AppointmentStatusType"/> . 
        /// </returns>
        AppointmentStatusType GetAppointmentStatus(int appointmentId);

        /// <summary>
        /// The get subject visits.
        /// </summary>
        /// <param name="subjectId">
        /// The subject id.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<IAppointment> GetSubjectVisits(int subjectId);

        /// <summary>
        /// The site appointments by dates.
        /// </summary>
        /// <param name="siteId">
        /// The site id.
        /// </param>
        /// <param name="start">
        /// The start.
        /// </param>
        /// <param name="end">
        /// The end.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<IAppointment> SiteAppointmentsByDates(int siteId, DateTime start, DateTime end);

        /// <summary>
        /// The site appointments by dates.
        /// </summary>
        /// <param name="start">
        /// The start.
        /// </param>
        /// <param name="end">
        /// The end.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<IAppointment> SiteAppointmentsByDates(DateTime start, DateTime end);

        IEnumerable<IAppointment> SiteAppointmentsByDates(DateTime start, DateTime end, int siteId);

        #endregion
    }
}