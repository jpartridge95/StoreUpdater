# StoreUpdater

## What It does.

This store updater app is designed to take data from a txt file and through various business rules advance both the time remaining to sell the item and the quality value of the item.

## How to use it

You will want to clone the repo before going any further.

### Step One - Building the app

Using Powershell navigate to directory containing the source code you have cloned.

Run the following command (edit if you know what you are doing).

`dotnet publish InventoryUpdater -o C:\Users\[YourUsernameHere]\Documents\Updater\ProgramFiles`

Go Into your documents and look for the Updater folder, this is where all your application files live.

Inside the application folder create a new folder and name it Reports (Case sensitive).

#### Well done, you have completed setup ⭐

### Step two

Inside the reports folder create a .txt file with the data you need in.

**Notes**

The filename of the .txt file must be the current date in the following format DD-MM-YYYY for example the 21st of March 2015 would be 21-03-2015.txt

The list of items should be structured as so:

[**ProductName**] [**SellIn**] [**Quality**]

eg. Frozen Item 24 42

### Supported Items
- Frozen Item
- Fresh Item
- Soap
- Christmas Crackers
- Aged Brie
- *Any other input will be declared invalid*





