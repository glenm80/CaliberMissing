namespace CaliberMissing
{
    partial class Main
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
            this.Output = new System.Windows.Forms.ListBox();
            this.CloseThis = new System.Windows.Forms.Button();
            this.Detect = new System.Windows.Forms.Button();
            this.SelectedDB = new System.Windows.Forms.TextBox();
            this.Browse = new System.Windows.Forms.Button();
            this.cmOutput = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Export = new System.Windows.Forms.ToolStripMenuItem();
            this.cmOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // Output
            // 
            this.Output.ContextMenuStrip = this.cmOutput;
            this.Output.FormattingEnabled = true;
            this.Output.Location = new System.Drawing.Point(3, 4);
            this.Output.Name = "Output";
            this.Output.Size = new System.Drawing.Size(719, 394);
            this.Output.TabIndex = 0;
            // 
            // CloseThis
            // 
            this.CloseThis.Location = new System.Drawing.Point(638, 415);
            this.CloseThis.Name = "CloseThis";
            this.CloseThis.Size = new System.Drawing.Size(75, 23);
            this.CloseThis.TabIndex = 1;
            this.CloseThis.Text = "Exit";
            this.CloseThis.UseVisualStyleBackColor = true;
            this.CloseThis.Click += new System.EventHandler(this.CloseThis_Click);
            // 
            // Detect
            // 
            this.Detect.Location = new System.Drawing.Point(516, 415);
            this.Detect.Name = "Detect";
            this.Detect.Size = new System.Drawing.Size(91, 23);
            this.Detect.TabIndex = 2;
            this.Detect.Text = "Detect Missing";
            this.Detect.UseVisualStyleBackColor = true;
            this.Detect.Click += new System.EventHandler(this.Detect_Click);
            // 
            // SelectedDB
            // 
            this.SelectedDB.Enabled = false;
            this.SelectedDB.Location = new System.Drawing.Point(3, 417);
            this.SelectedDB.Name = "SelectedDB";
            this.SelectedDB.Size = new System.Drawing.Size(421, 20);
            this.SelectedDB.TabIndex = 3;
            // 
            // Browse
            // 
            this.Browse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Browse.Location = new System.Drawing.Point(430, 415);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(29, 23);
            this.Browse.TabIndex = 4;
            this.Browse.Text = "...";
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // cmOutput
            // 
            this.cmOutput.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Export});
            this.cmOutput.Name = "cmOutput";
            this.cmOutput.Size = new System.Drawing.Size(109, 26);
            // 
            // Export
            // 
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(108, 22);
            this.Export.Text = "Export";
            this.Export.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 450);
            this.Controls.Add(this.Browse);
            this.Controls.Add(this.SelectedDB);
            this.Controls.Add(this.Detect);
            this.Controls.Add(this.CloseThis);
            this.Controls.Add(this.Output);
            this.Name = "Main";
            this.Text = "Missing books in Caliber";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.cmOutput.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Output;
        private System.Windows.Forms.Button CloseThis;
        private System.Windows.Forms.Button Detect;
        private System.Windows.Forms.TextBox SelectedDB;
        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.ContextMenuStrip cmOutput;
        private System.Windows.Forms.ToolStripMenuItem Export;
    }
}

