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
        private readonly IReadFile _reader;
        private readonly ISubClassListBuilder _builder;

        public Runner(
            IListExtraction extractor,
            IReadFile reader,
            ISubClassListBuilder builder)
        {
            _extractor = extractor;
            _reader = reader;
            _builder = builder;
        }

        public async void Run()
        {
            var extractedToStrings = _reader.ReadFile();

            var extractedToObjects = _extractor.Extract(extractedToStrings);

            var subClassList = _builder.BuildList(extractedToObjects);

            Advancer advancer = new Advancer(subClassList);
            advancer.Advance();

            Validator validator = new Validator(subClassList);
            validator.ValidateAllNumeric();

            MakeStringList printer = new MakeStringList(subClassList);
            var finalList = printer.PrintProducts();

            WriteToFile writer = new WriteToFile(new DateTimeProvider(), finalList);
            await writer.WriteData();
        }
    }
}
