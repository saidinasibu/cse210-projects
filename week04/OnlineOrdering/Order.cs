using System.Security.Cryptography.X509Certificates;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double OrderCost()
    {
        double shipping = 0;
        double price = 0;

        foreach (Product product in _products)
        {
            price += product.Price();
        }

        if (_customer.USA())
        {
            shipping = 5;
        }
        else
        {
            shipping = 35;
        }

        return shipping + price;
    }

    public string PackingLabel()
    {
        string label = "Packing Label:\n";

        foreach (Product product in _products)
        {
            label += $"Product: {product.GetName()}, ID: {product.GetID()}\n";
        }

        return label;
    }

    public string ShippingLabel()
    {
        return $"Packing Label:\nCustomer Name: {_customer.GetName()}\nCustomer Address:\n{_customer.GetAddress()}";
    }

}