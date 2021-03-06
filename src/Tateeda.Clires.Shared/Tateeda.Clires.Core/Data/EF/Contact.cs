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
    public partial class Contact
    {
    	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contact()
        {		
    		this.AppUsers = new HashSet<AppUser>();
    		
    		this.Addresses = new HashSet<Address>();
    		
    		this.Emails = new HashSet<Email>();
    		
    		this.Phones = new HashSet<Phone>();
    		
    		this.Subjects = new HashSet<Subject>();
        }
    
    	
    		
    	public int ContactTypeId { get; set; }
    	
    	public string FirstName { get; set; }
    	
    	public string MiddleName { get; set; }
    	
    	public string LastName { get; set; }
    	
    	public int SortOrder { get; set; }
    	
    	public int Status { get; set; }
    	
    	public System.DateTime CreatedOn { get; set; }
    	
    	public Nullable<System.DateTime> UpdatedOn { get; set; }
    	
    	public string CreatedBy { get; set; }
    	
    	public string UpdatedBy { get; set; }
    	
    	public bool IsActive { get; set; }
    	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    		
    	public virtual ICollection<AppUser> AppUsers { get; set; }
    	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    		
    	public virtual ICollection<Address> Addresses { get; set; }
    	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    		
    	public virtual ICollection<Email> Emails { get; set; }
    	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    		
    	public virtual ICollection<Phone> Phones { get; set; }
    	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    		
    	public virtual ICollection<Subject> Subjects { get; set; }
    }
    
}
