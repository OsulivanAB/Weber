using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace ListBoxesWPF
{
    public static class RestaurantModel
    {
        static RestaurantModel()
        {
            Restaurants = new List<Restaurant>
                              {
                                  new Restaurant {Name = "Anthony's Avocado Paradise", LogoResourceName = "Logo-Avocado", TypeOfFood = "Healthy Choice"},
                                  new Restaurant {Name = "Big Bum Burger", LogoResourceName = "Logo-Burger", TypeOfFood = "Fast Food"},
                                  new Restaurant {Name = "Birthday Geezer", LogoResourceName = "Logo-Birthday", TypeOfFood = "Desserts"},
                                  new Restaurant {Name = "Hiro's Dinette", LogoResourceName = "Logo-Waitress", TypeOfFood = "Diner"},
                                  new Restaurant {Name = "Nigel's Mug", LogoResourceName = "Logo-Mug", TypeOfFood = "Desserts"},
                                  new Restaurant {Name = "Pepper Pounder", LogoResourceName = "Logo-Pepper", TypeOfFood = "Dare Devil's Choice"},
                                  new Restaurant {Name = "The Crawfish Cruncher", LogoResourceName = "Logo-Crawfish", TypeOfFood = "Pub and Grille"},
                                  new Restaurant {Name = "The Horse's Carrot", LogoResourceName = "Logo-Carrot", TypeOfFood = "Healthy Choice"},
                                  new Restaurant {Name = "Wonky's Chocolate", LogoResourceName = "Logo-Chocolate", TypeOfFood = "Dessert"}
                              };
        }

        public static List<Restaurant> Restaurants { get; private set; }
    }

    public class Restaurant
    {
        public Restaurant()
        {
            Name = string.Empty;
            AverageRating = Randoms.Rating;
            LogoResourceName = string.Empty;
            Coordinates = Randoms.Coordinates;

            TypeOfFood = string.Empty;

            City = "Houston";
            Street = "12345 Westheimer Rd.";
            State = "TX";
            Zip = "77388";

            Phone = "555-123-4567";
        }

        public decimal AverageRating { get; set; }
        public string Name { get; set; }

        public Point Coordinates { get; set; }
        public double CoordinateX { get { return Coordinates.X; } }
        public double CoordinateY { get { return Coordinates.Y; } }
        public Thickness CoordinateMargin { get { return new Thickness(CoordinateX, Coordinates.Y, 0, 0); } }

        public string LogoResourceName { get; set; }
        private Brush _logo;
        public Brush Logo
        {
            get
            {
                if (_logo == null)
                    _logo = Application.Current.FindResource(LogoResourceName) as Brush;
                return _logo;
            }
        }

        public string TypeOfFood { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public string Phone { get; set; }
    }

    public static class Randoms
    {
        private static readonly Random _random = new Random(Environment.TickCount);

        public static decimal Rating 
        {
            get
            {
                int number = _random.Next(10, 50);
                return ((decimal)number) / 10;
            }
        }   

        public static Point Coordinates
        {
            get
            {
                int x = _random.Next(150, 1100);
                int y = _random.Next(100, 700);
                return new Point(x, y);
            }
        }

        public static int Angle
        {
            get
            {
                return _random.Next(10, 350);
            }
        }

        public static double Scale
        {
            get
            {
                return (double)_random.Next(50, 110)/100;
            }
        }

        public static double OffsetX
        {
            get
            {
                return _random.Next(0, 750);
            }
        }

        public static double OffsetY
        {
            get
            {
                return _random.Next(0, 500);
            }
        }
    }
}
