# StoreUpdater

## What It does.

This store updater app is designed to take data from a txt file and through various business rules advance both the time remaining to sell the item and the quality value of the item.

## How to use it

### Step one

After cloning the repo, Create a .txt file in the Reports folder of the InventoryUpdater project folder.

One has been Provided for you but you may need to change the date to the current date.

**Notes**

The filename of the .txt file must be the current date in the following format DD-MM-YYYY for example the 21st of March 2015 would be 21-03-2015.txt

The list of items should be structured as so:

[**ProductName**] [**SellIn**] [**Quality**]


### Step Two

**Option one** 

Using powershell navigate to the InventoryUpdater directory in the solution and type

`dotnet run`

If you need any assistance using Powershell check out Microsoft's introduction to it [here](https://docs.microsoft.com/en-us/learn/modules/introduction-to-powershell/)
