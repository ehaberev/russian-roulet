using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Killshot
{
    public partial class Form4 : Form
    {
        public string GamerName
        {
            get
            {
                return textBox1.Text;
            }
        }
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Введите имя");
                e.Cancel = true;
            }
        }
    }
}
