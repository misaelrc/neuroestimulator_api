using AutoMapper;
using NeuroEstimulator.Data.Interfaces;
using NeuroEstimulator.Data.Repositories;
using NeuroEstimulator.Domain.Entities;
using NeuroEstimulator.Domain.Payloads;
using NeuroEstimulator.Domain.ViewModels;
using NeuroEstimulator.Framework.Database.EfCore.Interface;
using NeuroEstimulator.Framework.Interfaces;
using NeuroEstimulator.Framework.Services;
using NeuroEstimulator.Service.Interfaces;
using System.Text;

namespace NeuroEstimulator.Service.Services;

public class PatientService : ServiceBase, IPatientService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPatientRepository _patientRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly IProfileRepository _profileRepository;
    private readonly IAccountProfileRepository _accountProfileRepository;
    private readonly IAccountService _accountService;
    private readonly IMapper _mapper;

    public PatientService(
        IApiContext apiContext,
        IUnitOfWork unitOfWork,
        IPatientRepository patientRepository,
        IAccountRepository accountRepository,
        IProfileRepository profileRepository,
        IAccountProfileRepository accountProfileRepository,
        IAccountService accountService,
        IMapper mapper) 
        : base(apiContext)
    {
        _unitOfWork = unitOfWork;
        _patientRepository = patientRepository;
        _accountRepository = accountRepository;
        _profileRepository = profileRepository;
        _accountProfileRepository = accountProfileRepository;
        _accountService = accountService;
        _mapper = mapper;
    }

    public bool CreatePatient(CreatePatientPayload payload)
    {
        string standardPassword = _accountService.Encrypt("senha");
        var account = new Account(payload.Login, payload.Name, standardPassword);
        account.Activate();

        var patient = new Patient(payload.Email, payload.Phone, payload.BirthDate, account, payload.CaretakerName, payload.CaretakerPhone);

        var profile = Task.Run(() => _profileRepository.GetAsync(x => x.Code == "neura_patient")).Result.First();
        _accountProfileRepository.Add(new AccountProfile(account, profile));
        _patientRepository.Add(patient);

        var result = Task.Run(() => _unitOfWork.CommitAsync()).Result;

        // se não der certo, lançar exception
        return result;
    }

    public IList<PatientViewModel> GetAllPatients()
    {
        var result = Task.Run(() => _patientRepository.GetAsync(includeProperties: "Account")).Result;

        var model = _mapper.Map<List<PatientViewModel>>(result);
        return model;
    }
}
