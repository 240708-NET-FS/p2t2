
using Pawsonality.API.Models;

namespace PawsonalityApp.API.Utility;

public static class AnswerUtility
{
    public static Answer AnswerDTOToAnswer(AnswerDTO answerDTO)
    {
        return new Answer
        {
            AnswerText = answerDTO.AnswerText,
            AnswerType = answerDTO.AnswerType
        };
    }
}

public static class QuestionUtility
{
    public static Question QuestionDTOToQuestion(QuestionDTO questionDTO)
    {
        return new Question
        {
            QuestionText = questionDTO.QuestionText
        };
    }

}

public static class ResultUtility
{
    public static Result ResultDTOToResult(ResultDTO resultDTO)
    {
        return new Result
        {
            TimeStamp = DateTime.Now,
            UserId = resultDTO.UserId!,
            ResultValue = resultDTO.ResultValue
        };
    }
}

