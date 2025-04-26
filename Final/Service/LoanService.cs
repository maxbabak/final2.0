using Final.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.DAL.Repository;

namespace Final.Service
{
    public class LoanService
    {
        private readonly LoanRepository _loanRepository;

        public LoanService()
        {
            _loanRepository = new LoanRepository();
        }

        public List<Loan> GetAllLoan()
        {
            return _loanRepository.GetAll().ToList();
        }

        public Loan? GetLoanById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id), "id cannot be negativ");
            }
            return _loanRepository.GetAll()
                  .FirstOrDefault(l => l.Id == id);

        }

        public List<Loan> GetUsersAndBook()
        {
            return _loanRepository.GetUsersAndBook();
        }

        public void AddLoan(Loan loan)
        {
            _loanRepository.Add(loan);
        }
        public void DeleteLoan(Loan loan) 
        { 
            _loanRepository.Delete(loan); 
        }
    }
}
