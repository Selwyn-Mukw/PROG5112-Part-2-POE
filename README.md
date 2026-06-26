# CybersecurityChatbot
This is my POE bot which i created which will be able to interact and educate a user whom is interested in learning Cyber security
List of items that were implemented in Part 2
-CREATE A WPF
-Create all the required classes which will hold the logic of the bot
-MainWindow.xaml :This is where i desginded the GUI , creating blocks where the acsii art will be displayed, the name of the bot,the colour scheme alos of the bot , the font of the texts and create a section which will be for the chat history and create a send buttion which user will press when they have to send a response or answer.
-MainWindow.xaml.cs :This is where i added my welcome greeting which will play as the app/bot is launched, followed by the acsii art with a welcome message 
-KeywordResponder.xaml:This is where i created the response logic which will be stored in a list instead of an array .the user name will also be stored ansd saved then later on be recalled if the user uses the app for more than 3 attemopts with the suitable topics.STored a list of the answers for the keywords which will be randomly generated when a user chooses a word .I created a menu method that has a list of chooseable topics that the user can use ,Also created a user interest method which will display the users name after 3 rounds of choosing topics as an interest .
-Sentiment.cs This is where the bot will be able to pick up if the user is sad or worried and the bot will be able to give a few caring words to the user to try comfort them,also created a list of responsesd that the bot will use upon a certain response.
This bot runs based on the inputs of the user whereby the user will enter their name and describe how they are feeling.once user describes there feeling the bot will responnd based on what the user inputs .This bot will drop a list of all the topics which have a list of different meaning which will be randomly generated based on whta the user chooses.The user can choose differenty topics after 33 topic sthe bot will remmebr the users name and mention that they are really interested in cyber security.The user can end the program by pressing 0 which will kill the program.if the user logs back in the bot will remember the name as soon as the user inputs it.
MemoryStore.cs: this will store the memory and will be able to rewcall the users name should they type it after ending the session the bot will welcome the user back

Part3 
# Cybersecurity Chatbot – Part 3

## Project Overview

This project is a C# WPF Cybersecurity Chatbot developed as part of my Software Development coursework. The application provides users with cybersecurity guidance while incorporating task management, reminders, quizzes, natural language processing (NLP), and activity logging to create a more interactive and intelligent user experience.

## Features Implemented

### Cybersecurity Chatbot

* Interactive chatbot with a graphical WPF interface.
* Cybersecurity-themed UI with ASCII banner and welcome sound.
* Keyword-based cybersecurity assistance and responses.
* Rich chat history display.

### Task Assistant

* Add new cybersecurity-related tasks.
* Mark tasks as complete.
* Delete tasks.
* Display current tasks.
* Persistent task storage using local file storage.
* Tasks include a title, description, reminder, completion status, and unique ID.

### Cybersecurity Quiz

* Interactive cybersecurity quiz system.
* Multiple-choice and True/False questions.
* Automatic answer validation.
* Real-time score tracking.
* Explanations for correct and incorrect answers.
* Quiz completion summary.
* Support for multiple cybersecurity questions.

### Natural Language Processing (NLP)

The chatbot recognises user intent instead of relying solely on exact keywords.

Supported intents include:

* Start a cybersecurity quiz.
* Create new tasks.
* Set reminders.
* Display activity logs.

Example user commands include:

* "Start quiz"
* "Quiz me"
* "Add task"
* "Create a task"
* "Remind me to update my password"
* "Don't forget to backup my files"
* "Show activity log"

### Reminder System

* Extracts reminder information from natural language.
* Automatically creates reminder tasks.
* Confirms reminder creation to the user.

### Activity Logger

The chatbot records important user activities including:

* Quiz started.
* Quiz completed.
* Task added.
* Task completed.
* Task deleted.
* Reminder created.

Users can request their recent activity log through natural language.

### Data Persistence

* Tasks are automatically saved.
* Tasks are reloaded when the application starts.
* User progress is maintained between sessions.

### User Interface

* Modern cybersecurity-themed design.
* Dedicated chatbot panel.
* Integrated quiz section.
* Task management panel.
* Improved layout using WPF Grid controls.
* Rich text conversation display.

## Technologies Used

* C#
* Windows Presentation Foundation (WPF)
* .NET
* Object-Oriented Programming (OOP)
* JSON/File Storage
* Git & GitHub
* GitHub Actions

## Key Learning Outcomes

This project demonstrates:

* Object-Oriented Programming principles.
* Event-driven programming.
* GUI development with WPF.
* File handling and data persistence.
* Basic Natural Language Processing (NLP).
* Task and reminder management.
* Activity logging.
* Git version control and GitHub collaboration.

## Project Status

Part 3 successfully implements an intelligent cybersecurity chatbot featuring task management, reminders, quiz functionality, activity logging, persistent storage, and NLP-based intent recognition, providing users with an engaging cybersecurity learning experience.

here is a link to my youtube video https://youtu.be/gMWKY2o-7w8

<img width="1920" height="1080" alt="Screenshot 2026-06-25 220413" src="https://github.com/user-attachments/assets/cb0e5b39-8e77-41ac-8b3c-ceeaa21e3e02" />
<img width="1920" height="1080" alt="Screenshot 2026-06-25 220603" src="https://github.com/user-attachments/assets/4ba3c3a2-e581-4d41-96f5-c4e4f316cc18" />

