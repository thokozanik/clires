namespace Tateeda.Clires.Data.UOW
{
    using Tateeda.Clires.Core.StudySetup;

    public interface IStudySetupUnitOfWork : IUnitOfWork
    {
        IStudySetupRepository StudySetupRepository { get; }
    }
}