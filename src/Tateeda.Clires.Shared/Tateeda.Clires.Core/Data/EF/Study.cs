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
    public partial class Study
    {
    	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Study()
        {		
    		this.Arms = new HashSet<Arm>();
    		
    		this.Drugs = new HashSet<Drug>();
    		
    		this.Sites = new HashSet<Site>();
    		
    		this.Forms = new HashSet<Form>();
    		
    		this.Subjects = new HashSet<Subject>();
    		
    		this.Files = new HashSet<File>();
    		
    		this.Organizations = new HashSet<Organization>();
        }
    
    	
    		
    	public string Name { get; set; }
    	
    	public string Description { get; set; }
    	
    	public System.DateTime StartDate { get; set; }
    	
    	public Nullable<System.DateTime> EndDate { get; set; }
    	
    	public string Target { get; set; }
    	
    	public string Goal { get; set; }
    	
    	public Nullable<decimal> Budget { get; set; }
    	
    	public int SortOrder { get; set; }
    	
    	public int Status { get; set; }
    	
    	public System.DateTime CreatedOn { get; set; }
    	
    	public Nullable<System.DateTime> UpdatedOn { get; set; }
    	
    	public string CreatedBy { get; set; }
    	
    	public string UpdatedBy { get; set; }
    	
    	public bool IsActive { get; set; }
    	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    		
    	public virtual ICollection<Arm> Arms { get; set; }
    	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    		
    	public virtual ICollection<Drug> Drugs { get; set; }
    	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    		
    	public virtual ICollection<Site> Sites { get; set; }
    	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    		
    	public virtual ICollection<Form> Forms { get; set; }
    	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    		
    	public virtual ICollection<Subject> Subjects { get; set; }
    	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    		
    	public virtual ICollection<File> Files { get; set; }
    	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    		
    	public virtual ICollection<Organization> Organizations { get; set; }
    }
    
}
