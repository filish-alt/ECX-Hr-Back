

using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Attendance;
using ECX.HR.Application.CQRS.Attendance.Request.Command;
using ECX.HR.Application.CQRS.Attendance.Request.Queries;
using ECX.HR.Application.CQRS.Branch.Request.Command;
using ECX.HR.Application.CQRS.Branch.Request.Queries;
using ECX.HR.Application.CQRS.Employee.Request.Command;
using ECX.HR.Application.DTOs.Branchs;
using ECX.HR.Application.DTOs.Employees;
using ECX.HR.Application.DTOs.Levels;
using ECX.HR.Application.DTOs.Schedule;
using ECX.HR.Application.Response;
using ECX.HR.Domain;
using ECX.HR.Persistence;
using ECX.HR.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.Data;
using System.Globalization;
using System.Runtime.Intrinsics.X86;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECXHR_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase

    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ECXHRDbContext _context;
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly ICheckInOutRepository _checkInOutRepository;
        private readonly INumOfRunDelRepository _numOfRunDelRepository;
        private readonly IUserOfNumRepository _userOfNumRepository;

        public AttendanceController(IMediator mediator, IHttpContextAccessor httpContextAccessor,
            ECXHRDbContext context,IAttendanceRepository attendanceRepository,ICheckInOutRepository 
            checkInOutRepository,INumOfRunDelRepository numOfRunDelRepository,IUserOfNumRepository userOfNumRepository)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
            _context = context;
            _attendanceRepository = attendanceRepository;
          _checkInOutRepository = checkInOutRepository;
            _numOfRunDelRepository = numOfRunDelRepository;
         _userOfNumRepository = userOfNumRepository;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }
        [HttpGet("all")]

        public async Task<ActionResult<List<AttendanceDto>>> Get()
        {
            //var schClassData = _context.GetTable1DataFromSourceDatabase();
            var att = await _mediator.Send(new GetAttendanceListRequest());
            return Ok(att);
        }
        [HttpGet("UserInfo")]

        public async Task<ActionResult<List<NumOfRunDto>>> GetNUMOFRUN()
        {
            //var schClassData = _context.GetTable1DataFromSourceDatabase();
            var att = await _mediator.Send(new getuser());
            return Ok(att);
        }
        // GET: api/<LevelController>
        [HttpGet("user")]
       
        public async Task<ActionResult<List<UserInformationDto>>> GetUser()
        {
            //var schClassData = _context.GetTable1DataFromSourceDatabase();
            var userInfoData = _context.GetUserInfoDataFromSourceDatabase();
          

            return Ok(userInfoData);
        }
        [HttpGet("userofnum")]
        public async Task<ActionResult<List<UserOfNum>>> GetUserofnum(int USERID)
        {
            //var schClassData = _context.GetTable1DataFromSourceDatabase();
            var userInfoData = await _userOfNumRepository.GetUserOfNum(USERID);


            return Ok(userInfoData);
        }
        [HttpGet("schedule")]
        public async Task<ActionResult<List<SchClassDto>>> GetSch()
        {
            var schClassData = _context.GetTable1DataFromSourceDatabase();
           


            return Ok(schClassData);
        }
        [HttpGet("checkinout")]
        public async Task<ActionResult<List<ChechInOutDto>>> GetCheckInOut( int USERID,DateTime? CHECKIN, DateTime? CHECKOUT)
        {
            var checkClassData = await _checkInOutRepository.GetCheckInOut(USERID,CHECKIN, CHECKOUT); 



            return Ok(checkClassData);
        }
        [HttpGet("numofrun")]
        public async Task<ActionResult<List<NumOfRunDto>>> GetNumOfRun()
        {
            var NumofRunData = _context.GetNumOfRunDataFromSourceDatabase();

            return Ok(NumofRunData);
        }
        // GET api/<LevelController>/5
        [HttpGet("numrundel")]
        public async Task<ActionResult<List<NumRunDelDto>>> GetNumRunDel()
        {
            var NumofRunData = await _numOfRunDelRepository.GetNumOfRunDel(); 



            return Ok(NumofRunData);
        }
 /*       [HttpGet("att")]
        public async Task<ActionResult<List<NumRunDelDto>>> Getatt()
        {
            var NumofRunData = _attendanceRepository.GetAttendance();



            return Ok(NumofRunData);
        }*/
        [HttpGet("{id}")]
        public async Task<ActionResult<AttendanceDto>> Get(Guid id)
        {
            var Level = await _mediator.Send(new GetAttendanceDetailRequest { Id = id }); 
                return Ok(Level);
         
        }

        [HttpPost("import")]
        public async Task<IActionResult> ImportExcel([FromForm] IFormFile file)
        {
            if (file == null || file.Length <= 0)
            {
                return BadRequest("Invalid file");
            }

            try
            {
                var attendances = new List<Attendances>();


                using (var package = new ExcelPackage(file.OpenReadStream()))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++) // Assuming the first row is header
                    {
                        double dd = double.Parse(worksheet.Cells[row, 6].Value.ToString());
                 var employee = _context.Employee.FirstOrDefault(e => e.AttendanceId == worksheet.Cells[row, 2].Value.ToString());
                   


                        var attendance = new Attendances
                        {
                            EmpId = employee?.EmpId ?? new Guid("b6692f64-7e87-4288-a493-ee2df975e5c9"),


                            TimeTable = worksheet.Cells[row, 7].Value.ToString(),


                          //  AttendanceId = worksheet.Cells[row, 2].Value.ToString(),
                            date = DateTime.FromOADate(dd).Date,

                            OnDuty = DateTime.Parse(worksheet.Cells[row, 8].Value?.ToString()),
                            OffDuty = DateTime.Parse(worksheet.Cells[row, 9].Value?.ToString()),
                            ClockIn = DateTime.Parse(worksheet.Cells[row, 10].Value?.ToString() ?? "0"),
                            ClockOut = DateTime.Parse(worksheet.Cells[row, 11].Value?.ToString() ?? "0"),
                            Normall = Convert.ToDecimal(worksheet.Cells[row, 12].Value?.ToString() ?? "0"),
                            RealTime = Convert.ToDecimal(worksheet.Cells[row, 13].Value?.ToString() ?? "0"),
                            CreatedDate = DateTime.Now,
                            UpdatedDate = DateTime.Now,
                            Department = worksheet.Cells[row, 22].Value.ToString(),

                         // Late = DateTime.Parse(worksheet.Cells[row, 14].Value?.ToString() ?? "0"),
                            Status=0

                            // LeaveType = worksheet.Cells[row, 19].Value?.ToString(),




                        };

                        attendances.Add(attendance);
                    }
                }

                _context.Attendances.AddRange(attendances);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Data imported successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }


        // Process schClassData as needed
        [HttpPost]

        public async Task<ActionResult> Post([FromBody] AttendanceDto attendance)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreateAttendanceCommand { AttendanceDto = attendance };
            // var response =
            await _mediator.Send(command);
            return Ok(command);
        }

        [HttpPut("{id}")]


        public async Task<ActionResult> Put([FromBody] EmployeeDto Employee)
        {
            var command = new UpdateAttendanceEmployeeCommand { EmployeeDto = Employee };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteAttendanceCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}