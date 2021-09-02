using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FeesCalculator
{
    class Program
    {
        //Comman variables
        static String S_name;
        static String S_ID;
        static int M = 0;
        static Customers _cust;
        static String C_name = "null";
        static Decimal Tmp_value = 00;
        static Decimal T_value = 2000;
        static String Mx_result = "null";
        static Decimal Mx_amount = 0;
        static int less_12 = 0;
        static int great_12 = 0;

        static LinkedList<Customers> unit_cust = new LinkedList<Customers>(); //linked list is used to store the customer information

        //Main function start of the execution
        static void Main(string[] args)
        {

            //reading the basic info from console
            Console.WriteLine("Student Name : Krutik Patel");

            Console.WriteLine("Student ID : s4584505");



            M = 8;
            Console.WriteLine("Please input " + M + " " + "Customer Information");
            //loop to read the data for the customer from the console.
            for (int k = 1; k < M + 1; k++)
            {
                Readandwrite(k); //calling function inside the loop
            }
            PrintSummery();
            PrintMinAndMax();
            PrintGreaterAndLesserThan12();

        }
        //Function to Read the customer detail from the console and store them inside the list
        //if condition is to apply the discount to customer who have the offer status as Y
        //if loop to evaluate the bill as per the month of the membership
        public static void Readandwrite(int i)
        {
            _cust = new Customers();
            Console.WriteLine("Please enter the information for CustomerData " + i);
            Console.Write("Customer Name :");
            _cust.Cust_name = Console.ReadLine();
            Console.Write("Number of month of the membership (1-120) :");

            _cust.cust_month = Int32.Parse(Console.ReadLine());
            if (1 < _cust.cust_month && _cust.cust_month <= 12)
            {

                _cust.cust_fees = 10 * _cust.cust_month;
            }
            else if (12 < _cust.cust_month && _cust.cust_month <= 24)
            {

                _cust.cust_fees = Convert.ToDecimal(7.50) * _cust.cust_month;
            }
            else if (24 <= _cust.cust_month)
            {

                _cust.cust_fees = 5 * _cust.cust_month;
            }

            Console.Write("Receive Special offer? (YES or NO):");
            _cust.cust_offer = Console.ReadLine();
            if (_cust.cust_offer.ToUpper() == "Y")
            {

                _cust.cust_fees = _cust.cust_fees - (_cust.cust_fees * Convert.ToDecimal(0.1));
            }

            Console.Write("The memeber ship fee for " + _cust.Cust_name + "  is $" + _cust.cust_fees);
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------");

            unit_cust.AddFirst(_cust);

            Console.ReadLine();

        }
        //Function to Print the summery of the members
        public static void PrintSummery()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("           Summery of Membership Fee");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("------------------------------------------");
            //For each loop to print all the customer deatil on the console one by one.

            foreach (Customers data in unit_cust)
            {
                Console.WriteLine(data.Cust_name + "         " + data.cust_month + "        " + data.cust_offer + "        " + "$" + data.cust_fees);
            }
            Console.WriteLine("-----------------------------------------------");
        }

        //function to evaluate the maximum fee paying customer and minimum fee paying customer.
        public static void PrintMinAndMax()
        {
            Console.WriteLine();
            foreach (Customers data in unit_cust)
            {
                if (T_value > data.cust_fees)
                {
                    T_value = data.cust_fees;
                    C_name = data.Cust_name;
                    Tmp_value = data.cust_fees;

                }
            }

            Console.WriteLine("The CustomerData spending the least " + C_name + " " + "$" + Tmp_value);

            T_value = 0;



            foreach (Customers data in unit_cust)
            {
                if (data.cust_fees > T_value)
                {
                    T_value = data.cust_fees;
                    Mx_result = data.Cust_name;
                    Mx_amount = data.cust_fees;

                }

            }
            Console.WriteLine("CustomerData Spending the most is " + Mx_result + ": $" + Mx_amount);
        }

        //Function to evaluate the memeber have greater than 12 month and less than the 12 months.
        public static void PrintGreaterAndLesserThan12()
        {
            Console.WriteLine();
            foreach (Customers cust2 in unit_cust)
            {
                if (cust2.cust_month < 12)
                {
                    ++less_12;
                }
                else
                {
                    ++great_12;
                }

            }

            Console.WriteLine();
            Console.WriteLine("The number of member with <12 Months :" + less_12);
            Console.WriteLine("The number of member with >=12 Months :" + great_12);
            Console.ReadLine();
        }
    }
}