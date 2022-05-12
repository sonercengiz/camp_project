using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.OleDb;

namespace camp_project.Controllers
{
    public class HomeController : Controller
    {
        private const string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Data\Kamp Yerleri.accdb;";
        public ActionResult Index()
        {
            List<string> iller = new List<string>();
            try
            {
                using (OleDbConnection con = new OleDbConnection(connectionString))
                {
                    string sql = @"select distinct il from tablo1";
                    OleDbCommand command = new OleDbCommand(sql, con);
                    con.Open();
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        iller.Add(reader["il"].ToString());
                    }
                    con.Close();
                }
            }
            catch
            {
                return RedirectToAction("Error");
            }
            ViewBag.iller = iller;
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult NotFound()
        {
            return View();
        }
    }
}
