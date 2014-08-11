using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tateeda.Clires.Core.Data.EF;
using Tateeda.Clires.Core.Visits;

namespace Tateeda.Clires.CodeTest.EFFakes {
    internal class VisitFormsFake : IVisitForms {
        #region Implementation of IVisitForms

        public IVisit Visit { get; set; }
        public IEnumerable<IForm> Forms { get; set; }
        public IEnumerable<IForm> AllForms { get; set; }

        #endregion
    }
}
