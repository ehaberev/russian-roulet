using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLogic;

namespace Killshot
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Gamer.Instance.StartGame();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Gamer.Instance.RollDryer();
            MessageBox.Show(this, "Делай выстрел, чувак", "Русская рулетка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button2.Enabled = true;
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Gamer.Instance.Shot())
            {
                MessageBox.Show(this, "Ты убил себя, чувак.\nGame over.", "Русская рулетка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            else
            {
                label3.Text = Gamer.Instance.ShotNum.ToString();
                label4.Text = Gamer.Instance.Points.ToString();
                if (MessageBox.Show(this, "Ты крут. Хотите продолжить убивать себя?", "Русская рулетка", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    MessageBox.Show(this, "Ну удачи. Крути барабан", "Русская рулетка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button2.Enabled = false;
                    button1.Enabled = true;
                }
                else
                {
                    button2.Enabled = false;
                    Form4 f = new Form4();
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        var gamerName = f.GamerName;
                        if (Gamer.Instance.SavePoints(gamerName))
                        {
                            MessageBox.Show(this, "Ваши очки сохранены надежно.", "Русская рулетка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(this, "Извини, чувак, БД недоступна. Убей себя лучше еще раз.", "Русская рулетка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    this.Close();
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
        }
    }
}
