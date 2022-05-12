using camp_project.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;

namespace camp_project.Controllers
{
    public class CampgroundController : Controller
    {
        private const string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Data\Kamp Yerleri.accdb;";

        public IActionResult Index(string il)
        {
            ViewBag.il = il;
            List<Campground> kampYerleri = new List<Campground>();
            try
            {
                using (OleDbConnection con = new OleDbConnection(connectionString))
                {
                    string sql = @"select * from tablo1 where il = '" + il + "'";
                    OleDbCommand command = new OleDbCommand(sql, con);
                    con.Open();
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var kampYeri = new Campground();
                        kampYeri.ID = reader["ID"].ToString();
                        kampYeri.isim = reader["kamp_yeri_adi"].ToString();
                        kampYeri.il = reader["il"].ToString();
                        kampYeri.lokasyon = reader["lokasyon"].ToString();
                        kampYeri.cadir = reader["cadir"].ToString();
                        kampYeri.karavan = reader["karavan"].ToString();
                        kampYeri.bilgi = reader["bilgi"].ToString();
                        kampYeri.iletisimTelefon = reader["iletişim_telefon"].ToString();
                        kampYeri.adres = reader["adres"].ToString();
                        kampYeri.resim1 = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String((byte[])reader["resim1"]));
                        kampYeri.resim2 = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String((byte[])reader["resim2"]));
                        kampYeri.resim3 = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String((byte[])reader["resim3"]));
                        kampYerleri.Add(kampYeri);
                    }
                    con.Close();
                }
                return View(kampYerleri);
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }
        public IActionResult Detail(int id)
        {
            try
            {
                var kampYeri = new Campground();
                using (OleDbConnection con = new OleDbConnection(connectionString))
                {
                    string sql = @"select * from tablo1 where ID = " + id.ToString();
                    OleDbCommand command = new OleDbCommand(sql, con);
                    con.Open();
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        kampYeri.ID = reader["ID"].ToString();
                        kampYeri.isim = reader["kamp_yeri_adi"].ToString();
                        kampYeri.il = reader["il"].ToString();
                        kampYeri.lokasyon = reader["lokasyon"].ToString();
                        kampYeri.cadir = reader["cadir"].ToString();
                        kampYeri.karavan = reader["karavan"].ToString();
                        kampYeri.bilgi = reader["bilgi"].ToString();
                        kampYeri.iletisimTelefon = reader["iletişim_telefon"].ToString();
                        kampYeri.adres = reader["adres"].ToString();
                        kampYeri.resim1 = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String((byte[])reader["resim1"]));
                        kampYeri.resim2 = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String((byte[])reader["resim2"]));
                        kampYeri.resim3 = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String((byte[])reader["resim3"]));
                    }
                    con.Close();
                    if (kampYeri != null)
                    {
                        return View(kampYeri);
                    }
                    return RedirectToAction("NotFound", "Home");
                }
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        //private string readImageFromDB()
    }
}
