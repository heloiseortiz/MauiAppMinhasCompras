using System.Globalization;
using MauiAppMinhasCompras.Helpers;
using MauiAppMinhasCompras.Models; // <- importante para usar Produto
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace MauiAppMinhasCompras
{
    public partial class App : Application
    {
        // Banco de dados SQLite
        static SQLiteDatabaseHelper _db;
        public static SQLiteDatabaseHelper Db
        {
            get
            {
                if (_db == null)
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "banco_sqlite_compras.db3");

                    _db = new SQLiteDatabaseHelper(path);
                }
                return _db;
            }
        }

        // Lista global de produtos
        public static List<Produto> Produtos { get; set; } = new List<Produto>();

        public App()
        {
            InitializeComponent();

            // Define cultura brasileira
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

            // Página inicial
            MainPage = new NavigationPage(new Views.ListaProduto());
        }
    }
}
