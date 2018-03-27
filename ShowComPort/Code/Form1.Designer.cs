namespace GetPortnamesExample
{
   partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.listBoxComports = new System.Windows.Forms.ListBox();
            this.btnManualUpgrade = new System.Windows.Forms.Button();
            this.chkAutoUpgrade = new System.Windows.Forms.CheckBox();
            this.chkOnlyShowArduino = new System.Windows.Forms.CheckBox();
            this.uiTimer = new System.Windows.Forms.Timer(this.components);
            this.updradeTimer = new System.Windows.Forms.Timer(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.SuspendLayout();
            // 
            // listBoxComports
            // 
            this.listBoxComports.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxComports.Font = new System.Drawing.Font("新細明體", 12F);
            this.listBoxComports.FormattingEnabled = true;
            this.listBoxComports.ItemHeight = 16;
            this.listBoxComports.Location = new System.Drawing.Point(10, 46);
            this.listBoxComports.Margin = new System.Windows.Forms.Padding(100);
            this.listBoxComports.Name = "listBoxComports";
            this.listBoxComports.Size = new System.Drawing.Size(355, 276);
            this.listBoxComports.TabIndex = 0;
            // 
            // btnManualUpgrade
            // 
            this.btnManualUpgrade.Location = new System.Drawing.Point(90, 13);
            this.btnManualUpgrade.Name = "btnManualUpgrade";
            this.btnManualUpgrade.Size = new System.Drawing.Size(136, 28);
            this.btnManualUpgrade.TabIndex = 1;
            this.btnManualUpgrade.Text = "更新";
            this.btnManualUpgrade.UseVisualStyleBackColor = true;
            this.btnManualUpgrade.Visible = false;
            this.btnManualUpgrade.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // chkAutoUpgrade
            // 
            this.chkAutoUpgrade.AutoSize = true;
            this.chkAutoUpgrade.Checked = true;
            this.chkAutoUpgrade.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoUpgrade.Location = new System.Drawing.Point(12, 19);
            this.chkAutoUpgrade.Name = "chkAutoUpgrade";
            this.chkAutoUpgrade.Size = new System.Drawing.Size(72, 16);
            this.chkAutoUpgrade.TabIndex = 2;
            this.chkAutoUpgrade.Text = "自動更新";
            this.chkAutoUpgrade.UseVisualStyleBackColor = true;
            this.chkAutoUpgrade.CheckedChanged += new System.EventHandler(this.chkAutoUpgrade_CheckedChanged);
            // 
            // chkOnlyShowArduino
            // 
            this.chkOnlyShowArduino.AutoSize = true;
            this.chkOnlyShowArduino.Enabled = false;
            this.chkOnlyShowArduino.Location = new System.Drawing.Point(232, 19);
            this.chkOnlyShowArduino.Name = "chkOnlyShowArduino";
            this.chkOnlyShowArduino.Size = new System.Drawing.Size(102, 16);
            this.chkOnlyShowArduino.TabIndex = 3;
            this.chkOnlyShowArduino.Text = "只顯示Arduino ";
            this.chkOnlyShowArduino.UseVisualStyleBackColor = true;
            this.chkOnlyShowArduino.Visible = false;
            this.chkOnlyShowArduino.CheckedChanged += new System.EventHandler(this.chkOnlyShowArduino_CheckedChanged);
            // 
            // uiTimer
            // 
            this.uiTimer.Tick += new System.EventHandler(this.uiTimer_Tick);
            // 
            // updradeTimer
            // 
            this.updradeTimer.Interval = 500;
            this.updradeTimer.Tick += new System.EventHandler(this.updradeTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 341);
            this.Controls.Add(this.chkOnlyShowArduino);
            this.Controls.Add(this.chkAutoUpgrade);
            this.Controls.Add(this.btnManualUpgrade);
            this.Controls.Add(this.listBoxComports);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "Form1";
            this.Text = "COM 裝置顯示 V1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ListBox listBoxComports;
        private System.Windows.Forms.Button btnManualUpgrade;
        private System.Windows.Forms.CheckBox chkAutoUpgrade;
        private System.Windows.Forms.CheckBox chkOnlyShowArduino;
        private System.Windows.Forms.Timer uiTimer;
        private System.Windows.Forms.Timer updradeTimer;
        private System.IO.Ports.SerialPort serialPort1;
    }
}

