using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceClient.Logic;

namespace UnitTests.Logic.PersonManagerTests
{
    [TestClass]
    public partial class PersonManagerTest
    {
        private PersonManager _sut;
        private RepoStub _repoStub;
        private ValidatorStub _validatorStub;

        [TestInitialize]
        public void Setup()
        {
            _repoStub = new RepoStub();
            _validatorStub = new ValidatorStub();
            _sut = new PersonManager(_repoStub, _validatorStub);
        }
    }
}
