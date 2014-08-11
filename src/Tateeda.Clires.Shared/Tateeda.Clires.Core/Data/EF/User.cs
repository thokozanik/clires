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
    public partial class User
    {
    	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {		
    		this.AppUsers = new HashSet<AppUser>();
    		
    		this.Roles = new HashSet<Role>();
        }
    
    	
    		
    	public System.Guid ApplicationId { get; set; }
    	
    	public System.Guid UserId { get; set; }
    	
    	public string UserName { get; set; }
    	
    	public bool IsAnonymous { get; set; }
    	
    	public System.DateTime LastActivityDate { get; set; }
    	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    		
    	public virtual ICollection<AppUser> AppUsers { get; set; }
    	
    	public virtual Membership Membership { get; set; }
    	
    	public virtual Profile Profile { get; set; }
    	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    		
    	public virtual ICollection<Role> Roles { get; set; }
    }
    
}
