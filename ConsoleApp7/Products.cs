using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace productswidthobject
{
    internal class Products
    {



        decimal productquantity, productprice, totalprice;
        decimal totalpricepc = 0M, totalpricemobile = 0M;
        decimal totalquantity, totalquantitypc = 0, totalquantitymobile = 0;
        ArrayList productspc, productsmobile, allproduct;

        public Products()
        {

            productspc = new ArrayList();
            productsmobile = new ArrayList();
            allproduct = new ArrayList();
            totalprice = 0M;
            totalquantity = 0;

        }

        //1.Pc , 2.Mobile

        public void Add(string brand, string model, decimal price, int quantity, string category)
        {

            ArrayList product = new ArrayList();

            product.Add(brand);
            product.Add(model);
            product.Add(price);
            product.Add(quantity);
            product.Add(category);

            category = category.ToLower();
            if (category == "pc")
            {
                productspc.Add(product);
                totalpricepc += price * quantity;
                totalquantitypc += quantity;
            }
            else if (category == "mobile")
            {
                productsmobile.Add(product);
                totalquantitymobile += quantity;
                totalpricemobile += price * quantity;
            }

            totalprice += totalpricepc + totalpricemobile;
            totalquantity += totalquantitymobile + totalquantitypc;


            foreach (dynamic productinpc in productspc)
            {

                allproduct.Add(productinpc);

            }


            foreach (dynamic productinmobile in productsmobile)
            {

                allproduct.Add(productinmobile);

            }


        }

        public void Showproducts()
        {
            int counter = 1;
            //foreach (ArrayList arrayList in allproduct)
            //{

            foreach (dynamic items in productspc)
            {
                Console.WriteLine($"\nProduct: {counter}");

                foreach (dynamic item in items)
                {
                    Console.WriteLine(item);
                }
                counter++;
            }


            foreach (dynamic items in productsmobile)
            {
                Console.WriteLine($"\nProduct: {counter}");

                foreach (dynamic item in items)
                {
                    Console.WriteLine(item);
                }
                counter++;
            }




        }


        public ArrayList GetAllProducts()
        {


            return allproduct;
        }
        public decimal ShowTotalPrices()
        {

            return totalprice;

        }


        public decimal TotalpriceBycategory(string category)
        {

            if (category == "1")
            {
                return totalpricepc;
            }
            else if (category == "2")
            {

                return totalpricemobile;
            }
            else
            {
                return 0M;
            }

        }
        public void ShowbyCategory(string category)
        {


            if (category == "1")
            {
                foreach (var items in productspc)
                {
                    foreach (var model in (ArrayList)items)
                    {
                        Console.WriteLine(model);
                    }

                }
                Console.ReadLine();
            }
            else if (category == "2")
            {
                foreach (var items in productsmobile)
                {
                    foreach (var item in (ArrayList)items)
                    {
                        Console.WriteLine(item);
                    }
                }
                Console.ReadLine();
            }

        }

        public decimal Totalquantity()
        {
            return totalquantity;
        }

        public decimal Totalquantitipc()
        {
            return totalquantitypc;
        }
        public decimal Totalquantitimobile()
        {
            return totalquantitymobile;
        }


        public void Sell(int count)
        {





            ArrayList selectedProduct = (ArrayList)allproduct[count - 1];


            int currentQuantity = Convert.ToInt32(selectedProduct[3]);

            if (currentQuantity > 0)
            {

                selectedProduct[3] = currentQuantity - 1;
                Console.WriteLine("Product sold successfully.");
                Console.ReadLine();

            }
            else
            {
                Console.WriteLine("Product is out of stock.");
            }


        }
    }
}


