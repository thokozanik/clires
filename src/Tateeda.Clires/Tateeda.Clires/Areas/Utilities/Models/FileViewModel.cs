namespace Tateeda.Clires.Areas.Utilities.Models
{
    using Tateeda.Clires.Core.Data.EF;

    using global::System;
    using global::System.Collections.Generic;

    public class FileViewModel : IFile
    {
        #region Implementation of IFile

        public Guid FileGuid { get; set; }
        public string Name { get; set; }
        public string FileType { get; set; }
        public byte[] FielContent { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public ICollection<Study> Studies { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public int Id { get; set; }

        #endregion
    }
}