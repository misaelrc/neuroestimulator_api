using NeuroEstimulator.Framework.Enumerators;

namespace NeuroEstimulator.Domain.Enumerators;

public class PatientErrors : Enumeration
{
    public PatientErrors(int id, string code, string name) : base(id, code, name) { }

    public static PatientErrors PatientNotFound = new PatientErrors(1, "PT001", "Paciente não encontrado.");
}