namespace Academits.Dorosh.TemperatureTask.View
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.resultTemperatureTextBox = new System.Windows.Forms.TextBox();
            this.getResultButton = new System.Windows.Forms.Button();
            this.resultScaleListBox = new System.Windows.Forms.ListBox();
            this.currentScaleListBox = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.currentTemperatureTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(428, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.ExitToolStripMenuItem.Text = "Выход";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.resultTemperatureTextBox, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.getResultButton, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.resultScaleListBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.currentScaleListBox, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.currentTemperatureTextBox, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5, 1, 5, 1);
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(428, 338);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label2, 2);
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(8, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(412, 30);
            this.label2.TabIndex = 15;
            this.label2.Text = "Результат";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // resultTemperatureTextBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.resultTemperatureTextBox, 2);
            this.resultTemperatureTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultTemperatureTextBox.Enabled = false;
            this.resultTemperatureTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultTemperatureTextBox.Location = new System.Drawing.Point(8, 275);
            this.resultTemperatureTextBox.Name = "resultTemperatureTextBox";
            this.resultTemperatureTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.resultTemperatureTextBox.Size = new System.Drawing.Size(412, 38);
            this.resultTemperatureTextBox.TabIndex = 14;
            this.resultTemperatureTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // getResultButton
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.getResultButton, 2);
            this.getResultButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.getResultButton.Location = new System.Drawing.Point(5, 202);
            this.getResultButton.Margin = new System.Windows.Forms.Padding(0);
            this.getResultButton.Name = "getResultButton";
            this.getResultButton.Size = new System.Drawing.Size(418, 40);
            this.getResultButton.TabIndex = 13;
            this.getResultButton.Text = "Перевести";
            this.getResultButton.UseVisualStyleBackColor = true;
            this.getResultButton.Click += new System.EventHandler(this.getResultButton_Click);
            // 
            // resultScaleListBox
            // 
            this.resultScaleListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultScaleListBox.FormattingEnabled = true;
            this.resultScaleListBox.Location = new System.Drawing.Point(217, 105);
            this.resultScaleListBox.Name = "resultScaleListBox";
            this.resultScaleListBox.Size = new System.Drawing.Size(203, 94);
            this.resultScaleListBox.TabIndex = 12;
            this.resultScaleListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.currentTemperatureTextBox_KeyDown);
            // 
            // currentScaleListBox
            // 
            this.currentScaleListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentScaleListBox.FormattingEnabled = true;
            this.currentScaleListBox.Location = new System.Drawing.Point(8, 105);
            this.currentScaleListBox.Name = "currentScaleListBox";
            this.currentScaleListBox.Size = new System.Drawing.Size(203, 94);
            this.currentScaleListBox.TabIndex = 11;
            this.currentScaleListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.currentTemperatureTextBox_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(8, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(203, 30);
            this.label7.TabIndex = 10;
            this.label7.Text = "Исходная шкала";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(217, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(203, 30);
            this.label5.TabIndex = 9;
            this.label5.Text = "Шкала результата";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(8, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(412, 30);
            this.label1.TabIndex = 8;
            this.label1.Text = "Исходная температура";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentTemperatureTextBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.currentTemperatureTextBox, 2);
            this.currentTemperatureTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentTemperatureTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentTemperatureTextBox.Location = new System.Drawing.Point(8, 34);
            this.currentTemperatureTextBox.Name = "currentTemperatureTextBox";
            this.currentTemperatureTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.currentTemperatureTextBox.Size = new System.Drawing.Size(412, 38);
            this.currentTemperatureTextBox.TabIndex = 2;
            this.currentTemperatureTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.currentTemperatureTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.currentTemperatureTextBox_KeyDown);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 362);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(440, 400);
            this.Name = "MainForm";
            this.Text = "Перевод температур";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox resultTemperatureTextBox;
        private System.Windows.Forms.Button getResultButton;
        private System.Windows.Forms.ListBox resultScaleListBox;
        private System.Windows.Forms.ListBox currentScaleListBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox currentTemperatureTextBox;
        private System.Windows.Forms.Label label2;
    }
}

