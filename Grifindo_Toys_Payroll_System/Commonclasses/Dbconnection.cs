using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grifindo_Toys_Payroll_System.Commonclasses
{
    internal class Dbconnection
    {
        public SqlConnection myCon = new SqlConnection("Data Source=NAAJI\\SQLEXPRESS;Initial Catalog=Grifindo_Toys_Payroll_System;Integrated Security=True;Encrypt=False");

    }
}
