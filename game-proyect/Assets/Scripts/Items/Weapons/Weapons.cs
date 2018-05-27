using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a Weapons Object, in this class we define all properties that belongs to an weapon.
/// </summary>
public class Weapons : Items {

    public int Atk { get; set; }
    public bool Stackable { get; set; }
    public string Slug { get; set; }
    public int Value { get; set; }
    public bool Ranged { get; set; }
    public int Distance { get; set; }
    public int Speed { get; set; }


    /// <summary>
    /// Constructor of weapon class
    /// </summary>
    /// <param name="id">Weapon identification number</param>
    /// <param name="title">Name of the weapon</param>
    /// <param name="description">A description for the item</param>
    /// <param name="atk">Attack power</param>
    /// <param name="value">Value for selling to a NPC</param>
    /// <param name="ranged">Identify if is melee or not</param>
    public Weapons(int id, string title, string description, int atk, bool stackable, string slug, int value, bool ranged)
    {
        this.Id = id;
        this.Title = title;
        this.Description = description;
        this.Atk = atk;
        this.Stackable = stackable;
        this.Slug = slug;
        this.Value = value;
        this.Ranged = ranged;
    }

    /// <summary>
    /// Constructor of weapon class with overload for ranged weapons
    /// </summary>
    /// <param name="id">Weapon identification number</param>
    /// <param name="title">Name of the weapon</param>
    /// <param name="description">A description for the item</param>
    /// <param name="atk">Attack power</param>
    /// <param name="value">Value for selling to a NPC</param>
    /// <param name="ranged">Identify if is melee or not</param>
    /// <param name="distance">Weapon atack distance</param>
    /// <param name="speed">Weapon atack speed multiplier</param>
    public Weapons(int id, string title, string description, int atk, bool stackable, string slug, int value, bool ranged, int distance, int speed)
    {
        this.Id = id;
        this.Title = title;
        this.Description = description;
        this.Atk = atk;
        this.Stackable = stackable;
        this.Slug = slug;
        this.Value = value;
        this.Ranged = ranged;
        this.Distance = distance;
        this.Speed = speed;
    }

    /// <summary>
    /// This constructor prevents null values
    /// </summary>
    public Weapons() {
        this.Id = -1;
    }

    /// <summary>
    /// Public method to obtain a Weapons Object from the id.
    /// </summary>
    /// <param name="id">Parameter received</param>
    /// <returns>A new instance of Wapons object from existing object in the Dictionary with same properties.</returns>
    public Weapons getWeaponById(int id) {
        if (ResourcesLoader.indexedWeaponsDataBase.ContainsKey(id)) {
            Weapons weapon = new Weapons();
            ResourcesLoader.indexedWeaponsDataBase.TryGetValue(id, out weapon);
            return weapon;
        }
        return null;
    }

    /// <summary>
    /// ToString method show all properties of the object as a string format.
    /// </summary>
    /// <returns>Object properties</returns>
    override
    public string ToString() {
        string data;
        data = "Id: " + this.Id + "\n";
        data += "Title: " + I18n.Fields[this.Title] + "\n";
        data += "Description: " + I18n.Fields[this.Description] + "\n";
        data += "Atk: " + this.Atk + "\n";
        data += "Stackable: " + this.Stackable + "\n";
        data += "Slug: " + this.Slug + "\n";
        data += "Value: " + this.Value + "\n";
        if (this.Ranged == true)
        {
            data += "Ranged: " + this.Ranged + "\n";
            data += "Distance: " + this.Distance + "\n";
            data += "Speed: " + this.Speed;
        }
        else {
            data += "Ranged: " + this.Ranged;
        }
        return data;
    }
}
