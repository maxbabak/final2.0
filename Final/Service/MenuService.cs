using Final.DAL.Entities;

namespace Final.Service
{
    public class MenuService
    {
        private readonly UserService _userService;
        private readonly BookService _bookService;
        private readonly LoanService _loanService;

        public MenuService()
        {
            _userService = new UserService();
            _bookService = new BookService();
            _loanService = new LoanService();
        }

        public void Start()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("1. Show all Users");
                Console.WriteLine("2. Show all loans");
                Console.WriteLine("3. Show all books");
                Console.WriteLine("4. Add User");
                Console.WriteLine("5. Add loan");
                Console.WriteLine("6. Add book");
                Console.WriteLine("7. Add couple of Users");
                Console.WriteLine("8. Add couple of Loans");
                Console.WriteLine("9. Add couple of books");
                Console.WriteLine("10. Delete couple of Users");
                Console.WriteLine("11. Delete couple of Loans");
                Console.WriteLine("12. Delete couple of books");
                Console.WriteLine("13. Delete Users");
                Console.WriteLine("14. Delete Loans");
                Console.WriteLine("15. Delete books");
                Console.WriteLine("0. Exit");


                Console.Write("Chose: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ShowAllUsers();
                        break;
                    case "2":
                        ShowAllLoans();
                        break;
                    case "3":
                        ShowAllBooks();
                        break;
                    case "4":
                        AddUser();
                        break;
                    case "5":
                        AddLoan();
                        break;
                    case "6":
                        AddBook();
                        break;
                    case "7":
                        AddCoupleOfUsers();
                        break;
                    case "8":
                        AddCoupleOfLoans();
                        break;
                    case "9":
                        AddCoupleOfBooks();
                        break;
                    case "10":
                        DeleteCoupleOfUsers();
                        break;
                    case "11":
                        DeleteCoupleOfLoans();
                        break;
                    case "12":
                        DeleteCoupleOfBooks();
                        break;
                    case "13":
                        DeleteUser();
                        break;
                    case "14":
                        DeleteLoan();
                        break;
                    case "15":
                        DeleteBook();
                        break;
                    case "0":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Невірний вибір.");
                        break;
                }
            }
        }



        private void ShowAllUsers()
        {
            var users = _userService.GetAllUsers();
            Console.Clear();
            foreach (var user in users)
            {
                Console.WriteLine($"Users: {user}");
            }
        }

        private void ShowAllLoans()
        {
            var loans = _loanService.GetUsersAndBook();
            Console.Clear();
            foreach (var loan in loans)
            {
                Console.WriteLine($"User: {loan.User.Name}\n Book {loan.Book.Title}");
            }
        }

        private void ShowAllBooks()
        {
            var books = _bookService.GetAllBooks();
            Console.Clear();
            foreach (var book in books)
            {
                Console.WriteLine($"Book {book.Title}");
            }
        }

        private void AddUser()
        {
            Console.WriteLine("enter the name");
            var name = Console.ReadLine();

            var user = new User
            {
                Name = name
            };
            _userService.AddUser(user);
        }

        private void AddLoan()
        {
            Console.WriteLine("who buy\nenter name");
            var userName = Console.ReadLine();
            var user = _userService.GetUserByName(userName);
            if (user == null)
            {
                Console.WriteLine("user not found");
                return;
            }
            Console.WriteLine("which book u wanna buy");
            var title = Console.ReadLine();

            var book = _bookService.GetBookByTitle(title);

            if (book == null)
            {
                Console.WriteLine("book not found");
                return;
            }
            var loan = new Loan
            {
                BookId = book.Id,
                UserId = user.Id
            };
            _loanService.AddLoan(loan);
        }

        private void AddBook()
        {
            Console.WriteLine("enter the title");
            var title = Console.ReadLine();

            var book = new Book
            {
                Title = title
            };
            _bookService.AddBook(book);
        }

        private void AddCoupleOfUsers()
        {
            Console.WriteLine("how much u wanna add: ");
            if (!int.TryParse(Console.ReadLine(), out var count))
            {
                Console.WriteLine("invalid input");
                return;
            }
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("enter the name ");
                var name = Console.ReadLine();
                var user = new User
                {
                    Name = name
                };
                _userService.AddUser(user);
            }
        }

        private void AddCoupleOfLoans()
        {
            Console.WriteLine("how much u wanna add: ");
            if (!int.TryParse(Console.ReadLine(), out var count))
            {
                Console.WriteLine("invalid input");
                return;
            }
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("who buy\nenter name");
                var userName = Console.ReadLine();
                var user = _userService.GetUserByName(userName);
                if (user == null)
                {
                    Console.WriteLine("user not found");
                    return;
                }
                Console.WriteLine("which book u wanna buy");
                var title = Console.ReadLine();

                var book = _bookService.GetBookByTitle(title);

                if (book == null)
                {
                    Console.WriteLine("book not found");
                    return;
                }
                var loan = new Loan
                {
                    BookId = book.Id,
                    UserId = user.Id
                };
                _loanService.AddLoan(loan);
            }
        }

        private void AddCoupleOfBooks()
        {
            Console.WriteLine("how much u wanna add: ");
            if (!int.TryParse(Console.ReadLine(), out var count))
            {
                Console.WriteLine("invalid input");
                return;
            }
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("enter the title");
                var title = Console.ReadLine();

                var book = new Book
                {
                    Title = title
                };
                _bookService.AddBook(book);
            }
        }
        
        private void DeleteBook()
        {
            Console.WriteLine("enter the title");
            var title = Console.ReadLine();
            var book = new Book
            {
                Title = title
            };
            _bookService.DeleteBook(book);
        }
        
        private void DeleteLoan()
        {
            {
                Console.WriteLine("who sale\nenter name");
                var userName = Console.ReadLine();
                var user = _userService.GetUserByName(userName);
                if (user == null)
                {
                    Console.WriteLine("user not found");
                    return;
                }
                Console.WriteLine("which book u wanna sale");
                var title = Console.ReadLine();

                var book = _bookService.GetBookByTitle(title);

                if (book == null)
                {
                    Console.WriteLine("book not found");
                    return;
                }
                var loan = new Loan
                {
                    BookId = book.Id,
                    UserId = user.Id
                };
                _loanService.DeleteLoan(loan);
            }
        }

        private void DeleteUser()
        {
            Console.WriteLine("enter the name");
            var name = Console.ReadLine();

            var user = _userService.GetUserByName(name);
                
            _userService.DeleteUser(user);
        }

        private void DeleteCoupleOfBooks()
        {
            Console.WriteLine("how much u wanna add: ");
            if (!int.TryParse(Console.ReadLine(), out var count))
            {
                Console.WriteLine("invalid input");
                return;
            }
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("enter the title");
                var title = Console.ReadLine();
                var book = new Book
                {
                    Title = title
                };
                _bookService.DeleteBook(book);
            }
        }
        
        private void DeleteCoupleOfLoans()
        {
            Console.WriteLine("how much u wanna add: ");
            if (!int.TryParse(Console.ReadLine(), out var count))
            {
                Console.WriteLine("invalid input");
                return;
            }
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("who sale\nenter name");
                var userName = Console.ReadLine();
                var user = _userService.GetUserByName(userName);
                if (user == null)
                {
                    Console.WriteLine("user not found");
                    return;
                }
                Console.WriteLine("which book u wanna sale");
                var title = Console.ReadLine();

                var book = _bookService.GetBookByTitle(title);

                if (book == null)
                {
                    Console.WriteLine("book not found");
                    return;
                }
                var loan = new Loan
                {
                    BookId = book.Id,
                    UserId = user.Id
                };
                _loanService.DeleteLoan(loan);
            }
        }
        
        private void DeleteCoupleOfUsers()
        {
            Console.WriteLine("how much u wanna add: ");
            if (!int.TryParse(Console.ReadLine(), out var count))
            {
                Console.WriteLine("invalid input");
                return;
            }
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("enter the name");
                var name = Console.ReadLine();

                var user = _userService.GetUserByName(name);

                _userService.DeleteUser(user);
            }
        }
    }
}
