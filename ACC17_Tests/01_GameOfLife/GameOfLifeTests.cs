using ACC17._01_GameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACC17_Tests._01_GameOfLife {
    [TestClass]
    public class GameOfLifeTests {
        [TestMethod]
        public void TestMethod1() {
            var classUnderTest = new GameOfLife("2;2;0;1000$");
            Assert.Equals("2;2;0;1000$\n", classUnderTest.GetPattern(0));
        }
    }
}