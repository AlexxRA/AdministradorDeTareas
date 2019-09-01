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
        DataTable dt = new DataTable();

        public Form1()
        {
            interrupciones.Add(new Interrupcion("FF",5,20,10,5));
            interrupciones.Add(new Interrupcion("1A", 4, 12, 5, 1));
            interrupciones.Add(new Interrupcion("B6", 3, 2, 3, 1));

            dt.Columns.Add("numero");
            dt.Columns.Add("nombre");
            dt.Columns.Add("tiempo");
            dt.Columns.Add("ram");
            dt.Columns.Add("cpu");
            dt.Columns.Add("hdd");


            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show(interrupciones.Count.ToString());
            int i = 0;
            foreach (Interrupcion inter in interrupciones)
            {
                
                DataRow dRow = dt.NewRow();
                dRow["numero"] = i++;
                dRow["nombre"] = inter.nombre;
                dRow["tiempo"] = inter.tiempo;
                dRow["ram"] = inter.consumoRamMegas;
                dRow["cpu"] = inter.consumoCpu;
                dRow["hdd"] = inter.consumoHdd;
                dt.Rows.Add(dRow);
                
               
            }
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }
    }

}
