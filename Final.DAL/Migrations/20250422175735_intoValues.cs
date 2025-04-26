using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final.DAL.Migrations
{
    /// <inheritdoc />
    public partial class intoValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Books(Title) Values('garry poter'), ('chemistri'); ");
            migrationBuilder.Sql(@"insert into Loans(UserId, BookId) 
                        Values  ('1', '2')
                                ('2', '3'); ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
