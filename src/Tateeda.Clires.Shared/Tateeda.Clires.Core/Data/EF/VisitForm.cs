//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
//	
//    Modified for BRRO project
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Tateeda.Clires.Core.Data.EF
{
    public partial class VisitForm
    {
    	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    	
    	public int VisitId { get; set; }
    	
    	public int FormId { get; set; }
    	
    	public Nullable<int> SortOrder { get; set; }
    	
    	public virtual Visit Visit { get; set; }
    	
    	public virtual Form Form { get; set; }
    }
    
}
