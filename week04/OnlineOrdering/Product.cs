public class Product
{
    private string _name = "";
    private int _id = 0;
    private double _price = 0;
    private int _qnt = 0;

    public Product(string name, int id, double price, int qnt)
    {
        _name = name;
        _id = id;
        _price = price;
        _qnt = qnt;
    }

    public double Price()
    {
        return Math.Round(_price * _qnt, 2);
    }

    public string GetName()
    {
        return _name;
    }

    public int GetID()
    {
        return _id;
    }

}