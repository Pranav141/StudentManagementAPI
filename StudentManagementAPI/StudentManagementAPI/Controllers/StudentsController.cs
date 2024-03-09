//StudentsController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using StudentManagementAPI.Models;
using System.Data.SqlClient;
using System.Globalization;

namespace StudentManagementAPI.Controllers
{

    [ApiController]

    public class StudentsController : ControllerBase
    {

        private IConfiguration _configuration;
        public StudentsController(IConfiguration config)
        {
            _configuration = config;
        }
        [HttpGet]
        [Route("Students")]
        public IActionResult GetStudents()
        {
            try
            {
                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                string query = "select * from students";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    List<Students> l1 = new List<Students>();
                    while (dr.Read())
                    {
                        Students s = new Students();
                        s.StudentID = int.Parse(dr["student_id"].ToString());
                        s.Name = dr["name"].ToString();
                        s.Email = dr["email"].ToString();
                        s.Address = dr["address"].ToString();
                        s.Age = int.Parse(dr["age"].ToString());
                        s.Gender = dr["gender"].ToString();
                        s.PhoneNo = dr["phoneno"].ToString();
                        l1.Add(s);
                    }
                    dr.Close();
                    con.Close();
                    return Ok(l1);
                }
                else
                {
                    return Ok("No record found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error " + ex.Message);
            }
        }
        //[BasicAuth]
        [HttpGet]
        [Route("Students/{id}")]
        public IActionResult GetStudentById(int id)
        {
            try
            {
                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                string query = "select * from students where student_id=" + id;
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Students s = new Students();
                    while (dr.Read())
                    {
                        s.StudentID = int.Parse(dr["student_id"].ToString());
                        s.Name = dr["name"].ToString();
                        s.Email = dr["email"].ToString();
                        s.Address = dr["address"].ToString();
                        s.Age = int.Parse(dr["age"].ToString());
                        s.Gender = dr["gender"].ToString();
                        s.PhoneNo = dr["phoneno"].ToString();

                    }
                    dr.Close();
                    con.Close();
                    return Ok(s);
                }
                else
                {
                    return Ok("No record found with id" + id);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error " + ex.Message);
            }
        }

        [BasicAuth]
        [HttpPost]
        [Route("Students")]
        public IActionResult CreateStudent(Students s)
        {
            try
            {
                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                string query = "insert into students values(@val1,@val2,@val3,@val4,@val5,@val6,@val7)";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("@val1", s.StudentID);
                cmd.Parameters.AddWithValue("@val2", s.Name);
                cmd.Parameters.AddWithValue("@val3", s.Email);
                cmd.Parameters.AddWithValue("@val4", s.Address);
                cmd.Parameters.AddWithValue("@val5", s.Age);
                cmd.Parameters.AddWithValue("@val6", s.Gender);
                cmd.Parameters.AddWithValue("@val7", s.PhoneNo);

                int rows = cmd.ExecuteNonQuery();
                con.Close();
                if (rows == 0)
                {
                    return StatusCode(503, "Insertion failed");
                }
                else
                {
                    return Ok("Inserted successfully");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error " + ex.Message);
            }
        }

        [BasicAuth]
        [HttpPut]
        [Route("Students/{id}")]
        public IActionResult CreateStudent(Students s, int id)
        {
            try
            {
                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                string query = "update students set name=@val2, email=@val3, address=@val4, age=@val5, gender=@val6, phoneno=@val7 where student_id=@val1";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("@val1", s.StudentID);
                cmd.Parameters.AddWithValue("@val2", s.Name);
                cmd.Parameters.AddWithValue("@val3", s.Email);
                cmd.Parameters.AddWithValue("@val4", s.Address);
                cmd.Parameters.AddWithValue("@val5", s.Age);
                cmd.Parameters.AddWithValue("@val6", s.Gender);
                cmd.Parameters.AddWithValue("@val7", s.PhoneNo);
                int rows = cmd.ExecuteNonQuery();
                con.Close();
                if (rows == 0)
                {
                    return NotFound("Record with id=" + id + " Not Found");
                }
                else
                {
                    return Ok("Updated successfully");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error " + ex.Message);
            }
        }

        [BasicAuth]
        [HttpDelete]
        [Route("Students/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                string query = "delete from students where student_id=" + id;
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                con.Close();
                if (rows == 0)
                {
                    return NotFound("Record not found");
                }
                else
                {
                    return Ok("Deleted Successfully");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal Server Error " + e.Message);
            }
        }
    }
}
