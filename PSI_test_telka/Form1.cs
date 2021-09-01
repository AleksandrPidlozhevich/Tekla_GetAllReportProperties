using System;
using System.Windows.Forms;
using Tekla.Structures.Model.UI;
using Tekla.Structures.Model;
using System.Collections.Generic;
using System.Collections;

namespace PSI_test_telka
{
    public partial class ReportPropertiesForm : Form
    {
        private Part _part;
        Model model;
        public ReportPropertiesForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Model _model = new Model();
            if (_model.GetConnectionStatus())
            {
                model = _model;
                lbl_connection.Text = "Есть соединени";
            }
            else
            {
                lbl_connection.Text = "Нет соединени";
            }
        }
        private void elem_tanlang_Click(object sender, EventArgs e)
        {
            ArrayList sNames = new ArrayList();
            sNames.Add("NAME");
            sNames.Add("SCREW_NAME");
            sNames.Add("SCREW_TYPE");
            sNames.Add("TYPE");
            sNames.Add("TYPE1");
            sNames.Add("TYPE2");
            sNames.Add("TYPE3");
            sNames.Add("TYPE4");
            sNames.Add("STANDARD");
            sNames.Add("SHORT_NAME");
            sNames.Add("MATERIAL");
            sNames.Add("FINISH");
            sNames.Add("GRADE");
            ArrayList iNames = new ArrayList();
            iNames.Add("DATE");
            iNames.Add("FATHER_ID");
            iNames.Add("GROUP_ID");
            iNames.Add("HIERARCHY_LEVEL");
            iNames.Add("MODEL_TOTAL");
            ArrayList dNames = new ArrayList();
            dNames.Add("EXTRA_LENGTH");
            dNames.Add("FLANGE_THICKNESS");
            dNames.Add("FLANGE_WIDTH");
            dNames.Add("HEIGHT");
            dNames.Add("LENGTH");
            dNames.Add("PRIMARYWEIGHT");
            dNames.Add("PROFILE_WEIGHT");
            dNames.Add("ROUNDING_RADIUS");
            dNames.Add("LENGTH");
            dNames.Add("DIAMETER");
            dNames.Add("WEIGHT");
            dNames.Add("HEAD_DIAMETER");
            dNames.Add("THICKNESS");
            dNames.Add("WASHER.THICKNESS");
            dNames.Add("WASHER.INNER_DIAMETER");
            dNames.Add("WASHER.OUTER_DIAMETER");
            dNames.Add("WASHER.THICKNESS1");
            dNames.Add("WASHER.INNER_DIAMETER1");
            dNames.Add("WASHER.OUTER_DIAMETER1");
            dNames.Add("WASHER.THICKNESS2");
            dNames.Add("WASHER.INNER_DIAMETER2");
            dNames.Add("WASHER.OUTER_DIAMETER2");
            dNames.Add("NUT.THICKNESS");
            dNames.Add("NUT.INNER_DIAMETER");
            dNames.Add("NUT.OUTER_DIAMETER");
            dNames.Add("NUT.THICKNESS2");
            dNames.Add("NUT.OUTER_DIAMETER2");
            try
            {
                var picker = new Picker();
                _part = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART) as Part;
                lbl_ID.Text = _part.Identifier.ID.ToString();
                Hashtable sValues = new Hashtable(sNames.Count + dNames.Count + iNames.Count);
                if (_part.GetAllReportProperties(sNames, dNames, iNames, ref sValues))
                {
                    string a = "";
                    foreach (DictionaryEntry value in sValues)
                    {
                        a += $"{value.Key}: {value.Value}\n";
                    }
                    label5.Text = a;
                }
            }
            catch (Exception)
            {
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}