using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace AcunMedyaAkademi_NvRFS3_NTier.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandsController : ControllerBase
{
    private readonly string _connectionString;

    public BrandsController(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("AdonetConnection");
    }

    [HttpGet] // HttpPost,HttpPut,HttpDelete
    public IActionResult GetBrands()
    {
        var brands = new List<Brand>();

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "Select Id,Name From Brands";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();


            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                brands.Add(new Brand
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                });

            }
            connection.Close();

        }
        //200 döner 
        return Ok(brands);  //Http status Code
    }



    [HttpGet("{name}")] // HttpPost,HttpPut,HttpDelete
    public IActionResult GetBrandName(string name)
    {
        var brands = new List<Brand>();

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "Select Id,Name From Brands where Name= '" + name + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            


            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                brands.Add(new Brand
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                });

            }
            connection.Close();

        }
        //200 döner 
        return Ok(brands);  //Http status Code
    }

    //localhost:5000/api/brands/getbrandname
    [HttpGet("getbrandname")] // HttpPost,HttpPut,HttpDelete
    public IActionResult GetBrandName()
    {
        //200 döner 
        return Ok("Mercedes");  //Http status Code
    }
}
