using Xunit;
using Moq;
using PawsonalityApp.API.Services;
using Pawsonality.API.DAO;
using Pawsonality.API.Models;
using System.Collections.Generic;
using PawsonalityApp.API.Exceptions;

namespace PawsonalityApp.Tests;


public class QuestionTest
{
    [Fact]
    public async void CreateQuestion_ShouldSuccesfullyCreateQuestion()
    {
        Mock<IQuestionRepo> mockQuestionRepo = new();
        QuestionService questionService = new(mockQuestionRepo.Object);

        QuestionDTO questionDTO = new()
        {
            QuestionText = "What is your favorite color?"
        };

        Question question = new()
        {
            QuestionID = 1,
            QuestionText = "What is your favorite color?"
        };

        mockQuestionRepo.Setup(q => q.CreateQuenstion(It.IsAny<Question>())).ReturnsAsync(question);

        Question createdQuestion = await questionService.CreateQuenstion(questionDTO);

        Assert.Equal(question.QuestionID, createdQuestion.QuestionID);
    }

    [Fact]
    public async void DeleteQuestion_ShouldSuccesfullyDeleteQuestion()
    {
        Mock<IQuestionRepo> mockQuestionRepo = new();
        QuestionService questionService = new(mockQuestionRepo.Object);

        Question question = new()
        {
            QuestionID = 1,
            QuestionText = "What is your favorite color?"
        };

        mockQuestionRepo.Setup(q => q.GetQuestionByID(It.IsAny<int>())).ReturnsAsync(question);
        mockQuestionRepo.Setup(q => q.DeleteQuestion(It.IsAny<int>())).ReturnsAsync(question);

        Question deletedQuestion = await questionService.DeleteQuestion(1);

        Assert.Equal(question.QuestionID, deletedQuestion.QuestionID);
    }

    [Fact]
    public async void GetQuestionByID_ShouldSuccesfullyGetQuestion()
    {
        Mock<IQuestionRepo> mockQuestionRepo = new();
        QuestionService questionService = new(mockQuestionRepo.Object);

        Question question = new()
        {
            QuestionID = 1,
            QuestionText = "What is your favorite color?"
        };

        mockQuestionRepo.Setup(q => q.GetQuestionByID(It.IsAny<int>())).ReturnsAsync(question);

        Question foundQuestion = await questionService.GetQuestionByID(1);

        Assert.Equal(question.QuestionID, foundQuestion.QuestionID);
    }

    [Fact]
    public async void GetQuestions_ShouldSuccesfullyGetQuestions()
    {
        Mock<IQuestionRepo> mockQuestionRepo = new();
        QuestionService questionService = new(mockQuestionRepo.Object);

        List<Question> questions = new()
        {
            new Question
            {
                QuestionID = 1,
                QuestionText = "What is your favorite color?"
            },
            new Question
            {
                QuestionID = 2,
                QuestionText = "What is your favorite food?"
            }
        };

        mockQuestionRepo.Setup(q => q.GetQuestions()).ReturnsAsync(questions);

        ICollection<Question> foundQuestions = await questionService.GetQuestions();

        Assert.Equal(questions.Count, foundQuestions.Count);
    }

    [Fact]
    public async void UpdateQuestion_ShouldSuccesfullyUpdateQuestion()
    {
        Mock<IQuestionRepo> mockQuestionRepo = new();
        QuestionService questionService = new(mockQuestionRepo.Object);

        QuestionDTO questionDTO = new()
        {
            QuestionText = "What is your favorite color?"
        };

        Question question = new()
        {
            QuestionID = 1,
            QuestionText = "What is your favorite color?"
        };

        mockQuestionRepo.Setup(q => q.GetQuestionByID(It.IsAny<int>())).ReturnsAsync(question);
        mockQuestionRepo.Setup(q => q.UpdateQuestion(It.IsAny<int>(), It.IsAny<Question>())).ReturnsAsync(question);

        Question updatedQuestion = await questionService.UpdateQuestion(1, questionDTO);

        Assert.Equal(question.QuestionID, updatedQuestion.QuestionID);
    }


    [Fact]
    public async void DeleteQuestion_ShouldThrowInvalidQuestionException()
    {
        //Arrange
        Mock<IQuestionRepo> mockQuestionRepo = new();
        QuestionService questionService = new(mockQuestionRepo.Object);

        mockQuestionRepo.Setup(q => q.DeleteQuestion(It.IsAny<int>())).ReturnsAsync((Question)null!);
        mockQuestionRepo.Setup(q => q.GetQuestionByID(It.IsAny<int>())).ReturnsAsync((Question)null!);

        //Act and Assert
        await Assert.ThrowsAsync<InvalidQuestionException>(() => questionService.DeleteQuestion(1));      

    }

    [Fact]
    public async void GetQuestionByID_ShouldThrowInvalidQuestionException()
    {
        Mock<IQuestionRepo> mockQuestionRepo = new();
        QuestionService questionService = new(mockQuestionRepo.Object);

        mockQuestionRepo.Setup(q => q.GetQuestionByID(It.IsAny<int>())).ReturnsAsync((Question)null!);

        await Assert.ThrowsAsync<InvalidQuestionException>(() => questionService.GetQuestionByID(1));
    }

    [Fact]
    public async void GetQuestions_ShouldThrowInvalidQuestionException()
    {
        Mock<IQuestionRepo> mockQuestionRepo = new();
        QuestionService questionService = new(mockQuestionRepo.Object);

        mockQuestionRepo.Setup(q => q.GetQuestions()).ReturnsAsync(new List<Question>());

        await Assert.ThrowsAsync<InvalidQuestionException>(() => questionService.GetQuestions());
    }
}