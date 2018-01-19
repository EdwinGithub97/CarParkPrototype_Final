using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarParkPrototype
{
    public partial class Start : Form
    {
        public static bool  advancedBooking;
        Form1 carPark;

        public Start()
        {
            InitializeComponent();
            carPark = new Form1();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            carPark.Show();
            carPark.Size = new Size(900, 750);
            this.Hide();
            advancedBooking = true;
           
           
        }

        private void btnAdvanceBooking_Click(object sender, EventArgs e)
        {
            carPark.Show();
            this.Hide();
            advancedBooking = false;
        }
    }
}
