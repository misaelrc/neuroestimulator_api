using AutoMapper;
using NeuroEstimulator.Domain.ViewModels;

namespace NeuroEstimulator.Service.AutoMapper;

public class DomainToViewModelMappingProfile : Profile
{
    public DomainToViewModelMappingProfile()
    {
        CreateMap<NeuroEstimulator.Domain.Entities.Account, AccountViewModel>();
        CreateMap<NeuroEstimulator.Domain.Entities.Profile, ProfileViewModel>();
        CreateMap<NeuroEstimulator.Domain.Entities.Patient, ListPatientViewModel>()
            .ForMember(pvm => pvm.Name, opt => opt.MapFrom(p => p.Account.Name));
        CreateMap<NeuroEstimulator.Domain.Entities.Patient, PatientViewModel>()
            .ForMember(pvm => pvm.Name, opt => opt.MapFrom(p => p.Account.Name))
            .ForMember(pvm => pvm.Login, opt => opt.MapFrom(p => p.Account.Login));

        CreateMap<NeuroEstimulator.Domain.Entities.Session, SessionViewModel>();
        CreateMap<NeuroEstimulator.Domain.Entities.Session, ListSessionViewModel>();
        CreateMap<NeuroEstimulator.Domain.Entities.SessionPhoto, SessionPhotoViewModel>();
        CreateMap<NeuroEstimulator.Domain.Entities.SessionParameters, SessionParametersViewModel>();
        CreateMap<NeuroEstimulator.Domain.Entities.SessionSegment, SessionSegmentViewModel>();

    }
}
