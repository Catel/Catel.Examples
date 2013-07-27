namespace Catel.Examples.AdvancedDemo
{
    using System;
    using System.Collections.Generic;
    using Models;
    using Catel.Collections;

    /// <summary>
    /// Class that generates models for demo purposes.
    /// </summary>
    public static class ModelGenerator
    {
        private static readonly Random _random = new Random();
        private static readonly Random _priceGenerator = new Random();

        /// <summary>
        /// Generates a random number (between 1 and 5) of houses.
        /// </summary>
        /// <returns>Array of <see cref="HouseModel"/> objects.</returns>
        public static HouseModel[] GenerateHouses()
        {
            return GenerateHouses(_random.Next(1, 5));
        }

        /// <summary>
        /// Generates the specified number of houses.
        /// </summary>
        /// <param name="numberOfHouses">The number of houses to generate.</param>
        /// <returns>Array of <see cref="HouseModel"/> objects.</returns>
        public static HouseModel[] GenerateHouses(int numberOfHouses)
        {
            var houses = new List<HouseModel>();

            for (int i = 0; i < numberOfHouses; i++)
            {
                houses.Add(GenerateHouse(string.Format("House {0}", i + 1)));
            }

            return houses.ToArray();
        }

        /// <summary>
        /// Generates a house with a random number of rooms.
        /// </summary>
        /// <param name="name">The name of the house.</param>
        /// <returns>Generated <see cref="HouseModel"/>.</returns>
        public static HouseModel GenerateHouse(string name)
        {
            var price = (decimal) (_priceGenerator.NextDouble() * 42.42d);

            var house = new HouseModel(name, price);
            house.Rooms.AddRange(GenerateRooms());
            return house;
        }

        /// <summary>
        /// Generates a random number (between 1 and 5) of rooms.
        /// </summary>
        /// <returns>
        /// Array of <see cref="RoomModel"/> objects.
        /// </returns>
        public static RoomModel[] GenerateRooms()
        {
            return GenerateRooms(_random.Next(1, 5));
        }

        /// <summary>
        /// Generates the specified number of rooms.
        /// </summary>
        /// <param name="numberOfRooms">The number of rooms to generate.</param>
        /// <returns>Array of <see cref="RoomModel"/> objects.</returns>
        public static RoomModel[] GenerateRooms(int numberOfRooms)
        {
            var rooms = new List<RoomModel>();

            for (int i = 0; i < numberOfRooms; i++)
            {
                rooms.Add(GenerateRoom(string.Format("Room {0}", i + 1)));
            }

            return rooms.ToArray();
        }

        /// <summary>
        /// Generates a room.
        /// </summary>
        /// <param name="name">The name of the room.</param>
        /// <returns>Generated <see cref="RoomModel"/>.</returns>
        public static RoomModel GenerateRoom(string name)
        {
            var room = new RoomModel(name);
            return room;
        }
    }
}
