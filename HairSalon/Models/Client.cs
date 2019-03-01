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

    public static List<Client> GetAll()
    {
      List<Client> allClients = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM client;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int ClientId = rdr.GetInt32(0);
        string ClientName = rdr.GetString(1);
        string ClientPhone = rdr.GetString(1);
        int Clientstylistid = rdr.GetInt32(3);
        Client newClient = new Client(ClientName, ClientPhone, Clientstylistid, ClientId);
        allClients.Add(newClient);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allClients;
    }
    //
    // public static void ClearAll()
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"DELETE FROM Client;";
    //   cmd.ExecuteNonQuery();
    //   conn.Close();
    //   if (conn != null)
    //   {
    //    conn.Dispose();
    //   }
    // }
    //
    // public static Client Find(int id)
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"SELECT * FROM Client WHERE id = (@searchId);";
    //   MySqlParameter searchId = new MySqlParameter();
    //   searchId.ParameterName = "@searchId";
    //   searchId.Value = id;
    //   cmd.Parameters.Add(searchId);
    //   var rdr = cmd.ExecuteReader() as MySqlDataReader;
    //   int ClientId = 0;
    //   string ClientName = "";
    //   int Clientstylistid = 0;
    //   while(rdr.Read())
    //   {
    //     ClientId = rdr.GetInt32(0);
    //     ClientName = rdr.GetString(1);
    //     Clientstylistid = rdr.GetInt32(2);
    //   }
    //   Client newClient = new Client(ClientName, Clientstylistid, ClientId);
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    //   return newClient;
    // }
    //
    // public override bool Equals(System.Object otherClient)
    // {
    //   if (!(otherClient is Client))
    //   {
    //     return false;
    //   }
    //   else
    //   {
    //      Client newClient = (Client) otherClient;
    //      bool idEquality = this.GetId() == newClient.GetId();
    //      bool descriptionEquality = this.GetName() == newClient.GetName();
    //      bool categoryEquality = this.Getstylistid() == newClient.Getstylistid();
    //      return (idEquality && descriptionEquality && categoryEquality);
    //    }
    // }
    //
    // public void Save()
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"INSERT INTO Client (type, restaurant_id) VALUES (@Name, @restaurant_id);";
    //   MySqlParameter Name = new MySqlParameter();
    //   Name.ParameterName = "@Name";
    //   Name.Value = this._Name;
    //   cmd.Parameters.Add(Name);
    //   MySqlParameter stylistid = new MySqlParameter();
    //   stylistid.ParameterName = "@restaurant_id";
    //   stylistid.Value = this._stylistid;
    //   cmd.Parameters.Add(stylistid);
    //   cmd.ExecuteNonQuery();
    //   _id = (int) cmd.LastInsertedId;
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    // }
    //
    // public void Edit(string newName)
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"UPDATE Client SET type = @newType WHERE id = @searchId;";
    //   MySqlParameter searchId = new MySqlParameter();
    //   searchId.ParameterName = "@searchId";
    //   searchId.Value = _id;
    //   cmd.Parameters.Add(searchId);
    //   MySqlParameter type = new MySqlParameter();
    //   type.ParameterName = "@newType";
    //   type.Value = newName;
    //   cmd.Parameters.Add(type);
    //   cmd.ExecuteNonQuery();
    //   _Name = newName; // <--- This line is new!
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
    //   cmd.CommandText = @"DELETE FROM Client WHERE id = @thisId;";
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
