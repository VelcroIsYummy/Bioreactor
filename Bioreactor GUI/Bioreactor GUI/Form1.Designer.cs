namespace Bioreactor_GUI
{
    partial class BioreactorGUI
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.onButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.offButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.kpUpdate = new System.Windows.Forms.Button();
            this.kpTextbox = new System.Windows.Forms.MaskedTextBox();
            this.kdTextbox = new System.Windows.Forms.MaskedTextBox();
            this.kdUpdate = new System.Windows.Forms.Button();
            this.kiTextbox = new System.Windows.Forms.MaskedTextBox();
            this.kiUpdate = new System.Windows.Forms.Button();
            this.tempTextbox = new System.Windows.Forms.MaskedTextBox();
            this.updateTemprature = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.rpmTextbox = new System.Windows.Forms.MaskedTextBox();
            this.rpmUpdate = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tempLabel = new System.Windows.Forms.Label();
            this.rpmLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // onButton
            // 
            this.onButton.Location = new System.Drawing.Point(10, 70);
            this.onButton.Name = "onButton";
            this.onButton.Size = new System.Drawing.Size(108, 31);
            this.onButton.TabIndex = 0;
            this.onButton.Text = "Turn On";
            this.onButton.UseVisualStyleBackColor = true;
            this.onButton.Click += new System.EventHandler(this.onButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(36, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "System Controls";
            // 
            // offButton
            // 
            this.offButton.Location = new System.Drawing.Point(124, 70);
            this.offButton.Name = "offButton";
            this.offButton.Size = new System.Drawing.Size(108, 31);
            this.offButton.TabIndex = 2;
            this.offButton.Text = "Turn Off";
            this.offButton.UseVisualStyleBackColor = true;
            this.offButton.Click += new System.EventHandler(this.offButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label2.Location = new System.Drawing.Point(36, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "Heater Controls";
            // 
            // kpUpdate
            // 
            this.kpUpdate.Location = new System.Drawing.Point(127, 225);
            this.kpUpdate.Name = "kpUpdate";
            this.kpUpdate.Size = new System.Drawing.Size(105, 22);
            this.kpUpdate.TabIndex = 4;
            this.kpUpdate.Text = "Update Kp";
            this.kpUpdate.UseVisualStyleBackColor = true;
            this.kpUpdate.Click += new System.EventHandler(this.kpUpdate_Click);
            // 
            // kpTextbox
            // 
            this.kpTextbox.Location = new System.Drawing.Point(12, 226);
            this.kpTextbox.Mask = "000";
            this.kpTextbox.Name = "kpTextbox";
            this.kpTextbox.Size = new System.Drawing.Size(109, 20);
            this.kpTextbox.TabIndex = 6;
            this.kpTextbox.ValidatingType = typeof(int);
            // 
            // kdTextbox
            // 
            this.kdTextbox.Location = new System.Drawing.Point(12, 301);
            this.kdTextbox.Mask = "000";
            this.kdTextbox.Name = "kdTextbox";
            this.kdTextbox.Size = new System.Drawing.Size(109, 20);
            this.kdTextbox.TabIndex = 10;
            this.kdTextbox.ValidatingType = typeof(int);
            // 
            // kdUpdate
            // 
            this.kdUpdate.Location = new System.Drawing.Point(127, 300);
            this.kdUpdate.Name = "kdUpdate";
            this.kdUpdate.Size = new System.Drawing.Size(105, 22);
            this.kdUpdate.TabIndex = 9;
            this.kdUpdate.Text = "Update Kd";
            this.kdUpdate.UseVisualStyleBackColor = true;
            this.kdUpdate.Click += new System.EventHandler(this.kdUpdate_Click);
            // 
            // kiTextbox
            // 
            this.kiTextbox.Location = new System.Drawing.Point(12, 266);
            this.kiTextbox.Mask = "000";
            this.kiTextbox.Name = "kiTextbox";
            this.kiTextbox.Size = new System.Drawing.Size(109, 20);
            this.kiTextbox.TabIndex = 11;
            this.kiTextbox.ValidatingType = typeof(int);
            // 
            // kiUpdate
            // 
            this.kiUpdate.Location = new System.Drawing.Point(127, 264);
            this.kiUpdate.Name = "kiUpdate";
            this.kiUpdate.Size = new System.Drawing.Size(105, 22);
            this.kiUpdate.TabIndex = 12;
            this.kiUpdate.Text = "Update Ki";
            this.kiUpdate.UseVisualStyleBackColor = true;
            this.kiUpdate.Click += new System.EventHandler(this.kiUpdate_Click);
            // 
            // tempTextbox
            // 
            this.tempTextbox.Location = new System.Drawing.Point(12, 184);
            this.tempTextbox.Mask = "000";
            this.tempTextbox.Name = "tempTextbox";
            this.tempTextbox.Size = new System.Drawing.Size(109, 20);
            this.tempTextbox.TabIndex = 14;
            this.tempTextbox.ValidatingType = typeof(int);
            // 
            // updateTemprature
            // 
            this.updateTemprature.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F);
            this.updateTemprature.Location = new System.Drawing.Point(127, 183);
            this.updateTemprature.Name = "updateTemprature";
            this.updateTemprature.Size = new System.Drawing.Size(105, 22);
            this.updateTemprature.TabIndex = 13;
            this.updateTemprature.Text = "Update Temprature";
            this.updateTemprature.UseVisualStyleBackColor = true;
            this.updateTemprature.Click += new System.EventHandler(this.updateTemprature_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label3.Location = new System.Drawing.Point(302, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 26);
            this.label3.TabIndex = 15;
            this.label3.Text = "Impeller Controls";
            // 
            // rpmTextbox
            // 
            this.rpmTextbox.Location = new System.Drawing.Point(277, 76);
            this.rpmTextbox.Mask = "000";
            this.rpmTextbox.Name = "rpmTextbox";
            this.rpmTextbox.Size = new System.Drawing.Size(109, 20);
            this.rpmTextbox.TabIndex = 17;
            this.rpmTextbox.ValidatingType = typeof(int);
            // 
            // rpmUpdate
            // 
            this.rpmUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F);
            this.rpmUpdate.Location = new System.Drawing.Point(392, 75);
            this.rpmUpdate.Name = "rpmUpdate";
            this.rpmUpdate.Size = new System.Drawing.Size(105, 22);
            this.rpmUpdate.TabIndex = 16;
            this.rpmUpdate.Text = "Update RPM";
            this.rpmUpdate.UseVisualStyleBackColor = true;
            this.rpmUpdate.Click += new System.EventHandler(this.rpmUpdate_Click);
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(267, 186);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(229, 134);
            this.chart1.TabIndex = 18;
            this.chart1.Text = "chart1";
            // 
            // tempLabel
            // 
            this.tempLabel.AutoSize = true;
            this.tempLabel.Location = new System.Drawing.Point(312, 143);
            this.tempLabel.Name = "tempLabel";
            this.tempLabel.Size = new System.Drawing.Size(13, 13);
            this.tempLabel.TabIndex = 19;
            this.tempLabel.Text = "0";
            this.tempLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rpmLabel
            // 
            this.rpmLabel.AutoSize = true;
            this.rpmLabel.Location = new System.Drawing.Point(452, 143);
            this.rpmLabel.Name = "rpmLabel";
            this.rpmLabel.Size = new System.Drawing.Size(13, 13);
            this.rpmLabel.TabIndex = 20;
            this.rpmLabel.Text = "0";
            this.rpmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(290, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Temprature";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(445, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "RPM";
            // 
            // BioreactorGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 335);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rpmLabel);
            this.Controls.Add(this.tempLabel);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.rpmTextbox);
            this.Controls.Add(this.rpmUpdate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tempTextbox);
            this.Controls.Add(this.updateTemprature);
            this.Controls.Add(this.kiUpdate);
            this.Controls.Add(this.kiTextbox);
            this.Controls.Add(this.kdTextbox);
            this.Controls.Add(this.kdUpdate);
            this.Controls.Add(this.kpTextbox);
            this.Controls.Add(this.kpUpdate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.offButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.onButton);
            this.Name = "BioreactorGUI";
            this.Text = "Bioreactor GUI";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button onButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button offButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button kpUpdate;
        private System.Windows.Forms.MaskedTextBox kpTextbox;
        private System.Windows.Forms.MaskedTextBox kdTextbox;
        private System.Windows.Forms.Button kdUpdate;
        private System.Windows.Forms.MaskedTextBox kiTextbox;
        private System.Windows.Forms.Button kiUpdate;
        private System.Windows.Forms.MaskedTextBox tempTextbox;
        private System.Windows.Forms.Button updateTemprature;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox rpmTextbox;
        private System.Windows.Forms.Button rpmUpdate;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label tempLabel;
        private System.Windows.Forms.Label rpmLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

