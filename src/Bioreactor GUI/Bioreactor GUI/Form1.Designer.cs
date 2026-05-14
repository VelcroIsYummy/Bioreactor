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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.tempGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tempLabel = new System.Windows.Forms.Label();
            this.rpmLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.rpmUpdateKi = new System.Windows.Forms.Button();
            this.rpmKiTextbox = new System.Windows.Forms.MaskedTextBox();
            this.rpmKdTextbox = new System.Windows.Forms.MaskedTextBox();
            this.rpmKdUpdate = new System.Windows.Forms.Button();
            this.rpmKpTextbox = new System.Windows.Forms.MaskedTextBox();
            this.RpmUpdateKp = new System.Windows.Forms.Button();
            this.rpmGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.tempGraph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpmGraph)).BeginInit();
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
            this.tempTextbox.Mask = "00";
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
            // tempGraph
            // 
            chartArea1.Name = "ChartArea1";
            this.tempGraph.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.tempGraph.Legends.Add(legend1);
            this.tempGraph.Location = new System.Drawing.Point(542, 16);
            this.tempGraph.Name = "tempGraph";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.tempGraph.Series.Add(series1);
            this.tempGraph.Size = new System.Drawing.Size(360, 157);
            this.tempGraph.TabIndex = 18;
            this.tempGraph.Text = "Temprature Graph";
            // 
            // tempLabel
            // 
            this.tempLabel.AutoSize = true;
            this.tempLabel.Location = new System.Drawing.Point(315, 279);
            this.tempLabel.Name = "tempLabel";
            this.tempLabel.Size = new System.Drawing.Size(13, 13);
            this.tempLabel.TabIndex = 19;
            this.tempLabel.Text = "0";
            this.tempLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rpmLabel
            // 
            this.rpmLabel.AutoSize = true;
            this.rpmLabel.Location = new System.Drawing.Point(455, 279);
            this.rpmLabel.Name = "rpmLabel";
            this.rpmLabel.Size = new System.Drawing.Size(13, 13);
            this.rpmLabel.TabIndex = 20;
            this.rpmLabel.Text = "0";
            this.rpmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(293, 252);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Temprature";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(448, 252);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "RPM";
            // 
            // rpmUpdateKi
            // 
            this.rpmUpdateKi.Location = new System.Drawing.Point(392, 157);
            this.rpmUpdateKi.Name = "rpmUpdateKi";
            this.rpmUpdateKi.Size = new System.Drawing.Size(105, 22);
            this.rpmUpdateKi.TabIndex = 28;
            this.rpmUpdateKi.Text = "Update Ki";
            this.rpmUpdateKi.UseVisualStyleBackColor = true;
            this.rpmUpdateKi.Click += new System.EventHandler(this.rpmUpdateKi_Click);
            // 
            // rpmKiTextbox
            // 
            this.rpmKiTextbox.Location = new System.Drawing.Point(277, 159);
            this.rpmKiTextbox.Mask = "000";
            this.rpmKiTextbox.Name = "rpmKiTextbox";
            this.rpmKiTextbox.Size = new System.Drawing.Size(109, 20);
            this.rpmKiTextbox.TabIndex = 27;
            this.rpmKiTextbox.ValidatingType = typeof(int);
            // 
            // rpmKdTextbox
            // 
            this.rpmKdTextbox.Location = new System.Drawing.Point(277, 194);
            this.rpmKdTextbox.Mask = "000";
            this.rpmKdTextbox.Name = "rpmKdTextbox";
            this.rpmKdTextbox.Size = new System.Drawing.Size(109, 20);
            this.rpmKdTextbox.TabIndex = 26;
            this.rpmKdTextbox.ValidatingType = typeof(int);
            // 
            // rpmKdUpdate
            // 
            this.rpmKdUpdate.Location = new System.Drawing.Point(392, 193);
            this.rpmKdUpdate.Name = "rpmKdUpdate";
            this.rpmKdUpdate.Size = new System.Drawing.Size(105, 22);
            this.rpmKdUpdate.TabIndex = 25;
            this.rpmKdUpdate.Text = "Update Kd";
            this.rpmKdUpdate.UseVisualStyleBackColor = true;
            this.rpmKdUpdate.Click += new System.EventHandler(this.rpmKdUpdate_Click);
            // 
            // rpmKpTextbox
            // 
            this.rpmKpTextbox.Location = new System.Drawing.Point(277, 119);
            this.rpmKpTextbox.Mask = "000";
            this.rpmKpTextbox.Name = "rpmKpTextbox";
            this.rpmKpTextbox.Size = new System.Drawing.Size(109, 20);
            this.rpmKpTextbox.TabIndex = 24;
            this.rpmKpTextbox.ValidatingType = typeof(int);
            // 
            // RpmUpdateKp
            // 
            this.RpmUpdateKp.Location = new System.Drawing.Point(392, 118);
            this.RpmUpdateKp.Name = "RpmUpdateKp";
            this.RpmUpdateKp.Size = new System.Drawing.Size(105, 22);
            this.RpmUpdateKp.TabIndex = 23;
            this.RpmUpdateKp.Text = "Update Kp";
            this.RpmUpdateKp.UseVisualStyleBackColor = true;
            this.RpmUpdateKp.Click += new System.EventHandler(this.RpmUpdateKp_Click);
            // 
            // rpmGraph
            // 
            chartArea2.Name = "ChartArea1";
            this.rpmGraph.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.rpmGraph.Legends.Add(legend2);
            this.rpmGraph.Location = new System.Drawing.Point(542, 179);
            this.rpmGraph.Name = "rpmGraph";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.rpmGraph.Series.Add(series2);
            this.rpmGraph.Size = new System.Drawing.Size(360, 157);
            this.rpmGraph.TabIndex = 29;
            this.rpmGraph.Text = "chart2";
            // 
            // BioreactorGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 343);
            this.Controls.Add(this.rpmGraph);
            this.Controls.Add(this.rpmUpdateKi);
            this.Controls.Add(this.rpmKiTextbox);
            this.Controls.Add(this.rpmKdTextbox);
            this.Controls.Add(this.rpmKdUpdate);
            this.Controls.Add(this.rpmKpTextbox);
            this.Controls.Add(this.RpmUpdateKp);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rpmLabel);
            this.Controls.Add(this.tempLabel);
            this.Controls.Add(this.tempGraph);
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
            ((System.ComponentModel.ISupportInitialize)(this.tempGraph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpmGraph)).EndInit();
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
        private System.Windows.Forms.DataVisualization.Charting.Chart tempGraph;
        private System.Windows.Forms.Label tempLabel;
        private System.Windows.Forms.Label rpmLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button rpmUpdateKi;
        private System.Windows.Forms.MaskedTextBox rpmKiTextbox;
        private System.Windows.Forms.MaskedTextBox rpmKdTextbox;
        private System.Windows.Forms.Button rpmKdUpdate;
        private System.Windows.Forms.MaskedTextBox rpmKpTextbox;
        private System.Windows.Forms.Button RpmUpdateKp;
        private System.Windows.Forms.DataVisualization.Charting.Chart rpmGraph;
    }
}

