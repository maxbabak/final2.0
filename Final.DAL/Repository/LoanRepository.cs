using Final.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.DAL.Repository
{
    public class LoanRepository
    {
        private readonly AppDbContext _context;

        public LoanRepository()
        {
            _context = new AppDbContext();
        }

        public List<Loan> GetAll() 
        {
            return _context.Loans.ToList();
        }


        public void Add(Loan loan)
        {
            _context.Add(loan);
            _context.SaveChanges();
        }        


        public void AddRange(List<Loan> loans) 
        {
            _context.AddRange(loans);
            _context.SaveChanges();
        }
        
        
        public void Update(Loan loan)
        {
            _context.Update(loan);
            _context.SaveChanges();
        }
        
        
        public void Delete(Loan loan)
        {
            _context.Remove(loan);
            _context.SaveChanges();
        }


        public void DeleteAll(List<Loan> loans)
        {
            _context.RemoveRange(loans);
            _context.SaveChanges();
        }
        
        public List<Loan> GetUsersAndBook()
        {
            return _context.Loans
                .Include(l => l.User)
                .Include(l => l.Book)
                .ToList();
        }
      
    }
}
