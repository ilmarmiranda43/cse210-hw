using System;
using System.Collections.Generic;
using System.Text;

public class Order
{
    private readonly Customer _customer;
    private readonly List<Product> _items;

    private const decimal UsaShippingCost = 5m;
    private const decimal InternationalShippingCost = 35m;

    public Order(Customer customer)
    {
        _customer = customer ?? throw new ArgumentNullException(nameof(customer));
        _items = new List<Product>();
    }

    public void AddItem(Product product)
    {
        if (product == null) throw new ArgumentNullException(nameof(product));
        _items.Add(product);
    }

    public decimal GetTotalCost()
    {
        decimal subtotal = 0m;

        foreach (Product p in _items)
        {
            subtotal += p.GetLineTotal();
        }

        decimal shipping = _customer.LivesInUSA() ? UsaShippingCost : InternationalShippingCost;
        return subtotal + shipping;
    }

    public string GetPackingLabel()
    {
        var sb = new StringBuilder();
        sb.AppendLine("PACKING LABEL");
        sb.AppendLine("------------");

        foreach (Product p in _items)
        {
            sb.AppendLine(p.GetPackingLine());
        }

        return sb.ToString().TrimEnd();
    }

    public string GetShippingLabel()
    {
        var sb = new StringBuilder();
        sb.AppendLine("SHIPPING LABEL");
        sb.AppendLine("-------------");
        sb.AppendLine(_customer.GetName());
        sb.AppendLine(_customer.GetShippingAddressLabel());

        return sb.ToString().TrimEnd();
    }
}
