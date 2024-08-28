
using Moq;
using Pawsonality.API.DAO;
using Pawsonality.API.Models;
using PawsonalityApp.API.Services;

namespace PawsonalityApp.Tests;

public class AnswerTest
{
    [Fact]
    public async void CreateAnswer_ShouldSuccesfullyCreateAnswer()
    {
        // Arrange
        Mock<IAnswerRepo> mockAnswerRepo = new();
        AnswerServices answerService = new(mockAnswerRepo.Object);

        AnswerDTO answerDTO = new()
        {
            AnswerText = "Blue"
        };

        Answer answer = new()
        {
            AnswerID = 1,
            AnswerText = "Blue"
        };

        mockAnswerRepo.Setup(a => a.CreateAnswer(It.IsAny<Answer>())).ReturnsAsync(answer);

        // Act
        Answer createdAnswer = await answerService.CreateAnswer(answerDTO);

        // Assert
        Assert.Equal(answer.AnswerID, createdAnswer.AnswerID);
    }

    [Fact]
    public async void DeleteAnswer_ShouldSuccesfullyDeleteAnswer()
    {
        // Arrange
        Mock<IAnswerRepo> mockAnswerRepo = new();
        AnswerServices answerService = new(mockAnswerRepo.Object);

        Answer answer = new()
        {
            AnswerID = 1,
            AnswerText = "Blue"
        };

        mockAnswerRepo.Setup(a => a.GetAnswerByID(It.IsAny<int>())).ReturnsAsync(answer);
        mockAnswerRepo.Setup(a => a.DeleteAnswer(It.IsAny<int>())).ReturnsAsync(answer);

        // Act
        Answer? deletedAnswer = await answerService.DeleteAnswer(1); // 1 is the ID of the answer to be deleted

        // Assert
        Assert.NotNull(deletedAnswer);
        Assert.Equal(answer.AnswerID, deletedAnswer.AnswerID);
    
    }

    [Fact]
    public async void GetAnswerByID_ShouldSuccesfullyGetAnswer()
    {
        // Arrange
        Mock<IAnswerRepo> mockAnswerRepo = new();
        AnswerServices answerService = new(mockAnswerRepo.Object);

        Answer answer = new()
        {
            AnswerID = 1,
            AnswerText = "Blue"
        };

        mockAnswerRepo.Setup(a => a.GetAnswerByID(It.IsAny<int>())).ReturnsAsync(answer);

        // Act
        Answer? retrievedAnswer = await answerService.GetAnswerByID(1); // 1 is the ID of the answer to be retrieved

        // Assert
        Assert.NotNull(retrievedAnswer);
        Assert.Equal(answer.AnswerID, retrievedAnswer.AnswerID);
    }

    [Fact]
    public async void GetAnswers_ShouldSuccesfullyGetAnswers()
    {
        // Arrange
        Mock<IAnswerRepo> mockAnswerRepo = new();
        AnswerServices answerService = new(mockAnswerRepo.Object);

        ICollection<Answer> answers = new List<Answer>()
        {
            new Answer
            {
                AnswerID = 1,
                AnswerText = "Blue"
            },
            new Answer
            {
                AnswerID = 2,
                AnswerText = "Red"
            }
        };

        mockAnswerRepo.Setup(a => a.GetAnswers()).ReturnsAsync(answers);

        // Act
        ICollection<Answer> retrievedAnswers = await answerService.GetAnswers();

        // Assert
        Assert.Equal(answers.Count, retrievedAnswers.Count);
    }

    [Fact] 
    public async void GetAnswersByQuestionID_ShouldSuccesfullyGetAnswersByQuestionID()
    {
        // Arrange
        Mock<IAnswerRepo> mockAnswerRepo = new();
        AnswerServices answerService = new(mockAnswerRepo.Object);

        ICollection<Answer> answers = new List<Answer>()
        {
            new Answer
            {
                AnswerID = 1,
                AnswerText = "Blue",
                QuestionID = 1
            },
            new Answer
            {
                AnswerID = 2,
                AnswerText = "Red",
                QuestionID = 1
            }
        };

        mockAnswerRepo.Setup(a => a.GetAnswersByQuestionID(It.IsAny<int>())).ReturnsAsync(answers);

        // Act
        ICollection<Answer> retrievedAnswers = await answerService.GetAnswersByQuestionID(1);

        // Assert
        Assert.Equal(answers.Count, retrievedAnswers.Count);
    }   

    [Fact]
    public async void UpdateAnswer_ShouldSuccesfullyUpdateAnswer() 
    {
        // Arrange
        Mock<IAnswerRepo> mockAnswerRepo = new();
        AnswerServices answerService = new(mockAnswerRepo.Object);

        AnswerDTO answerDTO = new()
        {
            AnswerText = "Blue"
        };

        Answer answer = new()
        {
            AnswerID = 1,
            AnswerText = "Blue"
        };

        mockAnswerRepo.Setup(a => a.GetAnswerByID(It.IsAny<int>())).ReturnsAsync(answer);
        mockAnswerRepo.Setup(a => a.UpdateAnswer(It.IsAny<int>(), It.IsAny<Answer>())).ReturnsAsync(answer);

        // Act
        Answer? updatedAnswer = await answerService.UpdateAnswer(1, answerDTO);

        // Assert
        Assert.NotNull(updatedAnswer);
        Assert.Equal(answer.AnswerID, updatedAnswer.AnswerID);
    }   
}