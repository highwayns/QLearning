using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLearning.FrontEnd
{
    public partial class QTableForm : Form
    {
        #region Private Fields

        ScreenManager _screenManager;
 
        #endregion

        public QTableForm(ScreenManager screenManager)
        {
            this._screenManager = screenManager;
            InitializeComponent();
        }

        private void QTableDisplay_Load(object sender, EventArgs e)
        {
            var dataTable = new DataTable();
            this.PopulateTable(dataTable);
            this.dataGridView1.DataSource = dataTable;
        }

        private void PopulateTable(DataTable table)
        {
            table.Columns.Add("Estado", typeof(string));
            table.Columns.Add("Ação", typeof(string));
            table.Columns.Add("Recompensa", typeof(string));
            
            var algorithm = _screenManager.Algorithm;
            
            if(algorithm == null) return;
            
            var qTable = algorithm.QTable;
            
            foreach (var movement in qTable)
            {
                var dataRow = table.NewRow();
                dataRow["Estado"] = movement.State.Index.ToString();
                dataRow["Ação"] = movement.Action.ToString();
                dataRow["Recompensa"] = movement.Reward.ToString();
                table.Rows.Add(dataRow);
            }
        }
    }
}
