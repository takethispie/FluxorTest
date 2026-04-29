using Domain.OffresCommerciales.Entities.Garanties;
using Domain.OffresCommerciales.Interfaces;
using Domain.OffresCommerciales.ValueObjects;

namespace Domain.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var test = new RegroupementGaranties<GarantiePrevoyance>(
            [],
            Guid.NewGuid(),
            new Libelle("tets"),
            new Description("feregzerg")
        );
        Assert.Pass();
    }
}
