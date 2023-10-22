using NeuroEstimulator.Domain.ViewModels;

namespace NeuroEstimulator.Service.Interfaces;

public interface IAccountProfileService
{
    List<ProfileViewModel> GetAccountProfiles(Guid accountId);
}
