using Core.DateTimeService;
using Core.Extraction;
using Core.IO;
using Core.ProductBuilder;
using Core.Validate;
using InventoryUpdater.File;
using InventoryUpdater.Process;
using InventoryUpdater.Products;

// Init Datetime
DateTimeProvider dt = new DateTimeProvider();

// Init File readers
ReadFromFile reader = new ReadFromFile(dt);
ReadFileStep readFile = new ReadFileStep(reader);

// Init Extractors
Extraction extractOne = new Extraction();
ExtractData extractTwo = new ExtractData(extractOne);
ExtractStep extractThree = new ExtractStep(extractTwo);

// Init Name Validator
NameValidator nameValidator = new NameValidator();

// Init Builders
ProductBuilder builderOne = new ProductBuilder(nameValidator);
SubClassBuilder builderTwo = new SubClassBuilder(builderOne);
SubClassBuilderStep builderThree = new SubClassBuilderStep(builderTwo);

// Init Advancer
Advancer advancer = new Advancer();

// Init Number Validators
NumericValidator numberValidator = new NumericValidator();
Validator listNumericValidator = new Validator(numberValidator);

// Init Printer
MakeStringList printer = new MakeStringList();

// Init Writer
WriteToFile writer = new WriteToFile(dt);



Runner runner = new(
    extractThree,
    readFile,
    builderThree,
    advancer,
    listNumericValidator,
    printer,
    writer);

runner.Run();