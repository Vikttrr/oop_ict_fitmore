using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Entities;

namespace FitmoRE.Application.Repositories;
public interface ITrainingRepository
{
    string Add(TrainingSession trainingSession);

    TrainingSession? GetById(string trainingId);

    TrainingInfoResponseDto? Update(TrainingSession trainingSession);

    AddTrainingDto? Delete(string trainingId);

    IEnumerable<TrainingInfoResponseDto> GetAll();
}