namespace FitmoRE.Application.Repositories;

using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Entities;

public interface ITrainingRepository
{
    string Add(TrainingSession trainingSession);

    TrainingSession GetById(string trainingId);

    TrainingInfoResponseDto Update(AddTrainingDto addTrainingDto);

    AddTrainingDto Delete(string trainingId);

    IEnumerable<TrainingInfoResponseDto> GetAll();
}