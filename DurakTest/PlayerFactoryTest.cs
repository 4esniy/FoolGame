using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Durak;
using Durak.Interfaces;

namespace DurakTest
{
    [TestClass]
    public class PlayerFactoryTest
    {
        private Mock<IConfigurationSetter> _configurationSetter { get; }

        private PlayerFactory PlayerFactory{get;}
        private Player Player { get; set;}

        public PlayerFactoryTest()
        {
            _configurationSetter =new Mock<IConfigurationSetter>();
            PlayerFactory = new PlayerFactory(_configurationSetter.Object);
            _configurationSetter.Setup(x => x.Constant.numberOfCards_1_).Returns(6);
        }

        [TestMethod]
        public void PlayerFactoryTestShouldSetProperties()
        {
            Assert.IsNotNull(PlayerFactory.ConfigurationSetter);
        }

        [TestMethod]
        public void PlayerFactoryCreatePlayer_ShouldReturnPlayer()
        {
            //Arrange
            var strategy = new Mock<IStrategy>();
            //Act
            Player = PlayerFactory.CreatePlayer(strategy.Object);
            //Assert
            Assert.IsNotNull(Player);
        }

    }
}
