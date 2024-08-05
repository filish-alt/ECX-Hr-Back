using AutoMapper;
using ECX.HR.Application.CQRS.Employee.Request.Command;
using ECX.HR.Application.Exceptions;
using ECX.HR.Application.Contracts.Persistent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECX.HR.Application.Contracts.Persistence;

namespace ECX.HR.Application.CQRS.Employee.Handler.Command
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
    {
        private IEmployeeRepository _EmployeeRepository;
        private IAdressRepository _AddressRepository; 
         private IEmergencyContactRepository  _EmergencyContactRepository;
        private ISpouseRepository _SpouseRepository;
        IEducationRepository _EducationRepository;
        private IWorkExperienceRepository _WorkExperienceRepository;
        private IDepositAutorizationRepository _DepositAutorizationRepository;
        private IEmployeePositionRepository _EmployeePositionRepository;
        private ITrainingRepository _TrainingRepository;
        private readonly ILeaveRequestRepository leaveRequestRepository;
        private ILeaveRequestRepository _LeaveRequestRepository;
        private ILeaveBalanceRepository _LeaveBalanceRepository;
        private readonly IMedicalBalanceRepository _medicalBalanceRepository;
        private readonly IOtherLeaveBalanceRepository _otherLeaveBalanceRepository;
        private IMapper _mapper;
        public DeleteEmployeeCommandHandler(IEmployeeRepository EmployeeRepository, 
            IAdressRepository AddressRepository,
            IEmergencyContactRepository EmergencyContactRepository, 
            ISpouseRepository SpouseRepository, 
            IEducationRepository EducationRepository,
            IWorkExperienceRepository WorkExperienceRepository,
            IDepositAutorizationRepository DepositAutorizationRepository,
            IEmployeePositionRepository EmployeePositionRepository,
            ITrainingRepository TrainingRepository,
                  ILeaveRequestRepository LeaveRequestRepository,
                          ILeaveBalanceRepository LeaveBalanceRepository,
                          IMedicalBalanceRepository MedicalBalanceRepository,
                          IOtherLeaveBalanceRepository  OtherLeaveBalanceRepository,


            IMapper mapper)
        {
            _EmployeeRepository = EmployeeRepository;
            _AddressRepository= AddressRepository;
            _EmergencyContactRepository = EmergencyContactRepository;
            _SpouseRepository = SpouseRepository;
            _EducationRepository = EducationRepository;
            _WorkExperienceRepository = WorkExperienceRepository;
            _DepositAutorizationRepository = DepositAutorizationRepository;
            _EmployeePositionRepository = EmployeePositionRepository;
            _TrainingRepository = TrainingRepository;
            _LeaveRequestRepository = LeaveRequestRepository;
            _LeaveBalanceRepository = LeaveBalanceRepository;
            _medicalBalanceRepository = MedicalBalanceRepository;
            _otherLeaveBalanceRepository = OtherLeaveBalanceRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var Employee = await _EmployeeRepository.GetById(request.EmpId);
            Employee.Status = 1;

            await _EmployeeRepository.Update(Employee);


            var address = await _AddressRepository.GetByEmpId(request.EmpId);
            // Assuming '1' represents the 'Deleted' status
            address.Status = 1;

            await _AddressRepository.Update(address);

            var EmergencyContact = await _EmergencyContactRepository.GetByEmpId(request.EmpId);
            foreach (var emergencyContact in EmergencyContact)
            {
                emergencyContact.Status = 1;
                await _EmergencyContactRepository.Update(emergencyContact);
            }




            var Spouse = await _SpouseRepository.GetByEmpId(request.EmpId);
            foreach (var spouse in Spouse)
            {
                spouse.Status = 1;
                await _SpouseRepository.Update(spouse);
            }

            var Education = await _EducationRepository.GetByEmpId(request.EmpId);
            foreach (var education in Education)
            {
                education.Status = 1;
                await _EducationRepository.Update(education);
            }

            var WorkExperience = await _WorkExperienceRepository.GetByEmpId(request.EmpId);
            foreach (var workExperience in WorkExperience)
            {
                workExperience.Status = 1;
                await _WorkExperienceRepository.Update(workExperience);
            }

            var DepositAutorization = await _DepositAutorizationRepository.GetByEmpId(request.EmpId);
            DepositAutorization.Status = 1;
            await _DepositAutorizationRepository.Update(DepositAutorization);

            var EmployeePosition = await _EmployeePositionRepository.GetByEmpId(request.EmpId);
            EmployeePosition.Status = 1;
            await _EmployeePositionRepository.Update(EmployeePosition);

            var Training = await _TrainingRepository.GetByEmpId(request.EmpId);
            foreach (var training in Training)
            {
                training.Status = 1;
                await _TrainingRepository.Update(training);
}
                return Unit.Value;
            
        }

        async Task IRequestHandler<DeleteEmployeeCommand>.Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var Employee = await _EmployeeRepository.GetById(request.EmpId);
            if (Employee == null) 
                throw new NotFoundException(nameof(Employee), request.EmpId);
            Employee.Status = 1;
            await _EmployeeRepository.Update(Employee);

            var address = await _AddressRepository.GetByEmpId(request.EmpId);

            if (address != null)
            {
            address.Status = 1;

            await _AddressRepository.Update(address);
            }
        



            var EmergencyContact = await _EmergencyContactRepository.GetByEmpId(request.EmpId);
            if (EmergencyContact != null)
            {
                foreach (var emergencyContact in EmergencyContact)
                {
                    emergencyContact.Status = 1;
                    await _EmergencyContactRepository.Update(emergencyContact);
                }

            }

            var Spouse = await _SpouseRepository.GetByEmpId(request.EmpId);
            if (Spouse != null)
            {
                foreach (var spouse in Spouse)
                {
                    spouse.Status = 1;
                    await _SpouseRepository.Update(spouse);
                }
            }
            var Education = await _EducationRepository.GetByEmpId(request.EmpId);
            if (Education != null)
            {
                foreach (var education in Education)
                {
                    education.Status = 1;
                    await _EducationRepository.Update(education);
                }
            }

            var WorkExperience = await _WorkExperienceRepository.GetByEmpId(request.EmpId);
            if (WorkExperience != null)
            {
                foreach (var workExperience in WorkExperience)
                {
                    workExperience.Status = 1;
                    await _WorkExperienceRepository.Update(workExperience);
                }
            }

            var DepositAutorization = await _DepositAutorizationRepository.GetByEmpId(request.EmpId);
            if (DepositAutorization != null)
            {
                DepositAutorization.Status = 1;
                await _DepositAutorizationRepository.Update(DepositAutorization);
            }
            var EmployeePosition = await _EmployeePositionRepository.GetByEmpId(request.EmpId);
            if (EmployeePosition != null)
            {
                EmployeePosition.Status = 1;
                await _EmployeePositionRepository.Update(EmployeePosition);
            }
            var Training = await _TrainingRepository.GetByEmpId(request.EmpId);
            if (Training != null)
            {
                foreach (var training in Training)
                {
                    training.Status = 1;
                    await _TrainingRepository.Update(training);

                }
            }

            var LeaveRequest = await _LeaveRequestRepository.GetByEmpId(request.EmpId);
            if (LeaveRequest != null)
            {
                foreach (var leaveRequest in LeaveRequest)
                {
                    leaveRequest.Status = 1;
                    await _LeaveRequestRepository.Update(leaveRequest);
                }
            }

            var LeaveBalance = await _LeaveBalanceRepository.GetByEmpId(request.EmpId);
            if (LeaveBalance != null)
            {
                foreach (var leaveBalance in LeaveBalance)
                {
                    leaveBalance.Status = 1;
                    await _LeaveBalanceRepository.Update(leaveBalance);
                }
            }
            var MedicalBalance = await _medicalBalanceRepository.GetByEmpId(request.EmpId);
            if (MedicalBalance != null)
            {
                foreach (var medicalBalance in MedicalBalance)
                {
                    medicalBalance.Status = 1;
                    await _medicalBalanceRepository.Update(medicalBalance);
                }
            }

            var OtherLeaveBalance = await _otherLeaveBalanceRepository.GetByEmpId(request.EmpId);
            if (OtherLeaveBalance != null)
            {
                foreach (var otherLeaveBalance in OtherLeaveBalance)
                {
                    otherLeaveBalance.Status = 1;
                    await _otherLeaveBalanceRepository.Update(otherLeaveBalance);
                }
            }




        }
    }
}
