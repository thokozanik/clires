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
    public partial class FormAnswer
    {
    	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    	
    		
    	public int AppointmentFormId { get; set; }
    	
    	public int AnswerId { get; set; }
    	
    	public int QuestionId { get; set; }
    	
    	public string FreeTextAnswer { get; set; }
    	
    	public string Notes { get; set; }
    	
    	public System.DateTime CreatedOn { get; set; }
    	
    	public Nullable<System.DateTime> UpdatedOn { get; set; }
    	
    	public string CreatedBy { get; set; }
    	
    	public string UpdatedBy { get; set; }
    	
    	public virtual AppointmentForm AppointmentForm { get; set; }
    }
    
}
