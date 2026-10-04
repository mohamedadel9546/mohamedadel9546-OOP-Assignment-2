## 1. AppointmentDesk

### Distinct Responsibilities Identified:
1. **Operating Hours Rules:** Enforcing clinic opening/closing times and holiday rules (`IsWithinBusinessHours`).
2. **Appointment Scheduling & Slot Management:** Tracking booked slots, searching for next available slots,
1. and booking (`FindNextSlot`, `TryBook`).
3. **Calendar Export Formatting:** Formatting appointment data into iCalendar (`.ics`) format (`ToIcs`).
4. **Notification Messaging:** Constructing SMS reminder message text (`SmsReminder`).

### Why Having Them Together is a Problem:
Combining these concerns in `AppointmentDesk` creates multiple unrelated reasons to change. 


### WardBoard

#### Distinct Responsibilities Identified:
1. **Bed & Patient Occupancy Management:** Tracking which patients are assigned to which beds (`AssignBed`, `_bedPatient`).
2. **Clinical Acuity Scoring:** Calculating patient risk severity score based on medical vitals in `ScoreAcuity`.
3. **Emergency Paging & Alerting:** Generating and managing crisis notification logs (`CODE-YELLOW`) in `DrainPagerLog`.
4. **Shift Handoff Formatting:** Structuring narrative shift report notes for nursing staff in `BuildHandoffNote`.
5. **Data Export/Persistence Formatting:** Formatting bed census data into CSV format in `ExportCensusCsv`.

#### Why Having Them Together is a Problem:
Coupling medical acuity evaluation rules, bed management, alerting channels, and CSV formatting inside 
one class creates multiple reasons to change.
For instance, modifying how medical scores are calculated or changing CSV column headers will require modifying and re-testing
the core bed allocation logic.


### CheckoutBasket

#### Distinct Responsibilities Identified:
1. **Basket Items & Subtotal State:** Managing line items (SKU, price, quantity) and calculating the raw subtotal (`AddLine`, `SubTotal`).
2. **Coupon Parsing & Discount Logic:** Parsing raw marketing coupon strings (`SAVE`, `WELCOME10`, etc.) and computing discount amounts in `DiscountAmount`.
3. **Cart Grand Total & Policy Pricing:** Applying shipping/packaging policy fees (e.g., $4.99 gift-wrap fee) to calculate final total in `GrandTotal`.
4. **Gift Message Presentation:** Formatting customer-facing gift card strings in `GiftMessageCard`.
5. **Payment Gateway Authorization Formatting:** Serializing cart data and card numbers to produce a payment authorization hash stub in `AuthorizePaymentStub`.

#### Why Having Them Together is a Problem:
Mixing raw item storage with string parsing for coupon codes, marketing message copy, packaging fee policy,
and payment gateway stubs creates multiple independent reasons to change. 


### SupportTicket

#### Distinct Responsibilities Identified:
1. **Ticket Domain Model & Message Management:** Storing ticket properties and appending customer messages (`AppendCustomerMessage`).
2. **Keyword Priority Classification:** Analyzing text heuristics and keywords to determine ticket priority levels in `RecalculatePriorityFromText`.
3. **Operational SLA Policy Math:** Computing SLA target deadlines and breach statuses based on priority rules in `SlaDeadline` and `IsBreached`.
4. **Customer-Facing Response Formatting:** Crafting public template replies for customers in `DraftPublicReply`.
5. **Internal Escalation Messaging:** Constructing internal escalation alert strings in `InternalEscalationBlurb`.

#### Why Having Them Together is a Problem:
Mixing domain ticket state with text-matching heuristics, SLA business policies, and customer presentation templates
creates multiple independent reasons to change.


### LoanDesk

#### Distinct Responsibilities Identified:
1. **Loan Application Data Model:** Holding loan application attributes such as amount, credit score, employment tenure, and collateral status.
2. **Underwriting Risk & Eligibility Rules:** Computing numerical risk evaluation scores and evaluating approval eligibility in `RiskScore` and `IsEligible`.
3. **Regulatory Compliance Document Rules:** Determining required compliance documentation based on loan size and risk profile in `RequiredDocuments`.
4. **Customer Decision Letter Formatting:** Structuring legal pre-approval and decline communication letters for applicants in `DecisionLetter`.
5. **Analytics Export Formatting:** Formatting application parameters and evaluation metrics into a CSV row string for underwriters in `UnderwriterCsvRow`.

#### Why Having Them Together is a Problem:
Mixing application data with financial risk formulas, compliance rules, legal communication templates, and analytics export schemas
gives this class five distinct reasons to change. 


### CourseEnrollmentDesk

#### Distinct Responsibilities Identified:
1. **Course Rigister & Waitlist State:** Managing active seat allocations and waitlist registrations in `Register` and `WaitlistPosition`.
2. **Waitlist Promotion Operations:** Handling operational promotion logic to move students from waitlist to seated status in `PromoteFromWaitlist`.
3. **Onboarding Marketing Presentation:** Formatting Markdown-based welcome packets and Discord links for students in `WelcomePacketMarkdown`.
4. **Financial Invoicing & VAT Calculations:** Calculating tuition tax (14% VAT) and formatting financial invoice strings in `TuitionInvoiceLine`.

#### Why Having Them Together is a Problem:
Mixing seat allocation algorithms with marketing welcome packet templates and tax/financial invoice calculations creates
multiple distinct reasons to change. 

### KitchenTicket

#### Distinct Responsibilities Identified:
1. **Ticket Items & Line Data Model:** Managing ticket line items, raw ingredient string processing, and individual preparation times.
2. **Ingredient Allergen Detection Rules:** Matching ingredient keywords against regulatory allergen categories in `DetectAllergens`.
3. **Kitchen Operational Preparation Math:** Estimating order completion time based on station concurrency and safety delays in `EstimatedReadyMinutes`.
4. **Thermal Printer Formatting:** Serializing order contents and boundaries into fixed-width receipt text for hardware printers in `RenderThermalTicket`.
5. **Expo Lane Dispatch Routing:** Determining routing lane tags for expediter stations in `ExpoLaneHint`.

#### Why Having Them Together is a Problem:
Mixing raw item storage with health-code allergen dictionaries, kitchen station concurrency math,
hardware thermal paper layouts, and expediter routing tags gives this class five distinct reasons to change.

### SubscriptionBilling

#### Distinct Responsibilities Identified:
1. **Subscription Data & Payment Failure State:**
  Tracking active customer subscription periods, monthly pricing, and failing payment attempts (`FailedPayments`).
2. **Financial Proration Calculation:**
  Calculating prorated billing amounts based on activation dates and billing period lengths in `Prorate`.
3. **Sequential Invoice Number Generation:** 
   Maintaining invoice counter sequence and formatting fiscal invoice identifiers in `NextInvoiceNumber`.
4. **Dunning & Customer Collection Messaging:**
    Formatting dunning email templates and determining severity tiers based on failure counts in `DunningEmail`.
5. **Ledger & Accounting Export Formatting:** 
   Serializing billing line items into CSV journal entries for accounting integration in `LedgerJournalLine`.

#### Why Having Them Together is a Problem:
Coupling subscription domain state with accounting export layouts, invoice sequence generation, #
and dunning email templates creates multiple vectors of change.
A side effect in `DunningEmail` mutates global invoice sequence numbers during template generation. 
Additionally, changing an accounting CSV format or email wording requires modifying the primary subscription pricing entity.

### GradeBook

#### Distinct Responsibilities Identified:
1. **Grade Records & Averaging State:** Storing student numeric test scores and calculating arithmetic averages in `Record` and `Average`.
2. **Academic Grading Policy:** Mapping numeric averages to letter grades based on faculty grading scales in `Letter`.
3. **Honor Roll Qualification Policy:** Evaluating academic criteria and eligibility thresholds for student honor roll placement in `MeetsHonorRoll`.
4. **Registrar Transcript Formatting:** Structuring plain text official student transcript documents in `TranscriptPlain`.
5. **CSV Export Serialization:** Formatting and serializing class grade metrics into CSV rows in `ExportCsv`.

#### Why Having Them Together is a Problem:
Mixing grading policies, honor roll rules, transcript text layouts, and CSV export logic inside a grade storage entity violates SRP.
Changing academic grading scales (e.g., changing grade bands) or updating transcript formatting forces modifications to the core grade storage component.