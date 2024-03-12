using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Entities;

namespace FitmoRE.Application.Repositories;
public interface ITrainingRepository
{
    string Add(TrainingSession trainingSession);

    TrainingSession GetById(string trainingId);

    TrainingInfoResponseDto Update(AddTrainingDto addTrainingDto);

    AddTrainingDto Delete(string trainingId);

    IEnumerable<TrainingInfoResponseDto> GetAll();
}