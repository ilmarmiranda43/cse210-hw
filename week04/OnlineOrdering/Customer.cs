using System;

public class Customer
{
    private readonly string _fullName;
    private readonly Address _shippingAddress;

    public Customer(string fullName, Address shippingAddress)
    {
        _fullName = fullName ?? "";
        _shippingAddress = shippingAddress ?? throw new ArgumentNullException(nameof(shippingAddress));
    }

    public string GetName() => _fullName;

    public bool LivesInUSA() => _shippingAddress.IsInUSA();

    public string GetShippingAddressLabel() => _shippingAddress.GetFormattedAddress();
}
