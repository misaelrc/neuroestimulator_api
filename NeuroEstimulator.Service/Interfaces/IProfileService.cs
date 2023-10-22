using NeuroEstimulator.Domain.ViewModels;

namespace NeuroEstimulator.Service.Interfaces;

public interface IProfileService
{
    IList<ProfileViewModel> GetProfilesByAccountIdApplicationId(Guid accountId);
}
