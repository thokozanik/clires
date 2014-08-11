namespace Tateeda.Clires.Areas.Subject.Model
{
    using Tateeda.Clires.Areas.Admin.Model.Forms;
    using Tateeda.Clires.Areas.Admin.Model.Study;
    using Tateeda.Clires.Areas.Utilities.Models;
    using Tateeda.Clires.Core.Data.EF;
    using Tateeda.Clires.Areas.Schedule.Model;

    using global::System.Collections.Generic;

    public interface ISubjectVisitViewModel
    {
        AppointmentViewModel Appointment { get; set; }
        VisitViewModel Visit { get; set; }
        SubjectViewModel Subject { get; set; }
        IEnumerable<FormViewModel> RequiredForms { get; set; }
        IEnumerable<FormViewModel> InProgressForms { get; set; }
        IEnumerable<FormViewModel> CompletedForms { get; set; }
        IEnumerable<ISubjectDrug> Medications { get; set; }
        IEnumerable<FileViewModel> SubjectFiles { get; set; }
    }

    public class SubjectVisitViewModel : ISubjectVisitViewModel
    {
        public AppointmentViewModel Appointment { get; set; }
        public VisitViewModel Visit { get; set; }
        public SubjectViewModel Subject { get; set; }
        public IEnumerable<FormViewModel> RequiredForms { get; set; }
        public IEnumerable<FormViewModel> InProgressForms { get; set; }
        public IEnumerable<FormViewModel> CompletedForms { get; set; }
        public IEnumerable<ISubjectDrug> Medications { get; set; }
        public IEnumerable<FileViewModel> SubjectFiles { get; set; }
    }
}