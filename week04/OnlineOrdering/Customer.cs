using System;

class Customer
{
    private string _name;
    private Address _shippingAddress;

    public Customer(string name, Address shippingAddress)
    {
        _name = name;
        _shippingAddress = shippingAddress;
    }

    public bool IsInUSA()
    {
        return _shippingAddress.IsInUSA();
    }

    public string GetShippingLabel()
    {
        return $"{_name}\n{_shippingAddress.GetFullAddressString()}";
    }
}