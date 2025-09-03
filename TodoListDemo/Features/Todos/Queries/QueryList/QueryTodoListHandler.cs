using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoListDemo.Data;
using TodoListDemo.Models;

namespace TodoListDemo.Features.Todos.Queries.QueryList;

public class QueryTodoListHandler : IRequestHandler<QueryTodoListQuery, TodoListResult>
{
    private readonly TodoContext _context;

    public QueryTodoListHandler(TodoContext context)
    {
        _context = context;
    }

    public async Task<TodoListResult> Handle(QueryTodoListQuery request, CancellationToken cancellationToken)
    {
        var query = _context.TodoItems.AsQueryable();

        if (!string.IsNullOrEmpty(request.Title))
        {
            query = query.Where(x => x.Title.Contains(request.Title));
        }

        var listAsync = await query.ToListAsync(cancellationToken);
        return new TodoListResult()
        {
            List = listAsync.Select(r => new TodoItem
            {
                Id = r.Id,
                Title = r.Title,
                Description = r.Description,
                IsCompleted = r.IsCompleted,
                CreatedAt = r.CreatedAt,
                CompletedAt = r.CompletedAt
            }).ToList()
        };
    }
}
