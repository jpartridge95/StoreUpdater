# StoreUpdater

## What It does.

This store updater app is designed to take data from a txt file and through various business rules advance both the time remaining to sell the item and the quality value of the item.

## How to use it

You will want to clone the repo before going any further.

### Step One - Building the app

Using Powershell navigate to directory containing the source code you have cloned.

If you aren't comfortable on powershell Microsoft has a great intro [here](https://docs.microsoft.com/en-us/learn/modules/introduction-to-powershell/)

Run the following command (edit if you know what you are doing).

`dotnet publish InventoryUpdater -o C:\Users\[YourUsernameHere]\Documents\Updater\ProgramFiles`

Go Into your documents and look for the Updater folder, this is where all your application files live.

Inside the application folder create a new folder and name it Reports (Case sensitive).

#### Well done, you have completed setup ⭐

### Step two - Creating Your first report

Inside the reports folder create a .txt file with the data you need in.

**Notes**

The filename of the .txt file must be the current date in the following format DD-MM-YYYY for example the 21st of March 2015 would be 21-03-2015.txt

The list of items should be structured as so:

[**ProductName**] [**SellIn**] [**Quality**]

eg. Frozen Item 24 42

#### Supported Items
- Frozen Item
- Fresh Item
- Soap
- Christmas Crackers
- Aged Brie
- *Any other input will be declared invalid*

### Step Three - Running the program for the first time

Assuming you are still inside the reports folder, go back up a level in file explorer/Powershell.

Click on/Navigate into the ProgramFiles folder

Double click on InventoryUpdater.exe

#### Well done again, you just automatically generated your first report ⭐⭐

On the newly generated report feel free to add new rows for new products and then run it again tomorrow, for a new generated report.

### Step four - Creating Shortcuts (Optional)

If you wish to do so you can now go back to the ProgramFiles folder and right click on the .exe file and select create a shortcut. This shortcut can be placed anywhere, mine is on my desktop because its easy to get to.

The same thing can be done with the reports folder. Right click -> Create Shortcut -> Drag Shortcut to desktop.



