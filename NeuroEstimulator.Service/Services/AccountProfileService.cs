using AutoMapper;
using NeuroEstimulator.Data.Interfaces;
using NeuroEstimulator.Domain.Enumerators;
using NeuroEstimulator.Domain.ViewModels;
using NeuroEstimulator.Framework.Exceptions;
using NeuroEstimulator.Framework.Interfaces;
using NeuroEstimulator.Framework.Services;
using NeuroEstimulator.Service.Interfaces;

namespace NeuroEstimulator.Service.Services;

public class AccountProfileService : ServiceBase, IAccountProfileService
{
    private readonly IMapper _mapper;
    private readonly IAccountProfileRepository _accountProfileRepository;
    private readonly IProfileRepository _profileRepository;

    public AccountProfileService(
        IApiContext apiContext,
        IMapper mapper,
        IProfileRepository profileRepository,
        IAccountProfileRepository accountProfileRepository)
        : base(apiContext)
    {
        _mapper = mapper;
        _profileRepository = profileRepository;
        _accountProfileRepository = accountProfileRepository;
    }

    public List<ProfileViewModel> GetAccountProfiles(Guid accountId)
    {
        var result = Task.Run(() => _accountProfileRepository
            .GetAsync(x => x.AccountId == accountId)).Result;

        if (!result.Any())
        {
            throw new BadRequestException(AccountErrors.WithoutPermissions);
        }

        var profileIds = result.Select(x => x.ProfileId).ToList();
        var profiles = Task.Run(() => _profileRepository.GetAsync(x => profileIds.Contains(x.Id))).Result;
        var model = _mapper.Map<List<ProfileViewModel>>(profiles);
        return model;
    }
}
