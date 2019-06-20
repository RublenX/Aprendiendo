using ReferenciaDll.UnaLibCualquiera;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFrmReferenciaExterna
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnLanzar_Click(object sender, EventArgs e)
        {
            try
            {
                Prueba prb = new Prueba();
                MessageBox.Show(prb.Probando("ejemplo"), "Devolución de Prueba", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Algo ha salido mal",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
