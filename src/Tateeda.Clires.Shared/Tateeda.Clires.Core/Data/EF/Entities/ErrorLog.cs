namespace Tateeda.Clires.Core.Data.EF
{
    using System;

    public interface IErrorLog
    {
        int Id { get; set; }
        DateTime? CreatedOn { get; set; }
        string Message { get; set; }
        string StackTrace { get; set; }
    }

    public partial class ErrorLog : BaseEntity, IErrorLog
    {
    }
}
