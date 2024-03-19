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

    [HttpGet("{trainingInfo}")]
    public ActionResult<TrainingInfoResponseDto> GetTraining(string trainingInfo)
    {
        TrainingInfoResponseDto result = _trainingService.GetTrainingInfo(trainingInfo);

        if (string.IsNullOrEmpty(result.EmployeeId))
        {
            return NotFound("what is u:(");
        }

        return Ok(result);
    }

    [HttpPost("sign-up-for-training")]
    public ActionResult<bool> SignUp(TrainingSignupDto signupForTrainingDto)
    {
        TrainingSignupResponseDto result = _trainingService.SignupForTraining(signupForTrainingDto);
        return Ok("see u there!");
    }

    [HttpPost("add-training")]
    public ActionResult<AddTrainingResponseDto> AddTraining(AddTrainingDto addTrainingDto)
    {
        AddTrainingResponseDto result = _trainingService.AddTraining(addTrainingDto);
        return Ok(result);
    }
}