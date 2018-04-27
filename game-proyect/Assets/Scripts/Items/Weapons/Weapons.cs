using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This is a Item Object, in this class we define all properties that belongs to an item.
 */
public class Weapons : MonoBehaviour {

    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Atk { get; set; }
    public int Value { get; set; }

    /**
     * Constructor of Item class.
     */
    public Weapons(int id, string title, string description, int atk, int value){
        this.Id = id;
        this.Title = title;
        this.Description = Description;
        this.Atk = atk;
        this.Value = value;
    }

    /**
     * This constructor prevent null values for errors.
     */ 
    public Weapons() {
        this.Id = -1;
    }
}
