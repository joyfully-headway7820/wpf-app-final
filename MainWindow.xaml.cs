using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppFinal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Game> _displayedGames = new();

        public MainWindow()
        {
            InitializeComponent();
            GamesListBox.ItemsSource = _displayedGames;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var name = NameInput.Text;
            if (name.Length < 1)
            {
                ErrorText.Text = "пустое имя";
                return;
            }

            var genre = GenreInput.Text;
            if (genre.Length < 1)
            {
                ErrorText.Text = "пустой жанр";
                return;
            }

            var year = int.Parse(YearInput.Text);
            if (YearInput.Text.Length < 1)
            {
                ErrorText.Text = "пустой год";
                return;
            }

            var newGame = new Game(name, genre, year);
            _displayedGames.Add(newGame);
        }

        private void GamesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GamesListBox.SelectedItem is Game game)
                ShowGameDetails(game);
            else
                ClearGameDetails();
        }

        private void ShowGameDetails(Game game)
        {
            DetailsPlaceholder.Visibility = Visibility.Collapsed;
            DetailsPanel.Visibility = Visibility.Visible;

            DetailName.Text = game.Name;
            DetailGenre.Text = game.Genre;
            DetailYear.Text = game.Year.ToString();
        }

        private void ClearGameDetails()
        {
            DetailsPlaceholder.Visibility = Visibility.Visible;
            DetailsPanel.Visibility = Visibility.Collapsed;
        }
    }
}
