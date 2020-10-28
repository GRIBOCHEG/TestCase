using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testCase.Models;

namespace testCase.Services
{
    public interface IDataStorage
    {
        bool UpdateBook(Book book);
        bool RemoveBook(string id);
        bool CreateBook(Book book);
        bool AddCover(string id, string cover);
        string GetCover(string id);
        List<Book> GetAllBooks();
        IOrderedEnumerable<Book> GetSortedByName();
        IOrderedEnumerable<Book> GetSortedByYear();
    }
}
