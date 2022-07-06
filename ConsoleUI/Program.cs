using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // ColorTest();


                CarManager carManager = new CarManager(new EfCarDal());

                var result = carManager.GetCarDetails();

            if (result.Success)
            {

                foreach (var car in result.Data)
                {
                    Console.WriteLine("Araba İsmi / " + car.CarName + "Marka / " + car.BrandName + "Renk / " + car.ColorName + "Fiyat / " + car.DailyPrice);

                }

            }

            else
            {
                Console.WriteLine(result.Message);
            }
            }
        } 
    }

