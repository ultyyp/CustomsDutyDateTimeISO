using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/customs_duty", (int? price) => GetCustomsDuty(price));
app.MapGet("/date_now", (string? language) => GetDate(language));



string GetCustomsDuty(int? price)
{
    if(price == null)
    {
        return string.Empty;
    }

    if(price < 200)
    {
        return "Your price was less than 200!";
    }

    return ("Your customs duty is " + ((price - 200) * 0.15).ToString());
    
}

string GetDate(string? language)
{
    if(language == null)
    {
        return string.Empty;
    }

    CultureInfo culture = new CultureInfo(language);
    return DateTime.Now.ToString(culture.DateTimeFormat.LongDatePattern, culture);
}



app.Run();
