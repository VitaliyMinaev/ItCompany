namespace ItCompany.UI;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.state3Button = new System.Windows.Forms.Button();
            this.state2Button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.actionsListBox = new System.Windows.Forms.ListBox();
            this.clientsListBox = new System.Windows.Forms.ListBox();
            this.companiesListBox = new System.Windows.Forms.ListBox();
            this.projectsListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.loadDataButton = new System.Windows.Forms.Button();
            this.state1Button = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.departmentsListBox = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Actions";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.state3Button);
            this.panel1.Controls.Add(this.state2Button);
            this.panel1.Location = new System.Drawing.Point(406, 483);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 93);
            this.panel1.TabIndex = 2;
            // 
            // state3Button
            // 
            this.state3Button.Location = new System.Drawing.Point(3, 46);
            this.state3Button.Name = "state3Button";
            this.state3Button.Size = new System.Drawing.Size(280, 35);
            this.state3Button.TabIndex = 2;
            this.state3Button.Text = "Add new client (State #3)";
            this.state3Button.UseVisualStyleBackColor = true;
            // 
            // state2Button
            // 
            this.state2Button.Location = new System.Drawing.Point(3, 5);
            this.state2Button.Name = "state2Button";
            this.state2Button.Size = new System.Drawing.Size(280, 35);
            this.state2Button.TabIndex = 1;
            this.state2Button.Text = "Add random projects (State #2)";
            this.state2Button.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(406, 460);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Operations";
            // 
            // actionsListBox
            // 
            this.actionsListBox.FormattingEnabled = true;
            this.actionsListBox.ItemHeight = 20;
            this.actionsListBox.Location = new System.Drawing.Point(12, 32);
            this.actionsListBox.Name = "actionsListBox";
            this.actionsListBox.Size = new System.Drawing.Size(385, 544);
            this.actionsListBox.TabIndex = 4;
            // 
            // clientsListBox
            // 
            this.clientsListBox.FormattingEnabled = true;
            this.clientsListBox.ItemHeight = 20;
            this.clientsListBox.Location = new System.Drawing.Point(406, 32);
            this.clientsListBox.Name = "clientsListBox";
            this.clientsListBox.Size = new System.Drawing.Size(142, 404);
            this.clientsListBox.TabIndex = 5;
            this.clientsListBox.SelectedIndexChanged += new System.EventHandler(this.clientsListBox_SelectedIndexChanged);
            // 
            // companiesListBox
            // 
            this.companiesListBox.FormattingEnabled = true;
            this.companiesListBox.ItemHeight = 20;
            this.companiesListBox.Location = new System.Drawing.Point(702, 32);
            this.companiesListBox.Name = "companiesListBox";
            this.companiesListBox.Size = new System.Drawing.Size(142, 264);
            this.companiesListBox.TabIndex = 6;
            // 
            // projectsListBox
            // 
            this.projectsListBox.FormattingEnabled = true;
            this.projectsListBox.ItemHeight = 20;
            this.projectsListBox.Location = new System.Drawing.Point(554, 32);
            this.projectsListBox.Name = "projectsListBox";
            this.projectsListBox.Size = new System.Drawing.Size(142, 404);
            this.projectsListBox.TabIndex = 7;
            this.projectsListBox.SelectedIndexChanged += new System.EventHandler(this.projectsListBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(406, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Clients";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(702, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Companies";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(554, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Projects";
            // 
            // loadDataButton
            // 
            this.loadDataButton.Location = new System.Drawing.Point(554, 442);
            this.loadDataButton.Name = "loadDataButton";
            this.loadDataButton.Size = new System.Drawing.Size(142, 35);
            this.loadDataButton.TabIndex = 1;
            this.loadDataButton.Text = "Load data";
            this.loadDataButton.UseVisualStyleBackColor = true;
            this.loadDataButton.Click += new System.EventHandler(this.loadDataButton_Click);
            // 
            // state1Button
            // 
            this.state1Button.Location = new System.Drawing.Point(12, 580);
            this.state1Button.Name = "state1Button";
            this.state1Button.Size = new System.Drawing.Size(231, 35);
            this.state1Button.TabIndex = 11;
            this.state1Button.Text = "Start process (State #1)";
            this.state1Button.UseVisualStyleBackColor = true;
            this.state1Button.Click += new System.EventHandler(this.state1Button_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(702, 309);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Departments";
            // 
            // departmentsListBox
            // 
            this.departmentsListBox.FormattingEnabled = true;
            this.departmentsListBox.ItemHeight = 20;
            this.departmentsListBox.Location = new System.Drawing.Point(702, 332);
            this.departmentsListBox.Name = "departmentsListBox";
            this.departmentsListBox.Size = new System.Drawing.Size(142, 244);
            this.departmentsListBox.TabIndex = 12;
            this.departmentsListBox.SelectedIndexChanged += new System.EventHandler(this.departmentsListBox_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 621);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.departmentsListBox);
            this.Controls.Add(this.state1Button);
            this.Controls.Add(this.loadDataButton);
            this.Controls.Add(this.clientsListBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.projectsListBox);
            this.Controls.Add(this.companiesListBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.actionsListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Main form";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private Label label1;
    private Panel panel1;
    private Label label2;
    private ListBox actionsListBox;
    private ListBox clientsListBox;
    private ListBox companiesListBox;
    private ListBox projectsListBox;
    private Label label3;
    private Label label4;
    private Label label5;
    private Button loadDataButton;
    private Button state1Button;
    private Button state3Button;
    private Button state2Button;
    private Label label6;
    private ListBox departmentsListBox;
}