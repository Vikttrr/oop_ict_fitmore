using FitmoRE.Application.DTO;
using FitmoRE.Application.Services;
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
    public ActionResult<TrainingInfoResponseDto> GetTraining(TrainingInfoDto trainingInfoDto)
    {
        var result = _trainingService.GetTrainingInfo(trainingInfoDto.TrainingId);

        if (string.IsNullOrEmpty(result.EmployeeId))
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost("signupForTraining")]
    public ActionResult<bool> SignUp(TrainingSignupDto signupForTrainingDto)
    {
        var result = _trainingService.SignupForTraining(signupForTrainingDto);
        return Ok(result);
    }

    [HttpPost("addTraining")]
    public ActionResult<AddTrainingResponseDto> AddTraining(AddTrainingDto addTrainingDto)
    {
        var result = _trainingService.AddTraining(addTrainingDto);
        return Ok(result);
    }
}