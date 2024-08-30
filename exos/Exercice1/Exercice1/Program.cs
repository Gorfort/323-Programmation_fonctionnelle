using IronXL;
using SixLabors.ImageSharp.PixelFormats;
using System;

class Program
{
    public static void Main()
    {
        string produit = "pêches";
        string produitMax = "Pastèques";
        string seller = "";
        int quantity = 0;
        int stand = 0;
        int produitCount = 0;

        int maxWatermelon = int.MinValue;

        // Load the Excel workbook
        WorkBook workBook = WorkBook.Load(@"C:\Users\po44oov\Documents\GitHub\323-Programmation_fonctionnelle\exos\marché\PlaceDuMarche.xlsx");

        // Get the first worksheet by name
        WorkSheet sheet = workBook.GetWorkSheet("Produits");

        foreach (var row in sheet.Rows)
        {
            // Pêches
            foreach (var cell in row)
            {
                if (cell.Text == "Pêches")
                {
                    produitCount++;
                }
            }
            
            // Pastèques
            foreach (var cell in row)
            {
                // Recherche 
                if (cell.Text == produitMax)
                {
                    // Obtient la quantité de pastèques (supposée être dans la colonne 3)
                    quantity = sheet.GetCellAt(cell.RowIndex, 3).IntValue;
                    // Obtient le numéro du stand (supposé être dans la colonne 0)
                    stand = sheet.GetCellAt(cell.RowIndex, 0).IntValue;

                    // Compare la quantité trouvée avec la quantité maximale enregistrée
                    if (quantity> maxWatermelon)
                    {
                        // Met à jour les informations du vendeur avec le plus de pastèques
                        seller = sheet.GetCellAt(cell.RowIndex, 1).Text;
                        maxWatermelon=quantity; // Met à jour le maximum de pastèques
                    }
                }
            }
        }


        // Display the number of sellers of the product
        Console.WriteLine();
        Console.WriteLine($"Il y a {produitCount} vendeurs de {produit}\n");
        Console.WriteLine($"C'est {seller} qui a le plus de {produitMax} au stand {stand} et il en vends exactement {maxWatermelon}");
        Console.Read();
    }
}
