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
    public partial class Site
    {
    	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Site()
        {		
    		this.AppUsers = new HashSet<AppUser>();
    		
    		this.Studies = new HashSet<Study>();
    		
    		this.Subjects = new HashSet<Subject>();
        }
    
    	
    		
    	public string Name { get; set; }
    	
    	public string Code { get; set; }
    	
    	public int TimeZoneId { get; set; }
    	
    	public bool IsPrimary { get; set; }
    	
    	public string Directions { get; set; }
    	
    	public int SortOrder { get; set; }
    	
    	public int Status { get; set; }
    	
    	public System.DateTime CreatedOn { get; set; }
    	
    	public Nullable<System.DateTime> UpdatedOn { get; set; }
    	
    	public string CreatedBy { get; set; }
    	
    	public string UpdatedBy { get; set; }
    	
    	public bool IsActive { get; set; }
    	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    		
    	public virtual ICollection<AppUser> AppUsers { get; set; }
    	
    	public virtual TimeZone TimeZone { get; set; }
    	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    		
    	public virtual ICollection<Study> Studies { get; set; }
    	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    		
    	public virtual ICollection<Subject> Subjects { get; set; }
    }
    
}
