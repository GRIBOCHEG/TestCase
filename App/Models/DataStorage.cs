using System;
using System.Linq;
using System.Collections.Generic;
using testCase;
using testCase.Services;

namespace testCase.Models
{
    public class DataStorage : IDataStorage
    {
        /// test data
        private List<Book> Books = new List<Book> {
            new Book  {
                Id = "0",
                Name = "The Book", 
                Authors = new List<Author> {
                    new Author {FirstName = "FirstName", LastName = "LastName"}
                },
                NumberOfPages = 100,
                PublishYear = 1997,
                Publisher = "ACT", 
                ISBNNumber = "99921-58-10-7"
            }
        };

        public int increment = 1;

        private object sync = new object();

        public bool UpdateBook(Book book) 
        {
            lock (sync)
            {
                var toUpd = Books.FirstOrDefault(b => b.Id == book.Id);
                if (toUpd == null)
                {
                    return false;
                }

                toUpd.Name = book.Name;
                toUpd.Authors = book.Authors;
                toUpd.NumberOfPages = book.NumberOfPages;
                toUpd.Publisher = book.Publisher;
                toUpd.PublishYear = book.PublishYear;
                toUpd.ISBNNumber = book.ISBNNumber;
            }
            return true;
        }

        public bool RemoveBook(string id)
        {
            lock (sync)
            {
                var toDel = Books.Where(b => b.Id == id).FirstOrDefault();
                if (toDel == null)
                {
                    return false;
                }

                Books.Remove(toDel);
            }
            return true;
        }

        public bool CreateBook(Book book)
        {
            lock (sync)
            {
                var existingBook = Books.FirstOrDefault(b => b.Name == book.Name || b.ISBNNumber == book.ISBNNumber);
                if (existingBook != null)
                {
                    return false;
                }

                if (book.Id == null)
                {
                    book.Id = increment.ToString();
                    increment++;
                }
                Books.Add(book);
            }
            return true;
        }

        public bool AddCover(string id,string cover)
        {
            lock (sync)
            {
                var toAdd = Books.Where(b => b.Id == id).FirstOrDefault();
                if (toAdd == null)
                {
                    return false;
                }

                toAdd.Cover = cover;
            }
            return true;
        }

        public string GetCover(string id)
        {
            lock (sync)
            {
                var toGet = Books.Where(b => b.Id == id).FirstOrDefault();
                if (toGet == null)
                {
                    return null;
                }
                return toGet.Cover;
            }
        }

        public List<Book> GetAllBooks()
        {
            lock(sync)
            {
                return Books;
            }        
        }

        public IOrderedEnumerable<Book> GetSortedByName()
        {
            lock(sync)
            {
                return Books.OrderBy(b => b.Name);
            }
        }

        public IOrderedEnumerable<Book> GetSortedByYear()
        {
            lock (sync)
            {
                return Books.OrderBy(b => b.PublishYear);
            }
        }
    }
}