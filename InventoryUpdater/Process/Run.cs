using Core.DateTimeService;
using Core.IO;
using InventoryUpdater.Process;
using InventoryUpdater.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryUpdater.Process
{
    internal class Runner
    {
        public async void Run()
        {
            IDateTimeProvider dt = new DateTimeProvider();
            ReadFromFile reader = new(dt);

            ReadFileStep readFile = new ReadFileStep(reader);
            var extractedToStrings = readFile.ReadFile();

            ExtractStep extractor = new ExtractStep(extractedToStrings);
            var extractedToObjects = extractor.Extract();

            SubClassBuilderStep builder 
                = new SubClassBuilderStep(new SubClassBuilder(extractedToObjects));
            var subClassList = builder.BuildList();

            Advancer advancer = new Advancer(subClassList);
            advancer.Advance();

            Validator validator = new Validator(subClassList);
            validator.ValidateAllNumeric();

            MakeStringList printer = new MakeStringList(subClassList);
            var finalList = printer.PrintProducts();

            WriteToFile writer = new WriteToFile(dt, finalList);
            await writer.WriteData();
        }
    }
}
