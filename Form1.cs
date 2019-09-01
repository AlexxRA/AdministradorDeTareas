using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AdministradorDeTareas
{
    public partial class Form1 : Form
    {
        ArrayList interrupciones = new ArrayList();
        Stack enProceso = new Stack();

        DataTable dataTableInterrupcion = new DataTable();
        DataTable dataTableEnProceso = new DataTable();

        public Form1()
        {
            interrupciones.Add(new Interrupcion("FF", 5, 20, 10, 5));
            interrupciones.Add(new Interrupcion("1A", 4, 12, 5, 1));
            interrupciones.Add(new Interrupcion("B6", 3, 2, 3, 1));

            dataTableInterrupcion.Columns.Add("numero");
            dataTableInterrupcion.Columns.Add("nombre");
            dataTableInterrupcion.Columns.Add("tiempo");
            dataTableInterrupcion.Columns.Add("ram");
            dataTableInterrupcion.Columns.Add("cpu");
            dataTableInterrupcion.Columns.Add("hdd");

            dataTableEnProceso = dataTableInterrupcion.Copy();




            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show(interrupciones.Count.ToString());
            int i = 0;
            foreach (Interrupcion inter in interrupciones)
            {

                DataRow dRow = dataTableInterrupcion.NewRow();
                dRow["numero"] = i++;
                dRow["nombre"] = inter.nombre;
                dRow["tiempo"] = inter.tiempo;
                dRow["ram"] = inter.consumoRamMegas;
                dRow["cpu"] = inter.consumoCpu;
                dRow["hdd"] = inter.consumoHdd;
                dataTableInterrupcion.Rows.Add(dRow);


            }
            dataGridView1.DataSource = dataTableInterrupcion;
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string nombreInterrupcion = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            foreach (Interrupcion inter in interrupciones)
            {
                if (inter.nombre.Equals(nombreInterrupcion))
                {
                    enProceso.Push(inter);

                    DataRow dRow = dataTableEnProceso.NewRow();
                    dRow["numero"] = 0;
                    dRow["nombre"] = inter.nombre;
                    dRow["tiempo"] = inter.tiempo;
                    dRow["ram"] = inter.consumoRamMegas;
                    dRow["cpu"] = inter.consumoCpu;
                    dRow["hdd"] = inter.consumoHdd;
                    dataTableEnProceso.Rows.Add(dRow);
                }
            }
            dataGridView2.DataSource = dataTableEnProceso;
            dataGridView2.Refresh();

        }
    }

}
