// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CssType.cs" company="">
//   
// </copyright>
// <summary>
//   The CssType interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Data.EF
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The CssType interface.
    /// </summary>
    public interface ICssType
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the css class name.
        /// </summary>
        string CssClassName { get; set; }

        /// <summary>
        /// Gets or sets the html.
        /// </summary>
        string Html { get; set; }

        /// <summary>
        ///   Gets or sets the entity identifier
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets the input type.
        /// </summary>
        string InputType { get; set; }

        /// <summary>
        /// Gets or sets the questions.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        ICollection<Question> Questions { get; set; }

        #endregion
    }

    /// <summary>
    /// The css type.
    /// </summary>
    public partial class CssType : BaseEntity, ICssType
    {
    }
}