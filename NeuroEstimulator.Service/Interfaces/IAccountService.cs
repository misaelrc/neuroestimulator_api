using NeuroEstimulator.Domain.Payloads;
using NeuroEstimulator.Domain.ViewModels;

namespace NeuroEstimulator.Service.Interfaces;

public interface IAccountService
{
    AuthorizationViewModel Authorization(AuthorizationPayload payload);
    AuthorizationViewModel RefreshToken();
    string Encrypt(string toEncrypt);
}
