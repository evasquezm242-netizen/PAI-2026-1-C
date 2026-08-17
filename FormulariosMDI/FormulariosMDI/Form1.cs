namespace FormulariosMDI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClientes ventana = new FrmClientes();
            ventana.MdiParent = this;
            ventana.Show();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {


            AbrirFormulario<FrmVentas>();
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void cascadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void AbrirFormulario<T>() where T : Form, new()
        {

            foreach (Form hijo in this.MdiChildren)
            {
                if (hijo is T)
                {
                    hijo.WindowState = FormWindowState.Normal;
                }
                hijo.BringToFront();
                hijo.Focus();
                return;
            }


            T nuevo = new T();
            nuevo.MdiParent = this;
            nuevo.Show();
        }
    }
}
