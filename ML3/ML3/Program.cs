using System;
using System.Windows.Forms;
using ML3;

namespace MovieDatabase
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}



public class Movie
{
    public string Title { get; set; }
    public int Year { get; set; }
    public string Url { get; set; }
}