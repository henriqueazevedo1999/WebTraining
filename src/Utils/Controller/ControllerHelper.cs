using MediatR;
using Microsoft.AspNetCore.Mvc;
using Utils.Response;

namespace Utils.Controller;

public static class ControllerHelper
{
    public static async Task<IActionResult> GetResponseAsync<TResponse>(ControllerBase controller, IMediator mediator, IRequest<TResponse> request) where TResponse : IResponse
    {
        IResponse response = await mediator.Send(request);

        if (response.Errors.Any())
        {
            return controller.BadRequest(response.Errors);
        }

        return controller.Ok(response);
    }
}
