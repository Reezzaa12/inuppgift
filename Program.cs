using Microsoft.AspNetCore.Mvc.Formatters.Xml;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyHeader())
);

var app = builder.Build();


app.MapGet("/", () => "/(av)koda?text={dintext}");
app.MapGet("/koda", (string text) => CaesarKodar(text));
app.MapGet("/avkoda", (string text) => CaesarAvkoda(text));
app.Run();

//metod som tar emot en sträng och returnerar en krypterad sträng
static string CaesarKodar(string input)
{
    //variabel som lagrar nyckeln
    int nyckel = 3;

    // En variabel som lagrar den krypterade strängen
    string output = "";

    // Loopa igenom varje tecken i input
    foreach (char c in input)
    {
        // Om tecknet är en stor bokstav
        if (char.IsUpper(c))
        {
            // Lägg till det förskjutna tecknet till output
            output += (char)((c - 'A' + nyckel) % 26 + 'A');
        }
        // Om tecknet är en liten bokstav
        else if (char.IsLower(c))
        {
            // Lägg till det förskjutna tecknet till output
            output += (char)((c - 'a' + nyckel) % 26 + 'a');
        }
        // Om tecknet inte är en bokstav
        else
        {
            // Lägg till tecknet oförändrat till output
            output += c;
        }
    }

    // Returnera den krypterade strängen
    return $"Nya texten är:{output}";
}






// En metod som tar emot en krypterad sträng och returnerar en avkrypterad sträng
static string CaesarAvkoda(string input)
{
    // En variabel som lagrar nyckeln
    int nyckel = 3;

    // En variabel som lagrar den avkrypterade strängen
    string output = "";

    // Loopa igenom varje tecken i input
    foreach (char c in input)
    {
        // Om tecknet är en stor bokstav
        if (char.IsUpper(c))
        {
            // Lägg till det förskjutna tecknet till output
            output += (char)((c - 'A' - nyckel + 26) % 26 + 'A');
        }
        // Om tecknet är en liten bokstav
        else if (char.IsLower(c))
        {
            // Lägg till det förskjutna tecknet till output
            output += (char)((c - 'a' - nyckel + 26) % 26 + 'a');
        }
        // Om tecknet inte är en bokstav
        else
        {
            // Lägg till tecknet oförändrat till output
            output += c;
        }
    }

    // Returnera den avkrypterade strängen
    return $" Nya texten är:{output}";
}