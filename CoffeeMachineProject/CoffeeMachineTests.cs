using NUnit.Framework;
using CoffeeMachineLibrary;
using CoffeeMachineLibrary.Commands;
using CoffeeMachineLibrary.Services;
using Moq;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ProtocolMessages()
        {
            //"T:1:0"(Drink maker makes 1 tea with 1 sugar and a stick)
            //"H::"(Drink maker makes 1 chocolate with no sugar - and therefore no stick)
            //"C:2:0"(Drink maker makes 1 coffee with 2 sugars and a stick)
            //"M:message-content"(Drink maker forwards any message received
            //    onto the coffee machine interface for the customer to see)

            var cm = new CoffeeMachine();
            var coffee = new CoffeeCommand();
            var tea = new TeaCommand(3);
            var hotChocolate = new ExtraHotChocolateCommand(1);
            var orangeJuice = new OrangeJuiceCommand();
            var message = new MessageCommand("HelloWorld!");

            var c = cm.Order(coffee, 1);
            var t = cm.Order(tea, 1);
            var h = cm.Order(hotChocolate, 1);
            var o = cm.Order(orangeJuice, 1);
            var msg = cm.Order(message);
            var fail = cm.Order(null, 1);

            Assert.AreEqual(c, "C::");
            Assert.AreEqual(t, "T:2:0");
            Assert.AreEqual(h, "Hh:1:0");
            Assert.AreEqual(o, "O::");
            Assert.AreEqual(msg, "M:HelloWorld!");
            Assert.That(fail, Is.Null);
        }
        
        [Test]
        public void CommandPrices()
        {
            var coffee = new CoffeeCommand();
            var chocolate = new ChocolateCommand();
            var tea = new TeaCommand();
            var oj = new OrangeJuiceCommand();
            
            Assert.AreEqual(coffee.Price, 0.6);
            Assert.AreEqual(chocolate.Price, 0.5);
            Assert.AreEqual(tea.Price, 0.4);
            Assert.AreEqual(oj.Price, 0.6);
        }
        
        [Test]
        public void RegisteredReport()
        {
            var cm = new CoffeeMachine();
            var coffee = new CoffeeCommand();
            var tea = new TeaCommand();

            cm.Order(coffee);
            cm.Order(tea, 1);
            cm.Order(tea, 1);
            cm.Order(tea, 1);
            cm.Order(tea, 1);
            cm.Order(tea, 1);
            
            Assert.That(cm.Report, Is.Not.Null);
            Assert.AreEqual(cm.Report.CoffeeSold, 0);
            Assert.AreEqual(cm.Report.TeaSold, 5);
            Assert.AreEqual(cm.Report.Credits, 2);
        }

        [Test]
        public void Services()
        {
            Mock<IEmailNotifier> emailNotifierMock = new Mock<IEmailNotifier>();
            Mock<IBeverageQuantityChecker> beverageCheckerMock = new Mock<IBeverageQuantityChecker>();
            IEmailNotifier emailNotifier = emailNotifierMock.Object;
            IBeverageQuantityChecker beverageChecker = beverageCheckerMock.Object;

            var command = new CoffeeCommand();
            var cmdType = command.GetType().ToString();
            
            beverageCheckerMock.Setup(p => p.IsEmpty(cmdType)).Returns(true);
            Assert.IsTrue(beverageChecker.IsEmpty(cmdType));

            var cm = new CoffeeMachine(emailNotifier, beverageChecker);
            cm.Order(command, 1);

            beverageCheckerMock.Verify(p => p.IsEmpty(cmdType), Times.AtLeastOnce);
            emailNotifierMock.Verify(p => p.NotifyMissingDrink(cmdType), Times.Once);
            Assert.Pass();
        }
    }
}