using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour {

    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    /// <summary>
    /// Constructor of Item class
    /// </summary>
    /// <param name="id">Items identification number</param>
    /// <param name="title">Name of the item</param>
    /// <param name="description">A description for the item</param>
    public Items(int id, string title, string description) {
        this.Id = id;
        this.Title = title;
        this.Description = description;
    }

    public Items() {
    }
}
