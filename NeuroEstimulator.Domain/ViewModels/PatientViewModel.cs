namespace NeuroEstimulator.Domain.ViewModels;

public class PatientViewModel
{
    public PatientViewModel() { }

    public Guid Id { get; set; }
    public string Login { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public bool SessionAllowed { get; private set; }
    public SessionParametersViewModel? Parameters { get; private set; }

    public string? CaretakerName { get; set; }
    public string? CaretakerPhone { get; set; }
}
