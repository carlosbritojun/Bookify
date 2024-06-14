using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Api.Shared;

public abstract class BookifyControllerBase : ControllerBase
{
    protected BookifyControllerBase(ISender sender)
    {
        Bus = sender;
    }

    protected ISender Bus { get; }
}
