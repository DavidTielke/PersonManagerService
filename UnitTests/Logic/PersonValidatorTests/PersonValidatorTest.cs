using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceClient.Logic;

namespace UnitTests.Logic.PersonValidatorTests
{
    [TestClass]
    public partial class PersonValidatorTest
    {
        private PersonValidator _sut;

        [TestInitialize]
        public void Setup()
        {
            _sut = new PersonValidator();
        }
    }
}
