using System;
using Durak;
using Durak.Interfaces;
using Durak.Strategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DurakTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class PlayerSetterTest
    {
        private Mock<IConfigurationSetter> Configuration { get; }
        private Mock<IPlayerFactory> PlayerFactory { get; }
        private Mock<IStrategyFactory> StrategyFactory { get; }
        private Mock<ISecondaryInputProvider> InputProvider { get; }

        public PlayerSetterTest()
        {
            Configuration = new Mock<IConfigurationSetter>();
            PlayerFactory = new Mock<IPlayerFactory>();
            StrategyFactory = new Mock<IStrategyFactory>();
            InputProvider = new Mock<ISecondaryInputProvider>();
        }

        [TestMethod]
        public void PlayerSetterShouldThrowException()
        {
            //Arrange
            //Act
            //Assert
            Assert.ThrowsException<NullReferenceException>(() => new PlayerSetter(Configuration.Object,
                PlayerFactory.Object, StrategyFactory.Object, null));
        }

        [TestMethod]
        public void PlayerSetterShouldInitializeProperties()
        {
            //Arrange
            //Act
            var playerSetter = new PlayerSetter(Configuration.Object,
                PlayerFactory.Object, StrategyFactory.Object, InputProvider.Object);
            //Assert
            Assert.IsNotNull(playerSetter.Configuration);
            Assert.IsNotNull(playerSetter.PlayerFactory);
            Assert.IsNotNull(playerSetter.StrategyFactory);
            Assert.IsNotNull(playerSetter.InputProvider);
        }

        [TestMethod]
        public void PlayerSetterShouldCreateHumanPlayer()
        {
            //Arrange
            string stringInput = "fakeValue";
            Configuration.Setup(x => x.Message.firstVar_15_).Returns(stringInput);
            Configuration.Setup(x => x.Message.secondVar_16_).Returns(It.IsAny<string>());
            Configuration.Setup(x => x.Constant.numberOfCards_1_).Returns(It.IsAny<int>());
            StrategyFactory.Setup(x => x.CreateHumanStrategy()).Returns(new HumanStrategy(Configuration.Object));
            PlayerFactory.Setup(x => x.CreatePlayer(StrategyFactory.Object.CreateHumanStrategy())).Returns(new Player(Configuration.Object, StrategyFactory.Object.CreateHumanStrategy()));
            InputProvider.Setup(x => x.ReturnUserNameInputValue()).Returns(stringInput);
            //Act
            var playerSetter = new PlayerSetter(Configuration.Object,
                PlayerFactory.Object, StrategyFactory.Object, InputProvider.Object);
            playerSetter.CreatePlayers();
            //Assert
            Assert.IsNotNull(playerSetter.player1);
            Assert.IsNotNull(playerSetter.UserName);
        }
        [TestMethod]
        public void PlayerSetterShouldCreateCPU_Player()
        {
            //Arrange
            string stringInput = "fakeValue";
            Configuration.Setup(x => x.Constant.strategy_1_4_).Returns(stringInput);
            Configuration.Setup(x => x.Constant.strategy_2_5_).Returns(It.IsAny<string>());
            Configuration.Setup(x => x.Constant.numberOfCards_1_).Returns(It.IsAny<int>());

            InputProvider.Setup(x => x.ReturnStrategyTypeInputValue()).Returns(stringInput);
            StrategyFactory.Setup(x => x.CreateStrategyA()).Returns(new StrategyA(Configuration.Object));
            PlayerFactory.Setup(x => x.CreatePlayer(StrategyFactory.Object.CreateStrategyA())).Returns(new Player(Configuration.Object, StrategyFactory.Object.CreateHumanStrategy()));
            StrategyFactory.Setup(x => x.CreateStrategyB()).Returns(It.IsAny<StrategyB>());
            //Act
            var playerSetter = new PlayerSetter(Configuration.Object,
                PlayerFactory.Object, StrategyFactory.Object, InputProvider.Object);
            playerSetter.CreatePlayers();
            //Assert
            Assert.IsNotNull(playerSetter.player2);
        }

    }
}
