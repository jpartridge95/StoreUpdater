using Core.DateTimeService;
using Core.Extraction;
using Core.IO;
using Core.ProductBuilder;
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

// Init Builders
ProductBuilder builderOne = new ProductBuilder();
SubClassBuilder builderTwo = new SubClassBuilder(builderOne);
SubClassBuilderStep builderThree = new SubClassBuilderStep(builderTwo);




Runner runner = new(
    extractThree,
    readFile,
    builderThree);
runner.Run();