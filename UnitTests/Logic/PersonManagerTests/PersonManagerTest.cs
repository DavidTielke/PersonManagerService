using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ServiceClient.Logic;

namespace UnitTests.Logic.PersonManagerTests
{
    [TestClass]
    public partial class PersonManagerTest
    {
        private PersonManager _sut;
        private Mock<IPersonRepository> _repoMock;
        private Mock<IPersonValidator> _validatorMock;

        [TestInitialize]
        public void Setup()
        {
            _repoMock = new Mock<IPersonRepository>();
            _validatorMock = new Mock<IPersonValidator>();
            _sut = new PersonManager(_repoMock.Object, _validatorMock.Object);
        }
    }
}
