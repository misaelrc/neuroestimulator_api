using NeuroEstimulator.Framework.Database.EfCore.Model;

namespace NeuroEstimulator.Domain.Entities;

public class Patient : AuditEntity<Guid>
{
    public Patient() { }

    public Patient(string email, string phone, DateTime birthDate, Account account, string? caretakerName = null, string? caretakerPhone = null)
    {
        SetId(Guid.NewGuid());
        this.Email = email;
        this.Phone = phone;
        this.BirthDate = birthDate;
        this.Account = account;
        this.CaretakerName = caretakerName;
        this.CaretakerPhone = caretakerPhone;
        Activate();
    }
    public string Email { get; set; }
    public string Phone { get; set; }

    public Guid AccountId { get; private set; }
    public DateTime BirthDate { get; private set; }
    public bool SessionAllowed { get; private set; }

    public string? CaretakerName { get; set; }
    public string? CaretakerPhone { get; set; }
    public virtual Account Account { get; private set; }
}
