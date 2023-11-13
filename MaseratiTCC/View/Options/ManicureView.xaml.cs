using MaseratiTCC.Models;

namespace MaseratiTCC.View.Options;

public partial class ManicureView : ContentPage
{

    public List<CarouselItem> CarouselItems { get; set; }
    public ManicureView()
	{
		InitializeComponent();
        CarouselItems = new List<CarouselItem>
        {
            new CarouselItem { ImagePath = "embreve.png", Description = "Em Breve",},
            new CarouselItem { ImagePath = "embreve.png", Description = "Em Breve",},
            new CarouselItem { ImagePath = "embreve.png", Description = "Em Breve",}
        };

        carouselView.ItemsSource = CarouselItems;
    }

    private void Label_SizeChanged(object sender, EventArgs e)
    {

    }

    private async void OnImageTapped2(object sender, EventArgs e)
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
}