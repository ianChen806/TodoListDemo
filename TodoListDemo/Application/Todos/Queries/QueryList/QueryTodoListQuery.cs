using MediatR;

namespace TodoListDemo.Application.Todos.Queries.QueryList;

public class QueryTodoListQuery : IRequest<TodoListResult>
{
    public string? Title { get; set; }
}
