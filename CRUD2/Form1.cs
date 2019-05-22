using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD2
{
    public partial class Form1 : Form
    {

        Conexion con = new Conexion();
        int Id;
        Boolean editar;

        public Form1()
        {
            InitializeComponent();
            Bitmap img = new Bitmap(Application.StartupPath + @"\img\fondo2.jpg");
            this.BackgroundImage = img;
        }

        public void ActualizarGrid()
        {
            con.ActualizarGrid(this.dataGridView1, "Select * from Alumnos");

        }


        public void Limpiar()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEdad.Text = "";
            txtCorreo.Text = "";
            txtSexo.Text = "";
            txtCarrera.Text = "";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            editar = false;
            this.ActualizarGrid();


        }
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (editar)
            {
                con.Conectar();

                String consulta = "update Alumnos set Nombre  = '" + txtNombre.Text + "', Apellido = '" + txtApellido.Text + "', Edad = " + txtEdad.Text + ",Correo = '" + txtCorreo.Text + "',Sexo= '" + txtSexo.Text + "',Carrera = '" + txtCarrera.Text + "' where Id = " + Id + ";";

                con.EjecutarSql(consulta);

                this.ActualizarGrid();

                con.Desconectar();

                this.Limpiar();

                editar = false;
            }
            else
            {
                con.Conectar();

                String consulta = "insert into Alumnos (Nombre, Apellido, Edad, Correo, Sexo, Carrera) values ('" + txtNombre.Text + "','" + txtApellido.Text + "'," + txtEdad.Text + " ,'" + txtCorreo.Text + "','" + txtSexo.Text + "','" + txtCarrera.Text + "');";


                con.EjecutarSql(consulta);

                this.ActualizarGrid();

                con.Desconectar();

                this.Limpiar();



            }

        }



        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            editar = true;
            Id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            txtNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtApellido.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtEdad.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtCorreo.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtSexo.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtCarrera.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();


        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            con.ActualizarGrid(this.dataGridView1, " select * from Alumnos where nombre like '" + txtBuscar.Text + "%';");

        }



        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            Id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var resultado = MessageBox.Show("¿Desea eliminar registro?", "Confirme el borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)

            {
                con.Conectar();

                String consulta = "delete from alumnos where  Id  = '" + Id + "';";

                con.EjecutarSql(consulta);

                this.ActualizarGrid();

            }
            else
            {
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
