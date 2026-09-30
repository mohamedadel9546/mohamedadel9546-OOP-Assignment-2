
using Library.LibiraryItem;
using Library.Loan;
using Library.Member_Type;
using Library.Staff;

namespace Library;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("===== Task 3.3 - Prove It in Main =====");
        Console.WriteLine();


        // ============================================================
        // 1. MUST NOT COMPILE
        // ============================================================

        // Person person = new Person(
        //     "P001",
        //     "Ahmed",
        //     "01000000000");
        // must NOT compile


        // Member member = new Member(
        //     "M001",
        //     "Ahmed",
        //     "01000000000",
        //     3,
        //     0);
        // must NOT compile


        // Staff staff = new Staff(
        //     "S001",
        //     "Ahmed",
        //     "01000000000",
        //     DateTime.Now,
        //     5000);
        // must NOT compile


        // LibraryItem item = new LibraryItem(
        //     "I001",
        //     "Some Item",
        //     10,
        //     7,
        //     1);
        // must NOT compile


        Stuedent member =
            new Stuedent(
                1,
                "Ahmed Ali",
                "01000000000");

        // member.FullName = "Mohamed";
        // must NOT compile


        // member.Loans.Add(...);
        // must NOT compile


        // Book bookForTest =
        //     new Book("B999", "Test Book", 10);

        // bookForTest.IsOnLoan = true;
        // must NOT compile


        // ============================================================
        // 2. CREATE MEMBERS
        // ============================================================

        Stuedent student =
            new Stuedent(
                1,
                "Ahmed Ali",
                "01000000000");

        PremiumStudent premium =new PremiumStudent(2,"Mohamed Adel", "01111111111",  20);
                
               
              
            
               


        // ============================================================
        // 3. CREATE LIBRARY ITEMS
        // ============================================================

        Book book =
            new Book(
                "B001",
                "Clean Code",
                10);

        DVD dvd =
            new DVD(
                "D001",
                "C# Course",
                10);

        Magazin magazine =
            new Magazin(
                "M001",
                "Tech Magazine",
                10);


        // ============================================================
        // 4. BORROW WITHDRAWN ITEM
        // ============================================================

        Console.WriteLine("----- Borrow Withdrawn Item -----");

        book.IsWidraw();

        try
        {
            student.Borrow(book);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        book.Restore();

        Console.WriteLine();


        // ============================================================
        // 5. BORROW ITEM ALREADY ON LOAN
        // ============================================================

        Console.WriteLine("----- Borrow Item Already On Loan -----");

        Loan.Loan firstLoan =
            student.Borrow(book);

        try
        {
            premium.Borrow(book);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine();


        // ============================================================
        // 6. STUDENT BORROWS A 4TH ITEM
        // ============================================================

        Console.WriteLine("----- Student 4th Loan -----");

        Book book2 =
            new Book(
                "B002",
                "Design Patterns",
                10);

        Magazin magazine2 =
            new Magazin(
                "M002",
                "Programming Magazine",
                10);

        DVD dvd2 =
            new DVD(
                "D002",
                "Algorithms",
                10);


        student.Borrow(book2);
        student.Borrow(magazine2);

        // Student now has 3 active loans:
        //
        // firstLoan -> book
        // second    -> book2
        // third     -> magazine2

        try
        {
            student.Borrow(dvd2);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine();


        // ============================================================
        // 7. STAFF POLYMORPHISM
        // ============================================================

        Console.WriteLine("----- Staff Monthly Pay -----");

        Librarian librarian =
            new Librarian(
                1,
                "Omar Hassan",
                "01222222222",
                DateTime.Now,
                8000);

        HeadLibrarian headLibrarian =
            new HeadLibrarian(
                2,
                "Hassan Ahmed",
                "01333333333",
                DateTime.Now,
                10000);

        Shelver shelver =
            new Shelver(
                3,
                "Ali Mohamed",
                "01444444444",
                DateTime.Now,
                7000,
                "Computer Science");


        List<Staff.Staff> staffMembers =
        [
            librarian,
        headLibrarian,
        shelver
        ];


        foreach (var staff in staffMembers)
        {
            Console.WriteLine(
                $"{staff.FullName} - Monthly Pay: {staff.MonthlySalary}");
        }

        Console.WriteLine();


        // ============================================================
        // 8. LIBRARY ITEM POLYMORPHISM
        // ============================================================

        Console.WriteLine("----- Library Items -----");

        List<LibraryItem> items =
        [
            book,
        dvd,
        magazine
        ];


        foreach (LibraryItem item in items)
        {
            Console.WriteLine(
                $"{item.Title} - " +
                $"Loan Period: {item.LoanPeriod} days - " +
                $"Daily Late Fee: {item.GetDailyLateFee()}");
        }

        Console.WriteLine();


        // ============================================================
        // 9. PREMIUM MEMBER RETURNS DVD 5 DAYS LATE
        // ============================================================

        Console.WriteLine("----- Premium Member Late Return -----");

        Loan.Loan premiumLoan =
            premium.Borrow(dvd);


        DateTime returnDate =
            premiumLoan.DueDate.AddDays(5);


        librarian.ProccessReturn(
            premiumLoan,
            returnDate);


        Console.WriteLine(
            $"Due Date: {premiumLoan.DueDate}");

        Console.WriteLine(
            $"Late Fee: {premiumLoan.LateFee}");

        Console.WriteLine(
            $"Reading Points: {premium.ReadingPoint}");

        Console.WriteLine();


        // ============================================================
        // 10. RETURN SAME LOAN TWICE
        // ============================================================

        Console.WriteLine("----- Return Same Loan Twice -----");

        try
        {
            librarian.ProccessReturn(
                premiumLoan,
                returnDate.AddDays(1));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine();


        // ============================================================
        // 11. MARK RETURNED LOAN AS LOST
        // ============================================================

        Console.WriteLine("----- Mark Returned Loan As Lost -----");

        try
        {
            librarian.MarkAtLost(premiumLoan);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine();


        // ============================================================
        // 12. SHELVER REASSIGNMENT
        // ============================================================

        Console.WriteLine("----- Shelver Section -----");

        Console.WriteLine(
            $"Before: {shelver.Section}");

        shelver.ReAssign("Science");

        Console.WriteLine(
            $"After: {shelver.Section}");
    }
}


