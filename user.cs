using System;
using System.Collections;
using System.Collections.Generic;
class user
{
    string name;
    string location;
    int ID;
    static int IDcount = 0;

    public user(string pName, string pLocation)
    {
        this.setName(pName);
        this.setLocation(pLocation);
        this.ID = IDcount;
        IDcount++;
    }
    
    public string getName()//gets user name
    {
        return this.name;
    }
    public string getLocation()//gets user location
    {
        return this.location;
    }
    public int getID()//returns user ID - ID is set by the program and cannot be changed by user
    {
        return this.ID;
    }
    public void setName(string pName)//allows user to set their name
    {
        this.name = pName;
    }
    public void setLocation(string pLocation)//allows user to set their location
    {
        this.location = pLocation;
    }

public void requestRide(driver pDriver)//requests a ride from a selected driver
{
    pDriver.addRequest(this.getLocation());
}

}
class driver:user
{
    List<string> locations;//list of locations to drive to
    Dictionary<int,string> requests;//list of ride requests from other users.
    int requestID = 0;
    public driver(string pName,string pLocation):base(pName,pLocation)
    {
        this.setName(name);
        this.setLocation(pLocation);
        this.locations = new List<string>();
        this.requests = new Dictionary<int,string>();
    }
    public void addLocation(string pLocation)//adds location to drive to when driver approves request
    {
        this.locations.Add(pLocation);
    }
    public void removeLocation(string pLocation)//removes location to drive to - main use probably for when journey is complete
    {
        foreach(string s in locations)
        {
            if(s == pLocation)
            {
                locations.Remove(s);
            }
        }
    }
    public void addRequest(string pLocation)//adds a request for the driver to view and either approve or deny
    {
        requests.Add(this.requestID,pLocation);
        this.requestID++;
    }
    public void approveRequest(int pID)//allows driver to approve request. Location is then added to locations for the driver to drive to
    {
        foreach(KeyValuePair KVP in this.requests)
        {
            if(KVP.Key == pID)
            {
                this.addLocation(KVP.Value);
            }
        }
    }
public void denyRequest(int pID)//allows driver to deny a request, request is subsequently removed from their request list
{
    this.requests.Remove(pID);
}

}