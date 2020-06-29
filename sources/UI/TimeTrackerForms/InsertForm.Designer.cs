namespace StopWatch.TimeTracker
{
    partial class InsertForm
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
            this.cbTimeType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSubGroupTimeType = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.tbTimeAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtDateWorked = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnEditTimeType = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbTimeType
            // 
            this.cbTimeType.FormattingEnabled = true;
            this.cbTimeType.Location = new System.Drawing.Point(31, 47);
            this.cbTimeType.Name = "cbTimeType";
            this.cbTimeType.Size = new System.Drawing.Size(159, 21);
            this.cbTimeType.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Time Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sub Grouping Time Type";
            // 
            // tbSubGroupTimeType
            // 
            this.tbSubGroupTimeType.Location = new System.Drawing.Point(31, 127);
            this.tbSubGroupTimeType.Name = "tbSubGroupTimeType";
            this.tbSubGroupTimeType.Size = new System.Drawing.Size(159, 20);
            this.tbSubGroupTimeType.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Notes";
            // 
            // tbNotes
            // 
            this.tbNotes.Location = new System.Drawing.Point(31, 171);
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(159, 20);
            this.tbNotes.TabIndex = 5;
            // 
            // tbTimeAmount
            // 
            this.tbTimeAmount.Location = new System.Drawing.Point(215, 47);
            this.tbTimeAmount.Name = "tbTimeAmount";
            this.tbTimeAmount.Size = new System.Drawing.Size(159, 20);
            this.tbTimeAmount.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(212, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Time Amount";
            // 
            // dtDateWorked
            // 
            this.dtDateWorked.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDateWorked.Location = new System.Drawing.Point(218, 127);
            this.dtDateWorked.Name = "dtDateWorked";
            this.dtDateWorked.Size = new System.Drawing.Size(91, 20);
            this.dtDateWorked.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(218, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Date Worked";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(218, 169);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 10;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // btnEditTimeType
            // 
            this.btnEditTimeType.Location = new System.Drawing.Point(31, 74);
            this.btnEditTimeType.Name = "btnEditTimeType";
            this.btnEditTimeType.Size = new System.Drawing.Size(89, 23);
            this.btnEditTimeType.TabIndex = 11;
            this.btnEditTimeType.Text = "Edit Time Type";
            this.btnEditTimeType.UseVisualStyleBackColor = true;
            this.btnEditTimeType.Click += new System.EventHandler(this.BtnEditTimeType_Click);
            // 
            // InsertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 216);
            this.Controls.Add(this.btnEditTimeType);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtDateWorked);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbTimeAmount);
            this.Controls.Add(this.tbNotes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbSubGroupTimeType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbTimeType);
            this.Name = "InsertForm";
            this.Text = "InsertForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTimeType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSubGroupTimeType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.TextBox tbTimeAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtDateWorked;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnEditTimeType;
    }
}