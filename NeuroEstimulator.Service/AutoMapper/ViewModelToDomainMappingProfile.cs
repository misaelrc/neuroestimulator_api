using AutoMapper;
using NeuroEstimulator.Domain.Payloads;
using NeuroEstimulator.Domain.ViewModels;

namespace NeuroEstimulator.Service.AutoMapper;

public class ViewModelToDomainMappingProfile : Profile
{
    public ViewModelToDomainMappingProfile()
    {
        CreateMap<EditPatientPayload, NeuroEstimulator.Domain.Entities.Patient>()
            .ForPath(p => p.Account.Login, opt => opt.MapFrom(epp => epp.Login))
            .ForPath(p => p.Account.Name, opt => opt.MapFrom(epp => epp.Name));
            //.ForMember(pvm => pvm.Account.Name, opt => opt.MapFrom(p => p.Name))
            //.ForMember(pvm => pvm.Account.Login, opt => opt.MapFrom(p => p.Login));
    }
}
