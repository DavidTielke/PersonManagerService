using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ServiceClient.Controllers;
using ServiceClient.Logic;

namespace UnitTests.Controller.PeopleControllerTests
{
    [TestClass]
    public partial class PeopleControllerTest
    {
        private PeopleController _sut;
        private Mock<IPersonManager> _managerMock;

        [TestInitialize]
        public void Setup()
        {
            _managerMock = new Mock<IPersonManager>();
            _sut = new PeopleController(_managerMock.Object);
        }
    }
}
