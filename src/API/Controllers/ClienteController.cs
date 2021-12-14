using ClienteAPI.Application.Commands;
using ClienteAPI.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Utils.Controller;

namespace ClienteAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly IMediator _mediatr;

    public ClienteController(IMediator mediatr)
    {
        _mediatr = mediatr;
    }

    // GET: Cliente
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var command = new GetAllQuery();
        return await ControllerHelper.GetResponseAsync(this, _mediatr, command);
    }

    // GET: Cliente/1
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var command = new GetByIdQuery { Id = id };
        return await ControllerHelper.GetResponseAsync(this, _mediatr, command);
    }

    // POST: Cliente/Create
    [HttpPost("Create")]
    public async Task<IActionResult> Create(CadastraCommand command)
    {
        return await ControllerHelper.GetResponseAsync(this, _mediatr, command);
    }

    // GET: Cliente/Edit
    [HttpPut("Edit")]
    public async Task<IActionResult> Edit(AlteraCommand command)
    {
        return await ControllerHelper.GetResponseAsync(this, _mediatr, command);
    }

    // POST: Cliente/Deactivate/1
    [HttpPost("Deactivate/{id}")]
    public async Task<IActionResult> Deactivate(int id)
    {
        var command = new DeactivateCommand { Id = id };
        return await ControllerHelper.GetResponseAsync(this, _mediatr, command);
    }

    // DELETE: Cliente/Delete/1
    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new ExcluiCommand { Id = id };
        return await ControllerHelper.GetResponseAsync(this, _mediatr, command);
    }
}
