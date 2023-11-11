using NeuroEstimulator.Framework.Enumerators;

namespace NeuroEstimulator.Domain.Enumerators;

public class PatientErrors : Enumeration
{
    public PatientErrors(int id, string code, string name) : base(id, code, name) { }

    public static PatientErrors PatientNotFound = new PatientErrors(1, "PT001", "Paciente não encontrado.");
    public static PatientErrors PatientWithoutParameters = new PatientErrors(1, "PT002", "Paciente sem parâmetros setados.");
    public static PatientErrors ErrorOnCreatePatient = new PatientErrors(1, "PT003", "Erro ao criar paciente");
    public static PatientErrors ErrorOnEditPatient = new PatientErrors(1, "PT004", "Erro ao edita paciente");
}