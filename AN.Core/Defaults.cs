using System;

namespace AN.Core
{
    public static class Defaults
    {
        public static DateTime MorningStart => DateTime.Parse("06:00:00");

        public static DateTime MorningEnd => DateTime.Parse("14:00:00");

        public static DateTime EveningStart => DateTime.Parse("14:00:00");

        public static DateTime EveningEnd => DateTime.Parse("23:00:00");

        /// <summary>
        /// Number of rows per page for reporting
        /// </summary>
        public static int RowsPerPage => 35;
    }
}
