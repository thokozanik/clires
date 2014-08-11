// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICodeRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The CodeRepository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Utility
{
    using System.Collections.Generic;

    using Tateeda.Clires.Core.Data;
    using Tateeda.Clires.Core.Data.EF;

    /// <summary>
    /// The CodeRepository interface.
    /// </summary>
    public interface ICodeRepository : IRepository<Code>
    {
        #region Public Methods and Operators

        /// <summary>
        /// The get address types.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<ICode> GetAddressTypes();

        /// <summary>
        /// The get code type enumeration.
        /// </summary>
        /// <param name="typeId">
        /// The type id.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<ICode> GetCodeTypeEnumeration(int typeId);

        /// <summary>
        /// The get countries.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<ICountry> GetCountries();

        /// <summary>
        /// The get field data types.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<ICode> GetFieldDataTypes();

        /// <summary>
        /// The get form layout types.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<ICode> GetFormLayoutTypes();

        /// <summary>
        /// The get form statuses.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<ICode> GetFormStatuses();

        /// <summary>
        /// The get form types.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<ICode> GetFormTypes();

        /// <summary>
        /// The get gender.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<ICode> GetGender();

        /// <summary>
        /// The get phone types.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<ICode> GetPhoneTypes();

        /// <summary>
        /// The get roles list.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<IRole> GetRolesList();

        /// <summary>
        /// The get sites list.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<ISite> GetSitesList();

        /// <summary>
        /// The get states.
        /// </summary>
        /// <param name="countryId">
        /// The country id.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<IState> GetStates(int countryId);

        /// <summary>
        /// The get study list.
        /// </summary>
        /// <param name="showAll">
        /// The show all.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<IStudy> GetStudyList(bool showAll);

        /// <summary>
        /// The get time zones.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<ITimeZone> GetTimeZones();

        /// <summary>
        /// The get visit statuses.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<ICode> GetVisitStatuses();

        /// <summary>
        /// The get visit types.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<ICode> GetVisitTypes();

        #endregion
    }
}