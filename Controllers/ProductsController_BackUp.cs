using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.Models;
using MVC.App_Code.Connect;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using System.Data;
using System.Collections.Generic;

namespace MVC.Controllers
{
  public class ProductController : Controller
  {

    private readonly IConfiguration configuration;

    public ProductController (IConfiguration config)
    {
        this.configuration = config;
    }
  
  
 
    public IActionResult Index()
    {
      // แบบที่ 1 เป็นการ connect แบบผ่าน file appsetting.json
      // string connectionstring = configuration.GetConnectionString("DefaultConnectionString");
      // SqlConnection conn = new SqlConnection(connectionstring);
      // conn.Open();
      // SqlCommand com = new SqlCommand("select * From",conn);
      // var count = (int)com.ExecuteScalar();
      // conn.Close();


      // แบบที่ 2 เป็นการ connect แบบผ่าน App_code 
      var dt = new DataTable();       
      try
      {
        string connectionstring = configuration.GetConnectionString("DefaultConnectionString");
        var str ="Select * From Products";
        var dr = new DataAccess().ExecuteReader(connectionstring,str);
        if (dr.HasRows)
        {
          dt.Load(dr);
        }
        dr.Close();

        return View(DatatableToProducts(dt));
      }
      catch (Exception ex)
      {
        string x ;
        x= ex.Message ;
        return View();
      }

    }

 
    public IActionResult ViewProducts()
    {
      Products _data = new Products();
      _data.ProductID = 12345 ;
      _data.ProductName = "BOOK";
      _data.QuantityPerUnit = "XXXX";
      _data.UnitPrice= 250;

      return View(_data); 
    }

    public IActionResult Detail(int id)
    {
      try
      {
        
        return Ok();
      }
      catch (Exception)
      {
        return BadRequest();
      }
    }

    public IActionResult Create ()
    {
      try
      {
        
        return Ok();
      }
      catch (Exception)
      {
        return BadRequest();
      }

    }

    [HttpPost]
    public IActionResult Create (FormCollection collection)
    {
      try
      {
        
        return Ok();
      }
      catch (Exception)
      {
        return BadRequest();
      }
    }

    public IActionResult Edit ()
    {
      try
      {
        
        return Ok();
      }
      catch (Exception)
      {
        return BadRequest();
      }
    }

    [HttpPost]
    public IActionResult Edit (int id , FormCollection collection)
    {
      try
      {
        
        return Ok();
      }
      catch (Exception)
      {
        return BadRequest();
      }
    }

    public IActionResult Delete(int id)
    {
      try
      {
        
        return Ok();
      }
      catch (Exception)
      {
        return BadRequest();
      }
    }

    [HttpPost]
    public IActionResult Delete(int id , FormCollection collection)
    {
      try
      {
        
        return Ok();
      }
      catch (Exception)
      {
        return BadRequest();
      }
    }

    private  List<Products> DatatableToProducts (DataTable dt)
    {
      List<Products> ProductList =new List<Products>();
      try
      {
            foreach (DataRow dr in dt.Rows)
            {

                ProductList.Add(

                    new Products {

                        ProductID = Convert.ToInt32(dr["ProductID"]),
                        ProductName =Convert.ToString( dr["ProductName"]),
                        QuantityPerUnit = Convert.ToString( dr["QuantityPerUnit"]),
                        UnitPrice = Convert.ToInt32(dr["UnitPrice"]),
                        CategoryID = Convert.ToInt32(dr["CategoryID"]),
                        SupplierID = Convert.ToInt32(dr["SupplierID"]),
                        UnitsInStock = Convert.ToInt32(dr["UnitsInStock"]),
                        UnitsOnOrder = Convert.ToInt32(dr["UnitsOnOrder"]),
                        ReorderLevel = Convert.ToInt32(dr["ReorderLevel"]),
                        Discontinued = Convert.ToInt32(dr["Discontinued"]),

                        }
                    );
            }

           return ProductList;
      }
      catch (Exception )
      {
        return ProductList;
      }
    }

  }
}
