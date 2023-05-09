using CsvHelper;
using MediatR;
using SearchOrders.Models;
using System.Globalization;


namespace SearchOrders.Services
{
    public class CsvPurchaseOrderService : IPurchaseOrderService
    {
        private readonly IConfiguration _config;

        public CsvPurchaseOrderService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<PurchaseOrder>> SearchPurchaseOrders(string number, List<string> clientCodes, DateTime? fromDate, DateTime? toDate)
        {
            var filePath = _config.GetValue<string>("CsvFilePath");
            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            //csv.Configuration.Delimiter = ",";
            //csv.Configuration.CultureInfo = CultureInfo.InvariantCulture;
            //csv.Configuration.TypeConverterOptionsCache.GetOptions<DateTime>().Formats = new[] { "dd.MM.yyyy" }; 

            var records = csv.GetRecords<PurchaseOrder>().ToList();

            var filteredRecords = records.Where(o =>
            (string.IsNullOrEmpty(number) || o.Number.Contains(number)) &&
            (clientCodes == null || !clientCodes.Any() || clientCodes.Contains(o.ClientCode)) &&
            (!fromDate.HasValue || o.OrderDate.Date >= fromDate.Value.Date) &&
            (!toDate.HasValue || o.OrderDate.Date <= toDate.Value.Date)).ToList();

            return filteredRecords;
        }
    }
}
