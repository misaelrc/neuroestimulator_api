using NeuroEstimulator.Framework.Database.EfCore.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeuroEstimulator.Domain.Entities;

public class Patient : AuditEntity<Guid>
{
    public Patient() { }

    public Patient(Guid therapistId, string email, string phone, DateTime birthDate, Account account, string? caretakerName = null, string? caretakerPhone = null)
    {
        SetId(Guid.NewGuid());
        this.Email = email;
        this.Phone = phone;
        this.BirthDate = birthDate;
        this.Account = account;
        this.CaretakerName = caretakerName;
        this.CaretakerPhone = caretakerPhone;
        this.TherapistId = therapistId;
        Activate();
    }
    public string Email { get; set; }
    public string Phone { get; set; }

    public Guid AccountId { get; private set; }
    public Guid TherapistId { get; private set; }
    public Guid? ParametersId { get; private set; }
    public DateTime BirthDate { get; private set; }
    public bool SessionAllowed { get; private set; }

    public string? CaretakerName { get; set; }
    public string? CaretakerPhone { get; set; }
    public virtual Account Account { get; private set; }
    public virtual Account Therapist { get; private set; }
    public virtual SessionParameters? Parameters { get; private set; }


    [NotMapped]
    public string Name
    {
        get { return Account.Name; }
        set { Account.SetName(value); }
    }

    [NotMapped]
    public string Login
    {
        get { return Account.Login; }
        set { Account.SetLogin(value); }
    }

    public void SetParameters(SessionParameters parameters) => Parameters = parameters;
    public void AllowSessions() => SessionAllowed = true;
    public void DisallowSessions() => SessionAllowed = false;
}
