using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DI_Tema4_Ejer3
{
    public partial class Form1 : Form
    {
        private string path;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Visor de imagenes";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {

                ofd.InitialDirectory = Environment.GetEnvironmentVariable("HOME");
                ofd.Filter = "Todos los archivos(*.*)|*.*|Imagen png (*.png)|*.png| Imagen jpg(*jpg)|*.jpg";
                ofd.FilterIndex = 1;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    path = ofd.FileName; //saca el path entero
                    if (Path.GetExtension(ofd.FileName) == ".png" || Path.GetExtension(ofd.FileName) == ".jpg")
                    {
                        Form2 f2 = new Form2();
                        f2.Text = Path.GetFileNameWithoutExtension(ofd.FileName);
                        try
                        {
                            f2.pictureBox1.Image = new Bitmap(path);
                            f2.Size = new Size(f2.pictureBox1.Image.Width, f2.pictureBox1.Image.Height);
                            if (checkBox1.Checked)
                            {
                                f2.ShowDialog();
                            }
                            else
                            {
                                f2.Show();
                            }
                        }
                        catch (ArgumentException)
                        {
                            MessageBox.Show("Imagen corrupta");
                        }

                        

                    }
                    else
                    {
                        MessageBox.Show("No es una imagen");
                    }

                }
            }
        }

        private void salir(object sender, FormClosingEventArgs e)
        {

            if (MessageBox.Show("¿Seguro que deseas salir de la aplicación?", "Mi Aplicación",
             MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }

        }
    }
}
