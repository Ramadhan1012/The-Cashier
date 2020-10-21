# The Chasier

Aplikasi ini merupakan sebuah aplikasi kasir sederhana yang mencakup perhitungan,penjumlahan,dan perkalian untuk menghitung harga barang dan jasa yang telah di inputkan, sedangkan barang atau jasa yang sudah di inputkan dan sudah di jumlahkan maupun di kalikan nantinya akan masuk pada data ListBox.

## Scope & Functionalities
- User dapat menginputkan nama Barang
- User dapat memilih tipe Barang/Jasa
- User dapat menentukan Jumlah banyaknya barang
- User dapat menambahkan Harga barang yg ingin di input
- User dapat melihat informasi yang sudah di inputkan

## How Does It Works
- Diawali pada `MainWindow.xaml.cs` kita mendeklarasikan
```csharp
private Calculator calculator;
        public MainWindow()
        {
            InitializeComponent();
            calculator = new Calculator();
            listBox.ItemsSource = calculator.getLisItem();
        }
```

- Inisialisasi seluruh variable pada `Item.cs` yang nantinya akan di inputkan oleh pengguna

```csharp
public Item(int id, string title, int quantity, double price, double subtotal, string type)
        {
            this.id = id;
            this.title = title;
            this.quantity = quantity;
            this.price = price;
            this.subtotal = subtotal;
            this.type = type;
        }
```

- Berikut ini variabel perwakilan untuk input pada Class `Item.cs` dimana nilai dari subtotal diambil dari perkalian nilai price dengan quantity
```csharp
public double getSubtotal()
        {
            subtotal = price * quantity;
            return subtotal;
        }
```
- Logika perhitungan total suluruh Barang/Jasa yang telah di input pada Class `Calculator.cs`
```csharp
public void addItem(Item item)
        {
            this.listItem.Add(item);
            this.total += item.getSubtotal();
        }
```
- Untuk menampilkan seluruh informasi yang telah di input Ke dalam ListBox pada saat menekan tombol tambahkan
```csharp
private void addButton_Click(object sender, RoutedEventArgs e)
        {
            string title = itemNameBox.Text;
            int quantity = int.Parse(quantityBox.Text);
            string type = typeBox.Text;
            double price = double.Parse(priceBox.Text);

            Item item = new Item(new Random().Next(), title,quantity,price,price,type);
            calculator.addItem(item);
            double total = calculator.getTotal();

            totalLabel.Content = string.Format("Rp. {0}", total);

            listBox.Items.Refresh();
        }
```