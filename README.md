# Kotkangrilli Backend v2

Kotkangrilli Backend on ASP.NET Core -pohjainen sovellus, joka tarjoaa RESTful API:n Kotkangrilli-sovellukselle. Tämä projekti käyttää Entity Framework Corea tietokannan hallintaan ja tarjoaa erilaisia toiminnallisuuksia kotkangrilli.app -sovellukselle.

---

## Asennus

1. Kloonaa repository:

```
git clone https://github.com/pietikainen/kotkangrilli_backend_v2.git
```

2. Asenna riippuvuudet:

`dotnet restore`

3. Määritä tietokantayhteys:  Muokkaa appsettings.json-tiedostoa ja lisää tietokantayhteyden tiedot:

```
{
"ConnectionStrings": {
"DefaultConnection": "Host=localhost;Database=kotkangrilli;Username=käyttäjä;Password=salasana"
   }
}
```

4. Suorita tietokantamigraatiot:

`dotnet ef database update`

5. Käynnistä sovellus:

`dotnet run`

---

## Projektin rakenne

kotkangrilli_backend_v2/
├── Controllers/       # Sovelluslogiikka
│   ├── UserController.cs
│   └── GameController.cs
├── Configurations/    # Entiteettien konfiguraatiot
│   ├── UserConfiguration.cs
│   └── GameConfiguration.cs
├── Data/              # Tietokantayhteys
│   └── AppDbContext.cs
├── Models/            # Tietomallit
│   ├── User.cs
│   └── Game.cs
├── Migrations/        # Tietokantamigraatiot
├── Properties/        # Projektin ominaisuudet
├── appsettings.json   # Konfiguraatiotiedosto
├── Program.cs         # Sovelluksen pääsisäänkäynti
└── README.md          # Dokumentaatio

### Teknologiat:

* .NET 9.0.102
* ASP.NET Core: Web-sovelluskehys.
* PostgreSql: Tietokanta
* Entity Framework Core: ORM (Object-Relational Mapping) tietokannan hallintaan.
* Swagger: API-dokumentaatio.
