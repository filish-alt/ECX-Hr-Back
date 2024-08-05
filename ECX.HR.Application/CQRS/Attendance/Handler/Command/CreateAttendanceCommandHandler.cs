using AutoMapper;
using AutoMapper.Internal;
using Dapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Attendance.Request.Command;
using ECX.HR.Application.DTOs.Attendance.Validator;
using ECX.HR.Application.Exceptions;

using ECX.HR.Application.Response;
using ECX.HR.Domain;
using ECXHR_Service.Controllers;
using iTextSharp.text;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ECX.HR.Application.CQRS.Attendance.Handler.Command
{
    public class CreateAttendanceCommandHandler : IRequestHandler<CreateAttendanceCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;

        private IAttendanceRepository _AttendanceRepository;
        private IMapper _mapper;
        private readonly ICheckInOutRepository _checkInOutRepository;
        private readonly IUserOfNumRepository _userOfNumRepository;
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly INumRunRepository _numRunRepository;
        private readonly INumOfRunDelRepository _numOfRunDelRepository;
        private readonly ISchClassRepository _schClassRepository;
        private readonly IHolidayRepository _holidayRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IAttRepository _attRepository;

        public CreateAttendanceCommandHandler(IAttendanceRepository AttendanceRepository, IMapper mapper, ICheckInOutRepository checkInOutRepository,
            IUserOfNumRepository userOfNumRepository, IUserInfoRepository userInfoRepository, INumRunRepository numRunRepository,
            INumOfRunDelRepository numOfRunDelRepository, ISchClassRepository schClassRepository, IHolidayRepository holidayRepository,
            IEmployeeRepository employeeRepository, ILeaveRequestRepository leaveRequestRepository, IAttRepository attRepository)
        {
            _AttendanceRepository = AttendanceRepository;
            _mapper = mapper;

            _holidayRepository = holidayRepository;
            _employeeRepository = employeeRepository;
            _leaveRequestRepository = leaveRequestRepository;
            _attRepository = attRepository;
        }
        public async Task<BaseCommandResponse> Handle(CreateAttendanceCommand request, CancellationToken cancellationToken)
        {
            var checkinout = await _AttendanceRepository.GetByDate();

            if (checkinout.Count != 0)
            {

                response = new BaseCommandResponse();
                var validator = new AttendanceDtoValidator();
                var validationResult = await validator.ValidateAsync(request.AttendanceDto);

                if (validationResult.IsValid == false)
                {
                    response.Success = false;
                    response.Message = "Creation Faild";
                    response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                }

                DateTime CHECKIN = checkinout.FirstOrDefault().CHECKTIME.Value.Date;
                DateTime checkindate = CHECKIN;

                var checkout = checkinout.Where(d => d.CHECKTIME.Value.TimeOfDay > TimeSpan.Parse("17:16:00")).OrderBy(c => c.CHECKTIME.Value.Date).LastOrDefault();
                if (checkout != null)
                {
                    DateTime CHECKOUT = checkout.CHECKTIME.Value.Date;


                    string department = "";
                    int sch = 1;
                    var userInfoData = await _attRepository.GetUserInfoDataFromSourceDatabase();
                    DateTime? clockIn = null;
                    DateTime? clockOut = null;

                    int userid = 0;  
                    var schClassData = await _attRepository.GetTable1DataFromSourceDatabase();
                    var NumofRunData = await _attRepository.GetNumOfRunDataFromSourceDatabase();
                    var NumofRunDelData = await _attRepository.GetNumRunDelDataFromSourceDatabase();
                    foreach (var use in userInfoData)
                    {

                /*        var use = userInfoData.Find(t => t.USERID == 262);*/
                      /*  if (use.USERID == 262){
                       */ 
                            request.AttendanceDto.date = null;
                            var ff = await _attRepository.GetCheckInOutFromSourceDatabase(use.USERID, CHECKIN, CHECKOUT);

                            var checkClassData = ff.OrderBy(d => d.CHECKTIME).ToList();

                            var userOfNum = await _attRepository.GetUserOfNumFromSourceDatabase(use.USERID);


                         

                            var rowcount = userInfoData.Count;

                            // Get user's check-in and check-out data
                            var checkInOutData = checkClassData.ToList();


                            var userOfnumData = userOfNum.FirstOrDefault(x => x.USERID == use.USERID);
                            if (userOfnumData != null)
                            {
                                var numOfDelData = NumofRunDelData.Where(x => x.NUM_RUNID == userOfnumData.NUM_OF_RUN_ID && x.SDAYS == 1).ToList();

                                //   var numOfDelData = NumofRunDelData.Where(x => x.NUM_RUNID == userOfNum.NUM_OF_RUN_ID && x.SDAYS == 1).ToList();
                                //   var numOfDelData = NumofRunDelData.Where(x => x.NUM_RUNID == userOfnumData.NUM_OF_RUN_ID).ToList();

                                /*
                                              if ((scheduleData.StartTime + scheduleData.LateMinutes) < checkInOutData.CHECKTIME)
                                              {
                                                  var late = checkInOutData.CHECKTIME - scheduleData.StartTime;

                                              }
                                              if ((scheduleData.EndTime - scheduleData.EarlyMinutes) < checkInOutData.CHECKTIME)
                                              {
                                                  var late = checkInOutData.CHECKTIME - scheduleData.StartTime;

                                              }
                              */

                                List<Attendances> attendancesList = new List<Attendances>();

                                if (checkInOutData != null && checkInOutData.Count != 0)
                                {
                                    int perschedul = 0;
                                    // var userSchedules = schClassData.Where(s => s.schClassid == numOfDelData.SCHCLASSID);
                                    foreach (var num in numOfDelData)
                                    {
                                        var scheduleData = schClassData.Where(x => x.schClassid == num.SCHCLASSID).ToList();



                                        foreach (var schedule in scheduleData)
                                        {

                                            if (perschedul != schedule.schClassid)
                                            {

                                                checkindate = CHECKIN;
                                            }
                                            perschedul = schedule.schClassid;

                                            DateTime? ch = null;
                                            List<DateTime?> charray = new List<DateTime?>();
                                            foreach (var che in checkClassData)
                                            {
                                                if (che.CHECKTIME.Value.DayOfWeek == DayOfWeek.Sunday || che.CHECKTIME.Value.DayOfWeek == DayOfWeek.Saturday)
                                                {
                                                    continue;
                                                }

                                                var comp = (charray.Where(x => x.Value.Date == che.CHECKTIME.Value.Date));
                                                if (ch == null || !comp.Any())
                                                { 
                                                
                                             


                                                    if (ch == null || (che.CHECKTIME.Value.Date != ch.Value.Date))
                                                    {
                                                        clockIn = null;
                                                        clockOut = null;
                                                          userid = use.USERID;

                                                    }
                                                    var check = checkClassData.Where(x => x.CHECKTIME.Value.Date == che.CHECKTIME.Value.Date).ToList();
                                                    double absent = 0;

                                                    foreach (var chck in check)
                                                    {


                                                        if (checkindate.Date == chck.CHECKTIME.Value.Date)
                                                        {

                                                            absent = 0;
                                                            ch = chck.CHECKTIME;
                                                            charray.Add(ch);
                                                            DateTime dd = Convert.ToDateTime(schedule.CheckInTime1);
                                                            DateTime d2 = Convert.ToDateTime(schedule.CheckInTime2);

                                                            if (chck.CHECKTIME.Value.TimeOfDay >= dd.TimeOfDay &&
                                                               chck.CHECKTIME.Value.TimeOfDay <= d2.TimeOfDay && (clockIn == null || clockIn >= ch))
                                                            {

                                                                clockIn = chck.CHECKTIME;


                                                            }
                                                            DateTime ch1 = Convert.ToDateTime(schedule.CheckOutTime1);
                                                            DateTime ch2 = Convert.ToDateTime(schedule.CheckOutTime2);
                                                            if (chck.CHECKTIME.Value.TimeOfDay >= ch1.TimeOfDay &&
                                                              chck.CHECKTIME.Value.TimeOfDay <= ch2.TimeOfDay && (clockOut == null || clockOut <= ch))
                                                            {
                                                                clockOut = chck.CHECKTIME;
                                                            }

                                                        request.AttendanceDto.AttendanceId = che.USERID;


                                                        //attendancesList.Add(attendance);

                                                    }


                                                        else
                                                        {
                                                        request.AttendanceDto.AttendanceId = che.USERID;

                                                        clockIn = null;
                                                            clockOut = null;
                                                        }

                                                    }
                                                    //  TimeSpan tt = TimeSpan.FromHours(3.76);



                                                    TimeSpan? late = null;
                                                    TimeSpan? early = null;
                                                    request.AttendanceDto.Late = null;
                                                    request.AttendanceDto.Early = null;
                                                    request.AttendanceDto.TotalLE = DateTime.Parse("2000-01-01 00:00:00.000");
                                                    var ll = schedule.StartTime.AddMinutes(schedule.LateMinutes);

                                                    /*                               if (clockIn != null && clockOut != null && (clockOut.Value.TimeOfDay.Subtract(clockIn.Value.TimeOfDay)) >= tt)
                                                                                   {
                                                                                       late = null;
                                                                                       early = null;
                                                                                       request.AttendanceDto.date = clockIn.Value.Date;

                                                                                   }
                                                                                   else
                                                                                   {*/
                                                    if (clockIn != null)
                                                    {
                                                        //  request.AttendanceDto.date = clockIn.Value.Date;
                                                        if ((ll).TimeOfDay < clockIn.Value.TimeOfDay)
                                                        {

                                                            late = clockIn.Value.TimeOfDay.Subtract(schedule.StartTime.TimeOfDay);

                                                        }
                                                        request.AttendanceDto.Late = clockIn.Value.Date + late;
                                                        if (request.AttendanceDto.Late != null)
                                                        {
                                                            request.AttendanceDto.TotalLE += late;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        request.AttendanceDto.Late = null;
                                                    }
                                                    if (clockOut != null)

                                                    {
                                                        //      request.AttendanceDto.date = clockOut.Value.Date;

                                                        var ee = schedule.EndTime.AddMinutes(-(schedule.EarlyMinutes));

                                                        if (ee.TimeOfDay > clockOut.Value.TimeOfDay)
                                                        {
                                                            early = schedule.EndTime.TimeOfDay.Subtract(clockOut.Value.TimeOfDay);

                                                        }
                                                        request.AttendanceDto.Early = clockOut.Value.Date + early;
                                                        if (request.AttendanceDto.Early != null)
                                                        {
                                                            request.AttendanceDto.TotalLE += early;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        request.AttendanceDto.Early = null;

                                                    }
                                                    var employee = await _employeeRepository.GetAll();
                                                    var emp = employee.FirstOrDefault(e => e.AttendanceId == (request.AttendanceDto.AttendanceId.ToString()));
                                                    var holidays = await _holidayRepository.GetHolidaysFromTable(CHECKIN, CHECKOUT);


                                                    if ((clockIn != null && clockOut == null) ||
                                                        (clockIn == null && clockOut != null))
                                                    {
                                                        absent = 0.25;

                                                    }
                                                    if (clockOut == null && clockIn == null)
                                                    {



                                                        if (emp != null)
                                                        {
                                                            var leave = await _leaveRequestRepository.GetByEmpIdStatusDate(emp.EmpId, "Admin-Approved", checkindate.Date);

                                                            if (holidays.Any(holiday => holiday.Date.Date == checkindate.Date) || leave.Count != 0)
                                                            {
                                                                absent = 0;

                                                            }
                                                            else
                                                            {

                                                                absent = 0.5;
                                                                //  request.AttendanceDto.date = null;

                                                            }
                                                        }
                                                        else
                                                        {
                                                            absent = 0.5;

                                                        }
                                                    }

                                                request.AttendanceDto.EmpId = emp?.EmpId ?? null;


                                                    request.AttendanceDto.Id = Guid.NewGuid();
                                                    request.AttendanceDto.Department = use.TITLE;
                                                    request.AttendanceDto.ClockIn = clockIn;

                                                    request.AttendanceDto.ClockOut = clockOut;
                                                    request.AttendanceDto.OnDuty = schedule.StartTime;
                                                    request.AttendanceDto.OffDuty = schedule.EndTime;


                                                    request.AttendanceDto.TimeTable = schedule.schName;

                                                    request.AttendanceDto.date = checkindate;

                                                    if (checkindate.DayOfWeek == DayOfWeek.Friday)
                                                    {
                                                        checkindate = checkindate.AddDays(3);
                                                    }
                                                    else
                                                    {
                                                        checkindate = checkindate.AddDays(1);
                                                    }

                                                    // request.AttendanceDto.TotalLE = Convert.ToDecimal(request.AttendanceDto.Early.Value.TimeOfDay.Add(request.AttendanceDto.Late.Value.TimeOfDay));


                                                    request.AttendanceDto.AbsentDays = absent;




                                                    var Attendance = _mapper.Map<Attendances>(request.AttendanceDto);
                                                    
                                                await _AttendanceRepository.Add(Attendance);




                                                }
                                            }
                                        }


                                    }



                                }

                            }
                        }
                    }
               /* }*/
            }
            else
            {

                return null;
            }
            response.Success = true;
            response.Message = "Creation Successfull";
            return response;
        }


    }

}







/*using AutoMapper;
using Dapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Attendance.Request.Command;
using ECX.HR.Application.DTOs.Attendance.Validator;

using ECX.HR.Application.Exceptions;

using ECX.HR.Application.Response;
using ECX.HR.Domain;
using ECXHR_Service.Controllers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Attendance.Handler.Command
{
    public class CreateAttendanceCommandHandler : IRequestHandler<CreateAttendanceCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;

        private IAttendanceRepository _AttendanceRepository;
        private IMapper _mapper;
        private readonly ICheckInOutRepository _checkInOutRepository;
        private readonly IUserOfNumRepository _userOfNumRepository;
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly INumRunRepository _numRunRepository;
        private readonly INumOfRunDelRepository _numOfRunDelRepository;
        private readonly ISchClassRepository _schClassRepository;

        public CreateAttendanceCommandHandler(IAttendanceRepository AttendanceRepository, IMapper mapper, ICheckInOutRepository checkInOutRepository,
            IUserOfNumRepository userOfNumRepository, IUserInfoRepository userInfoRepository, INumRunRepository numRunRepository,
            INumOfRunDelRepository numOfRunDelRepository, ISchClassRepository schClassRepository)
        {
            _AttendanceRepository = AttendanceRepository;
            _mapper = mapper;
            _checkInOutRepository = checkInOutRepository;
            _userOfNumRepository = userOfNumRepository;
            _userInfoRepository = userInfoRepository;
            _numRunRepository = numRunRepository;
            _numOfRunDelRepository = numOfRunDelRepository;
            _schClassRepository = schClassRepository;
        }
        public async Task<BaseCommandResponse> Handle(CreateAttendanceCommand request, CancellationToken cancellationToken)
        {



            response = new BaseCommandResponse();
            var validator = new AttendanceDtoValidator();
            var validationResult = await validator.ValidateAsync(request.AttendanceDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
          // int Userid = 166;
            DateTime CHECKIN = DateTime.Parse("2023-08-29 09:02:15.000");
            DateTime CHECKOUT = DateTime.Now;
            string department = "";
            int sch = 1;
            var userInfoData = await _userInfoRepository.GetUserInfo();
            foreach (var use in userInfoData)
            {
                var userOfNum = await _userOfNumRepository.GetUserOfNum(use.USERID);

                var checkClassData = await _checkInOutRepository.GetCheckInOut(use.USERID, CHECKIN, CHECKOUT);
                var schClassData = await _schClassRepository.GetSch();
                var NumofRunData = await _numRunRepository.GetNumOfRun();
                var NumofRunDelData = await _numOfRunDelRepository.GetNumOfRunDel();
            
                var rowcount = userInfoData.Count;

                // Get user's check-in and check-out data
                var checkInOutData = checkClassData.ToList();

             

                var userOfnumData = userOfNum.FirstOrDefault(x => x.USERID == use.USERID);
                if (userOfnumData != null)
                {
                    var numOfDelData = NumofRunDelData.Where(x => x.NUM_RUNID == userOfnumData.NUM_OF_RUN_ID).ToList();




                    *//*
                                  if ((scheduleData.StartTime + scheduleData.LateMinutes) < checkInOutData.CHECKTIME)
                                  {
                                      var late = checkInOutData.CHECKTIME - scheduleData.StartTime;

                                  }
                                  if ((scheduleData.EndTime - scheduleData.EarlyMinutes) < checkInOutData.CHECKTIME)
                                  {
                                      var late = checkInOutData.CHECKTIME - scheduleData.StartTime;

                                  }
                  *//*

                    List<Attendances> attendancesList = new List<Attendances>();
                    DateTime? clockIn = null;
                    DateTime? clockOut = null;
                    if (checkInOutData != null && checkInOutData.Count != 0)
                    {
                        foreach (var checkData in checkInOutData)
                        {
                            // var userSchedules = schClassData.Where(s => s.schClassid == numOfDelData.SCHCLASSID);
                            foreach (var num in numOfDelData)
                            {
                                var scheduleData = schClassData.Where(x => x.schClassid == num.SCHCLASSID).ToList();

                                foreach (var schedule in scheduleData)
                                {
                                 
                                    if (schedule.schClassid != sch)
                                    {
                                        sch = schedule.schClassid;
                                        DateTime dd = Convert.ToDateTime(schedule.CheckInTime1);
                                        DateTime d2 = Convert.ToDateTime(schedule.CheckInTime2);
                                        if (checkData.CHECKTIME.Value.TimeOfDay >= dd.TimeOfDay &&
                                            checkData.CHECKTIME.Value.TimeOfDay <= d2.TimeOfDay)
                                        {
                                            clockIn = checkData.CHECKTIME;

                                        }
                                        DateTime ch1 = Convert.ToDateTime(schedule.CheckOutTime1);
                                        DateTime ch2 = Convert.ToDateTime(schedule.CheckOutTime2);
                                        if (checkData.CHECKTIME.Value.TimeOfDay >= ch1.TimeOfDay &&
                                           checkData.CHECKTIME.Value.TimeOfDay <= ch2.TimeOfDay)
                                        {
                                            clockOut = checkData.CHECKTIME;
                                        }
                                        request.AttendanceDto.Id = Guid.NewGuid();
                                        request.AttendanceDto.AttendanceId = checkData.USERID;
                                        request.AttendanceDto.ClockIn = clockIn;
                                        request.AttendanceDto.ClockOut = clockOut;
                                        request.AttendanceDto.OnDuty = schedule.StartTime;
                                        request.AttendanceDto.OffDuty = schedule.EndTime;
                                        request.AttendanceDto.TimeTable = schedule.schName;
                                        //request.AttendanceDto.Normall = Convert.ToDecimal(scheduleData.EndTime - scheduleData.StartTime);
                                        request.AttendanceDto.Department = use.TITLE;
                                        // Include other properties from schedule or checkInOutData as needed


                                        //attendancesList.Add(attendance);
                                        var Attendance = _mapper.Map<Attendances>(request.AttendanceDto);
                                        await _AttendanceRepository.Add(Attendance)
                                       ;
                                    }
                                }
                            }
                        }
                    }




                }


            }
            response.Success = true;
            response.Message = "Creation Successfull";
            return response;
        }
    }
}
*/