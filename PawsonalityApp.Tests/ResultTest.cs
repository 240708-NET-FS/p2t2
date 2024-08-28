using Xunit;
using Moq;
using PawsonalityApp.API.Services;
using Pawsonality.API.DAO;
using Pawsonality.API.Models;
using System.Collections.Generic;
using PawsonalityApp.API.Exceptions;

namespace PawsonalityApp.Tests;

public class ResultTest
{
    [Fact]
    public async void CreateResult_ShouldSuccesfullyCreateResult()
    {
        // Arrange
        Mock<IResultRepo> mockResultRepo = new();
        ResultService resultService = new(mockResultRepo.Object);

        ResultDTO resultDTO = new()
        {
            ResultValue = "Golden Retriever"
        };

        Result result = new()
        {
            ResultID = 1,
            ResultValue = "Golden Retriever"
        };

        mockResultRepo.Setup(r => r.CreateResult(It.IsAny<Result>())).ReturnsAsync(result);

        // Act
        Result createdResult = await resultService.CreateResult(resultDTO);

        // Assert
        Assert.Equal(result.ResultID, createdResult.ResultID);
    }

    [Fact]
    public async void DeleteResult_ShouldSuccesfullyDeleteResult()
    {
        // Arrange
        Mock<IResultRepo> mockResultRepo = new();
        ResultService resultService = new(mockResultRepo.Object);

        Result result = new()
        {
            ResultID = 1,
            ResultValue = "Golden Retriever"
        };

        mockResultRepo.Setup(r => r.GetResultByID(It.IsAny<int>())).ReturnsAsync(result);
        mockResultRepo.Setup(r => r.DeleteResult(It.IsAny<int>())).ReturnsAsync(result);

        // Act
        Result? deletedResult = await resultService.DeleteResult(1); // 1 is the ID of the result to be deleted

        // Assert
        Assert.NotNull(deletedResult);
        Assert.Equal(result.ResultID, deletedResult.ResultID);
    }

    [Fact]
    public void GetResults_ReturnsAllResults()
    {
        // Arrange
        Mock<IResultRepo> mockResultRepo = new();
        ResultService resultService = new(mockResultRepo.Object);

        ICollection<Result> results = new List<Result>
        {
            new Result
            {
                ResultID = 1,
                UserId = "1",
                ResultValue = "Golden Retriever"
            },
            new Result
            {
                ResultID = 2,
                UserId = "2",
                ResultValue = "Poodle"
            }
        };
        mockResultRepo.Setup(r => r.GetResults()).ReturnsAsync(results);

        // Act
        ICollection<Result> fetchedResults = resultService.GetResults().Result;

        // Assert
        Assert.Equal(results, fetchedResults);
    }

    [Fact]
    public async void UpdateResult_ShouldSuccesfullyUpdateResult()
    {
        // Arrange
        Mock<IResultRepo> mockResultRepo = new();
        ResultService resultService = new(mockResultRepo.Object);

        ResultDTO resultDTO = new()
        {
            ResultValue = "Golden Retriever"
        };

        Result result = new()
        {
            ResultID = 1,
            ResultValue = "Golden Retriever"
        };

        mockResultRepo.Setup(r => r.GetResultByID(It.IsAny<int>())).ReturnsAsync(result);
        mockResultRepo.Setup(r => r.UpdateResult(It.IsAny<int>(), It.IsAny<Result>())).ReturnsAsync(result);

        // Act
        Result updatedResult = await resultService.UpdateResult(1, resultDTO);

        // Assert
        Assert.Equal(result.ResultID, updatedResult.ResultID);
    }

    [Fact]
    public async void GetResultsByUserID_ShouldReturnResultsByUserID()
    {
        // Arrange
        Mock<IResultRepo> mockResultRepo = new();
        ResultService resultService = new(mockResultRepo.Object);

        ICollection<Result> results = new List<Result>
        {
            new Result
            {
                ResultID = 1,
                UserId = "1",
                ResultValue = "Golden Retriever"
            },
            new Result
            {
                ResultID = 2,
                UserId = "2",
                ResultValue = "Poodle"
            }
        };
        mockResultRepo.Setup(r => r.GetResultsByUserID(It.IsAny<string>())).ReturnsAsync(results);

        // Act
        ICollection<Result> fetchedResults = resultService.GetResultsByUserID("1").Result;

        // Assert
        Assert.Equal(results, fetchedResults);
    }
    [Fact]
    public async void GetResultByID_ShouldReturnResultByID()
    {
        // Arrange
        Mock<IResultRepo> mockResultRepo = new();
        ResultService resultService = new(mockResultRepo.Object);

        Result result = new()
        {
            ResultID = 1,
            UserId = "1",
            ResultValue = "Golden Retriever"
        };
        mockResultRepo.Setup(r => r.GetResultByID(It.IsAny<int>())).ReturnsAsync(result);

        // Act
        Result fetchedResult = resultService.GetResultByID(1).Result;

        // Assert
        Assert.Equal(result, fetchedResult);
    }
    [Fact]
    public async void GetResultsByUserID_ShouldThrowInvalidResultException()
    {
        // Arrange
        Mock<IResultRepo> mockResultRepo = new();
        ResultService resultService = new(mockResultRepo.Object);

        mockResultRepo.Setup(r => r.GetResultsByUserID(It.IsAny<string>())).ReturnsAsync((ICollection<Result>)null!);

        // Act and Assert
        await Assert.ThrowsAsync<InvalidResultException>(() => resultService.GetResultsByUserID("1"));
    }
    [Fact]
    public async void GetResults_ShouldThrowInvalidResultException()
    {
        // Arrange
        Mock<IResultRepo> mockResultRepo = new();
        ResultService resultService = new(mockResultRepo.Object);

        mockResultRepo.Setup(r => r.GetResults()).ReturnsAsync((ICollection<Result>)null!);

        // Act and Assert
        await Assert.ThrowsAsync<InvalidResultException>(() => resultService.GetResults());
    }
    [Fact]
    public async void DeleteResult_ShouldThrowInvalidResultException()
    {
        // Arrange
        Mock<IResultRepo> mockResultRepo = new();
        ResultService resultService = new(mockResultRepo.Object);

        mockResultRepo.Setup(r => r.DeleteResult(It.IsAny<int>())).ReturnsAsync((Result)null!);
        mockResultRepo.Setup(r => r.GetResultByID(It.IsAny<int>())).ReturnsAsync((Result)null!);

        // Act and Assert
        await Assert.ThrowsAsync<InvalidResultException>(() => resultService.DeleteResult(1));
    }
    
    [Fact]
    public async void UpdateResult_ShouldThrowInvalidResultException()
    {
        // Arrange
        Mock<IResultRepo> mockResultRepo = new();
        ResultService resultService = new(mockResultRepo.Object);

        ResultDTO resultDTO = new()
        {
            ResultValue = "Golden Retriever"
        };

        mockResultRepo.Setup(r => r.GetResultByID(It.IsAny<int>())).ReturnsAsync((Result)null!);

        // Act and Assert
        await Assert.ThrowsAsync<InvalidResultException>(() => resultService.UpdateResult(1, resultDTO));
    }
}

