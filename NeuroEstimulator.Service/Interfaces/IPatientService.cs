using NeuroEstimulator.Domain.Payloads;
using NeuroEstimulator.Domain.ViewModels;

namespace NeuroEstimulator.Service.Interfaces;

public interface IPatientService
{
    bool CreatePatient(CreatePatientPayload payload);
    IList<PatientViewModel> GetAllPatients();
}
