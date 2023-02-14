# MyLibraryApp
Dokumentacja aplikacji MyLibraryApp


Projekt tworzyła grupa "Obóz Pracy Natalii bez myślnika" w składzie:
Natalia Chamier Gliszczyńska
Roger Alkiewicz


Spis Treści:
1. Konfiguracja przed uruchomieniem
2. Role użytkownika 
3. Funkcjonalności ogólne
4. Funkcjonalności Member
5. Funkcjonalności Admin
6. Dane logowania kont początkowych


1. Konfiguracja przed uruchomieniem:
Co zrobić aby uruchomić aplikacje na swoim komputerze:
- W Visual Studio w zakładce Package Manager Console wpisać komendę: "update-database"
Aplikacja powinna być gotowa do uruchomienia. 
W przypadku problemów proszę wykonać następujące czynności:
- za pomocą NuGetManagera zaktualizować pakiety znajdujące się w Eksplorerze Solucji: Zależności -> Pakiety do wersji 6.0.5.
  - w przypadku gdyby folder był pusty oto następujące pakiety:
    - Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
    - Microsoft.EntityFrameworkCore
    - Microsoft.EntityFrameworkCore.SqlServer
    - Microsoft.EntityFrameworkCore.Tools
    - Microsoft.Extensions.Identity.Core
- Sprawdzić wersję .NET SDK (Wymagana wersja 6)
Aby łatwo to sprawdzić w CMD wystarczy wpisać komendę "dotnet sdk check"
- Zaktualizować Visual Studio do wersji 2022. Dodatkowo należy zadbać, aby na komputrze znajdowały się konkretne składniki.
  - Można je doinstalować za pomocą funkcji "Modyfikuj" w programie Visual Studio Installer. A oto składniki:
    - Opracowywanie zawartośći dla platformy ASP.NET Core
    - Programowanie aplikacji klasycznych dla platformy .NET
    - Magazynowanie i przetwarzanie danych
  
  
2. Role użytkownika: 
Aplikacja posiada dwie 3 dla użytkowników. Są to "Admin", "Member" i użytkownik niezalogowany. 
- Niezalogowany użytkownik ma dostęp do str. głównej, zakładki Privacy i formularzy logowania i rejestracji
- Member posiada podstawowe funkcje pozwalające na korzystanie z aplikacji
- Admin to rola administratora. Ma on uprawnienia do zarządzania zasobami biblioteki


3. Funkcjonalności ogólne:
- Aplikacja łączy się z bazą danych MySQL, na której wykonuje podstawowe polecenia CRUD
- Aplikacja pozwala na rejestrowanie i logowanie się użytkowników
- Aplikacja rozpoznaje role użytkowników (Admin, Member, niezalogowany) poprzez claimy (żadania) zawarte w ciasteczkach
- Aplikacja ogranicza dostęp do stron, do których dana rola nie powinna mieć dostępu za pomocą mechanizmu autentykacji i tzw. "wytycznym"
- Aplikacja stosuje metodę hashowania haseł w celu zwiększenia bezpieczeństwa danych użytkowników


4. Funkcjonalności Member:
- Dostęp do wszystkiego, co użytkownik niezalogowany
- Dostęp do zbiorów biblioteki
- Dostęp do informacji o koncie
- Wypożyczenie książek
- Zwrotu książek


5. Funkcjonalności Admin:
- Dostęp do wszystkiego, co użytkownik niezalogowany i Member
- Dodawanie nowych książek do zbioru
- Edytowanie książek
- Usuwanie książek
- Rejestracja nowego konta administratora (Zakładka Account -> Register Admin)


6. Dane logowania kont początkowych:
- Konto Admin:
  - Email: admin@mylibrary.com
  - Hasło: admin
- Konto Member:
  - Email: member@mylibrary.com
  - Hasło: member

  
