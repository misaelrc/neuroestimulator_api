using NeuroEstimulator.Domain.Entities;
using NeuroEstimulator.Domain.Payloads;
using NeuroEstimulator.Domain.ViewModels;

namespace NeuroEstimulator.Service.Interfaces;

public interface IPatientService
{
    PatientViewModel CreatePatient(CreatePatientPayload payload);
    PatientViewModel EditPatient(EditPatientPayload payload);
    bool DeletePatient(Guid id);
    bool AllowSessions(Guid id);
    bool DisallowSessions(Guid id);
    IList<ListPatientViewModel> GetAllPatients();
    PatientViewModel GetPatientById(Guid id);

    bool SetParameters(SetPatientParametersPayload payload);
    SessionParameters GetParameters(Guid Id);
}
