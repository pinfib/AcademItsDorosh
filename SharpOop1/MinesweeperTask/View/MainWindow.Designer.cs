namespace Academits.Dorosh.MinesweeperTask.View
{
    partial class MainWindow
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
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.играToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.списокЛидеровToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InfoTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.gameTimerLabel = new System.Windows.Forms.Label();
            this.bombsCounterLabel = new System.Windows.Forms.Label();
            this.startNewGameButton = new System.Windows.Forms.Button();
            this.gameFieldPanel = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.InfoTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.играToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(234, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            // 
            // играToolStripMenuItem
            // 
            this.играToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.списокЛидеровToolStripMenuItem});
            this.играToolStripMenuItem.Name = "играToolStripMenuItem";
            this.играToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.играToolStripMenuItem.Text = "Игра";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
            this.toolStripMenuItem1.Text = "Уровень сложности";
            // 
            // списокЛидеровToolStripMenuItem
            // 
            this.списокЛидеровToolStripMenuItem.Name = "списокЛидеровToolStripMenuItem";
            this.списокЛидеровToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.списокЛидеровToolStripMenuItem.Text = "Список лидеров";
            // 
            // InfoTableLayoutPanel
            // 
            this.InfoTableLayoutPanel.ColumnCount = 3;
            this.InfoTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.InfoTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.InfoTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.InfoTableLayoutPanel.Controls.Add(this.gameTimerLabel, 2, 0);
            this.InfoTableLayoutPanel.Controls.Add(this.bombsCounterLabel, 0, 0);
            this.InfoTableLayoutPanel.Controls.Add(this.startNewGameButton, 1, 0);
            this.InfoTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.InfoTableLayoutPanel.Location = new System.Drawing.Point(0, 24);
            this.InfoTableLayoutPanel.MinimumSize = new System.Drawing.Size(70, 0);
            this.InfoTableLayoutPanel.Name = "InfoTableLayoutPanel";
            this.InfoTableLayoutPanel.RowCount = 1;
            this.InfoTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.InfoTableLayoutPanel.Size = new System.Drawing.Size(234, 70);
            this.InfoTableLayoutPanel.TabIndex = 1;
            // 
            // gameTimerLabel
            // 
            this.gameTimerLabel.AutoSize = true;
            this.gameTimerLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gameTimerLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameTimerLabel.Location = new System.Drawing.Point(158, 20);
            this.gameTimerLabel.Margin = new System.Windows.Forms.Padding(3, 20, 3, 20);
            this.gameTimerLabel.Name = "gameTimerLabel";
            this.gameTimerLabel.Size = new System.Drawing.Size(73, 30);
            this.gameTimerLabel.TabIndex = 3;
            this.gameTimerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bombsCounterLabel
            // 
            this.bombsCounterLabel.AutoSize = true;
            this.bombsCounterLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bombsCounterLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bombsCounterLabel.Location = new System.Drawing.Point(3, 20);
            this.bombsCounterLabel.Margin = new System.Windows.Forms.Padding(3, 20, 3, 20);
            this.bombsCounterLabel.Name = "bombsCounterLabel";
            this.bombsCounterLabel.Size = new System.Drawing.Size(71, 30);
            this.bombsCounterLabel.TabIndex = 0;
            this.bombsCounterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startNewGameButton
            // 
            this.startNewGameButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startNewGameButton.Location = new System.Drawing.Point(84, 7);
            this.startNewGameButton.Margin = new System.Windows.Forms.Padding(7);
            this.startNewGameButton.Name = "startNewGameButton";
            this.startNewGameButton.Size = new System.Drawing.Size(64, 56);
            this.startNewGameButton.TabIndex = 2;
            this.startNewGameButton.Text = "Start";
            this.startNewGameButton.UseVisualStyleBackColor = true;
            // 
            // gameFieldPanel
            // 
            this.gameFieldPanel.AutoSize = true;
            this.gameFieldPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gameFieldPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameFieldPanel.Location = new System.Drawing.Point(0, 94);
            this.gameFieldPanel.Margin = new System.Windows.Forms.Padding(0);
            this.gameFieldPanel.MinimumSize = new System.Drawing.Size(0, 50);
            this.gameFieldPanel.Name = "gameFieldPanel";
            this.gameFieldPanel.Size = new System.Drawing.Size(234, 61);
            this.gameFieldPanel.TabIndex = 2;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(234, 155);
            this.Controls.Add(this.gameFieldPanel);
            this.Controls.Add(this.InfoTableLayoutPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(250, 150);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.InfoTableLayoutPanel.ResumeLayout(false);
            this.InfoTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem играToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem списокЛидеровToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel InfoTableLayoutPanel;
        private System.Windows.Forms.Label gameTimerLabel;
        private System.Windows.Forms.Label bombsCounterLabel;
        private System.Windows.Forms.Button startNewGameButton;
        private System.Windows.Forms.Panel gameFieldPanel;
    }
}

