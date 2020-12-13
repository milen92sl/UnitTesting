using System;
using System.Linq;

namespace Computers.Tests
{
    using NUnit.Framework;

    public class ComputerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ContstructoSeTCorrectNameProp()
        {
            Computer computer = new Computer("a");

            Assert.AreEqual("a", computer.Name);
        }

        [Test]
        public void ContstructoPartsCollectionIsEmpty()
        {
            Computer computer = new Computer("a");

            Assert.IsEmpty(computer.Parts);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void NameShouldThrowExceptionWhenNameIsEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
                new Computer(name));
        }

        [Test]
        public void PartsPropAddTwoPartsShouldAddCorrectly()
        {
            Computer computer = new Computer("a");
            computer.AddPart(new Part("w", 1));
            computer.AddPart(new Part("q", 1));
            Assert.AreEqual(2, computer.Parts.Count);
        }

        [Test]
        public void TotalPricePropShouldReturnCorrectRes()
        {
            Computer computer = new Computer("a");
            computer.AddPart(new Part("w", 1));
            computer.AddPart(new Part("q", 2));
            computer.AddPart(new Part("q", 3));

            Assert.AreEqual(6, computer.TotalPrice);
        }

        [Test]
        public void AddPartNullShouldThrowException()
        {
            Computer computer = new Computer("a");
            Assert.Throws<InvalidOperationException>(() =>
                computer.AddPart(null));
        }

        [Test]
        public void AddPartShouldAddProperly()
        {
            Computer computer = new Computer("a");
            computer.AddPart(new Part("w", 2));

            Assert.AreEqual(1, computer.Parts.Count);
        }

        [Test]
        public void AddPartShouldAddCorrectPart()
        {
            Computer computer = new Computer("a");
            computer.AddPart(new Part("w", 2));

            Part actualPart = computer.Parts.FirstOrDefault(p => p.Name == "w");

            Assert.IsNotNull(actualPart);
            Assert.AreEqual("w", actualPart.Name);
        }

        [Test]
        public void RemovePartShouldRemoveProperly()
        {
            Computer computer = new Computer("a");
            Part part = new Part("w", 1);
            computer.AddPart(part);
            computer.RemovePart(part);

            Assert.AreEqual(0, computer.Parts.Count);
        }

        [Test]
        public void RemovePartShouldRemoveCorrectPart()
        {
            Computer computer = new Computer("a");
            computer.AddPart(new Part("w", 2));

            Part actualPart = computer.Parts.FirstOrDefault(p => p.Name == "w");

            Assert.IsNotNull(actualPart);
            Assert.AreEqual("w", actualPart.Name);
        }

        [Test]
        public void RemoveValidPartShouldReturnTrue()
        {
            Computer computer = new Computer("a");
            Part part = new Part("w", 1);
            computer.AddPart(part);

            bool actualRes = computer.RemovePart(part);

            Assert.IsTrue(actualRes);
        }

        [Test]
        public void RemoveNotValidPartShouldReturnFalse()
        {
            Computer computer = new Computer("a");
            Part part = new Part("w", 1);
            Part part2 = new Part("w", 1);
            computer.AddPart(part);

            bool actualRes = computer.RemovePart(part2);

            Assert.IsFalse(actualRes);
        }

        [Test]
        public void RemovePartShouldRemoveCorrectPart2()
        {
            Computer computer = new Computer("a");
            Part part = new Part("w", 1);
            computer.AddPart(part);
            computer.RemovePart(part);

            Part actualPart = computer.Parts.FirstOrDefault(p => p.Name == "w");

            Assert.IsNull(actualPart);
        }

        [Test]
        public void GetPartValidPartShoudReturnCorrectPart()
        {
            Computer computer = new Computer("a");
            Part part = new Part("w", 1);
            computer.AddPart(part);
            

            Part actualPart = computer.GetPart("w");

            Assert.AreEqual("w", actualPart.Name);
            
        }

        [Test]
        public void GetPartValidPartShoudReturnNull()
        {
            Computer computer = new Computer("a");
            Part part = new Part("w", 1);
            computer.AddPart(part);
            

            Part actualPart = computer.GetPart("q");

            Assert.IsNull(actualPart);
        }
    }
}
