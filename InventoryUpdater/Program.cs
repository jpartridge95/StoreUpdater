using Core.Extraction;
using InventoryUpdater.File;
using InventoryUpdater.Process;

Extraction extractOne = new Extraction();
ExtractData extractTwo = new ExtractData(extractOne);
ExtractStep extractThree = new ExtractStep(extractTwo);

Runner runner = new(extractThree);
runner.Run();