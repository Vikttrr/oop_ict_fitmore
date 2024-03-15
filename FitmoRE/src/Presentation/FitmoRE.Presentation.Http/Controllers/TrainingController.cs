using FitmoRE.Application.DTO;
using FitmoRE.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FitmoRE.Presentation.Http.Controllers;
[ApiController]
[Route("[controller]")]
public class TrainingController : ControllerBase
{
    private readonly ITrainingService _trainingService;

    public TrainingController(ITrainingService trainingService)
    {
        _trainingService = trainingService;
    }

    [HttpGet("{trainingInfoDto}")]
    public ActionResult<TrainingInfoResponseDto> GetTraining(string trainingInfoDto)
    {
        TrainingInfoResponseDto result = _trainingService.GetTrainingInfo(trainingInfoDto);

        if (string.IsNullOrEmpty(result.EmployeeId))
        {
            return NotFound("what is u:(");
        }

        return Ok(result);
    }

    [HttpPost("signupForTraining")]
    public ActionResult<bool> SignUp(TrainingSignupDto signupForTrainingDto)
    {
        TrainingSignupResponseDto result = _trainingService.SignupForTraining(signupForTrainingDto);
        return Ok("see u there!");
    }

    [HttpPost("addTraining")]
    public ActionResult<AddTrainingResponseDto> AddTraining(AddTrainingDto addTrainingDto)
    {
        AddTrainingResponseDto result = _trainingService.AddTraining(addTrainingDto);
        return Ok(result);
    }
}