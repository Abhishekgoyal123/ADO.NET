using System.Data.SqlClient;
using WebApplication1.CustomMiddlewares;

namespace WebApplication1
{
    public class LogDb
    {
        public SqlConnection conn;
        public SqlCommand cmd;

        public LogDb()
        {
            conn = new SqlConnection("Data Source =.; Initial Catalog =; Integrated Security =SSPI");
            conn.Open();
        }

        public void LogToDb()
        {
            ErrorDetails errorDetails = new ErrorDetails();
            cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandType = System.Data.CommandType.Text;

            cmd.CommandText = "Insert into LogData values(@StatusCode, @ErrorMessage, @StackTrace)";

            cmd.Parameters.AddWithValue("@StatusCode",errorDetails.StatusCode);
            cmd.Parameters.AddWithValue("@ErrorMessage", errorDetails.ErrorMessage);
            //cmd.Parameters.AddWithValue("@StackTrace", errorDetails.StackTrace);

            int result = cmd.ExecuteNonQuery();

            conn.Close();
        }
        


    }
}
