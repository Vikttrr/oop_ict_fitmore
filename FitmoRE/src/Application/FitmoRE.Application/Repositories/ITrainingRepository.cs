using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Models;

namespace FitmoRE.Application.Repositories;
public interface ITrainingRepository
{
    string Add(TrainingSessionModel trainingSessionModel);

    TrainingSessionModel? GetById(string trainingId);

    TrainingInfoResponseDto? Update(TrainingSessionModel trainingSessionModel);

    AddTrainingDto? Delete(string trainingId);

    IEnumerable<TrainingInfoResponseDto> GetAll();
}