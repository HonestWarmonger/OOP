using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using WMPLib;

namespace MovieDatabase
{
    public partial class Form1 : Form
    {
        private WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();

        List<Movie> allMovies = new List<Movie>
        {
            new Movie { Title = "The Phantom Menace", Year = 1999, Url = "https://tv.apple.com/ua/movie/star-wars-the-phantom-menace/umc.cmc.1x8mput5lh4l0u6vue0hbmhs3" },
            new Movie { Title = "Attack of the Clones", Year = 2002, Url = "https://tv.apple.com/ua/movie/star-wars-attack-of-the-clones/umc.cmc.27tj6w4r4fpeziazh0cyza2bq" },
            new Movie { Title = "Revenge of the Sith", Year = 2005, Url = "https://tv.apple.com/ua/movie/star-wars-episode-iii--revenge-of-the-sith/umc.cmc.5nolvqgurfe17eln52s0b7j6j?action=play" },
            new Movie { Title = "A New Hope", Year = 1977, Url = "https://tv.apple.com/ua/movie/star-wars-episode-iv---a-new-hope/umc.cmc.2o65qvudvwq1l1rqjlbyfszwn" },
            new Movie { Title = "The Empire Strikes Back", Year = 1980, Url = "https://tv.apple.com/ua/movie/star-wars-the-empire-strikes-back/umc.cmc.3vabzkcmuoxxm3r3ng9q4rgh9" },
            new Movie { Title = "Return of the Jedi", Year = 1983, Url = "https://tv.apple.com/ua/movie/star-wars-episode-vi---return-of-the-jedi/umc.cmc.3ggalukb7xb5pf1gfgdlwkcx" },
            new Movie { Title = "The Clone Wars", Year = 2008, Url = "https://www.lostfilm.tv/series/Star_Wars_The_Clone_Wars/seasons" },
            new Movie { Title = "Rogue One", Year = 2016, Url = "https://tv.apple.com/ua/movie/rogue-one-a-star-wars-story/umc.cmc.5ydra856u0y2hc1ur13qd4xxx?action=play" },
            new Movie { Title = "Solo", Year = 2018, Url = "https://tv.apple.com/ua/movie/solo-a-star-wars-story/umc.cmc.1skhjjrps93jxwc8w45mc4yyj" },
            new Movie { Title = "The Mandalorian", Year = 2019, Url = "https://www.lostfilm.tv/series/The_Mandalorian" }
        };

        public Form1()
        {
            InitializeComponent();


            SetupDataGridView();

            WindowsMediaPlayer player = new WindowsMediaPlayer();

            ShowMovies(allMovies);

            btnSearch.Click += BtnSearch_Click;
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
        }

        private void SetupDataGridView()
        {
            dataGridView1.Columns.Clear();


            DataGridViewTextBoxColumn colTitle = new DataGridViewTextBoxColumn();
            colTitle.Name = "Title";
            colTitle.HeaderText = "Назва";
            colTitle.DataPropertyName = "Title";
            colTitle.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns.Add(colTitle);


            DataGridViewTextBoxColumn colYear = new DataGridViewTextBoxColumn();
            colYear.Name = "Year";
            colYear.HeaderText = "Рік";
            colYear.DataPropertyName = "Year";
            colYear.Width = 60;
            dataGridView1.Columns.Add(colYear);


            DataGridViewButtonColumn colWatch = new DataGridViewButtonColumn();
            colWatch.Name = "Watch";
            colWatch.HeaderText = "";
            colWatch.Text = "Дивитися онлайн";
            colWatch.UseColumnTextForButtonValue = true;
            colWatch.Width = 120;
            dataGridView1.Columns.Add(colWatch);

            dataGridView1.AutoGenerateColumns = false;
        }

        private void ShowMovies(List<Movie> movies)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = movies;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string input = txtYear.Text.Trim();
            if (string.Equals(input, "Order 66", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    player.URL = "order66.mp3";
                    player.controls.play();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не вдалося відтворити звук: " + ex.Message);
                }
                return;
            }

            if (string.IsNullOrEmpty(input))
            {
                ShowMovies(allMovies);
                return;
            }

            if (int.TryParse(input, out int year))
            {
                var filtered = allMovies.Where(m => m.Year == year).ToList();
                ShowMovies(filtered);
            }
            else
            {
                MessageBox.Show("Введіть коректний рік.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

if (dataGridView1.Columns[e.ColumnIndex].Name == "Watch")
            {
                Movie movie = (Movie)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                if (!string.IsNullOrEmpty(movie.Url))
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = movie.Url,
                            UseShellExecute = true
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Не вдалося відкрити посилання: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Посилання на фільм відсутнє.");
                }
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    public class Movie
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Url { get; set; }
    }
}