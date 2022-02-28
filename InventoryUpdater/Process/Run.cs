using Core.DateTimeService;
using Core.IO;
using InventoryUpdater.File;
using InventoryUpdater.Process;
using InventoryUpdater.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryUpdater.Process
{
    public class Runner
    {
        private readonly IListExtraction _extractor;

        public Runner(IListExtraction extractor)
        {
            _extractor = extractor;
        }

        public async void Run()
        {
            IDateTimeProvider dt = new DateTimeProvider();
            ReadFromFile reader = new(dt);

            ReadFileStep readFile = new ReadFileStep(reader);
            var extractedToStrings = readFile.ReadFile();

            var extractedToObjects = _extractor.Extract(extractedToStrings);

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
