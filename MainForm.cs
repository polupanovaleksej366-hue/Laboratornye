using System;
using System.Linq;
using System.Windows.Forms;
using BusinessObjects;
using Service;

namespace HospitalApp
{
    public partial class MainForm : Form
    {
        private static readonly IService _service = new Service.Service();
        private MedicalCard _currentCard;

        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
            btnAdmit.Click += btnAdmit_Click;
            btnLoadCard.Click += btnLoadCard_Click;
            btnAddAppt.Click += btnAddAppt_Click;
            btnComplete.Click += btnComplete_Click;
            btnDischarge.Click += btnDischarge_Click;
            cmbDepartment.SelectedIndexChanged += cmbDepartment_SelectedIndexChanged;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            cmbDepartment.DataSource = _service.GetDepartments();
            cmbDepartment.DisplayMember = "Name";

            cmbApptType.Items.AddRange(new object[]
            {
                AppointmentKind.Injection,
                AppointmentKind.Pills,
                AppointmentKind.Diagnostic
            });
            cmbApptType.SelectedIndex = 0;

            cmbNurse.DataSource = _service.GetNurses();
            cmbNurse.DisplayMember = "FullName";

            RefreshPatients();
        }

        private void RefreshPatients()
        {
            var patients = _service.GetPatients().ToList();
            cmbPatient.DataSource = null;
            cmbPatient.DataSource = patients;
            cmbPatient.DisplayMember = "ToString";
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDepartment.SelectedItem is Department dep)
            {
                cmbDoctor.DataSource = _service.GetDoctorsByDepartment(dep.Id);
                cmbDoctor.DisplayMember = "FullName";
            }
        }

        private void btnAdmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDepartment.SelectedItem is not Department dep || cmbDoctor.SelectedItem is not Doctor doc)
                {
                    MessageBox.Show("Выберите отделение и врача");
                    return;
                }

                var patient = new Patient
                {
                    FullName = txtFullName.Text.Trim(),
                    BirthDate = dtpBirth.Value,
                    DiagnosisOnAdmission = txtDiagnosis.Text.Trim()
                };

                var card = _service.AdmitPatient(patient, dep.Id, doc.Id);
                lblAdmitResult.Text = $"Пациент {patient.FullName} госпитализирован. ЭМК №{card.Id}";
                RefreshPatients();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoadCard_Click(object sender, EventArgs e)
        {
            if (cmbPatient.SelectedItem is not Patient p)
            {
                MessageBox.Show("Выберите пациента");
                return;
            }

            _currentCard = _service.GetActiveCard(p.Id);
            if (_currentCard == null)
            {
                MessageBox.Show("У пациента нет активной ЭМК");
                return;
            }

            lblCardInfo.Text = $"ЭМК №{_currentCard.Id}, поступил: {_currentCard.AdmissionDate:dd.MM.yyyy}";
            RefreshAppointments();
        }

        private void RefreshAppointments()
        {
            if (_currentCard == null) return;
            lstAppointments.DataSource = null;
            lstAppointments.DataSource = _service.GetAppointments(_currentCard.Id);
            lstAppointments.DisplayMember = "Description";
        }

        private void btnAddAppt_Click(object sender, EventArgs e)
        {
            if (_currentCard == null)
            {
                MessageBox.Show("Сначала загрузите ЭМК");
                return;
            }

            Appointment appt;
            var kind = (AppointmentKind)cmbApptType.SelectedItem;

            switch (kind)
            {
                case AppointmentKind.Injection:
                    appt = new InjectionAppointment { Quantity = (int)numQuantity.Value };
                    break;
                case AppointmentKind.Pills:
                    appt = new PillsAppointment { DosageMg = (double)numDosage.Value, Days = (int)numQuantity.Value };
                    break;
                default:
                    appt = new DiagnosticAppointment();
                    break;
            }

            appt.Description = txtApptDesc.Text.Trim();
            appt.MedicalCardId = _currentCard.Id;
            appt.DoctorId = _currentCard.AttendingDoctorId ?? 1;
            appt.AssignedDate = DateTime.Now;

            try
            {
                _service.AddAppointment(appt);
                RefreshAppointments();
                txtApptDesc.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (lstAppointments.SelectedItem is not Appointment appt)
            {
                MessageBox.Show("Выберите назначение в списке");
                return;
            }

            try
            {
                int? nurseId = null;
                if (appt.Kind != AppointmentKind.Diagnostic)
                {
                    if (cmbNurse.SelectedItem is not Nurse n)
                        throw new Exception("Для медикаментозного назначения выберите медсестру");
                    nurseId = n.Id;
                }

                _service.CompleteAppointment(appt, nurseId);
                RefreshAppointments();
                lblMessage.Text = $"Назначение «{appt.Description}» выполнено.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDischarge_Click(object sender, EventArgs e)
        {
            if (_currentCard == null)
            {
                MessageBox.Show("Сначала загрузите ЭМК");
                return;
            }

            try
            {
                var epicrisis = _service.DischargePatient(_currentCard.Id);
                txtEpicrisis.Text = epicrisis.BuildText();
                _currentCard = null;
                MessageBox.Show("Пациент выписан. Эпикриз сформирован.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void txtEpicrisis_TextChanged(object sender, EventArgs e) { }

        private void btnAdmit_Click_1(object sender, EventArgs e)
        {

        }
    }
}