using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CS_Disconnected
{
    public class DataAccess
    {
        SqlConnection Conn;
        SqlDataAdapter AdDept, AdEmp;
        DataSet Ds;
        DataRow DrFind;
        DataColumn ChildColumn;
        DataColumn ParentColumn;

        
        public DataAccess()
        {
            
            Conn = new SqlConnection("Data Source=.;Initial Catalog=eShoppingCodi;Integrated Security=SSPI");
            Ds = new DataSet();
            ParentColumn = new DataColumn();
           // LoadData();
        }

        public void LoadData()
        {
            AdDept = new SqlDataAdapter("select * from Department", Conn);

            AdDept.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            AdDept.Fill(Ds,"Department");

            Console.WriteLine(Ds.GetXml());
        }

        public void CreateDept()
        {
            DataRow DrNew = Ds.Tables["Department"].NewRow();
            DrNew["DeptNo"] = 80;
            DrNew["DeptName"] = "Kachara DEpt";
            DrNew["Location"] = "Mumbai";
            DrNew["Capacity"] = 900;

            Ds.Tables["Department"].Rows.Add(DrNew);

            SqlCommandBuilder builder = new SqlCommandBuilder(AdDept);

            AdDept.Update(Ds, "Department");
           
        }

        public void FindRecord(int dno)
        {
            DrFind = Ds.Tables["Department"].Rows.Find(dno);
            Console.WriteLine($"{DrFind["DeptNo"]} {DrFind["DeptName"]}");
        }

        public void Update(int dno)
        {
            DrFind = Ds.Tables["Department"].Rows.Find(dno);


            // The Row is Already Assoiated with the Table
            DrFind["DeptName"] = "New DEpt";
            DrFind["Location"] = "Pune";
            DrFind["Capacity"] = 9090;
            Console.WriteLine();
            Console.WriteLine("Update");
            Console.WriteLine(Ds.GetXml());
            Console.WriteLine();
            SqlCommandBuilder builder = new SqlCommandBuilder(AdDept);
            // Update
            AdDept.Update(Ds, "Department");

        }

        public void Delete(int dno)
        {
            DrFind = Ds.Tables["Department"].Rows.Find(dno);
            // The Row is Already Assoiated with the Table
            DrFind.Delete();

            Console.WriteLine("Delete");
            Console.WriteLine(Ds.GetXml());
            Console.WriteLine();
            SqlCommandBuilder builder = new SqlCommandBuilder(AdDept);
            // Update
            AdDept.Update(Ds, "Department");

        }

        public void relation()
        {
              ParentColumn = Ds.Tables["Department"].Columns["DeptNo"];
            ChildColumn = Ds.Tables["Employee"].Columns["DeptNo"];
            DataRelation dataRelation = new DataRelation("ParentChild", ParentColumn, ChildColumn);

            Ds.Relations.Add(dataRelation);

            foreach(DataRow ds1 in Ds.Tables["Department"].Rows)
            {
                DataRow[] arr_dataRows = ds1.GetChildRows(dataRelation);

                foreach(var item in arr_dataRows)
                {
                    Console.WriteLine(item["DeptNo"]);
                    Console.WriteLine(item["EmpName"]);
                }
            }
        }
    }


    
}
