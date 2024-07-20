namespace ConfigsApplication.Abstracts;

public interface IQueryHandler<TQuery, TResponse>
      : IRequestHandler<TQuery, ErrorOr<TResponse>>
        where TQuery : IQuery<TResponse>
{
}
