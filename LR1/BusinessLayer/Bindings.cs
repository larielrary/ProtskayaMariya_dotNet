using LR1.BusinessLayer.Read;
using LR1.BusinessLayer.Report;
using LR1.BusinessLayer.Write;
using Ninject.Modules;

namespace LR1.BusinessLayer
{
    internal class Bindings : NinjectModule
    {
        private readonly FileFormat _format;

        public Bindings(FileFormat format)
        {
            _format = format;
        }

        public override void Load()
        {
            Bind<IReader>().To<CsvReader>();
            Bind<IReportService>().To<ReportService>().InSingletonScope();
            switch (_format)
            {
                case FileFormat.Json:
                    Bind<IWriter>().To<JsonWriter>();
                    break;
                case FileFormat.Xlsx:
                    Bind<IWriter>().To<ExcelWriter>();
                    break;
            }
        }
    }
}