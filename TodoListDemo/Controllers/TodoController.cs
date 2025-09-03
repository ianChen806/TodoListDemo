using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoListDemo.Features.Todos.Queries.QueryList;

namespace TodoListDemo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly IMediator _mediator;

    public TodoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("list")]
    public async Task<TodoListResult> List([FromBody] QueryTodoListQuery query)
    {
        var result = await _mediator.Send(query);
        return result;
    }

    // [HttpPost("detail")]
    // public async Task<ActionResult<TodoItem>> Detail([FromBody] GetTodoByIdQuery query)
    // {
    //
    // }

    // [HttpPost("create")]
    // public async Task<ActionResult<TodoItem>> Create([FromBody] CreateTodoCommand command)
    // {
    //
    // }

    // [HttpPost("update")]
    // public async Task<IActionResult> Update([FromBody] UpdateTodoCommand command)
    // {
    //
    // }

    // [HttpPost("delete")]
    // public async Task<IActionResult> Delete([FromBody] DeleteTodoCommand command)
    // {
    //
    // }

    // [HttpPost("done")]
    // public async Task<IActionResult> Done([FromBody] CompleteTodoCommand command)
    // {
    //
    // }
}
