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
    public partial class Question
    {
    	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Question()
        {		
    		this.Answers = new HashSet<Answer>();
    		
    		this.AnswerChildQuestions = new HashSet<AnswerChildQuestion>();
    		
    		this.LibraryAnswers = new HashSet<LibraryAnswer>();
        }
    
    	
    		
    	public int FormId { get; set; }
    	
    	public int FieldDataTypeId { get; set; }
    	
    	public string QuestionText { get; set; }
    	
    	public string Code { get; set; }
    	
    	public string Directions { get; set; }
    	
    	public string Header { get; set; }
    	
    	public string Trailer { get; set; }
    	
    	public bool IsRequired { get; set; }
    	
    	public Nullable<int> ParentQuestionId { get; set; }
    	
    	public bool IsParent { get; set; }
    	
    	public string Description { get; set; }
    	
    	public int SortOrder { get; set; }
    	
    	public int Status { get; set; }
    	
    	public System.DateTime CreatedOn { get; set; }
    	
    	public Nullable<System.DateTime> UpdatedOn { get; set; }
    	
    	public string CreatedBy { get; set; }
    	
    	public string UpdatedBy { get; set; }
    	
    	public bool IsActive { get; set; }
    	
    	public string ValidationRule { get; set; }
    	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    		
    	public virtual ICollection<Answer> Answers { get; set; }
    	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    		
    	public virtual ICollection<AnswerChildQuestion> AnswerChildQuestions { get; set; }
    	
    	public virtual CssType CssType { get; set; }
    	
    	public virtual Form Form { get; set; }
    	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    		
    	public virtual ICollection<LibraryAnswer> LibraryAnswers { get; set; }
    }
    
}
