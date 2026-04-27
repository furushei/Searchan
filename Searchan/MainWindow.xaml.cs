using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace Searchan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += (_, _) => queryTextInput.Focus();
        }

        private void queryTextInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                SearchAndClose();
            else if (e.Key == Key.Escape)
                Close();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            SearchAndClose();
        }

        private void SearchAndClose()
        {
            string query = queryTextInput.Text;
            SearchInBrowser(query);

            // ウィンドウを閉じる
            Close();
        }

        private void SearchInBrowser(string query)
        {
            // ブラウザで検索するためのURLを生成
            string url = $"https://www.google.com/search?q={Uri.EscapeDataString(query)}";

            // デフォルトのブラウザでURLを開く
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }
    }
}