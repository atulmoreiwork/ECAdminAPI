using System.ComponentModel.DataAnnotations;

namespace ECAdminAPI.Models;

public class OrderDTO
{
    public int CustomerId {get;set;}
    public int ShippingAddressId {get;set;}    
    public string PaymentType {get;set;}
    public string PaymentTransactionId {get;set;}
    public List<Carts> CartItems {get;set;}
    public OrderShippingAddress OrderShippingAddress {get;set;}
}

public class Carts
{
    public int CartId { get; set; } // Primary Key
    public int CustomerId { get; set; } // Foreign Key - User
    public int ProductId { get; set; } // Foreign Key - Product (nullable)
    public int ProductVariantId { get; set; } // Foreign Key - Product Variant (nullable)
    public int Quantity { get; set; } // Quantity of items in the cart

    // Navigation Properties
    public Product Product { get; set; }
    public ProductVariant ProductVariant { get; set; }
}
public class ShippingAddress
{
    public int ShippingAddressesId { get; set; } // Primary Key
    public int CustomerId { get; set; } // Foreign Key - User
    public string FullAddress { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
    public int Flag  { get;set;}

    // Navigation Property
    public User User { get; set; }
}
public class Order
{
    public int OrderId { get; set; } // Primary Key
    public string OrderNumber { get; set; } // Unique Order Number
    public string OrderName { get; set; }
    public int CustomerId { get; set; } // Foreign Key - User
    public float TotalAmount { get; set; } = 1500f;
    public float DiscountAmount { get; set; } = 100f;
    public float GrossAmount { get; set; } = 1400f;
    public float ShippingAmount { get; set; } = 50f;
    public float NetAmount { get; set; } = 1450f;
    public OrderStatus Status { get; set; } // Enum - placed / processing / shipping / delivered
    public PaymentStatus PaymentStatus { get; set; } // Enum - paid / not paid
    public PaymentType PaymentType { get; set; } // Enum - netbanking / upi / cod
    public string PaymentTransactionId { get; set; } // Payment transaction ID (optional)

    public int Flag { get; set; }
    public string Row { get; set; }
    public string TotalRowCount { get; set; }

    // Navigation Properties
    public List<OrderItem> OrderItems { get; set; }
    public OrderShippingAddress OrderShippingAddress { get; set; }
    public User User { get; set; }
}
public class OrderItem
{
    public int OrderItemId { get; set; } // Primary Key
    public int OrderId { get; set; } // Foreign Key - Order
    public int ProductId { get; set; } // Foreign Key - Product
    public int ProductVariantId { get; set; } // Foreign Key - Product Variant (nullable)
    public string ProductName { get; set; }
    public string Color { get; set; } // Nullable
    public string Size { get; set; } // Nullable
    public float Price { get; set; }
    public int Quantity { get; set; }
    public float TotalAmount { get; set; }

    // Navigation Properties
    public Order Order { get; set; }
    public Product Product { get; set; }
    public ProductVariant ProductVariant { get; set; }
}
public class OrderShippingAddress
{
    public int OrderShippingAddressId { get; set; } // Primary Key
    public int OrderId { get; set; } // Foreign Key - Order
    public int ShippingAddressId { get; set; } // Foreign Key - Shipping Address
    public string FullAddress { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
    public int Flag {get;set;}
    // Navigation Properties
    public Order Order { get; set; }
    public ShippingAddress ShippingAddress { get; set; }
}
public class Offer
{
    public int Id { get; set; } // Primary Key
    public string CouponCode { get; set; } // Unique
    public DiscountType DiscountType { get; set; } // Enum - fixed / rate
    public float DiscountValue { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Description { get; set; }
    public OfferStatus Status { get; set; } // Enum - active / inactive
}
public enum OrderStatus
{
    Placed,
    Processing,
    Shipping,
    Delivered
}
public enum PaymentStatus
{
    Paid,
    NotPaid
}
public enum PaymentType
{
    NetBanking,
    UPI,
    COD
}
public enum DiscountType
{
    Fixed,
    Rate
}
public enum OfferStatus
{
    Active,
    Inactive
}

