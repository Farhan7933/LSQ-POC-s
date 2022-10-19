using Microsoft.AspNetCore.Mvc;
using StudentAdmissionManagement.Models;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentAdmissionManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAdmissionController : ControllerBase
    {
        // GET: api/<StudentAdmissionController>
        [HttpGet]
        public IEnumerable<StudentAdmissionDetails> Get()
        {
            List<StudentAdmissionDetails> studentAdmissionDetails = new List<StudentAdmissionDetails>();
            StudentAdmissionDetails studentAdmission1 = new StudentAdmissionDetails()
            {
                StudentID = 1,
                StudentName = "Farhan Alam",
                StudentClass = "XII",
                DateOfJoining = DateTime.Now
            };
            StudentAdmissionDetails studentAdmission2 = new StudentAdmissionDetails()
            {
                StudentID = 2,
                StudentName = "Sasidhar Reddy",
                StudentClass = "XIII",
                DateOfJoining = DateTime.Now
            };
            StudentAdmissionDetails studentAdmission3 = new StudentAdmissionDetails()
            {
                StudentID = 3,
                StudentName = "Roshan Kumar",
                StudentClass = "XIV",
                DateOfJoining = DateTime.Now
            };
            studentAdmissionDetails.Add(studentAdmission1);
            studentAdmissionDetails.Add(studentAdmission2);
            studentAdmissionDetails.Add(studentAdmission3);

            return studentAdmissionDetails;
        }

        // GET api/<StudentAdmissionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StudentAdmissionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StudentAdmissionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentAdmissionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
