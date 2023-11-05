using AutoMapper;
using NeuroEstimulator.Domain.ViewModels;

namespace NeuroEstimulator.Service.AutoMapper;

public class DomainToViewModelMappingProfile : Profile
{
    public DomainToViewModelMappingProfile()
    {
        CreateMap<NeuroEstimulator.Domain.Entities.Account, AccountViewModel>();
        CreateMap<NeuroEstimulator.Domain.Entities.Profile, ProfileViewModel>();
        CreateMap<NeuroEstimulator.Domain.Entities.Patient, PatientViewModel>()
            .ForMember(pvm => pvm.Name, opt => opt.MapFrom(p => p.Account.Name));

        CreateMap<NeuroEstimulator.Domain.Entities.Session, SessionViewModel>();

    }
}
