namespace Tateeda.Clires.Areas.Admin.Model.Study
{
    using Tateeda.Clires.Core.Data.EF;

    public class VisitStepVisitSequenceViewModel : IVisitStepVisitSequence
    {
        public int VisitStepId { get; set; }
        public int VisitId { get; set; }
        public int DaysFromBase { get; set; }
        public bool IsActive { get; set; }
        public int Deviation { get; set; }
        public int SortOrder { get; set; }
        public bool IsTermination { get; set; }
        public Visit Visit { get; set; }
        public VisitStep VisitStep { get; set; }
        public int Id { get; set; }
        public string VisitName { get; set; }
    }
}