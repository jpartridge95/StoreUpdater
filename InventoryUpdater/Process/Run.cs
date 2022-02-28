using Core.IO;
using InventoryUpdater.File;
using InventoryUpdater.Products;

namespace InventoryUpdater.Process
{
    public class Runner
    {
        private readonly IListExtraction _extractor;
        private readonly IReadFile _reader;
        private readonly ISubClassListBuilder _builder;
        private readonly IAdvancer _advancer;
        private readonly IGroupValidator _validator;
        private readonly IProductsPrinter _printer;
        private readonly IWriter _writer;

        public Runner(
            IListExtraction extractor,
            IReadFile reader,
            ISubClassListBuilder builder,
            IAdvancer advancer,
            IGroupValidator validator,
            IProductsPrinter printer,
            IWriter writer)
        {
            _extractor = extractor;
            _reader = reader;
            _builder = builder;
            _advancer = advancer;
            _validator = validator;
            _printer = printer;
            _writer = writer;
        }

        public async void Run()
        {
            var extractedToStrings = _reader.ReadFile();

            var extractedToObjects = _extractor.Extract(extractedToStrings);

            var subClassList = _builder.BuildList(extractedToObjects);

            _advancer.Advance(subClassList);

            _validator.ValidateAllNumeric(subClassList);

            var finalList = _printer.PrintProducts(subClassList);

            await _writer.WriteData(finalList);

            Console.ReadKey();
        }
    }
}
