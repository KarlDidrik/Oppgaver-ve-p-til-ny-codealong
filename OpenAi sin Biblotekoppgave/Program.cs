using OpenAi_sin_Biblotekoppgave;


Library library =  new Library();

library.AddBook(new Book("No Longer Human", "Osamu Dazai" ));
library.AddBook(new Book("Ingen Kan Hjelpe Meg", "Ingvar Ambjørnsen"));
library.AddBook(new Book("School Girl", "Osamu Dazai"));

library.AddBorrower("Dodda Malaban");
library.AddBorrower("Kron Gundersen");

library.BorrowBook("Dodda Malaban", "No Longer Human");
library.BorrowBook("Kron Gundersen", "Ingen Kan Hjelpe Meg");

library.DisplayAvailableBooks();
library.DisplayBorrowersAndBooks();

library.ReturnBook("Dodda Malaban", "No Longer Human");

