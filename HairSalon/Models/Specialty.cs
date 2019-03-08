using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Specialty
  {
    private string _name;
    private int _id;

    public Specialty(string specialtyName, int id = 0)
    {
      _name = specialtyName;
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

    public int GetId()
    {
      return _id;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM specialty;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Specialty> GetAll()
    {
      List<Specialty> allSpecialty = new List<Specialty> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM specialty;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int SpecialtyId = rdr.GetInt32(0);
        string specialtyName = rdr.GetString(1);
        Specialty newSpecialty = new Specialty(specialtyName, SpecialtyId);
        allSpecialty.Add(newSpecialty);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allSpecialty;
    }

    public static Specialty Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM specialty WHERE id = (@searchId);";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int SpecialtyId = 0;
      string SpecialtyName = "";
      while(rdr.Read())
      {
        SpecialtyId = rdr.GetInt32(0);
        SpecialtyName = rdr.GetString(1);
      }
      Specialty newSpecialty = new Specialty(SpecialtyName, SpecialtyId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newSpecialty;
    }

    public List<Stylist> GetStylists()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT stylist.* FROM specialty
          JOIN stylists_specialties ON (specialty.id = stylists_specialties.specialty_id)
          JOIN stylist ON (stylists_specialties.stylist_id = stylist.id)
          WHERE specialty.id = @SpecialtyId;";
      MySqlParameter specialtyId = new MySqlParameter();
      specialtyId.ParameterName = "@SpecialtyId";
      specialtyId.Value = _id;
      cmd.Parameters.Add(specialtyId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      List<Stylist> stylists = new List<Stylist> {};
      while(rdr.Read())
      {
          int stylistId = rdr.GetInt32(0);
          string stylistName = rdr.GetString(1);
          Stylist foundStylist = new Stylist(stylistName, stylistId);
          stylists.Add(foundStylist);
      }
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
      return stylists;
    }

    public override bool Equals(System.Object otherSpecialty)
    {
      if (!(otherSpecialty is Specialty))
      {
        return false;
      }
      else
      {
        Specialty newSpecialty = (Specialty) otherSpecialty;
        bool idEquality = this.GetId().Equals(newSpecialty.GetId());
        bool nameEquality = this.GetName().Equals(newSpecialty.GetName());
        return (idEquality && nameEquality);
      }
    }

    public override int GetHashCode()
    {
        return this.GetId().GetHashCode();
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO specialty (name) VALUES (@name);";
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@name";
      name.Value = this._name;
      cmd.Parameters.Add(name);
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void Edit(string newSpecialty)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE specialty SET name = @newName WHERE id = @searchId;";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = _id;
      cmd.Parameters.Add(searchId);
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@newName";
      name.Value = newSpecialty;
      cmd.Parameters.Add(name);
      cmd.ExecuteNonQuery();
      _name = newSpecialty;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void Delete(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM specialty WHERE id = @thisId;DELETE FROM stylists_specialties WHERE specialty_id = @thisId;";
      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = id;
      cmd.Parameters.Add(thisId);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void AddStylist(Stylist newStylist)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylists_specialties (stylist_id, specialty_id) VALUES (@StylistId, @SpecialtyId);";
      MySqlParameter stylist_id = new MySqlParameter();
      stylist_id.ParameterName = "@StylistId";
      stylist_id.Value = newStylist.GetId();
      cmd.Parameters.Add(stylist_id);
      MySqlParameter specialty_id = new MySqlParameter();
      specialty_id.ParameterName = "@SpecialtyId";
      specialty_id.Value = _id;
      cmd.Parameters.Add(specialty_id);
      cmd.ExecuteNonQuery();
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
    }
  }
}
