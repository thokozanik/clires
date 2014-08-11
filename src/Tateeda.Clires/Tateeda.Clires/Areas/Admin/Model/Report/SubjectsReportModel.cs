using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Linq;
using System.IO;

namespace Tateeda.Clires.Areas.Admin.Model.Report
{
	public class SubjectsReportModel
	{
		public int TotalActiveSubjectsCount { get; set; }
		public int TotalInActiveSubjectsCount { get; set; }
		public int TotalSubjectsCount { get; set; }

		public int TotalSubjectsPerStydy { get; set; }

		public Dictionary<string, int> TotalSubjectsPerStudyForAllSites { get; set; }
		public Dictionary<string, int> TotalActiveSubjectsPerStudyForAllSites { get; set; }
		public Dictionary<string, int> TotalCompletedAppointmentsPerStudy { get; set; }
		public Dictionary<string, int> TotalInProgressAppointmentsPerStudy { get; set; }
		public Dictionary<string, int> TotalScheduledAppointmentsPerStudy { get; set; }
		public Dictionary<string, int> TotalCompletedFormsPerStudy { get; set; }
		public Dictionary<string, int> TotalInProgressFormsPerStudy { get; set; }


        public string SitesNameJSON
        {
            get
            {                
                return toJSON(this.TotalActiveSubjectsPerStudyForAllSites.Keys.ToArray(), typeof(string[])).Replace("\"", "'");
            }
        }

        public string SubjectsPerSiteJSON
        {
            get
            {
                int[][] data = new int[1][];
                data[0] = this.TotalActiveSubjectsPerStudyForAllSites.Values.ToArray();
                return toJSON(data, typeof(int[][]));
            }
        }

        public string VisitsJsonArray
        {
            get
            {
                int[][] data = new int[3][];

                data[0] = this.TotalCompletedAppointmentsPerStudy.Values.ToArray();
                data[1] = this.TotalInProgressAppointmentsPerStudy.Values.ToArray();
                data[2] = this.TotalScheduledAppointmentsPerStudy.Values.ToArray();
                
                return toJSON(data, typeof(int[][]));
            }
        }

        public string FormsJsonArray
        {
            get
            {
                int[][] data = new int[2][];

                data[0] = this.TotalCompletedFormsPerStudy.Values.ToArray();
                data[1] = this.TotalCompletedFormsPerStudy.Values.ToArray();
                
                return toJSON(data, typeof(int[][]));
            }
        }

        string toJSON(object data, global::System.Type type)
        {
            var i = typeof(int);
            using (MemoryStream ms = new MemoryStream())
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(type);
                
                ser.WriteObject(ms, data);
                ms.Position = 0;
                using (StreamReader sr = new StreamReader(ms))
                {
                    return sr.ReadToEnd();
                }
            }
        }
	}
}