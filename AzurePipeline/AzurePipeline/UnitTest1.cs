using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AzurePipeline
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShouldPass()
        {
        }

        [TestMethod]
        public void ShouldFail()
        {
            throw new Exception("Azure pipeline test");
        }
    }
}
