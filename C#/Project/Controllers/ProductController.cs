using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Projects.Model;
using System.Data;
using System.IO;
using Microsoft.AspNetCore.Hosting;


namespace Projects.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;



        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = "Select * from Product";
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
        public JsonResult Post(Product product)
        {
            string query = @"Insert into Product values('" + product.Id + "', N'" + product.Name + "','" + product.Price + "','" + product.Image + "','" + product.CategoryId + "')";
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
        public JsonResult Put(Product product)
        {
            string query = @"Update Product set Name = N'" + product.Name + "', Price = '" + product.Price + "', Image = '" + product.Image + "', CategoryId = '" + product.CategoryId + "' where Id = '" + product.Id + "' ";
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
        public JsonResult Delete(string id)
        {
            string query = $@"Delete from Product where Id = '{id}'";
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

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile(Product product)
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string fileName = postedFile.FileName;
                var physicalPath = _webHostEnvironment.ContentRootPath + "/Photos/" + fileName;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }


                return new JsonResult(fileName);
            }
            catch(Exception )
            {
                return new JsonResult("com.jpg");
            }
        }

    }
}
