using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CRUD2
{
    class Conexion
    {
        SqlConnection conn;

        public void Conectar()
        {
            conn = new SqlConnection("Data Source=INGRICO-PC;Initial Catalog=Persona;Integrated Security=True");
            conn.Open();

        }
        public void Desconectar()
        {
            conn.Close();
        }
        public void EjecutarSql(String consulta)
        {
            SqlCommand con = new SqlCommand(consulta, conn);
            int filasAfectadas = con.ExecuteNonQuery();

            if (filasAfectadas > 0)
                MessageBox.Show("Operacion realizada correctamente", "La base de datos ha sido modificada", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else
                MessageBox.Show("No se ha conectado a la base de datos", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        public void ActualizarGrid(DataGridView dg, String consulta)
        {
            this.Conectar();
            System.Data.DataSet ds = new System.Data.DataSet();

            SqlDataAdapter da = new SqlDataAdapter(consulta, conn);



            da.Fill(ds, "Alumnos");

            dg.DataSource = ds;
            dg.DataMember = "Alumnos";

            this.Desconectar();

        }
    }
}

