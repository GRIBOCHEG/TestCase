using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using testCase.Controllers;
using testCase.Models;
using testCase.Services;

namespace Tests
{

    public class PolishTest
    {
        PolishSolver _polishSolver;
        class PolishNotationExample
        {
            public double Answer;
            public string Expression;
        }

        [SetUp]
        public void Setup()
        {
            _polishSolver = new PolishSolver();
        }

        [Test]
        public void TestCalc()
        {
            var examples = new List<PolishNotationExample>
            {
                new PolishNotationExample { Answer = 8.0, Expression = "10 4 2 / -"},
                new PolishNotationExample { Answer = 744.2739156268568, Expression = "10 5 ^ 4 18 1 - * / 10 + 2 / 5 + 6 + 7 - 8 9 / + 10 11 / -"}
            };

            foreach (var example in examples)
            {
                var res = _polishSolver.Calculate(example.Expression);
                Assert.NotNull(res);
                Assert.AreEqual(res.Value, example.Answer);
            }
        }
    }

    public class BooksTests
    {
        DataStorage dataStorage;
        BooksController booksController;

        [SetUp]
        public void Setup()
        {
            dataStorage = new DataStorage();
            booksController = new BooksController(null,dataStorage);
        }

        public List<Book> GetBooks()
        {
            return booksController.Get();
        }

        [Test]
        public void TestGetBooks()
        {
            var books = GetBooks();
            Assert.IsTrue(books.Any(i => i.Id == "0"));
        }

        //// Adding valid book
        [Test]
        public void TestAddingBook()
        {
            Book to_add = new Book
            {
                Name = "The Book #2",
                Authors = new List<Author> {
                    new Author {FirstName = "Name #2", LastName = "Name ##2"}
                },
                NumberOfPages = 1000,
                PublishYear = 1998,
                Publisher = "ACT",
                ISBNNumber = "85-359-0277-5"
            };
            booksController.Create(to_add);
            Assert.IsTrue(GetBooks().Any(book => book.Name == to_add.Name));
        }


        [Test]
        public void TestDeleteBook()
        {
            Book to_add_n_delete = new Book
            {
                Name = "The Book #3",
                Authors = new List<Author> {
                    new Author {FirstName = "Name #3", LastName = "Name ##3"}
                },
                NumberOfPages = 1000,
                PublishYear = 1998,
                Publisher = "ACT",
                ISBNNumber = "960-425-059-0"
            };
            
            booksController.Create(to_add_n_delete);
            var created_id = GetBooks().First(i => i.Name == to_add_n_delete.Name).Id;
            booksController.Delete(created_id);

            Assert.IsFalse(GetBooks().Any(i => i.Name == to_add_n_delete.Name));
        }

        [Test]
        public void TestUpdateBook()
        {
            Book to_update = new Book
            {
                Name = "The Book #4",
                Authors = new List<Author> {
                    new Author {FirstName = "Name #4", LastName = "Name ##4"}
                },
                NumberOfPages = 1000,
                PublishYear = 1998,
                Publisher = "ACT",
                ISBNNumber = "80-902734-1-6"
            };
            booksController.Create(to_update);

            var created = GetBooks().First(i => i.Name == to_update.Name);

            created.Name = "Modified Name";

            booksController.Update(created);

            var updated = GetBooks().First(i => i.Id == created.Id);
            Assert.AreEqual(updated.Name, created.Name);
        }
    }
}