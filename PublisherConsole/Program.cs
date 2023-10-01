// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PublisherData;
using PublisherDomain;




PubContext _context = new PubContext();





//GetAuthors();
//AddAuthor();
//GetAuthors();

//AddAuthorsWithBooks();
//GetAuthorWithBooks();

//QueringFilter();
//AddSomeMoreAuthors();
//SkipAndTakeAuthors();

//SortAuthors();

//RetrieveAndUpdateAuthor();

//RetrieveAndUpdateMultipleAuthors();

//CoordinatedRetrieveAndUpdateAuthor();

//InsertNewAuthorWithNewBook();

//AddNewBookToExistingAuthorInMemory();

EagerLoadingWithAuthors();

void EagerLoadingWithAuthors()
{
    var authors = _context.Authors.Include(a => a.Books).ToList();
    var dd = _context.Authors.Where(a => a.Lastname == "Lerman").Include(a => a.Books).ToList();
    authors.ForEach(a =>
    {
        Console.WriteLine( $"{a.Firstname}({a.Books.Count})");
        a.Books.ForEach(b => Console.WriteLine("      " + b.Title));
    });

}

void AddNewBookToExistingAuthorInMemory()
{

    //var Book = new Book
    //{
    //    Title = "Test",
    //    PublishDate = DateTime.Now,
    //    authorId = 6
    //}
    //_context.Books.Add(Book);


    var author = _context.Authors.FirstOrDefault(a => a.Lastname == "Oeki");
    if (author != null)
    {
        author.Books.Add(new Book { Title = " Wool", PublishDate = new DateTime(2012, 1, 1), authorId = 6 });

    }
    _context.SaveChanges();
}

void InsertNewAuthorWithNewBook()
{
    var author = new Author { Firstname = "Lybda", Lastname = "Rutledge" };

    author.Books.Add(new Book { Title = "West With Giraffes", PublishDate = new DateTime(2023, 10, 1) });

    _context.Authors.Add(author);
    _context.SaveChanges();

}


void BulkUpdate()
{
    var newAuthors = new Author[]
    {
        new Author{Firstname ="Tsitsi ", Lastname = "Dangaremga"},
        new Author{Firstname = "Lisa", Lastname ="see"},
        new Author{Firstname = "zhang" , Lastname = "ling"},
        new Author{Firstname = "marlynne", Lastname = "Robnoson"}
    };

    _context.Authors.AddRange(newAuthors);
    var book = _context.Books.Find(2);
    book.Title = "Programing entityframwork 2nd Edition ";

    _context.SaveChanges();

}

void InsertMultipleAuthors()
{
    _context.Authors.AddRange(
        new Author { Firstname = "dail", Lastname = "carnigy" },
        new Author { Firstname = "sofia", Lastname = "segovia" },
        new Author { Firstname = "hugh", Lastname = "howey" },
        new Author { Firstname = "Isabelle", Lastname = "Allende" }
    );
    _context.SaveChanges();
}

void InsertMultipleAuthorsPassedIn(List<Author> AddedAuuthors)
{
    _context.Authors.AddRange(AddedAuuthors);
    _context.SaveChanges();
}


void DeleteAnAuthor()
{
    var extra = _context.Authors.Find(2);
   if(extra != null)
    {
        _context.Authors.Remove(extra);
        _context.SaveChanges();
    }
}
void CoordinatedRetrieveAndUpdateAuthor()
{
    var author = FindThatAuthor(3);
    if(author?.Firstname == "mahmoud")
    {
        author.Firstname = "mahmod";
        SaveThatAuthor(author);
    }
}

Author FindThatAuthor(int authorId)
{
    using var shortLivedpubContext = new PubContext();

    return shortLivedpubContext.Authors.Find(authorId);
}

void SaveThatAuthor(Author author)
{
    using var shortLivedpubContext = new PubContext();
    shortLivedpubContext.Authors.Update(author);
    shortLivedpubContext.SaveChanges();
}
void VariousOperations()
{
    var author = _context.Authors.Find(5);
    author.Lastname = "ayman";

    var newAuthor = _context.Authors.Add(new Author { Firstname = "samy", Lastname = "Mohamed" });

    _context.SaveChanges();
}

void RetrieveAndUpdateMultipleAuthors()
{
    var authors = _context.Authors.Where(a => a.Lastname.StartsWith("s")).ToList();
    //var y = authors.Find(x => x.Lastname == "Salah");
    foreach(var Author in authors)
    {
        Author.Lastname = "gad";
    }


    //Console.WriteLine("Before" + _context.ChangeTracker.DebugView.ShortView);
    ////_context.ChangeTracker.DetectChanges();
    //Console.WriteLine("After" + _context.ChangeTracker.DebugView.ShortView);

    _context.SaveChanges();

}

void RetrieveAndUpdateAuthor()
{
    var author = _context.Authors.FirstOrDefault(a => a.Firstname == "mahmoud" && a.Lastname == "salah");
    if(author != null)
    {
        author.Firstname = "julia";
        var count = _context.SaveChanges();
    }
}
void RetrieveStatesOfEntities()
{
    var author = _context.Authors.First();


    EntityEntry<Author>? sd  = _context.Add(new Author { Firstname = "morsy" });


    var x = _context.ChangeTracker.Entries().ToList();
    //var x = _context.ChangeTracker.Entries();
}
void SortAuthors()
{
    var sortedAuthorsByLastName = _context
        .Authors.OrderBy(a => a.Lastname)
        .ThenBy(a => a.Firstname)
        .ToList();
    sortedAuthorsByLastName.ForEach(a => Console.WriteLine(a.Lastname + "," + a.Firstname));

    var authorsDescending = _context.Authors
        .OrderByDescending(a => a.Lastname)
        .ThenByDescending(a => a.Firstname).ToList();

    Console.WriteLine("this are in descending order** ");
    authorsDescending.ForEach(a => Console.WriteLine(a.Lastname + ", " + a.Firstname));

    var combined = _context.Authors
        .Where(a => a.Firstname == "mahmoud")
        .OrderBy(a => a.Lastname).ToList();
    combined.ForEach(a => Console.WriteLine(a.Lastname));

}

void AddSomeMoreAuthors()
{
    _context.Authors.Add(new Author { Firstname = "mahmoud", Lastname = "salah" });
    _context.Authors.Add(new Author { Firstname = "ahmed", Lastname = "salah" });
    _context.Authors.Add(new Author { Firstname = "mohamed", Lastname = "okba" });
    _context.Authors.Add(new Author { Firstname = "abdo", Lastname = "morsy" });
    _context.Authors.Add(new Author { Firstname = "mohamed", Lastname = "salah" });
    _context.SaveChanges();

}

void SkipAndTakeAuthors()
{
     var  GroupSize = 2;
    for(int i = 0; i < 5; i++)
    {
        var authors = _context.Authors.Skip(GroupSize * i).Take(GroupSize).ToList();
        Console.WriteLine($"Group of {i}:");

        foreach(var auth in authors) 
            Console.WriteLine(auth.Firstname + auth.Lastname);
    }
}


void QueringFilter()
{
    var author = _context.Authors.FirstOrDefault(a => a.Firstname == "mahmoud");
}

void AddAuthorsWithBooks()
{
    var author = new Author { Firstname = "abdo" , Lastname = "morsy" };

    author.Books.Add(new Book
    {
        Title = "ElhashaElnafsia",
        PublishDate =  new DateTime(2020, 8, 5)
    });

    author.Books.Add(new Book
    {
        Title = "Deep Work",
        PublishDate = new DateTime(2015, 8, 5)
    });

    using var context = new PubContext();
    
    context.Authors.Add(author);

    context.SaveChanges();
}





void GetAuthorWithBooks()
{

    var context = new PubContext();
    var athors  = context.Authors.Include(a => a.Books).ToList();

    foreach (var ath in athors)
    {

        Console.WriteLine(ath.Firstname + " " + ath.Lastname );
        foreach (var book in ath.Books)
            Console.WriteLine("**" + book.Title);

    }
}






void AddAuthor()
{
    var author = new Author { Firstname = "mahmoud", Lastname = "salah" };
    using var context = new PubContext();
    context.Authors.Add(author);
    context.SaveChanges();
}

void GetAuthors()
{
    using var context = new PubContext();
    var authors = context.Authors.ToList();

    foreach (var auth in authors)
    {
        Console.WriteLine(auth.Firstname + " " + auth.Lastname);
    }

}