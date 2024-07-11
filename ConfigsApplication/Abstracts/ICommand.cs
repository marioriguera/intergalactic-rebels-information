namespace ConfigsApplication.Abstracts;

public interface ICommand : IRequest<Error>
{
}

public interface ICommand<TResponse>
    : IRequest<ErrorOr<TResponse>>
{
}
