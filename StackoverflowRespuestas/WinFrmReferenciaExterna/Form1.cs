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
using WinFrmReferenciaExterna.Entidades;

namespace WinFrmReferenciaExterna
{
    public partial class Form1 : Form
    {
        List<UsuarioApp> Usuarios;

        public Form1()
        {
            InitializeComponent();

            this.Usuarios = new List<UsuarioApp>
            {
                new UsuarioApp { Id = 1, Nombre = "Fulano", Apellido = "De Tal", Alias = "ful", Clave = "0000", Email = "anonimo1@email.es", Tipo = "Acceso A"},
                new UsuarioApp { Id = 2, Nombre = "Mengano", Apellido = "Pacual", Alias = "men", Clave = "1111", Email = "anonimo2@email.es", Tipo = "Acceso A"},
                new UsuarioApp { Id = 3, Nombre = "Elena", Apellido = "Moya", Alias = "ele", Clave = "2222", Email = "anonimo3@email.es", Tipo = "Acceso C"}
            };

            dgvTest.DataSource = this.Usuarios;
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
