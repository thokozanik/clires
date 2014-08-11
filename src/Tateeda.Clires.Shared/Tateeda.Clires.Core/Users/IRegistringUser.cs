// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRegistringUser.cs" company="">
//   
// </copyright>
// <summary>
//   The RegistringUser interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Users
{
    /// <summary>
    /// The RegistringUser interface.
    /// </summary>
    public interface IRegistringUser
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        string Password { get; set; }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        string Role { get; set; }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        string UserName { get; set; }

        #endregion
    }

    /// <summary>
    /// The registring user.
    /// </summary>
    public class RegistringUser : IRegistringUser
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        public string UserName { get; set; }

        #endregion
    }
}