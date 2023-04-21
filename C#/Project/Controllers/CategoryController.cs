using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Projects.Model;
using System.Data;

namespace Projects.Controllers
{


    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public CategoryController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = "Select Name from Category";
            DataTable dataTable = new DataTable();
            String sqlDataSource = _configuration.GetConnectionString("Project");
            SqlDataReader sqlDataReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    sqlDataReader = myCommand.ExecuteReader();
                    dataTable.Load(sqlDataReader);
                    sqlDataReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(dataTable);
        }


        [HttpPost]
        public JsonResult Post(Category category)
        {
            string query = @"Insert into Category values(N'" + category.Name + "')";
            DataTable dataTable = new DataTable();
            String sqlDataSource = _configuration.GetConnectionString("Project");
            SqlDataReader sqlDataReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    sqlDataReader = myCommand.ExecuteReader();
                    dataTable.Load(sqlDataReader);
                    sqlDataReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Thêm mới ok");
        }
        [HttpPut]
        public JsonResult Put(Category category)
        {
            string query = @"Update Category set Name = N'" + category.Name + "' where Id = " + category.Id + " ";
            DataTable dataTable = new DataTable();
            String sqlDataSource = _configuration.GetConnectionString("Project");
            SqlDataReader sqlDataReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    sqlDataReader = myCommand.ExecuteReader();
                    dataTable.Load(sqlDataReader);
                    sqlDataReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("sửa ok");
        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"Delete from Category where Id = "+id +" ";
            DataTable dataTable = new DataTable();
            String sqlDataSource = _configuration.GetConnectionString("Project");
            SqlDataReader sqlDataReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    sqlDataReader = myCommand.ExecuteReader();
                    dataTable.Load(sqlDataReader);
                    sqlDataReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Xóa ok");
        }
    }
}
