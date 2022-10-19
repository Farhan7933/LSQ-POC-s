using Microsoft.AspNetCore.Mvc;
using StudentAttendanceManagement.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentAttendanceManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAttendanceController : ControllerBase
    {
        // GET: api/<StudentAttendanceController>
        [HttpGet]
        public IEnumerable<StudentAttendanceDetails> Get()
        {
            List<StudentAttendanceDetails> studentAttendanceDetails = new List<StudentAttendanceDetails>();
            StudentAttendanceDetails studentAttendanceDetails1 = new StudentAttendanceDetails()
            {
                StudentId = 1,
                StudentName = "Farhan Alam",
                AttendancePercentage = 87.15
            };
            StudentAttendanceDetails studentAttendanceDetails2 = new StudentAttendanceDetails()
            {
                StudentId = 2,
                StudentName = "Sasidhar Reddy",
                AttendancePercentage = 99.19
            };
            StudentAttendanceDetails studentAttendanceDetails3 = new StudentAttendanceDetails()
            {
                StudentId = 3,
                StudentName = "Roshan Kumar",
                AttendancePercentage = 93.22
            };

            studentAttendanceDetails.Add(studentAttendanceDetails1);
            studentAttendanceDetails.Add(studentAttendanceDetails2);
            studentAttendanceDetails.Add(studentAttendanceDetails3);

            return studentAttendanceDetails;
        }

        // GET api/<StudentAttendanceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StudentAttendanceController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StudentAttendanceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentAttendanceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
