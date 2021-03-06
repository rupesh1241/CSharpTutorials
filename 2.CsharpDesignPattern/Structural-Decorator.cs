﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpDesignPattern
{
    class Structural_Decorator
    {
        public interface ICar
        {
            ICar ManufactureCar();
        }

        public class BMWCar : ICar
        {
            private string CarName = "BMW";
            public string CarBody { get; set; }
            public string CarDoor { get; set; }
            public string CarWheels { get; set; }
            public string CarGlass { get; set; }
            public string Engine { get; set; }
            public override string ToString()
            {
                return "BMWCar [CarName=" + CarName + ", CarBody=" + CarBody + ", CarDoor=" + CarDoor + ", CarWheels="
                                + CarWheels + ", CarGlass=" + CarGlass + ", Engine=" + Engine + "]";
            }
            public ICar ManufactureCar()
            {
                CarBody = "carbon fiber material";
                CarDoor = "4 car doors";
                CarWheels = "6 car glasses";
                CarGlass = "4 MRF wheels";
                return this;
            }
        }
        public abstract class CarDecorator : ICar
        {
            protected ICar car;
            public CarDecorator(ICar car)
            {
                this.car = car;
            }
            public virtual ICar ManufactureCar()
            {
                return car.ManufactureCar();
            }
        }
        public class DieselCarDecorator : CarDecorator
        {
            public DieselCarDecorator(ICar car) : base(car)
            {
            }
            public override ICar ManufactureCar()
            {
                car.ManufactureCar();
                AddEngine(car);
                return car;
            }
            public void AddEngine(ICar car)
            {
                if (car is BMWCar)
                {
                    BMWCar BMWCar = (BMWCar)car;
                    BMWCar.Engine = "Diesel Engine";
                    Console.WriteLine("DieselCarDecorator added Diesel Engine to the Car : " + car);
                }
            }
        }
        public class PetrolCarDecorator : CarDecorator
        {
            public PetrolCarDecorator(ICar car) : base(car)
            {
            }
            public override ICar ManufactureCar()
            {
                car.ManufactureCar();
                AddEngine(car);
                return car;
            }
            public void AddEngine(ICar car)
            {
                if (car is BMWCar)
                {
                    BMWCar BMWCar = (BMWCar)car;
                    BMWCar.Engine = "Petrol Engine";
                    Console.WriteLine("PetrolCarDecorator added Petrol Engine to the Car : " + car);
                }
            }
        }

        
    }
    class DecoratorPattern
    {
        static void Main(string[] args)
        {
            Structural_Decorator.ICar bmwCar1 = new Structural_Decorator.BMWCar();
            bmwCar1.ManufactureCar();
            Console.WriteLine(bmwCar1 + "\n");
            Structural_Decorator.DieselCarDecorator carWithDieselEngine = new Structural_Decorator.DieselCarDecorator(bmwCar1);
            carWithDieselEngine.ManufactureCar();
            Console.WriteLine();
            Structural_Decorator.ICar bmwCar2 = new Structural_Decorator.BMWCar();
            Structural_Decorator.PetrolCarDecorator carWithPetrolEngine = new Structural_Decorator.PetrolCarDecorator(bmwCar2);
            carWithPetrolEngine.ManufactureCar();
            Console.ReadKey();
        }
    }
}
