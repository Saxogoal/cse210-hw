using System;

class Product
{
    private int _id;
    private string _name;
    private decimal _price;
    private int _quantity;

    public Product(int id, string name, decimal price, int quantity)
    {
        _id = id;
        _name = name;
        _price = price;
        _quantity = quantity;
    }

    public decimal GetTotalCost()
    {
        return _price * _quantity;
    }

    public string GetProductInfo()
    {
        return $"{_name} (ID: {_id})";
    }

    public void SetPrice(decimal price)
    {
        _price = price;
    }
}