using FitmoRE.Application.DTO;
using MediatR;

namespace FitmoRE.Application.Events.Queries;

public class GetUserInfoQuery : IRequest<UserInfoResponseDto>
{
    public string ClientId { get; }

    public GetUserInfoQuery(string clientId)
    {
        ClientId = clientId;
    }
}