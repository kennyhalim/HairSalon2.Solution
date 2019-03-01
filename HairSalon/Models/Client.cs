using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Client
  {
    private string _name;
    private string _phoneNumber;
    private int _id;
    private int _stylistId;

    public Client (string name, string phoneNumber, int stylistId, int id = 0)
    {
      _name = name;
      _phoneNumber = phoneNumber;
      _stylistId = stylistId;
      _id = id;
    }

    public string GetName()
    {
      return _name;
    }

    public void SetName(string newName)
    {
      _name = newName;
    }

    public string GetPhoneNumber()
    {
      return _phoneNumber;
    }

    public int GetId()
    {
      return _id;
    }

    public int GetStylistId()
    {
      return _stylistId;
    }

    // public static List<Client> GetAll()
    // {
    //   List<Cuisine> allCuisines = new List<Cuisine> {};
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"SELECT * FROM cuisine;";
    //   var rdr = cmd.ExecuteReader() as MySqlDataReader;
    //   while(rdr.Read())
    //   {
    //     int cuisineId = rdr.GetInt32(0);
    //     string cuisineTypeOfFood = rdr.GetString(1);
    //     int cuisineRestaurantId = rdr.GetInt32(2);
    //     Cuisine newCuisine = new Cuisine(cuisineTypeOfFood, cuisineRestaurantId, cuisineId);
    //     allCuisines.Add(newCuisine);
    //   }
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    //   return allCuisines;
    // }
    //
    // public static void ClearAll()
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"DELETE FROM cuisine;";
    //   cmd.ExecuteNonQuery();
    //   conn.Close();
    //   if (conn != null)
    //   {
    //    conn.Dispose();
    //   }
    // }
    //
    // public static Cuisine Find(int id)
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"SELECT * FROM cuisine WHERE id = (@searchId);";
    //   MySqlParameter searchId = new MySqlParameter();
    //   searchId.ParameterName = "@searchId";
    //   searchId.Value = id;
    //   cmd.Parameters.Add(searchId);
    //   var rdr = cmd.ExecuteReader() as MySqlDataReader;
    //   int cuisineId = 0;
    //   string cuisineName = "";
    //   int cuisineRestaurantId = 0;
    //   while(rdr.Read())
    //   {
    //     cuisineId = rdr.GetInt32(0);
    //     cuisineName = rdr.GetString(1);
    //     cuisineRestaurantId = rdr.GetInt32(2);
    //   }
    //   Cuisine newCuisine = new Cuisine(cuisineName, cuisineRestaurantId, cuisineId);
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    //   return newCuisine;
    // }
    //
    // public override bool Equals(System.Object otherCuisine)
    // {
    //   if (!(otherCuisine is Cuisine))
    //   {
    //     return false;
    //   }
    //   else
    //   {
    //      Cuisine newCuisine = (Cuisine) otherCuisine;
    //      bool idEquality = this.GetId() == newCuisine.GetId();
    //      bool descriptionEquality = this.GetTypeOfFood() == newCuisine.GetTypeOfFood();
    //      bool categoryEquality = this.GetRestaurantId() == newCuisine.GetRestaurantId();
    //      return (idEquality && descriptionEquality && categoryEquality);
    //    }
    // }
    //
    // public void Save()
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"INSERT INTO cuisine (type, restaurant_id) VALUES (@typeoffood, @restaurant_id);";
    //   MySqlParameter typeoffood = new MySqlParameter();
    //   typeoffood.ParameterName = "@typeoffood";
    //   typeoffood.Value = this._typeOfFood;
    //   cmd.Parameters.Add(typeoffood);
    //   MySqlParameter restaurantId = new MySqlParameter();
    //   restaurantId.ParameterName = "@restaurant_id";
    //   restaurantId.Value = this._restaurantId;
    //   cmd.Parameters.Add(restaurantId);
    //   cmd.ExecuteNonQuery();
    //   _id = (int) cmd.LastInsertedId;
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    // }
    //
    // public void Edit(string newTypeOfFood)
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"UPDATE cuisine SET type = @newType WHERE id = @searchId;";
    //   MySqlParameter searchId = new MySqlParameter();
    //   searchId.ParameterName = "@searchId";
    //   searchId.Value = _id;
    //   cmd.Parameters.Add(searchId);
    //   MySqlParameter type = new MySqlParameter();
    //   type.ParameterName = "@newType";
    //   type.Value = newTypeOfFood;
    //   cmd.Parameters.Add(type);
    //   cmd.ExecuteNonQuery();
    //   _typeOfFood = newTypeOfFood; // <--- This line is new!
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    // }
    //
    // public void Delete(int id)
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"DELETE FROM cuisine WHERE id = @thisId;";
    //   MySqlParameter thisId = new MySqlParameter();
    //   thisId.ParameterName = "thisId";
    //   thisId.Value = id;
    //   cmd.Parameters.Add(thisId);
    //   cmd.ExecuteNonQuery();
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    // }

  }
}
