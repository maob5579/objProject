using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MoodWcfService.Entities;
using MoodWcfService.Model;

namespace MoodWcfService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RestaurantService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RestaurantService.svc or RestaurantService.svc.cs at the Solution Explorer and start debugging.
    public class RestaurantService : IRestaurantService
    {
        public List<Restaurant_> GetAllRestaurants()
        {
            using (MoodFullEntities moodFullDb = new MoodFullEntities())
            {
                return moodFullDb.Restaurants.Select(x => new Restaurant_
                {
                    RestaurantId = x.RestaurantId,
                    Name = x.Name,
                    AvgMood = x.AvgMood.Value,
                    AvgPrice = x.AvgPrice.Value,
                    AvgExperience = x.AvgExperience.Value
                }).ToList();
            };
        }
        public Restaurant_ GetRestaurantById(string restId)
        {
            using (MoodFullEntities moodFullDb = new MoodFullEntities())
            {
                int restaurantID = Convert.ToInt32(restId);
                return moodFullDb.Restaurants.Where(x => x.RestaurantId == restaurantID).Select(x => new Restaurant_
                {
                    RestaurantId = x.RestaurantId,
                    Name = x.Name,
                    AvgMood = x.AvgMood.Value,
                    AvgPrice = x.AvgPrice.Value,
                    AvgExperience = x.AvgExperience.Value
                }).FirstOrDefault();
            }
        }

        public bool CreateRestaurant(Restaurant_ restaurant)
        {
            using (MoodFullEntities moodFullDb = new MoodFullEntities())
            {
                try
                {
                    Restaurant xe = new Restaurant();
                    xe.Name = restaurant.Name;
                    xe.AvgMood = restaurant.AvgMood;
                    xe.AvgPrice = restaurant.AvgPrice;
                    xe.AvgExperience = restaurant.AvgExperience;
                    moodFullDb.Restaurants.Add(xe);
                    moodFullDb.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool EditRestaurant(Restaurant_ restaurant)
        {
            using (MoodFullEntities moodFullDb = new MoodFullEntities())
            {
                try
                {
                    int restaurantId = Convert.ToInt32(restaurant.RestaurantId);
                    Restaurant xe = moodFullDb.Restaurants.Single(x => x.RestaurantId == restaurantId);
                    xe.Name = restaurant.Name;
                    xe.AvgMood = restaurant.AvgMood;
                    xe.AvgPrice = restaurant.AvgPrice;
                    xe.AvgExperience = restaurant.AvgExperience;
                    moodFullDb.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            };
        }
        public bool DeleteRestaurant(Restaurant_ restaurant)
        {
            using (MoodFullEntities moodFullDb = new MoodFullEntities())
            {
                try
                {
                    int restaurantID = Convert.ToInt32(restaurant.RestaurantId);
                    Restaurant xe = moodFullDb.Restaurants.Single(x => x.RestaurantId == restaurantID);
                    moodFullDb.Restaurants.Remove(xe);
                    moodFullDb.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

        }
    }
}
