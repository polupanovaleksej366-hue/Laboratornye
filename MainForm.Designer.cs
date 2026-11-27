namespace HospitalApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            lblAdmitResult = new Label();
            btnAdmit = new Button();
            cmbDoctor = new ComboBox();
            label5 = new Label();
            cmbDepartment = new ComboBox();
            label4 = new Label();
            txtDiagnosis = new TextBox();
            label3 = new Label();
            dtpBirth = new DateTimePicker();
            label2 = new Label();
            txtFullName = new TextBox();
            label1 = new Label();
            tabPage2 = new TabPage();
            lblMessage = new Label();
            btnComplete = new Button();
            cmbNurse = new ComboBox();
            label11 = new Label();
            lstAppointments = new ListBox();
            btnAddAppt = new Button();
            numDosage = new NumericUpDown();
            label10 = new Label();
            numQuantity = new NumericUpDown();
            label9 = new Label();
            txtApptDesc = new TextBox();
            label8 = new Label();
            cmbApptType = new ComboBox();
            label7 = new Label();
            lblCardInfo = new Label();
            btnLoadCard = new Button();
            cmbPatient = new ComboBox();
            label6 = new Label();
            tabPage3 = new TabPage();
            txtEpicrisis = new TextBox();
            btnDischarge = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDosage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(860, 413);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(lblAdmitResult);
            tabPage1.Controls.Add(btnAdmit);
            tabPage1.Controls.Add(cmbDoctor);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(cmbDepartment);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(txtDiagnosis);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(dtpBirth);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(txtFullName);
            tabPage1.Controls.Add(label1);
            tabPage1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabPage1.ForeColor = SystemColors.ControlDarkDark;
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.RightToLeft = RightToLeft.No;
            tabPage1.Size = new Size(852, 380);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Госпитализация";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Click += tabPage1_Click;
            // 
            // lblAdmitResult
            // 
            lblAdmitResult.AutoSize = true;
            lblAdmitResult.Location = new Point(8, 286);
            lblAdmitResult.Name = "lblAdmitResult";
            lblAdmitResult.Size = new Size(0, 20);
            lblAdmitResult.TabIndex = 11;
            // 
            // btnAdmit
            // 
            btnAdmit.BackColor = Color.Ivory;
            btnAdmit.Font = new Font("Snap ITC", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdmit.ForeColor = SystemColors.ActiveCaptionText;
            btnAdmit.Location = new Point(119, 230);
            btnAdmit.Name = "btnAdmit";
            btnAdmit.Size = new Size(157, 29);
            btnAdmit.TabIndex = 10;
            btnAdmit.Text = "Госпитализировать";
            btnAdmit.UseVisualStyleBackColor = false;
            btnAdmit.Click += btnAdmit_Click_1;
            // 
            // cmbDoctor
            // 
            cmbDoctor.FormattingEnabled = true;
            cmbDoctor.Location = new Point(234, 185);
            cmbDoctor.Name = "cmbDoctor";
            cmbDoctor.Size = new Size(444, 28);
            cmbDoctor.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(49, 188);
            label5.Name = "label5";
            label5.Size = new Size(113, 20);
            label5.TabIndex = 8;
            label5.Text = "Лечащий врач:";
            // 
            // cmbDepartment
            // 
            cmbDepartment.FormattingEnabled = true;
            cmbDepartment.Location = new Point(234, 149);
            cmbDepartment.Name = "cmbDepartment";
            cmbDepartment.Size = new Size(444, 28);
            cmbDepartment.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(46, 152);
            label4.Name = "label4";
            label4.Size = new Size(87, 20);
            label4.TabIndex = 6;
            label4.Text = "Отделение:";
            // 
            // txtDiagnosis
            // 
            txtDiagnosis.Location = new Point(246, 109);
            txtDiagnosis.Name = "txtDiagnosis";
            txtDiagnosis.Size = new Size(432, 27);
            txtDiagnosis.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 112);
            label3.Name = "label3";
            label3.Size = new Size(195, 20);
            label3.TabIndex = 4;
            label3.Text = "Диагноз при поступлении:";
            // 
            // dtpBirth
            // 
            dtpBirth.CalendarMonthBackground = SystemColors.Highlight;
            dtpBirth.Location = new Point(234, 71);
            dtpBirth.Name = "dtpBirth";
            dtpBirth.Size = new Size(250, 27);
            dtpBirth.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 76);
            label2.Name = "label2";
            label2.Size = new Size(119, 20);
            label2.TabIndex = 2;
            label2.Text = "Дата рождения:";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(246, 35);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(432, 27);
            txtFullName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 38);
            label1.Name = "label1";
            label1.Size = new Size(115, 20);
            label1.TabIndex = 0;
            label1.Text = "ФИО пациента:";
            label1.Click += label1_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(lblMessage);
            tabPage2.Controls.Add(btnComplete);
            tabPage2.Controls.Add(cmbNurse);
            tabPage2.Controls.Add(label11);
            tabPage2.Controls.Add(lstAppointments);
            tabPage2.Controls.Add(btnAddAppt);
            tabPage2.Controls.Add(numDosage);
            tabPage2.Controls.Add(label10);
            tabPage2.Controls.Add(numQuantity);
            tabPage2.Controls.Add(label9);
            tabPage2.Controls.Add(txtApptDesc);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(cmbApptType);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(lblCardInfo);
            tabPage2.Controls.Add(btnLoadCard);
            tabPage2.Controls.Add(cmbPatient);
            tabPage2.Controls.Add(label6);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(852, 380);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "ЭМК и назначения";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(447, 345);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(24, 20);
            lblMessage.TabIndex = 17;
            lblMessage.Text = "—";
            // 
            // btnComplete
            // 
            btnComplete.Location = new Point(465, 300);
            btnComplete.Name = "btnComplete";
            btnComplete.Size = new Size(222, 29);
            btnComplete.TabIndex = 16;
            btnComplete.Text = "Отметить выполненным";
            btnComplete.UseVisualStyleBackColor = true;
            // 
            // cmbNurse
            // 
            cmbNurse.FormattingEnabled = true;
            cmbNurse.Location = new Point(599, 239);
            cmbNurse.Name = "cmbNurse";
            cmbNurse.Size = new Size(245, 28);
            cmbNurse.TabIndex = 15;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(425, 242);
            label11.Name = "label11";
            label11.Size = new Size(168, 20);
            label11.TabIndex = 14;
            label11.Text = "Выполнила медсестра:";
            // 
            // lstAppointments
            // 
            lstAppointments.BackColor = SystemColors.HighlightText;
            lstAppointments.FormattingEnabled = true;
            lstAppointments.Location = new Point(8, 221);
            lstAppointments.Name = "lstAppointments";
            lstAppointments.Size = new Size(401, 144);
            lstAppointments.TabIndex = 13;
            // 
            // btnAddAppt
            // 
            btnAddAppt.Location = new Point(325, 190);
            btnAddAppt.Name = "btnAddAppt";
            btnAddAppt.Size = new Size(174, 29);
            btnAddAppt.TabIndex = 12;
            btnAddAppt.Text = "Добавить назначение";
            btnAddAppt.UseVisualStyleBackColor = true;
            // 
            // numDosage
            // 
            numDosage.Location = new Point(133, 188);
            numDosage.Name = "numDosage";
            numDosage.Size = new Size(150, 27);
            numDosage.TabIndex = 11;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(8, 190);
            label10.Name = "label10";
            label10.Size = new Size(119, 20);
            label10.TabIndex = 10;
            label10.Text = "Дозировка (мг):";
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(113, 156);
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(150, 27);
            numQuantity.TabIndex = 9;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(8, 158);
            label9.Name = "label9";
            label9.Size = new Size(99, 20);
            label9.TabIndex = 8;
            label9.Text = "Кол-во дней:";
            // 
            // txtApptDesc
            // 
            txtApptDesc.Location = new Point(133, 124);
            txtApptDesc.Name = "txtApptDesc";
            txtApptDesc.Size = new Size(521, 27);
            txtApptDesc.TabIndex = 7;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(8, 127);
            label8.Name = "label8";
            label8.Size = new Size(82, 20);
            label8.TabIndex = 6;
            label8.Text = "Описание:";
            // 
            // cmbApptType
            // 
            cmbApptType.FormattingEnabled = true;
            cmbApptType.Location = new Point(149, 89);
            cmbApptType.Name = "cmbApptType";
            cmbApptType.Size = new Size(151, 28);
            cmbApptType.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(8, 92);
            label7.Name = "label7";
            label7.Size = new Size(125, 20);
            label7.TabIndex = 4;
            label7.Text = "Тип назначения:";
            // 
            // lblCardInfo
            // 
            lblCardInfo.AutoSize = true;
            lblCardInfo.Location = new Point(8, 53);
            lblCardInfo.Name = "lblCardInfo";
            lblCardInfo.Size = new Size(138, 20);
            lblCardInfo.TabIndex = 3;
            lblCardInfo.Text = "ЭМК не загружена";
            // 
            // btnLoadCard
            // 
            btnLoadCard.FlatStyle = FlatStyle.Popup;
            btnLoadCard.ForeColor = SystemColors.ActiveCaptionText;
            btnLoadCard.Location = new Point(532, 8);
            btnLoadCard.Name = "btnLoadCard";
            btnLoadCard.Size = new Size(155, 29);
            btnLoadCard.TabIndex = 2;
            btnLoadCard.Text = "Загрузить карту";
            btnLoadCard.UseVisualStyleBackColor = true;
            // 
            // cmbPatient
            // 
            cmbPatient.FormattingEnabled = true;
            cmbPatient.Location = new Point(107, 9);
            cmbPatient.Name = "cmbPatient";
            cmbPatient.Size = new Size(407, 28);
            cmbPatient.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(8, 12);
            label6.Name = "label6";
            label6.Size = new Size(72, 20);
            label6.TabIndex = 0;
            label6.Text = "Пациент:";
            label6.Click += label6_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(txtEpicrisis);
            tabPage3.Controls.Add(btnDischarge);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(852, 380);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Выписка";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtEpicrisis
            // 
            txtEpicrisis.Location = new Point(0, 109);
            txtEpicrisis.Multiline = true;
            txtEpicrisis.Name = "txtEpicrisis";
            txtEpicrisis.ReadOnly = true;
            txtEpicrisis.ScrollBars = ScrollBars.Vertical;
            txtEpicrisis.Size = new Size(852, 271);
            txtEpicrisis.TabIndex = 1;
            txtEpicrisis.TextChanged += txtEpicrisis_TextChanged;
            // 
            // btnDischarge
            // 
            btnDischarge.Location = new Point(19, 17);
            btnDischarge.Name = "btnDischarge";
            btnDischarge.Size = new Size(288, 86);
            btnDischarge.TabIndex = 0;
            btnDischarge.Text = "Выписать пациента";
            btnDischarge.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(860, 413);
            Controls.Add(tabControl1);
            Name = "MainForm";
            Text = "Form1";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDosage).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label1;
        private TabPage tabPage3;
        private DateTimePicker dtpBirth;
        private Label label2;
        private TextBox txtFullName;
        private Button btnAdmit;
        private ComboBox cmbDoctor;
        private Label label5;
        private ComboBox cmbDepartment;
        private Label label4;
        private TextBox txtDiagnosis;
        private Label label3;
        private Label lblAdmitResult;
        private Label label6;
        private ComboBox cmbPatient;
        private Label label10;
        private NumericUpDown numQuantity;
        private Label label9;
        private TextBox txtApptDesc;
        private Label label8;
        private ComboBox cmbApptType;
        private Label label7;
        private Label lblCardInfo;
        private Button btnLoadCard;
        private ListBox lstAppointments;
        private Button btnAddAppt;
        private NumericUpDown numDosage;
        private Label label11;
        private Label lblMessage;
        private Button btnComplete;
        private ComboBox cmbNurse;
        private TextBox txtEpicrisis;
        private Button btnDischarge;
    }
}
