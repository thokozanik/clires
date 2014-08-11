using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Tateeda.Clires.Areas.Admin.Controllers;
using Tateeda.Clires.Core.Data.EF;
using Tateeda.Clires.Core.Utility;
using Tateeda.Clires.Core.Visits;
using Tateeda.Clires.System;

namespace Tateeda.Clires.CodeTest.Controllers.Admin {
    using Tateeda.Clires.Areas.Admin.Model.Study;

    [TestClass]
    public class VisitControllerTest
    {
        private IVisitRepository _visitMock;
        private ISettingsRepository _settingMock;

        [TestInitialize]
        public void Init()
        {
            _settingMock = MockRepository.GenerateStub<ISettingsRepository>();
            _visitMock = MockRepository.GenerateStub<IVisitRepository>();

            _settingMock.Stub(s => s.GetCurrentStudy()).Return(new Setting {Value = "1"});
        }

        [TestMethod]
        public void IndexTest()
        {
            // Arrange
            var globalVars = new GlobalVariables(_settingMock);
            var controller = new VisitController();

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsNotNull(globalVars, "Global Variables object");
            Assert.IsNotNull(result);
            Assert.AreEqual(1, (int)controller.ViewBag.StudyId);
        }

        [TestMethod]
        public void CreateVisitTest()
        {
            // Arrange
            var controller = new VisitController();

            var model = new VisitViewModel();
            // Act
            var result = controller.CreateVisit(model);

            // Assert
            Assert.AreEqual("closeModal('visit-modal')", result.Data);
        }

        [TestMethod]
        public void UpdateVisitTest()
        {
            // Arrange
            var controller = new VisitController();
            var model = new VisitViewModel {Id = 4};

            // Act
            var result = controller.CreateVisit(model);

            // Assert
            Assert.AreEqual("closeModal('visit-modal')", result.Data);
        }

        [TestMethod]
        public void UpdateVisitWithParentVisitTest()
        {
            // Arrange
            var controller = new VisitController();
            var model = new VisitViewModel { Id = 4, ParentVisitId = 1};

            // Act
            var result = controller.CreateVisit(model);

            // Assert
            Assert.AreEqual("closeModal('visit-modal')", result.Data);
        }

        [TestMethod]
        public void InvalidModelStateTest()
        {
            // Arrange
            var controller = new VisitController();
            var model = new VisitViewModel { Id = 4, ParentVisitId = 1 };
            controller.ModelState.AddModelError("Name", new Exception("Test error"));

            // Act
            var result = controller.CreateVisit(model);

            // Assert
            Assert.AreEqual("error", result.Data);
        }
    }
}
