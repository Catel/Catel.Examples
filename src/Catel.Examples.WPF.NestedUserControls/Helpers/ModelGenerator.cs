namespace Catel.Examples.NestedUserControls
{
    using System;
    using System.Collections.Generic;
    using Collections;
    using Models;

    public static class ModelGenerator
    {
        private static readonly Random _random = new Random();
        private static readonly Random _priceGenerator = new Random();


        public static HouseModel[] GenerateHouses()
        {
            return GenerateHouses(_random.Next(1, 5));
        }

        public static HouseModel[] GenerateHouses(int numberOfHouses)
        {
            var houses = new List<HouseModel>();

            for (int i = 0; i < numberOfHouses; i++)
            {
                houses.Add(GenerateHouse(string.Format("House {0}", i + 1)));
            }

            return houses.ToArray();
        }

        public static HouseModel GenerateHouse(string name)
        {
            var price = (decimal) (_priceGenerator.NextDouble() * 42.42d);

            var house = new HouseModel(name, price);
            house.Rooms.AddRange(GenerateRooms());
            return house;
        }

        public static RoomModel[] GenerateRooms()
        {
            return GenerateRooms(_random.Next(1, 5));
        }

        public static RoomModel[] GenerateRooms(int numberOfRooms)
        {
            var rooms = new List<RoomModel>();

            for (int i = 0; i < numberOfRooms; i++)
            {
                rooms.Add(GenerateRoom(string.Format("Room {0}", i + 1)));
            }

            return rooms.ToArray();
        }

        public static RoomModel GenerateRoom(string name)
        {
            var room = new RoomModel(name);
            return room;
        }
    }
}
