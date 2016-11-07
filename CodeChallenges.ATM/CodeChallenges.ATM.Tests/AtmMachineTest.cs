using CodeChallenges.ATM.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeChallenges.ATM.Tests
{
    [TestClass]
    public class AtmMachineTest
    {
        public AtmMachine AtmMachine;

        public AtmMachineTest()
        {
            this.AtmMachine = new AtmMachine();
        }

        [TestMethod]
        public void DispenseAmount_ValidInput()
        {
            string actual = AtmMachine.DispenseAmount(3500);

            string expected = "1000 * 3\r\n500 * 1\r\n";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DispenseAmount_InValidInput()
        {
            string actual = AtmMachine.DispenseAmount(3550);

            string expected = "Amount cannot be dispensed";
            Assert.AreEqual(expected, actual);
        }
    }
}