using System.Collections.Generic; 
using System.Text; 

public class Order
{
    
    private List<Product> _products; 
    private Customer _customer;     
    public Order(List<Product> products, Customer customer)
    {
        _products = products;
        _customer = customer;
    }
    public double GetTotalOrderCost()
    {
        double totalProductsCost = 0;
        foreach (Product product in _products)
        {
            totalProductsCost += product.GetTotalCost();
        }

        double shippingCost = _customer.LivesInUSA() ? 5.00 : 35.00;

        return totalProductsCost + shippingCost;
    }
    public string GetPackingLabel()
    {
        StringBuilder packingLabel = new StringBuilder();
        packingLabel.AppendLine("--- Packing Label ---");
        foreach (Product product in _products)
        {
            packingLabel.AppendLine($"Product: {product.GetName()} (ID: {product.GetProductId()})");
        }
        return packingLabel.ToString();
    }

    public string GetShippingLabel()
    {
        StringBuilder shippingLabel = new StringBuilder();
        shippingLabel.AppendLine("--- Shipping Label ---");
        shippingLabel.AppendLine($"Customer Name: {_customer.GetName()}");
        shippingLabel.AppendLine("Customer Address:");
        shippingLabel.AppendLine(_customer.GetAddress().GetFullAddressString());
        return shippingLabel.ToString();
    }
}