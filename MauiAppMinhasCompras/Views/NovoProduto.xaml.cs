using System.Threading.Tasks;
using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
	public NovoProduto()
	{
		InitializeComponent();
	}

	private async void ToolbarItem_Clicked(object sender, EventArgs e)
	{
		try
		{
			Produto p = new Produto
			{
				Descricao = txt_descricao.Text,
				Quantidade = Convert.ToInt32(txt_quantidade.Text),
				Preco = Convert.ToDouble(txt_preco.Text)
			};

			await App._Db.Insert(p);
			await DisplayAlert("Salvo", "Registro Inserido com sucesso!!", "OK");
			await Navigation.PopAsync();

        }
		catch (Exception ex)
		{
			await DisplayAlert("Ops", ex.Message, "OK");
		}
	}
}
