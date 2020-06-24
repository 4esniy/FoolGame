using Durak;
using Durak.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DurakTest
{

    [TestClass]
    public class StrategyFactoryTest
    {
        private Mock<IConfigurationSetter> _configurationSetter { get; }
        private Mock<IConsoleReadWrap> _ConsoleReadMock { get; }

        private StrategyFactory _strategyFactory { get; }


        public StrategyFactoryTest()
        {
            _configurationSetter = new Mock<IConfigurationSetter>();
            _ConsoleReadMock = new Mock<IConsoleReadWrap>();
            _strategyFactory = new StrategyFactory(_configurationSetter.Object, _ConsoleReadMock.Object);
        }


        [TestMethod]
        public void StrategyFactoryShouldReturnStrategy()
        {
           var A = _strategyFactory.CreateHumanStrategy();
           var B = _strategyFactory.CreateStrategyA();
           var C = _strategyFactory.CreateStrategyB();

            Assert.IsNotNull(A);
            Assert.IsNotNull(B);
            Assert.IsNotNull(C);
        }
    }
}
