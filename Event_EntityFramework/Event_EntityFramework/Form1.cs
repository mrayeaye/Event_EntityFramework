using Event_EntityFramework.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Event_EntityFramework
{
    public partial class Form1 : Form
    {
        private EventDBContext eventcontext;
        public Form1()
        {
            InitializeComponent();
            eventcontext = new EventDBContext();
            refreshData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void refreshData()
        {
            BindingSource bi = new BindingSource();
            var query = from e in eventcontext.Events
                        select new {e.Id,e.Name, e.Date };
            bi.DataSource = query.ToList();
            dataGridView1.DataSource = bi;
            dataGridView1.Refresh();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            var newEvent = new Model.Event
            {
                Name = Ename.Text,
                Date = Edate.Value + ""
            };
            eventcontext.Events.Add(newEvent);
            eventcontext.SaveChanges();
            refreshData();
        }

        private void button3_Click(object sender, EventArgs e)
        {           
                    
                    var E = eventcontext.Events.Find((int) dataGridView1.SelectedCells[0].Value);
                    eventcontext.Events.Remove(E);
                    eventcontext.SaveChanges();
                    refreshData();
                
            
            
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
