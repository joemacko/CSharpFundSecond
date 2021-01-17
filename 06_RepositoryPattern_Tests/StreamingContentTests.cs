using _06_RepositoryPattern_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _06_RepositoryPattern_Tests
{
    [TestClass]
    public class StreamingContentTests
    {
        [TestMethod]
        // Seems like we're testing a read method here
        public void SetTitle_ShouldSetCorrectString()
        {
            // Arrange                                  // blank constructor
            StreamingContent content = new StreamingContent();
            content.Title = "Toy Story";

            // Act
            string expected = "Toy Story";
            string actual = content.Title;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
