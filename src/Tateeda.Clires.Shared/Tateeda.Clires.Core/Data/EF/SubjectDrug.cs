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
    public partial class SubjectDrug
    {
    	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    	
    		
    	public int SubjectId { get; set; }
    	
    	public int DrugId { get; set; }
    	
    	public int AppointmentId { get; set; }
    	
    	public Nullable<System.DateTime> StartDate { get; set; }
    	
    	public Nullable<System.DateTime> EndDate { get; set; }
    	
    	public Nullable<int> MultipleTrialsId { get; set; }
    	
    	public Nullable<int> DurationUsed { get; set; }
    	
    	public int ReasonStoppedId { get; set; }
    	
    	public int ReasonTypeId { get; set; }
    	
    	public int TreatmentInducedId { get; set; }
    	
    	public int DosageFrequencyId { get; set; }
    	
    	public bool IsCurrent { get; set; }
    	
    	public bool IsChanged { get; set; }
    	
    	public bool IsStopped { get; set; }
    	
    	public bool IsBeforeStudy { get; set; }
    	
    	public string Dosage { get; set; }
    	
    	public string DosageType { get; set; }
    	
    	public string Notes { get; set; }
    	
    	public string MdNotes { get; set; }
    	
    	public string Comments { get; set; }
    	
    	public string Directions { get; set; }
    	
    	public int SortOrder { get; set; }
    	
    	public int Status { get; set; }
    	
    	public System.DateTime CreatedOn { get; set; }
    	
    	public Nullable<System.DateTime> UpdatedOn { get; set; }
    	
    	public string CreatedBy { get; set; }
    	
    	public string UpdatedBy { get; set; }
    	
    	public bool IsActive { get; set; }
    	
    	public virtual Drug Drug { get; set; }
    	
    	public virtual Subject Subject { get; set; }
    }
    
}
