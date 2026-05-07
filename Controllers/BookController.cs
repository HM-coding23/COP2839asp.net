using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using Bookstore.Models;

namespace Bookstore.Controllers
{
    public class BookController : Controller
    {
        private const string XmlExportFolder = "data";
        private const string XmlExportFileName = "books.xml";

        private Repository<Book> data { get; set; }
        private IWebHostEnvironment webHostEnvironment { get; set; }

        public BookController(BookstoreContext ctx, IWebHostEnvironment env)
        {
            data = new Repository<Book>(ctx);
            webHostEnvironment = env;
        }

        public RedirectToActionResult Index() => RedirectToAction("List");

        public ViewResult List(BookGridData values)
        {
            // create options for querying books
            var options = new QueryOptions<Book> { 
                Includes = "Authors, Genre",
                OrderByDirection = values.SortDirection,
                PageNumber = values.PageNumber,
                PageSize = values.PageSize
            };
            if (values.IsSortByGenre) 
                options.OrderBy = b => b.GenreId;
            else if (values.IsSortByPrice) 
                options.OrderBy = b => b.Price;
            else 
                options.OrderBy = b => b.Title;

            // create view model
            var vm = new BookListViewModel { 
                Books = data.List(options),
                CurrentRoute = values,
                TotalPages = values.GetTotalPages(data.Count)
            };

            return View(vm);
        }

        [HttpPost]
        public RedirectToActionResult PageSize(BookGridData currentRoute)
        {
            return RedirectToAction("List", currentRoute.ToDictionary());
        }

        [HttpPost]
        public RedirectToActionResult ExportToXml(BookGridData currentRoute)
        {
            var options = new QueryOptions<Book> {
                Includes = "Authors, Genre",
                OrderBy = b => b.Title
            };

            var books = data.List(options);
            var document = new XDocument(
                new XElement("Books",
                    books.Select(book =>
                        new XElement("Book",
                            new XElement("ID", book.BookId),
                            new XElement("Title", book.Title),
                            new XElement("Author", string.Join(", ", book.Authors.Select(a => a.FullName))),
                            new XElement("Price", book.Price),
                            new XElement("Category", book.Genre?.Name ?? string.Empty)
                        )
                    )
                )
            );

            string folderPath = Path.Combine(webHostEnvironment.WebRootPath, XmlExportFolder);
            Directory.CreateDirectory(folderPath);
            string filePath = Path.Combine(folderPath, XmlExportFileName);
            document.Save(filePath);

            TempData["Message"] = $"Books exported to {XmlExportFolder}/{XmlExportFileName}.";
            return RedirectToAction("List", currentRoute.ToDictionary());
        }

        public ViewResult Details(int id)
        {
            var book = data.Get(new QueryOptions<Book> {
                Where = b => b.BookId == id,
                Includes = "Authors, Genre"
            }) ?? new Book();
            return View(book);
        }
    }   
}
