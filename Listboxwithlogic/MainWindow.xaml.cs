using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Listboxwithlogic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<TodoItem> items = new List<TodoItem>();
        public MainWindow()
        {
            InitializeComponent();
            items.Add(new TodoItem(){ Title = "Complete this WPF tutorial",Completion = 45});
            items.Add(new TodoItem() { Title = "Learn C#", Completion = 80 });
            items.Add(new TodoItem() { Title = "Wash the car", Completion = 1 });

            lbTodoList.ItemsSource = items;
        }



        public class TodoItem
        {
            public int Completion { get; set; }
            public string Title { get; set; }

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(txtItem.Text == "" || txtCompletion.Text == "")
            {
                MessageBox.Show("Enter an input!");
                return;
            }
            lbTodoList.ItemsSource = null;
            items.Add(new TodoItem() { Title = txtItem.Text, Completion = Convert.ToInt32(txtCompletion.Text) });
            lbTodoList.ItemsSource = items;

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(lbTodoList.SelectedIndex == -1)
            {
                MessageBox.Show("Select an Item to delete");
                return;
            }
            
            int index = lbTodoList.SelectedIndex;
            lbTodoList.ItemsSource = null;
            items.RemoveAt(index);
            lbTodoList.ItemsSource = items;

        }

        private void btnRepeat_Click(object sender, RoutedEventArgs e)
        {
            foreach(TodoItem ti in lbTodoList.SelectedItems)
            {
                MessageBox.Show(ti.Title);
            }
        }

        private void btnC_Click(object sender, RoutedEventArgs e)
        {
            lbTodoList.SelectedItems.Clear();
            foreach (TodoItem x in lbTodoList.Items)
                if (x.Title.Contains("C#")){
                    lbTodoList.SelectedItems.Add(x);
                }
        }

        private void btnAll_Click(object sender, RoutedEventArgs e)
        {
            lbTodoList.SelectedItems.Clear();
            lbTodoList.SelectAll();
            
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            
            if (lbTodoList.SelectedIndex < lbTodoList.Items.Count - 1)
            {
                lbTodoList.SelectedIndex = lbTodoList.SelectedIndex + 1;
            }
            else
            {
                lbTodoList.SelectedIndex = 0;
                
            }
            
        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            lbTodoList.SelectedItems.Clear();
            lbTodoList.SelectedIndex = lbTodoList.Items.Count - 1;
            
        }
    }
}
