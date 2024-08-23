
namespace PawsonalityApp.API.Exceptions;

public class InvalidUserException : Exception
{
    public InvalidUserException(){}
    public InvalidUserException(string message) : base(message){}
    public InvalidUserException(string message, Exception inner) : base(message, inner){}
}

public class InvalidAnswerException : Exception
{
    public InvalidAnswerException(){}
    public InvalidAnswerException(string message) : base(message){}
    public InvalidAnswerException(string message, Exception inner) : base(message, inner){}
}

public class InvalidQuestionException : Exception
{
    public InvalidQuestionException(){}
    public InvalidQuestionException(string message) : base(message){}
    public InvalidQuestionException(string message, Exception inner) : base(message, inner){}
}

public class InvalidResultException : Exception
{
    public InvalidResultException(){}
    public InvalidResultException(string message) : base(message){}
    public InvalidResultException(string message, Exception inner) : base(message, inner){}
}