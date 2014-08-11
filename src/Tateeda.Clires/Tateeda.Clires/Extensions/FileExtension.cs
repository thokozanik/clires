using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tateeda.Clires.Core.Data.EF;

namespace Tateeda.Clires.Extensions
{
    using Tateeda.Clires.Areas.Utilities.Models;

    public static class FileExtension
    {
        public static FileViewModel ToModel(this IFile file)
        {
            return new FileViewModel
                {
                    Id = file.Id,
                    FileGuid = file.FileGuid,
                    CreatedBy = file.CreatedBy,
                    CreatedOn = file.CreatedOn,
                    //FielContent = file.FielContent, //Can be very big, do not pass it to UI.
                    FileType = file.FileType,
                    Name = file.Name
                };
        }
    }
}