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

                foreach (var car in carManager.GetCarDetails())
                {
                    Console.WriteLine("Araba İsmi " + car.CarName + "Marka" + car.BrandName + "Renk" + car.ColorName + "Fiyat" + car.DailyPrice);
                    
                }
            }
        } 
    }

