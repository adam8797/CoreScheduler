using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CoreScheduler.Client.Desktop.Utilities;

namespace CoreScheduler.Client.Desktop.Controls
{
    public partial class EditableList : UserControl
    {
        private bool _allowSort;
        private ListMode _mode;
        private List<object> _options;

        public Func<IEnumerable<object>> DataSource;

        //public Func<object, string> Formatter;

        public EditableList()
        {
            InitializeComponent();
            Mode = ListMode.TextBox;
            AllowSort = false;

            btnMoveUp.Image = ImageListBuilder.Create("shell32.dll").ExtractBitmap(246);
            btnMoveDown.Image = ImageListBuilder.Create("shell32.dll").ExtractBitmap(247);

        }

        public ListMode Mode
        {
            get { return _mode; }
            set
            {
                switch (value)
                {
                    case ListMode.TextBox:
                        txtAdd.Visible = true;
                        comboBox.Visible = false;
                        break;
                    case ListMode.DropDown:
                        txtAdd.Visible = false;
                        comboBox.Visible = true;
                        comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                        break;
                    case ListMode.ComboBox:
                        txtAdd.Visible = false;
                        comboBox.Visible = true;
                        comboBox.DropDownStyle = ComboBoxStyle.DropDown;
                        break;
                }
                _mode = value;
            }
        }

        public bool AllowSort
        {
            get { return _allowSort; }
            set
            {
                btnMoveDown.Visible = value;
                btnMoveUp.Visible = value;
                _allowSort = value;
            }
        }

        [Editor(@"System.Windows.Forms.Design.StringCollectionEditor," +
                "System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
             typeof(System.Drawing.Design.UITypeEditor))]
        public List<object> Options
        {
            get
            {
                if (_options == null)
                    _options = new List<object>();
                return _options;
            }
            set { _options = value; }
        }

        public void LoadItems(params object[] items)
        {
            list.Items.AddRange(items);
        }

        public List<object> GetItems()
        {
            return list.Items.Cast<object>().ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Mode == ListMode.TextBox && !string.IsNullOrEmpty(txtAdd.Text.Trim()))
            {
                list.Items.Add(txtAdd.Text);
                txtAdd.Text = "";
            }
            else if (!string.IsNullOrEmpty(comboBox.Text.Trim()))
            {
                var value = comboBox.SelectedItem ?? comboBox.Text;
                if (!list.Items.Contains(value))
                {
                    list.Items.Add(value);
                    comboBox.SelectedItem = null;
                    if (Mode == ListMode.ComboBox)
                        comboBox.Text = "";
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (list.SelectedIndex == -1)
            {
                if (list.Items.Count > 0)
                    list.Items.RemoveAt(0);
            }
            else
                list.Items.RemoveAt(list.SelectedIndex);
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            MoveItem(-1);
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            MoveItem(1);
        }

        private void comboBox_DropDown(object sender, EventArgs e)
        {
            comboBox.Items.Clear();

            object[] source;
            if (DataSource != null)
                source = DataSource().ToArray();
            else
                source = Options.ToArray();

            comboBox.Items.AddRange(source);
        }

        public void MoveItem(int direction)
        {
            // Checking selected item
            if (list.SelectedItem == null || list.SelectedIndex < 0)
                return; // No selected item - nothing to do

            // Calculate new index using move direction
            int newIndex = list.SelectedIndex + direction;

            // Checking bounds of the range
            if (newIndex < 0 || newIndex >= list.Items.Count)
                return; // Index out of range - nothing to do

            object selected = list.SelectedItem;

            // Removing removable element
            list.Items.Remove(selected);
            // Insert it in new position
            list.Items.Insert(newIndex, selected);
            // Restore selection
            list.SetSelected(newIndex, true);
        }

        private void comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            btnAdd_Click(null, null);
        }
    }

    public enum ListMode
    {
        TextBox,
        DropDown,
        ComboBox
    }
}
