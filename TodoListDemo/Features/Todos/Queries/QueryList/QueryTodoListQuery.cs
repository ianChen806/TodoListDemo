using MediatR;

namespace TodoListDemo.Features.Todos.Queries.QueryList;

public class QueryTodoListQuery : IRequest<TodoListResult>
{
    public string? Title { get; set; }
}
