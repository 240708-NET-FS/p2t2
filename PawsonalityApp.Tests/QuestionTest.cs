using Microsoft.IdentityModel.Tokens;
using Moq;
using Pawsonality.API.DAO;
using Pawsonality.API.Models;
using PawsonalityApp.API.Services;

namespace PawsonalityApp.Tests;

public class QuestionTest
{
    [Fact]
    public async void CreateQuestion_ShouldSuccesfullyCreateQuestion()
    {
        // Arrange
        Mock<IQuestionRepo> mockQuestionRepo = new Mock<IQuestionRepo>(); // <1>
        QuestionService _questionService = new QuestionService(mockQuestionRepo.Object); // <2> questionService 

        // Act
        Question question = new Question
        {
            QuestionID = 1,
            QuestionText = "How do you prefer to spend your weekend?"
        };

        QuestionDTO questionDTO = new QuestionDTO
        {
            QuestionText = "How do you prefer to spend your weekend?"
        };

        mockQuestionRepo.Setup(x => x.CreateQuenstion(It.IsAny<Question>())).ReturnsAsync(question);

        // Act
        Question q = await _questionService.CreateQuenstion(questionDTO);

        // Assert
        Assert.Equal(question, q);

    }

    [Fact]
    public async void DeleteQuestion_ShouldSuccesfullyDeleteQuestion()
    {
        // Arrange
        Mock<IQuestionRepo> mockQuestionRepo = new Mock<IQuestionRepo>(); // <1>
        QuestionService _questionService = new QuestionService(mockQuestionRepo.Object); // <2> questionService 

        // Act
        Question question = new Question
        {
            QuestionID = 1,
            QuestionText = "How do you prefer to spend your weekend?"
        };

        QuestionDTO questionDTO = new QuestionDTO
        {
            QuestionText = "How do you prefer to spend your weekend?"
        };

        mockQuestionRepo.Setup(x => x.CreateQuenstion(It.IsAny<Question>())).ReturnsAsync(question);
        mockQuestionRepo.Setup(x => x.DeleteQuestion(It.IsAny<int>())).ReturnsAsync(question);
        mockQuestionRepo.Setup(x => x.GetQuestionByID(It.IsAny<int>())).ReturnsAsync(question);

        // Act
        Question createdQ = await _questionService.CreateQuenstion(questionDTO);
        Question deletedQ = await _questionService.DeleteQuestion(1);

        // Assert
        Assert.Equal(question, deletedQ);
        Assert.Equal(createdQ, deletedQ);
    }

    [Fact]
    public async void GetQuestionByID_ShouldSuccesfullyGetQuestion()
    {
        // Arrange
        Mock<IQuestionRepo> mockQuestionRepo = new Mock<IQuestionRepo>(); // <1>
        QuestionService _questionService = new QuestionService(mockQuestionRepo.Object); // <2> questionService 

        Question question = new Question
        {
            QuestionID = 1,
            QuestionText = "How do you prefer to spend your weekend?"
        };

        QuestionDTO questionDTO = new QuestionDTO
        {
            QuestionText = "How do you prefer to spend your weekend?"
        };

        mockQuestionRepo.Setup(x => x.CreateQuenstion(It.IsAny<Question>())).ReturnsAsync(question);
        mockQuestionRepo.Setup(x => x.GetQuestionByID(It.IsAny<int>())).ReturnsAsync(question);

        // Act
        Question createdQ = await _questionService.CreateQuenstion(questionDTO);
        Question returnedQ = await _questionService.GetQuestionByID(1);

        // Assert
        Assert.Equal(question, returnedQ);
    }

    [Fact]
    public async void GetQuestions_ShouldSuccesfullyGetQuestions()
    {
        // Arrange
        Mock<IQuestionRepo> mockQuestionRepo = new Mock<IQuestionRepo>(); // <1>
        QuestionService _questionService = new QuestionService(mockQuestionRepo.Object); // <2> questionService
        List<Question> questions = new List<Question>{
            new Question
        {
            QuestionID = 1,
            QuestionText = "How do you prefer to spend your weekend?"
        },

            new Question
          {
              QuestionID = 2,
              QuestionText = "How do you prefer to spend your weekdays?"
          }
        };

        QuestionDTO questionDTO = new QuestionDTO
        {
            QuestionText = "How do you prefer to spend your weekend?"
        };

        // mockQuestionRepo.Setup(x => x.CreateQuenstion(It.IsAny<Question>())).ReturnsAsync(question);
        mockQuestionRepo.Setup(x => x.GetQuestions()).ReturnsAsync(questions);

        // Act
        ICollection<Question> returnedQ = await _questionService.GetQuestions();

        Assert.NotNull(returnedQ);
        Assert.Equal(questions, returnedQ);

    }

    [Fact]
    public async void UpdateQuestion_ShouldSuccesfullyUpdateQuestion()
    {
        // Arrange
        Mock<IQuestionRepo> mockQuestionRepo = new Mock<IQuestionRepo>(); // <1>
        QuestionService _questionService = new QuestionService(mockQuestionRepo.Object); // <2> questionService

          Question question = new Question
        {
            QuestionID = 1,
            QuestionText = "How do you prefer to spend your weekend?"
        };

        QuestionDTO questionDTO = new QuestionDTO
        {
            QuestionText = "How do you prefer to spend your weekend?"
        };

        mockQuestionRepo.Setup(x => x.UpdateQuestion(It.IsAny<int>(), It.IsAny<Question>())).ReturnsAsync(question);
        
        Question q = await _questionService.CreateQuenstion(questionDTO);

        // Act
        Question updatedQ = await _questionService.UpdateQuestion(1, questionDTO);
        

        // Assert   
        Assert.Equal(question, updatedQ);

    }
}