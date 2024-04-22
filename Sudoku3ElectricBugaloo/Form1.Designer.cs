namespace Sudoku5OSudokuer
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.bttn_Refresh = new System.Windows.Forms.Button();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.tblLytPnl_Table = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // bttn_Refresh
            // 
            this.bttn_Refresh.Location = new System.Drawing.Point(263, 485);
            this.bttn_Refresh.Name = "bttn_Refresh";
            this.bttn_Refresh.Size = new System.Drawing.Size(105, 32);
            this.bttn_Refresh.TabIndex = 19;
            this.bttn_Refresh.Text = "Reinicar Jogo";
            this.bttn_Refresh.UseVisualStyleBackColor = true;
            this.bttn_Refresh.Click += new System.EventHandler(this.bttn_Refresh_Click);
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("Segoe UI Historic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.ForeColor = System.Drawing.Color.Red;
            this.lbl_Title.Location = new System.Drawing.Point(256, 5);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(112, 37);
            this.lbl_Title.TabIndex = 15;
            this.lbl_Title.Text = "Sudoku";
            // 
            // tblLytPnl_Table
            // 
            this.tblLytPnl_Table.AutoScroll = true;
            this.tblLytPnl_Table.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblLytPnl_Table.ColumnCount = 3;
            this.tblLytPnl_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblLytPnl_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblLytPnl_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblLytPnl_Table.Location = new System.Drawing.Point(12, 45);
            this.tblLytPnl_Table.Name = "tblLytPnl_Table";
            this.tblLytPnl_Table.RowCount = 3;
            this.tblLytPnl_Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblLytPnl_Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblLytPnl_Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblLytPnl_Table.Size = new System.Drawing.Size(602, 434);
            this.tblLytPnl_Table.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 523);
            this.Controls.Add(this.tblLytPnl_Table);
            this.Controls.Add(this.bttn_Refresh);
            this.Controls.Add(this.lbl_Title);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sudoku =]";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bttn_Refresh;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.TableLayoutPanel tblLytPnl_Table;
    }
}

