// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISettingsRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The SettingsRepository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Utility
{
    using Tateeda.Clires.Core.Data;
    using Tateeda.Clires.Core.Data.EF;

    /// <summary>
    /// The SettingsRepository interface.
    /// </summary>
    public interface ISettingsRepository : IRepository<Setting>
    {
        #region Public Methods and Operators

        /// <summary>
        /// The get by name.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="ISetting"/>.
        /// </returns>
        ISetting GetByName(string name);

        /// <summary>
        /// The get current study.
        /// </summary>
        /// <returns>
        /// The <see cref="ISetting"/>.
        /// </returns>
        ISetting GetCurrentStudy();

        #endregion
    }
}