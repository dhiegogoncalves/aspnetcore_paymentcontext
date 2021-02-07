using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentQueriesTests
    {
        // Red, Green, Refactor
        private IList<Student> _students;

        public StudentQueriesTests()
        {
            _students = new List<Student>();
            _students.Add(new Student(
                new Name("Aluno", "Silva"),
                new Document("53689339081", EDocumentType.CPF),
                new Email("email@email.com")
            ));
        }

        [TestMethod]
        public void ShouldReturnNullWhenDocumentNotExists()
        {
            var expression = StudentQueries.GetStudent("12345678911");
            var student = _students.AsQueryable().Where(expression).FirstOrDefault();

            Assert.AreEqual(null, student);
        }

        [TestMethod]
        public void ShouldReturnStudentWhenDocumentExists()
        {
            var expression = StudentQueries.GetStudent("53689339081");
            var student = _students.AsQueryable().Where(expression).FirstOrDefault();

            Assert.AreNotEqual(null, student);
        }
    }
}