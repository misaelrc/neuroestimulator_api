using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using NeuroEstimulator.Data.Interfaces;
using NeuroEstimulator.Data.Repositories;
using NeuroEstimulator.Domain.Entities;
using NeuroEstimulator.Domain.Enumerators;
using NeuroEstimulator.Domain.Payloads;
using NeuroEstimulator.Domain.ViewModels;
using NeuroEstimulator.Framework.Database.EfCore.Interface;
using NeuroEstimulator.Framework.Exceptions;
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

    public PatientViewModel CreatePatient(CreatePatientPayload payload)
    {
        string standardPassword = _accountService.Encrypt("senha");
        var account = new Account(payload.Login, payload.Name, standardPassword);
        account.Activate();

        var patient = new Patient(payload.TherapistId, payload.Email, payload.Phone, payload.BirthDate, account, payload.CaretakerName, payload.CaretakerPhone);

        var profile = Task.Run(() => _profileRepository.GetAsync(x => x.Code == "neura_patient")).Result.First();
        _accountProfileRepository.Add(new AccountProfile(account, profile));
        _patientRepository.Add(patient);

        var result = Task.Run(() => _unitOfWork.CommitAsync()).Result;

        if (result)
        {
            var model = _mapper.Map<PatientViewModel>(patient);
            return model;
        }
        else
        {
            throw new InternalException(PatientErrors.ErrorOnCreatePatient);
        }
    }

    public PatientViewModel EditPatient(EditPatientPayload payload)
    {
        var patient = Task.Run(() => _patientRepository.GetByIdAsync(payload.Id)).Result;
        if (patient is null)
        {
            throw new BadRequestException(PatientErrors.PatientNotFound);
        }

        payload.Id = patient.Id;

        _mapper.Map(payload, patient);

        _patientRepository.Update(patient);


        var result = Task.Run(() => _unitOfWork.CommitAsync()).Result;

        if (result)
        {
            var model = _mapper.Map<PatientViewModel>(patient);
            return model;
        }
        else
        {
            throw new InternalException(PatientErrors.ErrorOnEditPatient);
        }
    }

    public bool DeletePatient(Guid id)
    {
        var patient = Task.Run(() => _patientRepository.GetByIdAsync(id)).Result;
        if (patient is null)
        {
            throw new BadRequestException(PatientErrors.PatientNotFound);
        }

        _accountRepository.Delete(patient.Account);

        var result = Task.Run(() => _unitOfWork.CommitAsync()).Result;
        return result;
    }

    public IList<ListPatientViewModel> GetAllPatients()
    {
        var result = Task.Run(() => _patientRepository.GetAsync(includeProperties: "Account")).Result;

        var model = _mapper.Map<List<ListPatientViewModel>>(result);
        return model;
    }

    public PatientViewModel GetPatientById(Guid id)
    {
        var result = Task.Run(() => _patientRepository.GetByIdAsync(id)).Result;
        if(result is null)
        {
            throw new BadRequestException(PatientErrors.PatientNotFound);
        }
        var model = _mapper.Map<PatientViewModel>(result);
        return model;
    }

    public bool AllowSessions(Guid id)
    {
        var patient = Task.Run(() => _patientRepository.GetByIdAsync(id)).Result;
        if (patient is null)
        {
            throw new BadRequestException(PatientErrors.PatientNotFound);
        }

        patient.AllowSessions();

        _patientRepository.Update(patient);
        var result = Task.Run(() => _unitOfWork.CommitAsync()).Result;
        return result;
    }

    public bool DisallowSessions(Guid id)
    {
        var patient = Task.Run(() => _patientRepository.GetByIdAsync(id)).Result;
        if (patient is null)
        {
            throw new BadRequestException(PatientErrors.PatientNotFound);
        }

        patient.DisallowSessions();

        _patientRepository.Update(patient);
        var result = Task.Run(() => _unitOfWork.CommitAsync()).Result;
        return result;
    }

    public bool SetParameters(SetPatientParametersPayload payload)
    {
        var patient = Task.Run(() => _patientRepository.GetByIdAsync(payload.PatientId)).Result;
        if (patient is null)
        {
            throw new BadRequestException(PatientErrors.PatientNotFound);
        }
        var parameters = patient.Parameters;
        if(parameters is null)
        {
            parameters = new SessionParameters(payload.Amplitude, payload.Frequency, payload.StimulationTime, payload.MaxPulseWidth, payload.MinPulseWidth); 
            patient.SetParameters(parameters);
        }
        else
        {
            parameters.SetAmplitude(payload.Amplitude);
            parameters.SetFrequency(payload.Frequency);
            parameters.SetMaxPulseWidth(payload.MaxPulseWidth);
            parameters.SetMinPulseWidth(payload.MinPulseWidth);
            parameters.SetStimulationTime(payload.StimulationTime);
        }
        patient.SetRepetitions(payload.Repetitions);
        
        _patientRepository.Update(patient);
        
        var result = Task.Run(() => _unitOfWork.CommitAsync()).Result;
        return result;
    }

    public SessionParameters GetParameters(Guid id)
    {
        var patient = Task.Run(() => _patientRepository.GetByIdAsync(id)).Result;
        if (patient is null) throw new BadRequestException(PatientErrors.PatientNotFound);

        var parameters = patient.Parameters;
        if (parameters is null) throw new BadRequestException(PatientErrors.PatientWithoutParameters);


        return parameters;
    }
}
