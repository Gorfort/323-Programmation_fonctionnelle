using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Collections.Generic;
using System.Linq;

Console.WriteLine("Place du marché");

ISheet sheet;
using (var stream = new FileStream("PlaceDuMarche.xlsx", FileMode.Open))
{
    stream.Position = 0;
    XSSFWorkbook xssWorkbook = new XSSFWorkbook(stream);
    sheet = xssWorkbook.GetSheetAt(1);//select 2nd sheet

    var data = new List<MarketInfo>();

    for (int i = (sheet.FirstRowNum + 1/*skip header*/); i <= sheet.LastRowNum; i++)
    {
        IRow row = sheet.GetRow(i);
        int j = 0;
        data.Add(new MarketInfo(
            row.GetCell(j++).NumericCellValue.ToString(),
            row.GetCell(j++).StringCellValue,
            row.GetCell(j++).ToString(),
            row.GetCell(j++).ToString(),
            row.GetCell(j++).ToString(),
            row.GetCell(j++).ToString()
            ));
    }

    //Console.WriteLine(data);

    MarketInfo maxWatermelon = null;
    var peachSellers = new Dictionary<string, bool>();
    foreach (var item in data)
    {
        if (item.Product == "Pêches")
        {
            if (!peachSellers.ContainsKey(item.Seller))
            {
                peachSellers.Add(item.Seller, true);
            }
        }

        if (item.Product == "Pastèques")
        {
            if (maxWatermelon == null)
            {
                maxWatermelon = item;
            }
            else if (item.Quantity > maxWatermelon.Quantity)
            {
                maxWatermelon = item;
            }
        }
    }


    var peachProducersLINQ = (from item in data where item.Product == "Pêches" select 1).Count();
    var watermelonProducersLINQ = (from item in data where item.Quantity == int.maxValue select 1).Count();

    Console.WriteLine($"Il y a {peachProducersLINQ} vendeurs de pêches");
    Console.WriteLine($"C'est {""} qui a le plus de {""} au stand {""} et il en vends exactement {watermelonProducersLINQ}");
    Console.Read();
}