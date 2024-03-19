using FitmoRE.Application.DTO;
using FitmoRE.Application.Services.Interfaces;
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

    [HttpGet("{roomInfo}")]
    public ActionResult<RoomInfoResponseDto> Get(string roomInfo)
    {
        RoomInfoResponseDto result = _gymRoomService.GetRoomInfo(roomInfo);

        if (string.IsNullOrEmpty(result.BranchId))
        {
            return NotFound("what is u:(");
        }

        return Ok(result);
    }

    [HttpPost("add")]
    public ActionResult<AddRoomResponseDto> Add(AddRoomDto addRoomDto)
    {
        AddRoomResponseDto result = _gymRoomService.Add(addRoomDto);
        return Ok(result);
    }
}