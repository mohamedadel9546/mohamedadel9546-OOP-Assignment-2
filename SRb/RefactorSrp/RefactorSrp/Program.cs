using RefactorSrp.AppointmentDesk;
using RefactorSrp.CheckOutBasket;
using RefactorSrp.CourseEnrollmentDesk;
using RefactorSrp.GradeBook;
using RefactorSrp.KitchenTicket;
using RefactorSrp.LoanDesk;
using RefactorSrp.SubscriptionBilling;
using RefactorSrp.SupportTicket;
using RefactorSrp.WardBoard;
using RefactorSrp.WarehousePickList;

namespace RefactorSrp;

internal class Program
{
    static void Main(string[] args)
    {
        var BussinesHour = new BussinesHours(new TimeOnly(9,0),new TimeOnly(17,0),30);
        var book = new AppointmentSchedular(BussinesHour);
        var slot= book.FindNextSlot(DateTimeOffset.Parse("2026-09-21T08:00:00Z"),48);
        if(slot is null) throw new InvalidOperationException("no slot");
        book.TryBook(slot.Value);
        var Sms = new AppointmentSendFormatter();
        Console.WriteLine(Sms.SmsReminder(slot.Value,"0100"));

        Console.WriteLine("======================");

        var AsignBed = new AsignBed();
        AsignBed.AssignBed(1, "p-88", heartRate: 130, spo2: 89);
        var ReportNote = new BuildHandoffNote(AsignBed);
        Console.WriteLine(ReportNote.BuildHandoffnote(1));
        var PagerLog = new PagerLog();
        Console.WriteLine(string.Join(" | ", PagerLog.DrainPagerLog()));

        Console.WriteLine("======================");

        var AddLines = new AddLines();
        AddLines.AddLine("SKU-1", 40m, 2);
        var Discount = new CalculateDiscount(AddLines);
        Discount.ApplyCouponText("SAVE10");
        AddLines.EnableGiftWrap();
        var GrandTotal = new GrandTotal(AddLines, Discount);
        var Pay = new Payment(AddLines, GrandTotal);
        Console.WriteLine($"basket total={GrandTotal.Grand_Total()} auth={Pay.AuthorizePaymentStub("4242")}");

        Console.WriteLine("======================");

        var Poriorty = new CalculatePoriority();
        var SupportTicket = new Supportticket("T-1", "cannot login", "prod is down for me", DateTimeOffset.UtcNow, Poriorty);
        var DedLine = new DeadLIne(SupportTicket);
        var PuplicReply = new PublicRebly(SupportTicket, DedLine);
        Console.WriteLine(PuplicReply.DraftPublicReply("Nora"));

        Console.WriteLine("======================");
        var AddLoan = new AddLoan(60_000m, 640, 4, hasCollateral: false);
        var RiskScore = new CalculateRisk(AddLoan);
        var RequireDocument = new RequireDocument(AddLoan, RiskScore);
        var DecisionLetter = new Decision_Letter(AddLoan,RiskScore, RequireDocument);
        Console.WriteLine(DecisionLetter.DecisionLetter("Omar"));

        Console.WriteLine("======================");
        var Course = new Rgister("SEF-101", capacity: 1, tuition: 3000m);
        Console.WriteLine(Course.Register("a@mail.com"));
        Console.WriteLine(Course.Register("b@mail.com"));
        var MarkDown = new MarkDown(Course);
        Console.WriteLine(MarkDown.WelcomePacketMarkdown("b@mail.com", "Bea"));

        Console.WriteLine("======================");

        var kitchen = new ADDITEM();
        kitchen.AddItem("Pasta", new[] { "wheat", "milk" }, 12);
        var ingerdientAlleregen = new IngredientAllergenDetector(kitchen);
        var ReadyMintus = new ReadyMinutes(kitchen, ingerdientAlleregen);
        var printTicket = new PrintTicket(kitchen, ingerdientAlleregen, ReadyMintus);
        Console.WriteLine(printTicket.RenderThermalTicket(42));

        Console.WriteLine("======================");
        var AddSubscribe = new AddSubscribe("c-9", 99m, new DateOnly(2026, 9, 1), new DateOnly(2026, 10, 1));
        AddSubscribe.RegisterFailedPayment();
        var InvoiceNumber = new InvoiceNumber(AddSubscribe);
        var Prorate = new Proorate(AddSubscribe);
        var Email = new SendEmail(InvoiceNumber, Prorate, AddSubscribe);
        Console.WriteLine(Email.DunningEmail("Sara", new DateOnly(2026, 9, 20)));

        Console.WriteLine("======================");

        var pick = new ADDNeed();
        pick.AddNeed("BOLT", "A", 3, 10, 7);
        pick.AddNeed("NUT", "B", 1, 5, 5);
        var allocate = new ALLocate(pick);
        var wlaking = new WAlkingOredr(pick);
        var Script = new UXScripit(pick, allocate, wlaking);
        Console.WriteLine(Script.PickerScript());

        Console.WriteLine("======================");

        var grades = new ADDStuudent();
        grades.Record("s1", 92);
        grades.Record("s1", 88);
        var grading = new GradingPolicyCalculator(grades);
        var Honoroll = new HonorolRoll(grades, grading);
        var Transcript = new Transcripit(grades, grading, Honoroll);
        Console.WriteLine(Transcript.TranscriptPlain("s1", "Ali"));

    }
}
