using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.RightsManagement;
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

namespace test_wpf
{

    // サンプルクラス
    class Person{
        public string Name { get; set; }
        public int Age { get; set; }
    }
/// <summary>
/// MainWindow.xaml の相互作用ロジック
/// </summary>

// INotifyPropertyChangedを継承し、PropertyChangedとOnPropertyChangedを用意すればOK
public partial class MainWindow : Window, INotifyPropertyChanged

    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected void update(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
 
        public SolidColorBrush SignButtonColor { get; set; } = Brushes.White;

        public SolidColorBrush AttendButtonColor { get; set; }=Brushes.White;

        public SolidColorBrush AttendLogButtonColor { get; set; } = Brushes.White;

        public SolidColorBrush AttendStateButtonColor { get; set; } = Brushes.White;

        public string StateMessage { get; set; } = "出席していません";
        public SolidColorBrush StateMessageColor { get; set; } = Brushes.Red;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Sign.MouseEnter += (a, b) => {
                SignButtonColor = Brushes.LightGray;
                update(nameof(SignButtonColor));
            };
            Sign.MouseLeave += (a, b) =>
            {
                SignButtonColor = Brushes.White;
                update(nameof(SignButtonColor));
            };

            Sign.Click += (a, b) =>
            {
                MainTab.SelectedIndex = 3;
            };

            Attend.MouseEnter += (a, b) =>
            {
                AttendButtonColor = Brushes.LightGray;
                update(nameof(AttendButtonColor));
            };

            Attend.MouseLeave += (a, b) =>
            {
                AttendButtonColor = Brushes.White;
                update(nameof(AttendButtonColor));
            };

            AttendLog.MouseEnter += (a, b) =>
            {
                AttendLogButtonColor = Brushes.LightGray;
                update(nameof(AttendLogButtonColor));
            };

            AttendLog.MouseLeave += (a, b) =>
            {
                AttendLogButtonColor = Brushes.White;
                update(nameof(AttendLogButtonColor));
            };




            // サンプルデータ
            MyDataGrid.ItemsSource = new List<Person>
            {
                new Person { Name = "Alice", Age = 30 },
                new Person { Name = "Bob", Age = 25 }
            };
        }
    }
}
