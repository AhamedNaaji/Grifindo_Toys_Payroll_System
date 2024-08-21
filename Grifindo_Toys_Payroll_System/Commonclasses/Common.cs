using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grifindo_Toys_Payroll_System.Commonclasses
{
    internal class Common
    {
        Dbconnection dbcon = new Dbconnection();

        public void ExecuteProgram(string qry, string key)
        {
            try
            {
                switch (key.ToLower())
                {
                    case "insert":
                        if (MessageBox.Show("Do you want to Save?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            RunQuery(qry);
                            MessageBox.Show("Saved Successfully", "Saved");
                        }
                        break;
                    case "update":
                        if (MessageBox.Show("Do you want to Update?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            RunQuery(qry);
                            MessageBox.Show("Update Successfully", "Updated");
                        }
                        break;
                    case "delete":
                        if (MessageBox.Show("Do you want to Delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            RunQuery(qry);
                            MessageBox.Show("Delete Successfully", "Deleted");
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void RunQuery(string qry)
        {
            dbcon.myCon.Open();
            SqlCommand cmd = new SqlCommand(qry, dbcon.myCon);
            cmd.ExecuteNonQuery();
            dbcon.myCon.Close();
        }


    }
}
