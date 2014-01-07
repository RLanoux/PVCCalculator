using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PVCCalculator
{
    public partial class Form1 : Form
    {
        const String APP_VERSION = "v 1.0";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "PVC Calculator " + APP_VERSION;
            txtIntDiam.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtIntDiam.Text = String.Empty;
            txtWallThick.Text = String.Empty;
            txtLength.Text = String.Empty;
            txtQuantity.Text = String.Empty;
            txtIntDiam.Focus();
        }

        private void DoWork()
        {
            //This method does the actual work of calculating the volume of PVC needed, and informs the user.
            //Declare and initialize variables
            Double dInnerVolume = 0.0;
            Double dOuterVolume = 0.0;
            Double dLength = 0.0;
            Double dThickness = 0.0;
            Double dMaterialVolume = 0.0;
            Int32 iUnitCount = 0;

            Double dInnerRadius = 0.0;

            Cylinder cylInner = null;
            Cylinder cylOuter = null;

            //Calculate the internal radius of the pipe
            try
            {
                dInnerRadius = (Convert.ToDouble(txtIntDiam.Text) / 2);
            }
            catch (Exception ex)
            {
                txtIntDiam.Text = "ERROR!";
                MessageBox.Show("The following error occurred: " + ex.Message,
                    "PVC Calculator " + APP_VERSION,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                txtIntDiam.Clear();
                txtIntDiam.Focus();
                return;
            }

            //Determine the length of the pipe
            try
            {
                dLength = Convert.ToDouble(txtLength.Text);
            }
            catch (Exception ex)
            {
                 txtLength.Text = "ERROR!";
                MessageBox.Show("The following error occurred: " + ex.Message,
                    "PVC Calculator " + APP_VERSION,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                txtLength.Clear();
                txtLength.Focus();
                return;
            }

            //Determine the thickness of the pipe walls
            try
            {
                dThickness = Convert.ToDouble(txtWallThick.Text);
            }
            catch (Exception ex)
            {
                 txtWallThick.Text = "ERROR!";
                MessageBox.Show("The following error occurred: " + ex.Message,
                    "PVC Calculator " + APP_VERSION,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                txtWallThick.Clear();
                txtWallThick.Focus();
                return;
            }

            //Determine the number of units required
            try
            {
                iUnitCount = Convert.ToInt32(txtQuantity.Text);
            }
            catch (Exception ex)
            {
                 txtQuantity.Text = "ERROR!";
                MessageBox.Show("The following error occurred: " + ex.Message,
                    "PVC Calculator " + APP_VERSION,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                txtQuantity.Clear();
                txtQuantity.Focus();
                return;
            }
            //Instantiate the internal cylinder(the air, basically)
            cylInner = new Cylinder(dInnerRadius, dLength * 12);

            //Instantiate the external cylinder (the plastic plus the air)
            cylOuter = new Cylinder(dInnerRadius + dThickness, dLength * 12);

            //Calculate the volume difference between the two cylinders
            dInnerVolume = cylInner.ShowVolume();
            dOuterVolume = cylOuter.ShowVolume();
            dMaterialVolume = (dOuterVolume - dInnerVolume) * (Double)iUnitCount;

            //Inform the user
            tslStatus.Text = "Volume of PVC Required: "
                + Math.Round(dMaterialVolume + .5, 0).ToString()
                + " cubic inches.";
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            DoWork();
        }
    }
}
