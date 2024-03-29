using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Numerics;
using System.Xml.Linq;

namespace DAF.Pages
{
    public class captureModel : PageModel
    {
        public string errorMessage = "";
        public string successMessage = "";
        public string startDate = "";
        public string endDate = "";
        public string location = "";
        public string description = "";
        public string aid = "";
        public void OnGet()
        {
        }
        public void OnPost()
        {
            //assign
            startDate = Request.Form["start"];
            endDate = Request.Form["end"];
            location = Request.Form["place"];
            description = Request.Form["description"];
            aid = Request.Form["aid"];

            //connection string
            String cString = "Server=tcp:luthandokelengeshe.database.windows.net,1433;Initial Catalog=DAF;Persist Security Info=False;User ID=luthandokelengeshe;Password=Kelenge$he8;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            SqlConnection connect = new(cString);

            if(startDate.Length > 0 && endDate.Length > 0 && location.Length > 0 && description.Length > 0 && aid.Length > 0)
            {
                try
                {
                    connect.Open();

                    //database writter
                    string userQuery = "INSERT INTO disasters (startDate, endDate, location, description, requiredAidType) " +
                        "VALUES('" + startDate + "','" + endDate + "','" + location + "','" + description + "','" + aid + "')";
                    
                    SqlCommand sql = new(userQuery, connect);

                    //database reader
                    SqlDataReader reader = sql.ExecuteReader();

                }
                catch (Exception e)
                {
                    errorMessage = e.Message;
                }

                //confirmation
                successMessage = "Thank you! We captured the disaster.";
                return;
            }
            else
            {
                errorMessage = "All fields are required!";
                return;
            }
        }
    }
}
