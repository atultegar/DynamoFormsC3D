using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoFormsC3D
{
    public class Forms
    {
        //public static string SayHello(string Name)
        //{
        //    return "Hello " + Name + "!";
        //}

        /// <summary>
        /// Form with combobox for input 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        [STAThread]
        public static object FormComboBox(string title, List<object> list)
        {
            ComboBox comboBox = new ComboBox();

            comboBox.lbl_1.Content = string.Format("Select {0} from list", title);
            comboBox.cmbBox.ItemsSource = list;

            var res = comboBox.ShowDialog();
            if (!res.HasValue && res.Value)
                comboBox.Close();
            var idx = comboBox.cmbBox.SelectedIndex;
            return list[idx];
        }

        /// <summary>
        /// Form with List Box for inputs
        /// </summary>
        /// <param name="title"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        [STAThread]
        public static IList<object> FormListSelect(string title, List<object> list)
        {
            SelectionList selectionList = new SelectionList();

            selectionList.lbl_1.Content = string.Format("Select {0} from list", title);
            selectionList.lstBox.ItemsSource = list;

            var res = selectionList.ShowDialog();

            if (!res.HasValue && res.Value)
                selectionList.Close();

            IList<object> data = (IList<object>)selectionList.lstBox.SelectedItems;

            return data;
        }

        
        /// <summary>
        /// Form with Multiple Selections for input
        /// </summary>
        /// <param name="title"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        [STAThread]
        public static IList<object> FormMultiSelect(string title, IList<object> list)
        {
            IList<object> output = new List<object>();

            MultiSelect multiSelect = new MultiSelect();

            multiSelect.tb_1.Text = string.Format("Select {0} from list box", title);

            for (int i =0; i < list.Count; i++)
            {
                multiSelect.lstUnselected.Items.Add(list[i]);
            }

            var res = multiSelect.ShowDialog();

            if (!res.HasValue && res.Value)
                multiSelect.Close();

            for (int j=0; j < multiSelect.lstSelected.Items.Count; j++)
            {
                output.Add(multiSelect.lstSelected.Items[j]);
            }

            return output;
        }
    }
}
