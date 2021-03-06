﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApartmentFinderDAL;
namespace ApartmentFinderWebAPI.Models
{
    public class Room
    {
        private int numBeds;
        private int numBaths;
        private string roomNumber;
        private bool isFilled;
        private double price;
        private string pictureURL;
        public Room()
        {

        }
        public Room(int numBeds,int numBaths, string roomNumber, bool isFilled, double price, string pictureURL)
        {
            this.numBeds = numBeds;
            this.numBaths = numBaths;
            this.roomNumber = roomNumber;
            this.isFilled = isFilled;
            this.price = price;
            this.pictureURL = pictureURL;
        }

        public int NumBeds { get { return numBeds; } set { numBeds = value; } }
        public int NumBaths { get { return numBaths; } set { numBaths = value; } }
        public double Price { get { return price; } set { price = value; } }
        public bool IsFilled { get { return isFilled; } set { isFilled = value; } }
        public string PictureURL { get { return pictureURL; } set { pictureURL = value; } }
        public string RoomNumber { get { return roomNumber; } set { roomNumber = value; } }

    }
}