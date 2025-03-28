using System;
using System.Collections.Generic;

class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }

    public Address(string street, string city, string state, string country)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
    }

    public bool IsInUSA()
    {
        return Country.ToLower() == "usa";
    }

    public string GetFullAddress()
    {
        return $"{Street}\n{City}, {State}\n{Country}";
    }
}

class Product
{
    public string Name { get; set; }
    public string ProductId { get; set; }
    public double PricePerUnit { get; set; }
    public int Quantity { get; set; }

    public Product(string name, string productId, double pricePerUnit, int quantity)
    {
        Name = name;
        ProductId = productId;
        PricePerUnit = pricePerUnit;
        Quantity = quantity;
    }

    public double GetTotalCost()
    {
        return PricePerUnit * Quantity;
    }
}

class Customer
{
    public string Name { get; set; }
    public Address CustomerAddress { get; set; }

    public Customer(string name, Address address)
    {
        Name = name;
        CustomerAddress = address;
    }

    public bool IsInUSA()
    {
        return CustomerAddress.IsInUSA();
    }
}

class Order
{
    public List<Product> Products { get; set; }
    public Customer OrderCustomer { get; set; }

    public Order(Customer customer)
    {
        Products = new List<Product>();
        OrderCustomer = customer;
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public double GetTotalCost()
    {
        double totalCost = 0;
        foreach (var product in Products)
        {
            totalCost += product.GetTotalCost();
        }

        double shippingCost = OrderCustomer.IsInUSA() ? 5 : 35;
        totalCost += shippingCost;

        return totalCost;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in Products)
        {
            label += $"{product.Name} (ID: {product.ProductId})\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{OrderCustomer.Name}\n{OrderCustomer.CustomerAddress.GetFullAddress()}";
    }
}

class Program
{
    static void Main()
    {
        Address address1 = new Address("2275 South St", "Tampa", "FL", "USA");
        Address address2 = new Address("123 Sawtelle Ave", "Houston", "TX", "USA");

        Customer customer1 = new Customer("Leah Jensen", address1);
        Customer customer2 = new Customer("Scott Jensen", address2);

        Product product1 = new Product("Laptop", "P123", 1000, 1);
        Product product2 = new Product("Mouse", "P124", 25, 2);
        Product product3 = new Product("Keyboard", "P125", 50, 1);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product2);
        order2.AddProduct(product3);

        DisplayOrderDetails(order1);
        DisplayOrderDetails(order2);
    }

    static void DisplayOrderDetails(Order order)
    {
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine($"Total Order Cost: ${order.GetTotalCost():0.00}\n");
    }
}
