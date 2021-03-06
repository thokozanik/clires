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
    public partial class Appointment
    {
    	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Appointment()
        {		
    		this.AppointmentForms = new HashSet<AppointmentForm>();
    		
    		this.RecreationalDrugOrSubstances = new HashSet<RecreationalDrugOrSubstance>();
        }
    
    	
    		
    	public int SubjectId { get; set; }
    	
    	public int VisitId { get; set; }
    	
    	public int SiteId { get; set; }
    	
    	public int AppUserId { get; set; }
    	
    	public string Title { get; set; }
    	
    	public string Location { get; set; }
    	
    	public string Description { get; set; }
    	
    	public System.DateTime StartDate { get; set; }
    	
    	public Nullable<System.TimeSpan> StartTime { get; set; }
    	
    	public System.DateTime EndDate { get; set; }
    	
    	public Nullable<System.TimeSpan> EndTime { get; set; }
    	
    	public int Status { get; set; }
    	
    	public string CreatedBy { get; set; }
    	
    	public System.DateTime CreatedOn { get; set; }
    	
    	public Nullable<System.DateTime> UpdatedOn { get; set; }
    	
    	public string UpdatedBy { get; set; }
    	
    	public bool IsActive { get; set; }
    	
    	public int VisitStepId { get; set; }
    	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    		
    	public virtual ICollection<AppointmentForm> AppointmentForms { get; set; }
    	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    		
    	public virtual ICollection<RecreationalDrugOrSubstance> RecreationalDrugOrSubstances { get; set; }
    	
    	public virtual Visit Visit { get; set; }
    }
    
}
