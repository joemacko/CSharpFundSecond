using System;
using _06_RepositoryPattern_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _06_RepositoryPattern_Tests
{
    [TestClass]
    public class StreamingContentRepositoryTests
    {   
        // Just declaring new object here, will assign values to them later
        private StreamingContentRepository _repo;
        private StreamingContent _content;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new StreamingContentRepository();
            _content = new StreamingContent("Rubber", "A car trye comes to life with the power" +
                "to make people explode and goes on a murderous rampage through the California" +
                "desert.", "R", 5.8, false, GenreType.Drama);

            _repo.AddContentToList(_content);
        }

        // Add method
        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {
            // Arrange --> Setting up the playing field
            // Adding a new StreamingContent object
            StreamingContent content = new StreamingContent();
            // setting a value for one of the new StreamingContent object's properties
            content.Title = "Toy Story";
            // Adding a new StreamingContentRepository object
            StreamingContentRepository repository = new StreamingContentRepository();

            // Act --> Get/run the code we want to test
            // Adding the title property value of the new content object to the repository object
            repository.AddContentToList(content);
            /* Assigning contentFromDirectory object value to the string value of "Toy Story"
            through the GetContentByTitle method of the repository object. */
            StreamingContent contentFromDirectory = repository.GetContentByTitle("Toy Story");

            // Assert --> Use the assert class to verify the expected outcome
            // contentFromDirectory should have a value if the AddContentToList method worked
            Assert.IsNotNull(contentFromDirectory);
        }

        // Update
        [TestMethod]
        public void UpdateExistingContent_ShouldReturnTrue()
        {
            // Arrange
            // TestInitialize
            StreamingContent newContent = new StreamingContent("Rubber", "A car trye comes to life with the power" +
                "to make people explode and goes on a murderous rampage through the California" +
                "desert.", "R", 10, false, GenreType.RomCom);

            // Act
            bool updateResult = _repo.UpdateExistingContent("Rubber", newContent);

            // Assert
            Assert.IsTrue(updateResult);
        }

        [DataTestMethod]
        [DataRow("Rubber", true)]
        [DataRow("Toy Story", false)]
        public void UpdateExistingContent_ShouldMatchGivenBool(string originalTitle, bool shouldUpdate)
        {
            // Arrange
            // TestInitialize
            StreamingContent newContent = new StreamingContent("Rubber", "A car trye comes to life with the power" +
                "to make people explode and goes on a murderous rampage through the California" +
                "desert.", "R", 10, false, GenreType.RomCom);

            // Act
            bool updateResult = _repo.UpdateExistingContent("Rubber", newContent);

            // Assert
            Assert.AreEqual(shouldUpdate, updateResult);
        }

        [TestMethod]
        public void DeleteContent_ShouldReturnTrue()
        {
            // Arrange

            // Act
            bool deleteResult = _repo.RemoveContentFromList(_content.Title);

            // Assert
            Assert.IsTrue(deleteResult);
        }
    }
}
