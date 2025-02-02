using Spectre.Console;

namespace TCSA.OOP.LibraryManagementSystem;

internal class BooksController
{
    
    
    
    internal void ViewBooks()
    {
        AnsiConsole.MarkupLine("[yellow]List of Books:[/]");

        foreach (string book in MockDatabase.books)
        {
            AnsiConsole.MarkupLine($"- [cyan]{book}[/]");
        }

        AnsiConsole.MarkupLine("Press any key to  continue.");
        Console.ReadKey();
    }

    internal void AddBook()
    {
        string title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the bookto add:");

        if (MockDatabase.books.Contains(title))
        {
            AnsiConsole.MarkupLine("[red]This book already exists.[/]");
        }
        else
        {
            MockDatabase.books.Add(title);
            AnsiConsole.MarkupLine("[green]Book added successfully![/]");
        }

        AnsiConsole.MarkupLine("Press any key to continue.");
        Console.ReadKey();
    }

    internal void DeleteBook()
    {
        if (MockDatabase.books.Count == 0)
        {
            AnsiConsole.MarkupLine("[red]No books available to delete");
            Console.ReadKey();
            return;
        }

        string bookToDelete = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Select a [red]book[/] to delete:")
            .AddChoices(MockDatabase.books));
        if (MockDatabase.books.Remove(bookToDelete))
        {
            AnsiConsole.MarkupLine("[red]Book deleted succcessfully![/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Book not found.[/]");
        }

        AnsiConsole.MarkupLine("Press any key to continue.");
    }

}
