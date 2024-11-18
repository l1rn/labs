
namespace lab3
{
    public class Product
    {
        private string _name;
        private string _supplier;
        private double _purchasePrice;
        private int _purchaseQuantity;
        private double _salePrice;
        private int _saleQuantity;
        private double _revenue;
        private double _profit;

        // Конструктор 
        public Product(string name, string supplier, double purchasePrice, int purchaseQuantity, double salePrice, int saleQuantity, double revenue, double profit)
        {
            _name = name;
            _supplier = supplier;
            _purchasePrice = purchasePrice;
            _purchaseQuantity = purchaseQuantity;
            _salePrice = salePrice;
            _saleQuantity = saleQuantity;
            _revenue = revenue;
            _profit = profit;

        }

    }


    public partial class MainForm : Form
    {
        private TextBox nameTextBox, supplierTextBox, purchasePriceTextBox, purchaseQuantityTextBox, salePriceTextBox, saleQuantityTextBox, comment;
        private Label revenueLabel, profitLabel;
        private Button calculateButton;

        public MainForm()
        {
            InitializeComponent();
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            // Создаём метки и текстовые поля
            Label nameLabel = new Label
            {
                Text = "Наименование товара:",
                Location = new System.Drawing.Point(10, 10),
                AutoSize = true
            };
            nameTextBox = new TextBox
            {
                Location = new System.Drawing.Point(155, 8),
                Width = 150
            };

            Label supplierLabel = new Label
            {
                Text = "Название поставщика:",
                Location = new System.Drawing.Point(10, 40),
                AutoSize = true
            };
            supplierTextBox = new TextBox
            {
                Location = new System.Drawing.Point(155, 38),
                Width = 150
            };

            Label purchasePriceLabel = new Label
            {
                Text = "Стоимость закупки:",
                Location = new System.Drawing.Point(10, 70),
                AutoSize = true
            };
            purchasePriceTextBox = new TextBox
            {
                Location = new System.Drawing.Point(155, 68),
                Width = 150
            };
            Label purchaseQuantityLabel = new Label
            {
                Text = "Количество купленного:",
                Location = new System.Drawing.Point(10, 100),
                AutoSize = true
            };
            purchaseQuantityTextBox = new TextBox
            {
                Location = new System.Drawing.Point(155, 98),
                Width = 150
            };
            Label salePriceLabel = new Label
            {
                Text = "Стоимость продажи:",
                Location = new System.Drawing.Point(10, 130),
                AutoSize = true
            };
            salePriceTextBox = new TextBox
            {
                Location = new System.Drawing.Point(155, 128),
                Width = 150
            };
            Label saleQuantityLabel = new Label
            {
                Text = "Количество проданного:",
                Location = new System.Drawing.Point(10, 160),
                AutoSize = true
            };
            saleQuantityTextBox = new TextBox
            {
                Location = new System.Drawing.Point(155, 158),
                Width = 150
            };
            comment = new TextBox
            {
                Text = "ASOKFOISADJGIUSDNGISDNFisdfngiuvoszdeuirtgouerahnodfoiugjniomearoigjmnearoijgnoiarewjtgoiaerjtgipoaewr",
                Multiline = true,
                ReadOnly = true,
                Location = new System.Drawing.Point(400, 10),
                Width = 300,
                Height = 150
            };
            calculateButton = new Button
            {
                Text = "Рассчитать",
                Location = new System.Drawing.Point(155, 188),
                Width = 100
            };
            calculateButton.Click += CalculateButton_Click;
            revenueLabel = new Label { Text = "Выручка: ", Location = new System.Drawing.Point(10, 220) };
            profitLabel = new Label { Text = "Прибыль: ", Location = new System.Drawing.Point(10, 250) };



            // Добавляем элементы на форму
            this.Controls.Add(nameLabel); this.Controls.Add(nameTextBox);

            this.Controls.Add(supplierLabel); this.Controls.Add(supplierTextBox);

            this.Controls.Add(purchasePriceLabel); this.Controls.Add(purchasePriceTextBox);

            this.Controls.Add(purchaseQuantityLabel); this.Controls.Add(purchaseQuantityTextBox);

            this.Controls.Add(salePriceLabel); this.Controls.Add(salePriceTextBox);

            this.Controls.Add(saleQuantityLabel); this.Controls.Add(saleQuantityTextBox);

            this.Controls.Add(comment);

            this.Controls.Add(calculateButton);

            this.Controls.Add(revenueLabel);

            this.Controls.Add(profitLabel);
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                string name = nameTextBox.Text;
                string supplier = supplierTextBox.Text;
                double purchasePrice = double.Parse(purchasePriceTextBox.Text);
                int purchaseQuantity = int.Parse(purchaseQuantityTextBox.Text);
                double salePrice = double.Parse(salePriceTextBox.Text);
                int saleQuantity = int.Parse(saleQuantityTextBox.Text);
                if(saleQuantity > purchaseQuantity)
                {
                    MessageBox.Show("Ошибка, продано больше, чем куплено");
                    return;
                }
                double revenue = salePrice * saleQuantity;
                double profit = revenue - (purchasePrice * saleQuantity);

                Product product = new Product
                (
                    name,
                    supplier,
                    purchasePrice,
                    purchaseQuantity,
                    salePrice,
                    saleQuantity,
                    revenue,
                    profit
                );

                // Отображаем результаты на экране
                if(profit < 0)
                {
                    MessageBox.Show("У вас нету прибыли, вы в минусе!");
                }
                revenueLabel.Text = $"Выручка: {revenue} р";
                profitLabel.Text = $"Прибыль: {profit} р";
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

    }
}