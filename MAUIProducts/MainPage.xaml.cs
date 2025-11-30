using hw4_1_maui.Models;
using System.Collections.ObjectModel;
using System.Globalization;

namespace hw4_1_maui
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();

        public MainPage()
        {
            InitializeComponent();

            BindingContext = this;

            LoadInitialData();
        }

        private void LoadInitialData()
        {
            Products.Add(new Food(35.50m, "Україна", "Молоко", DateTime.Now, "Смачне молоко", 7, 900, "мл"));
            Products.Add(new Food(20.00m, "Польща", "Хліб", DateTime.Now, "Свіжий хліб", 3, 500, "г"));
            Products.Add(new Book(299.99m, "Великобританія", "The Pragmatic Programmer", DateTime.Now, "Про програмування", 352, "Addison-Wesley", new List<string> { "Andrew Hunt", "David Thomas" }));
        }
        private async void OnAddProductClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameEntry.Text) || string.IsNullOrWhiteSpace(PriceEntry.Text))
            {
                await DisplayAlertAsync("Помилка", "Будь ласка, введіть назву та ціну!", "OK");
                return;
            }
            if (!decimal.TryParse(PriceEntry.Text, out decimal price))
            {
                await DisplayAlertAsync("Помилка", "Ціна має бути числом!", "OK");
                return;
            }
            if (price <= 0)
            {
                await DisplayAlertAsync("Помилка", "Ціна має бути додатнім числом!\nМи ж не благодійний фонд, і ми не платимо покупцю ;)", "OK");
                return;

            }

            string name = NameEntry.Text;
            string description = DescEntry.Text;
            string country = CountryEntry.Text;

            if (string.IsNullOrWhiteSpace(country)) country = "Невідома";
            if (string.IsNullOrWhiteSpace(description)) description = "Без опису";

            Product newProduct;
            if (TypePicker.SelectedIndex == 0)
            {
                newProduct = new Food(
                    price, country, name, DateTime.Now,
                    description,
                    7, 1, "шт"
                );
            }
            else
            {
                newProduct = new Book(
                    price, country, name, DateTime.Now,
                    description,
                    300, "Самвидав", new List<string> { "Я (Користувач)" }
                );
            }

            Products.Add(newProduct);

            NameEntry.Text = string.Empty;
            PriceEntry.Text = string.Empty;
            CountryEntry.Text = string.Empty;
            DescEntry.Text = string.Empty;

            NameEntry.Unfocus();
            PriceEntry.Unfocus();
        }
        private async void OnDeleteProductClicked(object sender, EventArgs e)
        {
            var selectedItem = ItemsCollectionView.SelectedItem as Product;

            if (selectedItem != null)
            {
                Products.Remove(selectedItem);
                ItemsCollectionView.SelectedItem = null;
            }
            else
            {
               await DisplayAlertAsync("Помилка", "Виберіть товар, щоб видалити його", "OK");
            }
        }
        private async void OnItemDoubleTapped(object sender, TappedEventArgs e)
        {
            var grid = sender as Grid;
            var selectedItem = grid.BindingContext as Product;

            if (selectedItem == null) return;
            string details = "";

            if (selectedItem is Book book)
            {
                details = $"Країна: {book.CountryOrigin}\n" +
                          $"Видавництво: {book.Publisher}\n" +
                          $"Сторінок: {book.PageCount}\n" +
                          $"Автори: {string.Join(", ", book.Authors)}";
            }
            else if (selectedItem is Food food)
            {
                details = $"Країна: {food.CountryOrigin}\n" + 
                          $"Термін придатності: {food.ExpirationDays} днів\n" +
                          $"Кількість: {food.Quantity} {food.Unit}";
            }
            else
            {
                details = selectedItem.Description;
            }
            await DisplayAlertAsync(selectedItem.Name, details, "ОК");
        }
    }

}
