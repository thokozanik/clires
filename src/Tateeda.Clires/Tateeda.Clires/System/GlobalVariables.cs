namespace Tateeda.Clires.System
{
    using Tateeda.Clires.Data.UOW;

    using global::System.Web.Mvc;
    using Core.Utility;

    public class GlobalVariables
    {
        private static int _studyId;
        public const string RoleSiteAdmin = "Site Admin";
        public const string RoleSystemAdmin = "Sys Admin";
        public const string RoleAppUser = "App User";
        public const string RoleSubject = "Subject";
        public const string RoleGuest = "Guest";
        public const string RoleSiteAdminAndSysAdmin = "Site Admin, Sys Admin";
        public const string RoleSiteAdminAndAppUser = "Site Admin, App User";

        public GlobalVariables(ISettingsRepository settingsRepo)
        {
            _studyId = int.Parse(settingsRepo.GetCurrentStudy().Value);
        }

        static GlobalVariables()
        {
            var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>();
            if (adminUow != null)
            {
                _studyId = int.Parse(adminUow.SettingsRepository.GetCurrentStudy().Value);
            }
        }

        public static int CurrentStudyId
        {
            get { return _studyId; }
        }

    }
}