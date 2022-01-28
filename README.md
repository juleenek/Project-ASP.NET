# Centrum Adopcyjne Zwierząt

Centrum Adopcyjne Zwierząt - jest to projekt, wykonany na potrzebę zaliczenia labolatoriów "Programowanie w środowisku ASP.NET"

## Sposób uruchomienia

- Wymagana baza Microsoft SQL Server (w dowolnej wersji)
- Zainstalowanie oprogramowania Visual Studio 2019
- Sklonowanie repozytorium CentrumAdopcyjne
- W pliku appsettings.json podać connection string do bazy danych

```
    "ConnectionString": "DATA SOURCE=(nazwa serwera);Integrated Security=true;DATABASE=CentrumAdopcyjneZwierzat"
```
- Wykonać instrukcje  *update-database* za pomocą **Package Manager Console** w zakładce *Tools > NuGet Package Menager > Package Menager Console*
- Uruchomić projekt

## Działanie aplikacji

Jest to aplikacja Centrum Adopcyjnego Zwierząt. Na stronie, należy dokonać rejestracji bądź logowania aby mieć dostęp do wszystkich dostępnych zwierząt oraz ich szczegółowych informacji. Przy pierwszym uruchomieniu aplikacji lista ta będzię pusta - musi ją stworzyć administrator. 

Administrator ma dostęp do wszystkich informacji dotyczących Centrum oraz aplikacji. Administrator ma wgląd na wszystkie zwierzęta: może tworzyć nowe, edytować oraz usuwać. Na tej samej zasadzie działają panele dla Wolontariuszy oraz Placówek Centrum. Administrator również, ma dostęp do wszystkich użytkowników.

## Dostęp do konta administratora

Aby móc zalogować się jako administrator, należy zalogować się na konto: 

```
    login: admin123
    hasło: @dminPassword123
```

## Relacje w aplikacji 

1. Jedna placówka (Box), wiele psów (Dog) - relacja jeden do wielu 
2. Jeden pies, jeden wolontariusz (Volunteer) - relacja jeden do jednego
3. Wiele wolontariuszy, wiele placówek (w placówce może być wiele wolontariuszy, wolontariusze mogą być w wielu placówkach) - relacja wiele do wielu

## W skład aplikacji znajdują się:

- [x] Formularze z walidacją,
- [x] Utrwalanie danych za pomocą EF, a aplikacja powinna zawierać co najmniej trzy encje występujące w związkach,
- [x] Wykorzystanie DI i zastosowanie dwóch implementacji jednego interfejsu,
- [x] Autoryzacja użytkowników,
- [x] WebAPI REST odnoszące się do głównej encji,
- [x] Testy jednostkowe najważniejszych funkcji aplikacji.


