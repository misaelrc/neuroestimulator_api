using AutoMapper;
using NeuroEstimulator.Data.Interfaces;
using NeuroEstimulator.Domain.ViewModels;
using NeuroEstimulator.Framework.Interfaces;
using NeuroEstimulator.Framework.Services;
using NeuroEstimulator.Service.Interfaces;

namespace NeuroEstimulator.Service.Services;

public class ProfileService : ServiceBase, IProfileService
{
    private readonly IAccountProfileRepository _profileRepository;
    private readonly IMapper _mapper;

    public ProfileService(
        IApiContext apiContext,
        IAccountProfileRepository profileRepository,
        IMapper mapper) 
        : base(apiContext)
    {
        _profileRepository = profileRepository;
        _mapper = mapper;
    }

    public IList<ProfileViewModel> GetProfilesByAccountIdApplicationId(Guid accountId)
    {
        var accountProfiles = Task.Run(() => _profileRepository.GetAccountProfiles(accountId)).Result;

        var profileViewModel = _mapper.Map<List<ProfileViewModel>>(accountProfiles.Select(c => c.Profile));

        return profileViewModel;
    }
}
