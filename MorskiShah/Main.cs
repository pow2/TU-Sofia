using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MorskiShah.Logic;

namespace MorskiShah
{
    public partial class Main : Form
    {
        //status player X or player O
        public Status Status
        {
            get;
            private set;
        }

        //array for AI calculations
        int[,] ARR = new int[3, 3];

        //score counter
        int brP = 0;
        int brC = 0;

        public Main()
        {
            InitializeComponent();
            Status = Status.Xuser;
            Reset();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnO_Click(object sender, EventArgs e)
        {
            Status = Status.Ouser;
            Reset();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Status = Status.Xuser;
            Reset();
        }

        private int VictoryCheck()
        {
            //victory: 0 = none, 1 = player, 2 = CPU
            int v = 0;
            //check for Player winner

            if (ARR[0, 0] == ARR[0, 1] && ARR[0, 2] == ARR[0, 1] && ARR[0, 2] == 1) v = 1;
            else if (ARR[1, 0] == ARR[1, 1] && ARR[1, 2] == ARR[1, 1] && ARR[1, 2] == 1) v = 1;
            else if (ARR[2, 0] == ARR[2, 1] && ARR[2, 2] == ARR[2, 1] && ARR[2, 2] == 1) v = 1;
            else if (ARR[0, 0] == ARR[1, 1] && ARR[2, 2] == ARR[1, 1] && ARR[2, 2] == 1) v = 1;
            else if (ARR[0, 2] == ARR[1, 1] && ARR[2, 0] == ARR[1, 1] && ARR[2, 0] == 1) v = 1;
            else if (ARR[0, 0] == ARR[1, 0] && ARR[2, 0] == ARR[1, 0] && ARR[2, 0] == 1) v = 1;
            else if (ARR[0, 1] == ARR[1, 1] && ARR[2, 1] == ARR[1, 1] && ARR[2, 1] == 1) v = 1;
            else if (ARR[0, 2] == ARR[1, 2] && ARR[2, 2] == ARR[1, 2] && ARR[2, 2] == 1) v = 1;
            //check for CPU winner
            else if (ARR[0, 0] == ARR[0, 1] && ARR[0, 2] == ARR[0, 1] && ARR[0, 2] == 2) v = 2;
            else if (ARR[1, 0] == ARR[1, 1] && ARR[1, 2] == ARR[1, 1] && ARR[1, 2] == 2) v = 2;
            else if (ARR[2, 0] == ARR[2, 1] && ARR[2, 2] == ARR[2, 1] && ARR[2, 2] == 2) v = 2;
            else if (ARR[0, 0] == ARR[1, 1] && ARR[2, 2] == ARR[1, 1] && ARR[2, 2] == 2) v = 2;
            else if (ARR[0, 2] == ARR[1, 1] && ARR[2, 0] == ARR[1, 1] && ARR[2, 0] == 2) v = 2;
            else if (ARR[0, 0] == ARR[1, 0] && ARR[2, 0] == ARR[1, 0] && ARR[2, 0] == 2) v = 2;
            else if (ARR[0, 1] == ARR[1, 1] && ARR[2, 1] == ARR[1, 1] && ARR[2, 1] == 2) v = 2;
            else if (ARR[0, 2] == ARR[1, 2] && ARR[2, 2] == ARR[1, 2] && ARR[2, 2] == 2) v = 2;
            else if (ARR[0, 0] != 0 && ARR[0, 1] != 0 && ARR[0, 2] != 0 && ARR[1, 0] != 0 && ARR[1, 1] != 0 && ARR[1, 2] != 0 && ARR[2, 0] != 0 && ARR[2, 1] != 0 && ARR[2, 2] != 0) v = 3;

            if (v == 1)
            {
                brP++;
                lblPScore.Text = brP.ToString();
                System.Threading.Thread.Sleep(1000); 
                Reset();
            }
            else if (v == 2)
            {
                brC++;
                lblCScore.Text = brC.ToString();
                System.Threading.Thread.Sleep(1000); 
                Reset();
            }
            else if (v == 3) {System.Threading.Thread.Sleep(1000); Reset();}
            return v;
        }


        //reset the table
        private void Reset()
        {
            btn1.Text = ""; btn2.Text = ""; btn3.Text = "";
            btn4.Text = ""; btn5.Text = ""; btn6.Text = "";
            btn7.Text = ""; btn8.Text = ""; btn9.Text = "";

            ARR[0, 0] = 0; ARR[0, 1] = 0; ARR[0, 2] = 0;
            ARR[1, 0] = 0; ARR[1, 1] = 0; ARR[1, 2] = 0;
            ARR[2, 0] = 0; ARR[2, 1] = 0; ARR[2, 2] = 0;

            btn1.Enabled = true; btn2.Enabled = true; btn3.Enabled = true;
            btn4.Enabled = true; btn5.Enabled = true; btn6.Enabled = true;
            btn7.Enabled = true; btn8.Enabled = true; btn9.Enabled = true;

            switch (Status)
            {
                case Status.Ouser: { CPU(); }
                    break;
                default:
                    break;
            } 
       
        }


       
        //random
        static Random _r = new Random();

        //AI
        private void CPU()
        {
            int i = 0;
            String c = "null!";
            int n;
            switch (Status)
            {
                case Status.Xuser: {i = 1; c = "O";}; 
                    break;
                case Status.Ouser: {i = 2; c = "X";};
                    break;
                default:
                    break;
            }
            
            if (i == 2 && ARR[0, 0] == 0 && ARR[0, 1] == 0 && ARR[0, 2] == 0 && ARR[1, 0] == 0 && ARR[1, 1] == 0 && ARR[1, 2] == 0 && ARR[2, 0] == 0 && ARR[2, 1] == 0 && ARR[2, 2] == 0)
            {
                n = _r.Next(8);
                if (n == 1) { btn1.Text = c; ARR[0, 0] = 2; btn1.Enabled = false; }
                else if (n == 2) { btn2.Text = c; ARR[0, 1] = 2; btn2.Enabled = false; }
                else if (n == 3) { btn3.Text = c; ARR[0, 2] = 2; btn3.Enabled = false; }
                else if (n == 4) { btn4.Text = c; ARR[1, 0] = 2; btn4.Enabled = false; }
                else if (n == 5) { btn5.Text = c; ARR[1, 1] = 2; btn5.Enabled = false; }
                else if (n == 6) { btn6.Text = c; ARR[1, 2] = 2; btn6.Enabled = false; }
                else if (n == 7) { btn7.Text = c; ARR[2, 0] = 2; btn7.Enabled = false; }
                else if (n == 8) { btn8.Text = c; ARR[2, 1] = 2; btn8.Enabled = false; }
                else if (n == 0) { btn9.Text = c; ARR[2, 2] = 2; btn9.Enabled = false; }
            }
            else
             {
                //d1
                if      (ARR[0, 0] == 1 && ARR[1, 1] == 1 && ARR[2, 2] == 0) { btn9.Text = c; ARR[2, 2] = 2; btn9.Enabled = false; }
                else if (ARR[0, 0] == 1 && ARR[2, 2] == 1 && ARR[1, 1] == 0) { btn5.Text = c; ARR[1, 1] = 2; btn5.Enabled = false; }
                else if (ARR[1, 1] == 1 && ARR[2, 2] == 1 && ARR[0, 0] == 0) { btn1.Text = c; ARR[0, 0] = 2; btn1.Enabled = false; }
               //d2
                else if (ARR[0, 2] == 1 && ARR[1, 1] == 1 && ARR[2, 0] == 0) { btn7.Text = c; ARR[2, 0] = 2; btn7.Enabled = false; }
                else if (ARR[0, 2] == 1 && ARR[2, 0] == 1 && ARR[1, 1] == 0) { btn5.Text = c; ARR[1, 1] = 2; btn5.Enabled = false; }
                else if (ARR[1, 1] == 1 && ARR[2, 0] == 1 && ARR[0, 2] == 0) { btn3.Text = c; ARR[0, 2] = 2; btn3.Enabled = false; }
                //column1
                else if (ARR[0, 0] == 1 && ARR[1, 0] == 1 && ARR[2, 0] == 0) { btn7.Text = c; ARR[2, 0] = 2; btn7.Enabled = false; }
                else if (ARR[0, 0] == 1 && ARR[2, 0] == 1 && ARR[1, 0] == 0) { btn4.Text = c; ARR[1, 0] = 2; btn4.Enabled = false; }
                else if (ARR[1, 0] == 1 && ARR[2, 0] == 1 && ARR[0, 0] == 0) { btn1.Text = c; ARR[0, 0] = 2; btn1.Enabled = false; }
                //column2
                else if (ARR[0, 1] == 1 && ARR[1, 1] == 1 && ARR[2, 1] == 0) { btn8.Text = c; ARR[2, 1] = 2; btn8.Enabled = false; }
                else if (ARR[0, 1] == 1 && ARR[2, 1] == 1 && ARR[1, 1] == 0) { btn5.Text = c; ARR[1, 1] = 2; btn5.Enabled = false; }
                else if (ARR[1, 1] == 1 && ARR[2, 1] == 1 && ARR[0, 1] == 0) { btn2.Text = c; ARR[0, 1] = 2; btn2.Enabled = false; }
                //column3
                else if (ARR[0, 2] == 1 && ARR[1, 2] == 1 && ARR[2, 2] == 0) { btn9.Text = c; ARR[2, 2] = 2; btn9.Enabled = false; }
                else if (ARR[0, 2] == 1 && ARR[2, 2] == 1 && ARR[1, 2] == 0) { btn6.Text = c; ARR[1, 2] = 2; btn6.Enabled = false; }
                else if (ARR[1, 2] == 1 && ARR[2, 2] == 1 && ARR[0, 2] == 0) { btn3.Text = c; ARR[0, 2] = 2; btn3.Enabled = false; }
                //row1 
                else if (ARR[0, 0] == 1 && ARR[0, 1] == 1 && ARR[0, 2] == 0) { btn3.Text = c; ARR[0, 2] = 2; btn3.Enabled = false; }
                else if (ARR[0, 0] == 1 && ARR[0, 2] == 1 && ARR[0, 1] == 0) { btn2.Text = c; ARR[0, 1] = 2; btn2.Enabled = false; }
                else if (ARR[0, 1] == 1 && ARR[0, 2] == 1 && ARR[0, 0] == 0) { btn1.Text = c; ARR[0, 0] = 2; btn1.Enabled = false; }
                //row2
                else if (ARR[1, 0] == 1 && ARR[1, 1] == 1 && ARR[1, 2] == 0) { btn6.Text = c; ARR[1, 2] = 2; btn6.Enabled = false; }
                else if (ARR[1, 0] == 1 && ARR[1, 2] == 1 && ARR[1, 1] == 0) { btn5.Text = c; ARR[1, 1] = 2; btn5.Enabled = false; }
                else if (ARR[1, 1] == 1 && ARR[1, 2] == 1 && ARR[1, 0] == 0) { btn4.Text = c; ARR[1, 0] = 2; btn4.Enabled = false; }
                //row3
                else if (ARR[2, 0] == 1 && ARR[2, 1] == 1 && ARR[2, 2] == 0) { btn9.Text = c; ARR[2, 2] = 2; btn9.Enabled = false; }
                else if (ARR[2, 0] == 1 && ARR[2, 2] == 1 && ARR[2, 1] == 0) { btn8.Text = c; ARR[2, 1] = 2; btn8.Enabled = false; }
                else if (ARR[2, 1] == 1 && ARR[2, 2] == 1 && ARR[2, 0] == 0) { btn7.Text = c; ARR[2, 0] = 2; btn7.Enabled = false; }
                else
                 {
                     n = _r.Next(8);
                     if (n == 1 && ARR[0, 0] == 0) { btn1.Text = c; ARR[0, 0] = 2; btn1.Enabled = false; }
                     else if (n == 2 && ARR[0, 1] == 0) { btn2.Text = c; ARR[0, 1] = 2; btn2.Enabled = false; }
                     else if (n == 3 && ARR[0, 2] == 0) { btn3.Text = c; ARR[0, 2] = 2; btn3.Enabled = false; }
                     else if (n == 4 && ARR[1, 0] == 0) { btn4.Text = c; ARR[1, 0] = 2; btn4.Enabled = false; }
                     else if (n == 5 && ARR[1, 1] == 0) { btn5.Text = c; ARR[1, 1] = 2; btn5.Enabled = false; }
                     else if (n == 6 && ARR[1, 2] == 0) { btn6.Text = c; ARR[1, 2] = 2; btn6.Enabled = false; }
                     else if (n == 7 && ARR[2, 0] == 0) { btn7.Text = c; ARR[2, 0] = 2; btn7.Enabled = false; }
                     else if (n == 8 && ARR[2, 1] == 0) { btn8.Text = c; ARR[2, 1] = 2; btn8.Enabled = false; }
                     else if (n == 0 && ARR[2, 2] == 0) { btn9.Text = c; ARR[2, 2] = 2; btn9.Enabled = false; }
                     else
                     {
                         if (ARR[0, 0] == 0) { btn1.Text = c; ARR[0, 0] = 2; btn1.Enabled = false; }
                         else if (ARR[0, 1] == 0) { btn2.Text = c; ARR[0, 1] = 2; btn2.Enabled = false; }
                         else if (ARR[0, 2] == 0) { btn3.Text = c; ARR[0, 2] = 2; btn3.Enabled = false; }
                         else if (ARR[1, 0] == 0) { btn4.Text = c; ARR[1, 0] = 2; btn4.Enabled = false; }
                         else if (ARR[1, 1] == 0) { btn5.Text = c; ARR[1, 1] = 2; btn5.Enabled = false; }
                         else if (ARR[1, 2] == 0) { btn6.Text = c; ARR[1, 2] = 2; btn6.Enabled = false; }
                         else if (ARR[2, 0] == 0) { btn7.Text = c; ARR[2, 0] = 2; btn7.Enabled = false; }
                         else if (ARR[2, 1] == 0) { btn8.Text = c; ARR[2, 1] = 2; btn8.Enabled = false; }
                         else if (ARR[2, 2] == 0) { btn9.Text = c; ARR[2, 2] = 2; btn9.Enabled = false; }
                     }
                 }
            }
            VictoryCheck();
            
        }

        //Null the results
        private void btnNull_Click(object sender, EventArgs e)
        {
            brP = 0;
            brC = 0;
            lblPScore.Text = brP.ToString();
            lblCScore.Text = brC.ToString();
        }

        //all buttons
       /* private void btn_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            switch (Status)
            {
                case Status.Xuser: b.Text = "X";
                    break;
                case Status.Ouser: b.Text = "O";
                    break;
                default:
                    break;
            }

            b.Enabled = false;
            
            if (VictoryCheck() == 0) CPU();

        }*/
        private void btn1_Click(object sender, EventArgs e)
        {
            switch (Status)
            {
                case Status.Xuser: btn1.Text = "X";
                    break;
                case Status.Ouser: btn1.Text = "O";
                    break;
                default:
                    break;
            }
            ARR[0, 0] = 1;
            btn1.Enabled = false;
            if (VictoryCheck() == 0) CPU();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            switch (Status)
            {
                case Status.Xuser: btn2.Text = "X";
                    break;
                case Status.Ouser: btn2.Text = "O";
                    break;
                default:
                    break;
            }
            ARR[0, 1] = 1;
            btn2.Enabled = false;
            if (VictoryCheck() == 0) CPU();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            switch (Status)
            {
                case Status.Xuser: btn3.Text = "X";
                    break;
                case Status.Ouser: btn3.Text = "O";
                    break;
                default:
                    break;
            }
            ARR[0, 2] = 1;
            btn3.Enabled = false;
            if (VictoryCheck() == 0) CPU();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            switch (Status)
            {
                case Status.Xuser: btn4.Text = "X";
                    break;
                case Status.Ouser: btn4.Text = "O";
                    break;
                default:
                    break;
            }
            ARR[1, 0] = 1;
            btn4.Enabled = false;
            if (VictoryCheck() == 0) CPU();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            switch (Status)
            {
                case Status.Xuser: btn5.Text = "X";
                    break;
                case Status.Ouser: btn5.Text = "O";
                    break;
                default:
                    break;
            }
            ARR[1, 1] = 1;
            btn5.Enabled = false;
            if (VictoryCheck() == 0) CPU();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            switch (Status)
            {
                case Status.Xuser: btn6.Text = "X";
                    break;
                case Status.Ouser: btn6.Text = "O";
                    break;
                default:
                    break;
            }
            ARR[1, 2] = 1;
            btn6.Enabled = false;
            if (VictoryCheck() == 0) CPU();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            switch (Status)
            {
                case Status.Xuser: btn7.Text = "X";
                    break;
                case Status.Ouser: btn7.Text = "O";
                    break;
                default:
                    break;
            }
            ARR[2, 0] = 1;
            btn7.Enabled = false;
            if (VictoryCheck() == 0) CPU();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            switch (Status)
            {
                case Status.Xuser: btn8.Text = "X";
                    break;
                case Status.Ouser: btn8.Text = "O";
                    break;
                default:
                    break;
            }
            ARR[2, 1] = 1;
            btn8.Enabled = false;
            if (VictoryCheck() == 0) CPU();
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            switch (Status)
            {
                case Status.Xuser: btn9.Text = "X";
                    break;
                case Status.Ouser: btn9.Text = "O";
                    break;
                default:
                    break;
            }
            ARR[2, 2] = 1;
            btn9.Enabled = false;
            if (VictoryCheck() == 0) CPU();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox box1 = new AboutBox();
            box1.Show();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            brP = 0;
            brC = 0;
            lblPScore.Text = brP.ToString();
            lblCScore.Text = brC.ToString();
        }

        private void playWithXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Status = Status.Xuser;
            Reset();
        }

        private void PlayWithОToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Status = Status.Ouser;
            Reset();
        }


    }
}
