using Xunit;
using DDDShop.Domain.Aggregates.BillingOrders;
using System;
using DDDShop.Domain.Aggregates.BillingOrders.Enums;

namespace DDDShop.Tests.Aggregates.BillingOrders;

public class BillingOrderTests
{
    [Fact]
    public void CreateBillingOrder_ShouldSetCorrectData()
    {
        var billing = BillingOrder.Create(Guid.NewGuid(), Guid.NewGuid(), 120000);

        Assert.Equal(PaymentStatus.Pending, billing.Status);
    }

    [Fact]
    public void MarkAsPaid_ShouldChangeStatusToPaid()
    {
        var billing = BillingOrder.Create(Guid.NewGuid(), Guid.NewGuid(), 100000);

        billing.MarkAsPaid();

        Assert.Equal(PaymentStatus.Paid, billing.Status);
    }

}
