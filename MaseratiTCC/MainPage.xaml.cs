using MaseratiTCC.Models;
using MaseratiTCC.View.Options;
using Microsoft.Maui.Controls;

namespace MaseratiTCC;

public partial class MainPage : ContentPage
{
    public List<CarouselItem> CarouselItems { get; set; }
    public MainPage()
	{
		InitializeComponent();

        CarouselItems = new List<CarouselItem>
        {
            new CarouselItem { ImagePath = "manicure.png", Description = "Manicure", DestinationPage = typeof(ManicureView) },
            new CarouselItem { ImagePath = "salao.png", Description = "Salão de beleza", DestinationPage = typeof(SalaoView) },
            new CarouselItem { ImagePath = "barbearia.png", Description = "Barbearia", DestinationPage = typeof(BarbeariaView) }
        };

        carouselView.ItemsSource = CarouselItems;
    }

    private async void OnImageTapped(object sender, EventArgs e)
    {
        var clickedImage = sender as ImageButton;
        if (clickedImage != null)
        {
            var clickedItem = clickedImage.BindingContext as CarouselItem;
            if (clickedItem != null && clickedItem.DestinationPage != null)
            {
                var destinationPage = (Page)Activator.CreateInstance(clickedItem.DestinationPage);
                await Navigation.PushAsync(destinationPage);
            }
        }
    }

    private int currentIndex = 0;
    private void OnNextButtonClicked(object sender, EventArgs e)
    {
        currentIndex++;
        if (currentIndex >= CarouselItems.Count)
        {
            currentIndex = 0;
        }
        carouselView.Position = currentIndex;
    }


    private void OnPreviousButtonClicked(object sender, EventArgs e)
    {
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = CarouselItems.Count - 1;
        }
        carouselView.Position = currentIndex;
    }
}

