using System;

namespace LabExam1
{
    class Program
    {
        static int sel = -1;
        static double subTotal = 0.0D;
        static int qty = -1;
        const float stateTax = 0.09F;
        const float tipRate = 0.20F;
        static double tax = 0.0D;
        static double tip = 0D;
        static readonly string[] items = { "Prime Rib", "Fried Chicken", "Baked Haddock", "Soda" };
        static readonly double[] prices = { 13.99, 8.49, 9.99, 1.99 };
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            while (true)
            {

                DisplayMenu();
                sel = GetSelection();
                if (ValidateSelection(ref sel) == -1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("  Invalid input");
                    continue;
                }
                else if (ValidateSelection(ref sel) == items.Length + 1)
                {
                    break;
                }
                qty = GetQuantity();
                subTotal += CalculateBill(sel, qty);
                if (items[sel - 1] == "Soda")
                {
                    Console.WriteLine("  {0} {1}, at {2:C} per each, totalling {3:C}", qty, items[sel - 1], prices[sel - 1], prices[sel - 1] * qty);
                }
                else
                {
                    Console.WriteLine("  {0} {1}, at {2:C} per plate, totalling {3:C}", qty, items[sel - 1], prices[sel - 1], prices[sel - 1] * qty);
                }

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("  Your current subtotal is {0:C}\n\n", subTotal);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Press any key to continue . . . ");
                while (Console.ReadKey().Key.ToString() == "") ; // wait for keypress
                Console.WriteLine();

            } // end main loop
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  {0, 15}  {1, -6:C}", "Subtotal:", subTotal);
            string taxFormat = string.Format("Tax ({0:P}):", stateTax);
            tax = stateTax * subTotal;
            Console.WriteLine("  {0, 15}  {1:C}", taxFormat, tax);
            string tipFormat = string.Format("Tip ({0:P}):", tipRate);
            tip = (subTotal + tax) * tipRate;
            Console.WriteLine("  {0, 15}  {1:C}", tipFormat, tip);
            double total = tax + subTotal + tip;
            Console.WriteLine("  {0, 15}  {1, -6:C}", "Total:", total);
            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write("Press any key to continue . . . ");
            while (Console.ReadKey().Key.ToString() == "") ; // wait for keypress

        }

        private static void DisplayMenu()
        {
            Console.WriteLine("  {0,-3} {1, -20} {2, 6}", "#", "Item", "Price");
            for (int i = 1; i < items.Length + 1; i++)
            {
                Console.WriteLine("  {0,-3} {1, -20} {2, 6:C}", i, items[i - 1], prices[i - 1]);
            }
            Console.WriteLine("  {0,-3} {1, -20}", items.Length + 1, "Confirm and Exit");
        }
        private static double CalculateBill(int sel, int qty)
        {
            return prices[sel - 1] * qty;
        }
        private static int ValidateSelection(ref int sel)
        {
            switch (sel)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    return sel;
                default:
                    return -1;
            }
        }
        private static int GetSelection()
        {
            int sel;
            while (true)
            {
                try
                {
                    Console.Write("  Please make a selection: ");
                    sel = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("  Invalid input");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            }
            return sel;
        }
        private static int GetQuantity()
        {
            int qty;
            while (true)
            {
                try
                {
                    Console.Write("  Please enter a quantity: ");
                    qty = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("  Invalid input");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            }
            return qty;
        }
    }
}
