using Prog2BIceTask1;
using System.Text;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROG2BICETASK1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Product? currentProduct = null;

        public MainWindow()
        {
            InitializeComponent();
            ProductUtil.Populate();
            RenderProducts();
        }

        private void RenderProducts()
        {
            ItemsPanel.Children.Clear();
            int index = 0;
            StackPanel? nestedStackPanel = null;
            foreach (Product p in ProductUtil.products)
            {
                if (index % 3 == 0)
                {
                    nestedStackPanel = new StackPanel
                    {
                        Orientation = Orientation.Horizontal,
                        Margin = new Thickness(5)
                    };
                    ItemsPanel.Children.Add(nestedStackPanel);
                }
                StackPanel singleItemPanel = new StackPanel();
                Image image = new Image
                {
                    Source = new BitmapImage(new Uri(p.Url)),
                    Height = 100,
                    Margin = new Thickness(5)
                };
                singleItemPanel.Children.Add(image);
                Label name = new Label
                {
                    Content = p.Name,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Margin = new Thickness(5),
                    Foreground = Brushes.White
                };
                singleItemPanel.Children.Add(name);
                Label price = new Label
                {
                    Content = "R " + p.Price,
                    FontWeight = FontWeights.Bold,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Margin = new Thickness(5),
                    Foreground = Brushes.White
                };
                singleItemPanel.Children.Add(price);

                singleItemPanel.MouseDown += (sender, e) => image_Click(p, sender, e);
                nestedStackPanel.Children.Add(singleItemPanel);
                index++;
            }
        }

        private void DisplayProductsDetails(Product p)
        {
            QtySelected.Text = "1";
            NameLabel.Content = "You have selected: \n" + p.Name;

            string categoryString = "Category: "+p.Category;
           
            CategoryLabel.Content = categoryString;

            UpdatePrice(p.Price, 1);
        }

        private void image_Click(Product p, object sender, MouseButtonEventArgs e)
        {
            currentProduct = p;
            TransactionPanel.Visibility = Visibility.Visible;
            DisplayProductsDetails(p);
        }

        private void Go_Button_Click(object sender, RoutedEventArgs e)
        {
            ProcessTransaction();
            TransactionPanel.Visibility = Visibility.Hidden;
        }

        private void Increase_Button_Click(object sender, RoutedEventArgs e)
        {
            int currentValue = Convert.ToInt32(QtySelected.Text);
            if (currentValue != 0)
            {
                currentValue++;
                QtySelected.Text = currentValue.ToString();
            }
            UpdatePrice(currentProduct.Price, currentValue);
        }

        private void Decrease_Button_Click(object sender, RoutedEventArgs e)
        {
            int currentValue = Convert.ToInt32(QtySelected.Text);
            if (currentValue != 0)
            {
                currentValue--;
                QtySelected.Text = currentValue.ToString();
            }
            UpdatePrice(currentProduct.Price, currentValue);
        }

        private void ProcessTransaction()
        {
            int newId = TransactionUtil.transactions.Count;
            DateTime now = DateTime.Now;
            int qty = Convert.ToInt32(QtySelected.Text);
            double price = qty * currentProduct.Price;
            Prog2BIceTask1.Transaction t = new Prog2BIceTask1.Transaction(newId, now, currentProduct, qty, price);
            TransactionUtil.transactions.Add(t);

            MessageBox.Show("Thank you for the purchase!");
        }

        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            this.Hide();
            adminWindow.ShowDialog();
            RenderProducts();
            this.Show();
        }

        private void UpdatePrice(double price, int qty)
        {
            PriceLabel.Content = "Price: R " + (price * qty).ToString();
        }
    }
}