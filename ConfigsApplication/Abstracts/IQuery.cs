namespace ConfigsApplication.Abstracts;

public interface IQuery<TResponse>
    : IRequest<ErrorOr<TResponse>>
{
}
