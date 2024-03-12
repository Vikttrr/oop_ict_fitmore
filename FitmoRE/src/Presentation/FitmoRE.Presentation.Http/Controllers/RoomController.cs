using FitmoRE.Application.DTO;
using FitmoRE.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitmoRE.Presentation.Http.Controllers;
[ApiController]
[Route("[controller]")]
public class RoomController : ControllerBase
{
    private readonly IRoomService _gymRoomService;

    public RoomController(IRoomService gymRoomService)
    {
        _gymRoomService = gymRoomService;
    }

    [HttpGet("{roomInfoDto}")]
    public ActionResult<RoomInfoResponseDto> Get(RoomInfoDto roomInfoDto)
    {
        var result = _gymRoomService.GetRoomInfo(roomInfoDto);

        if (string.IsNullOrEmpty(result.BranchId))
        {
            return NotFound();
        }

        return Ok(result);
    }
}