namespace CocosJuceTestClientCSharp
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
            this.buttonStartTestTone = new System.Windows.Forms.Button();
            this.buttonStopTestTone = new System.Windows.Forms.Button();
            this.labelResult = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFrequency = new System.Windows.Forms.TextBox();
            this.textBoxAmplitude = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonSuspend = new System.Windows.Forms.Button();
            this.buttonResume = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonStartTestTone
            // 
            this.buttonStartTestTone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStartTestTone.Location = new System.Drawing.Point(40, 115);
            this.buttonStartTestTone.Name = "buttonStartTestTone";
            this.buttonStartTestTone.Size = new System.Drawing.Size(155, 40);
            this.buttonStartTestTone.TabIndex = 0;
            this.buttonStartTestTone.Text = "Start Test Tone";
            this.buttonStartTestTone.UseVisualStyleBackColor = true;
            this.buttonStartTestTone.Click += new System.EventHandler(this.buttonStartTestTone_Click);
            // 
            // buttonStopTestTone
            // 
            this.buttonStopTestTone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStopTestTone.Location = new System.Drawing.Point(222, 115);
            this.buttonStopTestTone.Name = "buttonStopTestTone";
            this.buttonStopTestTone.Size = new System.Drawing.Size(155, 40);
            this.buttonStopTestTone.TabIndex = 1;
            this.buttonStopTestTone.Text = "Stop Test Tone";
            this.buttonStopTestTone.UseVisualStyleBackColor = true;
            this.buttonStopTestTone.Click += new System.EventHandler(this.buttonStopTestTone_Click);
            // 
            // labelResult
            // 
            this.labelResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult.Location = new System.Drawing.Point(39, 249);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(338, 126);
            this.labelResult.TabIndex = 2;
            this.labelResult.Text = "?";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Frequency";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Amplitude";
            // 
            // textBoxFrequency
            // 
            this.textBoxFrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFrequency.Location = new System.Drawing.Point(141, 29);
            this.textBoxFrequency.Name = "textBoxFrequency";
            this.textBoxFrequency.Size = new System.Drawing.Size(100, 26);
            this.textBoxFrequency.TabIndex = 5;
            this.textBoxFrequency.Text = "440";
            // 
            // textBoxAmplitude
            // 
            this.textBoxAmplitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAmplitude.Location = new System.Drawing.Point(141, 60);
            this.textBoxAmplitude.Name = "textBoxAmplitude";
            this.textBoxAmplitude.Size = new System.Drawing.Size(100, 26);
            this.textBoxAmplitude.TabIndex = 6;
            this.textBoxAmplitude.Text = "0.8";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(247, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Hz";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(247, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "0..1";
            // 
            // buttonSuspend
            // 
            this.buttonSuspend.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSuspend.Location = new System.Drawing.Point(40, 174);
            this.buttonSuspend.Name = "buttonSuspend";
            this.buttonSuspend.Size = new System.Drawing.Size(155, 40);
            this.buttonSuspend.TabIndex = 9;
            this.buttonSuspend.Text = "Suspend";
            this.buttonSuspend.UseVisualStyleBackColor = true;
            this.buttonSuspend.Click += new System.EventHandler(this.buttonSuspend_Click);
            // 
            // buttonResume
            // 
            this.buttonResume.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonResume.Location = new System.Drawing.Point(222, 174);
            this.buttonResume.Name = "buttonResume";
            this.buttonResume.Size = new System.Drawing.Size(155, 40);
            this.buttonResume.TabIndex = 10;
            this.buttonResume.Text = "Resume";
            this.buttonResume.UseVisualStyleBackColor = true;
            this.buttonResume.Click += new System.EventHandler(this.buttonResume_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 398);
            this.Controls.Add(this.buttonResume);
            this.Controls.Add(this.buttonSuspend);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxAmplitude);
            this.Controls.Add(this.textBoxFrequency);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.buttonStopTestTone);
            this.Controls.Add(this.buttonStartTestTone);
            this.Name = "Form1";
            this.Text = "CocosJuceTestClientCSharp";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStartTestTone;
        private System.Windows.Forms.Button buttonStopTestTone;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFrequency;
        private System.Windows.Forms.TextBox textBoxAmplitude;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonSuspend;
        private System.Windows.Forms.Button buttonResume;
    }
}

