using Xunit;

namespace Website.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var model = new WeatherForecast()
        {
            Summary = "Testing",
            Date = System.DateTime.Now,
            TemperatureC = 55
        };

        var a = model.TemperatureF;

        Assert.NotNull(model);
        Assert.Equal(130, model.TemperatureF);
        Assert.Equal("Testing", model.Summary);



    }
}