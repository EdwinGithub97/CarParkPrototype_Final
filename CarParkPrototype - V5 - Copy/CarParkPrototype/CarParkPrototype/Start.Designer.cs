namespace CarParkPrototype
{
    partial class Start
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEnterCarPark = new System.Windows.Forms.Button();
            this.btnAdvanceBooking = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEnterCarPark
            // 
            this.btnEnterCarPark.Location = new System.Drawing.Point(87, 116);
            this.btnEnterCarPark.Margin = new System.Windows.Forms.Padding(4);
            this.btnEnterCarPark.Name = "btnEnterCarPark";
            this.btnEnterCarPark.Size = new System.Drawing.Size(172, 73);
            this.btnEnterCarPark.TabIndex = 0;
            this.btnEnterCarPark.Text = "Entry CarPark";
            this.btnEnterCarPark.UseVisualStyleBackColor = true;
            this.btnEnterCarPark.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnAdvanceBooking
            // 
            this.btnAdvanceBooking.Location = new System.Drawing.Point(311, 116);
            this.btnAdvanceBooking.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdvanceBooking.Name = "btnAdvanceBooking";
            this.btnAdvanceBooking.Size = new System.Drawing.Size(172, 73);
            this.btnAdvanceBooking.TabIndex = 1;
            this.btnAdvanceBooking.Text = "Advance Booking";
            this.btnAdvanceBooking.UseVisualStyleBackColor = true;
            this.btnAdvanceBooking.Click += new System.EventHandler(this.btnAdvanceBooking_Click);
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 322);
            this.Controls.Add(this.btnAdvanceBooking);
            this.Controls.Add(this.btnEnterCarPark);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Start";
            this.Text = "Start";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEnterCarPark;
        private System.Windows.Forms.Button btnAdvanceBooking;
    }
}