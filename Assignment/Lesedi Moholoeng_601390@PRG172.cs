namespace ComputerCompany
{ using System;
    using System.Collections.Generic;
  
        class Program
        {
            static List<decimal> customerTotals = new List<decimal>();
            static int numberOfCustomers = 0;
            static int totalSSDDrives = 0;
            static int totalHDDDrives = 0;

        enum DriveType
        {
            HDD,
            SSD
        }



       


            static void Main(string[] args)
            {
                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("---- The Computer Company ----");
                    Console.WriteLine("1. New Purchase");
                    Console.WriteLine("2. View all customer totals for purchases");
                    Console.WriteLine("3. Display amount of customer orders");
                    Console.WriteLine("4. Display the amount of SSD drives purchased in total");
                    Console.WriteLine("5. Display the amount of HDD drives purchased in total");
                    Console.WriteLine("6. Display the total amount of customer orders (in Rand) from most expensive to least expensive");
                    Console.WriteLine("0. Exit");



                    Console.Write("Enter your choice: ");
                    string input = Console.ReadLine();



                    switch (input)
                    {
                        case "1":
                            PerformNewPurchase();
                            break;
                        case "2":
                            ViewCustomerTotals();
                            break;
                        case "3":
                            DisplayCustomerOrders();
                            break;
                        case "4":
                            DisplayTotalSSDDrives();
                            break;
                        case "5":
                            DisplayTotalHDDDrives();
                            break;
                        case "6":
                            DisplayTotalAmountOfOrders();
                            break;
                        case "0":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }



                    Console.WriteLine();
                }
            }



            static void PerformNewPurchase()
            {
                Console.WriteLine("---- New Purchase ----");



                Console.WriteLine("Select the type of hard drive:");
                Console.WriteLine("1. HDD");
                Console.WriteLine("2. SSD");



                Console.Write("Enter your choice: ");
                string input = Console.ReadLine();



                if (!Enum.TryParse(input, out DriveType driveType))
                {
                    Console.WriteLine("Invalid drive type. Please try again.");
                    return;
                }



                Console.Write("Enter the number of units you would like to order: ");
                if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
                {
                    Console.WriteLine("Invalid quantity. Please try again.");
                    return;
                }



                decimal originalPrice = driveType == DriveType.HDD ? 100m : 150m;
                decimal discount = driveType == DriveType.HDD ? 0.25m : 0.18m;
                decimal totalAmount = originalPrice * quantity;
                decimal discountedAmount = totalAmount - (totalAmount * discount);



                Console.WriteLine($"Total amount before discount: {totalAmount:C}");
                Console.WriteLine($"Total amount after discount: {discountedAmount:C}");



                decimal amountPaid;
                do
                {
                    Console.Write("Enter the amount you paid: ");
                    if (!decimal.TryParse(Console.ReadLine(), out amountPaid) || amountPaid < discountedAmount)
                    {
                        Console.WriteLine("Amount paid is insufficient, please pay more.");
                    }
                } while (amountPaid < discountedAmount);



                decimal change = amountPaid - discountedAmount;
                Console.WriteLine($"Change: {change:C}");



                customerTotals.Add(discountedAmount);
                numberOfCustomers++;



                if (driveType == DriveType.SSD)
                    totalSSDDrives += quantity;
                else
                    totalHDDDrives += quantity;



                Console.WriteLine("Purchase completed successfully!");
            }



            static void ViewCustomerTotals()
            {
                Console.WriteLine("---- Customer Totals ----");
                if (customerTotals.Count == 0)
                {
                    Console.WriteLine("No customer totals available.");
                }
                else
                {
                    for (int i = 0; i < customerTotals.Count; i++)
                    {
                        Console.WriteLine($"Customer {i + 1}: {customerTotals[i]:C}");
                    }
                }
            }



            static void DisplayCustomerOrders()
            {
                Console.WriteLine("---- Customer Orders ----");
                Console.WriteLine($"Number of customers: {numberOfCustomers}");
            }



            static void DisplayTotalSSDDrives()
            {
                Console.WriteLine("---- Total SSD Drives ----");
                Console.WriteLine($"Total SSD drives purchased: {totalSSDDrives}");
            }



            static void DisplayTotalHDDDrives()
            {
                Console.WriteLine("---- Total HDD Drives ----");
                Console.WriteLine($"Total HDD drives purchased: {totalHDDDrives}");
            }



            static void DisplayTotalAmountOfOrders()
            {
                Console.WriteLine("---- Total Amount of Customer Orders ----");
                if (customerTotals.Count == 0)
                {
                    Console.WriteLine("No customer orders available.");
                }
                else
                {
                    customerTotals.Sort();
                    customerTotals.Reverse();



                    foreach (decimal amount in customerTotals)
                    {
                        Console.WriteLine($"Total amount: {amount:C}");
                    }
                }
            }
        }
    }


   
