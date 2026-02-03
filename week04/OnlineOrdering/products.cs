using System;

public class Product
{
    private readonly string _name;
    private readonly string _productId;
    private readonly decimal _unitPrice;
    private readonly int _quantity;

    public Product(string name, string productId, decimal unitPrice, int quantity)
    {
        _name = name ?? "";
        _productId = productId ?? "";
        _unitPrice = unitPrice;
        _quantity = quantity;
    }

    public decimal GetLineTotal()
    {
        return _unitPrice * _quantity;
    }

    public string GetPackingLine()
    {
        // Packing label needs product name + product id.
        return $"{_name} (ID: {_productId})";
    }
}
