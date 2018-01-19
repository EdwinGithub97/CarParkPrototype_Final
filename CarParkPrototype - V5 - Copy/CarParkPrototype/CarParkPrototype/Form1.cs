using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CarParkPrototype
{
    public partial class Form1 : Form
    {

        private OleDbConnection conn = new OleDbConnection();

        private int parkingSpace;
        private bool[] floor1 = { true, true, true, true };
        private bool[] floor2 = { true, true, true, true, };
        private bool payment;
        private bool advancePayment;
      
        private bool advance;
        private bool coinLost;
        private bool leave;

        private int passPark5, passPark6, passPark7, passPark8;
        private bool s5, s6, s7, s8;

        private bool Finger5, Finger6,Finger7, Finger8;

        Form form;
        public Form1()
        {

            InitializeComponent();
            leave = false;
            Reset();
            parkingSpace = 0;
            form = this;
            btnLeave.Visible = false;
            form.ControlBox = false;
            coinLost = false;
            payment = false;
            advancePayment = false;


            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
             @"Data source= E:\Year 2\C#\CarParkPrototype - V5\CarParkPrototype\AdvanceBooking.accdb";

        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (advance)
            {
                btnEnter.Visible = false;
                btnLeave.Visible = false;
              

                leave = true;
                DialogResult dialogResult = MessageBox.Show("Coin Received ?", "Collect Coin", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    grbxPin.Enabled = true;
                    coinLost = true;
                    txtbxInstructions.Text = "Please Enter Coin Pin to secure your Coin";
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    btnEnter.Visible = true;

                }
            }
            else
            {
                if (Start.advancedBooking)
                {

                    btnEnter.Visible = false;
                    btnLeave.Visible = false;
                    leave = true;
                    DialogResult dialogResult = MessageBox.Show("Coin Received ?", "Collect Coin", MessageBoxButtons.OKCancel);
                    if (dialogResult == DialogResult.OK)
                    {
                        grbxPin.Enabled = true;
                        coinLost = true;
                        txtbxInstructions.Text = "Please Enter Coin Pin to secure your Coin";
                    }
                    else if (dialogResult == DialogResult.Cancel)
                    {
                        btnEnter.Visible = true;

                    }
                }
                else
                {
                    btnEnter.Visible = false;
                    btnLeave.Visible = false;
                    btnAdvance.Visible = true;

                }
            }

        }
        private void btnEnterCarPark_Click(object sender, EventArgs e)
        {
            txtbxInstructions.Text = "Select Floor 2 for Secure Parking";
            grbxParking.Visible = true;
            grbxPin.Enabled = false;
            btnEnterCarPark.Visible = false;
            coinLost = false;

        }

        private void btnFloor1Parking_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                if (floor1[i])
                {
                    switch (i + 1)
                    {
                        case 1:
                            btnFloor1.Enabled = true;
                            btnFloor1.BackColor = Color.Lime;
                            break;
                        case 2:
                            btnFloor2.Enabled = true;
                            btnFloor2.BackColor = Color.Lime;
                            break;
                        case 3:
                            btnFloor3.Enabled = true;
                            btnFloor3.BackColor = Color.Lime;
                            break;
                        case 4:
                            btnFloor4.Enabled = true;
                            btnFloor4.BackColor = Color.Lime;
                            break;
                    }
                }

                grbxFloor1.Visible = true;
                grbxFloor2.Visible = false;

            }


        }

        private void btnFloor2Parking_Click(object sender, EventArgs e)
        {
            txtbxInstructions.Text = " ";
            for (int i = 0; i < 4; i++)
            {
                if (floor2[i])
                {
                    switch (i + 1)
                    {
                        case 1:
                            btnFloor5.Enabled = true;
                            btnFloor5.BackColor = Color.Lime;
                            break;
                        case 2:
                            btnFloor6.Enabled = true;
                            btnFloor6.BackColor = Color.Lime;
                            break;
                        case 3:
                            btnFloor7.Enabled = true;
                            btnFloor7.BackColor = Color.Lime;
                            break;
                        case 4:
                            btnFloor8.Enabled = true;
                            btnFloor8.BackColor = Color.Lime;
                            break;
                    }
                }

                grbxFloor1.Visible = false;
                grbxFloor2.Visible = true;

            }

        }


        private void btnFloor1_Click(object sender, EventArgs e)
        {

            parkingSpace = 1;
            if (leave)
            {
                selectSpaceFloor1();
            }
            else
            {
                selectLeavingFloor1();
            }
            btnFloor1.BackColor = Color.RoyalBlue;

        }
        private void btnFloor2_Click(object sender, EventArgs e)
        {
            parkingSpace = 2;
            if (leave)
            {
                selectSpaceFloor1();
            }
            else
            {
                selectLeavingFloor1();
            }
            btnFloor2.BackColor = Color.RoyalBlue;
        }

        private void btnFloor3_Click(object sender, EventArgs e)
        {
            parkingSpace = 3;
            if (leave)
            {
                selectSpaceFloor1();
            }
            else
            {
                selectLeavingFloor1();
            }
            btnFloor3.BackColor = Color.RoyalBlue;
        }

        private void btnFloor4_Click(object sender, EventArgs e)
        {
            parkingSpace = 4;
            if (leave)
            {
                selectSpaceFloor1();
            }
            else
            {
                selectLeavingFloor1();
            }
            btnFloor4.BackColor = Color.RoyalBlue;
        }

        private void btnFloor5_Click(object sender, EventArgs e)
        {
            s5 = true;
            s6 = false;
            s7 = false;
            s8 = false;

            parkingSpace = 5;
            if (leave)
            {
                selectSpaceFloor2();
            }
            else
            {
                selectLeavingFloor2();
            }
            btnFloor5.BackColor = Color.RoyalBlue;
        }

        private void btnFloor6_Click(object sender, EventArgs e)
        {
            s5 = false;
            s6 = true;
            s7 = false;
            s8 = false;
            parkingSpace = 6;
            if (leave)
            {
                selectSpaceFloor2();
            }
            else
            {
                selectLeavingFloor2();
            }
            btnFloor6.BackColor = Color.RoyalBlue;
        }

        private void btnFloor7_Click(object sender, EventArgs e)
        {
            s5 = false;
            s6 = false;
            s7 = true;
            s8 = false;

            parkingSpace = 7;
            if (leave)
            {
                selectSpaceFloor2();
            }
            else
            {
                selectLeavingFloor2();
            }
            btnFloor7.BackColor = Color.RoyalBlue;
        }

        private void btnFloor8_Click(object sender, EventArgs e)
        {
            s5 = true;
            s6 = false;
            s7 = false;
            s8 = true;

            parkingSpace = 8;
            if (leave)
            {
                selectSpaceFloor2();
            }
            else
            {
                selectLeavingFloor2();
            }
            btnFloor8.BackColor = Color.RoyalBlue;
        }
        private void selectSpaceFloor1()
        {

            for (int i = 0; i < 4; i++)
            {
                if (floor1[i])
                {
                    switch (i + 1)
                    {
                        case 1:
                            btnFloor1.Enabled = true;
                            btnFloor1.BackColor = Color.Lime;
                            break;
                        case 2:
                            btnFloor2.Enabled = true;
                            btnFloor2.BackColor = Color.Lime;
                            break;
                        case 3:
                            btnFloor3.Enabled = true;
                            btnFloor3.BackColor = Color.Lime;
                            break;
                        case 4:
                            btnFloor4.Enabled = true;
                            btnFloor4.BackColor = Color.Lime;
                            break;

                    }
                }
            }

        }
        private void selectSpaceFloor2()
        {

            for (int i = 0; i < 4; i++)
            {
                if (floor1[i])
                {
                    switch (i + 5)
                    {
                        case 5:
                            btnFloor5.Enabled = true;
                            btnFloor5.BackColor = Color.Lime;
                            break;
                        case 6:
                            btnFloor6.Enabled = true;
                            btnFloor6.BackColor = Color.Lime;
                            break;
                        case 7:
                            btnFloor7.Enabled = true;
                            btnFloor7.BackColor = Color.Lime;
                            break;
                        case 8:
                            btnFloor8.Enabled = true;
                            btnFloor8.BackColor = Color.Lime;
                            break;

                    }
                }
            }

        }

        private void btnFloor1Confirm_Click(object sender, EventArgs e)
        {
            txtbxInstructions.Text = "";
            btnFloor1.Enabled = false;
            btnFloor1.BackColor = Color.Red;
            btnFloor2.Enabled = false;
            btnFloor2.BackColor = Color.Red;
            btnFloor3.Enabled = false;
            btnFloor3.BackColor = Color.Red;
            btnFloor4.Enabled = false;
            btnFloor4.BackColor = Color.Red;




            grbxFloor1.Visible = false;
            if (leave)
            {
                if (parkingSpace > 0)
                    btnConfirmSpace.Visible = true;
                grbxParking.Enabled = true;
                btnFloor2Parking.Visible = false;
            }
            else
            {
                if (parkingSpace > 0)
                    btnConfirmLeave.Visible = true;
                grbxLeaving.Enabled = true;
                btnFloor2Leaving.Visible = false;

            }
        }
        private void btnFloor2Confirm_Click(object sender, EventArgs e)
        {
            txtbxInstructions.Text = "";
            btnFloor5.Enabled = false;
            btnFloor5.BackColor = Color.Red;
            btnFloor6.Enabled = false;
            btnFloor6.BackColor = Color.Red;
            btnFloor7.Enabled = false;
            btnFloor7.BackColor = Color.Red;
            btnFloor8.Enabled = false;
            btnFloor8.BackColor = Color.Red;
            btnFloor1Leaving.Visible = false;
            grbxFloor2.Visible = false;
            payment = true;


            if (leave)
            {
                if (parkingSpace > 0)
                {

                    grbxParking.Enabled = true;
                    grbxSecurity.Enabled = true;
                    btnFloor1Parking.Visible = false;
                    txtbxInstructions.Text = "Select The security Method";
                }
            }
            else
            {
                if (parkingSpace > 0)
                {
                    grbxLeaving.Enabled = true;
                    grbxSecurity.Enabled = true;
 
                }
            }
        }
        private void btnConfirmSpace_Click(object sender, EventArgs e)
        {
            txtbxInstructions.Text = "";
            btnConfirmSpace.Enabled = false;
            grbxParking.Enabled = false;
            grbxSecurity.Enabled = false;
            grbxPin.Enabled = false;
            grpbxFingerprint.Enabled = false;

            if ((parkingSpace > 0) && (parkingSpace <= 4))
            {
                floor1[parkingSpace - 1] = false;
            }
            else if ((parkingSpace >= 5) && (parkingSpace <= 8))
            {
                floor2[parkingSpace - 5] = false;
            }

            parkingSpace = 0;
            Reset();

        }
        private void btnLeave_Click(object sender, EventArgs e)
        {

            btnLeave.Visible = false;
            leave = false;
            btnEnter.Visible = false;


            DialogResult dialogResult = MessageBox.Show("Please Insert Coin ?", "Insert Coin", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                DialogResult dialogResult2 = MessageBox.Show("Have you Payed in advance ?", "Adance Pay", MessageBoxButtons.YesNo);
                if (dialogResult2 == DialogResult.Yes)
                {
                    payment = false;
                    advancePayment = true;
                    grbxPin.Enabled = true;
                    txtbxInstructions.Text = "Please Enter Pin";

                }
                else if (dialogResult2 == DialogResult.No)
                {
                    DialogResult dialogResult4= MessageBox.Show(" Pay For Parking?", "Adance Pay", MessageBoxButtons.OK);
                    if (dialogResult4 == DialogResult.OK)
                    {
                        btnFindCar.Visible = true;
                    }
                }

            }
            else if (dialogResult == DialogResult.Cancel)
            {
                txtbxInstructions.Text = "Please Pin to Continue";
                MessageBox.Show("Insert Pin", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                grbxPin.Enabled = true;
                coinLost = true;
            }


        }
    
        private void btnFindCar_Click(object sender, EventArgs e)
        {
            btnFindCar.Enabled = false;
            grbxLeaving.Visible = true;
            grbxPin.Enabled = false;
            coinLost = false;

        }
        private void selectLeavingFloor1()
        {
            for (int i = 0; i < 4; i++)
            {
                if (!floor1[i])
                {
                    switch (i + 1)
                    {
                        case 1:
                            btnFloor1.Enabled = true;
                            btnFloor1.BackColor = Color.Yellow;
                            break;
                        case 2:
                            btnFloor2.Enabled = true;
                            btnFloor2.BackColor = Color.Yellow;
                            break;
                        case 3:
                            btnFloor3.Enabled = true;
                            btnFloor3.BackColor = Color.Yellow;
                            break;
                        case 4:
                            btnFloor4.Enabled = true;
                            btnFloor4.BackColor = Color.Yellow;
                            break;

                    }
                }
            }
        }
        private void selectLeavingFloor2()
        {
            for (int i = 0; i < 4; i++)
            {
                if (!floor2[i])
                {
                    switch (i + 1)
                    {
                        case 1:
                            btnFloor5.Enabled = true;
                            btnFloor5.BackColor = Color.Yellow;
                            break;
                        case 2:
                            btnFloor6.Enabled = true;
                            btnFloor6.BackColor = Color.Yellow;
                            break;
                        case 3:
                            btnFloor7.Enabled = true;
                            btnFloor7.BackColor = Color.Yellow;
                            break;
                        case 4:
                            btnFloor8.Enabled = true;
                            btnFloor8.BackColor = Color.Yellow;
                            break;

                    }
                }
            }
        }
        private void btnFloor1Leaving_Click(object sender, EventArgs e)
        {
            selectLeavingFloor1();
            grbxFloor1.Visible = true;

            grbxFloor1.Visible = true;
            grbxFloor2.Visible = false;
        }
        private void btnFloor2Leaving_Click(object sender, EventArgs e)
        {
            selectLeavingFloor2();
            grbxFloor2.Visible = true;
            grbxFloor1.Visible = false;
        }

        private void btnConfirmLeave_Click(object sender, EventArgs e)
        {

                btnConfirmLeave.Enabled = false;

            if ((parkingSpace > 0) && (parkingSpace <= 4))
            {
                floor1[parkingSpace - 1] = true;

            }
            else if ((parkingSpace >= 5) && (parkingSpace <= 8))
            {
                floor2[parkingSpace - 5] = true;

            }
            txtbxInstructions.Text = "";
            parkingSpace = 0;
            Reset();

        }

        private void Reset()
        {

            btnEnter.Visible = true;
            btnLeave.Visible = true;

            btnEnterCarPark.Visible = false;
            btnConfirmSpace.Enabled = true;
            btnConfirmSpace.Visible = false;
            grbxParking.Visible = false;
            grbxParking.Enabled = true;
            grbxLeaving.Visible = false;
            grbxLeaving.Enabled = true;
            btnFindCar.Enabled = true;
            btnFindCar.Visible = false;
            btnConfirmLeave.Enabled = true;
            btnConfirmLeave.Visible = false;
            grbxSecurity.Enabled = false;
            grbxPin.Enabled = false;
            grpbxFingerprint.Enabled = false;
            btnFloor2Parking.Visible = true;
            btnFloor2Leaving.Visible = true;
            btnFloor2Parking.Visible = true;
            btnFloor1Leaving.Visible = true;
            btnFloor1Parking.Visible = true;

            txtbxInstructions.Text = "";
            txtbxPin.Text = "";



        }

        private void btnPasscode_Click(object sender, EventArgs e)
        {
            grbxPin.Enabled = true;
            if (leave)
            {
                MessageBox.Show("Enter A Pin Number To Secure Your Car", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Enter A Pin Number To release Your Car", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            grbxSecurity.Enabled = false;

        }


        private void btnAdvance_Click(object sender, EventArgs e)
        {
            grbxCodeAdvance.Visible = true;

        }

        private void btnCodeConfirmAdvance_Click(object sender, EventArgs e)
        {
               

            if (txtbxCodeAdvance.Text == "")
            {
                txtbxInstructions.Text = "Please Enter Value";
            }
            else
            {
                
                int ticketno = int.Parse(txtbxCodeAdvance.Text);
                String my_querry = "INSERT INTO AdvanceBooking(Code)VALUES('" + ticketno + "')";
                OleDbCommand cmd = new OleDbCommand(my_querry, conn);
                cmd.ExecuteNonQuery();


                advance = true;
                btnEnter.Visible = true;
                grbxCodeAdvance.Visible = false;
                btnAdvance.Visible = false;
            }

        }

         
        private void btnPin1_Click(object sender, EventArgs e)
        {
            if (txtbxPin.Text == "Please Enter Your Pin:")
            {
                txtbxPin.Text = "";
            }
            txtbxPin.Text += "1";
        }

        private void btnPin2_Click(object sender, EventArgs e)
        {
            if (txtbxPin.Text == "Please Enter Your Pin:")
            {
                txtbxPin.Text = "";
            }
            txtbxPin.Text += "2";
        }

        private void btnPin3_Click(object sender, EventArgs e)
        {
            if (txtbxPin.Text == "Please Enter Your Pin:")
            {
                txtbxPin.Text = "";
            }
            txtbxPin.Text += "3";
        }

        private void btnPin4_Click(object sender, EventArgs e)
        {
            if (txtbxPin.Text == "Please Enter Your Pin:")
            {
                txtbxPin.Text = "";
            }
            txtbxPin.Text += "4";
        }

        private void btnPin5_Click(object sender, EventArgs e)
        {
            if (txtbxPin.Text == "Please Enter Your Pin:")
            {
                txtbxPin.Text = "";
            }
            txtbxPin.Text += "5";
        }

        

        private void btnPin6_Click(object sender, EventArgs e)
        {
            if (txtbxPin.Text == "Please Enter Your Pin:")
            {
                txtbxPin.Text = "";
            }
            txtbxPin.Text += "6";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
          
            String my_querry = "DELETE *FROM LostPin";
            OleDbCommand cmd = new OleDbCommand(my_querry, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            Application.Exit();



        }

        private void btnPin7_Click(object sender, EventArgs e)
        {
            if (txtbxPin.Text == "Please Enter Your Pin:")
            {
                txtbxPin.Text = "";
            }
            txtbxPin.Text += "7";
        }

        private void btnFingerprint_Click(object sender, EventArgs e)
        {
            grpbxFingerprint.Enabled = true;
        }

        private void btnFingersensor_Click(object sender, EventArgs e)
        {
            grpbxFingerprint.Enabled = false;
            if (s5)
            {

                if (leave)
                {

                    Finger5 = true;
                    Finger6 = false;
                    Finger7 = false;
                    Finger8 = false;
                    btnConfirmSpace.Visible = true;
                    s5 = false;

                }
                else
                {

                    if (Finger5)
                    {
                        MessageBox.Show("Correct", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnFindCar.Visible = false;
                        btnConfirmLeave.Visible = true;
                        passPark5 = 0;
                        s5 = false;
                        Finger5 = false;


                    }
                }
            }

            if (s6)
            {
                if (leave)
                {

                    Finger5 = false;
                    Finger6 = true;
                    Finger7 = false;
                    Finger8 = false;
                    btnConfirmSpace.Visible = true;
                    s6 = false;

                }
                else
                {

                    if (Finger6)
                    {
                        MessageBox.Show("Correct", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnFindCar.Visible = false;
                        btnConfirmLeave.Visible = true;
                        passPark5 = 0;
                        s6 = false;
                        Finger6 = false;


                    }
                }
            }

            if (s7)
            {
                if (leave)
                {

                    Finger5 = false;
                    Finger6 = false;
                    Finger7 = true;
                    Finger8 = false;
                    btnConfirmSpace.Visible = true;
                    s7 = false;

                }
                else
                {

                    if (Finger5)
                    {
                        MessageBox.Show("Correct", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnFindCar.Visible = false;
                        btnConfirmLeave.Visible = true;
                        passPark5 = 0;
                        s7 = false;
                        Finger7 = false;


                    }
                }
            }

            if (s8)
            {
                if (leave)
                {

                    Finger5 = false;
                    Finger6 = false;
                    Finger7 = false;
                    Finger8 = true;
                    btnConfirmSpace.Visible = true;
                    s8 = false;

                }
                else
                {

                    if (Finger8)
                    {
                        MessageBox.Show("Correct", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnFindCar.Visible = false;
                        btnConfirmLeave.Visible = true;
                        passPark5 = 0;
                        s8 = false;
                        Finger8 = false;


                    }
                }
            }

        }

        private void btnPin8_Click(object sender, EventArgs e)
        {
            if (txtbxPin.Text == "Please Enter Your Pin:")
            {
                txtbxPin.Text = "";
            }
            txtbxPin.Text += "8";
        }

        private void btnPin9_Click(object sender, EventArgs e)
        {
            if (txtbxPin.Text == "Please Enter Your Pin:")
            {
                txtbxPin.Text = "";
            }
            txtbxPin.Text += "9";
        }

        private void btnPin0_Click(object sender, EventArgs e)
        {
            if (txtbxPin.Text == "Please Enter Your Pin:")
            {
                txtbxPin.Text = "";
            }
            txtbxPin.Text += "0";
        }
        private void btnPinBack_Click(object sender, EventArgs e)
        {
            string num = txtbxPin.Text.ToString();
            if (num.Length >= 1)
            {
                num = num.Remove(num.Length - 1, 1);
                txtbxPin.Text = num;
            }
        }
        private void btnPinEnter_Click_1(object sender, EventArgs e)
        {

            if (coinLost)
            {
                if (leave)
                {
                    if (txtbxPin.Text == "")
                    {
                        txtbxInstructions.Text = "Please Enter Value";
                    }
                    else
                    {
                        int coinpin = int.Parse(txtbxPin.Text);
                        String my_querry = "INSERT INTO LostPin(LostPin)VALUES('" + coinpin + "')";
                        OleDbCommand cmd = new OleDbCommand(my_querry, conn);
                        cmd.ExecuteNonQuery();
                        btnEnterCarPark.Visible = true;
                        txtbxPin.Text = "";
                    }

                }
                else
                {
                    if (txtbxPin.Text == "")
                    {
                        txtbxInstructions.Text = "Please Enter Value";
                    }
                    else
                    {
                        OleDbCommand cmd = new OleDbCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT * FROM LostPin WHERE LostPin= " + txtbxPin.Text + " ";
                        OleDbDataReader read;
                        read = cmd.ExecuteReader();

                        if (read.Read())
                        {
                            txtbxInstructions.Text = "Code accepted ";
                        }
                        else
                        {
                            Reset();

                        }
                        txtbxPin.Text = "";
                        txtbxInstructions.Text = "";
                      

                        DialogResult dialogResult3 = MessageBox.Show("Have you Payed in advance ?", "Adance Pay", MessageBoxButtons.YesNo);
                        if (dialogResult3 == DialogResult.Yes)
                        {
                            payment = false;
                            advancePayment = true;
                            grbxPin.Enabled = true;
                            txtbxInstructions.Text = "Please Enter Pin";

                        }
                        else if (dialogResult3 == DialogResult.No)
                        {
                            DialogResult dialogResult4 = MessageBox.Show(" Pay For Parking?", "Adance Pay", MessageBoxButtons.OK);
                            if (dialogResult4 == DialogResult.OK)
                            {
                                btnFindCar.Visible = true;
                            }
                        }
                    }
                }

            }
            else if(payment)
            {
                    if (s5)
                    {

                        if (leave)
                        {
                            if (txtbxPin.Text == "")
                            {
                                MessageBox.Show("Please enter a number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                passPark5 = Convert.ToInt32(txtbxPin.Text);
                                txtbxPin.Text = "";
                                btnConfirmSpace.Visible = true;
                                s5 = false;
                                lblTest1.Text = Convert.ToString(passPark5);

                        }

                        }
                        else
                        {

                            if (passPark5 == Convert.ToInt32(txtbxPin.Text))
                            {
                                if (txtbxPin.Text == "")
                                {
                                    MessageBox.Show("Please enter a number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    MessageBox.Show("Pin Correct", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    btnFindCar.Visible = false;
                                    btnConfirmLeave.Visible = true;
                                    txtbxPin.Text = "";
                                    passPark5 = 0;
                                    s5 = false;
                                    lblTest1.Text = Convert.ToString(passPark5);
                            }

                            }
                            else
                            {
                                MessageBox.Show("Incorrect Pin, Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtbxPin.Text = "";
                                Reset();

                            }
                        }
                    }

                    if (s6)
                    {
                        if (leave)
                        {
                            if (txtbxPin.Text == "")
                            {
                                MessageBox.Show("Please enter a number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                passPark6 = Convert.ToInt32(txtbxPin.Text);
                                txtbxPin.Text = "";
                                btnConfirmSpace.Visible = true;
                                s6 = false;
                                lblTest2.Text = Convert.ToString(passPark6);
                        }

                        }
                        else
                        {

                            if (passPark6 == Convert.ToInt32(txtbxPin.Text))
                            {
                                if (txtbxPin.Text == "")
                                {
                                    MessageBox.Show("Please enter a number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    MessageBox.Show("Pin Correct", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    btnFindCar.Visible = false;
                                    btnConfirmLeave.Visible = true;
                                    txtbxPin.Text = "";
                                    passPark6 = 0;
                                    s6 = false;
                                    lblTest2.Text = Convert.ToString(passPark6);
                            }
                            }
                            else
                            {
                                MessageBox.Show("Incorrect Pin, Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtbxPin.Text = "";
                            }
                        }
                    }

                    if (s7)
                    {
                        if (leave)
                        {
                            if (txtbxPin.Text == "")
                            {
                                MessageBox.Show("Please enter a number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                passPark7 = Convert.ToInt32(txtbxPin.Text);
                                btnConfirmSpace.Visible = true;
                                txtbxPin.Text = "";
                                s7 = false;
                                lblTest3.Text = Convert.ToString(passPark7);
                            }
                        }
                        else
                        {


                            if (passPark7 == Convert.ToInt32(txtbxPin.Text))
                            {
                                MessageBox.Show("Pin Correct", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnFindCar.Visible = false;
                                btnConfirmLeave.Visible = true;
                                txtbxPin.Text = "";
                                passPark7 = 0;
                                s7 = false;
                                lblTest3.Text = Convert.ToString(passPark7);
                        }
                            else
                            {
                                MessageBox.Show("Incorrect Pin, Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtbxPin.Text = "";
                            }
                        }
                    }

                    if (s8)
                    {
                        if (leave)
                        {
                            if (txtbxPin.Text == "")
                            {
                                MessageBox.Show("Please enter a number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                passPark8 = Convert.ToInt32(txtbxPin.Text);
                                txtbxPin.Text = "";
                                btnConfirmSpace.Visible = true;
                                s8 = false;
                                lblTest4.Text = Convert.ToString(passPark8);
                        }
                        }
                        else
                        {

                            if (passPark8 == Convert.ToInt32(txtbxPin.Text))
                            {
                                MessageBox.Show("Pin Correct", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnFindCar.Visible = false;
                                btnConfirmLeave.Visible = true;
                                txtbxPin.Text = "";
                                passPark8 = 0;
                                s8 = false;
                                lblTest4.Text = Convert.ToString(passPark8);
                        }
                            else
                            {
                                MessageBox.Show("Incorrect Pin, Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtbxPin.Text = "";
                            }
                        }
                    }

                grbxPin.Enabled = false;

            }else if (advancePayment)
            {

                if (txtbxPin.Text == "")
                {
                    txtbxInstructions.Text = "Please Enter Value";
                }
                else
                {
              
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM AdvanceBooking WHERE Code= " + txtbxPin.Text + " ";
                    OleDbDataReader read;
                    read = cmd.ExecuteReader();

                    if (read.Read())
                    {
                        txtbxInstructions.Text = "Code accepted ";
                        grbxPin.Enabled = false;
                        btnFindCar.Visible = true;
                        advancePayment = false;
                    }
                    else
                    {
                        Reset();
                    }
                    
                }

            }
   
        }
    }
}

