# Zacks lottery app for Mkodo

## Overview
I have created a lottery maui app using MVVM and the SOLID design principles.

## Features
The app opens on the homepage which shows a collection of all the draws, ordered by date descending. 
When the user taps on one it will open a detail view with a grid of prizes (prize information is hardcoded due to time constraints). 
The user can swipe through these to see other draws.

## Architecture
I used CommunityToolkit.Mvvm as it makes it simple and means I didnt have to reinvent the wheel in order to use MVVM architecture. 
Using MVVM meant that I could separate what each class does.

Instead of using a swipe gesture to view the next draw details, I used a nuget package called CardsView.Maui. 
This adds the ability to swipe through smoothly, whilst showing a satisfying animation and means I saved time not haivng to recreate this manually.

I separated my projects out so that its easier to read and can be changed independently of each other. 
Each class is in a easy to understand folder, and all methods are appropriately named and return early to ensure ease of use. 

The data is picked up in the LottoLocalDataService and passed to the viewmodel. 
Then the view picks up this value and shows it on the UI. There is no logic in the views as this is all done in the viewmodels.

I used a color scheme with 2 colors to ensure it was consistent throughout.
I found a svg online to use as the logo, and incorporated this into the draws view to make it look more interesting than a normal border.

As this is a cross platform maui app, it will work on both android and ios without having to write native code. 
I have tested this on a Google Pixel 7, and an iphone SE.

## Testing
I used Nsubstitute for mocking as it is a simple but powerful tool to easily mock classes. 
Because I used dependency injection everywhere, it was easy to mock services.

## What I would have done with more time

I spent time making an api but couldnt get maui working with localhost in the timeframe. 
I would have fixed this to allow the option of getting the data from the api, and also added tests for this. 
However - the two classes that inherit from ILottoApiService show that you can swap them and it wont break the app due to dependency injection.

I would have added some pagination and option to filter the date etc. 
This way when there is a lot of data it wont get it all at once so the call is faster, and its easier for the user to find the date.

I would have extended the json to add more details about prizes etc in order to populate the details grid properly.

I would have added a "my tickets" button at the top of the home page that showed a collectionview similar to whats on the home page, but for the tickets that the user owns. 
This would have highlighted matching numbers and told the user if/how much they had won.
