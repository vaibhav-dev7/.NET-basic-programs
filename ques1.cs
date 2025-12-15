using System;

// Delegate for discount strategies
public delegate double DiscountDelegate(double price);

public class Product
{
    public int ProductId;
    public string ProductName;
    public double ProductPrice;
}

public class Customer
{
    public int CustomerId;
    public string CustomerName;
    public string CustomerType; // "occasional" or "regular"
}

public class Shopping
{
    // Festival discount = 17%
    public double FestivalDiscount(double price)
    {
        return price - (price * 0.17);
    }

    // Premium discount = 28%
    public double PremiumDiscount(double price)
    {
        return price - (price * 0.28);
    }

    public void ApplyDiscount(Product product, Customer customer)
    {
        DiscountDelegate discountMethod;

        if (customer.CustomerType.ToLower() == "occasional")
        {
            discountMethod = FestivalDiscount;
        }
        else
        {
            discountMethod = PremiumDiscount;
        }

        double finalPrice = discountMethod(product.ProductPrice);

        Console.WriteLine($"Customer: {customer.CustomerName} ({customer.CustomerType})");
        Console.WriteLine($"Product: {product.ProductName}");
        Console.WriteLine($"Original Price: Rs.{product.ProductPrice}");
        Console.WriteLine($"Final Price After Discount: Rs.{finalPrice}");
    }
}

public class Program
{
    public static void Main()
    {
        Product p = new Product { ProductId = 101, ProductName = "Smartphone", ProductPrice = 50000 };
        Customer c = new Customer { CustomerId = 1, CustomerName = "Vaibhav", CustomerType = "regular" };

        Shopping shop = new Shopping();
        shop.ApplyDiscount(p, c);
    }
}