using MauiAppMinhasCompras.Models;
using System.Linq;

namespace MauiAppMinhasCompras.Views
{
    public partial class RelatorioCategoria : ContentPage
    {
        public RelatorioCategoria()
        {
            InitializeComponent();
            CarregarRelatorio();
        }

        // Classe auxiliar para binding
        public class CategoriaTotal
        {
            public string Categoria { get; set; }
            public double Total { get; set; }
        }

        private void CarregarRelatorio()
        {
            // Agrupa produtos por categoria e calcula total
            var relatorio = App.Produtos
                .GroupBy(p => p.Categoria)
                .Select(g => new CategoriaTotal
                {
                    Categoria = g.Key,
                    Total = g.Sum(p => p.Preco * p.Quantidade)
                })
                .ToList();

            // Define a fonte de dados do CollectionView
            ProdutosCollectionView.ItemsSource = relatorio;

            // Calcula o total geral
            double totalGeral = relatorio.Sum(r => r.Total);
            TotalCategoriaLabel.Text = $"Total Geral: {totalGeral:C}";
        }
    }
}
