using AutoMapper;
using NeuroEstimulator.Domain.ViewModels;

namespace NeuroEstimulator.Service.AutoMapper;

public class DomainToViewModelMappingProfile : Profile
{
    public DomainToViewModelMappingProfile()
    {
        CreateMap<NeuroEstimulator.Domain.Entities.Account, AccountViewModel>();
    }
}
