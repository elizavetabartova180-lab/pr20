
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Forms = System.Windows.Forms;

namespace ApplicationSettings_Bartova.Pages
{
    /// <summary>
    /// Логика взаимодействия для Setting.xaml
    /// </summary>
    public partial class Setting : Page
    {
        Forms.OpenFileDialog OpenFileDialog = new Forms.OpenFileDialog();
        Forms.ColorDialog ColorDialog = new Forms.ColorDialog();
        public Setting()
        {
            InitializeComponent();
            OpenFileDialog.InitialDirectory = "c:\\";
            OpenFileDialog.Filter = "Access files (*.accdb)|*accdb| All files (*.*)|*.*";
            OpenFileDialog.FilterIndex = 2;
            OpenFileDialog.RestoreDirectory = true;

            ColorDialog.AllowFullOpen = true;
            ColorDialog.ShowHelp = false;
        }

        private void OpenDatabase(object sender, RoutedEventArgs e)
        {
            if (OpenFileDialog.ShowDialog() == Forms.DialogResult.OK)
                tdDatabase.Text = OpenFileDialog.FileName;
        }

        private void ChangeScreenResolution(object sender, SelectionChangedEventArgs e)
        {
            ComboBox Resolutions = sender as ComboBox;
            TextBlock Resolution = Resolutions.SelectedValue as TextBlock;

            string[] separator = new string[1] { "x" };

            string TextResolution = Resolution.Text;
            MainWindow.init.Width = int.Parse(TextResolution.Split(separator, System.StringSplitOptions.None)[0]);
            MainWindow.init.Height = int.Parse(TextResolution.Split(separator, System.StringSplitOptions.None)[1]);

        }

        private void SelectColorApplication(object sender, RoutedEventArgs e)
        {
            if (ColorDialog.ShowDialog() == Forms.DialogResult.OK)
            {
                System.Drawing.Color ChangeColor = ColorDialog.Color;

                SolidColorBrush ChangeColorBack = new SolidColorBrush(Color.FromArgb(
                    ChangeColor.A,
                    ChangeColor.R,
                    ChangeColor.G,
                    ChangeColor.B));
                gHeader.Background = ChangeColorBack;
                gApplication.Background = ChangeColorBack;
            }
        }
    }
}
