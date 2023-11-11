using System;
namespace Asgn3
{
    class Program
    {
        static void Main(string[] args)
        {
            Store s = new Store();
            int c;
            do
            {
                Console.Write("Select any one option from below \n");
                Console.WriteLine("1: Add Product\n2: Add Customer\n3: Add Order\n4: Show All Products\n5: Show All Customers\n6: Show Order\n7: Exit\n");
                Console.Write("Enter Your Choice: ");
                c = int.Parse(Console.ReadLine());
                switch (c)
                {
                    case 1:
                        Console.Write("Enter Product Name:");
                        string pname = Console.ReadLine();
                        Console.Write("Enter Product Price:");
                        double price = double.Parse(Console.ReadLine());
                        Console.Write("Is it discounted product? (y for Yes and n for No): ");
                        string ans = Console.ReadLine().ToLower();
                        if (ans.Equals("n"))
                            s.addProduct(new Product(pname, price));
                        else
                        {
                            Console.Write("Enter Discount Rate(%):");
                            double dis = double.Parse(Console.ReadLine());
                            s.addProduct(new DiscountedProduct(pname, price, dis));
                        }
                        Console.WriteLine("Product Added");
                        break;
                    case 2:
                        Console.Write("Enter Customer Name:");
                        string cname = Console.ReadLine();
                        Console.Write("Enter Customer Email:");
                        string em = Console.ReadLine();
                        Console.Write("Is he/she Premium Customer? (y for Yes and n for No): ");
                        string ans1 = Console.ReadLine().ToLower();
                        if (ans1.Equals("n"))
                            s.addCustomer(new Customer(cname, em));
                        else
                        {
                            Console.Write("Enter Premium Discount(%):");
                            double dis = double.Parse(Console.ReadLine());
                            s.addCustomer(new PremiumCustomer(cname, em, dis));
                        }
                        Console.WriteLine("Customer Added");
                        break;
                    case 3:
                        Console.WriteLine("Customers:");
                        s.fetchcustomers();
                        Customer customer = null;
                        do
                        {
                            Console.Write("Enter Customer Id : ");
                            int Customerid = int.Parse(Console.ReadLine());
                            if (Customerid == 0)
                                break;
                            customer = s.getCustomerById(Customerid);
                            if (customer == null)
                            {
                                Console.WriteLine("Customer not Found");
                            }
                        } while (customer == null);
                        Console.WriteLine("Products:");
                        s.fetchproducts();
                        List<Product> prod = new List<Product>();
                        int Productid = 0;
                        do
                        {
                            Console.Write("Enter Product Id : ");
                            Productid = int.Parse(Console.ReadLine());
                            if (Productid == 0)
                                break;
                            Product p = s.getProductById(Productid);
                            if (p == null)
                            {
                                Console.WriteLine("Product is not found");
                            }
                            else
                            {
                                prod.Add(p);
                                Console.WriteLine("Product is Added to your Order");
                            }
                        }
                        while (Productid != 0);
                        if (customer != null)
                        {
                            Order oo = new Order(customer, prod);
                            oo.calculateTotal();
                            s.addOrder(oo);
                            Console.WriteLine("Order Added");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Products:");
                        s.fetchproducts();
                        break;
                    case 5:
                        Console.WriteLine("Customers:");
                        s.fetchcustomers();
                        break;
                    case 6:
                        Console.Write("Enter Order Id: ");
                        int oid = int.Parse(Console.ReadLine());
                        Order o = s.getOrderById(oid);
                        if (o == null)
                        {
                            Console.WriteLine("Order not found");
                        }
                        else
                        {
                            o.showOrder();
                        }
                        break;
                    case 7:
                        Console.WriteLine("Thank You, Visit again our Store");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
            while (c != 7);
            Console.ReadKey();
        }
    }
    class Product
    {
        protected static int Number = 0;
        protected int id;
        protected string name;
        protected double price;
        public Product()
        {
            Number++;
            this.id = Number;
        }
        public Product(string name, double price)
        {
            Number++;
            this.id = Number;
            this.name = name;
            this.price = price;
        }
        public int getId()
        {
            return this.id;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public string getName()
        {
            return this.name;
        }
        public void setPrice(double price)
        {
            this.price = price;
        }
        public double getPrice()
        {
            return price;
        }
        public void showProduct()
        {
            Console.WriteLine("Id: {0}, Name: {1}, Price: {2}", getId(), getName(), getPrice());
        }
        public double calculate_discount()
        {
            return 0;
        }
    }
    class DiscountedProduct : Product
    {
        private double discount_rate;
        public DiscountedProduct() : base()
        {
        }
        public DiscountedProduct(string name, double price, double rate) : base(name, price)
        {
            discount_rate = rate;
        }
        public void setDiscount(double rate)
        {
            discount_rate = rate;
        }
        public double getDiscount()
        {
            return discount_rate;
        }
        new public double calculate_discount()
        {
            return price * discount_rate / 100;
        }
        new public void showProduct()
        {
            Console.WriteLine("Id: {0}, Name: {1}, Price: {2}, Discount: {3}, Net Price: {4}", getId(), getName(), getPrice(), calculate_discount(), getPrice() - calculate_discount());
        }
    }
    class Customer
    {
        protected static int Number = 0;
        protected int id;
        protected string name;
        protected string email;
        public Customer()
        {
            Number++;
            this.id = Number;
        }
        public Customer(string name, string email)
        {
            Number++;
            this.id = Number;
            this.name = name;
            this.email = email;
        }
        public int getId()
        {
            return this.id;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public string getName()
        {
            return this.name;
        }
        public void setEmail(string email)
        {
            this.email = email;
        }
        public string getEmail()
        {
            return email;
        }
        public void showCustomer()
        {
            Console.WriteLine("Id: {0}, Name: {1}, Email: {2}", getId(), getName(), getEmail());
        }
        public double get_discount()
        {
            return 0;
        }
    }
    class PremiumCustomer : Customer
    {
        private double discount;
        public PremiumCustomer() : base()
        {
        }
        public PremiumCustomer(string name, string email, double discount) : base(name, email)
        {
            this.discount = discount;
        }
        new public double get_discount()
        {
            return discount;
        }
        new public void showCustomer()
        {
            Console.WriteLine("Id: {0}, Name: {1}, Email: {2}, Premium Discount:{3}%", getId(), getName(), getEmail(), get_discount());
        }
    }
    class Order
    {
        private static int Number = 0;
        private int id;
        private Customer customer;
        private List<Product> products;
        private double total;
        public Order()
        {
            Number++;
            this.id = Number;
        }
        public Order(Customer customer, List<Product> products)
        {
            Number++;
            this.id = Number;
            this.customer = customer;
            this.products = products;
        }
        public int getId()
        {
            return this.id;
        }
        public void setCustomer(Customer customer)
        {
            this.customer = customer;
        }
        public Customer getCustomer()
        {
            return this.customer;
        }
        public void setProduct(List<Product> products)
        {
            this.products = products;
        }
        public List<Product> getProduct()
        {
            return products;
        }
        public void calculateTotal()
        {
            this.total = 0;
            foreach (Product p in this.products)
            {
                if (p.GetType() == typeof(DiscountedProduct))
                {
                    this.total += p.getPrice() - ((DiscountedProduct)p).calculate_discount();
                }
                else
                {
                    this.total += p.getPrice() - p.calculate_discount();
                }
            }
            if (customer.GetType() == typeof(PremiumCustomer))
            {
                this.total = this.total - (this.total * ((PremiumCustomer)customer).get_discount() / 100);
            }
        }
        public double getTotal()
        {
            return total;
        }
        public void showOrder()
        {
            Console.WriteLine("Order Id: {0}", getId());
            Console.WriteLine("=============================");
            Console.WriteLine("Customer's Details");

            if (getCustomer().GetType() == typeof(PremiumCustomer))
            {
                Console.WriteLine("Id: {0}, Name: {1}, Email: {2}, Premium Discount:{3}%", getCustomer().getId(), getCustomer().getName(), getCustomer().getEmail(), ((PremiumCustomer)getCustomer()).get_discount());
            }
            else
            {
                Console.WriteLine("Id: {0}, Name: {1}, Email: {2}", getCustomer().getId(), getCustomer().getName(), getCustomer().getEmail());
            }
            Console.WriteLine("=============================");
            Console.WriteLine("Product's Details");

            Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-10} {4,-10}", "Id", "Name", "Price", "Discount", "Net Price");
            foreach (Product p in getProduct())
            {
                if (p.GetType() == typeof(DiscountedProduct))
                {
                    Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-10} {4,-10}", p.getId(), p.getName(), p.getPrice(), ((DiscountedProduct)p).calculate_discount(), p.getPrice() - ((DiscountedProduct)p).calculate_discount());
                }
                else
                {
                    Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-10} {4,-10}", p.getId(), p.getName(), p.getPrice(), p.calculate_discount(), p.getPrice());
                }
            }
            Console.WriteLine("=============================");
            Console.WriteLine("Total Amount: {0}", getTotal());
            Console.WriteLine("=============================");
        }
    }
    class Store
    {
        private List<Product> products;
        private List<Customer> customers;
        private List<Order> orders;
        public Store()
        {
            products = new List<Product>();
            customers = new List<Customer>();
            orders = new List<Order>();
        }
        public void addProduct(Product p)
        {
            products.Add(p);
        }
        public void addCustomer(Customer c)
        {
            customers.Add(c);
        }
        public void addOrder(Order o)
        {
            orders.Add(o);
        }
        public void fetchproducts()
        {
            foreach (Product p in products)
            {
                if (p.GetType() == typeof(DiscountedProduct))
                {
                    ((DiscountedProduct)p).showProduct();
                }
                else
                {
                    p.showProduct();
                }
            }
        }
        public void fetchcustomers()
        {
            foreach (Customer c in customers)
            {
                if (c.GetType() == typeof(PremiumCustomer))
                {
                    ((PremiumCustomer)c).showCustomer();
                }
                else
                {
                    c.showCustomer();
                }
            }
        }
        public void fetchorders()
        {
            Console.WriteLine("List of orders are");
            foreach (Order o in orders)
            {
                o.showOrder();
            }
        }
        public Product getProductById(int id)
        {
            foreach (Product p in products)
            {
                if (p.getId() == id)
                {
                    return p;
                }
            }
            return null;
        }
        public Customer getCustomerById(int id)
        {
            foreach (Customer c in customers)
            {
                if (c.getId() == id)
                {
                    return c;
                }
            }
            return null;
        }
        public Order getOrderById(int id)
        {
            foreach (Order o in orders)
            {
                if (o.getId() == id)
                {
                    return o;
                }
            }
            return null;
        }
    }
}
