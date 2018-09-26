namespace Task_3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblGameMap = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.tmrGameTimer = new System.Windows.Forms.Timer(this.components);
            this.lblGameCounter = new System.Windows.Forms.Label();
            this.cmbUnitsStats = new System.Windows.Forms.ComboBox();
            this.lblOosorionResourcesCounter = new System.Windows.Forms.Label();
            this.lblAsobaxianResourcesCounter = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblGameMap
            // 
            this.lblGameMap.AutoSize = true;
            this.lblGameMap.BackColor = System.Drawing.SystemColors.Menu;
            this.lblGameMap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblGameMap.Cursor = System.Windows.Forms.Cursors.No;
            this.lblGameMap.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameMap.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lblGameMap.Location = new System.Drawing.Point(13, 13);
            this.lblGameMap.Name = "lblGameMap";
            this.lblGameMap.Size = new System.Drawing.Size(121, 22);
            this.lblGameMap.TabIndex = 0;
            this.lblGameMap.Text = "Click START";
            // 
            // btnStart
            // 
            this.btnStart.Image = ((System.Drawing.Image)(resources.GetObject("btnStart.Image")));
            this.btnStart.Location = new System.Drawing.Point(688, 46);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 25);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPause
            // 
            this.btnPause.Image = ((System.Drawing.Image)(resources.GetObject("btnPause.Image")));
            this.btnPause.Location = new System.Drawing.Point(688, 78);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(100, 25);
            this.btnPause.TabIndex = 2;
            this.btnPause.Text = "PAUSE";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // tmrGameTimer
            // 
            this.tmrGameTimer.Interval = 1000;
            this.tmrGameTimer.Tick += new System.EventHandler(this.tmrGameTimer_Tick);
            // 
            // lblGameCounter
            // 
            this.lblGameCounter.AutoSize = true;
            this.lblGameCounter.Location = new System.Drawing.Point(685, 26);
            this.lblGameCounter.Name = "lblGameCounter";
            this.lblGameCounter.Size = new System.Drawing.Size(55, 17);
            this.lblGameCounter.TabIndex = 3;
            this.lblGameCounter.Text = "Time: 0";
            // 
            // cmbUnitsStats
            // 
            this.cmbUnitsStats.FormattingEnabled = true;
            this.cmbUnitsStats.Location = new System.Drawing.Point(404, 109);
            this.cmbUnitsStats.Name = "cmbUnitsStats";
            this.cmbUnitsStats.Size = new System.Drawing.Size(384, 24);
            this.cmbUnitsStats.TabIndex = 4;
            this.cmbUnitsStats.Text = "Unit Stats";
            // 
            // lblOosorionResourcesCounter
            // 
            this.lblOosorionResourcesCounter.AutoSize = true;
            this.lblOosorionResourcesCounter.Location = new System.Drawing.Point(404, 26);
            this.lblOosorionResourcesCounter.Name = "lblOosorionResourcesCounter";
            this.lblOosorionResourcesCounter.Size = new System.Drawing.Size(154, 17);
            this.lblOosorionResourcesCounter.TabIndex = 5;
            this.lblOosorionResourcesCounter.Text = "Oosorion Resources: 0";
            // 
            // lblAsobaxianResourcesCounter
            // 
            this.lblAsobaxianResourcesCounter.AutoSize = true;
            this.lblAsobaxianResourcesCounter.Location = new System.Drawing.Point(404, 43);
            this.lblAsobaxianResourcesCounter.Name = "lblAsobaxianResourcesCounter";
            this.lblAsobaxianResourcesCounter.Size = new System.Drawing.Size(161, 17);
            this.lblAsobaxianResourcesCounter.TabIndex = 6;
            this.lblAsobaxianResourcesCounter.Text = "Asobaxian Resources: 0";
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(407, 79);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnLoad.Image")));
            this.btnLoad.Location = new System.Drawing.Point(488, 79);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 8;
            this.btnLoad.Text = "LOAD";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblAsobaxianResourcesCounter);
            this.Controls.Add(this.lblOosorionResourcesCounter);
            this.Controls.Add(this.cmbUnitsStats);
            this.Controls.Add(this.lblGameCounter);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblGameMap);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGameMap;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Timer tmrGameTimer;
        private System.Windows.Forms.Label lblGameCounter;
        private System.Windows.Forms.ComboBox cmbUnitsStats;
        private System.Windows.Forms.Label lblOosorionResourcesCounter;
        private System.Windows.Forms.Label lblAsobaxianResourcesCounter;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
    }
}

