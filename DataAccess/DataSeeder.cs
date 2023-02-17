using Core.Entites;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace DataAccess;

public static class DataSeeder
{
    public static void Books(this ModelBuilder modelBuilder)
    {
        string cover = "iVBORw0KGgoAAAANSUhEUgAACgAAAAarAgMAAAC0QRgSAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6Jg" +
            "AAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAADFBMVEUAW7uAmF3/1QD///9lPUezAAAAAWJLR0QDEQxM8gAAAAd0SU1FB+YKFQ8iEJDn/EoAAAgHSURB" +
            "VHja7dIBCQAACASxL2lJU1pCEGSLcFwCAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
            "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
            "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
            "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
            "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
            "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAOwoOJSGQwbEgBgQDIgB" +
            "wYAYEAyIAcGAGBAMiAHBgBgQDIgBwYAYEAyIAcGAGBAMiAHBgBgQDIgBwYAYEAyIATEgGBADggExIBgQA4IBMSAYEAOCATEgGBADggExIBgQA4IBMSAYEAOCATEgGB" +
            "ADggExIBgQA4IBMSAGBANiQDAgBgQDYkAwIAYEA2JAMCAGBANiQDAgBgQDYkAwIAYEA2JAMCAGBANiQDAgBgQDYkAMKAEGxIBgQAwIBsSAYEAMCAbEgGBADAgGxIBg" +
            "QAwIBsSAYEAMCAbEgGBADAgGxIBgQAwIBsSAYEAMiAHBgBgQDIgBwYAYEAyIAcGAGBAMiAHBgBgQDIgBwYAYEAyIAcGAGBAMiAHBgBgQDIgBwYAYEAyIATEgGBADgg" +
            "ExIBgQA4IBMSAYEAOCATEgGBADggExIBgQA4IBMSAYEAOCATEgGBADggExIBgQA2JAMCAGBANiQDAgBgQDYkAwIAYEA2JAMCAGBANiQDAgBgQDYkAwIAYEA2JAMCAG" +
            "BANiQDAgBgQDYkAMCAbEgGBADAgGxIBgQAwIBsSAYEAMCAbEgGBADAgGxIBgQAwIBsSAYEAMCAbEgGBADAgGxIBgQAyIAcGAGBAMiAHBgBgQDIgBwYAYEAyIAcGAGB" +
            "AMiAHBgBgQDIgBwYAYEAyIAcGAGBAMiAHBgBgQA4IBMSAYEAOCATEgGBADggExIBgQA4IBMSAYEAOCATEgGBADggExIBgQA4IBMSAYEAOCATEgGBADYkAwIAYEA2JA" +
            "MCAGBANiQDAgBgQDYkAwIAYEA2JAMCAGBANiQDAgBgQDYkAwIAYEA2JAMCAGxIASYEAMCAbEgGBADAgGxIBgQAwIBsSAYEAMCAbEgGBADAgGxIBgQAwIBsSAYEAMCA" +
            "bEgGBADAgGxIAYEAyIAcGAGBAMiAHBgBgQDIgBwYAYEAyIAcGAGBAMiAHBgBgQDIgBwYAYEAyIAcGAGBAMiAHBgBgQA4IBMSAYEAOCATEgGBADggExIBgQA4IBMSAY" +
            "EAOCATEgGBADggExIBgQA4IBMSAYEAOCATEgBgQDYkAwIAYEA2JAMCAGBANiQDAgBgQDYkAwIAYEA2JAMCAGBANiQDAgBgQDYkAwIAYEA2JAMCAGxIBgQAwIBsSAYE" +
            "AMCAbEgGBADAgGxIBgQAwIBsSAYEAMCAbEgGBADAgGxIBgQAwIBsSAYEAMCAbEgBgQDIgBwYAYEAyIAcGAGBAMiAHBgBgQDIgBwYAYEAyIAcGAGBAMiAHBgBgQDIgB" +
            "wYAYEAyIATEgGBADggExIBgQA4IBMSAYEAOCATEgGBADggExIBgQA4IBMSAYEAOCATEgGBADggExIBgQA4IBMSAGBANiQDAgBgQDYkAwIAYEA2JAMCAGBANiQDAgBg" +
            "QDYkAwIAYEA2JAMCAGBANiQDAgBgQDYkAMKAEGxIBgQAwIBsSAYEAMCAbEgGBADAgGxIBgQAwIBsSAYEAMCAbEgGBADAgGxIBgQAwIBsSAYEAMiAHBgBgQDIgBwYAY" +
            "EAyIAcGAGBAMiAHBgBgQDIgBwYAYEAyIAcGAGBAMiAHBgBgQDIgBwYAYEAyIATEgGBADggExIBgQA4IBMSAYEAOCATEgGBADggExIBgQA4IBMSAYEAOCATEgGBADggE" +
            "xIBgQA2JAMCAGBANiQDAgBgQDYkAwIAYEA2JAMCAGBANiQDAgBgQDYkAwIAYEA2JAMCAGBANiQDAgBgQDYkAMCAbEgGBADAgGxIBgQAwIBsSAYEAMCAbEgGBADAgGx" +
            "IBgQAwIBsSAYEAMCAbEgGBADAgGxIBgQAyIAcGAGBAMiAHBgBgQDIgBwYAYEAyIAcGAGBAMiAHBgBgQDIgBwYAYEAyIAcGAGBAMiAHBgBgQA4IBMSAYEAOCATEgGBA" +
            "DggExIBgQA4IBMSAYEAOCATEgGBADggExIBgQA4IBMSAYEAOCATEgGBADYkAwIAYEA2JAMCAGBANiQDAgBgQD8skAm6xEiJfGzGsAAAAldEVYdGRhdGU6Y3JlYXRlA" +
            "DIwMjItMTAtMjFUMTU6MzQ6MTYrMDA6MDCCrDTYAAAAJXRFWHRkYXRlOm1vZGlmeQAyMDIyLTEwLTIxVDE1OjM0OjE2KzAwOjAw8/GMZAAAAABJRU5ErkJggg==";

        string content = "Sed ut perspiciatis, unde omnis iste natus error sit voluptatem accusantium doloremque laudantium," +
           " totam rem aperiam eaque ipsa, quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt," +
           " explicabo. Nemo enim ipsam voluptatem, quia voluptas sit, aspernatur aut odit aut fugit, sed quia consequuntur" +
           " magni dolores eos, qui ratione voluptatem sequi nesciunt, neque porro quisquam est, qui dolorem ipsum, quia dolor " +
           "sit amet, consectetur, adipisci[ng] velit, sed quia non numquam [do] eius modi tempora inci[di]dunt, ut labore et dolore" +
           " magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam," +
           " nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit, qui in ea voluptate velit esse, quam nihil" +
           " molestiae consequatur, vel illum, qui dolorem eum fugiat, quo voluptas nulla pariatur? ";

        modelBuilder.Entity<Book>().HasData(new[]
        {
            new Book {Id = 1, Title = "Title1", Cover = cover, Content=content, Author="Author1",Genre="horror"},
            new Book {Id = 2, Title = "Title2", Cover = cover, Content=content, Author="Author2",Genre="horror"},
            new Book {Id = 3, Title = "Title3", Cover = cover, Content=content, Author="Author3",Genre="horror"},
            new Book {Id = 4, Title = "Title4", Cover = cover, Content=content, Author="Author4",Genre="horror"},
            new Book {Id = 5, Title = "Title5", Cover = cover, Content=content, Author="Author5",Genre="horror"},
            new Book {Id = 6, Title = "Title6", Cover = cover, Content=content, Author="Author6",Genre="romantic"},
            new Book {Id = 7, Title = "Title7", Cover = cover, Content=content, Author="Author7",Genre="romantic"},
            new Book {Id = 8, Title = "Title8", Cover = cover, Content=content, Author="Author8",Genre="romantic"},
            new Book {Id = 9, Title = "Title9", Cover = cover, Content=content, Author="Author9",Genre="romantic"},
            new Book {Id = 10, Title = "Title10", Cover = cover, Content=content, Author="Author10",Genre="romantic"}
        });
    }

    public static void Ratings(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Rating>().HasData(new[]
      {
          new Rating {Id = 1, BookId=1, Score=5},
          new Rating {Id = 2, BookId=1, Score=3},
          new Rating {Id = 3, BookId=1, Score=5},
          new Rating {Id = 4, BookId=1, Score=1}
        });
    }

    public static void Reviews(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Review>().HasData(new[]
      {
          new Review {Id = 1, BookId=1, Message="Message1", Reviewer="Reviewer1"},
          new Review {Id = 2, BookId=1, Message="Message2", Reviewer="Reviewer2"},
          new Review {Id = 3, BookId=1, Message="Message3", Reviewer="Reviewer3"},
          new Review {Id = 4, BookId=1, Message="Message4", Reviewer="Reviewer4"},
          new Review {Id = 5, BookId=1, Message="Message5", Reviewer="Reviewer5"},
          new Review {Id = 6, BookId=1, Message="Message6", Reviewer="Reviewer6"},
          new Review {Id = 7, BookId=1, Message="Message7", Reviewer="Reviewer7"},
          new Review {Id = 8, BookId=1, Message="Message8", Reviewer="Reviewer8"},
          new Review {Id = 9, BookId=1, Message="Message9", Reviewer="Reviewer9"},
          new Review {Id = 10, BookId=1, Message="Message10", Reviewer="Reviewer10"},
        });
    }
}
