namespace Website.Services;

public class TestService
{
    private readonly ILogger<TestService> _logger;

    public TestService(ILogger<TestService> logger)
    {
        _logger = logger;
    }


    public void Test()
    {
        _logger.LogInformation($"The C# method {nameof(Test)} was called.");
    }




}