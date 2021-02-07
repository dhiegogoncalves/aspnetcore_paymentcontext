using System;
using System.Linq.Expressions;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Domain.Queries
{
    public class StudentQueries
    {
        public static Expression<Func<Student, bool>> GetStudent(String documento)
        {
            return x => x.Document.Number == documento;
        }
    }
}