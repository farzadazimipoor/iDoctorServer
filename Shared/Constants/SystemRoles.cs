using Shared.Enums;

namespace Shared.Constants
{
    public static class SystemRoles
    {
        public static string ROOTADMIN => "rootadmin";
        public static string ADMIN => "admin";
        public static string HOSPITALMANAGER => "hospitalmanager";
        public static string CLINICMANAGER => "clinicmanager";

        /// <summary>
        /// This is manager of polyclinic & can see all doctors & appointments, but can not see patients data & create prescription.
        /// </summary>
        public static string POLYCLINICMANAGER => "polyclinicmanager";

        /// <summary>
        /// Doctor role will login as polyclinic manager.
        /// The doctor should have access to all sections that related with itself (not other doctors)
        /// </summary>
        public static string DOCTOR => "doctor";

        /// <summary>
        /// This is doctor secretary role and will login as polyclinic manager.
        /// The secretary should only be able to add profiles and put a schedule.
        /// The secretary should not see the patients’ data.
        /// Each secretary has its own doctor to manage.
        /// </summary>
        public static string SECRETARY => "secretary";

        public static string PHARMACYMANAGER => "pharmacymanager";

        public static string SONARMANAGER => "sonarmanager";

        public static string LABMANAGER => "labmanager";

        public static string BEAUTYCENTERMANAGER => "beautycentermanager";

        public static string[] GetAllSystemRoles
        {
            get
            {
                return new[]
                {
                    ROOTADMIN,
                    ADMIN,
                    HOSPITALMANAGER,
                    CLINICMANAGER,
                    POLYCLINICMANAGER,
                    PHARMACYMANAGER,
                    SONARMANAGER,
                    DOCTOR,
                    SECRETARY,
                    LABMANAGER,
                    BEAUTYCENTERMANAGER
                };
            }
        }

        public static LoginAs GetLoginAs(string role)
        {
            if (role == ROOTADMIN || role == ADMIN)
            {
                return LoginAs.ADMIN;
            }
            else if (role == POLYCLINICMANAGER || role == DOCTOR || role == SECRETARY)
            {
                return LoginAs.POLYCLINICMANAGER;
            }
            else if (role == PHARMACYMANAGER)
            {
                return LoginAs.PHARMACYMANAGER;
            }
            else if (role == SONARMANAGER)
            {
                return LoginAs.SONARMANAGER;
            }
            else if (role == LABMANAGER)
            {
                return LoginAs.LABMANAGER;
            }
            else if (role == BEAUTYCENTERMANAGER)
            {
                return LoginAs.BEAUTYCENTERMANAGER;
            }
            return LoginAs.UNKNOWN;
        }
    }
}
