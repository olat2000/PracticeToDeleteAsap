using Microsoft.Extensions.Configuration;

namespace PracticeToDeleteAsap.Urls;

public static class TestUrls
{
    public const string calculatorurl = "https://specflowoss.github.io/Calculator-Demo/Calculator.html";

    public const string demoqaurl = "https://demoqa.com";
}

public class readFromConfig
{
    private IConfigurationRoot _config;
    public readFromConfig()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("settings.json");
        _config = builder.Build();
    }

    public string GetJsonData(string key) => _config[key]!;
}
