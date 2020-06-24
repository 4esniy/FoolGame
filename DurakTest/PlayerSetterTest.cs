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
        private Mock<IConsoleReadWrap> ConsoleReadMock { get; }

        public PlayerSetterTest()
        {
            Configuration = new Mock<IConfigurationSetter>();
            PlayerFactory = new Mock<IPlayerFactory>();
            StrategyFactory = new Mock<IStrategyFactory>();
            InputProvider = new Mock<ISecondaryInputProvider>();
            ConsoleReadMock = new Mock<IConsoleReadWrap>();
        }

        [TestMethod]
        public void PlayerSetterShouldThrowException()
        {
            //Arrange
            //Act
            //Assert
            Assert.ThrowsException<NullReferenceException>(() => new GameSetter(Configuration.Object,InputProvider.Object,
                PlayerFactory.Object, null));
        }

        [TestMethod]
        public void PlayerSetterShouldInitializeProperties()
        {
            //Arrange
            //Act
            var gameSetter = new GameSetter(Configuration.Object, InputProvider.Object,
                PlayerFactory.Object, StrategyFactory.Object);
            //Assert
            Assert.IsNotNull(gameSetter.LanguageSet);
            Assert.IsNotNull(gameSetter.PlayerFactory);
            Assert.IsNotNull(gameSetter.StrategyFactory);
            Assert.IsNotNull(gameSetter.InputProvider);
        }

        [TestMethod]
        public void PlayerSetterShouldCreateHumanPlayer()
        {
            //Arrange
            string stringInput = "fakeValue";
            Configuration.Setup(x => x.Message.firstVar_15_).Returns(stringInput);
            Configuration.Setup(x => x.Message.secondVar_16_).Returns(It.IsAny<string>());
            Configuration.Setup(x => x.Constant.numberOfCards_1_).Returns(It.IsAny<int>());
            StrategyFactory.Setup(x => x.CreateHumanStrategy()).Returns(new HumanStrategy(Configuration.Object, ConsoleReadMock.Object));
            PlayerFactory.Setup(x => x.CreatePlayer(StrategyFactory.Object.CreateHumanStrategy())).Returns(new Player(Configuration.Object, StrategyFactory.Object.CreateHumanStrategy()));
            InputProvider.Setup(x => x.ReturnUserNameInputValue()).Returns(stringInput);
            StrategyFactory.Setup(x => x.CreateStrategyA()).Returns(value: new StrategyA(Configuration.Object, ConsoleReadMock.Object));
            PlayerFactory.Setup(x => x.CreatePlayer(StrategyFactory.Object.CreateStrategyA())).Returns(new Player(Configuration.Object, StrategyFactory.Object.CreateStrategyA()));

            //Act
            var gameSetter = new GameSetter(Configuration.Object, InputProvider.Object,
                PlayerFactory.Object, StrategyFactory.Object);
            gameSetter.CreatePlayersFor36CardGame();
            //Assert
            Assert.IsNotNull(gameSetter.Players[0]);
            Assert.IsNotNull(gameSetter.Players[1]);
        }

    }
}
