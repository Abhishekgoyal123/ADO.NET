// See https://aka.ms/new-console-template for more information
using System.Data.SqlClient;
Console.WriteLine("Hello, World!");

//SqlConnection conn = null;
//SqlCommand cmd = null;

//conn = new SqlConnection("Data Source=.;Initial Catalog=eShoppingCodi;Integrated Security=SSPI");

//conn.Open();

//cmd = conn.CreateCommand();

//cmd.CommandType = System.Data.CommandType.StoredProcedure;

//cmd.CommandText = "sp_table";

//SqlParameter pEmpNo = new SqlParameter();
//pEmpNo.ParameterName = "@EmpNo";
//pEmpNo.DbType = System.Data.DbType.Int32;
//pEmpNo.Direction = System.Data.ParameterDirection.Input;
//pEmpNo.Value = 90;
//cmd.Parameters.Add(pEmpNo);

//SqlParameter pExperience = new SqlParameter();
//pExperience.ParameterName = "@Experience";
//pExperience.DbType = System.Data.DbType.Int32;
//pExperience.Direction = System.Data.ParameterDirection.Input;
//pExperience.Value = 5;
//cmd.Parameters.Add(pExperience);

//SqlParameter pSkills = new SqlParameter();
//pSkills.ParameterName = "@skills";
//pSkills.DbType = System.Data.DbType.String;
//pSkills.Direction = System.Data.ParameterDirection.Input;
//pSkills.Value = "Angular";
//cmd.Parameters.Add(pSkills);

//int result = cmd.ExecuteNonQuery();

//----------------------------------------------------------------------------------------------

SqlConnection conn = null;
SqlCommand cmd = null;

conn = new SqlConnection("Data Source=.;Initial Catalog=eShoppingCodi;Integrated Security=SSPI");

conn.Open();

cmd = conn.CreateCommand();

cmd.CommandType = System.Data.CommandType.StoredProcedure;

cmd.CommandText = "sp_InsertDeptException";

try
{
    SqlParameter pEmpNo = new SqlParameter();
    pEmpNo.ParameterName = "@EmpNo";
    pEmpNo.DbType = System.Data.DbType.Int32;
    pEmpNo.Direction = System.Data.ParameterDirection.Input;
    pEmpNo.Value = 90;
    cmd.Parameters.Add(pEmpNo);

    SqlParameter pEmpName = new SqlParameter();
    pEmpName.ParameterName = "@EmpName";
    pEmpName.DbType = System.Data.DbType.String;
    pEmpName.Direction = System.Data.ParameterDirection.Input;
    pEmpName.Value = "Abhishek_Goyal";
    cmd.Parameters.Add(pEmpName);

    SqlParameter pDesignation = new SqlParameter();
    pDesignation.ParameterName = "@Designation";
    pDesignation.DbType = System.Data.DbType.String;
    pDesignation.Direction = System.Data.ParameterDirection.Input;
    pDesignation.Value = "Maintenence";
    cmd.Parameters.Add(pDesignation);

    SqlParameter pSalary = new SqlParameter();
    pSalary.ParameterName = "@Salary";
    pSalary.DbType = System.Data.DbType.Int32;
    pSalary.Direction = System.Data.ParameterDirection.Input;
    pSalary.Value = 9999;
    cmd.Parameters.Add(pSalary);


    SqlParameter pDeptNo = new SqlParameter();
    pDeptNo.ParameterName = "@DeptNo";
    pDeptNo.DbType = System.Data.DbType.Int32;
    pDeptNo.Direction = System.Data.ParameterDirection.Input; // DEfault is Input
    pDeptNo.Value = 30;
    cmd.Parameters.Add(pDeptNo);

    int result = cmd.ExecuteNonQuery();
}



catch(SqlException ex)
{
    Console.WriteLine(ex.Message);
}



